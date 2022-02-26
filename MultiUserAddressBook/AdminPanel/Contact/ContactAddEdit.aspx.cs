using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("/AdminPanel/UserLogin", true);
        }
        if (!IsPostBack)
        {
            FillDropDownList();
            FillCBLContactCategoryID();
            if (Page.RouteData.Values["OprationName"].ToString().Trim() != "Add")
            {
                FillControls(EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));      
            }
        }
    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(string ContactID)
    {
        
        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        fuProfilePicture.Visible = false;
        #endregion Variable | Conn string

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserIDContactID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContectName.Text = objSDR["ContactName"].ToString();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                }
                FillDropDownList();
            }
            objSDR.Close();

            #region Fill  ContactCategory
            DataTable dt = new DataTable();
            SqlCommand objCmdContactCategory = objConn.CreateCommand();
            objCmdContactCategory.CommandType = CommandType.StoredProcedure;
            objCmdContactCategory.CommandText = "PR_ContactCategory_SelectCheckedContactCategoryByUserIDContactID";
            objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID);
            objCmdContactCategory.Parameters.AddWithValue("@UserID", strUserID);
            SqlDataReader objSDRContactCategory = objCmdContactCategory.ExecuteReader();
            dt.Load(objSDRContactCategory);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr["SelectedOrNot"].Equals(DBNull.Value))
                    {
                        if (dr["SelectedOrNot"].ToString().Trim() == "Selected")
                        {
                            if (dr["ContactCategoryName"].ToString().Trim() == cblContactCategoryID.Items[i].Text && dr["ContactCategoryID"].ToString().Trim() == cblContactCategoryID.Items[i].Value)
                            {
                                cblContactCategoryID.Items[i].Selected = true;
                            }
                        }
                        i++;
                    }
                }
                //wrong coding
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (dt.Rows[i][2].ToString() == "Selected")
                //    {
                //        cblContactCategoryID.Items[i].Selected = true;
                //    }
                //}
            }
            #endregion Fill ContactCategory
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Execute | Close

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion Try | Catch | Finally
    }
    #endregion Fill Controls

    #region Btn Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Declare Variable
        SqlString strUserID = SqlString.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlDateTime dateBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32 intAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlInt32 intCountryID = SqlInt32.Null;
        SqlInt32 intStateID = SqlInt32.Null;
        SqlInt32 intCityID = SqlInt32.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strErrorMsg = "";
        String strFileLocationToSave = "~/UserImg/";
        String strPhysicalPath = "";
        SqlString strAttributes = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Declare Variable

        #region Server Side Validation
        if (txtContectName.Text.Trim() == "")
            strErrorMsg += "Enter Contact Name <br/>";
        if (txtContactNo.Text.Trim() == "")
            strErrorMsg += "Enter Contact Number <br/>";
        if (txtEmail.Text.Trim() == "")
            strErrorMsg += "Enter Email ID <br/>";
        if (txtAddress.Text.Trim() == "")
            strErrorMsg += "Enter Address <br/>";
        if (ddlCountryID.SelectedIndex == 0)
            strErrorMsg += "Select Country <br/>";
        if (ddlStateID.SelectedIndex == 0)
            strErrorMsg += "Select State <br/>";
        if (ddlCityID.SelectedIndex == 0)
            strErrorMsg += "Select City <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        if (txtContectName.Text.Trim() != "")
            strContactName = txtContectName.Text.Trim();
        if (txtContactNo.Text.Trim() != "")
            strContactNo = txtContactNo.Text.Trim();
        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();
        if (ddlCountryID.SelectedIndex != 0)
            intCountryID = Int32.Parse(ddlCountryID.SelectedValue);
        if (ddlStateID.SelectedIndex != 0)
            intStateID = Int32.Parse(ddlStateID.SelectedValue);
        if (ddlCityID.SelectedIndex != 0)
            intCityID = Int32.Parse(ddlCityID.SelectedValue);
        dateBirthDate = DateTime.Parse(txtBirthDate.Text.Trim());
        intAge = Int32.Parse(txtAge.Text.Trim());
        strBloodGroup = txtBloodGroup.Text.Trim();
        #endregion Assigne Value

        #region File Upload
        if (fuProfilePicture.HasFile)
        {
            strPhysicalPath = Server.MapPath(strFileLocationToSave);
            strPhysicalPath += fuProfilePicture.FileName;
            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuProfilePicture.SaveAs(strPhysicalPath);
            strFileLocationToSave += fuProfilePicture.FileName;

            Decimal Size = Math.Round(((decimal)fuProfilePicture.PostedFile.ContentLength / (decimal)1024), 2);
            string strExt = Path.GetExtension(strFileLocationToSave);

            strAttributes = "File Size : " + Size + "KB" + " File Type : " + strExt;

        }

        #endregion File Upload

        #region Add Parameters
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.Parameters.AddWithValue("@UserID", strUserID);
        objCmd.Parameters.AddWithValue("@CountryID", intCountryID);
        objCmd.Parameters.AddWithValue("@StateID", intStateID);
        objCmd.Parameters.AddWithValue("@CityID", intCityID);
        objCmd.Parameters.AddWithValue("@ContactName", strContactName);
        objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
        objCmd.Parameters.AddWithValue("@BirthDate", dateBirthDate);
        objCmd.Parameters.AddWithValue("@Email", strEmail);
        objCmd.Parameters.AddWithValue("@Age", intAge);
        objCmd.Parameters.AddWithValue("@Address", strAddress);
        objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);

        //objCmd.Parameters["@ContactID"].Direction = ParameterDirection.Output;
        #endregion Add Parameters

        #region Try | Catch | Finally
        try
        {

            if (Page.RouteData.Values["OprationName"].ToString().Trim() == "Add")
            {
                #region Insert Data

                #region Insert Details
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.Parameters.AddWithValue("@ProfilePicture", strFileLocationToSave);
                objCmd.Parameters.AddWithValue("@ProfilePictureDetails", strAttributes);
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.ExecuteNonQuery();
                #endregion Insert Details

                #region Insert chk ContactCategory
                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_Insert";
                        objCmdContactCategory.Parameters.AddWithValue("@UserID", strUserID);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                }
                #endregion Insert chk ContactCategory

                #region Close Connection
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                lblMessage.Text = "Data inserted Sucessfully";
                ClearContent();
                #endregion Close Connection

                #endregion Insert Data
            }
            else
            {
                #region Update Data

                #region Update Details
                objCmd.CommandText = "PR_Contact_UpdateByUserIDContactID";
                objCmd.Parameters.AddWithValue("@ContactID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                #endregion Update Details

                #region Update ContactCategory
                SqlCommand objCmdContactCategoryDelete = objConn.CreateCommand();
                objCmdContactCategoryDelete.CommandType = CommandType.StoredProcedure;
                objCmdContactCategoryDelete.CommandText = "PR_ContactWiseContactCategory_DeleteByContactIDUserID";
                objCmdContactCategoryDelete.Parameters.AddWithValue("@ContactID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                objCmdContactCategoryDelete.Parameters.AddWithValue("@UserID", strUserID);
                objCmdContactCategoryDelete.ExecuteNonQuery();

                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_Insert";
                        objCmdContactCategory.Parameters.AddWithValue("@UserID", strUserID);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                }
                #endregion Update ContactCategory

                #region Close Connection
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("/AdminPanel/Contact/List");
                #endregion Close Connection

                #endregion Update Data
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion Try | Catch | Finally
    }
    #endregion Btn Save

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/Contact/List");
    }
    #endregion Button | Cancel

    #region Country Index Change
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommanDropDownFill.FillDDLState(ddlStateID, Session["UserID"].ToString().Trim(), ddlCountryID.SelectedValue);
        ddlCityID.ClearSelection();
    }
    #endregion Country Index Change

    #region State Index Change
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommanDropDownFill.FillDDLCity(ddlCityID, Session["UserID"].ToString().Trim(), ddlStateID.SelectedValue);
    }
    #endregion State Index Change

    #region Fill cbl ContactCategory

    private void FillCBLContactCategoryID()
    {
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                cblContactCategoryID.DataSource = objSDR;
                cblContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactCategoryID.DataBind();
            }

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();

        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion Try | Catch | Finally
    }

    #endregion Fill cbl ContactCategory

    #region Clear Controls
    private void ClearContent()
    {
        txtContectName.Text = "";
        txtContactNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        txtBloodGroup.Text = "";
    }
    #endregion Clear Controls

    #region Fill All DropDownList
    private void FillDropDownList()
    {
        CommanDropDownFill.FillDDLCountry(ddlCountryID, Session["UserID"].ToString().Trim());
        CommanDropDownFill.FillDDLState(ddlStateID, Session["UserID"].ToString().Trim(), ddlCountryID.SelectedValue);
        CommanDropDownFill.FillDDLCity(ddlCityID, Session["UserID"].ToString().Trim(), ddlStateID.SelectedValue);
    }
    #endregion Fill All DropDownList
}
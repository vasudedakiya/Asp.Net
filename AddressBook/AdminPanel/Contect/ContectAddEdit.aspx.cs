using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class AdminPanel_Contect_ContectAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Request.QueryString["ContactID"] != null)
            {
                FillControls(Request.QueryString["ContactID"]);
                FillDDLCountry();
                FillDDLState();
                FillDDLCity();
                FillDDContactCategory();
            }
            else
            {
                FillDDContactCategory();
                FillDDLCountry();
            }

        }

    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(string Id)
    {
        #region Varible | Conn string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPK";
            if (Id.ToString().Trim() != "")
                objCmd.Parameters.AddWithValue("@ContactID", Id.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }

                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString();
                    }

                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString();
                    }

                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContectName.Text = objSDR["ContactName"].ToString();
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

                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }

                    if (!objSDR["FaceBookID"].Equals(DBNull.Value))
                    {
                        txtFaceBookID.Text = objSDR["FaceBookID"].ToString();
                    }

                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                    {
                        txtLinkdInID.Text = objSDR["LinkedINID"].ToString();
                    }
                    if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString();
                    }
                }
            }
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
        if (Request.QueryString["ContactID"] == null)
        {
            #region Insert Data
            insertData();
            ClearControls();
            lblMessage.Text = "Data inserted Sucessfully";
            #endregion Insert Data
        }
        else
        {
            #region Update Data
            updateData();
            ClearControls();
            #endregion Update Data
        }

    }
    #endregion Btn Save

    #region Update Data
    private void updateData()
    {
        #region Varible | Conn string
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlInt32 intCountryID = SqlInt32.Null;
        SqlInt32 intStateID = SqlInt32.Null;
        SqlInt32 intCityID = SqlInt32.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
        SqlString strLinkdInID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Server Side Validation
        if (txtContectName.Text.Trim() == "")
            strErrorMsg += "Enter ContactName <br/>";
        if (txtContactNo.Text.Trim() == "")
            strErrorMsg += "Enter Contact No <br/>";
        if (txtEmail.Text.Trim() == "")
            strErrorMsg += "Enter Email <br/>";
        if (txtAddress.Text.Trim() == "")
            strErrorMsg += "Enter Address <br/>";
        if (ddlStateID.SelectedValue == "-1")
            strErrorMsg += "Select State <br/>";
        if (ddlContactCategory.SelectedValue == "-1")
            strErrorMsg += "Select Contact Category <br/>";
        if (ddlCountryID.SelectedValue == "-1")
            strErrorMsg += "Select Country <br/>";
        if (ddlCityID.SelectedValue == "-1")
            strErrorMsg += "Select City <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (txtContectName.Text.Trim() == "")
            strContactName = txtContectName.Text.Trim();
        if (txtContactNo.Text.Trim() == "")
            strContactNo = txtContactNo.Text.Trim();
        if (txtEmail.Text.Trim() == "")
            strEmail = txtEmail.Text.Trim();
        if (txtAddress.Text.Trim() == "")
            strAddress = txtAddress.Text.Trim();
        if (ddlStateID.SelectedValue == "-1")
            intStateID = Int32.Parse(ddlStateID.SelectedValue);
        if (ddlContactCategory.SelectedValue == "-1")
            strContactCategoryID = Int32.Parse(ddlContactCategory.SelectedValue);
        if (ddlCountryID.SelectedValue == "-1")
            intCountryID = Int32.Parse(ddlCountryID.SelectedValue);
        if (ddlCityID.SelectedValue == "-1")
            intCityID = Int32.Parse(ddlCityID.SelectedValue);

        strWhatsAppNo = txtWhatsAppNo.Text.Trim();
        strBirthDate = DateTime.Parse(txtBirthDate.Text.Trim());
        strAge = Int32.Parse(txtAge.Text.Trim());
        strBloodGroup = txtBloodGroup.Text.Trim();
        strFaceBookID = txtFaceBookID.Text.Trim();
        strLinkdInID = txtLinkdInID.Text.Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_UpdateByPK";
            objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"]);
            objCmd.Parameters.AddWithValue("@CountryID", intCountryID);
            objCmd.Parameters.AddWithValue("@StateID", intStateID);
            objCmd.Parameters.AddWithValue("@CityID", intCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FaceBookID", strFaceBookID);
            objCmd.Parameters.AddWithValue("@LinkdInID", strLinkdInID);
            #endregion SQL Command

            #region Execute | Close
            objCmd.ExecuteNonQuery();
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            Response.Redirect("~/AdminPanel/Contect/ContectList.aspx");
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
    #endregion Update Data

    #region Insert Data
    private void insertData()
    {
        #region Varible | Conn string
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlInt32 intCountryID = SqlInt32.Null;
        SqlInt32 intStateID = SqlInt32.Null;
        SqlInt32 intCityID = SqlInt32.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
        SqlString strLinkdInID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Server Side Validation
        if (txtContectName.Text.Trim() == "")
            strErrorMsg += "Enter ContactName <br/>";
        if (txtContactNo.Text.Trim() == "")
            strErrorMsg += "Enter Contact No <br/>";
        if (txtEmail.Text.Trim() == "")
            strErrorMsg += "Enter Email <br/>";
        if (txtAddress.Text.Trim() == "")
            strErrorMsg += "Enter Address <br/>";
        if (ddlStateID.SelectedValue == "-1")
            strErrorMsg += "Select State <br/>";
        if (ddlContactCategory.SelectedValue == "-1")
            strErrorMsg += "Select Contact Category <br/>";
        if (ddlCountryID.SelectedValue == "-1")
            strErrorMsg += "Select Country <br/>";
        if (ddlCityID.SelectedValue == "-1")
            strErrorMsg += "Select City <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (txtContectName.Text.Trim() == "")
            strContactName = txtContectName.Text.Trim();
        if (txtContactNo.Text.Trim() == "")
            strContactNo = txtContactNo.Text.Trim();
        if (txtEmail.Text.Trim() == "")
            strEmail = txtEmail.Text.Trim();
        if (txtAddress.Text.Trim() == "")
            strAddress = txtAddress.Text.Trim();
        if (ddlStateID.SelectedValue == "-1")
            intStateID = Int32.Parse(ddlStateID.SelectedValue);
        if (ddlContactCategory.SelectedValue == "-1")
            strContactCategoryID = Int32.Parse(ddlContactCategory.SelectedValue);
        if (ddlCountryID.SelectedValue == "-1")
            intCountryID = Int32.Parse(ddlCountryID.SelectedValue);
        if (ddlCityID.SelectedValue == "-1")
            intCityID = Int32.Parse(ddlCityID.SelectedValue);
        strWhatsAppNo = txtWhatsAppNo.Text.Trim();
        strBirthDate = DateTime.Parse(txtBirthDate.Text.Trim());
        strAge = Int32.Parse(txtAge.Text.Trim());
        strBloodGroup = txtBloodGroup.Text.Trim();
        strFaceBookID = txtFaceBookID.Text.Trim();
        strLinkdInID = txtLinkdInID.Text.Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_Insert";
            objCmd.Parameters.AddWithValue("@CountryID", intCountryID);
            objCmd.Parameters.AddWithValue("@StateID", intStateID);
            objCmd.Parameters.AddWithValue("@CityID", intCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FaceBookID", strFaceBookID);
            objCmd.Parameters.AddWithValue("@LinkdInID", strLinkdInID);
            #endregion SQL Command

            #region Execute | Close
            objCmd.ExecuteNonQuery();
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
    #endregion Insert Data

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contect/ContectList.aspx");
    }
    #endregion Button | Cancel

    #region Country Index Change
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCityID.Items.Clear();
        ddlStateID.Items.Clear();
        FillDDLState();
    }
    #endregion Country Index Change

    #region State Index Change
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDLCity();
    }
    #endregion State Index Change

    #region Bind Country DDL
    private void FillDDLCountry()
    {
        #region Varible | Conn string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAll";
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
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
    #endregion Bind Country DDL

    #region Bind State DDL
    private void FillDDLState()
    {

        #region Varible | Conn string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_StateByCountry";
            objCmd.Parameters.AddWithValue("@CountyId", ddlCountryID.SelectedValue);
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
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
    #endregion Bind State DDL

    #region Bind City DDL
    private void FillDDLCity()
    {
        #region Varible | Conn string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_CityByState";
            objCmd.Parameters.AddWithValue("@StateId", ddlStateID.SelectedValue);
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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
    #endregion Bind City DDL

    #region Bind Category DDL
    private void FillDDContactCategory()
    {
        #region Varible | Conn string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn stringtry

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectAll";
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlContactCategory.DataSource = objSDR;
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataBind();
            }
            ddlContactCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
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
    #endregion Bind Category DDL

    #region Clear Content
    private void ClearControls()
    {
        txtContectName.Text = "";
        txtContactNo.Text = "";
        txtWhatsAppNo.Text = "";
        ddlContactCategory.SelectedValue = "-1";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtWhatsAppNo.Text = "";
        txtAddress.Text = "";
        ddlCountryID.SelectedValue = "-1";
        ddlStateID.SelectedValue = "-1";
        ddlCityID.SelectedValue = "-1";
        txtWhatsAppNo.Text = "";
        txtFaceBookID.Text = "";
        txtBloodGroup.Text = "";
        txtLinkdInID.Text = "";
    }
    #endregion Clear Content
}
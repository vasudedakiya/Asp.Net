using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContectCategory_ContectCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("/AdminPanel/UserLogin", true);
        }
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["OprationName"].ToString().Trim() != "Add")
            {
                FillControls(EncodeDecode.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
            }
        }
    }
    #endregion Load Event

    #region Fill Controls
    private void FillControls(string ContactCategoryID)
    {
        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
        SqlString strContactCategoryName = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
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
            objCmd.CommandText = "PR_ContactCategory_SelectByUserIDContactCategoryID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtCatName.Text = objSDR["ContactCategoryName"].ToString();
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

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
        SqlString strContactCategoryName = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Variable | Conn string

        #region Server Side Validation
        if (txtCatName.Text.Trim() == "")
            strErrorMsg += "Enter Contact Category <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        if (txtCatName.Text.Trim() != "")
            strContactCategoryName = txtCatName.Text.Trim();
        #endregion Assigne Value

        #region Add Parameters
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.Parameters.AddWithValue("@UserID", strUserID);
        objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
        #endregion Add Parameters

        #region Try | Catch | Finally
        try
        {
            if (Page.RouteData.Values["OprationName"].ToString().Trim() == "Add")
            {
                #region Insert Data
                objCmd.CommandText = "PR_ContactCategory_Insert";
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                txtCatName.Text = "";
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                objCmd.CommandText = "PR_ContactCategory_UpdateByUserIDContactCategoryID";
                objCmd.Parameters.AddWithValue("@ContactCategoryID", EncodeDecode.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("/AdminPanel/ContactCategory/List");
                txtCatName.Text = "";
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
    #endregion Button | Save

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/ContactCategory/List");
    }
    #endregion Button | Cancel
}
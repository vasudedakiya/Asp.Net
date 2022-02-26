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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
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
            CommanDropDownFill.FillDDLCountry(ddlCountry, Session["UserID"].ToString().Trim());
            if (Page.RouteData.Values["OprationName"].ToString().Trim() != "Add")
            {
                FillControls(EncodeDecode.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(string StateID)
    {
        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
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
            objCmd.CommandText = "PR_State_SelectByUserIDStateID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString();
                    }
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
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
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlString strCountryID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Variable | Conn string

        #region Server Side Validation
        if (txtStateCode.Text.Trim() == "")
            strErrorMsg += "Enter Code <br/>";
        if (txtStateName.Text.Trim() == "")
            strErrorMsg += "Enter State <br/>";
        if (ddlCountry.SelectedIndex == 0)
            strErrorMsg += "Select Country <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }

        #endregion Server Side Validation

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        if (txtStateName.Text.Trim() != "")
            strStateName = txtStateName.Text.Trim();
        if (txtStateCode.Text.Trim() != "")
            strStateCode = txtStateCode.Text.Trim();
        if (ddlCountry.SelectedIndex != 0)
            strCountryID = ddlCountry.SelectedValue;
        #endregion Assigne Value

        #region Add Parameters
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.Parameters.AddWithValue("@UserID", strUserID);
        objCmd.Parameters.AddWithValue("@StateName", strStateName);
        objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
        objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
        #endregion Add Parameters

        #region Try | Catch | Finally
        try
        {
            if (Page.RouteData.Values["OprationName"].ToString().Trim() == "Add")
            {
                #region Insert Data
                objCmd.CommandText = "PR_State_Insert";
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                ClearControl();
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                objCmd.CommandText = "PR_State_UpdateByUserIDStateID";
                objCmd.Parameters.AddWithValue("@StateID", EncodeDecode.Base64Decode(Page.RouteData.Values["StateID"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
                //ClearControl();
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
        Response.Redirect("/AdminPanel/State/List");
    }
    #endregion Button | Cancel

    #region Clear Control
    private void ClearControl()
    {
        txtStateCode.Text = "";
        txtStateName.Text = "";
        ddlCountry.SelectedIndex = 0;
    }
    #endregion Clear Control
}
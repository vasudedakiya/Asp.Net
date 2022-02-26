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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
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
            if (Page.RouteData.Values["OprationName"].ToString().Trim() != "Add")
            {
                FillControls(EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(string CountryID)
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
            objCmd.CommandText = "PR_Country_SelectByUserIDCountryID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString();
                    }
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString();
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
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Variable | Conn string

        #region Server Side Validation
        if (txtCountryCode.Text.Trim() == "")
            strErrorMsg += "Enter Country Code <br/>";
        if (txtCountryName.Text.Trim() == "")
            strErrorMsg += "Enter Country Name <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        if (txtCountryCode.Text.Trim() != "")
            strCountryCode = txtCountryCode.Text.Trim();
        if (txtCountryName.Text.Trim() != "")
            strCountryName = txtCountryName.Text.Trim();
        #endregion Assigne Value

        #region Add Parameters
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.Parameters.AddWithValue("@UserID", strUserID);
        objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
        objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
        #endregion Add Parameters

        #region Try | Catch | Finally
        try
        {
            #region Insert | Update Data
            if (Request.QueryString["CountryID"] == null)
            {
                #region Insert Data
                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                CLearControls();
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                objCmd.CommandText = "PR_Country_UpdateByUserIDCountryID";
                objCmd.Parameters.AddWithValue("@CountryID", EncodeDecode.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("/AdminPanel/Country/List");
                #endregion Update Data
            }
            #endregion Insert | Update Data
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
        Response.Redirect("/AdminPanel/Country/List");
    }
    #endregion Button | Cancel

    #region Clear Contrls
    private void CLearControls()
    {
        txtCountryCode.Text = "";
        txtCountryName.Text = "";
    }
    #endregion Clear Controls
}
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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
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
            FillDDLState();
            if (Page.RouteData.Values["OprationName"].ToString().Trim() != "Add")
            {
                FillContent(EncodeDecode.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim()));
            }
            
        }
    }
    #endregion Page Load

    #region Fill Content
    private void FillContent(string CityID)
    {
        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strStateID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        FillDDLState();
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
            objCmd.CommandText = "PR_City_SelectByUserIDCityID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPINCode.Text = objSDR["PinCode"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
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
    #endregion Fill Content

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Insert | Update Data

        #region Variable | Conn string
        SqlString strUserID = SqlString.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strStateID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Variable | Conn string

        #region Server Side Validation
        if (txtPINCode.Text.Trim() == "")
            strErrorMsg += "Enter PIN code <br/>";
        if (txtCityName.Text.Trim() == "")
            strErrorMsg += "Enter City Name <br/>";
        if (ddlState.SelectedValue == "-1")
            strErrorMsg += "Select State <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        if (txtPINCode.Text.Trim() != "")
            strPinCode = txtPINCode.Text.Trim();
        if (txtCityName.Text.Trim() != "")
            strCityName = txtCityName.Text.Trim();
        if (ddlState.SelectedIndex != 0)
            strStateID = ddlState.SelectedValue;
        #endregion Assigne Value

        #region Add Parameters
        if (objConn.State != ConnectionState.Open)
            objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.Parameters.AddWithValue("@UserID", strUserID);
        objCmd.Parameters.AddWithValue("@StateID", strStateID);
        objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
        objCmd.Parameters.AddWithValue("@CityName", strCityName);
        #endregion Add Parameters

        #region Try | Catch | Finally
        try
        {
            if (Page.RouteData.Values["OprationName"].ToString().Trim() == "Add")
            {
                #region Insert Data
                objCmd.CommandText = "PR_City_Insert";
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                lblMessage.Text = "Data inserted Sucessfully";
                CLearControls();
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                objCmd.CommandText = "PR_City_UpdateByUserIDCityID";
                objCmd.Parameters.AddWithValue("@CityID", EncodeDecode.Base64Decode(Page.RouteData.Values["CityID"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("/AdminPanel/City/List");
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

        #endregion Insert | Update Data
    }
    #endregion Button | Save

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/City/List");
    }
    #endregion Button | Cancel

    #region Fill ddl State
    private void FillDDLState()
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
            objCmd.CommandText = "PR_State_SelectByUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion SQL Command

            #region Data Bind & Close Conn
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }
            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion Data Bind & Close Conn

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
    #endregion Fill ddl State

    #region Clear Controls
    private void CLearControls()
    {
        txtCityName.Text = "";
        txtPINCode.Text = "";
        ddlState.SelectedIndex = 0;
    }
    #endregion Clear Controls
}
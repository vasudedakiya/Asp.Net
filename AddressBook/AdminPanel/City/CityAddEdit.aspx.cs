using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Request.QueryString["CityID"]);
                //FillDDLCountry();
                FillDDLState();
            }
            else
            {
                FillDDLState();
            }
        }
    }
    #endregion Load Event

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
            objCmd.CommandText = "PR_City_SelectByPK";
            #endregion SQL Command

            #region Assigne Value
            if (Id.ToString().Trim() != "")
                objCmd.Parameters.AddWithValue("@CityID", Id.ToString().Trim());
            #endregion Assigne Value

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
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString();
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
    #endregion Fill Edit-Data

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["CountryID"] == null)
        {
            #region Insert Data
            insertData();
            ClearControls();

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
    #endregion Button | Save

    #region Insert Data
    private void insertData()
    {
        #region Varible | Conn string
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strStateID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string


        #region Server Side Validation
        if (txtCityName.Text.Trim() == "")
            strErrorMsg += "Enter City <br/>";
        if (ddlState.SelectedValue == "-1")
            strErrorMsg += "Select State <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (txtCityName.Text.Trim() != "")
            strCityName = txtCityName.Text.Trim();
        if (txtSTDCode.Text.Trim() != "")
            strSTDCode = txtSTDCode.Text.Trim();
        if (txtPINCode.Text.Trim() != "")
            strPinCode = txtPINCode.Text.Trim();
        if (ddlState.SelectedValue != "-1")
            strStateID = ddlState.SelectedValue;
        #endregion Assigne Value


        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_Insert";
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            #endregion SQL Command

            #region Execute | Close
            objCmd.ExecuteNonQuery();
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            lblMessage.Text += "Data inserted Sucessfully";
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
    #endregion InsertData

    #region Update Data
    private void updateData()
    {

        #region Varible | Conn string
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strStateID = SqlString.Null;
        SqlString strErrorMsg = "";
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Server Side Validation
        if (txtCityName.Text.Trim() == "")
            strErrorMsg += "Enter City <br/>";
        if (ddlState.SelectedValue == "-1")
            strErrorMsg += "Select State <br/>";
        if (strErrorMsg != "")
        {
            lblMessage.Text = "Please Enter This filds <br/>" + strErrorMsg.ToString();
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (txtCityName.Text.Trim() != "")
            strCityName = txtCityName.Text.Trim();
        if (txtSTDCode.Text.Trim() != "")
            strSTDCode = txtSTDCode.Text.Trim();
        if (txtPINCode.Text.Trim() != "")
            strPinCode = txtPINCode.Text.Trim();
        if (ddlState.SelectedValue != "-1")
            strStateID = ddlState.SelectedValue;
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_UpdateByPK";
            objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"]);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            #endregion SQL Command

            #region Execute | Close
            objCmd.ExecuteNonQuery();
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            Response.Redirect("~/AdminPanel/City/CityList.aspx");
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

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button | Cancel

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
            objCmd.CommandText = "PR_State_SelectAll";
            #endregion SQL Command

            #region Execute | Close
            SqlDataReader objSDR = objCmd.ExecuteReader();

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

    #region Clear Controls
    private void ClearControls()
    {
        txtCityName.Text = "";
        txtSTDCode.Text = "";
        txtPINCode.Text = "";
        ddlState.SelectedValue = "-1";
    }
    #endregion Clear Controls

    #region Comments
    //#region Country Index Change
    //protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillDDLState();
    //}
    //#endregion Country Index Change

    //#region Bind Country DDL
    //private void FillDDLCountry()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
    //    try
    //    {

    //        objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_Country_SelectAll";
    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlCountry.DataSource = objSDR;
    //            ddlCountry.DataValueField = "CountryID";
    //            ddlCountry.DataTextField = "CountryName";
    //            ddlCountry.DataBind();
    //        }
    //        ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        objConn.Close();
    //    }
    //}
    //#endregion Bind Country DDL
    #endregion Comments

}
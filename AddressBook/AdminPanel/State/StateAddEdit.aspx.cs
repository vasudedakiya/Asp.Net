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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLCountry();
            if (Request.QueryString["StateID"] != null)
            {
                FillEditData(Request.QueryString["StateID"]);
            }
        }
    }
    #endregion Load Event

    #region Fill Edit-Data
    private void FillEditData(string Id)
    {
        #region Varible | Conn string
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlInt32 intCountryID = SqlInt32.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByPK";
            objCmd.Parameters.AddWithValue("@StateID", Id.ToString().Trim());

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

            objConn.Close();
            #endregion Execute | Close

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
        #endregion Try | Catch | Finally
    }
    #endregion Fill Edit-Data

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtStateName.Text) && !string.IsNullOrEmpty(txtStateCode.Text))
        {
            if (Request.QueryString["StateID"] == null)
            {
                #region Insert Data
                insertData();
                txtStateCode.Text = "";
                txtStateName.Text = "";
                ddlCountry.SelectedValue = "-1";
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                updateData();
                txtStateCode.Text = "";
                txtStateName.Text = "";
                ddlCountry.SelectedValue = "-1";
                #endregion Update Data
            }
        }

        else
        {
            lblMessage.Text = "Enter proper data";
        }
    }
    #endregion Button | Save

    #region Insert Data
    private void insertData()
    {
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlString strCountryID = SqlString.Null;

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_Insert";

            strCountryID = ddlCountry.SelectedValue;
            strStateName = txtStateName.Text.Trim();
            strStateCode = txtStateCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);

            objCmd.ExecuteNonQuery();

            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            objConn.Close();
        }


    }
    #endregion InsertData

    #region Update Data
    private void updateData()
    {
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlString strCountryID = SqlString.Null;

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_UpdateByPK";

            strCountryID = ddlCountry.SelectedValue;
            strStateName = txtStateName.Text.Trim();
            strStateCode = txtStateCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"]);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);

            objCmd.ExecuteNonQuery();

            objConn.Close();
            Response.Redirect("~/AdminPanel/State/StateList.aspx");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            objConn.Close();
        }
    }
    #endregion Update Data

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Button | Cancel

    #region Bind Country DDL
    private void FillDDLCountry()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {

            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAll";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion Bind Country DDL

}
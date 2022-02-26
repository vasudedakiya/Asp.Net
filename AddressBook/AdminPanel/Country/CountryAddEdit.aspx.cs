using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Configuration;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillEditData(Request.QueryString["CountryID"]);
            }
        }
    }
    #endregion Load Event

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Insert | Update Data
        if (!string.IsNullOrEmpty(txtCountryName.Text) && !string.IsNullOrEmpty(txtCountryCode.Text))
        {
            if (Request.QueryString["CountryID"] == null)
            {
                #region Insert Data
                insertData();
                txtCountryCode.Text = "";
                txtCountryName.Text = "";
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                updateData();
                
            }
        }
        else
        {
            lblMessage.Text = "Enter proper data";
        }
        #endregion Insert | Update Data
    }
    #endregion Button | Save

    #region Fill Edit-Data
    private void FillEditData(string Id)
    {
        #region Varible | Conn string
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryId", Id.ToString().Trim());
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

    #region Insert Data
    private void insertData()
    {
        #region Varible | Conn string
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Varible | Conn string

        #region Try | Catch | Finally
        try
        {
            #region SQL Command
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_Insert";
            strCountryName = txtCountryName.Text.Trim();
            strCountryCode = txtCountryCode.Text.Trim();
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            #endregion SQL Command


            #region Execute | Close
            objCmd.ExecuteNonQuery();

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
    #endregion InsertData

    #region Update Data
    private void updateData()
    {
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_UpdateByPK";


            strCountryName = txtCountryName.Text.Trim();
            strCountryCode = txtCountryCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@CountyID", Request.QueryString["CountryID"]);
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            objCmd.ExecuteNonQuery();
            objConn.Close();
            Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
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
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button | Cancel
}


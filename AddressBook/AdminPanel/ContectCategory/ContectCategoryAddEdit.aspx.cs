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
        if (!IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillEditData(Request.QueryString["ContactCategoryID"]);
            }
        }
    }
    #endregion Load Event

    #region Fill Edit-Data
    private void FillEditData(string Id)
    {
        SqlString strContactCategoryName = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region SQL Command
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", Id.ToString().Trim());
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
    }
    #endregion Fill Edit-Data

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCatName.Text))
        {
            if (Request.QueryString["ContactCategoryID"] == null)
            {
                #region Insert Data
                insertData();
                txtCatName.Text = "";
                lblMessage.Text = "Data inserted Sucessfully";
                #endregion Insert Data
            }
            else
            {
                #region Update Data
                updateData();
                txtCatName.Text = "";
                #endregion Update Data
            }
        }
        else
        {
            lblMessage.Text = "Enter proper data";
        }
    }
    #endregion Button | Save

    #region Update Data
    private void updateData()
    {
        SqlString strContactCategoryName = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_UpdateByPK";

            strContactCategoryName = txtCatName.Text.Trim();

            objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"]);
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);

            objCmd.ExecuteNonQuery();

            objConn.Close();
            Response.Redirect("~/AdminPanel/ContectCategory/ContectCategoryList.aspx");
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

    #region Insert Data
    private void insertData()
    {
        SqlString strContactCategoryName = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_Insert";

            strContactCategoryName = txtCatName.Text.Trim();

            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);

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

    #region Button | Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button | Cancel
}
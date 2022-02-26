using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class AdminPanel_Contect_ContectList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillData();
        }
    }
    #endregion Page Load

    #region Fill Data
    private void FillData()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand sqlCmd = objConn.CreateCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "PR_Contact_SelectAll";

            SqlDataReader objSDR = sqlCmd.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();

            objConn.Close();
        }
        catch (Exception ex)
        {
            lblDisplay.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion Fill Data

    #region Row Command
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByPK";

            objCmd.Parameters.AddWithValue("@ContactID", e.CommandArgument.ToString().Trim());
            objCmd.ExecuteNonQuery();
            objConn.Close();
            FillData();
        }

        catch (Exception ex)
        {
            lblDisplay.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion Row Command
}
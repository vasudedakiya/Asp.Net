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

public partial class AdminPanel_ContectCategory_ContactCategory : System.Web.UI.Page
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
            FillGridView();
        }
    }
    #endregion Page Load

    #region Row Command
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            #region Local Variabel
            SqlString strUserID = SqlString.Null;
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
            #endregion Local Variabel

            #region Assigne Value
            if (Session["UserID"] != "")
                strUserID = Session["UserID"].ToString().Trim();
            #endregion Assigne Value

            #region Try Catch
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_DeleteByUserIDContactCategoryID";

                objCmd.Parameters.AddWithValue("@UserID", strUserID);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", e.CommandArgument.ToString().Trim());

                objCmd.ExecuteNonQuery();

                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                FillGridView();
            }
            catch (Exception ex)
            {
                lblDisplay.Text = ex.Message;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
            #endregion Try Catch

        }
    }
    #endregion Row Command

    #region Fill Grid View
    private void FillGridView()
    {
        #region Local Varibel
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Varibel

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        #endregion Assigne Value

        #region Try Catch
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }

        catch (Exception ex)
        {
            lblDisplay.Text = ex.Message;
        }

        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion Try Catch
    }
    #endregion Fill Grid View
}
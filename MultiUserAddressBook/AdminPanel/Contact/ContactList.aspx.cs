using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            #region Local Variabel
            SqlString strUserID = SqlString.Null;
            String ImgPath = "";
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
            #endregion Local Variabel

            #region Assigne Value
            if (Session["UserID"] != "")
                strUserID = Session["UserID"].ToString().Trim();
            #endregion Assigne Value

            #region Try | Catch | Finally
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                #region Delete ContactCategory
                SqlCommand objCmdContactCategory = objConn.CreateCommand();
                objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_DeleteByContactIDUserID";
                objCmdContactCategory.Parameters.AddWithValue("@ContactID", e.CommandArgument.ToString().Trim());
                objCmdContactCategory.Parameters.AddWithValue("@UserID", strUserID);
                objCmdContactCategory.ExecuteNonQuery();
                #endregion Delete ContactCategory

                #region Delete Photo from folder
                SqlCommand objCmdProfilePicture = objConn.CreateCommand();
                objCmdProfilePicture.CommandType = CommandType.StoredProcedure;
                objCmdProfilePicture.CommandText = "PR_Contact_SelectImgPathByContactID";
                objCmdProfilePicture.Parameters.AddWithValue("@ContactID", e.CommandArgument.ToString().Trim());
                objCmdProfilePicture.Parameters.AddWithValue("@UserID", strUserID);
                SqlDataReader objSDRProfilePicture = objCmdProfilePicture.ExecuteReader();
                if (objSDRProfilePicture.HasRows)
                {
                    while (objSDRProfilePicture.Read())
                    {
                        if (objSDRProfilePicture["ProfilePicture"] != "")
                            ImgPath = objSDRProfilePicture["ProfilePicture"].ToString().Trim();
                    }
                }

                String strPhysicalPath = Server.MapPath(ImgPath);
                if (File.Exists(strPhysicalPath))
                    File.Delete(strPhysicalPath);
                objSDRProfilePicture.Close();
                #endregion Delete Photo from folder

                #region Delete Contact
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_DeleteByUserIDContactID";
                objCmd.Parameters.AddWithValue("@UserID", strUserID);
                objCmd.Parameters.AddWithValue("@ContactID", e.CommandArgument.ToString().Trim());
                objCmd.ExecuteNonQuery();
                #endregion Delete Contact

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
            #endregion Try | Catch | Finally

        }
    }
    #endregion Row Command

    #region Fill Grid View
    private void FillGridView()
    {
        #region Local Variabel
        SqlString strUserID = SqlString.Null;
        SqlString strContactID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variabel

        #region Assigne Value
        if (Session["UserID"] != "")
            strUserID = Session["UserID"].ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContact.DataSource = objSDR;
            gvContact.DataBind();
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
        #endregion Try | Catch | Finally
    }
    #endregion Fill Grid View
}
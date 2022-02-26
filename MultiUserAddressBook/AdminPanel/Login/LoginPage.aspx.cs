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

public partial class AdminPanel_Login_LoginPage : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load

    #region Btn Save
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CheckLogin();
    }
    #endregion Btn Save

    #region Check UserID Password
    private void CheckLogin()
    {
        #region Local Variabel
        SqlString strUserID = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variabel

        #region Server Side Validation
        string strErrorMsg = "";
        if (txtLoginUsername.ToString().Trim() == "")
            strErrorMsg += "Enter UserID <br/>";
        if (txtLoginPassword.ToString().Trim() == "")
            strErrorMsg += "Enter Password <br/>";
        if (strErrorMsg != "")
        {
            lblMessaage.Text = strErrorMsg;
            return;
        }
        #endregion Server Side Validation

        #region Assigne Value
        if (txtLoginUsername.Text.Trim() != "")
            strUserID = txtLoginUsername.Text.Trim();
        if (txtLoginPassword.Text.Trim() != "")
            strPassword = txtLoginPassword.Text.Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserIDPassword";
            objCmd.Parameters.AddWithValue("@UserName", strUserID);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    if (!objSDR["UserImg"].Equals(DBNull.Value))
                    {
                        Session["UserImg"] = objSDR["UserImg"].ToString().Trim();
                    }
                    break;
                }
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                Response.Redirect("/AdminPanel/Home", true);
            }
            else
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                lblMessaage.Text = "Invalid User Please Register first";
            }
        }
        catch (Exception ex)
        {
            lblMessaage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }

        #endregion Try | Catch | Finally

    }
    #endregion Check UserID Password

    #region btn Register
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AdminPanel/UserRegister");
    }

    #endregion btn Register
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommanDropDownFill
/// </summary>
public static class CommanDropDownFill
{
    #region Fill DDL Country
    public static void FillDDLCountry(DropDownList ddlCountry, string UserID)
    {
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #region Assigne Value
        if (UserID.ToString().Trim() != "")
            strUserID = UserID.ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion  Try | Catch | Finally
    }
    #endregion Fill DDL Country

    #region Fill DDL State
    public static void FillDDLState(DropDownList ddlState, string UserID,string CountryID)
    {
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #region Assigne Value
        if (UserID.ToString().Trim() != "")
            strUserID = UserID.ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectDropDownByCountryIDUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@CountyId", CountryID);
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
        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion  Try | Catch | Finally
    }
    #endregion Fill DDL State

    #region Fill DDL State
    public static void FillDDLCity(DropDownList ddlCity, string UserID,string StateID)
    {
        SqlString strUserID = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #region Assigne Value
        if (UserID.ToString().Trim() != "")
            strUserID = UserID.ToString().Trim();
        #endregion Assigne Value

        #region Try | Catch | Finally
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectDropDownByStateIDUserID";
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@StateId", StateID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion  Try | Catch | Finally
    }
    #endregion Fill DDL State
}
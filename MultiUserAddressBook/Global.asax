<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRouting(System.Web.Routing.RouteTable.Routes);

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public static void RegisterRouting(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.add/{*pathInfo}");

       // Country
        routes.MapPageRoute("MultiAddressBookCountryList",
            "AdminPanel/Country/List",
            "~/AdminPanel/Country/CountryList.aspx");

        routes.MapPageRoute("MultiAddressBookCountryAdd",
            "AdminPanel/Country/{OprationName}",
            "~/AdminPanel/Country/CountryAddEdit.aspx");

        routes.MapPageRoute("MultiAddressBookCountryEdit",
            "AdminPanel/Country/{OprationName}/{CountryID}",
            "~/AdminPanel/Country/CountryAddEdit.aspx");

        //State
        routes.MapPageRoute("MultiAddressBookStateList",
            "AdminPanel/State/List",
            "~/AdminPanel/State/StateList.aspx");

        routes.MapPageRoute("MultiAddressBookStateAdd",
           "AdminPanel/State/{OprationName}",
           "~/AdminPanel/State/StateAddEdit.aspx");

        routes.MapPageRoute("MultiAddressBookStateEdit",
            "AdminPanel/State/{OprationName}/{StateID}",
            "~/AdminPanel/State/StateAddEdit.aspx");
        
        //City
        routes.MapPageRoute("MultiAddressBookCityList",
            "AdminPanel/City/List",
            "~/AdminPanel/City/CityList.aspx");

        routes.MapPageRoute("MultiAddressBookCityAdd",
           "AdminPanel/City/{OprationName}",
           "~/AdminPanel/City/CityAddEdit.aspx");

        routes.MapPageRoute("MultiAddressBookCityEdit",
            "AdminPanel/City/{OprationName}/{CityID}",
            "~/AdminPanel/City/CityAddEdit.aspx");

        //Contact
        routes.MapPageRoute("MultiAddressBookContactList",
            "AdminPanel/Contact/List",
            "~/AdminPanel/Contact/ContactList.aspx");

        routes.MapPageRoute("MultiAddressBookContactAdd",
           "AdminPanel/Contact/{OprationName}",
           "~/AdminPanel/Contact/ContactAddEdit.aspx");

        routes.MapPageRoute("MultiAddressBookContactEdit",
            "AdminPanel/Contact/{OprationName}/{ContactID}",
            "~/AdminPanel/Contact/ContactAddEdit.aspx");
        
        //Contact Category
        routes.MapPageRoute("MultiAddressBookContectCategoryList",
            "AdminPanel/ContactCategory/List",
            "~/AdminPanel/ContactCategory/ContactCategoryList.aspx");

        routes.MapPageRoute("MultiAddressBookContectCategoryAdd",
           "AdminPanel/ContactCategory/{OprationName}",
           "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        routes.MapPageRoute("MultiAddressBookContectCategoryEdit",
            "AdminPanel/ContactCategory/{OprationName}/{ContactCategoryID}",
            "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");

        //Login
        routes.MapPageRoute("MultiAddressBookLogin",
            "AdminPanel/UserLogin",
            "~/AdminPanel/Login/LoginPage.aspx");

        routes.MapPageRoute("MultiAddressBookRegister",
           "AdminPanel/UserRegister",
           "~/AdminPanel/Login/RegisterPage.aspx");

        routes.MapPageRoute("MultiAddressBookHome",
            "AdminPanel/Home",
            "~/AdminPanel/Login/Home.aspx");

        
    }
       
</script>

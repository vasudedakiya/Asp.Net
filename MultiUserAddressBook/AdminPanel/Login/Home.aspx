<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="AdminPanel_Login_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <div class="h3">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-6">
                UserName : 
            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>

        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-6">
                DisplayName : 
            <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>

        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-6">
                Mobile No :
            <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                Email :
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-4"></div>

        </div>

        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </div>
    

</asp:Content>


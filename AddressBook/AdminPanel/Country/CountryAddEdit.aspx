<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">


    <div class="row">
        <div class="col-md-12">
            <h2 style="font-family: Verdana; text-align: center; color: dodgerblue">Country Add/Edit Page</h2>
            <hr style="color: lightblue; border: double" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Country's Name: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>
    <div class="row">
        <div class="col-md-1"></div>7
        <div class="col-md-3">
            <h3 style="font-family: Verdana; text-align: justify; color: cornflowerblue">Country's Code: </h3>
        </div>
        <div class="col-md-6">
            <br />
            <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-md-2"></div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-md" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-md" OnClick="btnCancel_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 text-center">
            <strong>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text="" EnableViewState="False"></asp:Label>
            </strong>
        </div>
    </div>




</asp:Content>


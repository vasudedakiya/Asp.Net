<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    
    <div class="row">
        <div class="col-md-4">
            <asp:HyperLink ID="hlAdd" CssClass="btn btn-dark" runat="server"  NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" >Add Country</asp:HyperLink>
        </div>
        <div class="col-md-8 text-left">
            <h2>Country List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand" >

                <Columns>
                    

                    <asp:BoundField runat="server" DataField="CountryID" HeaderText="ID" />
                    <asp:BoundField runat="server" DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField runat="server" DataField="CountryCode" HeaderText="Country Code" />

                    <asp:TemplateField runat="server">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger"
                                 CommandName="DeleteRow" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-outline-primary" 
                                runat="server"  NavigateUrl= '<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString()  %>' >Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
    <div class="text-center">
            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        </div>

</asp:Content>
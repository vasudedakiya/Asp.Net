<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContectList.aspx.cs" Inherits="AdminPanel_Contect_ContectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
         <div class="col-md-4">
            <asp:HyperLink ID="hlAdd" CssClass="btn btn-dark" runat="server"  NavigateUrl="~/AdminPanel/Contect/ContectAddEdit.aspx" >Add Country</asp:HyperLink>
        </div>
        <div class="col-md-8 text-left">
            <h2>Contect List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                   
                    <asp:BoundField DataField="ContactID" HeaderText="ID" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contect No" />
                    <%--<asp:BoundField DataField="Address" HeaderText="Add." />--%>
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="BirthDate" HeaderText="DOB" />
                    <asp:BoundField DataField="FacebookID" HeaderText="FB-ID" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />

                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-outline-danger" Text="Delete" CommandName="DeleteByID" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-outline-primary" 
                                runat="server"  NavigateUrl= '<%# "~/AdminPanel/Contect/ContectAddEdit.aspx?ContactID=" + Eval("ContactID").ToString()  %>' >Edit</asp:HyperLink>
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


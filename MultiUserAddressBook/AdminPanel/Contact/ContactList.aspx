<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-4">
            <asp:HyperLink ID="hlAdd" CssClass="btn btn-dark" runat="server" NavigateUrl="/AdminPanel/Contact/Add">Add Contact</asp:HyperLink>
        </div>
        <div class="col-md-8 text-left">
            <h2>Contact List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>

                    <asp:BoundField DataField="ContactID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Profile Picture">
                        <ItemTemplate>
                            <asp:Image ToolTip='<%# Eval("PictureDetails") %>' runat="server" Height="100" CssClass="rounded-circle" ImageUrl='<%# Eval("ProfilePicture") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                    <%--<asp:BoundField DataField="Address" HeaderText="Add." />--%>
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="BirthDate" HeaderText="DOB" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-outline-danger" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-outline-primary"
                                runat="server" NavigateUrl='<%# "/AdminPanel/Contact/Edit/" + EncodeDecode.Base64Encode(Eval("ContactID").ToString())  %>'>Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover"></asp:GridView>
    </div>

    <div class="text-center">
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-4">
            <asp:HyperLink ID="hlAdd" CssClass="btn btn-dark" runat="server"  NavigateUrl="/AdminPanel/State/Add" >Add State</asp:HyperLink>
        </div>
        <div class="col-md-8 text-left">
            <h2>State List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                    <asp:BoundField runat="server" DataField="StateID" HeaderText="ID" />
                     <asp:BoundField runat="server" DataField="CountryName" HeaderText="Country" />
                   <%-- <asp:BoundField runat="server" DataField="CountryID" HeaderText="Country" />--%>
                    <asp:BoundField runat="server" DataField="StateName" HeaderText="State" />
                    <asp:BoundField runat="server" DataField="StateCode" HeaderText="State Code" />
                    <asp:TemplateField runat="server">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-outline-primary" 
                                runat="server"  NavigateUrl= '<%# "/AdminPanel/State/Edit/" + EncodeDecode.Base64Encode(Eval("StateID").ToString())  %>' >Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="text-center">
            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        </div>


    </div>
</asp:Content>


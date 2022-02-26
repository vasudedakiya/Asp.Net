﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <div class="row">
        <div class="col-md-4">
            <asp:HyperLink ID="hlAdd" CssClass="btn btn-dark" runat="server"  NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" >Add City</asp:HyperLink>
        </div>
        <div class="col-md-8 text-left">
            <h2>City List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            
            <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvCountry_RowCommand">

                <Columns>
                    <asp:BoundField DataField="CityID" HeaderText="ID" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                     <asp:BoundField DataField="CityName" HeaderText="Name" />
                     <asp:BoundField DataField="STDCode" HeaderText="STD code" />
                     <asp:BoundField DataField="PinCode" HeaderText="Pin code" />

                    <asp:TemplateField runat="server" HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteItem" CommandArgument='<%# Eval("CityID").ToString() %>' />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-outline-primary" 
                                runat="server"  NavigateUrl= '<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString()  %>' >Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>
        </div>
        
    </div>
    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
</asp:Content>


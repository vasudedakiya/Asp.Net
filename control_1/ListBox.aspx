<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListBox.aspx.cs" Inherits="control_1_ListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        ul {
            list-style-type: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>New Value</h2>
        Country Name :
        <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
        <p>
            Country Code :
            <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
        </p>

        <h2>Old Value</h2>
        Country Name :
        <asp:TextBox ID="txtOldItem" runat="server"></asp:TextBox>
        <p>
            Country Code :
            <asp:TextBox ID="txtOldValue" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click"  />

        <hr />

        <div>

            <div style="float: left">
                <asp:ListBox ID="lbCountryLeft" runat="server"></asp:ListBox>
            </div>
            <div style="float: left; margin-top: -20px">
                <ul>
                    <li>
                        <asp:Button ID="btnSelectedLeft" runat="server" Text=">" OnClick="btnSelectedLeft_Click" /></li>
                    <li>
                        <asp:Button ID="btnAllLeft" runat="server" Text=">>" OnClick="btnAllLeft_Click" /></li>
                    <li>
                        <asp:Button ID="btnSelectedRight" runat="server" Text="<" OnClick="btnSelectedRight_Click" /></li>
                    <li>
                        <asp:Button ID="btnAllRight" runat="server" Text="<<" OnClick="btnAllRight_Click" /></li>
                </ul>
            </div>
            <div style="float: left; margin-left: 35px">
                <asp:ListBox ID="lbCountryRight" runat="server"></asp:ListBox>
            </div>


        </div>


        <p>
            &nbsp;
        </p>


        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" />
        <p>
            <asp:Label ID="lblDisplay" runat="server" EnableViewState="False"></asp:Label>
        </p>


    </form>
</body>
</html>












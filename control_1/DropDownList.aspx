<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList.aspx.cs" Inherits="control_1_DropDownList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Item:
        <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
        </div>
        Enter Value:
        <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
        </p>

        <hr />
        <asp:DropDownList ID="ddlCountry" runat="server">
            <asp:ListItem Value="991">INDIA</asp:ListItem>
        </asp:DropDownList>

        <p>

            <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" />
        </p>
        <p>
            <asp:Label ID="lblDisplay" runat="server" EnableViewState="False"></asp:Label>

        </p>

    </form>
</body>
</html>

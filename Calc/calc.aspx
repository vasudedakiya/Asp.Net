<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calc.aspx.cs" Inherits="calc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Number 1 :
        <asp:TextBox ID="txtNo1" runat="server"></asp:TextBox>
        Oprater :
        <asp:TextBox ID="txtOpratre" runat="server"></asp:TextBox>
        Number 2:
        <asp:TextBox ID="txtNo2" runat="server"></asp:TextBox>
       
        <p>
            <asp:Button ID="btnOutput" runat="server" Text="Calculate" OnClick="btnOutput_Click" />
        </p>
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
       
        
     
    </form>
</body>
</html>

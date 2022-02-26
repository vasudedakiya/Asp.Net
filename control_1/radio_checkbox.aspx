<%@ Page Language="C#" AutoEventWireup="true" CodeFile="radio_checkbox.aspx.cs" Inherits="radio_checkbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br /><br /><br /><br /><br /><hr /><hr />
        
        Select Department : 
        <asp:RadioButton ID="rbDegree" runat="server" Text="Degree" GroupName="Dep"/>
        <asp:RadioButton ID="rbDiploma" runat="server" Text="Diploma" GroupName="Dep"/>
        <asp:Button ID="btnSelectDep" runat="server" Text="Select" OnClick="btnSelectDep_Click" />
        <br />
        <div ID="allDegreeLbl" runat="server">
        <asp:RadioButton ID="rbCE" runat="server" Text="Computer Engineering" GroupName="Degree"></asp:RadioButton><br />
        <asp:RadioButton ID="rbCI" runat="server" Text="Civil Engineering" GroupName="Degree"></asp:RadioButton><br />
        <asp:RadioButton ID="rbEE" runat="server" Text="Eletrical Engineering" GroupName="Degree"></asp:RadioButton><br />
        <asp:RadioButton ID="rbME" runat="server" Text="Mechinacal Engineering" GroupName="Degree"></asp:RadioButton><br />
        </div>

        <div id="allDiploLbl" runat="server">
        <asp:RadioButton ID="rbDiCE" runat="server" Text="Diploma computer Engineering" GroupName="Diploma"></asp:RadioButton><br />
        <asp:RadioButton ID="rbDiCI" runat="server" Text="Diploma Civil Engineering" GroupName="Diploma"></asp:RadioButton><br />
        <asp:RadioButton ID="rbDiEE" runat="server" Text="Diploma Eletrical Engineering" GroupName="Diploma"></asp:RadioButton><br />
        <asp:RadioButton ID="rbDiME" runat="server" Text="Diploma Mechinacal Engineering" GroupName="Diploma"></asp:RadioButton><br />
        </div>
        <asp:Button ID="btnDisplayRadio" runat="server" Text="Display" OnClick="btnDisplayRadio_Click" />
        <hr />
        <asp:Label ID="lblSelection" runat="server" Text=""></asp:Label>
        <hr />

        



        <br /><br /><br />
        <div ID="divBranchDegree" runat="server">
        Fav Branch In Degree:<br />
        <asp:CheckBox ID="chkAll" runat="server" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged"/>
        <asp:CheckBox ID="chkNone" runat="server" Text="None" AutoPostBack="True" OnCheckedChanged="chkNone_CheckedChanged" />
        <asp:CheckBox ID="chkAlternative" runat="server" Text="Select Alternative" AutoPostBack="True" OnCheckedChanged="chkAlternative_CheckedChanged" /><br />
        <asp:CheckBox ID="chkCE" runat="server" Text="Computer Engineering" /><br />
        <asp:CheckBox ID="chkEC" runat="server" Text="Eletric Engineering"/><br />
        <asp:CheckBox ID="chkCI" runat="server" Text="Civil Engineering"/><br />
        <asp:CheckBox ID="chkME" runat="server" Text="Mechinal Engineering"/><br />
        </div>

        <br /><br />

        <asp:Button ID="btnDisplayChk" runat="server" Text="Display" OnClick="btnDisplayChk_Click" />
        <br />
        <asp:Label ID="lblDisplayChk" runat="server" Text=""></asp:Label>
        <%--<div ID="divBranchDiploma" runat="server">
        Fav Branch Diploma:<br />
        <asp:CheckBox ID="chkDiAll" runat="server" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkDiAll_CheckedChanged"/>
        <asp:CheckBox ID="chkDiNone" runat="server" Text="None" AutoPostBack="True" OnCheckedChanged="chkDiNone_CheckedChanged"/>
        <asp:CheckBox ID="chkDiSlternative" runat="server" Text="Select Alternative" AutoPostBack="True" OnCheckedChanged="chkDiSlternative_CheckedChanged"/><br />
        <asp:CheckBox ID="chkDiCE" runat="server" Text="Computer Engineering"/><br />
        <asp:CheckBox ID="chkDiEC" runat="server" Text="Eletric Engineering"/><br />
        <asp:CheckBox ID="chkDiCI" runat="server" Text="Civil Engineering"/><br />
        <asp:CheckBox ID="chkDiME" runat="server" Text="Mechinal Engineering"/><br />
        </div>--%>

        <br /><br /><br /><br /><br /><br /><hr /><hr />
    </form>
</body>
</html>

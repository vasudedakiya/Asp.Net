<%@ Page Language="C#" AutoEventWireup="true" CodeFile="validation.aspx.cs" Inherits="control_1_validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Student Enrollment Form</h1>
            <br />
            <br />
            <div>
                <div>
                    <h2>Register Here</h2>
                    <table>
                        <tr>
                            <td>*Name* : </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">*Enrollment No : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtEnrollment" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style1" style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rfvEnroll" runat="server" Display="Dynamic" ErrorMessage="Enter Enrollment" ControlToValidate="txtEnrollment"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>*Institute : </td>
                            <td>
                                <asp:DropDownList ID="ddlInstitute" runat="server">
                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                    <asp:ListItem Value="DU">Darshan Uni</asp:ListItem>
                                    <asp:ListItem Value="GEC_R">GEC Rajkot</asp:ListItem>
                                    <asp:ListItem>VVP </asp:ListItem>
                                   
                                </asp:DropDownList>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rfvInstiute" runat="server" ControlToValidate="ddlInstitute" Display="Dynamic" ErrorMessage="Select Instiute" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">*Department : </td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                    <asp:ListItem Value="CE">Computer</asp:ListItem>
                                    <asp:ListItem Value="ME">Mechinal</asp:ListItem>
                                    <asp:ListItem Value="EE">Eletrical</asp:ListItem>
                                    <asp:ListItem Value="CI">Civil</asp:ListItem>
                                    
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style1" style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" Display="Dynamic" ErrorMessage="Select Department" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>Birth Date : </td>
                            <td>
                                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:CompareValidator ID="cvDOB" runat="server" ErrorMessage="Enter Date Correct" ControlToValidate="txtDOB" Display="Dynamic" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Semester : </td>
                            <td>
                                <asp:TextBox ID="txtSem" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RangeValidator ID="rvSem" runat="server" Display="Dynamic" ErrorMessage="Enter Correct Sem" MaximumValue="8" MinimumValue="1" Type="Integer" ControlToValidate="txtSem"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Email : </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>*Mobile No : </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rvfMobileNo" runat="server" Display="Dynamic" ErrorMessage="Enter Mobile No" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>*Password : </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="Enter Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPassword" runat="server" Display="Dynamic" ErrorMessage="Enter Strong Password" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ControlToValidate="txtPassword"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Retype Password : </td>
                            <td>
                                <asp:TextBox ID="txtRePassword" runat="server"></asp:TextBox>
                            </td>
                            <td style="color: #FF0000">
                                <asp:CompareValidator ID="cvRePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRePassword" Display="Dynamic" ErrorMessage="Password same as upper password"></asp:CompareValidator>
                                
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:CheckBox ID="chkTurms" runat="server" Text="Agree terms & condition" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                    <br />

                    <asp:Button ID="btnSubmit" runat="server" Text="Register" Width="460px" OnClick="btnSubmit_Click" />
                </div>
                <asp:Label ID="lblSave" runat="server" Text=""></asp:Label>
            </div>


            <br />

        </div>

    </form>
</body>
</html>

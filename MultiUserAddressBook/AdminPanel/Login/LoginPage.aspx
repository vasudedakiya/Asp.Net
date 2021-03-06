<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="AdminPanel_Login_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>

    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button:hover {
            opacity: 0.8;
        }

        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }

        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 50%;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }
        .red{
            color:red;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cnbtn {
                width: 100%;
            }
        }

        .frmalg {
            margin: auto;
            width: 40%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" class="frmalg">
        <div class="container">
            <center>
                <h3>Login Page</h3>
            </center>
            <label ><b>Username</b></label>
            <asp:TextBox runat="server" ID="txtLoginUsername" placeholder="Enter Username"></asp:TextBox>
            <label ><b>Password</b></label>
            <asp:TextBox runat="server" ID="txtLoginPassword" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
            <asp:Label runat="server" ID="lblMessaage" class="red"></asp:Label><br />
            <asp:Button runat="server" ID="btnLogin" CssClass="lgnbtn" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button runat="server" ID="btnRegister" Text="Register" class="cnbtn" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>

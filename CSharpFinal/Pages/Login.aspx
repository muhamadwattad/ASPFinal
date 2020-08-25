<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSharpFinal.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <style>
        body {
            background-image: url("../Images/thisback.jpg");
            font-size: 14px;
            color: #fff;
        }

        .link {
            color: black;
        }

        .simple-login-container {
            width: 300px;
            max-width: 100%;
            margin: 50px auto;
        }

            .simple-login-container h2 {
                text-align: center;
                font-size: 20px;
            }

            .simple-login-container .btn-login {
                background-color: #FF5964;
                color: #fff;
            }

        a {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="simple-login-container" style="margin-top: 50px;">
            <h2 style="color: black">Login</h2>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:TextBox runat="server" ID="UsernameText" placeholder="Username" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:TextBox runat="server" TextMode="Password" ID="PasswordText" placeholder="Password" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-block btn-login" OnClick="LoginButton_Click1"></asp:Button>

                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="color: black">
                    <div style="float: left; width: 50%; text-align: center;font-weight:bold">
                        <asp:LinkButton ID="LinkButton3" runat="server" align="left" CssClass="link" OnClick="LinkButton3_Click">Signup</asp:LinkButton>
                    </div>
                    <div  style="float: left; width: 50%; text-align: center;font-weight:bold">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text=" Teacher Login"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

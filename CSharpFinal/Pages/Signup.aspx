<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="CSharpFinal.Pages.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup Page</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script>


</script>
    <style>
        body {
            background-image: url("../Images/thisback.jpg");
            font-size: 14px;
            color: #fff;
        }

        .TextinCheck {
            color: black;
            font-size:small;
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
    <form id="form1" runat="server" class="master-div">
        <div class="simple-login-container" style="margin-top: 50px;">
            <h2 style="color: black">Login</h2>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:TextBox runat="server" ID="UsernameText" placeholder="Username" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:TextBox runat="server" ID="PasswordText" placeholder="Password" CssClass="form-control" AutoPostBack="false"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                     <asp:TextBox runat="server" TextMode="Email" ID="EmailText" placeholder="Email" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <div align="center">
                        <asp:DropDownList ID="Subjects" runat="server" align="center" OnSelectedIndexChanged="Subjects_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:CheckBoxList ID="Courses" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="Courses_SelectedIndexChanged1" Width="78px" CssClass="TextinCheck">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:Button ID="LoginButton" runat="server" Text="Signup" CssClass="btn btn-block btn-login" OnClick="LoginButton_Click1"></asp:Button>

                </div>
            </div>
         
        </div>

    </form>

</body>
</html>

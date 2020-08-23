<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CSharpFinal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="Style.css" />

    <style>
        a.imjusttext {
            color: #000000;
            text-decoration: none;
        }

            a.imjusttext:hover {
                text-decoration: none;
            }
    </style>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label5" runat="server" Text="Welcome HEY"></asp:Label>
        </div>
        <div style="margin-top: 15px">

            <ul>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="Home"></asp:Label>
                </li>
                <li onclick="gotoclasses">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Classes</asp:LinkButton>
                   
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Grades</asp:LinkButton>
                </li>
                <li class="right">
                    <asp:LinkButton ID="LinkButton4" runat="server">Logout</asp:LinkButton>
                </li>
                <li class="right">
                    <asp:LinkButton ID="LinkButton3" runat="server">Contact us</asp:LinkButton>
                </li>

            </ul>

        </div>
    </form>
</body>
</html>

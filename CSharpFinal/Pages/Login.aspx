<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSharpFinal.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-content: center; text-align: center; align-self: center; align-items: center; margin-top: 15px">
            <div style="text-align:center;align-content:center;align-items:center; direction: ltr;">
                <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate" TextLayout="TextOnTop">
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                    <TextBoxStyle Font-Size="0.8em" />
                    <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
            </div>
        </div>
    </form>
</body>
</html>

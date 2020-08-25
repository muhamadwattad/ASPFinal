<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CSharpFinal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="Style.css" />


    <style>
    .noborder{
        border:0px;
    }
        body {
            background-image: url('../Images/thisback.jpg');
            background-repeat: repeat;
            background-attachment: fixed;
            font-family: Arial, Helvetica, sans-serif;
        }



        .activeNV {
            border-bottom-color: #3377FF;
            border-bottom: 2px solid;
        }

        .btn {
            margin-top: 50px;
            margin-left: 50px;
            -webkit-border-radius: 50px;
            -moz-border-radius: 50px;
            border-radius: 50px;
        }


        a.imjusttext:hover {
            text-decoration: none;
        }
        .goleft{
            
            text-align:end;
            align-self:flex-end;
        }
        .topnav {
            background-color: #333;
            overflow: hidden;
            height: 50px;
            margin: 6px;
        }

        /* Style the links inside the navigation bar */
        .cont {
            float: left;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
            font-size: 17px;
        }

        /* Change the color of links on hover */
        . :hover {
            background-color: #ddd;
            color: black;
        }

        /* Add a color to the active/current link */
        .topnav a.active {
            background-color: #4CAF50;
            color: white;
        }
    </style>
    <title></title>
    <style>
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="topnav">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="cont active" OnClick="LinkButton1_Click1">HomePage</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="cont" OnClick="LinkButton2_Click1">Classes</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="cont" OnClick="LinkButton3_Click">Grades</asp:LinkButton>
           
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="cont" OnClick="LinkButton5_Click">Logout</asp:LinkButton>
 
            </div>
        <div style="height: auto; margin-top: 15px">
            <div style="width: 40%; float: left; text-align: left;margin:10px;">
                <div class="list-group">
                    <asp:Button Text="Sunday" ID="sun" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed1_Click"></asp:Button>
                    <asp:Button ID="mon" Text="Monday" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed2_Click"></asp:Button>
                    <asp:Button ID="the" Text="Theusday" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed3_Click"></asp:Button>
                    <asp:Button ID="wend" Text="Wendsday" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed4_Click"></asp:Button>
                    <asp:Button Text="Thursday" ID="thu" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed5_Click"></asp:Button>
                    <asp:Button Text="Friday" ID="fri" type="button" CssClass="list-group-item list-group-item-action noborder" runat="server" OnClick="Unnamed6_Click"></asp:Button>
                   
                </div>
            </div>
            <div style="margin-left: 15px">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="SqlDataSource1" GridLines="Horizontal" Height="163px" Width="412px">
                    <Columns>
                        <asp:BoundField DataField="Course_Name" HeaderText="Course" SortExpression="Course_Name" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" SelectCommand="GetCourseDay" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="Username" Name="name" Type="String" />
                        <asp:SessionParameter Name="day" SessionField="day" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>

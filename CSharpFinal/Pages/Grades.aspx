<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grades.aspx.cs" Inherits="CSharpFinal.Pages.Grades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="Style.css" />
    <title>Grades</title>
    <style>
        body {
            background-image: url('../Images/thisback.jpg');
            background-repeat: repeat;
            background-attachment: fixed;
            font-family: Arial, Helvetica, sans-serif;
        }



        .active {
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

        .topnav {
            background-color: #333;
            overflow: hidden;
            height: 50px;
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
</head>
<body>
    <form id="form1" runat="server">
       <div class="topnav">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="cont" OnClick="LinkButton1_Click1">HomePage</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="cont " OnClick="LinkButton2_Click1">Classes</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="cont active" OnClick="LinkButton3_Click">Grades</asp:LinkButton>
           
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="cont" OnClick="LinkButton5_Click">Logout</asp:LinkButton>

        </div>
        <div style="width:auto;margin-top:15px">
            <div style="float:left;width:auto">
                <asp:GridView ID="GridView1" runat="server" Width="204px" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" SortExpression="Course_Name" />
                        <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="Day" />
                        <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" SelectCommand="GetGrades" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="Username" Name="name" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            
           
        </div>
    </form>
</body>
</html>

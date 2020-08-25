<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="CSharpFinal.Pages.Classes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="Style.css" />

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
    <title></title>
</head>

<body>
    <form id="form1" runat="server" clientidmode="Static">
        <div class="topnav">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="cont" OnClick="LinkButton1_Click1">HomePage</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="cont active" OnClick="LinkButton2_Click1">Classes</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="cont" OnClick="LinkButton3_Click">Grades</asp:LinkButton>
           
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="cont" OnClick="LinkButton5_Click">Logout</asp:LinkButton>

        </div>

        <div style="margin-top: 40px; width: 824px;">

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="657px" Height="346px">
                <Columns>
                    <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                    <asp:BoundField DataField="Course_ID" HeaderText="Course Code" SortExpression="Course_ID" />
                    <asp:BoundField DataField="Course_Name" HeaderText="Course" SortExpression="Course_Name" />
                    <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" InsertCommand="getCourses" InsertCommandType="StoredProcedure" SelectCommand="getCourses" UpdateCommand="getCourses" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:CookieParameter CookieName="Username" Name="name" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>

        </div>
        <div style="margin-top: 15px;">
            <div style="float: left">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Day" HeaderText="Available Days" SortExpression="Day" />
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

                <div>
                </div>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" SelectCommand="GetDays" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="code" SessionField="code" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div style="float: left; width: 265px; height: 148px; margin; margin-left: 20px" class="ats">
                <asp:Button ID="Button1" runat="server" Text="Select day" CssClass="btn" OnClick="Button1_Click" />
            </div>
        </div>
    </form>

</body>
</html>

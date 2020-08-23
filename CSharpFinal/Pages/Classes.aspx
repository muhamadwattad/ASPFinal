<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="CSharpFinal.Pages.Classes" %>

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
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Home</asp:LinkButton>

                </li>
                <li onclick="gotoclasses">
                    <asp:Label ID="Label2" runat="server" Text="Classes" CssClass="active"></asp:Label>


                </li>
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Grades</asp:LinkButton>
                </li>
                <li class="right">
                    <asp:LinkButton ID="LinkButton4" runat="server">Logout</asp:LinkButton>
                </li>
                <li class="right">
                    <asp:LinkButton ID="LinkButton3" runat="server">Contact us</asp:LinkButton>
                </li>


            </ul>

        </div>
         <div style="margin-top:40px">
             <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="421px">
                 <AlternatingRowStyle BackColor="Gainsboro" />
                 <Columns>
                     <asp:CommandField ShowSelectButton="True" />
                     <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" SortExpression="Course_ID" />
                     <asp:BoundField DataField="Course_Name" HeaderText="Course_Name" SortExpression="Course_Name" />
                     <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
                 </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#0000A9" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#000065" />
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" InsertCommand="getCourses" InsertCommandType="StoredProcedure" SelectCommand="getCourses" SelectCommandType="StoredProcedure" UpdateCommand="getCourses" UpdateCommandType="StoredProcedure">
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
    </form>
   
</body>
</html>

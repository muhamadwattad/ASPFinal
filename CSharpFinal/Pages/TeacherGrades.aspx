<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherGrades.aspx.cs" Inherits="CSharpFinal.Pages.TeacherGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Grades</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
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
            top: 0px;
            left: 0px;
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

            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="cont active" OnClick="LinkButton3_Click">Grades</asp:LinkButton>
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="cont " OnClick="LinkButton5_Click">Logout</asp:LinkButton>

        </div>
        <div style="height: auto; margin-top: 15px">
            <div style="width: 33%; float: left; text-align: left; margin: 10px;">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" Height="189px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="318px">
                    <Columns>
                        <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                        <asp:BoundField DataField="Course_ID" HeaderText="Course Code" SortExpression="Course_ID" />
                        <asp:BoundField DataField="Course_Name" HeaderText="Course" SortExpression="Course_Name" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" SelectCommand="GetTeacherCourses" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="Teacher" Name="name" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
                <div style="width:20%;float:left">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Course_ID,User_Name" DataSourceID="SqlDataSource3">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="User_Name" HeaderText="Student" ReadOnly="True" SortExpression="User_Name" />
                     
                        <asp:BoundField DataField="Course_ID" HeaderText="Course Code" ReadOnly="True" SortExpression="Course_ID" />
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
               
                    </div>
            <div style="float:left;margin-left:5px">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:CSharpFinalConnectionString2 %>" DeleteCommand="DELETE FROM [CourseUsers] WHERE [Course_ID] = @original_Course_ID AND [User_Name] = @original_User_Name AND (([Grade] = @original_Grade) OR ([Grade] IS NULL AND @original_Grade IS NULL))" InsertCommand="INSERT INTO [CourseUsers] ([Grade], [Course_ID], [User_Name]) VALUES (@Grade, @Course_ID, @User_Name)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Grade], [Course_ID], [User_Name] FROM [CourseUsers] WHERE ([Course_ID] = @Course_ID)" UpdateCommand="UPDATE [CourseUsers] SET [Grade] = @Grade WHERE [Course_ID] = @original_Course_ID AND [User_Name] = @original_User_Name AND (([Grade] = @original_Grade) OR ([Grade] IS NULL AND @original_Grade IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_Course_ID" Type="Int32" />
                        <asp:Parameter Name="original_User_Name" Type="String" />
                        <asp:Parameter Name="original_Grade" Type="Double" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Grade" Type="Double" />
                        <asp:Parameter Name="Course_ID" Type="Int32" />
                        <asp:Parameter Name="User_Name" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="Course_ID" SessionField="id" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Grade" Type="Double" />
                        <asp:Parameter Name="original_Course_ID" Type="Int32" />
                        <asp:Parameter Name="original_User_Name" Type="String" />
                        <asp:Parameter Name="original_Grade" Type="Double" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>

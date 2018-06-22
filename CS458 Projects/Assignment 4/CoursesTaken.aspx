<%@ Page Title="" Language="C#" MasterPageFile="~/TrollUniversity.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Assignment_4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Student: <asp:Label runat="server" ID="StudentName" DataSourceID ="StudentDataSource">CJ Post</asp:Label>
    <br />
    <br />
    Courses Taken<asp:SqlDataSource ID="SqlDataSourceGetStudentCoursesTaken" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsCourses %>" 
        ProviderName="<%$ ConnectionStrings:StudentsCourses.ProviderName %>" OnSelecting="SqlDataSource1_Selecting" 
        SelectCommand="SELECT CoursesTaken.Grade, Courses.CourseNo + Courses.Discipline AS Course, Courses.CourseTitle AS Title FROM ((Courses INNER JOIN CoursesTaken ON Courses.CourseID = CoursesTaken.CourseID) INNER JOIN Students ON CoursesTaken.StudentID = Students.Email) WHERE (Students.Email = 'aaakin@mail.usi.edu') ORDER BY Courses.CourseTitle"  >
        
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceGetGrade" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Grade] FROM [CoursesTaken] WHERE (([StudentID] = ?) AND ([CourseID] = ?))">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="StudentID" QueryStringField="id" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="CourseID" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceGetCourseNames" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [CourseID] FROM [Courses]"></asp:SqlDataSource>
    <table style="width:100%;">
            <table class="tg">
                <tr>
                    <th class="tg-yw4l">Selected Course:</th>
                    <th class="tg-yw4l">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceGetStudentCoursesTaken" DataTextField="Course" DataValueField="Course" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                    </th>
                </tr>
                <tr>
                    <td class="tg-yw4l">Grade:</td>
                    <td class="tg-yw4l">
                        <asp:TextBox ID="TextBox2" runat="server" Width="85px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tg-yw4l" style="height: 23px"></td>
                    <td class="tg-yw4l" style="height: 23px">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Apply" Width="59px" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" Width="60px" />
                    </td>
                </tr>
            </table>
            <br />
                <table class="tg">
                    <tr>
                        <th class="tg-yw4l" style="width: 103px">Course:</th>
                        <th class="tg-yw4l"><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSourceGetCourseNames" DataTextField="CourseID" DataValueField="CourseID">
                </asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <td class="tg-yw4l" style="width: 103px">Grade:</td>
                        <td class="tg-yw4l"> <asp:TextBox ID="TextBox1" runat="server" Width="85px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l" style="width: 103px">&nbsp;</td>
                        <td class="tg-yw4l">
                <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click1" Width="66px" />
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSourceMis" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Grade] FROM [CoursesTaken] WHERE ([StudentID] = ?)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="StudentID" QueryStringField="ID" Type="String" />
                    </SelectParameters>
    </asp:SqlDataSource>
                <br />
                &nbsp;<br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 262px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSourceGetStudentCoursesTaken">
        <AlternatingItemTemplate>
            <span style="background-color: #FFF8DC;">Grade:
            <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
            <br />
            Course:
            <asp:Label ID="CourseLabel" runat="server" Text='<%# Eval("Course") %>' />
            <br />
            Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
<br /></span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="background-color: #008A8C;color: #FFFFFF;">Grade:
            <asp:TextBox ID="GradeTextBox" runat="server" Text='<%# Bind("Grade") %>' />
            <br />
            Course:
            <asp:TextBox ID="CourseTextBox" runat="server" Text='<%# Bind("Course") %>' />
            <br />
            Title:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            <br /><br /></span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">Grade:
            <asp:TextBox ID="GradeTextBox" runat="server" Text='<%# Bind("Grade") %>' />
            <br />Course:
            <asp:TextBox ID="CourseTextBox" runat="server" Text='<%# Bind("Course") %>' />
            <br />Title:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br /><br /></span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="background-color: #DCDCDC;color: #000000;">Grade:
            <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
            <br />
            Course:
            <asp:Label ID="CourseLabel" runat="server" Text='<%# Eval("Course") %>' />
            <br />
            Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
<br /></span>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">Grade:
            <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
            <br />
            Course:
            <asp:Label ID="CourseLabel" runat="server" Text='<%# Eval("Course") %>' />
            <br />
            Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
<br /></span>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>

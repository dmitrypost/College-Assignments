<%@ Page Title="" Language="C#" MasterPageFile="~/TrollUniversity.Master" AutoEventWireup="true" CodeBehind="Courses View.aspx.cs" Inherits="Assignment_4.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Courses]"></asp:SqlDataSource>
    <p>

    </p>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="CourseID" DataSourceID="SqlDataSource1">
    <AlternatingItemTemplate>
        <span style="background-color: #FAFAD2;color: #284775;">CourseID:
        <asp:Label ID="CourseIDLabel" runat="server" Text='<%# Eval("CourseID") %>' />
        <br />
        Discipline:
        <asp:Label ID="DisciplineLabel" runat="server" Text='<%# Eval("Discipline") %>' />
        <br />
        CourseNo:
        <asp:Label ID="CourseNoLabel" runat="server" Text='<%# Eval("CourseNo") %>' />
        <br />
        CourseTitle:
        <asp:Label ID="CourseTitleLabel" runat="server" Text='<%# Eval("CourseTitle") %>' />
        <br />
<br /></span>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <span style="background-color: #FFCC66;color: #000080;">CourseID:
        <asp:Label ID="CourseIDLabel1" runat="server" Text='<%# Eval("CourseID") %>' />
        <br />
        Discipline:
        <asp:TextBox ID="DisciplineTextBox" runat="server" Text='<%# Bind("Discipline") %>' />
        <br />
        CourseNo:
        <asp:TextBox ID="CourseNoTextBox" runat="server" Text='<%# Bind("CourseNo") %>' />
        <br />
        CourseTitle:
        <asp:TextBox ID="CourseTitleTextBox" runat="server" Text='<%# Bind("CourseTitle") %>' />
        <br />
        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
        <br /><br /></span>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <span>No data was returned.</span>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <span style="">CourseID:
        <asp:TextBox ID="CourseIDTextBox" runat="server" Text='<%# Bind("CourseID") %>' />
        <br />Discipline:
        <asp:TextBox ID="DisciplineTextBox" runat="server" Text='<%# Bind("Discipline") %>' />
        <br />CourseNo:
        <asp:TextBox ID="CourseNoTextBox" runat="server" Text='<%# Bind("CourseNo") %>' />
        <br />CourseTitle:
        <asp:TextBox ID="CourseTitleTextBox" runat="server" Text='<%# Bind("CourseTitle") %>' />
        <br />
        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
        <br /><br /></span>
    </InsertItemTemplate>
    <ItemTemplate>
        <span style="background-color: #FFFBD6;color: #333333;">CourseID:
        <asp:Label ID="CourseIDLabel" runat="server" Text='<%# Eval("CourseID") %>' />
        <br />
        Discipline:
        <asp:Label ID="DisciplineLabel" runat="server" Text='<%# Eval("Discipline") %>' />
        <br />
        CourseNo:
        <asp:Label ID="CourseNoLabel" runat="server" Text='<%# Eval("CourseNo") %>' />
        <br />
        CourseTitle:
        <asp:Label ID="CourseTitleLabel" runat="server" Text='<%# Eval("CourseTitle") %>' />
        <br />
<br /></span>
    </ItemTemplate>
    <LayoutTemplate>
        <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
            <span runat="server" id="itemPlaceholder" />
        </div>
        <div style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
            <asp:DataPager ID="DataPager1" runat="server">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
        </div>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <span style="background-color: #FFCC66;font-weight: bold;color: #000080;">CourseID:
        <asp:Label ID="CourseIDLabel" runat="server" Text='<%# Eval("CourseID") %>' />
        <br />
        Discipline:
        <asp:Label ID="DisciplineLabel" runat="server" Text='<%# Eval("Discipline") %>' />
        <br />
        CourseNo:
        <asp:Label ID="CourseNoLabel" runat="server" Text='<%# Eval("CourseNo") %>' />
        <br />
        CourseTitle:
        <asp:Label ID="CourseTitleLabel" runat="server" Text='<%# Eval("CourseTitle") %>' />
        <br />
<br /></span>
    </SelectedItemTemplate>
</asp:ListView>
</asp:Content>

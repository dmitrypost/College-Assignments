<%@ Page Title="" Language="C#" MasterPageFile="~/TrollUniversity.Master" AutoEventWireup="true" CodeBehind="Student Details.aspx.cs" Inherits="Assignment_4.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Student data
        <br />
        <asp:SqlDataSource runat="server" ID="SqlDataSourceStudentData" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" OnSelecting="SqlDataSourceStudentData_Selecting" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Students] WHERE ([Email] = ?)">
            <SelectParameters>
                <asp:QueryStringParameter Name="Email" QueryStringField="StudentID" Type="String" />
            </SelectParameters>

        </asp:SqlDataSource>
    </p>
    <p>
        moo</p>
    <table style="width:350px;">
        <tr>
            <td style="width: 99px">First name:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox1" runat="server" style="margin-left: 0px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">Middle Initial:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">Last name:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">Phone:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox4" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">GPA:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox5" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">Email:</td>
            <td style="width: 298px">
                <asp:Label ID="TextBox6" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">&nbsp;</td>
            <td style="width: 298px">&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Courses Taken" OnClick="Button1_Click" />
    <br />
    
</asp:Content>

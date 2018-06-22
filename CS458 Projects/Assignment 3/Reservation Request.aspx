<%@ Page Title="Anderson Zepplin Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservation Request.aspx.cs" Inherits="Assfdlsanmfewkr3.WebForm2" SmartNavigation="True"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <table>
        <tr>
            <td>
<p>Reservation Request</p>
            </td>
        </tr>
        <tr>
            <td>
    Date: <asp:TextBox ID="TextBox1" runat="server" Width="104px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True" CssClass="required"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Resources/images.jpg" OnClick="ImageButton1_Click" Width="23px" Height="21px" />
            </td>
        </tr>
    </table>
    
    
    <table>
        <asp:Calendar ID="Calendar1" runat="server" Visible="True" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="Cal"></asp:Calendar>
    </table>
    <table><tr><td>
        Number of adults ($125.00)  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UpdateTotal">
        
    </asp:DropDownList>
           </td></tr>
        <tr><td>
            Number of children ($75.00) <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="UpdateTotal">
        
    </asp:DropDownList>
        </td></tr>
        
    </table>
    <table><tr><td>
            Class: </td><td><asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="separator">
                <asp:ListItem>First</asp:ListItem>
                <asp:ListItem>Coach</asp:ListItem>
                <asp:ListItem>Standing Room</asp:ListItem>
            </asp:RadioButtonList>
            </td></tr></table>
    <table>
        <tr>
            <td>
                Destination:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>Evansville -&gt; St. Louis</asp:ListItem>
                    <asp:ListItem>Evansville -&gt; Chicago</asp:ListItem>
                    <asp:ListItem>Evansville -&gt; Indianapolis</asp:ListItem>
                    <asp:ListItem>Evansville -&gt; Nashville</asp:ListItem>
                    <asp:ListItem>Evansville -&gt; Pittsburgh</asp:ListItem>
                    <asp:ListItem>Evansville -&gt; Atlanta</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Special Requests:
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="72px" Width="174px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Contact Information:
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Name:
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="required"></asp:TextBox>
            </td>
        </tr>
    
        <tr>
            <td>
                Email:
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged" AutoPostBack="True" CssClass="required"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
  
        <tr>
            <td>
                Total:
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="$0.00"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="180px" CssClass="button" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Clear" Width="180px" OnClick="Button2_Click" CssClass="button" />
            </td>
        </tr>
    </table>
</asp:Content>

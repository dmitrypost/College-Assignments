<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Assignment_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    
        <asp:Label ID="Label1" runat="server" Text="REGISTRATION FORM"></asp:Label>
        <div>
            <asp:Label ID="Label2" runat="server" Text='Please fill in all feilds and click "Register".'></asp:Label>
        </div>
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/Untitled picture.png" />
        </div>
        
            <table style="height: 33px; width: 65px">
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="First Name" Width="85px"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>

                    <td><asp:Label ID="Label4" runat="server" Text="Last Name" Width="85px"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Email" Width="85px"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    <td><asp:Label ID="Label6" runat="server" Text="Phone" Width="85px"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
            </table>
       
            <div>

        <div>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/Untitled picture1.png" />
        </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="207px" OnSelectedIndexChanged="UpdateTotal" AutoPostBack="True">
                <asp:ListItem>Student ($5.00)</asp:ListItem>
                <asp:ListItem>Presenter ($10.00)</asp:ListItem>
                <asp:ListItem>Member ($10.00)</asp:ListItem>
                <asp:ListItem>Non-Member ($29.00)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Resources/Untitled picture2.png" />
        </div>
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="UpdateTotal" AutoPostBack="True">
                <asp:ListItem>Friday lunch ($8.00)</asp:ListItem>
                <asp:ListItem>Friday Keynote Dinner ($25.00)</asp:ListItem>
                <asp:ListItem>Saturday Breakfast ($6.00)</asp:ListItem>
                <asp:ListItem>Saturday Lunch ($8.00)</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div>
            <label>Total:</label>
            <asp:TextBox ID="TextBoxTotal" runat="server"></asp:TextBox>
        </div>
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register" />
        </p>
    </form>
</body>
</html>

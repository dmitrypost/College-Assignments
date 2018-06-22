<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Assignmnet_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
</head>
<body>
    <div style="display:table;">
  <div style="display:flex;justify-content:center;align-items:center;">
    <div style="margin-left:auto;margin-right:auto;">
<form id="form1" runat="server" class="holder" >
        
    
        <asp:Label ID="Label1" runat="server" Text="REGISTRATION FORM" Font-Names="Comic Sans MS"></asp:Label>
        <div>
            <asp:Label ID="Label2" runat="server" Text='Please fill in all feilds and click "Register".' Font-Names="Comic Sans MS"></asp:Label>
        </div>
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/UserInformation.fw.png" CssClass="pictureTitle" Width="273px" />
        </div>
        
            <table style="height: 33px; width: 65px">
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="First Name" Width="85px" Font-Names="Comic Sans MS"></asp:Label></td>
                    
                    <td><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="textbox" OnTextChanged="UpdateTotal"></asp:TextBox></td>

                </tr>
                <tr>

                    <td><asp:Label ID="Label4" runat="server" Text="Last Name" Width="85px" Font-Names="Comic Sans MS"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" CssClass="textbox" OnTextChanged="UpdateTotal" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Email" Width="85px" Font-Names="Comic Sans MS"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" CssClass="textbox" OnTextChanged="UpdateTotal"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Phone" Width="85px" Font-Names="Comic Sans MS"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" CssClass="textbox" OnTextChanged="UpdateTotal"></asp:TextBox></td>
                </tr>
            </table>
       
            <div>

        <div>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/Type.fw.png" CssClass="pictureTitle" Width="273px" />
        </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="207px" OnSelectedIndexChanged="UpdateTotal" AutoPostBack="True" Font-Names="Comic Sans MS">
                <asp:ListItem>Student ($5.00)</asp:ListItem>
                <asp:ListItem>Presenter ($10.00)</asp:ListItem>
                <asp:ListItem>Member ($10.00)</asp:ListItem>
                <asp:ListItem>Non-Member ($29.00)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Resources/Meals.fw.png" CssClass="pictureTitle" Width="273px" />
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
            <asp:TextBox ID="TextBoxTotal" runat="server" CssClass="total" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register" CssClass="button" />
        </p>
    </form>
       
    </div>
  </div>
</div>
    
</body>
</html>

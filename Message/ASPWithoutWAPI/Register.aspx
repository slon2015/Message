<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ASPWithoutWAPI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #RegBut {
            width: 104px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label><asp:TextBox ID="EmailBox" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="NickLabel" runat="server" Text="Nick"></asp:Label><asp:TextBox ID="NickBox" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="PassLabel" runat="server" Text="Password"></asp:Label><asp:TextBox ID="PassBox" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="TPassLabel" runat="server" Text="Password validate"></asp:Label><asp:TextBox ID="TPassBox" runat="server" ></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" CommandName="RegisterUser" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestSenMail.aspx.cs" Inherits="TestSenMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:RegularExpressionValidator
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox1" 
            ValidationExpression="[\d]{1,4}([.,][\d]{1,2})?"></asp:RegularExpressionValidator>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>

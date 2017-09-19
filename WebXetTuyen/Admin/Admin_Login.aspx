<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>
</head>
<body>
    <form id="frmLoging" runat="server">
   <center>
       &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;<table border="0" cellpadding="0" cellspacing = "0" style="width: 406px; height: 180px;" id="TABLE1" >
       <tr><td colspan="2" align="center" style="color: #ffffff; background-color: #0066cc">Đăng nhập vào trang quản trị</td></tr>
        <tr>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8; text-align: left;">
             <strong>&nbsp; User Name</strong>:</td>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8;">
             <asp:TextBox ID="txtUserName" runat="server" Width="181px" 
               AutoPostBack="false"></asp:TextBox></td>
        </tr>
        <tr>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8; text-align: left;">
             <strong>&nbsp; Pass world:</strong></td>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8;">
             <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="182px" 
                  AutoPostBack="false" ></asp:TextBox></td>
        </tr>
        <tr>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8; text-align: center;">
             <asp:Button ID="btnReset" runat="server" Height="35px" Text="Reset" UseSubmitBehavior="False"
                 Width="149px" OnClick="btnReset_Click" /></td>
         <td align ="left" style="width: 224px; height: 30px; background-color: #ece9d8; text-align: center;">
             <asp:Button ID="btnLogin" runat="server" Height="35px" Text="Login" UseSubmitBehavior="False"
                 Width="149px" OnClick="btnLogin_Click" />
        </tr>
        <tr><td colspan="2" align="center" style="height: 30px; width: 224px; background-color: #ece9d8; text-align: center;"> 
            <asp:Label ID="lblThongBao" runat="server" Text="Pass world hoặc mật khẩu sai!" Visible="False" Height="23px" Width="246px" ForeColor="Red"></asp:Label></td></tr>
        </table>
        </center>
   
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NumCaptcha.ascx.cs" Inherits="Controls_Levioza_levcaptcha" %>

<table border="0">
<tr>
<td><asp:image id="Image1" runat="server" imageurl="captcsha.jpg" /></td>
<td valign="middle">&nbsp;&nbsp; =&nbsp;</td>
<td valign="middle">
<asp:TextBox ID="TextBoxNo" runat="server" width="25px" maxlength="2"></asp:TextBox>
<asp:RequiredFieldValidator ID="ReqNo" runat="server" ControlToValidate="TextBoxNo" Display="Dynamic"
SetFocusOnError="true" Font-Size="11px" ErrorMessage="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegxNo" ControlToValidate="TextBoxNo" SetFocusOnError="true" Font-Size="11px" Display="Dynamic"
ValidationExpression="[0-9]{1,2}" runat="server" ErrorMessage="Chỉ nhập số"></asp:RegularExpressionValidator>
&nbsp;<asp:Label ID="lblMessage" ForeColor="Red" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
</td>
</tr>
</table>

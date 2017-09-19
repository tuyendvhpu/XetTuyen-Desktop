<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Admin_GroupAdd.aspx.cs" Inherits="Admin_GroupAdd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenHead" Runat="Server">
THÊM NHÓM NGƯỜI DÙNG
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentEdit" Runat="Server">
 <table cellpadding="0" cellspacing="0" border="0" width="725">
        <tr>
            <td class="text13b" align="center" valign="top" colspan="2" style="padding-left: 5px;
                padding-bottom: 5px; padding-top: 5px;">
               </td>
        </tr>
        <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Tên nhóm người dùng:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtName" runat="server" Width="300px"   onkeyup=telexingVietUC(this,event)></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator
                    ID="rqvName" ControlToValidate="txtName" runat="server" ErrorMessage="Vui lòng nhập tên nhóm!"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
              Ghi chú:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtGhichu" runat="server" Width="490px"  ></asp:TextBox>
                </td>
        </tr>
         <tr>
           
            <td class="text12" align="center" valign="top" colspan ="2" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                &nbsp;<asp:Button ID="bntUpdate"  runat="server" Text="Thêm Mới" OnClick="bntUpdate_Click" Width="119px" UseSubmitBehavior="False"  />
                </td>
        </tr>
        <tr><td colspan="2" align ="center" style="height:10px;" valign="middle"><asp:Label ID="lblAdd" runat="server" Height="34px" Visible="False" Width="713px"></asp:Label></td></tr>
    </table>
</asp:Content>


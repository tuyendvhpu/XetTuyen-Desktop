<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Admin_UsersEdit.aspx.cs" Inherits="Admin_UsersEdit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenHead" Runat="Server">
    THÊM NGƯỜI DÙNG
<link rel="stylesheet" type="text/css" media="all" href="calendar/calendar-system.css" title="DeadLine">
<script type="text/javascript" src="calendar/calendar.js"></script>
<script type="text/javascript" src="calendar/lang/calendar-en.js"></script>
<script type="text/javascript" src="calendar/calendar-setup.js"></script>
<script src="<%=ResolveUrl("js/jquery-1.7.2.min.js")%>" type="text/javascript"></script>

<script type="text/javascript">
    function txtBirthDayVali(sender, args) {
        args.IsValid = false;
 
        var v = document.getElementById('<%=txtBirthDay.ClientID%>').value;
        //alert(v);
        // Check Euro Date format (dd/mm/yyyy)
          args.IsValid = ew_CheckEuroDate(v) ;

      }
      function txtDateDeadlineVali(sender, args) {
          args.IsValid = false;

          var v = document.getElementById('<%=txtDateDeadline.ClientID%>').value;
          //alert(v);
          // Check Euro Date format (dd/mm/yyyy)
          args.IsValid = ew_CheckEuroDate(v);

      }
      function txtEmailVali(sender, args) {
          args.IsValid = false;

          var v = document.getElementById('<%=txtEmail.ClientID%>').value;
          //alert(v);
          // Check Euro Date format (dd/mm/yyyy)
          args.IsValid = ew_CheckEmail(v);

      }
      
     
</script>

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
                Tên đăng nhập:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtUser" runat="server" Width="250px"   onkeyup=telexingVietUC(this,event)></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator
                    ID="rqvUser" ControlToValidate="txtUser" runat="server"  Display="Dynamic" ErrorMessage="Vui lòng nhập đăng nhập!"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Mật khẩu:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtPass" runat="server" Width="250px" TextMode="Password"  ></asp:TextBox><asp:RequiredFieldValidator
                    ID="rqvPass" ControlToValidate="txtPass" runat="server"  Display="Dynamic" ErrorMessage="Vui lòng nhập mật khẩu!"></asp:RequiredFieldValidator>
                </td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Nhập lại mật khẩu:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtRePass" runat="server" Width="250px" TextMode="Password" ></asp:TextBox> 
                <asp:CompareValidator ID="cpvPass" v runat="server" ControlToCompare="txtPass"  Display="Dynamic" ControlToValidate="txtRePass" ErrorMessage="Xác nhận mật khẩu không đúng!"></asp:CompareValidator><asp:RequiredFieldValidator
                    ID="rqvRePass" ControlToValidate="txtRePass" runat="server"  Display="Dynamic" ErrorMessage="Vui lòng nhập lại mật khẩu!"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Họ tên:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtName" runat="server" Width="300px"   onkeyup=telexingVietUC(this,event)></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator
                    ID="rqvName" ControlToValidate="txtName"  Display="Dynamic" runat="server" ErrorMessage="Vui lòng nhập họ tên!"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Ngày sinh:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtBirthDay" Text="01/01/1995"  CssClass="NgaySinhtxt" MaxLength="10" runat="server"></asp:TextBox>
                (dd/mm/yyyy)&nbsp;<img src="../images/calendar.png" id="cal_x_txtBirthDay" name="cal_x_txtBirthDay"  style="cursor:pointer;cursor:hand;">
<script type="text/javascript">
    Calendar.setup({
    inputField: "<%=txtBirthDay.ClientID%>", // input field id
        ifFormat: "%d/%m/%Y", // date format
        button: "cal_x_txtBirthDay" // button id
    });
</script><asp:RequiredFieldValidator
                    ID="rqvBirthDay" ControlToValidate="txtBirthDay"  Display="Dynamic" runat="server" ErrorMessage="Vui lòng nhập ngày sinh!"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="csvBirthDay" Display="Dynamic" ControlToValidate="txtBirthDay" ErrorMessage="Định dạng ngày tháng không đúng!" ClientValidationFunction="txtBirthDayVali" runat="server" ></asp:CustomValidator>
                    </td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Giới tính:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;"> <asp:DropDownList ID="drlGioiTinh" Width="75" runat="server">
             <asp:ListItem Selected="True">Nam</asp:ListItem>
             <asp:ListItem>Nữ</asp:ListItem>
         </asp:DropDownList>
               </td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Địa chỉ email:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"   onkeyup=telexingVietUC(this,event)></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator ID="rqvEmail" runat="server" 
             ErrorMessage="Xin vui lòng nhập Email!" ControlToValidate="txtEmail" 
             Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CustomValidator Display="Dynamic" ID="csvEmail" ControlToValidate="txtEmail" ErrorMessage="Định dạng email không đúng!" ClientValidationFunction="txtEmailVali" runat="server" ></asp:CustomValidator></td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Khóa mật khẩu:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:CheckBox ID="cbLock" runat="server" />
                </td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Lý do khóa:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtLockReason" runat="server" Width="300px" TextMode="MultiLine"   onkeyup=telexingVietUC(this,event)></asp:TextBox>
                </td>
        </tr>
         <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Hạn dùng:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:TextBox ID="txtDateDeadline" Text="01/01/1995"  CssClass="NgaySinhtxt" MaxLength="10" runat="server"></asp:TextBox>
                (dd/mm/yyyy)&nbsp;<img src="../images/calendar.png" id="cal_x_txtDateDeadline" name="cal_x_txtDateDeadline"  style="cursor:pointer;cursor:hand;">
<script type="text/javascript">
    Calendar.setup({
    inputField: "<%=txtDateDeadline.ClientID%>", // input field id
        ifFormat: "%d/%m/%Y", // date format
        button: "cal_x_txtDateDeadline" // button id
    });
</script><asp:RequiredFieldValidator
                    ID="rqvDateDeadline" ControlToValidate="txtDateDeadline"  Display="Dynamic" runat="server" ErrorMessage="Vui lòng nhập ngày hết hạn!"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="csvDateDeadLine" ControlToValidate="txtDateDeadline" ErrorMessage="Định dạng ngày tháng không đúng!" ClientValidationFunction="txtDateDeadlineVali" runat="server" ></asp:CustomValidator>
                </td>
        </tr>
        <tr>
            <td class="text12b" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 173px;">
                Nhóm người dùng:</td>
            <td class="text12" align="left" valign="top" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:CheckBoxList ID="cblGroup" runat="server" 
                    ondatabinding="cblGroup_DataBinding">
                </asp:CheckBoxList>
                </td>
        </tr>
        <tr>
           
            <td class="text12" align="center" valign="top" colspan ="2" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                <asp:Label ID="lbleror" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
                </td>
        </tr>
         <tr>
           
            <td class="text12" align="center" valign="top" colspan ="2" style="padding-left: 5px; padding-bottom: 5px;
                padding-top: 5px; width: 552px;">
                &nbsp;<asp:Button ID="bntUpdate"  runat="server" Text="Cập nhật" OnClick="bntUpdate_Click" Width="119px" UseSubmitBehavior="False"  />
                </td>
        </tr>
        <tr><td colspan="2" align ="center" style="height:10px;" valign="middle"><asp:Label ID="lblAdd" runat="server" Height="34px" Visible="False" Width="713px"></asp:Label></td></tr>
    </table>
</asp:Content>


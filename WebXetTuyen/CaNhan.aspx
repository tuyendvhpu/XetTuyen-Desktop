<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CaNhan.aspx.cs" Inherits="CaNhan" Title="Haiphong Private University"  Culture="en-US" UICulture="en-US" %>
<%@ Register TagName="Captcha" TagPrefix="Controls" Src="NumCaptcha.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="js/calendar-en.min.js" type="text/javascript"></script>
<script type="text/javascript">

var regex = new RegExp("^[a-zA-Z0-9]+$");
    $(document).ready(function () {
        $("#<%=txtNgaySinh.ClientID%>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
      
        $("#<%=txtMaTinh.ClientID%>").keypress(function(e) {
             
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               $("#<%=txtMaTinh.ClientID%>").val(str);
                if (regex.test(str)) {
                 var datavalue ={'matinh': + str+$("#<%=txtMaTinh1.ClientID%>").val() ,'mahuyen': + $("#<%=txtMaHuyen.ClientID%>").val() +$("#<%=txtMaHuyen1.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "CaNhan.aspx/GetHuyen",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblHuyen.ClientID%>").text(data.d);
                    }
                    });
                    
                    $("#<%=txtMaTinh1.ClientID%>").focus();
                    
                 return true;
                }
        
             
        });
       
        $("#<%=txtMaTinh1.ClientID%>").keypress(function(e) {
         
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                 $("#<%=txtMaTinh1.ClientID%>").val(str);
                var datavalue ={'matinh': + $("#<%=txtMaTinh.ClientID%>").val()+str ,'mahuyen': + $("#<%=txtMaHuyen.ClientID%>").val() +$("#<%=txtMaHuyen1.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "CaNhan.aspx/GetHuyen",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblHuyen.ClientID%>").text(data.d);
                    }
                    });
                     
                     $("#<%=txtMaHuyen.ClientID%>").focus();
                      return true;
                }
        });
  
        
        
        $("#<%=txtMaHuyen.ClientID%>").keypress(function(e) {
           
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                $("#<%=txtMaHuyen.ClientID%>").val(str);
                 var datavalue ={'matinh': + $("#<%=txtMaTinh.ClientID%>").val()+$("#<%=txtMaTinh1.ClientID%>").val() ,'mahuyen': + str +$("#<%=txtMaHuyen1.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "CaNhan.aspx/GetHuyen",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblHuyen.ClientID%>").text(data.d);
                    }
                    });
                    $("#<%=txtMaHuyen1.ClientID%>").focus();
                      return true;
                }
        });
        
         $("#<%=txtMaHuyen1.ClientID%>").keypress(function(e) {
           
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                 $("#<%=txtMaHuyen1.ClientID%>").val(str);
                  var datavalue ={'matinh': + $("#<%=txtMaTinh.ClientID%>").val()+$("#<%=txtMaTinh1.ClientID%>").val() ,'mahuyen': + $("#<%=txtMaHuyen.ClientID%>").val()+str };
                    $.ajax({
                    type: "POST",
                     url: "CaNhan.aspx/GetHuyen",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblHuyen.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=captcha.ClientID%>").focus();
                      return true;
                }
        });
        
       
    });
    
</script>
    <style >
        .pointer         { cursor: pointer; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
      <div id="contentheader">
				 
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="cacbuoc">Nhập thông tin cá nhân</div>
				<!-- cacbuocnoidung --> <div id="cacbuocnoidung">
					
					<ul id="ma">
						<li id="ma">Số CMTND: <%=Session["soCMTND"]%></li>
						<li id="ma">MÃ XÉT TUYỂN: <%=Session["soBaoDanh"]%></li>
					</ul>
					<table id="tableHSCaNhan" border="0" cellspacing="0" cellpadding="0">
					
  <tr>
    <td class="col1">Họ và tên</td>
    <td class="col2">
        <asp:TextBox ID="txtHoTen" CssClass="CaNhantxt" runat="server"></asp:TextBox>
        <span style="color: #CC3300">
             *</span>
             <strong> 
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="txtHoTen" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập họ tên!"></asp:RequiredFieldValidator>
             </strong> 
        </td>
  </tr>
  <tr>
    <td class="col1">Số điện thoại</td>
    <td class="col2">
        <asp:TextBox ID="txtSoDienThoai" CssClass="CaNhantxt"  runat="server"></asp:TextBox>
        <span style="color: #CC3300">
             *</span>
			<strong> 
             <asp:RequiredFieldValidator ID="rqvDienThoai" runat="server" 
                 ControlToValidate="txtSoDienThoai" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập điện thoại!"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator
                     ID="rglDienTHoai" runat="server" ErrorMessage="Điện thoại không đúng!" 
                 ControlToValidate="txtSoDienThoai" Display="Dynamic" 
                 ValidationExpression="^\d{10,11}"></asp:RegularExpressionValidator>
             </strong> 
        </td>
  </tr>
  <tr>
    <td class="col1">Email</td>
    <td class="col2">
        <asp:TextBox ID="txtEmail" CssClass="CaNhantxt"  runat="server"></asp:TextBox>
        <span style="color: #CC3300">
         *</span> <strong> 
         <asp:RequiredFieldValidator ID="rqvEmail" runat="server" 
             ErrorMessage="Xin vui lòng nhập Email!" ControlToValidate="txtEmail" 
             Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="rglEmail" runat="server" 
             ControlToValidate="txtEmail" 
             ErrorMessage="Địa chỉ email không hợp lệ!" 
             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
             Display="Dynamic"></asp:RegularExpressionValidator></strong> 
        </td>
  </tr>
  <tr>
    <td class="col1">Dân tộc</td>
    <td class="col2">
        <asp:DropDownList ID="drlDanToc" runat="server">
        </asp:DropDownList><span style="color: #CC3300">
         *</span><strong> 
             <asp:RequiredFieldValidator ID="rqvDanToc" runat="server" 
                 ControlToValidate="drlDanToc" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng chọn dân tộc!"></asp:RequiredFieldValidator>
             </strong> 
    </td>
  </tr>
  <tr>
    <td class="col1">Địa chỉ liên hệ</td>
    <td class="col2">
        <asp:TextBox ID="txtDiaChi" CssClass="DiaChitxt" runat="server"></asp:TextBox>
        <span style="color: #CC3300">
         *</span>
        
     </td>
  </tr>
   <tr>
    <td></td>
    <td>
         <strong> 
             <asp:RequiredFieldValidator ID="rqvDiachi" runat="server" 
                 ControlToValidate="txtDiaChi" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập địa chỉ liên hệ!"></asp:RequiredFieldValidator>
             </strong> 
     </td>
  </tr>
  <tr>
    <td class="col1">Ngày sinh</td>
    <td class="col2"><asp:TextBox ID="txtNgaySinh" Text="01/01/1995"  CssClass="NgaySinhtxt" MaxLength="10" runat="server"></asp:TextBox>(dd/mm/yyyy)&nbsp;<asp:Image ID="imgDate" ImageUrl="images/calendar.png"  runat="server"  CssClass="pointer" />
		&nbsp;&nbsp;&nbsp;&nbsp; Giới tính &nbsp;
         <asp:DropDownList ID="drlGioiTinh" runat="server">
             <asp:ListItem Selected="True">Nam</asp:ListItem>
             <asp:ListItem>Nữ</asp:ListItem>
         </asp:DropDownList>    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;(<a href="<%=ResolveUrl("~/huongdan.html") %>" target="_blank">Tra cứu mã tỉnh, huyện</a>)</td>
  </tr>
   <tr>
    <td></td>
    <td>
         <strong> 
             <asp:RequiredFieldValidator ID="rqvNgaySinh" runat="server" 
                 ControlToValidate="txtNgaySinh" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập ngày sinh!"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="valrDate" runat="server" ControlToValidate="txtNgaySinh"  
          MinimumValue="31/12/1950"
         MaximumValue="1/1/2100" Type="Date" Text="Ngày sinh không đúng!" Display="Dynamic" />
            </strong> 
     </td>
  </tr>
  <tr>
   
    <td colspan="2">
       <table id="tableHSCaNhan2"  border="0" cellspacing="0" cellpadding="0">
  <tr style="text-align:left;">
  <td class="col1">Hộ khẩu thường trú </td>
     <td >
	  <asp:TextBox ID="txtHoKhau" CssClass="DiaChitxt" runat="server"></asp:TextBox>
        <span style="color: #CC3300">
         *</span>
     </td>
    <td style="width:55px;"><asp:TextBox ID="txtMaTinh" maxlength="1"  class="Thongtintxt"  runat="server" AutoPostBack="false" ></asp:TextBox>
        <asp:TextBox ID="txtMaTinh1" maxlength="1"  class="Thongtintxt" runat="server" 
            AutoPostBack="false" ></asp:TextBox></td>
    <td style="width:55px;"><asp:TextBox ID="txtMaHuyen" maxlength="1"  class="Thongtintxt"  runat="server" AutoPostBack="false"></asp:TextBox>
            <asp:TextBox ID="txtMaHuyen1" maxlength="1"  class="Thongtintxt" runat="server" 
            AutoPostBack="false" ></asp:TextBox>
        </td>
  </tr>
  <tr>  
   <td class="col1"> </td>
  <td style="width:390px"><strong> 
             <asp:RequiredFieldValidator ID="rqvHoKhau" runat="server" 
                 ControlToValidate="txtHoKhau" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng hộ khẩu thường trú!"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="rqvMaTinh" runat="server" 
                 ControlToValidate="txtMaTinh" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập mã tỉnh ở ô thứ nhất!"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="rqvMaTinh1" runat="server" 
                 ControlToValidate="txtMaTinh1" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập mã tỉnh ở ô thứ 2!"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="rqvMaHuyen" runat="server" 
                 ControlToValidate="txtMaHuyen" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập mã huyện ở ô thứ nhất!"></asp:RequiredFieldValidator>
                  <asp:RequiredFieldValidator ID="rqvMaHuyen1" runat="server" 
                 ControlToValidate="txtMaHuyen1" Display="Dynamic" EnableTheming="False" 
                 ErrorMessage="Xin vui lòng nhập mã huyện ở ô thứ hai!"></asp:RequiredFieldValidator>
          <asp:Label ForeColor="#CC3300" ID="lblError" runat="server" Text=""></asp:Label>
             </strong> </td>
    <td style="width:55px;">Mã tỉnh</td>
    <td style="width:55px;" >Mã huyện</td>
  </tr>
</table>
        
     </td>
  </tr>
 <tr>
    <td></td>
    <td class="des"  style="text-align:right;">
        <asp:Label ID="lblHuyen" runat="server" Text="" ></asp:Label>
     </td>
  </tr>
  <tr>
    <td class="col1">Mã xác nhận</td>
    <td class="col2">
        <Controls:Captcha ID="captcha" CalcMode="1" runat="server" 
            message="Câu trả lời không đúng" />
    </td>
  </tr>
  <tr>
					<td colspan="2"> <asp:CheckBox ID="cbXacThuc" runat="server" ForeColor="Black" 
            Text="Tôi xin cam đoan các thông tin trên là đúng!" Font-Italic="True" /> <asp:Label ID="lblThongBao" ForeColor="#CC3300" runat="server" Text=""></asp:Label></td>
					</tr>
					
</table>
					<!-- cacbuocnoidung --> </div>
				<div id="CaNhanLine"><div id="bottonTiep"> 
    <asp:Button ID="btnTiep" CssClass="BottonTiep" runat="server" Text="Tiếp >>" 
                        onclick="btnTiep_Click"  />
</div>	</div>
</asp:Content>


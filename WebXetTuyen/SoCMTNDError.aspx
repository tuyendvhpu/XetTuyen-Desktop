<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoCMTNDError.aspx.cs" Inherits="SoCMTNDError" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
     <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- SoCMTNTite --> <div id="SoCMTNDTile">Thông báo</div>
				 <!-- SoCMTND --> <div id="SoCMTND">
				 <p id="SoCMTNDThongBao">Số chứng minh thư này đã được sử dụng</p>
				  <p id="SoCMTNDThongBaonodung">
				  Nếu bạn đã đăng ký với số CMT này xin mời cập nhật hồ sơ <a title="HPU sự khác biệt" href="<%=ResolveUrl("SoCMTNDSoBD.html")%>">tại đây</a><br />
				  Vui lòng liên hệ <strong style="color:#ed1c24"> Hotline  0901 598 698 </strong> để được giải đáp
				  </p>
                     <asp:Button ID="btnBack" CssClass="SoCMTNDErrorBotton" runat="server" 
                     Text="Quay lại" onclick="btnBack_Click" />       
				 </div>
<script type="text/javascript">
    var LHCChatOptions = {};
    LHCChatOptions.opt = { widget_height: 340, widget_width: 300, popup_height: 520, popup_width: 500, domain: 'xettuyen.hpu.edu.vn' };
    (function () {
        var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
        var refferer = (document.referrer) ? encodeURIComponent(document.referrer.substr(document.referrer.indexOf('://') + 1)) : '';
        var location = (document.location) ? encodeURIComponent(window.location.href.substring(window.location.protocol.length)) : '';
        po.src = '//hotro.hpu.edu.vn/index.php/chat/getstatus/(click)/internal/(position)/bottom_right/(ma)/br/(top)/350/(units)/pixels/(leaveamessage)/true/(department)/6?r=' + refferer + '&l=' + location;
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
    })();
				</script>
</asp:Content>


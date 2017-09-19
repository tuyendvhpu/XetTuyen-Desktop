<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietHS.aspx.cs" Inherits="_Default" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">

/*--This JavaScript method for Print command--*/

    function PrintDoc() {

        var toPrint = document.getElementById('printarea');

        var popupWin = window.open('', '_blank', 'width=600,height=800,location=no,left=200px');

        popupWin.document.open();

        popupWin.document.write('<html><title>::Preview::</title><link rel="stylesheet" type="text/css" href="print.css" /></head><body onload="window.print()">')

        popupWin.document.write(toPrint.innerHTML);

        popupWin.document.write('</html>');

        popupWin.document.close();

    }
     

/*--This JavaScript method for Print Preview command--*/

    function PrintPreview() {

        var toPrint = document.getElementById('printarea');

        var popupWin = window.open('', '_blank', 'width=350,height=150,location=no,left=200px');

        popupWin.document.open();

        popupWin.document.write('<html><title>::Print Preview::</title><link rel="stylesheet" type="text/css" href="Print.css" media="screen"/></head><body">')

        popupWin.document.write(toPrint.innerHTML);

        popupWin.document.write('</html>');

        popupWin.document.close();

    }

    function openNewWin(url, title, w, h) {

        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        var targetWin = window.open(url, title, 'toolbar=no, titlebar=no,location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        
        targetWin.focus();
    }
</script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=btnIn.ClientID%>").click(function () {
         PrintDoc();
     });
            $("#<%=btnKetThuc.ClientID%>").click(function () {
                openNewWin("<%=ResolveUrl("~/ChonIn.aspx") %>", "Thông báo!", 520, 135);
       });
 });
 </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
     <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="linetite">TRƯỜNG ĐẠI HỌC DÂN LẬP HẢI PHÒNG NĂM HỌC 2015 TỔ CHỨC TUYỂN SINH THEO 02 HÌNH THỨC XÉT TUYỂN</div>
				
				 <!-- end TuyenSinh--> <div id="TuyenSinh" >
				 
				 <p id="TuyenSinh">THÔNG TIN CHI TIẾT XIN LIÊN HỆ HOTLINE <strong style="color:#FF0000">0989 652 819</strong> hoặc <strong style="color:#FF0000">0313 740 577</strong></p>
				<% if (objHoso != null )
            { %><div  id="printarea">
				 <p id="Dot"><b>THÔNG TIN HỒ SƠ ĐĂNG KÝ XÉT TUYỂN CỦA BẠN</b></p>
				 <ul id="Dot">
                <li class="Dot">Số CMTND: <strong style="color:Red; font-size:16px;"><%=objHoso.SoCMTND%></strong></li>
                    <li class="Dot">Điện thoại: <strong style="color:Red; font-size:16px;"><%=objHoso.DienThoai%></strong> </li>
                <li class="Dot">Số Báo danh: <strong style="color:Red; font-size:16px;"><%=objHoso.SoBaoDanh%></strong> </li>
                <li class="Dot">Họ tên: <%=objHoso.HoTen%></li>
                <li class="Dot">Ngày sinh: <%=objHoso.NgaySinh.ToString("dd/MM/yyyy")%></li>
                <li class="Dot">Hộ khẩu: <%=objHoso.HoKhau%></li>
                
                <li class="Dot">Dân tộc: <%=objHoso.DanToc%></li>
               
                <li class="Dot">Email: <%=objHoso.Email%></li>
                 <li class="Dot">Giới tính: <%=objHoso.GioiTinh%></li>
               <li class="Dot">Địa chỉ liên hệ: <%=objHoso.DiaChi%></li>
               <li class="Dot">Lớp 10: <%=objHoso.Lop10%></li>
               <li class="Dot">Lớp 11: <%=objHoso.Lop11%></li>
                <li class="Dot">Lớp 12: <%=objHoso.Lop12%></li>
                <li class="Dot">Khu vực: KV<%=objHoso.MaKV%></li>
                <li class="Dot">Đối tượng: <%=objHoso.MaDT%></li>
				 </ul>
				 <%  if (dtNganh.Rows.Count > 0)
                {%>
				 <p id="Dot"><b>Các ngành đã đăng ký:</b></p>
			<ul id="Dot">
				  <% for (int i = 0; i < dtNganh.Rows.Count; i++)
         {
             %>
                        <li class="Dot">Tên ngành: <%=dtNganh.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtNganh.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%= dtNganh.Rows[i]["DiemTB"].ToString()%></li>
                      
        <% 
         } %>
                </ul>
                <%} %><br />
               <%if (dtTrungTuyen.Rows.Count > 0)
                 { %>
                <p id="Dot"><b>Bạn trúng tuyển ngành sau:</b></p>
                <ul id="Dot">
                    <% for (int i = 0; i < dtTrungTuyen.Rows.Count; i++)
         {
             %>
                        <li class="Dot">Tên ngành: <%=dtTrungTuyen.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtTrungTuyen.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%=dtTrungTuyen.Rows[i]["DiemTB"].ToString()%><strong style="color:blue"> : Trúng tuyển!</strong></li>
                      
        <% 
         } %>
                 </ul>
                  <p id="Dot"><b>Bạn cần chọn một trong các ngành đã trúng tuyển để in giấy báo nhập học:</b></p>
                <asp:RadioButtonList ID="rblTrungTuyen" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" CssClass="clbTrungTuyen">
              
                
            </asp:RadioButtonList>            
                      
                <%} %>
                <br />
<div id="TrungTuyen">
      <b>Để nhận giấy báo nhập học, có 2 cách:</b><br />
   <b>Cách 1</b>: Nhận trực tiếp tại Phòng D105 - Trường Đại học Dân lập Hải Phòng<br />
-	Bạn tới Phòng D105 - Trường Đại học Dân lập Hải Phòng, Địa chỉ: Số 36 - Đường Dân Lập - Phường Dư Hàng Kênh - Lê Chân - Hải Phòng.<br />
-	Bạn cần mang theo bản sao: CMND, Bằng tốt nghiệp hoặc Giấy chứng nhận tốt nghiệp, Học bạ THPT, Phiếu báo điểm (nếu xét tuyển theo Kết quả thi THPT Quốc gia).<br />
-	Sau khi xác minh thông tin, bạn sẽ nhận được Giấy báo nhập học.<br />
<b>Cách 2</b>: Qua đường bưu điện<br />
-	Bạn gửi bản sao: CMND, Bằng tốt nghiệp hoặc Giấy chứng nhận tốt nghiệp, Học bạ THPT, Phiếu báo điểm (nếu xét tuyển theo Kết quả thi THPT Quốc gia).
Tới địa chỉ: Hội đồng tuyển sinh - Trường Đại học Dân lập Hải Phòng, Địa chỉ: Số 36 - Đường Dân Lập - Phường Dư Hàng Kênh - Lê Chân - Hải Phòng.<br />
-	Sau khi xác minh thông tin, Giấy báo nhập học sẽ được gửi tới Địa chỉ bạn đã cung cấp.<br /><br />
<b><i>Chúc bạn thành công!</i></b>
</div>


                </div>
                     <div style="clear:both; float:right;float:left; width:100%"></div>
                <div class="ThongBaoButton">  <asp:Button ID="btnKetThuc" CssClass="BottonTiep" 
                        runat="server" Text="Xác nhận" OnClick="btnKetThuc_Click" />   
                    <asp:Button ID="btnIn" CssClass="BottonTiep" runat="server" Text="In phiếu" />
                 </div>
       <div style="clear:both; float:right;float:left; width:100%;height:10px;"></div>
             <%}%>
               
              
				 </div>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTiet.aspx.cs" Inherits="_Default" Title="Haiphong Private University" %>

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



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
     <div id="contentheader">
				  <table id="tablecontentheader">
				  	  <tr>
					  <td id="topleft"><div id="lefttable"></div><div id="lefttablebotton"></div></td>
                         <td id="cola1">
                             <div id="newshot">
                                
								<div class="slider-wrapper theme-default">
								<div class="ribbon" ></div>
								<div id="slider" class="nivoSlider">
								
								<a href="<%=ResolveUrl("~/InfoNganh.html") %>" target="_blank"><img src="<%=ResolveUrl("images/a1.jpg")%>"  /></a>
								<a target="_blank" href="http://www.hpu.edu.vn/tintuc/HPUCSVCT-cuusinhvien-15-2512-Co-Hoi-Viec-Lam-Thang-7--2015.html"><img src"<%=ResolveUrl("images/a2.jpg")%>"   /></a>
								<a target="_blank" href="http://hpu.edu.vn/tintuc/HPUHP-1-hpusukhacbiet.html"><img src="<%=ResolveUrl("images/a3.jpg")%>"   /></a>		
								<a target="_blank"  href="http://www.hpu.edu.vn/tintuc/HPUTT-1-2511-Dh-Dan-Lap-Hai-Phong-Ho-Tro-Cho-O-Tai-Khach-San-Sinh-Vien-Cho-Thi-Sinh.html"><img src=<%=ResolveUrl("images/a4.jpg")%>"   /></a>		
								<a target="_blank" href="http://hpu.edu.vn/tintuc/HPUTT-1-2406-De-An-Tuyen-Sinh-Dhcd-Cua-Dh-Dan-Lap-Hai-Phong-Nam-2015.html"><img src=<%=ResolveUrl("images/a5.jpg")%>"   /></a>										
								</div>
								</div>
								<script type="text/javascript">
								$(window).load(function() {
								$('#slider').nivoSlider({
								//	effect: 'random',               // Specify sets like: 'fold,fade,sliceDown'
									//slices: 15,                     // For slice animations
									//boxCols: 8,                     // For box animations
									//boxRows: 4,                     // For box animations
									//animSpeed: 500,                 // Slide transition speed
									//pauseTime: 3000,                // How long each slide will show
									//startSlide: 0,                  // Set starting Slide (0 index)
									//directionNav: true,             // Next & Prev navigation
									controlNav: true,               // 1,2,3... navigation
									//controlNavThumbs: false,        // Use thumbnails for Control Nav
									//pauseOnHover: true,             // Stop animation while hovering
									//manualAdvance: false,           // Force manual transitions
									prevText: '',               // Prev directionNav text
									nextText: '',               // Next directionNav text
									//randomStart: false,             // Start on a random slide
									//beforeChange: function(){},     // Triggers before a slide transition
									//afterChange: function(){},      // Triggers after a slide transition
									//slideshowEnd: function(){},     // Triggers after all slides have been shown
									//lastSlide: function(){},        // Triggers when last slide is shown
									//afterLoad: function(){}         // Triggers when slider has loaded
									});
								
								});
								</script>
                                
                             <!-- end newshot --></div>
                         </td>
                         <td id="cola2">
                            <div id="tiletablecola2">
							<ul class="ttob">
							<li ><a title="Học ngành nào ra làm gì?" target="_blank" href="<%=ResolveUrl("~/InfoNganh.html") %>">Học ngành nào ra làm gì?</a></li>
							<li ><a title="Cơ hội việc làm HPU" target="_blank" href="http://www.hpu.edu.vn/tintuc/HPUCSVCT-cuusinhvien-15-2512-Co-Hoi-Viec-Lam-Thang-7--2015.html" > Cơ hội việc làm HPU</a></li>	
							<li ><a title="HPU sự khác biệt" target="_blank"  href="http://hpu.edu.vn/tintuc/HPUHP-1-hpusukhacbiet.html">HPU sự khác biệt</a></li>	
							<li ><a title="Hỗ trợ chỗ ở cho thí sinh" target="_blank" href="http://www.hpu.edu.vn/tintuc/HPUTT-1-2511-Dh-Dan-Lap-Hai-Phong-Ho-Tro-Cho-O-Tai-Khach-San-Sinh-Vien-Cho-Thi-Sinh.html">Hỗ trợ chỗ ở cho thí sinh</a></li>	
							<li ><a title="Đề án tuyển sinh HPU - 2015" target="_blank" href="http://hpu.edu.vn/tintuc/HPUTT-1-2406-De-An-Tuyen-Sinh-Dhcd-Cua-Dh-Dan-Lap-Hai-Phong-Nam-2015.html">Đề án tuyển sinh HPU - 2015</a></li>	
                                <li ><a title="Mẫu đơn đăng ký xét tuyển 2015" target="_blank" href="<%=ResolveUrl("~/TinBai/files/Mau_don_dang_ky_xet_tuyen_nam_2015.pdf")  %>">Mẫu đơn đăng ký xét tuyển 2015</a></li>	
						   </ul> 
							 <!-- end tiletablecola2 --></div>
                         	<div id="tiletablecola2botton"></div>
						  </td> 
                     </tr>      
				  </table>
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="linetite">TRƯỜNG ĐẠI HỌC DÂN LẬP HẢI PHÒNG NĂM HỌC 2015 TỔ CHỨC TUYỂN SINH THEO 02 HÌNH THỨC XÉT TUYỂN</div>
				
				 <!-- end TuyenSinh--> <div id="TuyenSinh" >
				 
				 <p id="TuyenSinh">THÔNG TIN CHI TIẾT XIN LIÊN HỆ HOTLINE <strong style="color:#FF0000">0989 652 819</strong> hoặc <strong style="color:#FF0000">0313 740 577</strong></p>
				<% if (objHoso != null )
            { %><div  id="printarea">
				 <p id="Dot">THÔNG TIN HỒ SƠ ĐĂNG KÝ XÉT TUYỂN CỦA BẠN</p>
				 <ul id="Dot">
                <li class="Dot">Số CMTND: <strong style="color:Red; font-size:16px;"><%=objHoso.SoCMTND%></strong></li>
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
				 <p id="Dot">CÁC NGÀNH VÀ KHỐI ĐĂNG KÝ XÉT TUYỂN</p>
				  <ul id="Dot">
				  <% for (int i = 0; i < dtNganh.Rows.Count; i++)
         {
             %>
                        <li class="Dot">Tên ngành: <%=dtNganh.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtNganh.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%= Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)%><strong style="color:blue">  : <%if(dtNganh.Rows[i]["TrangThai"].ToString().Equals("0")){%>Đang xét tuyển <%}else{ %>Đã xét tuyển<%} %> </strong></li>
                      
        <% 
         } %>
                </ul>
                <%} %>
                 <% if (dtDiem.Rows.Count > 0)
                    {
                        
                  %>
				 <p id="Dot">ĐIỂM XÉT TUYỂN</p>
				
				  <% 
                        int j = 0, k=0;
                        for (int i = 0; i < dtDiem.Rows.Count; i++)
                        {
                            khoi = dtDiem.Rows[i]["MaKhoi"].ToString().Trim();
                   %>
                <% if(k==0) {%>
                 <table style="width:650px;
	            background:#e4f2fc;
	            vertical-align:text-top;
	            text-align:center;
	            color:#000000;
	            font-family: 'MyriadPro-Regular'; 
	            font-size:13px;"  >
                    <%if(k==0){ %>
                     <tr><td colspan="3" align="left" class="HK"> Khối: <%= khoi.Trim() %> </td></tr>
                     <%} %>
                  <% 
                   }
                   if(j==0){
                    %>
                     <tr> 
                      <%} %>
                    <td align="left"> <%=dtDiem.Rows[i]["TenMon"].ToString().Trim()%>: <b><%=dtDiem.Rows[i]["Diem"].ToString().Trim()%></b></td>
                    <%  
                        j = j + 1; k += 1;
                        if (j == 3)
                         {
                          j = 0;
                    %>
                    </tr>                 
                    <%  
                    } 
                    %>
                        <% 
                     if (i == dtDiem.Rows.Count-1)
                       {%>
                    </table>
                     <%} else{
                       if (!khoi.Equals(dtDiem.Rows[i+1]["MaKhoi"].ToString())){
                           j = 0; k = 0;
                    %>
                     </table>
                     <% }
                       } %>
                    <%
                        }
                    }
                    %>
                </div>
              
       <div style="clear:both; float:right;float:left; width:100%;height:10px;"></div>
             <%}%>
               
              
				 </div>
</asp:Content>


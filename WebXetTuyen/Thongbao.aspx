<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thongbao.aspx.cs" Inherits="_Default" Title="Haiphong Private University" %>

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
    $("#<%=btnIn.ClientID%>").click(function(){
     PrintDoc();
     });
     $("#<%=btnKetThuc.ClientID%>").click(function () {
         openNewWin("<%=ResolveUrl("~/KetThuc.aspx") %>","Thông báo!",520,135);
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
				<% if (Session["objHoSo"] != null && Session["objHoSo"].ToString() != "")
            { %><div  id="printarea">
				 <p id="Dot">THÔNG TIN HỒ SƠ ĐĂNG KÝ XÉT TUYỂN CỦA BẠN</p>
				 <ul id="Dot">
                <li class="Dot">Số CMTND: <strong style="color:Red; font-size:16px;"><%=objHoso.SoCMTND%></strong></li>
                <li class="Dot">Số Báo danh: <strong style="color:Red; font-size:16px;"><%=objHoso.SoBaoDanh%></strong> </li>
                <li class="Dot">Họ tên: <%=objHoso.HoTen%></li>
                <li class="Dot">Ngày sinh: <%=objHoso.NgaySinh.ToString("dd/MM/yyyy")%></li>
                <li class="Dot">Hộ khẩu: <%=objHoso.HoKhau%></li>
                
                <li class="Dot">Dân tộc: <%=objHoso.DanToc%></li>
                <li class="Dot">Điện thoại: <%=objHoso.DienThoai%></li>
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
             if (dtNganh.Rows[i]["Makhoi"].ToString().Length > 3)
             {
                 if (checkNganhXT(dtNganh.Rows[i]["MaNganh"].ToString(), Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)))
                 {
                     %>

                    <li class="Dot">Tên ngành: <%=dtNganh.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtNganh.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%= Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)%><strong style="color:blue"> : Đủ điều kiện xét tuyển!</strong></li>
                    <%
                 }
                 else
                 {
                  %>
                      <li class="Dot">Tên ngành: <%=dtNganh.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtNganh.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%= Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)%><strong style="color:red"> : Không đủ điều kiện xét tuyển!</strong></li>
                    <%
                 }
             }

             else
             {
                    %>
                       <li class="Dot">Tên ngành: <%=dtNganh.Rows[i]["TenNganh"].ToString()%> - Khối: <%=dtNganh.Rows[i]["Makhoi"].ToString()%> - Điểm trung bình: <%= Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)%> </li>
                      
        <% }
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
                <div style="clear:both; float:right;float:left; width:100%"></div>
                <div class="ThongBaoButton">  <asp:Button ID="btnKetThuc" CssClass="BottonTiep" 
                        runat="server" Text="Kết thúc" onclick="btnKetThuc_Click" />   
                    <asp:Button ID="btnIn" CssClass="BottonTiep" runat="server" Text="In phiếu" 
                        onclick="btnIn_Click" /></div>
       
       <div style="clear:both; float:right;float:left; width:100%;height:10px;"></div>
             <%}%>
                <%
                
                if (id == 1)
                  { %>
                   <p id="Dot">ĐÃ HẾT ĐỢT XÉT TUYỂN BẠN HÃY ĐỢI ĐỢT SAU!</p>
                   
                   <ul id="Dot">
                        <% 

                        int idot = 0;
                        // int total = dtDot.Rows.Count;
                        //  Response.Write(total);
                        foreach (System.Data.DataRow drow in dtDot.Rows)
                        {
                        idot = idot + 1;
                        %>
			              <li class="Dot">Đợt <% Response.Write( idot); %>: Từ <% DateTime dt = Convert.ToDateTime(drow["NgayBD"].ToString()); Response.Write(dt.ToString("dd/MM/yyyy")); %> đến <% dt = Convert.ToDateTime(drow["NgayKT"].ToString()); Response.Write(dt.ToString("dd/MM/yyyy")); %></li>
                        				
                        <%} %>
				 </ul>
                  
                <%} %>
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


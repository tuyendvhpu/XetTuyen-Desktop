<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
    <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="linetite">TRƯỜNG ĐẠI HỌC DÂN LẬP HẢI PHÒNG TỔ CHỨC TUYỂN SINH THEO 02 HÌNH THỨC XÉT TUYỂN</div>
				 <!-- bglinetite --> <div id="bglinetite"></div>
            <asp:ImageButton ID="imgTHPT" class="imgTHPT" 
    src="images/xettuyen1.png" ToolTip="Nhấn vào đây để đăng ký" runat="server" onclick="imgTHPT_Click" ImageUrl="~/images/Xettuyen1_active.png"  OnMouseOver="src='images/Xettuyen1_active.png';"
OnMouseOut="src='images/xettuyen1.png';"   />
             <asp:ImageButton  ToolTip="Nhấn vào đây để đăng ký" ID="imgDH" class="imgDH" 
    src="images/xettuyen2.png" runat="server" onclick="imgDH_Click" ImageUrl="~/images/Xettuyen2_active.png"  OnMouseOver="src='images/Xettuyen2_active.png';"
OnMouseOut="src='images/xettuyen2.png';"   />
             <%--<asp:ImageButton ID="imgCapNhat" ToolTip="Nhấn vào đây để tra cứu" class="imgCapNhat" 
        src="images/xettuyen3.png" runat="server" onclick="imgCapNhat_Click" OnMouseOver="src='images/Xettuyen3_active.png';" OnMouseOut="src='images/xettuyen3.png';"   />--%>
				 <!-- end TuyenSinh--> 
    <div id="TuyenSinh" >
	<% 

    int idot = 0;
   // int total = dtDot.Rows.Count;
  //  Response.Write(total);
    foreach (System.Data.DataRow drow in dtDot.Rows)
    {
        idot = idot + 1;
        if (dtDotCurent.Rows.Count > 0)
        {
            if (dtDotCurent.Rows[0]["MaDot"].ToString().Equals(drow["MaDot"].ToString()))
                break;
        }
    }
%>
				 <p id="TuyenSinh">THÔNG TIN CHI TIẾT XIN LIÊN HỆ HOTLINE <strong style="color:#FF0000"> 0901 598 698</strong> hoặc <strong style="color:#FF0000">(0225)3740577</strong></p>
				 <p id="Dot">NHẬN ĐĂNG KÝ XÉT TUYỂN <%if (dtDotCurent.Rows.Count > 0)
                                          { %>- Thời gian còn lại: 
                      <asp:Label ID="lbltime" runat="server" Text=""></asp:Label> của đợt <%=idot%> <%} %></p>
				 <ul id="Dot">
<% 

     idot = 0;
   // int total = dtDot.Rows.Count;
  //  Response.Write(total);
foreach (System.Data.DataRow drow in dtDot.Rows)
{
   idot = idot + 1;
%>
				 <li <% if(dtDotCurent.Rows.Count>0){ if( dtDotCurent.Rows[0]["MaDot"].ToString().Equals(drow["MaDot"].ToString())) {%> class="curent" <%}else{ %><%} }%> >Đợt <% Response.Write( idot); %>: Từ <% DateTime dt = Convert.ToDateTime(drow["NgayBD"].ToString()); Response.Write(dt.ToString("dd/MM/yyyy")); %> đến <% dt = Convert.ToDateTime(drow["NgayKT"].ToString()); Response.Write(dt.ToString("dd/MM/yyyy")); %></li>
					
 <%} %>
				 </ul>
				 <script type="text/javascript">
				     var LHCChatOptions = {};
				     LHCChatOptions.opt = {widget_height:340,widget_width:300,popup_height:520,popup_width:500,domain:'xettuyen.hpu.edu.vn'};
				     (function() {
				         var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
				         var refferer = (document.referrer) ? encodeURIComponent(document.referrer.substr(document.referrer.indexOf('://')+1)) : '';
				         var location  = (document.location) ? encodeURIComponent(window.location.href.substring(window.location.protocol.length)) : '';
				         po.src = '//hotro.hpu.edu.vn/index.php/chat/getstatus/(click)/internal/(position)/bottom_right/(ma)/br/(top)/350/(units)/pixels/(leaveamessage)/true/(department)/6?r='+refferer+'&l='+location;
				         var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
				     })();
				</script>
				 </div>

				 <script type="text/javascript">
				      var leave = <%=seconds%>;
				      CounterTimer();
				      var interv = setInterval(CounterTimer, 1000);
				      function CounterTimer() {
				          var day = Math.floor(leave / (60 * 60 * 24))
				          var hour = Math.floor(leave / 3600) - (day * 24)
				          var minute = Math.floor(leave / 60) - (day * 24 * 60) - (hour * 60)
				          var second = Math.floor(leave) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60)
				          hour = hour < 10 ? "0" + hour : hour;
				          minute = minute < 10 ? "0" + minute : minute;
				          second = second < 10 ? "0" + second : second;
				          var remain = day + " ngày   " + hour + ":" + minute + ":" + second;
				          leave = leave - 1;

				        document.getElementById('<%=lbltime.ClientID%>').innerHTML = remain;
				      }
   
    </script>
</asp:Content>


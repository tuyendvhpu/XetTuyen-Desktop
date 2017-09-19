<%@ Page Language="C#" MasterPageFile="~/MasterHoSo.master" AutoEventWireup="true" CodeFile="Step2DH.aspx.cs" Inherits="Step2DH" Title="Haiphong Private University" %>
<%@ Register TagName="Captcha" TagPrefix="Controls" Src="NumCaptcha.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
<!--  contentHoSo --><div id="contentHoSo">
				<div id="HoSoTile">ĐĂNG KÝ THÔNG TIN XÉT TUYỂN VÀO ĐẠI HỌC - CAO ĐẲNG</div>
				<div id="HoSoHinhThuc">
				Hình thức xét tuyển theo <br/>
				KẾT QUẢ THI ĐẠI HỌC
				</div>
				<div id="setpHS">
							
								<div id="numHSfist">
									<ul id="stepnumHS">
									<li><a  title="Haiphong Private University" href="#" class="stepnumchoiceHSac">1</a></li>
									</ul>
								
							</div>
							<div id="lineHSac"></div>
							
								<div id="numHS">
									<ul id="stepnumHS">
									<li><a  title="Haiphong Private University" href="#" class="stepnumchoiceHSac">2</a></li>
									</ul>
								</div>
							
							<div id="lineHSac"></div>
							
								<div id="numHS">
									<ul id="stepnumHS">
									<li ><a  title="Haiphong Private University" href="#" class="stepnumchoiceHSac">3</a></li>
									</ul>
								</div>
	
					</div>
						<ul id="setpHStext">
								<li class="fistHS"><a  title="Haiphong Private University" class="acHS" href="#" >Xác minh thông tin</a></li>
								<li><a  title="Haiphong Private University" class="acHS"  href="#" >Chọn ngành đào tạo</a></li>
								<li class="endHS"><a  title="Haiphong Private University" class="acHS"  href="#">Nhập điểm xét tuyển</a></li>
						</ul>
				<!-- ThongTinHS --><div id="ThongTinHS">
					<table id="tabbbleDiem">
						<tr><td id="tieude" colspan="3">Thí sinh nhập điểm thi Đại học vào các ô điểm tương ứng</td></tr>
						<tr><td id="diem" ><asp:PlaceHolder ID="holder" runat="server" /></td></tr>
					</table>
					<div id="ThongTinHSContent">
						<div id="HoSoCenter">
						<div style="clear:both; height:5px;"></div>
					<div id="group">
					<div class="line" style="width:660px"></div>
					</div>
					<div style="clear:both; height:5px;"></div>
					<table border="0" id="mapop"><tr><td style="width:130px;">Nhập mã xác nhận &nbsp</td><td style="width:400px;"><Controls:Captcha ID="captcha"   CalcMode="1" runat="server"  message="Câu trả lời không đúng" /></td></tr></table>
                    <div style="clear:both; height:5px;"></table>
					<p id="perror"  runat="server" class="error">ads</p>
<div id="bottonTiep"><asp:Button ID="btnNop" CssClass="BottonTiep"  runat="server" 
        Text="Nộp hồ sơ" onclick="btnNop_Click" /></div>		
</div>		
					</div>
			<!-- end ThongTinHS -->	</div>
				<!-- end contentHoSo --> </div>
    </div>
</asp:Content>


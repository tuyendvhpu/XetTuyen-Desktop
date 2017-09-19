<%@ Page Language="C#" MasterPageFile="~/MasterHoSo.master" AutoEventWireup="true" CodeFile="Step2THPT.aspx.cs" Inherits="Step2THPT" Title="Haiphong Private University" %>
<%@ Register TagName="Captcha" TagPrefix="Controls" Src="NumCaptcha.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
    <!--  contentHoSo --><div id="contentHoSo">
				<div id="HoSoTile">ĐĂNG KÝ THÔNG TIN XÉT TUYỂN VÀO ĐẠI HỌC - CAO ĐẲNG</div>
				<div id="HoSoHinhThuc">
				Hình thức xét tuyển theo <br/>
				KẾT QUẢ THPT
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
				<div id="TiteTHPTDiem">(Nhập điểm từng môn theo học kỳ) 
					</div>
					<div style="width:680px; float:left; position:relative; clear:both; text-align:center;"><center><asp:PlaceHolder   ID="holder" runat="server" /></center></div>
					<div id="ThongTinHSContent">
						<div id="HoSoCenter">
							
						<div style="clear:both; height:5px;"></div>
					<div id="group">
					
					</div>
					<div style="clear:both; height:5px;"></div>
					<table border="0" id="mapop"><tr><td style="width:130px;">Nhập mã xác nhận &nbsp</td><td style="width:400px;"><Controls:Captcha ID="captcha"   CalcMode="1" runat="server"  message="Câu trả lời không đúng" /></td></tr></table>
                    <div style="clear:both; height:5px;"></table>
					<p id="perror"  runat="server" class="error">ads</p>
<div id="bottonTiepDiem"><asp:Button ID="btnNop" CssClass="BottonTiep"  runat="server" 
        Text="Nộp hồ sơ" onclick="btnNop_Click" /></div>		
</div>		
					</div>
			<!-- end ThongTinHS -->	</div>
				<!-- end contentHoSo --> </div>
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


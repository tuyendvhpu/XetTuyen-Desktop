<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Huongdan.aspx.cs" Inherits="Huongdan" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
 <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				<div id="cacbuoc">Hướng dẫn tra cứu thông tin tuyển sinh</div>
				
				 <div id="cacbuocnoidung">
				
				<%if (dtTinh.Rows.Count > 0)
                    { %>
				 <div id="group">
						<div class="item line1"></div>
						<div class="item textlineNganh">Danh mục Mã trường THPT, Mã trường nghề và tương đương</div>
						<div class="item line"></div>
		
				</div>
				    <div style="clear:both;float:left; position:relative; width:100%;">
				    <table style="width:100%;text-align:left;vertical-align:text-top; ">
				      <tr>
				    <%
                        int j = 0;
                        int a = (int)(dtTinh.Rows.Count / 4);
                        for (int i = 0; i < dtTinh.Rows.Count;i++)
                        {
                          
                                    if (j == a) j = 0;
                          if (j == 0)
                                {
                            %>
				                     <td style="text-align:left;vertical-align:text-top; padding:10px 10px;font-size:15;">
				              <% } %>
				         <%= dtTinh.Rows[i]["MaTinh"].ToString() + "&nbsp &nbsp  <a  href="+ ResolveUrl("Truongpt/"+ dtTinh.Rows[i]["MaTinh"].ToString()+".html") +">" + dtTinh.Rows[i]["Tentinh"].ToString() + "</a><br>"%>
				        <%
                            j = j + 1;
                                   
                                    if (j == a)
                                    {
                            %>
				         </td> 
				       <% }
                            }%>
				       </tr>
				    </table>
				    </div>
				    <%} %>
				    <div style="clear:both;float:left; position:relative; width:100%; min-height:100px;">
				     <div id="group" style="clear:both;">
						<div class="item line1"></div>
						<div class="item textlineNganh">Tra cứu thông tin các huyện</div>
						<div class="item line"></div>
		
				    </div>
				    <div style="clear:both;float:left; position:relative; width:100%;height:30px; text-align:left; padding:10px 10px;"> Nhập mã tỉnh &nbsp
                        <asp:TextBox ID="txtMaTinh" Text="03" runat="server"></asp:TextBox> 
                        <asp:Button ID="btnTim" runat="server" CssClass="BottonTiep" Text="Tra cứu" onclick="btnTim_Click" /> (Mã tỉnh  &nbsp &nbsp Mã huyện &nbsp &nbsp Tên Quận Huyện)</div>
                        <%if (dtHuyen.Rows.Count > 0)
                              
                          { %>
                          <table style="width:100%;text-align:left;vertical-align:text-top; ">
				      <tr>
				    <%
                        int j = 0;
                        int a =  (int) (dtHuyen.Rows.Count / 4);
                       // Response.Write(a);
                        for (int i = 0; i < dtHuyen.Rows.Count; i++)
                        {

                            if (j == a) j = 0;
                          if (j == 0)
                                {
                            %>
				                     <td style="text-align:left;vertical-align:text-top; padding:10px 10px;font-size:15;">
				              <% } %>
				         <%= dtHuyen.Rows[i]["MaTinh"].ToString() + " &nbsp &nbsp " + dtHuyen.Rows[i]["MaHuyen"].ToString() + "&nbsp &nbsp " + dtHuyen.Rows[i]["TenHuyen"].ToString() + "<br>"%>
				        <%
                            j = j + 1;

                            if (j == a)
                                    {
                            %>
				         </td> 
				       <% }
                            }%>
				       </tr>
				    </table>
                          
                    <%} %>
				    </div>
				    </div>
				    
				
				 <div id="bottonTiep" style="height:90px;"></div>
</asp:Content>


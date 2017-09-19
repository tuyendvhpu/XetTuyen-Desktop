<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TruongPT.aspx.cs" Inherits="TruongPT" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
<div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				<div id="cacbuoc">Danh mục Mã trường THPT, Mã trường nghề và tương đương</div>
				
				 <div id="cacbuocnoidung">
			
				    <div style="clear:both;float:left; position:relative; width:100%; padding:10px 10px;">
                        <asp:GridView ID="grvTruongpt" runat="server" AutoGenerateColumns="False" 
                            Width="965px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#E3EAEB" />
                            <Columns>
                                <asp:BoundField DataField="MaTinh" HeaderText="Mã tỉnh" >
                                </asp:BoundField>
                                <asp:BoundField DataField="MaTruong" HeaderText="Mã trường" >
                                </asp:BoundField>
                                <asp:BoundField DataField="TenTruong" HeaderText="Tên trường" >
                                <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="MaKV" HeaderText="Khu vực" />
                            </Columns>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
				 </div>
				 </div>
				 <div id="bottonTiep" style="height:90px;"></div>
</asp:Content>


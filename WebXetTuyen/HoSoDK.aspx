<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HoSoDK.aspx.cs" Inherits="HoSoDK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
     <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="linetite">CẬP NHẬT DANH SÁCH HỒ SƠ ĐĂNG KÝ XÉT TUYỂN NĂM 2015</div>
				 <div id="HoSoDk" >
                     <table cellpadding="0" cellspacing="0" border="0" width="1000px">
<tr><td  align="center" valign="top"  style="padding-left: 0px;
               padding-bottom: 5px; padding-top: 5px; font-size:16px; color:blueviolet;">Tổng số hồ sơ: <%=TongSo %></td>
            <td align="center" valign="top"  style="padding-left: 0px;
               padding-bottom: 5px; padding-top: 5px;"> 
                Họ tên
               <asp:TextBox ID="txtHoTen" runat="server" Width="101px"></asp:TextBox> 
                Số CMTND <asp:TextBox ID="txtSoCMTD" runat="server" Width="101px"></asp:TextBox> Địa chỉ:
                <asp:TextBox ID="txtLop12" runat="server" Width="107px"></asp:TextBox> 

                <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" onclick="btnTim_Click" /> 
                
            </td></tr></table>
                     <asp:GridView ID="dgvDK" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" OnPageIndexChanging="dgvDK_PageIndexChanging" OnSelectedIndexChanging="dgvDK_SelectedIndexChanging" PageSize="50" GridLines="Vertical" OnDataBinding="dgvDK_DataBinding" OnRowDataBound="dgvDK_RowDataBound">
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                         <Columns>
                               <asp:HyperLinkField AccessibleHeaderText="HoTen" DataNavigateUrlFields="IDHS" DataNavigateUrlFormatString="ChiTiet/{0}.html" DataTextField="Hoten" HeaderText="Họ tên" Target="_blank">
                               <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                               <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" />
                               </asp:HyperLinkField>
            <asp:BoundField AccessibleHeaderText="NgaySinh" DataField="NgaySinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày sinh" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="90px" />
            </asp:BoundField>
            <asp:BoundField AccessibleHeaderText="SoCMTND" DataField="SoCMTND" HeaderText="Số CMTND" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px" />
            </asp:BoundField>
                               <asp:TemplateField AccessibleHeaderText="dot" HeaderText="Đợt/Ngày trả KQ">

                                   <ItemTemplate>
                                       <asp:Label ID="lblDot" runat="server" ></asp:Label>
                                   </ItemTemplate>
                                  
                                   <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="90px" />
                                  
                               </asp:TemplateField>
                               <asp:TemplateField AccessibleHeaderText="HinhThuc" HeaderText="Hệ xét tuyển">
                                   <ItemTemplate>
                                       <asp:Label ID="lblHinhThuc" runat="server"></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="90px" />
                               </asp:TemplateField>
                               <asp:TemplateField AccessibleHeaderText="nganhdk" HeaderText="Ngành đăng ký">
                                   <ItemTemplate>
                                       <asp:Label ID="lblNganh" runat="server"></asp:Label>
                                   </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" />
                               </asp:TemplateField>
                               <asp:TemplateField AccessibleHeaderText="NgayDK" HeaderText="Ngày đăng ký">
                                   <ItemTemplate>
                                       <asp:Label ID="lblNgayDK" runat="server"></asp:Label>
                                   </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px" />
                               </asp:TemplateField>
                               <asp:TemplateField AccessibleHeaderText="TrangThai" HeaderText="Trạng thái">
                                   <ItemTemplate>
                                       <asp:Label ID="lblTrangThai" runat="server"></asp:Label>
                                   </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                               </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="DiaChi" DataField="DiaChi" HeaderText="Địa chỉ">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Width="490px" HorizontalAlign="Left" VerticalAlign="Top" />
            </asp:BoundField>
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                         <PagerSettings Mode="NumericFirstLast" NextPageText="&amp;gt; " />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                        
                         <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
                         <SelectedRowStyle BackColor="#003399" Font-Bold="True" ForeColor="White" />
                     </asp:GridView>
				 </div>
        
 </asp:Content>


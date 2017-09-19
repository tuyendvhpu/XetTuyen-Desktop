<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_HoSoTraCuu.aspx.cs" Inherits="Admin_HoSoTraCuu" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
<div  style="z-index:10; float:left; position:relative;">
<table cellpadding="0" cellspacing="0" border="0" width="1000px">
<tr>
            <td align="center" valign="top"  style="padding-left: 0px;
                padding-bottom: 5px; padding-top: 5px;">
                Đợt xét tuyển 
                <asp:DropDownList ID="drlDotXetTuyen" runat="server">
                </asp:DropDownList>
                Số CMTND <asp:TextBox ID="txtSoCMTD" runat="server" Width="101px"></asp:TextBox>  Số báo danh 
                <asp:TextBox ID="txtSoBaoDanh" runat="server" Width="107px"></asp:TextBox> 
               Số điện thoại <asp:TextBox ID="txtDienThoai" runat="server" Width="113px"></asp:TextBox> 

                <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" onclick="btnTim_Click" /> 
                <asp:Button ID="btnExcel" runat="server" onclick="btnExcel_Click" Text="Excell" 
                    Width="68px" />
            </td></tr>
<tr>
            <td align="center" valign="top"  style="padding-left: 0px;
                padding-bottom: 5px; padding-top: 5px;">
    <asp:GridView ID="grvHoSo" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" AllowPaging="True" AllowSorting="True" 
                    onpageindexchanging="grvHoSo_PageIndexChanging">
        <PagerSettings Mode="NumericFirstLast" />
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:BoundField DataField="SoCMTND" HeaderText="Số CMTND" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="SoBaoDanh" HeaderText="Só báo danh" >
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTen" HeaderText="Họ tên" >
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="NgaySinh" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="Ngày sinh" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="HeXetTuyen" HeaderText="Hệ XT" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayNhap" HeaderText="Ngày ĐK" 
                DataFormatString="{0:dd/MM/yyyy}" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="TenNganh" HeaderText="Tên ngành" >
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="MaKhoi" HeaderText="Khối" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="UTKV" HeaderText="UTKV" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="UTDT" HeaderText="ĐTUT" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="DiemTB" HeaderText="Điểm TB" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Buoc" HeaderText="Bước">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
       </td>
        </tr></table>
        </div>
</asp:Content>

    
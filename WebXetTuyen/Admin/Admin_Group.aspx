<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Admin_Group.aspx.cs" Inherits="Admin_Album" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenHead" Runat="Server">
QUẢN TRỊ THÔNG TIN NHÓM NGƯỜI DÙNG
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentEdit" Runat="Server">
<table cellpadding="0" cellspacing="0" border="0" width="725">
        <tr>
            <td class="text13b" align="center" valign="top"  style="padding-left: 5px;
                padding-bottom: 5px; padding-top: 5px;">
               </td>
        </tr>
          <tr>
            <td class="text13b" align="right" valign="top"  style="padding-right: 5px;
                padding-bottom: 5px; padding-top: 5px;">
                <asp:Label ID="lblThongbao" runat="server" Text=""></asp:Label>
               </td>
        </tr>
      <tr>
            <td class="text13b" align="left" valign="top"  style="
                padding-bottom: 5px; padding-top: 5px;">
                <asp:GridView ID="gvTinTuc" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="725px" PageSize="15" OnPageIndexChanging="gvTinTuc_PageIndexChanging" >
                    <Columns>
                        <asp:BoundField DataField="GroupName" HeaderText="Tên nhóm">
                            <ControlStyle Font-Bold="True" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="600px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Thao tác"  >
                            <ItemTemplate>
                                <a href="<%#ResolveUrl("~/Admin/GroupEdit/"+DataBinder.Eval(Container.DataItem, "GroupID")+".html") %>" target="_self">Edit</a>|<a href="<%#ResolveUrl("~/Admin/Del/Group/"+DataBinder.Eval(Container.DataItem, "GroupID")+".html") %>" target="_self" >Delete</a>
                            </ItemTemplate>
                            <ControlStyle Font-Bold="True" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BorderColor="White" BorderStyle="Inset" Wrap="False" />
                </asp:GridView>
                
               </td>
        </tr>
   <tr>
            <td class="text13b" align="right" valign="top"  style="padding-right: 5px;
                padding-bottom: 5px; padding-top: 5px;">
                 <a href="<%=ResolveUrl("~/Admin/GroupAdd.html") %>"  target="_self">AddNews</a>
               </td>
        </tr>
    </table>
</asp:Content>


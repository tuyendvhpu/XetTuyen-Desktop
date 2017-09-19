<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoCMTND.aspx.cs" Inherits="SoCMTND" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var regex = new RegExp("^[0-9]+$");
    $(document).ready(function () {
                    
                     $("#<%=btnCheck.ClientID%>").click(function(e) {
              // alert("keypress"); return false;
                var str = $("#<%=txtSoCMTND.ClientID%>").val();
                if (regex.test(str)) {  
                
                    if(str.length<=8)
                    {
                    alert("Độ dài chứng minh thư phải lớn hơn 8!");
                        $("#<%=txtSoCMTND.ClientID%>").focus();
                         return false;
                    }
                     return true;
              
                }
                else{
                    alert("Bạn phải nhập số cho số chứng minh thư!");
                    $("#<%=txtSoCMTND.ClientID%>").focus();
                     return false;
                    
                }
            });
                    
               
   });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
     <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- SoCMTNTite --> <div id="SoCMTNDTile">Mời bạn nhập số Chứng minh thư:</div>
				 <!-- SoCMTND --> <div id="SoCMTND">
                     <asp:TextBox ID="txtSoCMTND"   placeholder="Số chứng minh thư" Text=""  
                         MaxLength="12"  CssClass="SoCMTNDtxt" 
                         runat="server"></asp:TextBox>
                        <p style="text-align:center;"><asp:RequiredFieldValidator ID="rqvSoCMTND" runat="server" 
                        ErrorMessage="Xin nhập số chứng minh thư nhân dân!" ControlToValidate="txtSoCMTND" Display="Dynamic"></asp:RequiredFieldValidator></p>
                     <asp:Button ID="btnCheck" Text="Kiểm tra" CssClass="SoCMTNDBotton" 
                         runat="server" onclick="btnCheck_Click" />   
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


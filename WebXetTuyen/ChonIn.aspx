<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonIn.aspx.cs" Inherits="KetThuc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thông báo</title>
    <style type="text/css">
        .auto-style1
        {
            width: 500px;
            float: left;
            border-color: #fff;
            background-color: #055e7f;
            color:white;
            
        }
    </style>
</head>
<body>
    <form id="frmThongBao" runat="server">
    <div>
   
        <table align="center" class="auto-style1">
            <tr>
                <td>Chúc mừng bạn đã đăng ký chọn in thành công.

</td>
            </tr>
            <tr>
                <td>Bạn đã chọn: <%=Session["snganh"].ToString() %>   </td>
            </tr>
             <tr>
                <td>Mọi thông tin thắc mắc xin vui lòng liên hệ: <br />
Hotline: 0901 598 698 <br />
Email:dangkyxettuyen@hpu.edu.vn   </td>
            </tr>
        </table>
   
    </div>
    </form>
</body>
</html>

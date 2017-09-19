<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonNganh.aspx.cs" Inherits="ChongNganh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Style-Type" content="text/css" />
<meta http-equiv="Content-Script-Type" content="text/javascript" />
<title>Haiphong Private University</title>
<link rel="icon" type="text/css" href="images/common/img_logo.png" />
<meta name="description" content="" />
<meta name="keywords" content="" />

<style type="text/css">
@font-face {
	font-family: 'UTM Alter Gothic';
	src: url('css/font/UTM%20Alter%20Gothic.ttf');
	
}

@font-face {
	font-family: 'UTM Aquarelle';
	src: url('css/font/UTM%20Aquarelle.ttf');
	
}

</style>
	<!--[if lt IE 7]>
		<style type="text/css">
			#wrapper { height:100%; }
		</style>
	<![endif]-->

<link rel="contents" href="/" title="Home" />
<!--[if lte IE 7]><script language="JavaScript" type="text/javascript" src="js/fix_png02.js" defer="defer"></script><![endif]-->
<!-- sideshow newshot-->
 <link href="<%=ResolveUrl("css/CaNhan.css")%>" media="screen" rel="stylesheet" type="text/css" />
 <link href="<%=ResolveUrl("css/calendar-blue.css")%>" media="screen" rel="stylesheet" type="text/css" />
 <link href="<%=ResolveUrl("css/nivo-slider.css")%>" media="screen" rel="stylesheet" type="text/css" />
<script src="<%=ResolveUrl("js/jquery-1.10.1.min.js")%>" type="text/javascript"></script>
<script src="<%=ResolveUrl("js/jquery.nivo.slider.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function(){
        
       

            $("#<%=btnTiep.ClientID %>").click(function() {
                var f = true;
                var smsg=""
                var sNganh="";
                var sKhoi="";
                var sNganhTong="";
                
                //Begin Validate he dai hoc
                if((<%=hexettuyen%>==2)||(<%=hexettuyen%>==1)) { 
            // Cong nghe
            sNganh="";
            sKhoi="";
            $('#<%=cblNganhCNTT.ClientID%> input[type=checkbox]:checked').each(function() {
                    sNganh = sNganh + " " + $(this).next().text();
                    sNganhTong = sNganhTong + " " + $(this).next().text();
                });
                $('#<%=cblCNTT.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành công nhệ thông tin! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối công nhệ thông tin! \n";
                alert(smsg);
                return false;
            }
            //Dien
            sNganh="";
            sKhoi="";
            $('#<%=cblNganhDien.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblDien.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành điện - điện tử! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối điện - điện tử! \n";
                alert(smsg);
                return false;
            }
            
            //Van hoa
            sNganh="";
            sKhoi="";
            $('#<%=cblNganhVH.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblVH.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành văn hóa du lịch! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối văn hóa du lịch! \n";
                alert(smsg);
                return false;
            }
            
            //Xay Dung
            sNganh="";
            sKhoi="";
            $('#<%=cblNganhXD.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblXD.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành kỹ thuật công trình xây dựng! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối kỹ thuật công trình xây dựng! \n";
                alert(smsg);
                return false;
            }
            
            
            //MoiTruong
            sNganh="";
            sKhoi="";
            
            $('#<%=cblNganhMT.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblMT.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành kỹ thuật công trình môi trường! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối kỹ thuật công trình môi trường! \n";
                alert(smsg);
                return false;
            }
            
            //Ngoai Ngu
            sNganh="";
            sKhoi="";
            
            $('#<%=cblNganhNN.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblNN.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành ngôn ngữ anh! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối ngôn ngữ anh! \n";
                alert(smsg);
                return false;
            
           
            }
            
            
            //Quan Tri
            sNganh="";
            sKhoi="";
            
            $('#<%=cblNganhQT.ClientID%> input[type=checkbox]:checked').each(function() {
                     sNganh = sNganh + " " + $(this).next().text();
                     sNganhTong = sNganhTong + " " + $(this).next().text();
                 });
                 $('#<%=cblQT.ClientID%> input[type=checkbox]:checked').each(function() {
                sKhoi = sKhoi + " " + $(this).next().text();
            });

            if( (sNganh!="") && (sKhoi=="")){
                smsg = smsg + "Bạn phải chọn khối cho ngành quản trị kinh doanh! \n";
                alert(smsg);
                return false;
            }
            
            if( (sNganh=="") && (sKhoi!="")){
                smsg = smsg + "Bạn phải chọn ngành cho khối quản trị kinh doanh! \n";
                alert(smsg);
                return false;
            }

                    //Nong Nghiep
            sNganh="";
            sKhoi="";
            
            $('#<%=cblNganhNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
                sNganh = sNganh + " " + $(this).next().text();
                sNganhTong = sNganhTong + " " + $(this).next().text();
            });
            $('#<%=cblNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
                        sKhoi = sKhoi + " " + $(this).next().text();
                    });

                    if( (sNganh!="") && (sKhoi=="")){
                        smsg = smsg + "Bạn phải chọn khối cho ngành nông nghiệp! \n";
                        alert(smsg);
                        return false;
                    }
            
                    if( (sNganh=="") && (sKhoi!="")){
                        smsg = smsg + "Bạn phải chọn ngành cho khối nông nghiệp! \n";
                        alert(smsg);
                        return false;
                    }
        }//End validateHe dai hoc
         
                //Begin validate he cao dang
                if((<%=hexettuyen%>==2)||(<%=hexettuyen%>==0)) { 
        
        
                    // Cong nghe
                    sNganh="";
                    sKhoi="";
                    $('#<%=cblNganhCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sNganh = sNganh + " " + $(this).next().text();
                    sNganhTong = sNganhTong + " " + $(this).next().text();
                });
                $('#<%=cblCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sKhoi = sKhoi + " " + $(this).next().text();
                });

                if( (sNganh!="") && (sKhoi=="")){
                    smsg = smsg + "Bạn phải chọn khối cho ngành công nhệ thông tin hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                if( (sNganh=="") && (sKhoi!="")){
                    smsg = smsg + "Bạn phải chọn ngành cho khối công nhệ thông tin hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                //Dien
                sNganh="";
                sKhoi="";
                $('#<%=cblNganhDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                sNganh = sNganh + " " + $(this).next().text();
                sNganhTong = sNganhTong + " " + $(this).next().text();
            });
            $('#<%=cblDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sKhoi = sKhoi + " " + $(this).next().text();
                });

                if( (sNganh!="") && (sKhoi=="")){
                    smsg = smsg + "Bạn phải chọn khối cho ngành điện - điện tử hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                if( (sNganh=="") && (sKhoi!="")){
                    smsg = smsg + "Bạn phải chọn ngành cho khối điện - điện tử hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
            
                //Van hoa
                sNganh="";
                sKhoi="";
                $('#<%=cblNganhVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                sNganh = sNganh + " " + $(this).next().text();
                sNganhTong = sNganhTong + " " + $(this).next().text();
            });
            $('#<%=cblVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sKhoi = sKhoi + " " + $(this).next().text();
                });

                if( (sNganh!="") && (sKhoi=="")){
                    smsg = smsg + "Bạn phải chọn khối cho ngành văn hóa du lịch hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                if( (sNganh=="") && (sKhoi!="")){
                    smsg = smsg + "Bạn phải chọn ngành cho khối văn hóa du lịch hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                //Xay Dung
                sNganh="";
                sKhoi="";
                $('#<%=cblNganhXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                sNganh = sNganh + " " + $(this).next().text();
                sNganhTong = sNganhTong + " " + $(this).next().text();
            });
            $('#<%=cblXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sKhoi = sKhoi + " " + $(this).next().text();
                });

                if( (sNganh!="") && (sKhoi=="")){
                    smsg = smsg + "Bạn phải chọn khối cho ngành kỹ thuật công trình xây dựng hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                if( (sNganh=="") && (sKhoi!="")){
                    smsg = smsg + "Bạn phải chọn ngành cho khối kỹ thuật công trình xây dựng hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
                //Quan Tri
                sNganh="";
                sKhoi="";
            
                $('#<%=cblNganhQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                sNganh = sNganh + " " + $(this).next().text();
                sNganhTong = sNganhTong + " " + $(this).next().text();
            });
            $('#<%=cblQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                    sKhoi = sKhoi + " " + $(this).next().text();
                });

                if( (sNganh!="") && (sKhoi=="")){
                    smsg = smsg + "Bạn phải chọn khối cho ngành quản trị kinh doanh hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
                if( (sNganh=="") && (sKhoi!="")){
                    smsg = smsg + "Bạn phải chọn ngành cho khối quản trị kinh doanh hệ cao đẳng! \n";
                    alert(smsg);
                    return false;
                }
            
            }//End Validate cao dang
         
         
                if(sNganhTong=="")
                {
                    smsg = smsg + "Bạn phải chọn một ngành để xét tuyển! \n";
                    alert(smsg);
                    return false;
                }
        
                return f;
      
            });

            //begin DaiHOc  
            if((<%=hexettuyen%>==2)||(<%=hexettuyen%>==1)) { 
                //Xu ly su  kiên CNTT
        
                $("#<%=imgCongNgheTT.ClientID%>").click(function(){
          
            var str = "";
            $('#<%=cblNganhCNTT.ClientID%> input[type=checkbox]:checked').each(function() {
                   str = str + " " + $(this).next().text();
               });
               if(str!="" & !$("#<%=pnNganhCNTT.ClientID%>").is(":hidden")) {
         
                return false;
            }
           
        $("#<%=pnNganhCNTT.ClientID%>").toggle();
           $("#<%=pnKhoiCNTT.ClientID%>").toggle();
           
        if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")){
          
            $("#<%=pnIconCNTT.ClientID%>").height($("#<%=pnNganhCNTT.ClientID%>").height() - $("#<%=pnNganhCNTT.ClientID%>").height());
               $("#<%=pnatitleCNTT.ClientID%>").width($("#<%=pnatitleCNTT.ClientID%>").width() + $("#<%=pnKhoiCNTT.ClientID%>").width());
               $("#<%=pnatitleCNTT.ClientID%>").css({"color":"#ffffff"});
            
           }else{
               $("#<%=pnIconCNTT.ClientID%>").height($("#<%=pnatitleCNTT.ClientID%>").height()+ $("#<%=pnNganhCNTT.ClientID%>").height() +22);
               $("#<%=pnatitleCNTT.ClientID%>").width($("#<%=pnatitleCNTT.ClientID%>").width() - $("#<%=pnKhoiCNTT.ClientID%>").width());
               $("#<%=pnatitleCNTT.ClientID%>").css({"color":"#e1e31a"});
             
               //tat cac nganh
               if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
               if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
               if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
               if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
               if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
               //end tat cac nganh
                  
              
           }
       });
          
            $("#<%=pnatitleCNTT.ClientID%>").click(function(){
         
         var str = "";
         $('#<%=cblNganhCNTT.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhCNTT.ClientID%>").is(":hidden")){
            return false;
        }
        
        str = "";
        $('#<%=cblCNTT.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhCNTT.ClientID%>").is(":hidden")){
            return false;
        }  
        
        $("#<%=pnNganhCNTT.ClientID%>").toggle();
        $("#<%=pnKhoiCNTT.ClientID%>").toggle();
        if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")){
            $("#<%=pnIconCNTT.ClientID%>").height($("#<%=pnNganhCNTT.ClientID%>").height() - $("#<%=pnNganhCNTT.ClientID%>").height());
                 $("#<%=pnatitleCNTT.ClientID%>").width($("#<%=pnatitleCNTT.ClientID%>").width() + $("#<%=pnKhoiCNTT.ClientID%>").width());
                 $("#<%=pnatitleCNTT.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconCNTT.ClientID%>").height($("#<%=pnatitleCNTT.ClientID%>").height()+ $("#<%=pnNganhCNTT.ClientID%>").height() +22);
                 $("#<%=pnatitleCNTT.ClientID%>").width($("#<%=pnatitleCNTT.ClientID%>").width() - $("#<%=pnKhoiCNTT.ClientID%>").width());
                 $("#<%=pnatitleCNTT.ClientID%>").css({"color":"#e1e31a"});
               
               
                 //tat cac nganh
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
                  
             }
    });
          
          
          
          
            //Xu ly su  kiên Dien
            $("#<%=imgDien.ClientID%>").click(function(){
          
                var str = "";
                $('#<%=cblNganhDien.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhDien.ClientID%>").is(":hidden")){
            return false;
        }
        
        str = "";
        $('#<%=cblDien.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhDien.ClientID%>").is(":hidden")){
            return false;
        }
        
        $("#<%=pnNganhDien.ClientID%>").toggle();
        $("#<%=pnKhoiDien.ClientID%>").toggle();
           
        if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")){
            $("#<%=pnIconDien.ClientID%>").height($("#<%=pnNganhDien.ClientID%>").height() - $("#<%=pnNganhDien.ClientID%>").height());
                  $("#<%=pnatitleDien.ClientID%>").width($("#<%=pnatitleDien.ClientID%>").width() + $("#<%=pnKhoiDien.ClientID%>").width());
                  $("#<%=pnatitleDien.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconDien.ClientID%>").height($("#<%=pnatitleDien.ClientID%>").height()+ $("#<%=pnNganhDien.ClientID%>").height() +22);
                  $("#<%=pnatitleDien.ClientID%>").width($("#<%=pnatitleDien.ClientID%>").width() - $("#<%=pnKhoiDien.ClientID%>").width());
                  $("#<%=pnatitleDien.ClientID%>").css({"color":"#e1e31a"});
             
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                  if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                  if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                  if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                  //end tat cac nganh
                  
              }
    });
          
            $("#<%=pnatitleDien.ClientID%>").click(function(){
         
                var str = "";
                $('#<%=cblNganhDien.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhDien.ClientID%>").is(":hidden")  ){
            return false;
        }
        
        str = "";
        $('#<%=cblDien.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhDien.ClientID%>").is(":hidden") ){
            return false;
        }
        
        $("#<%=pnNganhDien.ClientID%>").toggle();
        $("#<%=pnKhoiDien.ClientID%>").toggle();
        if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")){
            $("#<%=pnIconDien.ClientID%>").height($("#<%=pnNganhDien.ClientID%>").height() - $("#<%=pnNganhDien.ClientID%>").height());
                 $("#<%=pnatitleDien.ClientID%>").width($("#<%=pnatitleDien.ClientID%>").width() + $("#<%=pnKhoiDien.ClientID%>").width());
                 $("#<%=pnatitleDien.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconDien.ClientID%>").height($("#<%=pnatitleDien.ClientID%>").height()+ $("#<%=pnNganhDien.ClientID%>").height() +22);
                 $("#<%=pnatitleDien.ClientID%>").width($("#<%=pnatitleDien.ClientID%>").width() - $("#<%=pnKhoiDien.ClientID%>").width());
                 $("#<%=pnatitleDien.ClientID%>").css({"color":"#e1e31a"});
               
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
             }
    });
          
          
          
            //Xu ly su  kiên Van hoa
            $("#<%=imgVH.ClientID%>").click(function(){
          
                var str = "";
                $('#<%=cblNganhVH.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            return false;
        }
        
        str = "";
        $('#<%=cblVH.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!=""  & !$("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            return false;
        }
          
        $("#<%=pnNganhVH.ClientID%>").toggle();
        $("#<%=pnKhoiVH.ClientID%>").toggle();
           
        if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            $("#<%=pnIconVH.ClientID%>").height($("#<%=pnNganhVH.ClientID%>").height() - $("#<%=pnNganhVH.ClientID%>").height());
                  $("#<%=pnatitleVH.ClientID%>").width($("#<%=pnatitleVH.ClientID%>").width() + $("#<%=pnKhoiVH.ClientID%>").width());
                  $("#<%=pnatitleVH.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconVH.ClientID%>").height($("#<%=pnatitleVH.ClientID%>").height()+ $("#<%=pnNganhVH.ClientID%>").height() +22);
                  $("#<%=pnatitleVH.ClientID%>").width($("#<%=pnatitleVH.ClientID%>").width() - $("#<%=pnKhoiVH.ClientID%>").width());
                  $("#<%=pnatitleVH.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                  if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                  if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                  if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                  //end tat cac nganh
             
              }
    });
          
            $("#<%=pnatitleVH.ClientID%>").click(function(){
         
                var str = "";
                $('#<%=cblNganhVH.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""   & !$("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            return false;
        }
         
        str = "";
        $('#<%=cblVH.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!=""  & !$("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            return false;
        }
        $("#<%=pnNganhVH.ClientID%>").toggle();
        $("#<%=pnKhoiVH.ClientID%>").toggle();
        if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")){
            $("#<%=pnIconVH.ClientID%>").height($("#<%=pnNganhVH.ClientID%>").height() - $("#<%=pnNganhVH.ClientID%>").height());
                 $("#<%=pnatitleVH.ClientID%>").width($("#<%=pnatitleVH.ClientID%>").width() + $("#<%=pnKhoiVH.ClientID%>").width());
                 $("#<%=pnatitleVH.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconVH.ClientID%>").height($("#<%=pnatitleVH.ClientID%>").height()+ $("#<%=pnNganhVH.ClientID%>").height() +22);
                 $("#<%=pnatitleVH.ClientID%>").width($("#<%=pnatitleVH.ClientID%>").width() - $("#<%=pnKhoiVH.ClientID%>").width());
                 $("#<%=pnatitleVH.ClientID%>").css({"color":"#e1e31a"});
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
             }
    });
          
          
            //Xu ly su  kiên Xay dung
            $("#<%=imgXD.ClientID%>").click(function(){
          
                var str = "";
                $('#<%=cblNganhXD.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            return false;
        }
        
        str = "";
        $('#<%=cblXD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!=""  & !$("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            return false;
        }
        
          
        $("#<%=pnNganhXD.ClientID%>").toggle();
        $("#<%=pnKhoiXD.ClientID%>").toggle();
           
        if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            $("#<%=pnIconXD.ClientID%>").height($("#<%=pnNganhXD.ClientID%>").height() - $("#<%=pnNganhXD.ClientID%>").height());
                  $("#<%=pnatitleXD.ClientID%>").width($("#<%=pnatitleXD.ClientID%>").width() + $("#<%=pnKhoiXD.ClientID%>").width());
                  $("#<%=pnatitleXD.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconXD.ClientID%>").height($("#<%=pnatitleXD.ClientID%>").height()+ $("#<%=pnNganhXD.ClientID%>").height() +22);
                  $("#<%=pnatitleXD.ClientID%>").width($("#<%=pnatitleXD.ClientID%>").width() - $("#<%=pnKhoiXD.ClientID%>").width());
                  $("#<%=pnatitleXD.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                  if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                  if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                  if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                  //end tat cac nganh
              }
    });
            
            $("#<%=pnatitleXD.ClientID%>").click(function(){
        
                var str = "";
                $('#<%=cblNganhXD.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            return false;
        }
        
        str = "";
        $('#<%=cblXD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!=""  & !$("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            return false;
        }
        
        $("#<%=pnNganhXD.ClientID%>").toggle();
        $("#<%=pnKhoiXD.ClientID%>").toggle();
        if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")){
            $("#<%=pnIconXD.ClientID%>").height($("#<%=pnNganhXD.ClientID%>").height() - $("#<%=pnNganhXD.ClientID%>").height());
                 $("#<%=pnatitleXD.ClientID%>").width($("#<%=pnatitleXD.ClientID%>").width() + $("#<%=pnKhoiXD.ClientID%>").width());
                 $("#<%=pnatitleXD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconXD.ClientID%>").height($("#<%=pnatitleXD.ClientID%>").height()+ $("#<%=pnNganhXD.ClientID%>").height() +22);
                 $("#<%=pnatitleXD.ClientID%>").width($("#<%=pnatitleXD.ClientID%>").width() - $("#<%=pnKhoiXD.ClientID%>").width());
                 $("#<%=pnatitleXD.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
             }
    });
          
            //Xu ly su  kiên Moi Truong
            $("#<%=imgMT.ClientID%>").click(function(){
          
                var str = "";
                $('#<%=cblNganhMT.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhMT.ClientID%>").is(":hidden")){
            return false;
        }
            
        str = "";
        $('#<%=cblMT.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhMT.ClientID%>").is(":hidden")){
            return false;
        }
            
        
        $("#<%=pnNganhMT.ClientID%>").toggle();
        $("#<%=pnKhoiMT.ClientID%>").toggle();
           
        if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")){
         
            var str = "";
            $('#<%=cblNganhMT.ClientID%> input[type=checkbox]:checked').each(function() {
                      str = str + " " + $(this).next().text();
                  });
                  if(str!=""  & !$("#<%=pnNganhMT.ClientID%>").is(":hidden")){
                      return false;
                  }
            
                  str = "";
                  $('#<%=cblMT.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!=""  & !$("#<%=pnNganhMT.ClientID%>").is(":hidden")){
                      return false;
                  }
            
                  $("#<%=pnIconMT.ClientID%>").height($("#<%=pnNganhMT.ClientID%>").height() - $("#<%=pnNganhMT.ClientID%>").height());
                  $("#<%=pnatitleMT.ClientID%>").width($("#<%=pnatitleMT.ClientID%>").width() + $("#<%=pnKhoiMT.ClientID%>").width());
                  $("#<%=pnatitleMT.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconMT.ClientID%>").height($("#<%=pnatitleMT.ClientID%>").height()+ $("#<%=pnNganhMT.ClientID%>").height() +22);
                  $("#<%=pnatitleMT.ClientID%>").width($("#<%=pnatitleMT.ClientID%>").width() - $("#<%=pnKhoiMT.ClientID%>").width());
                  $("#<%=pnatitleMT.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                  if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                  if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                  if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                  //end tat cac nganh
              }
    });
          
            $("#<%=pnatitleMT.ClientID%>").click(function(){
                $("#<%=pnNganhMT.ClientID%>").toggle();
        $("#<%=pnKhoiMT.ClientID%>").toggle();
        if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")){
            $("#<%=pnIconMT.ClientID%>").height($("#<%=pnNganhMT.ClientID%>").height() - $("#<%=pnNganhMT.ClientID%>").height());
                 $("#<%=pnatitleMT.ClientID%>").width($("#<%=pnatitleMT.ClientID%>").width() + $("#<%=pnKhoiMT.ClientID%>").width());
                 $("#<%=pnatitleMT.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconMT.ClientID%>").height($("#<%=pnatitleMT.ClientID%>").height()+ $("#<%=pnNganhMT.ClientID%>").height() +22);
                 $("#<%=pnatitleMT.ClientID%>").width($("#<%=pnatitleMT.ClientID%>").width() - $("#<%=pnKhoiMT.ClientID%>").width());
                 $("#<%=pnatitleMT.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
             }
    });
          
          
            //Xu ly su  kiên Ngoai Ngu
            $("#<%=imgNN.ClientID%>").click(function(){
          
          
                var str = "";
                $('#<%=cblNganhNN.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhNN.ClientID%>").is(":hidden")){
            return false;
        }
            
        str = "";
        $('#<%=cblNN.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!=""& !$("#<%=pnNganhNN.ClientID%>").is(":hidden") ){
            return false;
        }
            
          
        $("#<%=pnNganhNN.ClientID%>").toggle();
        $("#<%=pnKhoiNN.ClientID%>").toggle();
           
        if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")){
            $("#<%=pnIconNN.ClientID%>").height($("#<%=pnNganhNN.ClientID%>").height() - $("#<%=pnNganhNN.ClientID%>").height());
                  $("#<%=pnatitleNN.ClientID%>").width($("#<%=pnatitleNN.ClientID%>").width() + $("#<%=pnKhoiNN.ClientID%>").width());
                  $("#<%=pnatitleNN.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconNN.ClientID%>").height($("#<%=pnatitleNN.ClientID%>").height()+ $("#<%=pnNganhNN.ClientID%>").height() +22);
                  $("#<%=pnatitleNN.ClientID%>").width($("#<%=pnatitleNN.ClientID%>").width() - $("#<%=pnKhoiNN.ClientID%>").width());
                  $("#<%=pnatitleNN.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                  if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                  if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                  if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                  if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
                  //end tat cac nganh
              }
    });
          
            $("#<%=pnatitleNN.ClientID%>").click(function(){
         
                var str = "";
                $('#<%=cblNganhNN.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhNN.ClientID%>").is(":hidden")){
            return false;
        }
        str = "";
        $('#<%=cblNN.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhNN.ClientID%>").is(":hidden")){
            return false;
        }
         
        $("#<%=pnNganhNN.ClientID%>").toggle();
        $("#<%=pnKhoiNN.ClientID%>").toggle();
        if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")){
            $("#<%=pnIconNN.ClientID%>").height($("#<%=pnNganhNN.ClientID%>").height() - $("#<%=pnNganhNN.ClientID%>").height());
                 $("#<%=pnatitleNN.ClientID%>").width($("#<%=pnatitleNN.ClientID%>").width() + $("#<%=pnKhoiNN.ClientID%>").width());
                 $("#<%=pnatitleNN.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconNN.ClientID%>").height($("#<%=pnatitleNN.ClientID%>").height()+ $("#<%=pnNganhNN.ClientID%>").height() +22);
                 $("#<%=pnatitleNN.ClientID%>").width($("#<%=pnatitleNN.ClientID%>").width() - $("#<%=pnKhoiNN.ClientID%>").width());
                 $("#<%=pnatitleNN.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                 if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
              if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}     
            //end tat cac nganh
             }
    });
          
          
            //Xu ly su  kiên Quan Tri
            $("#<%=imgQT.ClientID%>").click(function(){
          
                var str = "";
                $('#<%=cblNganhQT.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!="" & !$("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            return false;
        }
            
        str = "";
        $('#<%=cblQT.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!=""  & !$("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            return false;
        }
          
        $("#<%=pnNganhQT.ClientID%>").toggle();
        $("#<%=pnKhoiQT.ClientID%>").toggle();
           
        if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            $("#<%=pnIconQT.ClientID%>").height($("#<%=pnNganhQT.ClientID%>").height() - $("#<%=pnNganhQT.ClientID%>").height());
                  $("#<%=pnatitleQT.ClientID%>").width($("#<%=pnatitleQT.ClientID%>").width() + $("#<%=pnKhoiQT.ClientID%>").width());
                  $("#<%=pnatitleQT.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconQT.ClientID%>").height($("#<%=pnatitleQT.ClientID%>").height()+ $("#<%=pnNganhQT.ClientID%>").height() +22);
                  $("#<%=pnatitleQT.ClientID%>").width($("#<%=pnatitleQT.ClientID%>").width() - $("#<%=pnKhoiQT.ClientID%>").width());
                  $("#<%=pnatitleQT.ClientID%>").css({"color":"#e1e31a"});
             
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                  if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                  if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                  if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                  if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
                 if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
                if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                  //end tat cac nganh
              }
    });
          
            $("#<%=pnatitleQT.ClientID%>").click(function(){
         
                var str = "";
                $('#<%=cblNganhQT.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            return false;
        }
         
        str = "";
        $('#<%=cblQT.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!=""  & !$("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            return false;
        }
         
        $("#<%=pnNganhQT.ClientID%>").toggle();
        $("#<%=pnKhoiQT.ClientID%>").toggle();
        if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")){
            $("#<%=pnIconQT.ClientID%>").height($("#<%=pnNganhQT.ClientID%>").height() - $("#<%=pnNganhQT.ClientID%>").height());
                 $("#<%=pnatitleQT.ClientID%>").width($("#<%=pnatitleQT.ClientID%>").width() + $("#<%=pnKhoiQT.ClientID%>").width());
                 $("#<%=pnatitleQT.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconQT.ClientID%>").height($("#<%=pnatitleQT.ClientID%>").height()+ $("#<%=pnNganhQT.ClientID%>").height() +22);
                 $("#<%=pnatitleQT.ClientID%>").width($("#<%=pnatitleQT.ClientID%>").width() - $("#<%=pnKhoiQT.ClientID%>").width());
                 $("#<%=pnatitleQT.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
                 if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
                 if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
                 if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
                 if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
            if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")==false){$("#<%=imgNongNghiep.ClientID%>").click();}
                 //end tat cac nganh
             }
    });
                //Xu ly su  kiên Nông nghiệp
                $("#<%=imgNongNghiep.ClientID%>").click(function(){
          
                    var str = "";
                    $('#<%=cblNganhNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
                    str = str + " " + $(this).next().text();
                });
                if(str!="" & !$("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")){
                    return false;
                }
            
                str = "";
                $('#<%=cblNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")){
                    return false;
                }
          
                $("#<%=pnNganhNongNghiep.ClientID%>").toggle();
                $("#<%=pnKhoiNongNghiep.ClientID%>").toggle();
           
                if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")){
                    $("#<%=pnIconNongNghiep.ClientID%>").height($("#<%=pnNganhNongNghiep.ClientID%>").height() - $("#<%=pnNganhNongNghiep.ClientID%>").height());
            $("#<%=pnatitleNongNghiep.ClientID%>").width($("#<%=pnatitleNongNghiep.ClientID%>").width() + $("#<%=pnKhoiNongNghiep.ClientID%>").width());
            $("#<%=pnatitleNongNghiep.ClientID%>").css({"color":"#ffffff"});
        }else{
            $("#<%=pnIconNongNghiep.ClientID%>").height($("#<%=pnatitleNongNghiep.ClientID%>").height()+ $("#<%=pnNganhNongNghiep.ClientID%>").height() +22);
            $("#<%=pnatitleNongNghiep.ClientID%>").width($("#<%=pnatitleNongNghiep.ClientID%>").width() - $("#<%=pnKhoiNongNghiep.ClientID%>").width());
            $("#<%=pnatitleNongNghiep.ClientID%>").css({"color":"#e1e31a"});
             
             
            //tat cac nganh
            if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
            if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
            if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
            if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
            if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            //end tat cac nganh
        }
            });
          
    $("#<%=pnatitleNongNghiep.ClientID%>").click(function(){
         
                    var str = "";
                    $('#<%=cblNganhNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
                    str = str + " " + $(this).next().text();
                });
                if(str!=""  & !$("#<%=pnNganhQT.ClientID%>").is(":hidden")){
                    return false;
                }
         
                str = "";
                $('#<%=cblNongNghiep.ClientID%> input[type=checkbox]:checked').each(function() {
            str = str + " " + $(this).next().text();
        });
        if(str!=""  & !$("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")){
                    return false;
                }
         
                $("#<%=pnNganhNongNghiep.ClientID%>").toggle();
                $("#<%=pnKhoiNongNghiep.ClientID%>").toggle();
                if( $("#<%=pnNganhNongNghiep.ClientID%>").is(":hidden")){
                    $("#<%=pnIconNongNghiep.ClientID%>").height($("#<%=pnNganhNongNghiep.ClientID%>").height() - $("#<%=pnNganhNongNghiep.ClientID%>").height());
            $("#<%=pnatitleNongNghiep.ClientID%>").width($("#<%=pnatitleNongNghiep.ClientID%>").width() + $("#<%=pnKhoiNongNghiep.ClientID%>").width());
            $("#<%=pnatitleNongNghiep.ClientID%>").css({"color":"#ffffff"});
        }else{
            $("#<%=pnIconNongNghiep.ClientID%>").height($("#<%=pnatitleNongNghiep.ClientID%>").height()+ $("#<%=pnNganhNongNghiep.ClientID%>").height() +22);
            $("#<%=pnatitleNongNghiep.ClientID%>").width($("#<%=pnatitleNongNghiep.ClientID%>").width() - $("#<%=pnKhoiNongNghiep.ClientID%>").width());
            $("#<%=pnatitleNongNghiep.ClientID%>").css({"color":"#e1e31a"});
               
            //tat cac nganh
            if( $("#<%=pnNganhCNTT.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTT.ClientID%>").click();}
            if( $("#<%=pnNganhDien.ClientID%>").is(":hidden")==false){$("#<%=imgDien.ClientID%>").click();}
            if( $("#<%=pnNganhVH.ClientID%>").is(":hidden")==false){$("#<%=imgVH.ClientID%>").click();}
            if( $("#<%=pnNganhXD.ClientID%>").is(":hidden")==false){$("#<%=imgXD.ClientID%>").click();}
            if( $("#<%=pnNganhNN.ClientID%>").is(":hidden")==false){$("#<%=imgNN.ClientID%>").click();}
            if( $("#<%=pnNganhMT.ClientID%>").is(":hidden")==false){$("#<%=imgMT.ClientID%>").click();}
            if( $("#<%=pnNganhQT.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
            //end tat cac nganh
        }
            });
          
        }//endDH
          
          
             
          //Su ly các sự kiện trong hệ cao đẳng
           if((<%=hexettuyen%>==2)||(<%=hexettuyen%>==0)) { 
               //Xu ly su  kiên CNTT
        
               $("#<%=imgCongNgheTTCD.ClientID%>").click(function(){
          
                   var str = "";
                   $('#<%=cblNganhCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!=""  & !$("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
                       return false;
                   }
           
           
                   str = "";
                   $('#<%=cblCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
                       return false;
                   }  
               
                   $("#<%=pnNganhCNTTCD.ClientID%>").toggle();
                   $("#<%=pnKhoiCNTTCD.ClientID%>").toggle();
           
                   if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
          
                       $("#<%=pnIconCNTTCD.ClientID%>").height($("#<%=pnNganhCNTTCD.ClientID%>").height() - $("#<%=pnNganhCNTTCD.ClientID%>").height());
                  $("#<%=pnatitleCNTTCD.ClientID%>").width($("#<%=pnatitleCNTTCD.ClientID%>").width() + $("#<%=pnKhoiCNTTCD.ClientID%>").width());
                  $("#<%=pnatitleCNTTCD.ClientID%>").css({"color":"#ffffff"});
            
              }else{
                  $("#<%=pnIconCNTTCD.ClientID%>").height($("#<%=pnatitleCNTTCD.ClientID%>").height()+ $("#<%=pnNganhCNTTCD.ClientID%>").height() +22);
                  $("#<%=pnatitleCNTTCD.ClientID%>").width($("#<%=pnatitleCNTTCD.ClientID%>").width() - $("#<%=pnKhoiCNTTCD.ClientID%>").width());
                  $("#<%=pnatitleCNTTCD.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                  if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                  if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
                  if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                  //end tat cac nganh
                  
              
              }
               });
          
          $("#<%=pnatitleCNTTCD.ClientID%>").click(function(){
         
                   var str = "";
                   $('#<%=cblNganhCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblCNTTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
             return false;
         }  
        
         $("#<%=pnNganhCNTTCD.ClientID%>").toggle();
         $("#<%=pnKhoiCNTTCD.ClientID%>").toggle();
         if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconCNTTCD.ClientID%>").height($("#<%=pnNganhCNTTCD.ClientID%>").height() - $("#<%=pnNganhCNTTCD.ClientID%>").height());
                 $("#<%=pnatitleCNTTCD.ClientID%>").width($("#<%=pnatitleCNTTCD.ClientID%>").width() + $("#<%=pnKhoiCNTTCD.ClientID%>").width());
                 $("#<%=pnatitleCNTTCD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconCNTTCD.ClientID%>").height($("#<%=pnatitleCNTTCD.ClientID%>").height()+ $("#<%=pnNganhCNTTCD.ClientID%>").height() +22);
                 $("#<%=pnatitleCNTTCD.ClientID%>").width($("#<%=pnatitleCNTTCD.ClientID%>").width() - $("#<%=pnKhoiCNTTCD.ClientID%>").width());
                 $("#<%=pnatitleCNTTCD.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                 if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                 if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
                 if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                 //end tat cac nganh
             }
     });
          
          
               //Xu ly su  kiên Dien
         $("#<%=imgDienCD.ClientID%>").click(function(){
          
                   var str = "";
                   $('#<%=cblNganhDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         $("#<%=pnNganhDienCD.ClientID%>").toggle();
         $("#<%=pnKhoiDienCD.ClientID%>").toggle();
           
         if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconDienCD.ClientID%>").height($("#<%=pnNganhDienCD.ClientID%>").height() - $("#<%=pnNganhDienCD.ClientID%>").height());
                  $("#<%=pnatitleDienCD.ClientID%>").width($("#<%=pnatitleDienCD.ClientID%>").width() + $("#<%=pnKhoiDienCD.ClientID%>").width());
                  $("#<%=pnatitleDienCD.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconDienCD.ClientID%>").height($("#<%=pnatitleDienCD.ClientID%>").height()+ $("#<%=pnNganhDienCD.ClientID%>").height() +22);
                  $("#<%=pnatitleDienCD.ClientID%>").width($("#<%=pnatitleDienCD.ClientID%>").width() - $("#<%=pnKhoiDienCD.ClientID%>").width());
                  $("#<%=pnatitleDienCD.ClientID%>").css({"color":"#e1e31a"});
             
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                  if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                  if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
                  if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                  //end tat cac nganh
                  
              }
     });
          
          $("#<%=pnatitleDienCD.ClientID%>").click(function(){
         
                   var str = "";
                   $('#<%=cblNganhDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblDienCD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         $("#<%=pnNganhDienCD.ClientID%>").toggle();
         $("#<%=pnKhoiDienCD.ClientID%>").toggle();
         if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconDienCD.ClientID%>").height($("#<%=pnNganhDienCD.ClientID%>").height() - $("#<%=pnNganhDienCD.ClientID%>").height());
                 $("#<%=pnatitleDienCD.ClientID%>").width($("#<%=pnatitleDienCD.ClientID%>").width() + $("#<%=pnKhoiDienCD.ClientID%>").width());
                 $("#<%=pnatitleDienCD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconDienCD.ClientID%>").height($("#<%=pnatitleDienCD.ClientID%>").height()+ $("#<%=pnNganhDienCD.ClientID%>").height() +22);
                 $("#<%=pnatitleDienCD.ClientID%>").width($("#<%=pnatitleDienCD.ClientID%>").width() - $("#<%=pnKhoiDienCD.ClientID%>").width());
                 $("#<%=pnatitleDienCD.ClientID%>").css({"color":"#e1e31a"});
               
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                 if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                 if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
                 if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                 //end tat cac nganh
             }
     });
          
               //Xu ly su  kiên Van hoa
         $("#<%=imgVHCD.ClientID%>").click(function(){
          
                   var str = "";
                   $('#<%=cblNganhVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             return false;
         }
          
         $("#<%=pnNganhVHCD.ClientID%>").toggle();
         $("#<%=pnKhoiVHCD.ClientID%>").toggle();
           
         if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconVHCD.ClientID%>").height($("#<%=pnNganhVHCD.ClientID%>").height() - $("#<%=pnNganhVHCD.ClientID%>").height());
                  $("#<%=pnatitleVHCD.ClientID%>").width($("#<%=pnatitleVHCD.ClientID%>").width() + $("#<%=pnKhoiVHCD.ClientID%>").width());
                  $("#<%=pnatitleVHCD.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconVHCD.ClientID%>").height($("#<%=pnatitleVHCD.ClientID%>").height()+ $("#<%=pnNganhVHCD.ClientID%>").height() +22);
                  $("#<%=pnatitleVHCD.ClientID%>").width($("#<%=pnatitleVHCD.ClientID%>").width() - $("#<%=pnKhoiVHCD.ClientID%>").width());
                  $("#<%=pnatitleVHCD.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                  if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                  if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
             
                  if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                  //end tat cac nganh
             
              }
     });
          
          $("#<%=pnatitleVHCD.ClientID%>").click(function(){
         
                   var str = "";
                   $('#<%=cblNganhVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             return false;
         }
         
         str = "";
         $('#<%=cblVHCD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             return false;
         }
         $("#<%=pnNganhVHCD.ClientID%>").toggle();
         $("#<%=pnKhoiVHCD.ClientID%>").toggle();
         if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconVHCD.ClientID%>").height($("#<%=pnNganhVHCD.ClientID%>").height() - $("#<%=pnNganhVHCD.ClientID%>").height());
                 $("#<%=pnatitleVHCD.ClientID%>").width($("#<%=pnatitleVHCD.ClientID%>").width() + $("#<%=pnKhoiVHCD.ClientID%>").width());
                 $("#<%=pnatitleVHCD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconVHCD.ClientID%>").height($("#<%=pnatitleVHCD.ClientID%>").height()+ $("#<%=pnNganhVHCD.ClientID%>").height() +22);
                 $("#<%=pnatitleVHCD.ClientID%>").width($("#<%=pnatitleVHCD.ClientID%>").width() - $("#<%=pnKhoiVHCD.ClientID%>").width());
                 $("#<%=pnatitleVHCD.ClientID%>").css({"color":"#e1e31a"});
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                 if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                 if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
             
                 if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQTCD.ClientID%>").click();}
                 //end tat cac nganh
             }
     });
          
          
          
               //Xu ly su  kiên Xay dung
         $("#<%=imgXDCD.ClientID%>").click(function(){
          
                   var str = "";
                   $('#<%=cblNganhXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             return false;
         }
        
          
         $("#<%=pnNganhXDCD.ClientID%>").toggle();
         $("#<%=pnKhoiXDCD.ClientID%>").toggle();
           
         if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconXDCD.ClientID%>").height($("#<%=pnNganhXDCD.ClientID%>").height() - $("#<%=pnNganhXDCD.ClientID%>").height());
                  $("#<%=pnatitleXDCD.ClientID%>").width($("#<%=pnatitleXDCD.ClientID%>").width() + $("#<%=pnKhoiXDCD.ClientID%>").width());
                  $("#<%=pnatitleXDCD.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconXDCD.ClientID%>").height($("#<%=pnatitleXDCD.ClientID%>").height()+ $("#<%=pnNganhXDCD.ClientID%>").height() +22);
                  $("#<%=pnatitleXDCD.ClientID%>").width($("#<%=pnatitleXDCD.ClientID%>").width() - $("#<%=pnKhoiXDCD.ClientID%>").width());
                  $("#<%=pnatitleXDCD.ClientID%>").css({"color":"#e1e31a"});
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                  if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                  if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
             
                  if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
                  //end tat cac nganh
              }
     });
            
          $("#<%=pnatitleXDCD.ClientID%>").click(function(){
        
                   var str = "";
                   $('#<%=cblNganhXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         str = "";
         $('#<%=cblXDCD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             return false;
         }
        
         $("#<%=pnNganhXDCD.ClientID%>").toggle();
         $("#<%=pnKhoiXDCD.ClientID%>").toggle();
           
         if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconXDCD.ClientID%>").height($("#<%=pnNganhXDCD.ClientID%>").height() - $("#<%=pnNganhXDCD.ClientID%>").height());
                 $("#<%=pnatitleXDCD.ClientID%>").width($("#<%=pnatitleXDCD.ClientID%>").width() + $("#<%=pnKhoiXDCD.ClientID%>").width());
                 $("#<%=pnatitleXDCD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconXDCD.ClientID%>").height($("#<%=pnatitleXDCD.ClientID%>").height()+ $("#<%=pnNganhXDCD.ClientID%>").height() +22);
                 $("#<%=pnatitleXDCD.ClientID%>").width($("#<%=pnatitleXDCD.ClientID%>").width() - $("#<%=pnKhoiXDCD.ClientID%>").width());
                 $("#<%=pnatitleXDCD.ClientID%>").css({"color":"#e1e31a"});
             
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                 if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                 if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
             
                 if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")==false){$("#<%=imgQT.ClientID%>").click();}
                 //end tat cac nganh
          
             }
     });
          
               //Xu ly su  kiên Quan Tri
         $("#<%=imgQTCD.ClientID%>").click(function(){
          
                   var str = "";
                   $('#<%=cblNganhQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             return false;
         }
            
         str = "";
         $('#<%=cblQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                  str = str + " " + $(this).next().text();
              });
              if(str!="" & !$("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             return false;
         }
          
         $("#<%=pnNganhQTCD.ClientID%>").toggle();
         $("#<%=pnKhoiQTCD.ClientID%>").toggle();
           
         if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconQTCD.ClientID%>").height($("#<%=pnNganhQTCD.ClientID%>").height() - $("#<%=pnNganhQTCD.ClientID%>").height());
                  $("#<%=pnatitleQTCD.ClientID%>").width($("#<%=pnatitleQTCD.ClientID%>").width() + $("#<%=pnKhoiQTCD.ClientID%>").width());
                  $("#<%=pnatitleQTCD.ClientID%>").css({"color":"#ffffff"});
              }else{
                  $("#<%=pnIconQTCD.ClientID%>").height($("#<%=pnatitleQTCD.ClientID%>").height()+ $("#<%=pnNganhQTCD.ClientID%>").height() +22);
                  $("#<%=pnatitleQTCD.ClientID%>").width($("#<%=pnatitleQTCD.ClientID%>").width() - $("#<%=pnKhoiQTCD.ClientID%>").width());
                  $("#<%=pnatitleQTCD.ClientID%>").css({"color":"#e1e31a"});
             
             
                  //tat cac nganh
                  if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                  if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                  if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                  if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
             
                  //end tat cac nganh
              }
     });
          
          $("#<%=pnatitleQTCD.ClientID%>").click(function(){
         
                   var str = "";
                   $('#<%=cblNganhQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                       str = str + " " + $(this).next().text();
                   });
                   if(str!="" & !$("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             return false;
         }
         
         str = "";
         $('#<%=cblQTCD.ClientID%> input[type=checkbox]:checked').each(function() {
                 str = str + " " + $(this).next().text();
             });
             if(str!="" & !$("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             return false;
         }
         
         $("#<%=pnNganhQTCD.ClientID%>").toggle();
         $("#<%=pnKhoiQTCD.ClientID%>").toggle();
         if( $("#<%=pnNganhQTCD.ClientID%>").is(":hidden")){
             $("#<%=pnIconQTCD.ClientID%>").height($("#<%=pnNganhQTCD.ClientID%>").height() - $("#<%=pnNganhQTCD.ClientID%>").height());
                 $("#<%=pnatitleQTCD.ClientID%>").width($("#<%=pnatitleQTCD.ClientID%>").width() + $("#<%=pnKhoiQTCD.ClientID%>").width());
                 $("#<%=pnatitleQTCD.ClientID%>").css({"color":"#ffffff"});
             }else{
                 $("#<%=pnIconQTCD.ClientID%>").height($("#<%=pnatitleQTCD.ClientID%>").height()+ $("#<%=pnNganhQTCD.ClientID%>").height() +22);
                 $("#<%=pnatitleQTCD.ClientID%>").width($("#<%=pnatitleQTCD.ClientID%>").width() - $("#<%=pnKhoiQTCD.ClientID%>").width());
                 $("#<%=pnatitleQTCD.ClientID%>").css({"color":"#e1e31a"});
               
                 //tat cac nganh
                 if( $("#<%=pnNganhCNTTCD.ClientID%>").is(":hidden")==false){$("#<%=imgCongNgheTTCD.ClientID%>").click();}
                 if( $("#<%=pnNganhDienCD.ClientID%>").is(":hidden")==false){$("#<%=imgDienCD.ClientID%>").click();}
                 if( $("#<%=pnNganhVHCD.ClientID%>").is(":hidden")==false){$("#<%=imgVHCD.ClientID%>").click();}
                 if( $("#<%=pnNganhXDCD.ClientID%>").is(":hidden")==false){$("#<%=imgXDCD.ClientID%>").click();}
             
                 //end tat cac nganh
             }
     });
          
         
     }//End cao dang
          
          
     });

     function showalert(btnText) {
         alert(btnText)
     }
    </script>
</head>
<body>
    <form id="frmMain" runat="server">
    <!-- Begin Wapper-->
<div id="wrapper">	
<div id="layout" class="clearfix">
	 	<!--  center --><div id="centerHoSo" >
					 <!--  content --><div id="content">
							 <div id="header">
				 <table id="tableheader">
                     <tr>
                         <td id="col6" >
						 <a href="<%=ResolveUrl("Home.html")%>" title="Haiphong Private University"> <img src="images/index/logo.jpg" alt="Haiphong Private University" width="60" height="60"/></a></td>
                         <td id="col2">  <h1 id="h1namehome">TRƯỜNG ĐẠI HỌC DÂN LẬP HẢI PHÒNG </h1></td>
                         <td id="col3">
                             <asp:TextBox ID="txtSearch"  class="searchtxt" Text=""  runat="server"></asp:TextBox>
                         </td>
                         <td id="col4">
						 <ul id="ulshare">
							 <li>
								  <ul id="ulsharelink">
									  <li><a  title="Haiphong Private University" href="https://www.facebook.com/HaiPhongPrivateUniversity" target="_blank" class="iconface"></a></li>
									  <li><a  title="Haiphong Private University" href="https://twitter.com/HpuVn" target="_blank" class="icontiwter"> </a></li>
									  <li><a  title="Haiphong Private University" href="https://plus.google.com/113567665922413102836" target="_blank" class="icongoogle"></a></li>
									  <li><a  title="Haiphong Private University" href="http://diendan.hpu.edu.vn/"  target="_blank" class="iconfeed"> </a></li>
									  <li><a  title="Haiphong Private University" href="https://www.youtube.com/HPUVideoChannel" target="_blank" class="iconyoutobe"></a></li>
								  </ul>  
							</li>
							  
						</ul>               
                         </td>
                     </tr>              
              </table>
				  <!-- end header --></div>
				  
				   <div id="divnavi">
              <ul id="ulnavi">
                  <li>
				  <a  class="afist" title="Haiphong Private University" target="_blank" href="http://hpu.edu.vn/gioithieu/HPUGT-gioithieu-1.html">Giới thiệu</a></li>
				   <li><a  title="Haiphong Private University" target="_blank" href="http://hpu.edu.vn/tintuc/HPU-tintuc.html">Tin tức </a></li>
                  <li><a  title="Haiphong Private University" target="_blank" href="http://hpu.edu.vn/thongbao/HPUTB-thongbao.html">Thông báo </a></li>
                  <li><a  title="Haiphong Private University" target="_blank" href="http://hpu.edu.vn/tuyensinh/HPUTS-tuyensinh.html">Tuyển sinh </a></li>
                  <li><a  title="Haiphong Private University" href="<%=ResolveUrl("Huongdan.html")%>">Hướng dẫn (khai hồ sơ)</a></li>
              </ul>
          <!-- end divnavi --></div>
			<div id="contentbody" class="clearfix">	
			<div id="contentheader">
    <!--  contentHoSo --><div id="contentHoSo">
						<div id="HoSoTile">ĐĂNG KÝ THÔNG TIN XÉT TUYỂN VÀO ĐẠI HỌC - CAO ĐẲNG</div>
				<div id="HoSoHinhThuc">
				Hình thức xét tuyển theo <br/>
				KẾT QUẢ <%=Session["HinhThuc"] %>
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
							
							<div id="lineHS"></div>
							
								<div id="numHS">
									<ul id="stepnumHS">
									<li ><a  title="Haiphong Private University" href="#" class="stepnumchoiceHS">3</a></li>
									</ul>
								</div>
	
					</div>
						<ul id="setpHStext">
								<li class="fistHS"><a  title="Haiphong Private University" class="acHS" href="#" >Xác minh thông tin</a></li>
								<li><a  title="Haiphong Private University" href="#" class="acHS" >Chọn ngành đào tạo</a></li>
								<li class="endHS"><a  title="Haiphong Private University" href="#">Nhập điểm xét tuyển</a></li>
						</ul>
						<div id="NganhDaoTao">
							<!-- NganhHSContent --><div id="NganhHSContent">
							<% if((hexettuyen==2)||(hexettuyen==1)) { %>
							<div style="clear:both; height:5px;"></div>
							
						<div id="group">
						<div class="item line1"></div>
						<div class="item textlineNganh">CHỌN NGÀNH ĐÀO TẠO HỆ ĐẠI HỌC</div>
						<div class="item line"></div>
						</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconCNTT" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgCongNgheTT"  ToolTip="CÔNG NGHỆ THÔNG TIN" CssClass="img"  ImageUrl="images/CNTT.png"  runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterCNTT" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleCNTT" CssClass="NganhCenterLeft"  runat="server">CÔNG NGHỆ THÔNG TIN
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiCNTT" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblCNTT" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblCNTT_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhCNTT" CssClass="NganhCenterBotton"  runat="server">
                                               <asp:CheckBoxList ID="cblNganhCNTT"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" ondatabound="cblNganhCNTT_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							<div class="Nganh">
							    <asp:Panel ID="pnIconDien" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgDien"  ToolTip="ĐIỆN - ĐIỆN TỬ" CssClass="img"  ImageUrl="images/DIEN.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterDien" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleDien" CssClass="NganhCenterLeft"  runat="server">KỸ THUẬT ĐIỆN - ĐIỆN TỬ
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiDien" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblDien" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblDien_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhDien" CssClass="NganhCenterBotton"  runat="server">
                                               <asp:CheckBoxList ID="cblNganhDien"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" ondatabound="cblNganhDien_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconVH" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgVH"  ToolTip="VĂN HÓA DU LỊCH" CssClass="img"  ImageUrl="images/vhdl-04.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterVH" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleVH" CssClass="NganhCenterLeft"  runat="server">VIỆT NAM HỌC
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiVH" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblVH" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblVH_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhVH" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhVH"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhVH_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconXD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgXD"  ToolTip="KT CÔNG TRÌNH XÂY DỰNG" CssClass="img"  ImageUrl="images/xaydung.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterXD" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleXD" CssClass="NganhCenterLeft"  runat="server">KỸ THUẬT CÔNG TRÌNH XÂY DỰNG
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiXD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblXD" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblXD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhXD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhXD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhXD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconMT" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgMT"  ToolTip="KỸ THUẬT MÔI TRƯỜNG" CssClass="img"  ImageUrl="images/kythuatmoitruong.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterMT" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleMT" CssClass="NganhCenterLeft"  runat="server">KỸ THUẬT MÔI TRƯỜNG
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiMT" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblMT" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblMT_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhMT" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhMT"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhMT_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconNN" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgNN"  ToolTip="NGÔN NGỮ ANH" CssClass="img"  ImageUrl="images/ngonnguanh.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterNN" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleNN" CssClass="NganhCenterLeft"  runat="server">NGÔN NGỮ ANH
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiNN" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblNN" RepeatDirection="Horizontal"  CssClass="cblKhoi" RepeatLayout="Table" runat="server" ondatabound="cblNN_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhNN" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhNN"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhNN_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconQT" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgQT"  ToolTip="QUẢN TRỊ KINH DOANH" CssClass="img"  ImageUrl="images/quantrikinhdoanh.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterQT" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleQT" CssClass="NganhCenterLeft"  runat="server">QUẢN TRỊ KINH DOANH
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiQT" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblQT" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblQT_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhQT" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhQT"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhQT_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>

                                <div class="Nganh">
							    <asp:Panel ID="pnIconNongNghiep" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgNongNghiep"  ToolTip="NÔNG NGHIỆP" CssClass="img"  ImageUrl="images/vhdl-04.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterNongNghiep" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleNongNghiep" CssClass="NganhCenterLeft"  runat="server">NÔNG NGHIỆP
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiNongNghiep" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblNongNghiep" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" OnDataBound="cblNongNghiep_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhNongNghiep" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhNongNghiep"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhNongNghiep_DataBound" > </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							   <%} %>
							   <% if ((hexettuyen == 2) || (hexettuyen == 0))
             { %>
							<div style="clear:both; height:5px;"></div>
							<div id="group">
						<div class="item line1"></div>
						<div class="item textlineNganh">CHỌN NGÀNH ĐÀO TẠO HỆ CAO ĐẲNG</div>
						<div class="item line"></div>
						</div>
							<div style="clear:both; height:5px;"></div>
						  <div class="Nganh">
							    <asp:Panel ID="pnIconCNTTCD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgCongNgheTTCD"  ToolTip="CÔNG NGHỆ THÔNG TIN" CssClass="img"  ImageUrl="images/CNTT.png"  runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterCNTTCD" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleCNTTCD" CssClass="NganhCenterLeft"  runat="server">CÔNG NGHỆ THÔNG TIN
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiCNTTCD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblCNTTCD" RepeatDirection="Horizontal"  
                                                 CssClass="cblKhoi" RepeatLayout="Table" runat="server" 
                                                 ondatabound="cblCNTTCD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhCNTTCD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhCNTTCD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhCNTTCD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							<div class="Nganh">
							    <asp:Panel ID="pnIconDienCD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgDienCD"  ToolTip="ĐIỆN - ĐIỆN TỬ" CssClass="img"  ImageUrl="images/DIEN.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterDienCD" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleDienCD" CssClass="NganhCenterLeft"  runat="server">KỸ THUẬT ĐIỆN - ĐIỆN TỬ
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiDienCD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblDienCD" RepeatDirection="Horizontal"  
                                                 CssClass="cblKhoi" RepeatLayout="Table" runat="server" 
                                                 ondatabound="cblDienCD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhDienCD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhDienCD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhDienCD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconVHCD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgVHCD"  ToolTip="VĂN HÓA DU LỊCH" CssClass="img"  ImageUrl="images/vhdl-04.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterVHCD" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleVHCD" CssClass="NganhCenterLeft"  runat="server">VIỆT NAM HỌC
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiVHCD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblVHCD" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblVHCD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhVHCD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhVHCD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhVHCD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconXDCD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgXDCD"  ToolTip="KT CÔNG TRÌNH XÂY DỰNG" CssClass="img"  ImageUrl="images/xaydung.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="Panel1" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleXDCD" CssClass="NganhCenterLeft"  runat="server">KỸ THUẬT CÔNG TRÌNH XÂY DỰNG
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiXDCD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblXDCD" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblXDCD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhXDCD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhXDCD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhXDCD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							
							
							<div class="Nganh">
							    <asp:Panel ID="pnIconQTCD" CssClass="Nganhlefft"  runat="server"> 
                                    <asp:Image ID="imgQTCD"  ToolTip="QUẢN TRỊ KINH DOANH" CssClass="img"  ImageUrl="images/quantrikinhdoanh.png" runat="server" /></asp:Panel>
                                     <asp:Panel ID="pncenterQTCD" CssClass="NganhCenter"  runat="server">
                                          <asp:Panel ID="pnatitleQTCD" CssClass="NganhCenterLeft"  runat="server">QUẢN TRỊ KINH DOANH
                                        </asp:Panel>
                                         <asp:Panel ID="pnKhoiQTCD" CssClass="NganhCenterRight"  runat="server"><div class="divider"></div>KHỐI XÉT TUYỂN <br />
                                             <asp:CheckBoxList ID="cblQTCD" RepeatDirection="Horizontal"  CssClass="cblKhoi" 
                                                 RepeatLayout="Table" runat="server" ondatabound="cblQTCD_DataBound"> 
                                             </asp:CheckBoxList>
                                        </asp:Panel>
							               <asp:Panel ID="pnNganhQTCD" CssClass="NganhCenterBotton"  runat="server"><asp:CheckBoxList ID="cblNganhQTCD"  CssClass="cblNganh"
                            RepeatColumns="2" RepeatLayout="Table" runat="server" OnDataBound="cblNganhQTCD_DataBound"> </asp:CheckBoxList>
                                        </asp:Panel>
                                    </asp:Panel>
							    
							</div>
							    <%} %>
							<div style="clear:both; height:20px;"></div>
<div id="bottonTiep"><asp:Button ID="btnTiep" runat="server"   class="BottonTiep" 
        Text="Tiếp >>" onclick="btnTiep_Click" /></div>	
   	
					<!-- end NganhDaoTao --></div>
					
							<!-- end NganhHSContent -->	</div>
				<!-- end contentHoSo --> </div>
        <!-- content heder --> </div>
<!-- end contentbody--></div>    
			 <!-- end content --></div>
		<!-- end centerHoSo --></div>
		  <!-- end logobotton--> <div id="logobotton" class="clearfix">
		   <div id="contentbotton" class="clearfix">
         <div id="footter">
            <table id="tablefooter">
                    <tr>
                           <td id="co1"> 
                           <p class="diachi">
                           
                           Địa chỉ: Số 36 - Đường Dân Lập - Phường Dư Hàng Kênh - Quận Lê Chân - TP Hải Phòng
                          <br/>  Điện thoại: 031 3740577 - 031 3833802 - 031 3740578  Fax: 031.3740476  Email: webmaster@hpu.edu.vn
                           </p></td>   
                           <td id="Td1">
                             <p class="sologon">
                               Học thật thi thật để ra đời làm thật
                             </p>
                           </td>               
                    </tr>           
            </table>
         <!-- end footer--></div>
       <!-- end contentbottom--></div>	
	 <!-- end layout --></div>
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
<!-- End Wapper-->
    </form>
</body>
</html>


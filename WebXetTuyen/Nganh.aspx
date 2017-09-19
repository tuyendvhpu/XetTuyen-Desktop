<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHoSo.master" AutoEventWireup="true" CodeFile="Nganh.aspx.cs" Inherits="Nganh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="highslide/highslide-full.js"></script>
<link rel="stylesheet" type="text/css" href="highslide/highslide.css" />
    <script type="text/javascript">
        hs.graphicsDir = 'highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.outlineType = 'rounded-white';
        hs.fadeInOut = true;
        hs.dimmingOpacity = 0.75;

        // define the restraining box
        hs.useBox = true;
        hs.width = 100%;
        hs.height = 100%;

        // Add the controlbar
        hs.addSlideshow({
            //slideshowGroup: 'group1',
            interval: 5000,
            repeat: false,
            useControls: true,
            fixedControls: 'fit',
            overlayOptions: {
                opacity: 1,
                position: 'bottom center',
                hideOnMouseOut: true
            }
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
    <div id="contentheader">
				  
				 <!-- content heder --> </div>
				 <!-- linebgheader --> <div id="linebgheader"></div>
				 <!-- linetite --> <div id="linetite">HỌC NGÀNH NÀO RA LÀM GÌ?</div>
				 <!-- bglinetite --> <div id="bglinetite"></div>
  
      <div class="highslide-gallery" style="height:350px">
<!--
	4) This is how you mark up the thumbnail image with an anchor tag around it.
	The anchor's href attribute defines the URL of the full-size image.
-->
<a href="images/vhdl.jpg" class="highslide"  onclick="return hs.expand(this)">
	<img src="images/KhoaDL.jpg" alt="Khoa du lịch"  style="width:245px; height:140px;"
		title="Văn hóa du lịch" />
</a>

<!--
	5 (optional). This is how you mark up the caption. The correct class name is important.
-->

<div class="highslide-caption">
	Văn hóa du lịch.
</div>


<!-- Repetionion of the above -->
<a href="images/cntt.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/khoaCN.jpg" alt="Công nghệ thông tin"  style="width:245px;height:140px;"
		title="Khoa công nghệ thông tin" /></a>

<div class="highslide-caption">
Khoa công nghệ thông tin.
</div>

<a href="images/moitruong.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/KhoaMT.jpg" alt="Khoa môi trường"  style="width:240px;height:140px;"
		title="Khoa môi trường" /></a>

<div class="highslide-caption">
	Khoa môi trường.
</div>

<a href="images/dien-dientu.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/KhoaDien.jpg" alt="Khoa điện - điện tử" style="width:245px;height:140px;"
		title="Khoa điện - điện tử" /></a>

<div class="highslide-caption">
	Khoa điện - điện tử.
</div>

 <a href="images/NgoaiNgu.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/NgoaiNgu.jpg" alt="Khoa ngoại ngữ" style="width:245px;height:140px;"
		title="Khoa ngoại ngữ" /></a>

<div class="highslide-caption">
	Khoa ngoại ngữ.
</div>
  <a href="images/XayDung.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/XayDung.jpg" alt="Khoa xây dựng " style="width:245px;height:140px;"
		title="Khoa xây dựng" /></a>

<div class="highslide-caption">
	Khoa xây dựng.
</div>
          <a href="images/QTKD1.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/QTKD1.jpg" alt="Quản trị kinh doanh" style="width:240px;height:140px;"
		title="Quản trị kinh doanh" /></a>

<div class="highslide-caption">
	Quản trị kinh doanh
</div>
<a href="images/QTKD2.jpg" class="highslide" onclick="return hs.expand(this)">
	<img src="images/QTKD2.jpg" alt="Quản trị kinh doanh " style="width:244px;height:140px;"
		title="Quản trị kinh doanh" /></a>

<div class="highslide-caption">
	Quản trị kinh doanh
</div>
</div>
</asp:Content>


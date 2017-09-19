<%@ Page Language="C#" MasterPageFile="~/MasterHoSo.master" AutoEventWireup="true" CodeFile="StepOne.aspx.cs" Inherits="StepOne" Title="Haiphong Private University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var regex = new RegExp("^[a-zA-Z0-9]+$");
 $(document).ready(function () {
       
        $("#<%=txtMaTruong.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                  $("#<%=txtMaTruong.ClientID%>").val(str);
                 var datavalue ={'matruongDH':  str + $("#<%=txtMaTruong1.ClientID%>").val() + $("#<%=txtMaTruong_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongDH",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruong.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong1.ClientID%>").focus();
                 return true;
                }
            });
            
            
             $("#<%=txtMaTruong1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                
                if (regex.test(str)) {
                $("#<%=txtMaTruong1.ClientID%>").val(str);
                 var datavalue ={'matruongDH': $("#<%=txtMaTruong.ClientID%>").val() + str +  $("#<%=txtMaTruong_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongDH",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruong.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong_2.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
             $("#<%=txtMaTruong_2.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong_2.ClientID%>").val(str);
                 var datavalue ={'matruongDH': $("#<%=txtMaTruong.ClientID%>").val() +  $("#<%=txtMaTruong1.ClientID%>").val()+ str  };
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongDH",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruong.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtKhoi.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
            
             $("#<%=txtKhoi.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                  $("#<%=txtKhoi.ClientID%>").val(str);
                     $("#<%=txtKhoi1.ClientID%>").focus();
                    
                 return true;
                }
            });
             $("#<%=txtKhoi1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                  $("#<%=txtKhoi1.ClientID%>").val(str);
                     $("#<%=txtMaTinh10.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
            
            $("#<%=txtMaTinh10.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                 $("#<%=txtMaTinh10.ClientID%>").val(str);
                 var datavalue ={'matinh':  str + $("#<%=txtMaTinh10_1.ClientID%>").val(),'matruongPT': + $("#<%=txtMaTruong10.ClientID%>").val() + $("#<%=txtMaTruong10_1.ClientID%>").val() + $("#<%=txtMaTruong10_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT10.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTinh10_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
             $("#<%=txtMaTinh10_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTinh10_1.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh10.ClientID%>").val() + str ,'matruongPT': + $("#<%=txtMaTruong10.ClientID%>").val() + $("#<%=txtMaTruong10_1.ClientID%>").val() + $("#<%=txtMaTruong10_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT10.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong10.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
            $("#<%=txtMaTruong10.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong10.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh10.ClientID%>").val() + $("#<%=txtMaTinh10_1.ClientID%>").val()  ,'matruongPT': + str + $("#<%=txtMaTruong10_1.ClientID%>").val() + $("#<%=txtMaTruong10_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT10.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong10_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            
            $("#<%=txtMaTruong10_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong10_1.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh10.ClientID%>").val() + $("#<%=txtMaTinh10_1.ClientID%>").val() ,'matruongPT': + $("#<%=txtMaTruong10.ClientID%>").val() + str + $("#<%=txtMaTruong10_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT10.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong10_2.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong10_2.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong10_2.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh10.ClientID%>").val() + $("#<%=txtMaTinh10_1.ClientID%>").val() ,'matruongPT': + $("#<%=txtMaTruong10.ClientID%>").val() + $("#<%=txtMaTruong10_1.ClientID%>").val() + str};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                        $("#<%=lblTruongPT10.ClientID%>").text(data.d);
                        $("#<%=txtMaTinh11.ClientID%>").val($("#<%=txtMaTinh10.ClientID%>").val()); 
                        $("#<%=txtMaTinh11_1.ClientID%>").val($("#<%=txtMaTinh10_1.ClientID%>").val()); 
                        $("#<%=txtMaTruong11.ClientID%>").val($("#<%=txtMaTruong10.ClientID%>").val()); 
                        $("#<%=txtMaTruong11_1.ClientID%>").val($("#<%=txtMaTruong10_1.ClientID%>").val()); 
                        $("#<%=txtMaTruong11_2.ClientID%>").val($("#<%=txtMaTruong10_2.ClientID%>").val()); 
                    }
                    });
                     $("#<%=txtMaTinh11.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTinh11.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTinh11.ClientID%>").val(str);
                 var datavalue ={'matinh':  str + $("#<%=txtMaTinh11_1.ClientID%>").val(),'matruongPT': + $("#<%=txtMaTruong11.ClientID%>").val() + $("#<%=txtMaTruong11_1.ClientID%>").val() + $("#<%=txtMaTruong11_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT11.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTinh11_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
             $("#<%=txtMaTinh11_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTinh11_1.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh11.ClientID%>").val() + str ,'matruongPT': + $("#<%=txtMaTruong11.ClientID%>").val() + $("#<%=txtMaTruong11_1.ClientID%>").val() + $("#<%=txtMaTruong11_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                        $("#<%=lblTruongPT11.ClientID%>").text(data.d);
                        $("#<%=txtMaTruong11.ClientID%>").val = $("#<%=txtMaTinh11.ClientID%>").val();
                    }
                    });
                     $("#<%=txtMaTruong11.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong11.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong11.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh11.ClientID%>").val() + $("#<%=txtMaTinh11_1.ClientID%>").val() ,'matruongPT': + str + $("#<%=txtMaTruong11_1.ClientID%>").val() + $("#<%=txtMaTruong11_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT11.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong11_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong11_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                  $("#<%=txtMaTruong11_1.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh11.ClientID%>").val() + $("#<%=txtMaTinh11_1.ClientID%>").val() ,'matruongPT': + $("#<%=txtMaTruong11.ClientID%>").val() + str + $("#<%=txtMaTruong11_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT11.ClientID%>").text(data.d);
                    }
                    });
                     $("#<%=txtMaTruong11_2.ClientID%>").focus();
                    
                 return true;
                }
            });
            $("#<%=txtMaTruong11_2.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong11_2.ClientID%>").val(str);
                 var datavalue ={'matinh':  $("#<%=txtMaTinh11.ClientID%>").val() + $("#<%=txtMaTinh11_1.ClientID%>").val() ,'matruongPT': + $("#<%=txtMaTruong11.ClientID%>").val() + $("#<%=txtMaTruong11_1.ClientID%>").val() + str};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                        $("#<%=lblTruongPT11.ClientID%>").text(data.d);
                        $("#<%=txtMaTinh12.ClientID%>").val($("#<%=txtMaTinh11.ClientID%>").val());
                        $("#<%=txtMaTinh12_1.ClientID%>").val($("#<%=txtMaTinh11_1.ClientID%>").val());
                        $("#<%=txtMaTruong12.ClientID%>").val($("#<%=txtMaTruong11.ClientID%>").val());
                        $("#<%=txtMaTruong12_1.ClientID%>").val($("#<%=txtMaTruong11_1.ClientID%>").val());
                        $("#<%=txtMaTruong12_2.ClientID%>").val($("#<%=txtMaTruong11_2.ClientID%>").val()); 
                    }
                    });
                     $("#<%=txtMaTinh12.ClientID%>").focus();
                    
                 return true;
                }
            });

            //truong lop 12
            $("#<%=txtMaTinh12.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTinh12.ClientID%>").val(str);
                 var datavalue ={'matinh':  str + $("#<%=txtMaTinh12_1.ClientID%>").val() ,'matruongPT': + $("#<%=txtMaTruong12.ClientID%>").val() + $("#<%=txtMaTruong12_1.ClientID%>").val() + $("#<%=txtMaTruong12_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT_KV",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT12.ClientID%>").html(data.d);
                    }
                    });
                     $("#<%=txtMaTinh12_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTinh12_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                 $("#<%=txtMaTinh12_1.ClientID%>").val(str);
                 var datavalue ={'matinh': $("#<%=txtMaTinh12.ClientID%>").val() + str   ,'matruongPT': + $("#<%=txtMaTruong12.ClientID%>").val() + $("#<%=txtMaTruong12_1.ClientID%>").val() + $("#<%=txtMaTruong12_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT_KV",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT12.ClientID%>").html(data.d);
                    }
                    });
                     $("#<%=txtMaTruong12.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong12.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong12.ClientID%>").val(str);
                 var datavalue ={'matinh': $("#<%=txtMaTinh12.ClientID%>").val() + $("#<%=txtMaTinh12_1.ClientID%>").val()   ,'matruongPT': + str + $("#<%=txtMaTruong12_1.ClientID%>").val() + $("#<%=txtMaTruong12_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT_KV",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT12.ClientID%>").html(data.d);
                    }
                    });
                     $("#<%=txtMaTruong12_1.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong12_1.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                 $("#<%=txtMaTruong12_1.ClientID%>").val(str);
                 var datavalue ={'matinh': $("#<%=txtMaTinh12.ClientID%>").val() + $("#<%=txtMaTinh12_1.ClientID%>").val()   ,'matruongPT': + $("#<%=txtMaTruong12.ClientID%>").val() + str + $("#<%=txtMaTruong12_2.ClientID%>").val()};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT_KV",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT12.ClientID%>").html(data.d);
                    }
                    });
                     $("#<%=txtMaTruong12_2.ClientID%>").focus();
                    
                 return true;
                }
            });
            
            $("#<%=txtMaTruong12_2.ClientID%>").keypress(function(e) {
                //alert("keypress");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
               
                if (regex.test(str)) {
                
                $("#<%=txtMaTruong12_2.ClientID%>").val(str);
                 var datavalue ={'matinh': $("#<%=txtMaTinh12.ClientID%>").val() + $("#<%=txtMaTinh12_1.ClientID%>").val()   ,'matruongPT': + $("#<%=txtMaTruong12.ClientID%>").val() + $("#<%=txtMaTruong12_1.ClientID%>").val() + str};
                    $.ajax({
                    type: "POST",
                     url: "StepOne.aspx/TruongPT_KV",
                    data:JSON.stringify(datavalue),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                    //alert(data.d),
                    $("#<%=lblTruongPT12.ClientID%>").html(data.d);
                    }
                    });
                     $("#<%=drbNam.ClientID%>").focus();
                    
                 return true;
                }
            });
   });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHere" Runat="Server">
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
							<div id="lineHS"></div>
							
								<div id="numHS">
									<ul id="stepnumHS">
									<li><a  title="Haiphong Private University" href="#" class="stepnumchoiceHS">2</a></li>
									</ul>
								</div>
							
							<div id="lineHS" ></div>
							
								<div id="numHS">
									<ul id="stepnumHS">
									<li ><a  title="Haiphong Private University" href="#" class="stepnumchoiceHS">3</a></li>
									</ul>
								</div>
	
					</div>
						<ul id="setpHStext">
								<li class="fistHS"><a  title="Haiphong Private University" class="acHS" href="#" >Xác minh thông tin</a></li>
								<li><a  title="Haiphong Private University" href="#" >Chọn ngành đào tạo</a></li>
								<li class="endHS"><a  title="Haiphong Private University" href="#">Nhập điểm xét tuyển</a></li>
						</ul>
				<!-- ThongTinHS --><div id="ThongTinHS">
					<div id="group">
					<div class="item line1"></div>
					<div class="item textline">Thông tin hồ sơ</div>
					<div class="item line"></div>
					</div>
					<div id="ThongTinHSContent">
						<div id="HoSoCenter">
		<table id="tabbleNoidung" border="0" cellspacing="0" cellpadding="0">
		<tr>
		<td></td><td></td>
		<td class="des" >Mã trường</td><td class="des" >khối thi</td>
		</tr>
		<tr>
		<td id="col11">Hạnh kiểm  &nbsp;  
            <asp:DropDownList ID="drbHanhKiem" runat="server">
                  <asp:ListItem Selected="True">Tốt</asp:ListItem>
                <asp:ListItem>Khá</asp:ListItem>
                <asp:ListItem>Trung bình</asp:ListItem>
                <asp:ListItem>Yếu</asp:ListItem>
            </asp:DropDownList>
		</td>
		<td id="col12">Trường thi tuyển</td>
		<td id="matruong"><asp:TextBox ID="txtMaTruong" maxlength="1"  class="Thongtintxt" runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTruong1" maxlength="1"  class="Thongtintxt" runat="server"></asp:TextBox><asp:TextBox ID="txtMaTruong_2" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox>
        </td><td id="matinh"><asp:TextBox ID="txtKhoi" maxlength="1"  class="Thongtintxt" runat="server"></asp:TextBox><asp:TextBox ID="txtKhoi1" maxlength="1"  class="Thongtintxt" runat="server"></asp:TextBox></td>
		<td style="width:190px;" ><asp:Label ID="lblTruong" runat="server"  CssClass="des" Text=""></asp:Label>
          </td>
		</tr>
		</table>
		<table id="tabbleNoidung1" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="namhoc">Năm học lớp 10</td>
    <td id="matinh"><asp:TextBox ID="txtMaTinh10" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTinh10_1" maxlength="1"  class="Thongtintxt" runat="server" ></asp:TextBox>
    </td>
    <td id="matruong">
        <asp:TextBox ID="txtMaTruong10" maxlength="1"  class="Thongtintxt"  runat="server"></asp:TextBox><asp:TextBox ID="txtMaTruong10_1" maxlength="1"  class="Thongtintxt"   runat="server"   ></asp:TextBox><asp:TextBox ID="txtMaTruong10_2" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox>
    </td>
    <td  id="namhoc1">Năm học lớp 11</td>
    <td id="matinh">
        <asp:TextBox ID="txtMaTinh11" maxlength="1"  class="Thongtintxt"  runat="server"></asp:TextBox><asp:TextBox ID="txtMaTinh11_1" maxlength="1"  class="Thongtintxt" runat="server" ></asp:TextBox>
    </td>
    <td id="matruong"><asp:TextBox ID="txtMaTruong11" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTruong11_1" maxlength="1"  class="Thongtintxt"   runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTruong11_2" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox>
    </td>
	<td  id="namhoc1">Năm học lớp 12</td>
    <td id="matinh">
        <asp:TextBox ID="txtMaTinh12" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTinh12_1" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox>
    </td>
    <td id="matruong"><asp:TextBox ID="txtMaTruong12" maxlength="1"  class="Thongtintxt"  runat="server" ></asp:TextBox><asp:TextBox ID="txtMaTruong12_1" maxlength="1"  class="Thongtintxt"    runat="server"></asp:TextBox><asp:TextBox ID="txtMaTruong12_2" maxlength="1"  class="Thongtintxt"   runat="server" ></asp:TextBox>
   </td>
  </tr>
  <tr>
    <td></td>
    <td class="des" id="matinh">Mã tỉnh </td>
    <td class="des" id="matruong">Mã trường </td>
    <td></td>
    <td class="des" id="matinh">Mã tỉnh</td>
    <td class="des" id="matruong"> Mã trường </td>
    <td></td>
    <td class="des" id="matinh">Mã tỉnh</td>
    <td class="des" id="matruong">Mã trường </td>
  </tr>
  <tr>
    <td class="des" colspan="3">
        <asp:Label ID="lblTruongPT10" runat="server" Text=""></asp:Label> </td>
    <td class="des" colspan="3"><asp:Label ID="lblTruongPT11" runat="server" Text=""></asp:Label></td>
    <td class="des" colspan="3"><asp:Label ID="lblTruongPT12" runat="server" Text=""></asp:Label></td>
  </tr>
</table>

	<table id="tabbleNoidung2" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="col21">Năm tốt nghiệp THPT &nbsp;  
        <asp:DropDownList ID="drbNam" runat="server">
        </asp:DropDownList>
    </td>
    <td>Mã đối tượng &nbsp; 
        <asp:TextBox ID="txtDoiTuong" CssClass="Thongtintxt" maxlength="1" Text="0" runat="server"></asp:TextBox><asp:TextBox ID="txtDoiTuong1" Text="0"  CssClass="Thongtintxt" maxlength="1" runat="server"></asp:TextBox></td>
    <td style=" display:inline;">Hệ xét tuyển<asp:CheckBoxList Width="140px" ID="cblHeXeTuyen"  RepeatDirection="Horizontal"   RepeatColumns="2" RepeatLayout="Table"  runat="server"><asp:ListItem Value="0">Cao Đẳng</asp:ListItem><asp:ListItem Selected="True" Value="1">Đại học</asp:ListItem></asp:CheckBoxList>
    </td>
  </tr>
</table>
<p id="perror"  runat="server" class="error"></p>
<div id="bottonTiep"> 
    <asp:Button ID="btnTiep" CssClass="BottonTiep" runat="server" Text="Tiếp >>" 
        onclick="btnTiep_Click" />
</div>		
</div>		
					</div>
			<!-- end ThongTinHS -->	</div>
				<!-- end contentHoSo --> </div>
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


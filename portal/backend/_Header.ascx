<%@ Control CodeBehind="_Header.ascx.vb" Language="vb" AutoEventWireup="false" Inherits="C_Header1" %>
<!-- // START: header.tpl // -->
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=big5">
			<style type="text/css">
a:link{color: #0000FF; text-decoration: none; font-family: "新細明體", "細明體"}
a:visited{color: #444444; text-decoration: none; font-family: "新細明體", "細明體"}
a:active{color:#000000; font-family: "新細明體", "細明體"}
a:hover{color:#FFCC00; text-decoration: none; font-family: "新細明體", "細明體"}

/*定義按鈕格式*/
a.button {background-color:  #0066FF;text-align: center;width:95px;  /* 設定寬度 */font-size: 9.5pt;text-decoration:none;; border: 1px #0066FF outset; font-family: "細明體", "新細明體"; clip:  rect(   )}
a.button:link  {color: #F0B606; }   /* 超連結文字色彩 */
a.button:visited {color:#F0B606; }  /* 已連結過之超連結文字色彩 */
a.button:hover {color: #FFFFFF; border-style: inset }  /* 滑鼠指標所在超連結之文字色彩及邊框樣式 */
a.button:active {color: #FFFFFF;}  /* 正被選取之超連結文字以粗體顯示且放大字型 */

a.button1 {background-color:  #FF0000;text-align: center;width:40px;  /* 設定寬度 */font-size: 10pt;text-decoration:none;; border: 1px #FF0000 outset; font-family: "細明體", "新細明體"; clip:  rect(   )}
a.button1:link  {color: #000000; }   /* 超連結文字色彩 */
a.button1:visited {color:#000000; }  /* 已連結過之超連結文字色彩 */
a.button1:hover {color: #FFFFFF; border-style: inset }  /* 滑鼠指標所在超連結之文字色彩及邊框樣式 */
a.button1:active {color: #FFFFFF;}  /* 正被選取之超連結文字以粗體顯示且放大字型 */

a.actionbutton1 {background-color:  #FF6600;text-align: center;width:65px;  /* 設定寬度 */font-size: 10pt;text-decoration:none;; border: 1px #FF0000 outset; font-family: "細明體", "新細明體"; clip:  rect(   )}
a.actionbutton1:link  {color: #000000; }   /* 超連結文字色彩 */
a.actionbutton1:visited {color:#000000; }  /* 已連結過之超連結文字色彩 */
a.actionbutton1:hover {color: #FFFFFF; border-style: inset }  /* 滑鼠指標所在超連結之文字色彩及邊框樣式 */
a.actionbutton1:active {color: #FFFFFF;}  /* 正被選取之超連結文字以粗體顯示且放大字型 */

a.actionbutton2 {background-color:  #CCCCCC;text-align: center;width:65px;  /* 設定寬度 */font-size: 10pt;text-decoration:none;; border: 1px #CCCCCC outset; font-family: "細明體", "新細明體"; clip:  rect(   )}
a.actionbutton2:link  {color: #000000; }   /* 超連結文字色彩 */
a.actionbutton2:visited {color:#000000; }  /* 已連結過之超連結文字色彩 */
a.actionbutton2:hover {color: #FF0000; border-style: inset }  /* 滑鼠指標所在超連結之文字色彩及邊框樣式 */
a.actionbutton2:active {color: #FF0000;}  /* 正被選取之超連結文字以粗體顯示且放大字型 */

p{color:#323232; font-family: 新細明體,細明體; font-size: 10pt }
input{font-family: 新細明體,細明體; font-size: 10pt}
.select{font-family: 新細明體,細明體; font-size: 10pt}
td{color:#323232; font-family: 新細明體,細明體; font-size: 10pt }
body{color:#000000; font-family: "新細明體", "細明體"; font-size: 10pt }

.selected{font-family: 新細明體,細明體; font-size: 10pt;color:#9E4434;}
.mini {  font-size: 10pt; text-align: center; border: 1px #0000FF solid}
.px12 {  font-size: 13px; line-height: 20px; font-variant: normal}
.text {  color: #000000; font-size: 14px; font-variant: normal;  font-family: "新細明體", "細明體"}
.text_title1 { color: #000000; font-size: 14px; font-variant: normal; font-family: "新細明體", "細明體" ; font-weight: bold}

.table1 {  font-family: "細明體", "新細明體"; border-style:solid ;border-width:1,1,1,1 ;border-color:#666666; line-height: 18px}
.table2 {  font-size: 12pt;font-family: "細明體", "新細明體"; border-style:solid ;border-width:1,1,1,1 ;border-color:#666666}

input.c {  font-size: 10pt; border: 1px #CCCCCC solid; color: #0339B8; background-color: #FFFFFF}
.small {COLOR: #0000200; FONT-FAMILY: "細明體", "新細明體"; FONT-SIZE: 10pt; FONT-STYLE: normal; LINE-HEIGHT: 13pt; VERTICAL-ALIGN: top}
.bt {  font-size: 10pt; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; height: 16px; width: 65px; background-color: #FFFFFF; cursor: hand} 
.bt1 {  font-size:10pt; color:#0000FF; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; height: 20px; width: 98px; background-color: #FFFFFF; cursor: hand} 
.bt11 {  font-size:10pt; color:#FF9900; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; height: 20px; width: 75px; background-color: #FFFFFF; cursor: hand} 
.bt2 {  font-size:10pt; color:#FFFFFF; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; height: 17px; width: 45px; background-color: #666666; cursor: hand} 
.bt21 {  font-size:10pt; color:#FFFFFF; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; height: 17px; width: 45px; background-color: #FF5151; cursor: hand} 
.bt22 {  font-size:10pt; color:#000000; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; height: 17px; width: 55px; background-color: #FF9900; cursor: hand} 
.bt23 {  font-size:10pt; color:#000000; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; height: 17px; width: 82px; background-color: #FF9900; cursor: hand} 
.bt3 {  font-size:10pt; color:#0000FF; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; height: 20px; width: 120px; cursor: hand}
.bt4 {  font-size:10pt; color:#FFFFFF; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; height: 20px; width: 100px; background-color: #FF0000; cursor: hand} 
.tx1 { height: 20px; width: 30px; font-size: 10pt; border: 1px solid; border-color: black black #000000; color: #0000FF} 

.border-und {
	BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT: black 0px solid; BORDER-RIGHT: black 0px solid; BORDER-TOP: black 0px solid
}
.menutitle{
cursor:pointer;
margin-bottom: 3px;
background-color:#A6C4E1;
color:#000000;
width:142px;
padding:3px;
text-align:center;
border:1px solid #DCE8F3;
}
.submenu{
margin-bottom: 5px;
}
</style>
			<title>欣欣網站管理系統</title>
	</head>
	<script language="JavaScript" src="../inc/utility.js"></script>
	<link rel="stylesheet" type="text/css" media="all" href="../inc/calendar-win2k-cold-1.css"
		title="win2k-cold-1" />
	<script type="text/javascript" src="../inc/calendar.js"></script>
	<script type="text/javascript" src="../inc/lang/calendar-tw.js"></script>
	<script type="text/javascript" src="../inc/calendar-setup.js"></script>
	<script language="javascript">
<!--
function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}
function newin(width,height,url,name) 
{
	msgWindow=window.open(url,name,'statusbar=no,scrollbars=yes,status=yes,resizable=yes,width='+width+',height='+height);
}
function confirmDelete(){     
    if (confirm("您確定要刪除?"))
    return true;
    else return false;   
}
function ym_onchange(yy,mm,dd) {
     var month, year, day ;
     day = dd.selectedIndex ; 
     month = mm.options[mm.selectedIndex].value ;
     year = yy.options[yy.selectedIndex].value ;
     if (month == "1" || month == "3" || month == "5" || month == "7" || month == "8" || month == "10" || month == "12")     {
          for(i=1;i<=31;i++) {
              dd.options[i-1] = new Option(i);
              dd.options[i-1].value = i;
         }
          dd.length = "31" ;
     }
     if (month == "4" || month == "6" || month == "9" || month == "11") {
          for(i=1;i<=30;i++) {
              dd.options[i-1] = new Option(i);
              dd.options[i-1].value = i ;
         }
          dd.length = "30" ;
     }
     if (month == "2") {
         if (year%4 > 0)     {
              for(i=1;i<=28;i++) {
                   dd.options[i-1] = new Option(i);
                   dd.options[i-1].value = i;
              }
              dd.length = "28" ;
         }
         if (year%4 == 0)     {
              if ((year%100 == 0) && (year%400 > 0))    {
                   for(i=1;i<=28;i++) {
                        dd.options[i-1] = new Option(i);
                        dd.options[i-1].value = i;
                   }
                   dd.length = "28" ;                             
              }
              if ((year%100 > 0) || (year%400 == 0))  {
                   for(i=1;i<=29;i++) {
                        dd.options[i-1] = new Option(i);
                        dd.options[i-1].value = i;
                   }
                   dd.length = "29" ;           
              }
         }
     }
     if (dd.length < day + 1)      {
          dd.selectedIndex = dd.length-1 ;
     }
     else {
          dd.selectedIndex = day ;
     }
}
function isfilled(elmt){     
    if (elmt.value =="" || elmt.value==null)
    return false;
    else return true;   
}
function isemail(elm){    
    if(elm.value.indexOf("@") != "-1" &&
       elm.value.indexOf("@") != "0" &&
       elm.value.indexOf("@") == elm.value.lastIndexOf("@")&&      
       elm.value.indexOf(".") != "-1" &&       
       elm.value.lastIndexOf(".")!=elm.value.length-1)
    return true;
    else return false;
}
function selectAll(v) {
	f = document.form1
	n = f.elements.length
	for (i=0; i < n; i++) {
		if (f.elements[i].name == "del[]") {
			f.elements[i].checked = v;
		}
	}
	
}
-->
	</script>
	<script type="text/javascript">

/***********************************************
* Switch Menu script- by Martial B of http://getElementById.com/
* Modified by Dynamic Drive for format & NS4/IE4 compatibility
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

if (document.getElementById){ //DynamicDrive.com change
document.write('<style type="text/css">\n')
document.write('.submenu{display: none;}\n')
document.write('</style>\n')
}

function SwitchMenu(obj){
	if(document.getElementById){
	var el = document.getElementById(obj);
	var ar = document.getElementById("masterdiv").getElementsByTagName("span"); //DynamicDrive.com change
		if(el.style.display != "block"){ //DynamicDrive.com change
			for (var i=0; i<ar.length; i++){
				if (ar[i].className=="submenu") //DynamicDrive.com change
				ar[i].style.display = "none";
			}
			el.style.display = "block";
		}else{
			el.style.display = "none";
		}
	}
}

	</script>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td width="110">&nbsp;</td>
				<td width="930"><table width="100%" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td><img src="images/logo.gif" border="0"></td>
							<td>&nbsp;</td>
							<td align="center"></td>
						</tr>
						<tr>
							<td width="33%">&nbsp;</td>
							<td width="50%">&nbsp;</td>
							<td width="17%"><div align="center"></div>
							</td>
						</tr>
					</table>
				</td>
				<td width="132">&nbsp;</td>
			</tr>
			<tr>
				<td bgcolor="#6699CC"><img src="images/bg01.gif" width="8" height="20"></td>
				<td width="930" bgcolor="#6699CC"><table width="100%" border="0">
						<tr align="center">
							<td width="40%" align="left">&nbsp;</td>
							<td width="30%">&nbsp;</td>
							<td width="12%">&nbsp;</td>
							<td width="8%">&nbsp;</td>
							<td width="10%"><a href="logout.aspx"><font color="#FFFFFF">[&nbsp;登出系統&nbsp;]</font></a></td>
						</tr>
					</table>
				</td>
				<td bgcolor="#6699CC">&nbsp;</td>
			</tr>
			<tr>
				<td height="1" colspan="3" bgColor="#000000"><IMG alt="" border="0" height="1" src="images/spacer.gif" width="4"></td>
			</tr>
<!-- // END: header.tpl // -->


<%@ Control CodeBehind="_NewMenu.ascx.vb" Language="vb" AutoEventWireup="false" Inherits="__NewMenu" %>
<div id="masterdiv">
	<%
dim conn 
dim strConn,struid,strpassword
dim qrysql
dim rs
Conn=Server.CreateObject("ADODB.Connection")
   strConn="DSN=eiis"
   strUID="eiis"
   strPassword="eiisdba" 
   CONN.Open(strConn,strUID,strPassword)
'----------
RS = Server.CreateObject("ADODB.Recordset") 
RS.CursorLocation = 3 
'--------------------   
   QrySQL ="Select * From sysfunctionmaster"
RS.Open(QrySQL, CONN, 1, 1)
do while not rs.eof
	response.write(rs.fields("functionid").value & "<br/>")
	rs.movenext
loop
rs.close
conn.close

    if Session("Usergrp") = 1 then
    %>
	<span class="submenu" id="sub1"></span>
	<div class="menutitle" onclick="SwitchMenu('sub2')">系統帳號管理</div>
	<span class="submenu" id="sub2">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="admin.aspx"><font color="#ffffff">管理者帳號</font></a><br>
	</span>
	<%
	End if
	%>
	<div class="menutitle" onclick="SwitchMenu('sub3')">首頁資料管理</div>
	<span class="submenu" id="sub3">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="hotnews.aspx"><font color="#ffffff">最新消息管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="information.aspx"><font color="#ffffff">公司訊息管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="workinfor.aspx"><font color="#ffffff">施工通告管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="stopinfor.aspx"><font color="#ffffff">停氣公告管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="message.aspx"><font color="#ffffff">跑馬燈管理</font></a><br>
	</span>
	<!--
	<div class="menutitle" onclick="SwitchMenu('sub4')">用戶服務管理</div>
	<span class="submenu" id="sub4">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="#"><font color="#ffffff">新用戶申請查詢</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="#"><font color="#ffffff">裝/復/拆表申請</font></a><br>
	</span>
	</div>
	-->
	<div class="menutitle" onclick="SwitchMenu('sub5')">下載專區管理</div>
	<span class="submenu" id="sub5">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="download_grp.aspx"><font color="#ffffff">下載群組管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="download_item.aspx"><font color="#ffffff">下載資料管理</font></a><br>
	</span>
</div>
<div class="menutitle" onclick="SwitchMenu('sub6')">產品管理</div>
<span class="submenu" id="sub6">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="product_grp.aspx"><font color="#ffffff">產品群組管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="product_item.aspx"><font color="#ffffff">產品資料管理</font></a><br>
	</span>
<DIV></DIV>
<div class="menutitle" onclick="SwitchMenu('sub7')">常見問題(FAQ)管理</div>
<span class="submenu" id="sub7">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="faq_grp.aspx"><font color="#ffffff">問題群組管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="faq_item.aspx"><font color="#ffffff">問題資料管理</font></a><br>
	</span>
<DIV></DIV>
<div class="menutitle" onclick="SwitchMenu('sub8')"><a href="contact.aspx">意見申訴查詢</a></div>
<span class="submenu" id="sub1"></span>
<DIV></DIV>
<div class="menutitle" onclick="SwitchMenu('sub9')">投資人訊息管理</div>
<span class="submenu" id="sub9">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_01.aspx"><font color="#ffffff">財務資訊管理</font></a><br>
		<!-- &nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_02.aspx"><font color="#ffffff">股利政策管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_03.aspx"><font color="#ffffff">股本形成經過管理</font></a><br> -->
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_04.aspx"><font color="#ffffff">股利發放情形管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_05.aspx"><font color="#ffffff">除權(息)資訊管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_06.aspx"><font color="#ffffff">重要決議事項管理</font></a><br>
		<!-- &nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_07.aspx"><font color="#ffffff">公司治理管理</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="invest_08.aspx"><font color="#ffffff">股務代理機構管理</font></a><br> -->
	</span>
<div class="menutitle" onclick="SwitchMenu('sub10')">用戶服務管理</div>
<span class="submenu" id="sub10">&nbsp;&nbsp; <img src="images/arrow.gif"><a href="user_01.aspx"><font color="#ffffff">新用戶申請查詢</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="user_02.aspx"><font color="#ffffff">自報度數查詢</font></a><br>
		&nbsp;&nbsp; <img src="images/arrow.gif"><a href="user_03.aspx"><font color="#ffffff">電子對帳單申請查詢</font></a><br>
	</span>
<DIV></DIV>

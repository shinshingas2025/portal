<%@ Page CodeBehind="recent_sucess.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="recent_sucess" %>
<HTML>
	<HEAD>
		<title>欣欣天然氣股份有限公司</title>
		<META http-equiv="Content-Type" content="text/html; charset=big5">
		<LINK media="screen" href="content.css" type="text/css" rel="stylesheet">
			<SCRIPT language="JavaScript1.2" src="navbar.js" type="text/javascript"></SCRIPT>
			<STYLE type="text/css">.style6 { FONT-SIZE: 14px; COLOR: #000000 }
	</STYLE>
	</HEAD>
	<BODY>
		<DIV id="wrapper">
			<DIV id="hader">
				<DIV id="logo"><A href="index.aspx"><IMG height="46" alt="欣欣天然氣股份有限公司商標" src="images/hader_logo.gif" width="274" border="0"></A></DIV>
				<DIV class="item" id="searchBar">
					<script language="JavaScript" src="topmenu.js" type="text/javascript"></script>
				</DIV>
			</DIV>
		</DIV>
		<DIV id="image"><IMG height="100" alt="Inside Image" src="images/inside_image.jpg" width="780"></DIV>
		<DIV id="content">
			<DIV id="navBar">
				<SCRIPT language="JavaScript" src="menu.js" type="text/javascript"></SCRIPT>
				<A href="index.aspx"><IMG height="39" alt="回首頁" src="images/index.jpg" width="73" border="0"></A>&nbsp;</DIV>
			<DIV id="main">
			<% If Session("wm_id") <> "" Then %>
				<SCRIPT language="JavaScript" src="topmenu_erso.js" type="text/javascript"></SCRIPT>
			<% else %>
				<SCRIPT language="JavaScript" src="topmenu_ers.js" type="text/javascript"></SCRIPT>
			<% end if %>
				<DIV id="topic">
					<P class="topic">會員服務 &gt; 重寄授權碼</P>
				</DIV>
				<DIV id="sub">
					<DIV align="center">
						<DIV class="style1" id="Div1" align="center"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
							<P align="center"><BR>
								<BR>
								授權碼己重新寄至您所申請的郵件信箱!
							</P>
							
								<BR>
								<BR>
								<BR>
								<BR>
								<BR>
								<BR>
								<BR>
								<BR>
								<BR>
						</DIV>
					</DIV>
				</DIV>
			</DIV>
		</DIV>
		<DIV id="footer"><IMG height="47" alt="版權宣告" src="images/copyright.gif" width="780"></DIV>
	</BODY>
</HTML>

<%@ Import Namespace="System.Web.Mail" %>
<%@ Page CodeBehind="recent.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="recent" %>
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
						<form id="form1" runat="server">
							<P><FONT face="新細明體"></FONT>&nbsp;</P>
							<TABLE class="p1" borderColor="#ffffff" cellSpacing="0" cellPadding="2" width="90%" border="1">
								<TR>
									<TD width="202" bgColor="#1d459c" height="33">
										<DIV align="left">請輸入註冊時所填的電子信箱：
										</DIV>
									</TD>
									<TD bgColor="#cccccc" height="33">
										<DIV align="left"><asp:textbox id="txtWmEmail" runat="server" Width="216px"></asp:textbox><asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="(必填欄位)"
												ControlToValidate="txtWmEmail"></asp:RequiredFieldValidator><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtWmEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
												ErrorMessage="RegularExpressionValidator">(格式不符)</asp:regularexpressionvalidator></DIV>
									</TD>
								</TR>
							</TABLE>
							<P><asp:label id="message" runat="server" ForeColor="Red"></asp:label></P>
					</DIV>
					<DIV align="center">
						<TABLE cellSpacing="0" cellPadding="0" width="50%" border="0">
							<TR>
								<TD vAlign="middle" height="24">
									<div align="center"><asp:button id="btnOK" runat="server" Width="73px" Text="確認送出" CssClass="button" BorderStyle="Solid"
											Height="18px"></asp:button></div>
								</TD>
								<TD height="24">
									<div align="center"><asp:button id="btnReset" runat="server" Width="73px" Text="清除重填" CssClass="button" CausesValidation="False"
											BorderStyle="Solid" Height="18px"></asp:button>&nbsp;</div>
								</TD>
							</TR>
						</TABLE>
					</DIV>
					<DIV align="center"><FONT face="新細明體"></FONT>&nbsp;</DIV>
					<DIV align="center"><FONT face="新細明體"></FONT>&nbsp;</DIV>
					<DIV align="center"><FONT face="新細明體"></FONT>&nbsp;</DIV>
					<DIV align="center"><FONT face="新細明體"></FONT>&nbsp;</DIV>
					<DIV align="center">&nbsp;</DIV>
					<DIV align="center">
						<BR>
					</DIV>
				</DIV>
			</DIV>
		</DIV>
		<DIV id="footer"><IMG height="47" alt="版權宣告" src="images/copyright.gif" width="780"></DIV>
		</FORM>
	</BODY>
</HTML>

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditUserInfo.aspx.vb" Inherits="EditUserInfo" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UserInfoView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body  leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form id="Form1" method="post" runat="server">
			<uc1:DesktopPortalBanner id="DesktopPortalBanner1" runat="server"></uc1:DesktopPortalBanner>
			<table cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=114 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          style="WIDTH: 114px"><asp:label id="Label7" runat="server" CssClass="head">編輯個人資料</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' ></td>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif' ></td>
					</tr>
					<tr>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' ></td>
						<td bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<!---------------------------------------------------------------------------------------------------------------------->
											<TABLE class="TTable1" id="Table1" cellSpacing="1" cellPadding="1" width="504" align="center"
												border="0">
												<TR>
													<TD style="HEIGHT: 26px"><FONT face="新細明體" size="2" color="#ff0000">使用者ID</FONT></TD>
													<TD style="HEIGHT: 26px"><asp:textbox id="txtUID" runat="server" Width="150px"></asp:textbox><asp:label id="lblUID" runat="server"></asp:label><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px; HEIGHT: 26px"><FONT face="新細明體" size="2">
															<asp:Label id="lblSeqno" runat="server">次序</asp:Label></FONT></TD>
													<TD style="HEIGHT: 26px" colSpan="3"><FONT face="新細明體"><FONT size="2"><asp:textbox id="txtSeqno" runat="server" Width="50px">1</asp:textbox></FONT></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2" color="#ff0000">中文姓名</FONT></TD>
													<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtCname" runat="server" Width="296px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtCname" ErrorMessage="*"></asp:requiredfieldvalidator><FONT size="2"></FONT></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">類別</FONT></TD>
													<TD><asp:dropdownlist id="selU_Class" runat="server">
															<asp:ListItem Value="0">類別</asp:ListItem>
															<asp:ListItem Value="1">類別一</asp:ListItem>
															<asp:ListItem Value="2">類別二</asp:ListItem>
															<asp:ListItem Value="3">類別三</asp:ListItem>
															<asp:ListItem Value="4">類別四</asp:ListItem>
															<asp:ListItem Value="5">類別五</asp:ListItem>
															<asp:ListItem Value="6">類別六</asp:ListItem>
															<asp:ListItem Value="7">類別七</asp:ListItem>
															<asp:ListItem Value="8">類別八</asp:ListItem>
															<asp:ListItem Value="9">類別九</asp:ListItem>
														</asp:dropdownlist><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">客戶編號</FONT></TD>
													<TD><asp:textbox id="txtAlias" runat="server" Width="150px" MaxLength="4" Enabled="False"></asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">英文姓名</FONT></TD>
													<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtEname" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">身份證號 </FONT>
													</TD>
													<TD><asp:textbox id="txtIDNum" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">姓別</FONT></TD>
													<TD><asp:dropdownlist id="selSex" runat="server">
															<asp:ListItem Value="1" Selected="True">男</asp:ListItem>
															<asp:ListItem Value="0">女</asp:ListItem>
														</asp:dropdownlist><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT size="2">郵遞區號</FONT></TD>
													<TD><asp:textbox id="txtAddr_zip" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px"><FONT size="2">縣市</FONT></TD>
													<TD><asp:textbox id="txtAddr_div" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 18px"><FONT size="2">鄉鎮市區</FONT></TD>
													<TD style="HEIGHT: 18px"><asp:textbox id="txtAddr_vil" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px; HEIGHT: 18px"><FONT size="2">國家</FONT></TD>
													<TD style="HEIGHT: 18px"><asp:textbox id="txtnation" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT size="2">街路號</FONT></TD>
													<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtAddr_door" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
												</TR>
												<TR>
													<TD colSpan="4"><FONT face="新細明體" size="2">
															<HR width="100%" color="#000000" SIZE="1">
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 28px"><FONT size="2">公司</FONT></TD>
													<TD style="HEIGHT: 28px" colSpan="3"><FONT face="新細明體"><asp:textbox id="txtCompany" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
												</TR>
												<TR>
													<TD><FONT size="2">行動電話</FONT></TD>
													<TD><asp:textbox id="txtTelmobile" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px"><FONT size="2">電話(公)</FONT></TD>
													<TD><asp:textbox id="txtTelcompany" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT size="2">電話(家)</FONT></TD>
													<TD><FONT face="新細明體"><asp:textbox id="txtTelhome" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
													<TD style="WIDTH: 60px"><FONT face="新細明體" size="2">部門</FONT></TD>
													<TD><asp:textbox id="txtDept" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">職稱</FONT></TD>
													<TD><asp:textbox id="txttitle" runat="server" Width="150px"></asp:textbox><FONT size="2"></FONT></TD>
													<TD style="WIDTH: 60px"><FONT size="2">mask</FONT></TD>
													<TD><asp:textbox id="txtmask" runat="server" Width="50px">0</asp:textbox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">網站</FONT></TD>
													<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtHomepage" runat="server" Width="304px"></asp:textbox><FONT size="2"></FONT></FONT></TD>
												</TR>
												<TR>
													<TD><FONT face="新細明體" size="2">電子郵件</FONT></TD>
													<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtEmail" runat="server" Width="304px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD align="right" colSpan="4"><FONT face="新細明體">
															<asp:Label id="txtState" runat="server"></asp:Label>
															<asp:Button id="btneditpassword" runat="server" Text="修改密碼"></asp:Button><asp:button id="btnAdd" runat="server" Text="確定"></asp:button></FONT></TD>
												</TR>
											</TABLE>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV></DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
					</tr>
					<tr>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>

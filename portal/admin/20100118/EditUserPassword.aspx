<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditUserPassword.aspx.vb" Inherits="EditUserPassword" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AccountMgtView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<uc1:DesktopPortalBanner id="DesktopPortalBanner1" runat="server"></uc1:DesktopPortalBanner>
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=114 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          style="WIDTH: 114px"><asp:label id="Label7" runat="server" CssClass="head">修改密碼</asp:label></td>
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
											<TABLE id="Table1" cellSpacing="1" borderColorDark="black" cellPadding="1" width="100%"
												border="0" class="TTable1">
												<TR>
													<TD style="WIDTH: 90px; HEIGHT: 32px"><asp:Label id="Label1" runat="server" CssClass="subhead">帳號</asp:Label></TD>
													<TD style="WIDTH: 145px; HEIGHT: 32px" colSpan="2">
														<asp:Label id="txtLoginID" runat="server"></asp:Label><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 90px; HEIGHT: 23px">
														<asp:Label id="Label2" runat="server" CssClass="subhead">舊密碼</asp:Label></TD>
													<TD style="WIDTH: 145px; HEIGHT: 23px" colSpan="2">
														<asp:TextBox id="txtOldPassword" runat="server" Width="160px" TextMode="Password"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 90px; HEIGHT: 23px">
														<asp:Label id="Label3" runat="server" CssClass="subhead">新密碼</asp:Label></TD>
													<TD style="WIDTH: 145px; HEIGHT: 23px" colSpan="2">
														<asp:TextBox id="txtPassword1" runat="server" Width="160px" TextMode="Password"></asp:TextBox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 90px">
														<asp:Label id="Label4" runat="server" CssClass="subhead">新密碼確認</asp:Label></TD>
													<TD style="WIDTH: 145px" colSpan="2">
														<asp:TextBox id="txtPassword2" runat="server" Width="160px" TextMode="Password"></asp:TextBox><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 93px" align="left" colSpan="2"></TD>
													<TD style="WIDTH: 125px" align="right">
														<asp:Button id="btnAdd" runat="server" Text="確定"></asp:Button><INPUT type="reset" value="清除"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 93px" align="left" colSpan="3">
														<asp:Label id="txtResult" runat="server" ForeColor="Red" Font-Size="X-Small" Width="224px"></asp:Label></TD>
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

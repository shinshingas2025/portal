<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ImportExportAdmin.aspx.vb" Inherits="ASPNET.StarterKit.Portal.ImportExportAdmin" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P><FONT face="新細明體"></FONT>&nbsp;</P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="60%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">匯出匯入管理</asp:label></td>
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
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
											border="0">
											<tr>
												<td align="center"><asp:label id="Label4" runat="server" CssClass="subhead">匯入</asp:label></td>
												<td align="center"><asp:label id="Label6" runat="server" CssClass="subhead">匯出</asp:label></td>
											</tr>
											<tr>
												<td align="center">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="79"><asp:label id="Label2" runat="server" CssClass="subhead">主題</asp:label></td>
															<td><asp:textbox id="TextBoxImportTitle" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td width="79"><asp:label id="Label3" runat="server" CssClass="subhead">內容</asp:label></td>
															<td><asp:textbox id="TextBoxImportDescription" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td align="center" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																	<tr>
																		<td><asp:button id="ButtonImportInsert" runat="server" Text="新增"></asp:button></td>
																		<td><asp:button id="ButtonImportUpdate" runat="server" Text="修改"></asp:button></td>
																		<td><asp:button id="ButtonImportDelete" runat="server" Text="刪除"></asp:button></td>
																		<td><asp:button id="ButtonImportColumnEdit" runat="server" Text="修改匯入欄位"></asp:button></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
												<td align="center">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="79"><asp:label id="Label1" runat="server" CssClass="subhead">主題</asp:label></td>
															<td><asp:textbox id="TextBoxExportTitle" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td width="79"><asp:label id="Label5" runat="server" CssClass="subhead">內容</asp:label></td>
															<td><asp:textbox id="TextBoxExportDescription" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td align="center" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																	<tr>
																		<td><asp:button id="ButtonExportInsert" runat="server" Text="新增"></asp:button></td>
																		<td><asp:button id="ButtonExportUpdate" runat="server" Text="修改"></asp:button></td>
																		<td><asp:button id="ButtonExportDelete" runat="server" Text="刪除"></asp:button></td>
																		<td><asp:button id="ButtonExportColumnEdit" runat="server" Text="修改匯出欄位"></asp:button></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</TABLE>
										<!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
								<tr>
									<td align="center">
										<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
								</tr>
							</TABLE>
						</td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></td>
					</tr>
					<tr>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ></td>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>

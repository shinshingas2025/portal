<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page validateRequest="false" language="vb" CodeBehind="EditPrivateAnnouncement.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditPrivateAnnouncement" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server" />
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">詳細資料</asp:label></td>
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
											<table width="100%" cellspacing="0" cellpadding="0" border="0">
												<tr>
													<td>
														<br>
														<table width="98%" cellspacing="0" cellpadding="4" border="0">
															<tr valign="top">
																<td width="100">
																	&nbsp;
																</td>
																<td width="*">
																	<table width="750" cellspacing="0" cellpadding="0">
																		<tr>
																			<td align="left" class="Head">
																				HTML 設定
																			</td>
																		</tr>
																		<tr>
																			<td colspan="2">
																				<hr noshade size="1">
																			</td>
																		</tr>
																	</table>
																	<table width="720" cellspacing="0" cellpadding="0">
																		<tr valign="top">
																			<td class="SubHead">
																				桌面 HTML 內容:
																			</td>
																			<td>
																				&nbsp;&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="DesktopText" columns="75" width="650" rows="12" textmode="multiline" runat="server" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				行動摘要 (選擇項):
																			</td>
																			<td>
																				&nbsp;&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="MobileSummary" columns="75" width="650" rows="3" textmode="multiline" runat="server" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				行動詳細資料 (選擇項):
																			</td>
																			<td>
																				&nbsp;&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="MobileDetails" columns="75" width="650" rows="5" textmode="multiline" runat="server" />
																			</td>
																		</tr>
																	</table>
																	<p>
																		<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
																		&nbsp;
																		<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
																			borderstyle="none" />
																		&nbsp;
																	</p>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
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
				</TBODY></table>
		</form>
	</body>
</HTML>

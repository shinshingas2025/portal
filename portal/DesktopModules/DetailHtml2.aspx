<%@ Page validateRequest="false" language="vb" CodeBehind="DetailHtml2.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.DetailHtml2" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner><FONT face="新細明體"><BR>
				<BR>
			</FONT>
			<table cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
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
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td><br>
														<table cellSpacing="0" cellPadding="4" width="98%" border="0">
															<tr vAlign="top">
																<td width="8">&nbsp;
																</td>
																<td width="*">
																	<table cellSpacing="0" cellPadding="0" width="100%">
																		<tr>
																			<td colSpan="2"><FONT face="新細明體"></FONT><FONT face="新細明體">
																					<asp:Literal id="literdesktop" runat="server"></asp:Literal></FONT>
																			</td>
																		</tr>
																	</table>
																	<table cellSpacing="0" cellPadding="0" width="100%">
																		<tr vAlign="top">
																			<td class="SubHead" width="72">&nbsp;
																			</td>
																			<td vAlign="middle" align="center" width="178"><FONT face="新細明體"></FONT></td>
																			<TD vAlign="top" class="SubHead" align="left" width="79"><FONT face="新細明體"></FONT>
																			</TD>
																			<td vAlign="top" align="left"><FONT face="新細明體"></FONT></td>
																		</tr>
																		<TR>
																			<TD class="SubHead" vAlign="top" colSpan="4"><FONT face="新細明體">
																					<HR width="100%" SIZE="1">
																				</FONT>
																			</TD>
																		</TR>
																		<TR>
																			<TD class="SubHead" width="72" valign="top"><FONT face="新細明體"><asp:image id="Image1" runat="server"></asp:image></FONT></TD>
																			<TD width="264" colSpan="3" vAlign="top" align="left"><FONT face="新細明體">
																					<asp:Literal id="literDetail" runat="server"></asp:Literal></FONT></TD>
																		</TR>
																		<!--tr valign="top">
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
										</tr--></table>
																	<p align="center">&nbsp;&nbsp;&nbsp;
																		<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
																			<TR>
																				<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																				<TD 
                            background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																					<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" borderstyle="none" text="取消"
																						causesvalidation="False">
										返回</asp:linkbutton></TD>
																				<TD width="1"><IMG 
                              src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																			</TR>
																		</TABLE>
																	</p>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table> <!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
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
				</TBODY></table>
		</form>
	</body>
</HTML>

<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="EditWebSiteMgt.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditWebSiteMgt" %>
<HTML>
	<HEAD>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner>
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">新增學校網站</asp:label></td>
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
													<td><asp:label id="lblmsg" runat="server" CssClass="normalred"></asp:label><br>
														<table cellSpacing="0" cellPadding="4" width="98%" border="0">
															<tr vAlign="top">
																<td width="150">&nbsp;
																</td>
																<td align="center" width="*">
																	<table cellSpacing="0" cellPadding="0" width="750" border="0">
																		<TR>
																			<TD class="SubHead" width="100" height="8">學校所屬區域</TD>
																			<TD height="8"></TD>
																			<TD height="8"><asp:dropdownlist id="dlarea" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
																			<TD width="25" height="8"></TD>
																			<TD class="Normal" width="250" height="8"></TD>
																		</TR>
																		<tr>
																			<td class="SubHead" width="100" height="2">學校名稱:
																			</td>
																			<td rowSpan="5">&nbsp;
																			</td>
																			<td height="2"><asp:dropdownlist id="txtSchool" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
																			<td width="25" rowSpan="5">&nbsp;
																			</td>
																			<td class="Normal" width="250" height="2"></td>
																		</tr>
																		<tr>
																			<td class="SubHead"><FONT face="新細明體"></FONT><FONT face="新細明體">網域名稱</FONT></td>
																			<td><FONT face="新細明體">
																					<asp:dropdownlist id="dlDN" runat="server" AutoPostBack="True"></asp:dropdownlist></FONT></td>
																			<td class="Normal"></td>
																		</tr>
																	</table>
																	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="150" border="0">
																		<TR>
																			<TD>
																				<table cellSpacing="0" cellPadding="0" border="0">
																					<TR>
																						<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></TD>
																						<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                                ><asp:linkbutton id="updateButton" runat="server" borderstyle="none" text="更新" cssclass="CommandButton">新增</asp:linkbutton></TD>
																						<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></TD>
																					</TR>
																				</table>
																			</TD>
																			<TD>
																				<table cellSpacing="0" cellPadding="0" border="0">
																					<TR>
																						<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></TD>
																						<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                                ><asp:linkbutton id="cancelButton" runat="server" borderstyle="none" text="取消" cssclass="CommandButton"
																								causesvalidation="False"></asp:linkbutton></TD>
																						<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></TD>
																					</TR>
																				</table>
																			</TD>
																			<TD></TD>
																		</TR>
																	</TABLE>
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
				</TBODY></table>
		</form>
	</body>
</HTML>

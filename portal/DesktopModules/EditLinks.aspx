<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="EditLinks.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditLinks" %>
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
          ><asp:label id="Label7" runat="server" CssClass="head">連結詳細資料</asp:label></td>
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
																<td width="150">
																	&nbsp;
																</td>
																<td width="*" align="center">
																	<table width="500" cellspacing="0" cellpadding="0">
																		<tr>
																			<td align="left" class="Head"><FONT face="新細明體"></FONT>
																			</td>
																		</tr>
																		<tr>
																			<td colspan="2"><FONT face="新細明體"></FONT>
																			</td>
																		</tr>
																	</table>
																	<table width="750" cellspacing="0" cellpadding="0" border="0">
																		<tr>
																			<td width="100" class="SubHead">
																				標題:
																			</td>
																			<td rowspan="5">
																				&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="TitleField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150"
																					runat="server" />
																			</td>
																			<td width="25" rowspan="5">
																				&nbsp;
																			</td>
																			<td class="Normal" width="250">
																				<asp:requiredfieldvalidator id="Req1" display="Static" errormessage="您必須輸入有效標題" controltovalidate="TitleField"
																					runat="server" />
																			</td>
																		</tr>
																		<tr>
																			<td class="SubHead">
																				URL:
																			</td>
																			<td>
																				<asp:textbox id="UrlField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150"
																					runat="server" />
																			</td>
																			<td class="Normal">
																				<asp:requiredfieldvalidator id="Req2" display="Static" runat="server" errormessage="您必須輸入有效 URL" controltovalidate="UrlField" />
																			</td>
																		</tr>
																		<!--tr>
											<td class="SubHead">
												行動 URL:
											</td>
											<td>
												<asp:textbox id="MobileUrlField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150" runat="server" />
											</td>
											<td>
												&nbsp;
											</td>
										</tr-->
																		<tr>
																			<td class="SubHead">
																				說明:
																			</td>
																			<td>
																				<asp:textbox id="DescriptionField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150"
																					runat="server" Height="160px" />
																			</td>
																			<td>
																				&nbsp;
																			</td>
																		</tr>
																		<tr>
																			<td class="SubHead">
																				檢視順序:
																			</td>
																			<td>
																				<asp:textbox id="ViewOrderField" cssclass="NormalTextBox" width="24px" columns="30" maxlength="3"
																					runat="server" />
																			</td>
																			<td class="Normal">
																				<asp:requiredfieldvalidator display="Static" id="RequiredViewOrder" runat="server" controltovalidate="ViewOrderField"
																					errormessage="您必須輸入有效檢視順序" />
																				<asp:comparevalidator display="Static" id="VerifyViewOrder" runat="server" operator="DataTypeCheck" controltovalidate="ViewOrderField"
																					type="Integer" errormessage="您必須輸入有效檢視順序" />
																			</td>
																		</tr>
																	</table>
																	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="150" border="0">
																		<TR>
																			<TD>
																				<table border="0" cellspacing="0" cellpadding="0">
																					<TR>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																						<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																							<asp:linkbutton id="updateButton" runat="server" cssclass="CommandButton" borderstyle="none" text="更新"></asp:linkbutton></TD>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																					</TR>
																				</table>
																			</TD>
																			<TD>
																				<table border="0" cellspacing="0" cellpadding="0">
																					<TR>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																						<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																							<asp:linkbutton id="cancelButton" runat="server" cssclass="CommandButton" borderstyle="none" text="取消"
																								causesvalidation="False"></asp:linkbutton></TD>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																					</TR>
																				</table>
																			</TD>
																			<TD>
																				<table border="0" cellspacing="0" cellpadding="0">
																					<TR>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																						<TD 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																							<asp:linkbutton id="deleteButton" runat="server" cssclass="CommandButton" borderstyle="none" text="刪除此項目"
																								causesvalidation="False"></asp:linkbutton></TD>
																						<TD width="1"><IMG 
                                src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																					</TR>
																				</table>
																			</TD>
																		</TR>
																	</TABLE>
																	<hr noshade size="1" width="500">
																	<span class="Normal">建立者
                                            <asp:label id="CreatedBy" runat="server" />
                                            建立日期
                                            <asp:label id="CreatedDate" runat="server" />
                                            <br>
                                        </span>
																	<p><FONT face="新細明體"></FONT>
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

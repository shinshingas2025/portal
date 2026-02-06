<%@ Page language="vb" CodeBehind="EditEvents.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditEvents" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
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
          ><asp:label id="Label7" runat="server" CssClass="head">內容</asp:label></td>
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
																	<table width="500" cellspacing="0" cellpadding="0">
																		<tr>
																			<td align="left" class="Head">
																				資料
																			</td>
																		</tr>
																		<tr>
																			<td colspan="2">
																				<hr noshade size="1">
																			</td>
																		</tr>
																	</table>
																	<table width="750" cellspacing="0" cellpadding="0">
																		<tr valign="top">
																			<td width="100" class="SubHead">
																				標題:
																			</td>
																			<td rowspan="4">
																				&nbsp;
																			</td>
																			<td>
																				<asp:textbox id="TitleField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150"
																					runat="server" />
																			</td>
																			<td width="25" rowspan="4">
																				&nbsp;
																			</td>
																			<td class="Normal" width="250">
																				<asp:requiredfieldvalidator display="Static" runat="server" errormessage="您必須輸入有效標題" controltovalidate="TitleField"
																					id="Requiredfieldvalidator1" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				說明:
																			</td>
																			<td>
																				<asp:textbox id="DescriptionField" textmode="Multiline" width="390" columns="44" rows="6" runat="server" />
																			</td>
																			<td class="Normal">
																				<asp:requiredfieldvalidator display="Static" runat="server" errormessage="您必須輸入有效說明" controltovalidate="DescriptionField"
																					id="Requiredfieldvalidator2" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				位置/時間:
																			</td>
																			<td>
																				<asp:textbox id="WhereWhenField" cssclass="NormalTextBox" width="390" columns="30" maxlength="150"
																					runat="server" />
																			</td>
																			<td class="Normal">
																				<asp:requiredfieldvalidator display="Static" runat="server" errormessage="您必須輸入有效時間/位置" controltovalidate="WhereWhenField"
																					id="Requiredfieldvalidator3" />
																			</td>
																		</tr>
																		<tr valign="top">
																			<td class="SubHead">
																				到期:
																			</td>
																			<td>
																				<asp:textbox id="ExpireField" text="" cssclass="NormalTextBox" width="100" columns="8" runat="server" />
																				<asp:Button id="Button1" runat="server" Text="選擇"></asp:Button>
																				<asp:Calendar id="Calendar1" runat="server" BorderWidth="1px" BackColor="White" Width="220px"
																					DayNameFormat="FirstLetter" ForeColor="#003399" Height="200px" Font-Size="8pt" Font-Names="Verdana"
																					BorderColor="#3366CC" CellPadding="1" Visible="False">
																					<TodayDayStyle ForeColor="White" BackColor="#99CCCC"></TodayDayStyle>
																					<SelectorStyle ForeColor="#336666" BackColor="#99CCCC"></SelectorStyle>
																					<NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
																					<DayHeaderStyle Height="1px" ForeColor="#336666" BackColor="#99CCCC"></DayHeaderStyle>
																					<SelectedDayStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedDayStyle>
																					<TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="#CCCCFF"
																						BorderStyle="Solid" BorderColor="#3366CC" BackColor="#003399"></TitleStyle>
																					<WeekendDayStyle BackColor="#CCCCFF"></WeekendDayStyle>
																					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
																				</asp:Calendar>
																			</td>
																			<td class="Normal">
																				<asp:requiredfieldvalidator display="Static" id="RequiredExpireDate" runat="server" errormessage="您必須輸入有效到期日"
																					controltovalidate="ExpireField" />
																				<asp:comparevalidator display="Static" id="VerifyExpireDate" runat="server" operator="DataTypeCheck" controltovalidate="ExpireField"
																					type="Date" errormessage="您必須輸入有效到期日" />
																			</td>
																		</tr>
																	</table>
																	<p>
																		<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
																		&nbsp;
																		<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
																			borderstyle="none" />
																		&nbsp;
																		<asp:linkbutton id="deleteButton" text="刪除此項目" causesvalidation="False" runat="server" class="CommandButton"
																			borderstyle="none" />
																		<hr noshade size="1" width="500">
																		<span class="Normal">建立者
                                            <asp:label id="CreatedBy" runat="server" />
                                            建立日期
                                            <asp:label id="CreatedDate" runat="server" />
                                            <br>
                                        </span>
																	<P></P>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="?啁敦??"></FONT></DIV>
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

<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="ASPNET.StarterKit.Portal.Tabs" CodeBehind="Tabs.ascx.vb" language="vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title runat="server" id="Title1" />
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="#ffffff">
			<TABLE border="0">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<table cellpadding="2" cellspacing="0" border="0">
							<tr>
								<td colspan="2">
									<table border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
											<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
												<asp:LinkButton id="addBtn" cssclass="CommandButton" Text="新增索引標籤" runat="server" /></td>
											<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr valign="top">
								<td width="100">
									&nbsp;
								</td>
								<td width="50" class="Normal">
									索引標籤:
								</td>
								<td>
									<table cellpadding="0" cellspacing="0" border="0">
										<tr valign="top">
											<td>
												<asp:ListBox id="tabList" width=200 DataSource="<%# portalTabs %>" DataTextField="TabName" DataValueField="TabId" rows=5 runat="server" />
											</td>
											<td>
												&nbsp;
											</td>
											<td>
												<table>
													<tr>
														<td>
															<asp:ImageButton id="upBtn" ImageUrl="~/images/up.gif" CommandName="up" AlternateText="在清單中上移選取的索引標籤"
																runat="server" />
														</td>
													</tr>
													<tr>
														<td>
															<asp:ImageButton id="downBtn" ImageUrl="~/images/dn.gif" CommandName="down" AlternateText="在清單中下移選取的索引標籤"
																runat="server" />
														</td>
													</tr>
													<tr>
														<td>
															<asp:ImageButton id="editBtn" ImageUrl="~/images/edit.gif" AlternateText="編輯選取的索引標籤屬性" runat="server" />
														</td>
													</tr>
													<tr>
														<td>
															<asp:ImageButton id="deleteBtn" ImageUrl="~/images/delete.gif" AlternateText="刪除選取的索引標籤" runat="server" />
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!---------------------------------------------------------------------------------------------------------------------->
					</TD>
				</TR>
			</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

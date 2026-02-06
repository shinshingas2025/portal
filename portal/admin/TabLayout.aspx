<%@ Page language="vb" CodeBehind="TabLayout.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.TabLayout" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<%--
     The TabLayout.aspx page is used to control the layout settings of an
     individual tab within the portal.
--%>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form runat="server">
			<aspnetportal:banner id="Banner1" runat="server" showtabs="false"></aspnetportal:banner>
			<table cellSpacing="0" cellPadding="0" width="350" align="center" border="0">
				<tr>
					<td colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
							<tr>
								<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
								<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle"> 索引標籤管理</asp:label></td>
								<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
								<td><FONT face="新細明體"></FONT></td>
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
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><br>
												<table cellSpacing="0" cellPadding="4" width="98%">
													<tr vAlign="top">
														<td width="12">&nbsp;
														</td>
														<td width="*">
															<table cellSpacing="1" cellPadding="2" width="100%" border="0">
																<tr>
																	<td colSpan="4">
																		<table cellSpacing="0" cellPadding="0" width="100%">
																			<tr>
																				<td class="Head" align="left">索引標籤名稱及配置
																				</td>
																			</tr>
																			<tr>
																				<td>
																					<hr noShade SIZE="1">
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class="Normal" width="100">索引標籤名稱:
																	</td>
																	<td colSpan="3"><asp:textbox id="tabName" runat="server" cssclass="NormalTextBox" width="300"></asp:textbox></td>
																</tr>
																<tr>
																	<td class="Normal" noWrap>授權的角色:
																	</td>
																	<td colSpan="3"><asp:checkboxlist id="authRoles" runat="server" width="300" font-size="8pt" font-names="Verdana,Arial"
																			repeatcolumns="2"></asp:checkboxlist></td>
																</tr>
																<tr>
																	<td>&nbsp;
																	</td>
																	<td colSpan="3">
																		<hr noShade SIZE="1">
																	</td>
																</tr>
																<tr>
																	<td class="Normal" noWrap>向行動使用者顯示?:
																	</td>
																	<td colSpan="3"><asp:checkbox id="showMobile" runat="server" font-size="8pt" font-names="Verdana,Arial"></asp:checkbox></td>
																</tr>
																<tr>
																	<td class="Normal" noWrap>行動索引標籤名稱:
																	</td>
																	<td colSpan="3"><asp:textbox id="mobileTabName" runat="server" cssclass="NormalTextBox" width="300"></asp:textbox></td>
																</tr>
																<tr>
																	<td colSpan="4">
																		<hr noShade SIZE="1">
																	</td>
																</tr>
																<tr>
																	<td class="Normal">新增模組:
																	</td>
																	<td class="Normal">模組型別:
																	</td>
																	<td colSpan="2"><asp:dropdownlist id="moduleType" runat="server" datatextfield="FriendlyName" datavaluefield="ModuleDefID"></asp:dropdownlist></td>
																</tr>
																<tr>
																	<td>&nbsp;
																	</td>
																	<td class="Normal">模組名稱:
																	</td>
																	<td colSpan="2"><asp:textbox id="moduleTitle" runat="server" cssclass="NormalTextBox" width="250" text="新模組名稱"
																			enableviewstate="false"></asp:textbox></td>
																</tr>
																<tr>
																	<td>&nbsp;
																	</td>
																	<td colSpan="3">
																		<DIV align="right">
																			<table cellSpacing="0" cellPadding="0" align="center" border="0">
																				<tr>
																					<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></td>
																					<td 
                                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                                ><asp:linkbutton class="CommandButton" id="AddModuleBtn" runat="server" text='<img src="../images/dn.gif" border=0> 新增至下方的「組織模組」'></asp:linkbutton></td>
																					<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></td>
																				</tr>
																			</table>
																		</DIV>
																	</td>
																</tr>
																<tr>
																	<td>&nbsp;
																	</td>
																	<td colSpan="3">
																		<hr noShade SIZE="1">
																	</td>
																</tr>
																<tr vAlign="top">
																	<td class="Normal">組織模組:
																	</td>
																	<td width="120">
																		<table cellSpacing="0" cellPadding="2" width="100%" border="0">
																			<tr>
																				<td class="NormalBold">&nbsp;左迷你窗格
																				</td>
																			</tr>
																			<tr vAlign="top">
																				<td>
																					<table cellSpacing="2" cellPadding="0" border="0">
																						<tr vAlign="top">
																							<td rowSpan="2"><asp:listbox id=leftPane runat="server" width="110" rows="7" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# leftList %>" Height="200px" BackColor="AliceBlue"></asp:listbox></td>
																							<td vAlign="top" noWrap><asp:imagebutton id="LeftUpBtn" runat="server" alternatetext="在清單中上移選取的模組" commandargument="leftPane"
																									commandname="up" imageurl="~/images/up.gif"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="LeftRightBtn" runat="server" alternatetext="將選取的模組移至內容窗格" commandname="right"
																									imageurl="~/images/rt.gif" targetpane="contentPane" sourcepane="leftPane"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="LeftDownBtn" runat="server" alternatetext="在清單中下移選取的模組" commandargument="leftPane"
																									commandname="down" imageurl="~/images/dn.gif"></asp:imagebutton>&nbsp;&nbsp;
																							</td>
																						</tr>
																						<tr>
																							<td vAlign="bottom" noWrap><FONT face="新細明體"><BR>
																								</FONT>
																								<asp:imagebutton id="LeftEditBtn" runat="server" alternatetext="編輯此項目" commandargument="leftPane"
																									commandname="edit" imageurl="~/images/edit.gif"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="LeftDeleteBtn" runat="server" alternatetext="刪除此項目" commandargument="leftPane"
																									commandname="delete" imageurl="~/images/delete.gif"></asp:imagebutton></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</td>
																	<td width="*">
																		<table cellSpacing="0" cellPadding="2" width="100%" border="0">
																			<tr>
																				<td class="NormalBold">&nbsp;內容窗格
																				</td>
																			</tr>
																			<tr>
																				<td align="center">
																					<table cellSpacing="2" cellPadding="0" border="0">
																						<tr vAlign="top">
																							<td rowSpan="2"><asp:listbox id=contentPane runat="server" width="170" rows="7" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# contentList %>" Height="200px" BackColor="SeaShell"></asp:listbox></td>
																							<td vAlign="top" noWrap><asp:imagebutton id="ContentUpBtn" runat="server" alternatetext="在清單中上移選取的模組" commandargument="contentPane"
																									commandname="up" imageurl="~/images/up.gif"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="ContentLeftBtn" runat="server" alternatetext="將選取的模組移至左窗格" imageurl="~/images/lt.gif"
																									targetpane="leftPane" sourcepane="contentPane"></asp:imagebutton><br>
																								<FONT face="新細明體">
																									<BR>
																								</FONT>
																								<asp:imagebutton id="ContentRightBtn" runat="server" alternatetext="將選取的模組移至右窗格" imageurl="~/images/rt.gif"
																									targetpane="rightPane" sourcepane="contentPane"></asp:imagebutton><br>
																								<BR>
																								<asp:imagebutton id="ContentDownBtn" runat="server" alternatetext="在清單中下移選取的模組" commandargument="contentPane"
																									commandname="down" imageurl="~/images/dn.gif"></asp:imagebutton>&nbsp;&nbsp;
																							</td>
																						</tr>
																						<tr>
																							<td vAlign="bottom" noWrap><FONT face="新細明體"></FONT><asp:imagebutton id="ContentEditBtn" runat="server" alternatetext="編輯此項目" commandargument="contentPane"
																									commandname="edit" imageurl="~/images/edit.gif"></asp:imagebutton><br>
																								<FONT face="新細明體">
																									<BR>
																								</FONT>
																								<asp:imagebutton id="ContentDeleteBtn" runat="server" alternatetext="刪除此項目" commandargument="contentPane"
																									commandname="delete" imageurl="~/images/delete.gif"></asp:imagebutton></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</td>
																	<td width="120">
																		<table cellSpacing="0" cellPadding="2" width="100%" border="0">
																			<tr>
																				<td class="NormalBold">&nbsp;右迷你窗格
																				</td>
																			</tr>
																			<tr>
																				<td>
																					<table cellSpacing="2" cellPadding="0" border="0">
																						<tr vAlign="top">
																							<td rowSpan="2"><asp:listbox id=rightPane runat="server" width="110" rows="7" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# rightList %>" Height="200px" BackColor="Beige"></asp:listbox></td>
																							<td vAlign="top" noWrap><asp:imagebutton id="RightUpBtn" runat="server" alternatetext="在清單中上移選取的模組" commandargument="rightPane"
																									commandname="up" imageurl="~/images/up.gif"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="RightLeftBtn" runat="server" alternatetext="將選取的模組移至左窗格" imageurl="~/images/lt.gif"
																									targetpane="contentPane" sourcepane="rightPane"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="RightDownBtn" runat="server" alternatetext="在清單中下移選取的模組" commandargument="rightPane"
																									commandname="down" imageurl="~/images/dn.gif"></asp:imagebutton></td>
																						</tr>
																						<tr>
																							<td vAlign="bottom" noWrap><asp:imagebutton id="RightEditBtn" runat="server" alternatetext="編輯此項目" commandargument="rightPane"
																									commandname="edit" imageurl="~/images/edit.gif"></asp:imagebutton><FONT face="新細明體"><BR>
																								</FONT>
																								<br>
																								<asp:imagebutton id="RightDeleteBtn" runat="server" alternatetext="刪除此項目" commandargument="rightPane"
																									commandname="delete" imageurl="~/images/delete.gif"></asp:imagebutton></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td colSpan="4">
																		<hr noShade SIZE="1">
																	</td>
																</tr>
																<tr>
																	<td colSpan="4">
																		<DIV align="right">
																			<table cellSpacing="0" cellPadding="0" align="right" border="0">
																				<tr>
																					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																						<asp:linkbutton id="applyBtn" class="CommandButton" text="套用變更" runat="server" /></td>
																					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																				</tr>
																			</table>
																		</DIV>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!----------------------------------------------------------------------------------------------------------------------></TD>
							</TR>
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
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

<%@ Page language="vb" CodeBehind="ModuleDefinitions.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.ModuleDefinitions" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<%--
    The SecurityRoles.aspx page is used to create and edit security roles within
    the Portal application.
--%>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
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
          ><asp:label id="Label7" runat="server" CssClass="head">模組型別定義</asp:label></td>
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
																<td width="150">&nbsp;
																</td>
																<td width="*">
																	<table cellSpacing="0" cellPadding="0" width="500">
																		<tr>
																			<td colSpan="2"></td>
																		</tr>
																	</table>
																	<table cellSpacing="0" cellPadding="0" width="750" border="0">
																		<tr>
																			<td class="SubHead" width="100">易記名稱:
																			</td>
																			<td rowSpan="5">&nbsp;
																			</td>
																			<td><asp:textbox id="FriendlyName" runat="server" maxlength="150" columns="30" width="390" cssclass="NormalTextBox"></asp:textbox></td>
																			<td width="25" rowSpan="5">&nbsp;
																			</td>
																			<td class="Normal" width="250"><asp:requiredfieldvalidator id="Req1" runat="server" controltovalidate="FriendlyName" errormessage="輸入模組名稱："
																					display="Static"></asp:requiredfieldvalidator></td>
																		</tr>
																		<tr>
																			<td class="SubHead" noWrap>桌面來源:
																			</td>
																			<td><asp:textbox id="DesktopSrc" runat="server" maxlength="150" columns="30" width="390" cssclass="NormalTextBox"></asp:textbox></td>
																			<td class="Normal"><asp:requiredfieldvalidator id="Req2" runat="server" controltovalidate="DesktopSrc" errormessage="您必須輸入桌面模組的來源路徑"
																					display="Static"></asp:requiredfieldvalidator></td>
																		</tr>
																		<tr>
																			<td class="SubHead">行動來源:
																			</td>
																			<td><asp:textbox id="MobileSrc" runat="server" maxlength="150" columns="30" width="390" cssclass="NormalTextBox"></asp:textbox></td>
																			<td>&nbsp;
																			</td>
																		</tr>
																	</table>
																	<p><asp:linkbutton class="CommandButton" id="updateButton" runat="server" borderstyle="none" text="更新"></asp:linkbutton>&nbsp;
																		<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" borderstyle="none" text="取消"
																			causesvalidation="False"></asp:linkbutton>&nbsp;
																		<asp:linkbutton class="CommandButton" id="deleteButton" runat="server" borderstyle="none" text="刪除此模組型別"
																			causesvalidation="False"></asp:linkbutton></p>
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

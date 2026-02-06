<%@ Page language="vb" CodeBehind="WebSiteList.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.WebSiteList" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server" />]
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">各校網站資料</asp:label></td>
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
													<td vAlign="top"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
														<br>
														<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" height="290">
															<TR>
																<TD height="1">
																	<TABLE id="Table2" height="38" cellSpacing="0" cellPadding="0" width="211" align="center"
																		border="0">
																		<TR>
																			<TD width="124">
																				<P align="right">
																					<asp:TextBox id="txtSearch" runat="server" Width="100px"></asp:TextBox></P>
																			</TD>
																			<TD width="185">
																				<DIV align="left">
																					<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="left" border="0">
																						<TR>
																							<TD><IMG 
                        src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
																							<TD 
                      background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																								<asp:LinkButton id="btnSearch" runat="server" CssClass="CommandButton">搜尋</asp:LinkButton></TD>
																							<TD width="1"><IMG 
                        src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
																						</TR>
																					</TABLE>
																				</DIV>
																			</TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR>
																<TD vAlign="top">
																	<asp:DataList id="DataList1" runat="server" Width="100%" RepeatColumns="4">
																		<ItemTemplate>
																			<span class="Normal">
																				<img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'>
																				<asp:HyperLink id="editLink" ImageUrl="<%# linkImage %>" NavigateUrl='<%# ChooseURL(DataBinder.Eval(Container.DataItem,"itemid"), Request.Params("Mid"), DataBinder.Eval(Container.DataItem,"portalid")) %>' Target='<%# ChooseTarget() %>' ToolTip='<%# ChooseTip(DataBinder.Eval(Container.DataItem,"Portalname")) %>' runat="server" />
																				<asp:HyperLink Text='<%# DataBinder.Eval(Container.DataItem,"Portalname") %>' NavigateUrl='<%# "../DesktopDefault.aspx?sid=" & DataBinder.Eval(Container.DataItem,"portalid") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem,"portalname") %>' Target="_new" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
																			</span>
																			<br>
																		</ItemTemplate>
																	</asp:DataList></TD>
															</TR>
														</TABLE>
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

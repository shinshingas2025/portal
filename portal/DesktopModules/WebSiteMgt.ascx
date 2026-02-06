<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.WebSiteMgt" CodeBehind="WebSiteMgt.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleBottom" Src="../DesktopModuleBottom.ascx" %>
<FONT face="新細明體"></FONT>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td colSpan="3"><aspnetportal:title id="Title1" runat="server" editurl="~/DesktopModules/EditWebSiteMgt.aspx"></aspnetportal:title></td>
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
		<td bgColor="#ffffff" width="100%">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="571"><FONT face="新細明體">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" height="38" align="center">
								<TR>
									<TD width="124">
										<P align="right">
											<asp:TextBox id="txtSearch" runat="server" Width="100px"></asp:TextBox></P>
									</TD>
									<TD width="185">
										<DIV align="left">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0" align="left">
												<TR>
													<TD><IMG 
                        src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></TD>
													<TD 
                      background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' >
														<asp:LinkButton id="btnSearch" runat="server" CssClass="CommandButton">搜尋</asp:LinkButton></TD>
													<TD width="1"><IMG 
                        src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
					<TD><FONT face="新細明體"></FONT></TD>
				</TR>
				<TR>
					<TD colSpan="2"><FONT face="新細明體">
							<TABLE border="0" width="100%">
								<TR>
									<TD vAlign="top" align="center"><!---------------------------------------------------------------------------------------------------------------------->
										<asp:datalist id="myDataList" runat="server" cellpadding="4" width="100%">
											<itemtemplate>
												<span class="Normal">
													<img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'>
													<asp:HyperLink id="editLink" ImageUrl="<%# linkImage %>" NavigateUrl='<%# ChooseURL(DataBinder.Eval(Container.DataItem,"itemid"), ModuleId, DataBinder.Eval(Container.DataItem,"portalid")) %>' Target='<%# ChooseTarget() %>' ToolTip='<%# ChooseTip(DataBinder.Eval(Container.DataItem,"Portalname")) %>' runat="server" />
													<asp:HyperLink Text='<%# DataBinder.Eval(Container.DataItem,"Portalname") %>' NavigateUrl='<%# "../DesktopDefault.aspx?sid=" & DataBinder.Eval(Container.DataItem,"portalid") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem,"portalname") %>' Target="_new" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
												</span>
												<br>
											</itemtemplate>
										</asp:datalist><!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
			</TABLE>
			<P align="right">
				<uc1:DesktopModuleBottom EditUrl="~/DesktopModules/WebSiteList.aspx" id="DesktopModuleBottom1" runat="server"></uc1:DesktopModuleBottom></P>
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

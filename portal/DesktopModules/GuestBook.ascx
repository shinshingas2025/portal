<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.GuestBook" CodeBehind="GuestBook.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3" width="100%">
			<ASPNETPORTAL:TITLE id="Title1" runat="server" EditUrl="~/DesktopModules/GuestBook/GuestBookAdminList.aspx"
				EditText="管理資料"></ASPNETPORTAL:TITLE>
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' width=5><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="#ffffff" width="100%">
			<TABLE border="0" width="100%" cellSpacing="0" cellPadding="0">
				<TR>
					<TD valign="top" align="center" width="100%">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="100%" align="center"><asp:datalist id="myDataList" runat="server" EnableViewState="false" Width="100%" CellPadding="0">
										<ItemTemplate>
											<SPAN class="ItemTitle">
												<asp:HyperLink id=editLink runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# "~/DesktopModules/GuestBook/GuestBookAdd.aspx?EntityID=" & DataBinder.Eval(Container.DataItem,"EntityID") & "&ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID") & "&mid=" & ModuleId & "&sid=" & ctype(session("sid"),string) & "&tabid=" & tabid & "&tabindex=" & tabindex %>' ImageUrl="~/images/edit.gif">
												</asp:HyperLink>
												<IMG alt=項目 src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'>
												<a href='DesktopModules/GuestBook/GuestBookView.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>&EntityID=<%# DataBinder.Eval(Container.DataItem,"EntityID") %>'>
													<%# DataBinder.Eval(Container.DataItem,"Title") %>
												</a>
											</SPAN>
										</ItemTemplate>
									</asp:datalist></TD>
							</TR>
							<tr>
								<td width="100%" align="right">
									<table border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
											<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
												<asp:linkbutton id="LinkButtonAdd" runat="server" CssClass="CommandButton">新增留言</asp:linkbutton></td>
											<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
										</tr>
									</table>
								</td>
							</tr>
						</TABLE>
						<P align="right">
							<ASPNETPORTAL:Bottom id="Title2" runat="server" EditUrl="~/DesktopModules/GuestBook/GuestBookList.aspx"
								EditText="更多資料"></ASPNETPORTAL:Bottom></P>
						<!---------------------------------------------------------------------------------------------------------------------->
					</TD>
				</TR>
			</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td width="5"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

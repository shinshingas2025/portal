<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Announcements" CodeBehind="Announcements.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title EditText="新增資料" EditUrl="~/DesktopModules/EditAnnouncements.aspx" runat="server"
				id="Title1" />
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
			<TABLE border="0" width="100%">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="TTable1">
							<TR>
								<TD>
									<asp:DataList id="myDataList" CellPadding="4" Width="100%" EnableViewState="false" runat="server">
										<ItemTemplate>
											<asp:HyperLink id="editLink" ImageUrl="~/images/edit.gif" NavigateUrl='<%# "~/DesktopModules/EditAnnouncements.aspx?ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID") & "&mid=" & ModuleId & "&sid=" & ctype(session("sid"),string) %>' Visible="<%# IsEditable %>" runat="server" />
											<Img src='/portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'  alt='項目'><span class="ItemTitle">
												<%# DataBinder.Eval(Container.DataItem,"Title") %>
											</span>
											<br>
											<span class="Normal">
            <%# DataBinder.Eval(Container.DataItem,"Description") %>
            &nbsp;
            <asp:HyperLink id="moreLink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"MoreLink") %>' Visible='<%# DataBinder.Eval(Container.DataItem,"MoreLink") <> String.Empty %>' runat="server">
                參閱相關資訊...</asp:HyperLink>
        </span>
											<br>
										</ItemTemplate>
									</asp:DataList></TD>
							</TR>
						</TABLE>
						<!---------------------------------------------------------------------------------------------------------------------->
					</TD>
				</TR>
			</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' width="100%"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

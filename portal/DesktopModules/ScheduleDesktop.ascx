<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.ScheduleDesktop" CodeBehind="ScheduleDesktop.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleBottom" Src="~/DesktopModuleBottom.ascx" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPORTAL:TITLE id="Title1" runat="server" EditShow="false" EditUrl="~/DesktopModules/AuditSystem/ScheduleAdmin.aspx"
				EditText="管理資料"></ASPNETPORTAL:TITLE>
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="#ffffff" width="100%">
			<TABLE border="0" width="100%">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center"><h2>今日行事曆</h2></TD>
							</TR>
							<tr>
								<td colSpan="5" width="100%">
									<table cellSpacing="0" cellPadding="0" border="0" width="100%">
										<tr>
											<th width="5%">
												選擇</th>
											<th width="20%">
												開始時間</th>
											<th width="20%">
												結束時間</th>
											<th width="55%">
												主題</th></tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="5" width="100%"><asp:datalist id="DataListResult" runat="server" DataKeyField="EntityID" Width="100%">
										<ItemTemplate>
											<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
												<TR>
													<td width="5%" align="center">
														<a href='DesktopModules/AuditSystem/ScheduleAdmin.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>&scheduleID=<%# DataBinder.Eval(Container.DataItem,"EntityID") %>'>
															<img src="/PortalFiles/WebImage/AuditSystem/rt.gif"></a>
													</td>
													<TD width="20%">
														<ASP:LABEL id="Label3" runat="server">
															<%# DataBinder.Eval(Container.DataItem, "StartDateString") %>
														</ASP:LABEL></TD>
													<TD width="20%">
														<ASP:LABEL id="Label1" runat="server">
															<%# DataBinder.Eval(Container.DataItem, "EndDateString") %>
														</ASP:LABEL></TD>
													<TD width="55%" class="NormalBold">
														<ASP:LABEL id="Label2" runat="server">
															<%# DataBinder.Eval(Container.DataItem, "Title") %>
														</ASP:LABEL>
													</TD>
												</TR>
											</TABLE>
										</ItemTemplate>
									</asp:datalist></td>
							</tr>
						</TABLE>
						<P align="right">
							<uc1:DesktopModuleBottom id="DesktopModuleBottom2" runat="server" EditText="more" EditUrl="~/DesktopModules/AuditSystem/ScheduleAdmin.aspx"></uc1:DesktopModuleBottom>
							<br>
						</P>
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

<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleBottom" Src="~/DesktopModuleBottom.ascx" %>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.AdminBulletin" CodeBehind="AdminBulletin.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPORTAL:TITLE id="Title1" runat="server" EditUrl="~/DesktopModules/Bulletin/BulletinAdmin.aspx"
				EditText="管理資料" EditShow="false"></ASPNETPORTAL:TITLE>
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
								<TD><asp:datalist id="myDataList" runat="server" EnableViewState="false" Width="100%" CellPadding="4"
										CssClass="ItemTitle">
										<HeaderTemplate>
											<table width="100%" cellpadding="0" cellspacing="0" border="0">
												<tr>
													<th width="10">
													</th>
													<th width="76%">
														主題</th>
													<th>
														發佈單位/發佈日期</th>
												</tr>
											</table>
										</HeaderTemplate>
										<ItemTemplate>
											<span class="ItemTitle">
												<table width="100%" cellpadding="0" cellspacing="0" border="0">
													<tr>
														<td width="10" valign="top"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
														<td class="normal" valign="top">
															<a href='DesktopModules/AdminBulletin/AdminBulletinShow.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>&bulletinmapid=<%# DataBinder.Eval(Container.DataItem,"EntityID") %>'>
																<%# DataBinder.Eval(Container.DataItem,"Title") %>
															</a>
														</td>
														<td width="150">
															<asp:Label CssClass="itemtitle" Text='<%# DataBinder.Eval(Container.DataItem,"AnnounceUnit") %>' runat="server" ID="Label2"/><br>
															<asp:Label CssClass="normal" Text='<%# DataBinder.Eval(Container.DataItem,"CreatedDate") %>' runat="server" ID="Label1"/>
														</td>
													</tr>
												</table>
											</span>
										</ItemTemplate>
										<SeparatorTemplate>
										</SeparatorTemplate>
									</asp:datalist></TD>
							</TR>
						</TABLE>
						<P align="right">
							<uc1:DesktopModuleBottom id="DesktopModuleBottom2" runat="server" EditText="more" EditUrl="~/DesktopModules/AdminBulletin/AdminBulletinList.aspx"></uc1:DesktopModuleBottom>
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

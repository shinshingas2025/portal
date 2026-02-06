<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.announces" CodeBehind="announce.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title EditText="新增資料" EditUrl="~/DesktopModules/announce.aspx" runat="server" id="Title1" />
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
									<asp:DataList id="myDataList" CellPadding="4" Width="98%" EnableViewState="false" runat="server">
										<ItemTemplate>
											<span class="ItemTitle">
												<asp:HyperLink id="editLink" ImageUrl='<%# "/PortalFiles/WebImage/" &  ctype(session("sid"),string) & "/" & ctype(session("sid"),string) & "_0009.gif" %>' NavigateUrl='<%# "~/DesktopModules/announce.aspx?ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID") & "&mid=" & ModuleId & "&sid=" & ctype(session("sid"),string) %>' Visible="<%# IsEditable %>" runat="server" />
												<Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'  alt='項目'>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' runat="server" ID="Label1" NAME="Label1"/>
											</span>
											<br>
											<span class="Normal">
												<i>
													<%# DataBinder.Eval(Container.DataItem,"WhereWhen") %>
												</i>
											</span>
											<br>
											<span class="Normal">
												<%# DataBinder.Eval(Container.DataItem,"Description") %>
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

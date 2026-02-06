<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Document" CodeBehind="Document.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title EditText="加入新增文件" EditUrl="~/DesktopModules/EditDocs.aspx" runat="server" id="Title1" />
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
									<asp:datagrid id="myDataGrid" Border="0" width="100%" AutoGenerateColumns="false" EnableViewState="false"
										runat="server">
										<Columns>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:HyperLink id="editLink" ImageUrl="~/images/edit.gif" NavigateUrl='<%# "~/DesktopModules/EditDocs.aspx?ItemID=" & DataBinder.Eval(Container.DataItem,"ItemID")  & "&mid=" & ModuleId & "&sid=" & ctype(session("sid"),string) %>' Visible="<%# IsEditable %>" runat="server" />
													<Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'  alt=項目>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="標題" HeaderStyle-CssClass="NormalBold">
												<ItemTemplate>
													<asp:HyperLink id="docLink" Text='<%# DataBinder.Eval(Container.DataItem,"FileFriendlyName") %>' NavigateUrl='<%# GetBrowsePath(DataBinder.Eval(Container.DataItem,"FileNameUrl"), DataBinder.Eval(Container.DataItem,"ContentSize"), CInt(DataBinder.Eval(Container.DataItem,"ItemId"))) %>' CssClass="Normal" Target="_new" runat="server" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="擁有者" DataField="CreatedByUser" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
											<asp:BoundColumn HeaderText="區域" DataField="Category" ItemStyle-Wrap="false" ItemStyle-CssClass="Normal"
												HeaderStyle-Cssclass="NormalBold" />
											<asp:BoundColumn HeaderText="上次更新日期" DataField="CreatedDate" DataFormatString="{0:d}" ItemStyle-CssClass="Normal"
												HeaderStyle-Cssclass="NormalBold" />
										</Columns>
									</asp:datagrid></TD>
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
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

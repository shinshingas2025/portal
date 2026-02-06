<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Discussion" CodeBehind="Discussion.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%-- discussion list --%>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title id="Title1" runat="server" EditTarget="_new" EditUrl="~/DesktopModules/DiscussDetails.aspx"
				EditText="加入新增討論"></ASPNETPortal:title>
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
									<asp:DataList id="TopLevelList" width="98%" ItemStyle-Cssclass="Normal" DataKeyField="Parent"
										runat="server">
										<SelectedItemTemplate>
											<asp:ImageButton id="btnCollapse" runat="server" CommandName="collapse" ImageUrl="~/images/minus.gif"></asp:ImageButton>
											<asp:hyperlink id=Hyperlink2 runat="server" Target="_new" NavigateUrl='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "ItemID"))) %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'>
											</asp:hyperlink>，寄件者
											<%# DataBinder.Eval(Container.DataItem,"CreatedByUser") %>
											，傳送日期
											<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
											<asp:DataList id=DetailList runat="server" ItemStyle-Cssclass="Normal" datasource="<%# GetThreadMessages() %>">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "Indent") %>
													<img src="<%=Global.GetApplicationPath(Request)%>/images/1x1.gif" height="15">
													<asp:hyperlink Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' NavigateUrl='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "ItemID"))) %>' Target="_new" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>，寄件者
													<%# DataBinder.Eval(Container.DataItem,"CreatedByUser") %>
													，傳送日期
													<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
												</ItemTemplate>
											</asp:DataList>
										</SelectedItemTemplate>
										<ItemStyle CssClass="Normal"></ItemStyle>
										<ItemTemplate>
											<asp:ImageButton id=btnSelect runat="server" CommandName="select" ImageUrl='<%# NodeImage(Cint(DataBinder.Eval(Container.DataItem, "ChildCount"))) %>'>
											</asp:ImageButton>
											<asp:hyperlink id="Hyperlink3" runat="server" Target="_new" NavigateUrl='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "ItemID"))) %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'>
											</asp:hyperlink>，寄件者
											<%# DataBinder.Eval(Container.DataItem,"CreatedByUser") %>
											，傳送日期
											<%# DataBinder.Eval(Container.DataItem,"CreatedDate", "{0:g}") %>
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
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

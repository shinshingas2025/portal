<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.ImageList" CodeBehind="ImageList.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPortal:title EditUrl="~/DesktopModules/EditImageList.aspx" runat="server" id="Title2" />
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
			<TABLE border="0">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<asp:DataList id="myDataList" CellPadding="4" Width="98%" EnableViewState="false" runat="server"
							HorizontalAlign="Center">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
							
								<asp:HyperLink id=editLink runat="server" Visible="<%# IsEditable %>" NavigateUrl='<%# "~/DesktopModules/EditImageList.aspx?ItemID=" &amp; DataBinder.Eval(Container.DataItem,"ItemID") &amp; "&amp;mid=" &amp; ModuleId &amp; "&amp;sid=" &amp; ctype(session("sid"),string) %>' ImageUrl='<%# "/PortalFiles/WebImage/" &amp; Request.Params("sid") &amp; "/" &amp; Request.Params("sid") &amp; "_0009.gif"%>' >
								</asp:HyperLink>
								<a href='<%# DataBinder.Eval(Container.DataItem,"Url") %>'><IMG alt="圖片" border=0 src='<%# DataBinder.Eval(Container.DataItem,"ImagePath") %><%# DataBinder.Eval(Container.DataItem,"ImageName") %>'>
								</a></SPAN>
							</ItemTemplate>
						</asp:DataList>
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

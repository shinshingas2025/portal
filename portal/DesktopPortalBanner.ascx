<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Control CodeBehind="DesktopPortalBanner.ascx.vb" language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.DesktopPortalBanner" %>
<%--

   The DesktopPortalBanner User Control is responsible for displaying the standard Portal
   banner at the top of each .aspx page.

   The DesktopPortalBanner uses the Portal Configuration System to obtain a list of the
   portal's sitename and tab settings. It then render's this content into the page.

--%>
<table width="100%" height="120" cellspacing="0" class="HeadBg" border="0" background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0001.gif'>
	<tr valign="top">
		<TD class="SiteLink" align="right" width="9"></TD>
		<td colspan="3" class="SiteLink" align="right">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="15"><IMG alt="項目" src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif'></TD>
					<TD width="276">
						<asp:label id="siteName" runat="server" EnableViewState="false" CssClass="SiteTitle"></asp:label></TD>
					<TD align="right" class="SiteLink">
						<asp:label id="WelcomeMessage" forecolor="#eeeeee" runat="server" />
						<A class="SiteLink" href="http://www.shinshingas.com.tw/" target="_blank">前台首頁<span class="Accent">|</span></A>
						<A class=SiteLink href="<%= Global_asax.GetApplicationPath(Request)%>/DesktopDefault.aspx?sid=2&amp;tabindex=0">
							入口網站主頁
                        </A><asp:Label ID="lblLogout" runat="server"></asp:Label>
						&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
			&nbsp;
		</td>
	</tr>
	<tr>
		<td colspan="2" valign="bottom">
		</td>
		<td align="center" rowspan="2">
			<!--ASP.NET Logo was here//--><FONT face="新細明體"></FONT>
		</td>
	</tr>
	<tr>
		<td width="9">
		</td>
		<td>
			<DIV align="right">
				<asp:datalist id="tabs" cssclass="OtherTabsBg" repeatdirection="horizontal" ItemStyle-Height="25"
					SelectedItemStyle-CssClass="TabBg" ItemStyle-BorderWidth="1" EnableViewState="false" runat="server"
					Width="385px">
					<SelectedItemStyle CssClass="TabBg"></SelectedItemStyle>
					<SelectedItemTemplate>
						&nbsp;<span class="SelectedTab"><a href='<%= Global_asax.GetApplicationPath(Request)%>/DesktopDefault.aspx?tabindex=<%# Container.ItemIndex %>&tabid=<%# Ctype(Container.DataItem, TabStripDetails).TabId %>&ttabid=<%# Ctype(Container.DataItem, TabStripDetails).AuthorizedRoles %>&sid=<%# CType(trim(Session("sid")), String) %>' ><%# Ctype(Container.DataItem, TabStripDetails).TabName %></a></span>&nbsp;
					</SelectedItemTemplate>
					<ItemStyle Height="25px" BorderWidth="1px" HorizontalAlign="Center"></ItemStyle>
					<ItemTemplate>
						&nbsp;<a href='<%= Global_asax.GetApplicationPath(Request)%>/DesktopDefault.aspx?tabindex=<%# Container.ItemIndex %>&tabid=<%# CType(Container.DataItem, TabStripDetails).TabId%>&ttabid=<%# Ctype(Container.DataItem, TabStripDetails).AuthorizedRoles %>&sid=<%# CType(trim(Session("sid")), String) %>' class="OtherTabs"><%# Ctype(Container.DataItem, TabStripDetails).TabName %></a>&nbsp;
					</ItemTemplate>
				</asp:datalist></DIV>
		</td>
	</tr>
</table>

<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.QuickLinks" CodeBehind="QuickLinks.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleTitle" Src="../DesktopModuleTitle.ascx" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<uc1:DesktopModuleTitle id="DesktopModuleTitle1" editurl= "~/DesktopModules/EditLinks.aspx" runat="server"></uc1:DesktopModuleTitle>
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
						<asp:datalist id="myDataList" cellpadding="4" width="100%" enableviewstate="false" runat="server">
							<itemtemplate>
								<span class="Normal">
									<asp:hyperlink id="editLink" imageurl="<%# linkImage %>" navigateurl='<%# ChooseURL(DataBinder.Eval(Container.DataItem,"ItemID"), ModuleId, DataBinder.Eval(Container.DataItem,"Url")) %>' runat="server" />
									<a href='<%# DataBinder.Eval(Container.DataItem,"Url") %>'>
										<%# DataBinder.Eval(Container.DataItem,"Title") %>
									</a>
								</span>
								<br>
							</itemtemplate>
						</asp:datalist>
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

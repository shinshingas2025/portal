<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Links" CodeBehind="Links.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<aspnetportal:title editurl="~/DesktopModules/EditLinks.aspx" edittext="加入連結" runat="server" id="Title1" />
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
						<asp:datalist id="myDataList" cellpadding="4" width="100%" runat="server">
							<itemtemplate>
								<span class="Normal">
									<asp:HyperLink id="editLink" ImageUrl="<%# linkImage %>" NavigateUrl='<%# ChooseURL(DataBinder.Eval(Container.DataItem,"ItemID"), ModuleId, DataBinder.Eval(Container.DataItem,"Url")) %>' Target='<%# ChooseTarget() %>' ToolTip='<%# ChooseTip(DataBinder.Eval(Container.DataItem,"Description")) %>' runat="server" />
									<asp:HyperLink Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"Url") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem,"Description") %>' Target="_new" runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
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
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' width="100%"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

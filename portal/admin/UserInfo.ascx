<%@ Register TagPrefix="uc1" TagName="DesktopModuleTitle" Src="../DesktopModuleTitle.ascx" %>
<%@ Control Inherits="ASPNET.StarterKit.Portal.UserInfo" CodeBehind="UserInfo.ascx.vb" language="vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0" id="Table1">
	<tr>
		<td colspan="3">
			<uc1:DesktopModuleTitle id="DesktopModuleTitle1" editurl="~/admin/EditUserInfo.aspx" runat="server"></uc1:DesktopModuleTitle>
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
			<TABLE border="0" id="Table2">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<asp:Label id="Label1" runat="server" CssClass="normal">維護個人資料</asp:Label>
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

<%@ Control CodeBehind="DesktopModuleTitle.ascx.vb" language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.DesktopModuleTitle" %>
<%--

   The PortalModuleTitle User Control is responsible for displaying the title of each
   portal module within the portal -- as well as optionally the module's "Edit Page"
   (if such a page has been configured).

--%>
<table width="98%" border="0" align="right" cellpadding="0" cellspacing="0">
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></td>
		<td width="80" background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' >
			<asp:label id="ModuleTitle" cssclass="Head" EnableViewState="false" runat="server" /></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></td>
		<td>
			<asp:ImageButton id="Editbutton"  EnableViewState="False" runat="server"  ImageAlign="Right">
			</asp:ImageButton></td>
	</tr>
</table>

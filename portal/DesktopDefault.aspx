<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page language="vb" CodeBehind="DesktopDefault.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.DesktopDefault" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="DesktopPortalBanner.ascx" %>
<HTML>
	<HEAD>
		<title>欣欣天然氣股份有限公司網站管理系統</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<%--

   The DesktopDefault.aspx page is used to load and populate each Portal View.  It accomplishes
   this by reading the layout configuration of the portal from the Portal Configuration
   system, and then using this information to dynamically instantiate portal modules
   (each implemented as an ASP.NET User Control), and then inject them into the page.

--%>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0" background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2">
						<ASPNETPortal:Banner id="Banner" SelectedTabIndex="0" runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="100%" cellspacing="0" cellpadding="2" border="0">
							<tr height="*" valign="top">
								<td width="5">&nbsp;
									
								</td>
								<td id="LeftPane" Visible="false" Width="170" runat="server" class="cLeftPane">
								</td>
								<td width="1">
								</td>
								<td id="ContentPane" Visible="false" Width="*" runat="server" class="cContentPane">
								</td>
								<td id="RightPane" Visible="false" Width="230" runat="server" class="cRightPane">
								</td>
								<td width="10">&nbsp;
									
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="docend" align="center">
						欣欣天然氣股份有限公司&nbsp;版權所有 翻印必究
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

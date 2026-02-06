<%@ Page CodeBehind="EditAccessDenied.aspx.vb" language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditAccessDenied" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ OutputCache Duration="36000" VaryByParam="none" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<html>
	<head>
		<title>ASP.NET 入口網站入門套件</title>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Session("sid")%>.css' type="text/css">
	</head>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/PortalFiles/WebImage/<%=Session("sid")%>/<%=Session("sid")%>_0002.gif' >
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2">
						<aspnetportal:banner runat="server" id="Banner1" />
					</td>
				</tr>
				<tr>
					<td valign="top">
						<center>
							<br>
							<table width="500" border="0">
								<tr>
									<td class="Normal">
										<br>
										<br>
										<br>
										<br>
										<span class="Head">拒絕編輯存取</span>
										<br>
										<br>
										<hr noshade size="1">
										<br>
										您可能目前尚未登入，或是沒有修改目前入口網站模組內容的存取權。
										請連絡入口網站系統管理員以取得此模組的存取權。
										<br>
										<br>
										<a href="<%=Global_asax.GetApplicationPath(Request)%>/Default.aspx?sid=<%=Session("sid")%>">返回入口網站主頁</a>
									</td>
								</tr>
							</table>
						</center>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

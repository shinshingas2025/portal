<%@ Page CodeBehind="NotImplemented.aspx.vb" language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.NotImplemented" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ OutputCache Duration="600" VaryByParam="title" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%--

   This page is the target for the fictious links in the sample data.

--%>
<html>
	<head>
		<title>ASP.NET 入口網站入門套件: 並未實作內容</title>
		<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</head>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0">
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
										<span id="title" class="Head" runat="server">未提供連結內容</span>
										<br>
										<br>
										<hr noshade size="1">
										<br>
										您所按下的連結屬於 [入口網站入門套件]  的範例資料。
                                                                      此連結的內容並非提供為範例應用程式的一部分。
										<br>
										<br>
										<a href="<%=Global.GetApplicationPath(Request)%>/DesktopDefault.aspx">返回入口網站入門套件主頁</a>
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

<%@ Page CodeBehind="ModuleSettings.aspx.vb" language="vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.ModuleSettingsPage" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%--
    The ModuleSettings.aspx page is used to enable administrators to view/edit/update
    a portal module's settings (title, output cache properties, edit access)
--%>
<html>
	<head>
	<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</head>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2">
						<aspnetportal:banner showtabs="false" runat="server" id="Banner1" />
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr valign="top">
								<td width="150">
									&nbsp;
								</td>
								<td width="*">
									<table cellpadding="2" cellspacing="1" border="0">
										<tr>
											<td colspan="4">
												<table width="100%" cellspacing="0" cellpadding="0">
													<tr>
														<td align="left" class="Head">
															模組設定
														</td>
													</tr>
													<tr>
														<td>
															<hr noshade size="1">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td width="100" class="SubHead">
												模組名稱：
											</td>
											<td colspan="3">
												&nbsp;<asp:textbox id="moduleTitle" width="300" cssclass="NormalTextBox" runat="server" />
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												快取逾時 (秒數):
											</td>
											<td colspan="3">
												&nbsp;<asp:textbox id="cacheTime" width="100" cssclass="NormalTextBox" runat="server" />
											</td>
										</tr>
										<tr>
											<td>
												&nbsp;
											</td>
											<td colspan="3">
												<hr noshade size="1">
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												可以編輯內容的角色:
											</td>
											<td colspan="3">
												<asp:checkboxlist id="authEditRoles" repeatcolumns="2" font-names="Verdana,Arial" font-size="8pt" width="300" cellpadding="0" cellspacing="0" runat="server" />
											</td>
										</tr>
										<tr>
											<td>
												&nbsp;
											</td>
											<td colspan="3">
												<hr noshade size="1">
											</td>
										</tr>
										<tr>
											<td class="SubHead" nowrap>
												向行動使用者顯示?:
											</td>
											<td colspan="3">
												<asp:checkbox id="showMobile" font-names="Verdana,Arial" font-size="8pt" runat="server" />
											</td>
										</tr>
										<tr>
											<td colspan="4">
												<hr noshade size="1">
											</td>
										</tr>
										<tr>
											<td colspan="4">
												<asp:linkbutton class="CommandButton" text="套用模組變更" runat="server" id="ApplyButton" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="EditImage.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditImage" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2">
						<aspnetportal:banner id="SiteHeader" runat="server" />
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
									<table width="500" cellspacing="0" cellpadding="0">
										<tr>
											<td align="left" class="Head">
												影像設定
											</td>
										</tr>
										<tr>
											<td colspan="2">
												<hr noshade size="1">
											</td>
										</tr>
									</table>
									<table width="500" cellspacing="0" cellpadding="0">
										<tr valign="top">
											<td width="100" class="SubHead">
												來源位置:
											</td>
											<td rowspan="3">
												&nbsp;
											</td>
											<td class="Normal">
												<asp:textbox id="Src" cssclass="NormalTextBox" width="352px" columns="30" runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												影像寬度:
											</td>
											<td>
												<asp:textbox id="Width" cssclass="NormalTextBox" width="390" columns="30" runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												影像高度:
											</td>
											<td>
												<asp:textbox id="Height" cssclass="NormalTextBox" width="390" columns="30" runat="server" />
											</td>
										</tr>
									</table>
									<p>
										<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
										&nbsp;
										<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
											borderstyle="none" />
									</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

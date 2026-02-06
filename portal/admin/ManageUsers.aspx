<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="ManageUsers.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.ManageUsers" %>
<HTML>
	<HEAD>
		<%--
    The SecurityRoles.aspx page is used to create and edit security roles within
    the Portal application.
--%>
		<link rel="stylesheet" href='../css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2">
						<aspnetportal:banner showtabs="false" runat="server" id="Banner1" />
					</td>
				</tr>
				<tr>
					<td width="100">
						&nbsp;
					</td>
					<td>
						<br>
						<table width="450" cellspacing="0" cellpadding="4" border="0">
							<tr height="*" valign="top">
								<td colspan="2">
									<table width="100%" cellspacing="0" cellpadding="0">
										<tr>
											<td align="left">
												<span id="title" class="Head" runat="server">管理使用者</span>
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
								<td class="Normal">
									電子郵件地址 (或 Windows 網域名稱):
								</td>
								<td>
									<asp:textbox id="Email" width="200" cssclass="NormalTextBox" runat="server" />
								</td>
							</tr>
							<tr>
								<td class="Normal">
									密碼:
								</td>
								<td>
									<asp:Textbox id="Password" width="200" cssclass="NormalTextBox" runat="server" TextMode="Password" />
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Password"
										CssClass="NormalRed" Display="Dynamic"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td class="Normal">
									確認密碼:
								</td>
								<td>
									<asp:Textbox id="ConfirmPassword" width="200" cssclass="NormalTextBox" runat="server" TextMode="Password" />
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="ConfirmPassword"
										CssClass="NormalRed" Display="Dynamic"></asp:RequiredFieldValidator>
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="ConfirmPassword"
										ControlToCompare="Password" CssClass="NormalRed" Display="Dynamic"></asp:CompareValidator>
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<asp:linkbutton text="套用名稱及密碼變更" cssclass="CommandButton" runat="server" id="UpdateUserBtn" />
									<br>
									<br>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:dropdownlist id="allRoles" datatextfield="RoleName" datavaluefield="RoleID" runat="server" />
									&nbsp;<asp:linkbutton id="addExisting" cssclass="CommandButton" text="將使用者加入此角色" runat="server" CausesValidation="False">
								將使用者加入此角色</asp:linkbutton>
								</td>
							</tr>
							<tr valign="top">
								<td>
									&nbsp;
								</td>
								<td>
									<asp:datalist id="userRoles" repeatcolumns="2" datakeyfield="RoleId" runat="server">
										<itemstyle width="225" />
										<itemtemplate>
											&nbsp;&nbsp;
											<asp:imagebutton imageurl="~/images/delete.gif" commandname="delete" alternatetext="將使用者由此角色移除" runat="server"
												id="Imagebutton1" />
											<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "RoleName") %>' cssclass="Normal" runat="server" ID="Label1" />
										</itemtemplate>
									</asp:datalist>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<hr noshade size="1">
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:linkbutton id="saveBtn" class="CommandButton" text="儲存使用者變更" runat="server" CausesValidation="False">
								儲存使用者變更</asp:linkbutton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

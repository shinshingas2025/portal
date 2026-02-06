<%@ Page language="vb" CodeBehind="Register.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.Register" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%--

   The Register.aspx page is used to enable clients to register a new unique username
   and password with the portal system.  The page contains a single server event
   handler -- RegisterBtn_Click -- that executes in response to the page's Register
   Button being clicked.

   The Register.aspx page uses the UsersDB class to manage the actual account creation.
   Note that the Usernames and passwords are stored within a table in a SQL database.

--%>
<html>
	<head>
		<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</head>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form runat="server">
			<table width="100%" cellspacing="0" cellpadding="0">
				<tr valign="top">
					<td colspan="2">
						<aspnetportal:banner showtabs="false" runat="server" id="Banner1" />
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr>
								<td width="150">
									&nbsp;
								</td>
								<td width="*">
									<table cellpadding="2" cellspacing="1" border="0">
										<tr>
											<td width="450">
												<table width="100%" cellspacing="0" cellpadding="0">
													<tr>
														<td>
															<span class="Head">建立新帳戶 </span>
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
										<tr valign="top">
											<td class="Normal">
												名稱:
												<br>
												<asp:textbox size="25" id="Name" runat="server" />
												&nbsp;
												<asp:requiredfieldvalidator controltovalidate="Name" errormessage="「名稱」不能空白。" runat="server" id="RequiredFieldValidator1" />
												<p>
													電子郵件:
													<br>
													<asp:textbox size="25" id="Email" runat="server" />
													&nbsp;
													<asp:regularexpressionvalidator controltovalidate="Email" validationexpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" display="Dynamic" errormessage="必須使用有效的電子郵件地址。" runat="server" id="RegularExpressionValidator1" />
													<asp:requiredfieldvalidator controltovalidate="Email" errormessage="「電子郵件地址」不能空白。" runat="server" id="RequiredFieldValidator2" />
												<p>
													密碼:
													<br>
													<asp:textbox size="25" id="Password" textmode="Password" runat="server" />
													&nbsp;
													<asp:requiredfieldvalidator controltovalidate="Password" errormessage="「密碼」不能空白。" runat="server" id="RequiredFieldValidator3" />
												<p>
													確認密碼:
													<br>
													<asp:textbox size="25" id="ConfirmPassword" textmode="Password" runat="server" />
													&nbsp;
													<asp:requiredfieldvalidator controltovalidate="ConfirmPassword" display="Dynamic" errormessage="「確認」不能空白。" runat="server" id="RequiredFieldValidator4" />
													<asp:comparevalidator controltovalidate="ConfirmPassword" controltocompare="Password" errormessage="密碼欄位並不符合。" runat="server" id="CompareValidator1" />
												<p>
													<asp:linkbutton class="CommandButton" text="註冊並立即登入" runat="server" id="RegisterBtn" />
													<br>
													<br>
												<p>
													<asp:label id="Message" cssclass="NormalRed" runat="server" />
												</p>
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

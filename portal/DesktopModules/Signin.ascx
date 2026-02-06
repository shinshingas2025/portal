<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Signin" CodeBehind="Signin.ascx.vb" AutoEventWireup="false" %>
<%--

   The SignIn User Control enables clients to authenticate themselves using
   the ASP.NET Forms based authentication system.

   When a client enters their username/password within the appropriate
   textboxes and clicks the "Login" button, the LoginBtn_Click event
   handler executes on the server and attempts to validate their
   credentials against a SQL database.

   If the password check succeeds, then the LoginBtn_Click event handler
   sets the customers username in an encrypted cookieID and redirects
   back to the portal home page.

   If the password check fails, then an appropriate error message
   is displayed.

--%>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<table width="98%" border="0" align="right" cellpadding="0" cellspacing="0">
				<tr>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></td>
					<td width="114" background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' >
						<div class="Head">管理者帳戶登入</div>
					</td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></td>
					<td>
					</td>
				</tr>
			</table>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><table border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="Normal" width="50">帳號:</td>
											<td><asp:TextBox id="email" columns="8" width="100" cssclass="NormalTextBox" runat="server" /></td>
										</tr>
										<tr>
											<td class="Normal">密碼:</td>
											<td><asp:TextBox id="password" columns="8" width="100" textmode="password" cssclass="NormalTextBox"
													runat="server" /></td>
										</tr>
									</table>
									<asp:checkbox id="RememberCheckbox" class="Normal" Text="記憶登入" runat="server" Visible="False" />
									<table width="100%" cellspacing="0" cellpadding="4" border="0">
										<tr>
											<td><table border="0" cellpadding="0" cellspacing="0" align="right">
													<tr>
														<td><table border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																	<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'>
																		<asp:LinkButton id="LoginBtn" runat="server" CssClass="CommandButton">登入</asp:LinkButton></td>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																</tr>
															</table>
														</td>
														<td>
															<!--<table border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																	<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																		<asp:LinkButton id="btnRegister" runat="server" CssClass="CommandButton">註冊</asp:LinkButton></td>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																</tr>
															</table>-->
														</td>
													</tr>
												</table>
												<br>
												<asp:label id="Message" class="NormalRed" runat="server" />
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
						<!---------------------------------------------------------------------------------------------------------------------->
					</TD>
				</TR>
			</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

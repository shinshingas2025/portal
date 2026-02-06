<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="5" cellPadding="5" width="75%" align="center" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center">
						<table width="600" border="0">
							<tr>
								<td vAlign="middle" align="center" height="124">
									<table cellSpacing="2" cellPadding="1" width="100%" border="0">
										<tr align="center">
											<td width="100%" height="25">
												<table cellSpacing="1" cellPadding="4" width="70%" bgColor="#6699cc" border="0">
													<tr align="center" bgColor="#a6c4e1">
														<td colSpan="2"><font size="2">欣欣網站管理系統</font></td>
													</tr>
													<tr bgColor="#ffffff">
														<td align="right" width="31%" bgColor="#a6c4e1"><font size="2">帳號</font></td>
														<td width="69%"><FONT face="新細明體"><asp:textbox id="txtLoginID" runat="server" Width="152px" MaxLength="20"></asp:textbox></FONT></td>
													</tr>
													<tr bgColor="#ffffff">
														<td align="right" bgColor="#a6c4e1"><font size="2">密碼</font></td>
														<td><FONT face="新細明體"><asp:textbox id="txtPassword" runat="server" Width="152px" TextMode="Password" MaxLength="20"></asp:textbox></FONT></td>
													</tr>
													<tr align="center" bgColor="#ffffff">
														<td colSpan="2"><asp:button id="loginbutton" runat="server" Width="88px" Text="登入系統"></asp:button></td>
													</tr>
												</table>
												<asp:Label id="lblerror" runat="server" ForeColor="#FF8000" Font-Size="Smaller"></asp:Label>
											</td>
										</tr>
									</table>
									<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Width="132px" ControlToValidate="txtLoginID"
										Font-Size="Smaller"> 請輸入帳號!!</asp:requiredfieldvalidator></td>
							</tr>
						</table>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Width="132px" ControlToValidate="txtPassword"
							Font-Size="Smaller"> 請輸入密碼!!</asp:requiredfieldvalidator></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

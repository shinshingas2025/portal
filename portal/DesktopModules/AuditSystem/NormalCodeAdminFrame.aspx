<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NormalCodeAdminFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.NormalCodeAdminFrame" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link href="../../css/AuditSystem1.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="/PortalFiles/WebImage/AuditSystem/1x1.gif"
		topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
					<td width="100%" bgColor="#ffffff">
						<TABLE width="100%" border="0">
							<TR>
								<TD vAlign="top" align="center">
									<!---------------------------------------------------------------------------------------------------------------------->
									<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
										border="0">
										<tr>
											<td align="left" width="100%">選擇代碼群組：
												<asp:dropdownlist AutoPostBack="True" CssClass="footer" id="DropDownListCodeGroup" runat="server"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%">
													<tr>
														<td>群組名稱：
															<asp:textbox id="TextBoxGroupName" runat="server" Columns="60"></asp:textbox><asp:label id="LabelGroupResult" runat="server" ForeColor="Red"></asp:label></td>
														<td>顯示順序：
															<asp:textbox id="TextBoxGroupDisplayOrder" runat="server" Columns="3"></asp:textbox></td>
													</tr>
													<tr>
														<td colSpan="2">說明：
															<asp:textbox id="TextBoxGroupDescription" runat="server" Columns="60"></asp:textbox></td>
													</tr>
													<tr>
														<td align="center" colSpan="2"><asp:button CssClass="nav" id="ButtonGroupInsert" runat="server" Text="新增"></asp:button>
															<asp:button CssClass="nav" id="ButtonGroupUpdate" runat="server" Text="修改"></asp:button>
															<asp:button CssClass="nav" id="ButtonGroupDelete" runat="server" Text="刪除"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center" width="100%">
												<asp:PlaceHolder id="PlaceHolderCode" runat="server"></asp:PlaceHolder></td>
										</tr>
										<tr>
											<td align="center" width="100%">
												<asp:Button CssClass="nav" id="ButtonCodeAction" runat="server" Width="40"></asp:Button>
												<asp:TextBox id="TextBoxCodeName" runat="server" Width="200"></asp:TextBox>
												<asp:TextBox id="TextBoxCodeDescription" runat="server" Width="300"></asp:TextBox>
												<asp:TextBox id="TextBoxCodeDisplayOrder" runat="server" Width="32"></asp:TextBox></td>
										</tr>
									</TABLE>
									<!----------------------------------------------------------------------------------------------------------------------></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

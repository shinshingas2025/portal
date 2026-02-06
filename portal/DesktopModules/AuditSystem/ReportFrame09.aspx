<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReportFrame09.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ReportFrame09" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="/PortalFiles/WebImage/AuditSystem/1x1.gif"
		topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
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
											<td align="center" colSpan="3"><FONT face="新細明體">
													<asp:Label id="Label1" runat="server" CssClass="subhead">新聞稿日期：</asp:Label>
													<asp:textbox id="TextBoxStartDate" runat="server"></asp:textbox></FONT></td>
										</tr>
										<tr>
											<td align="center" colSpan="3"><asp:button id="ButtonOK" runat="server" Text="查詢"></asp:button></td>
										</tr>
										<tr>
											<td align="center" colSpan="3"><iframe id="Iframe1" frameBorder="0" width="100%" height="400" runat="server"></iframe></td>
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

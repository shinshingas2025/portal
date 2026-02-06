<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReportFrame01.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ReportFrame01" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
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
													<asp:Label id="Label1" runat="server" CssClass="subhead">起始時間：</asp:Label>
													<asp:textbox id="TextBoxStartDate" runat="server"></asp:textbox>
													<asp:Label id="Label2" runat="server" CssClass="subhead">終止時間：</asp:Label>
													<asp:textbox id="TextBoxEndDate" runat="server"></asp:textbox>
													<asp:Label id="Label3" runat="server" CssClass="subhead">組別： </asp:Label>
													<asp:DropDownList id="DropDownListGroup" runat="server"></asp:DropDownList></FONT></td>
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

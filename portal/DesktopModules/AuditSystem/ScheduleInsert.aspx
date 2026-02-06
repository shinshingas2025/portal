<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ScheduleInsert.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ScheduleInsert" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href="../../css/AuditSystem1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" style="BACKGROUND-COLOR: #ffffcc" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
				</tr>
			</table>
			<TABLE width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
							border="0">
							<TR vAlign="top">
								<td width="30%"><asp:calendar id="Calendar1" Runat="server" SelectionMode="DayWeekMonth" TitleFormat="Month" NextPrevFormat="ShortMonth"></asp:calendar></td>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<tr>
											<td width="100%">
												<fieldset>
													<table cellSpacing="0" cellPadding="0" align="left" border="0">
														<tr>
															<td width="48">開始時間</td>
															<td><asp:textbox id="TextBoxStartTime" runat="server"></asp:textbox></td>
															<td width="48">結束時間</td>
															<td><asp:textbox id="TextBoxEndTime" runat="server"></asp:textbox></td>
															<td rowSpan="4"><asp:button id="ButtonInsert" runat="server" Text="新增" CssClass="nav"></asp:button></td>
														</tr>
														<tr>
															<td width="48">主旨</td>
															<td colSpan="3"><asp:textbox id="TextBoxTitle" runat="server" Columns="60" TextMode="SingleLine"></asp:textbox></td>
														</tr>
														<tr>
															<td width="48">內容</td>
															<td colSpan="3"><asp:textbox id="TextBoxDescription" runat="server" Columns="48" TextMode="MultiLine"></asp:textbox></td>
														</tr>
														<tr>
															<td width="48">備註</td>
															<td colSpan="3"><asp:textbox id="TextBoxNote" runat="server" Columns="60"></asp:textbox></td>
														</tr>
													</table>
												</fieldset>
											</td>
										</tr>
									</table>
								</td>
							</TR>
						</TABLE>
						<!----------------------------------------------------------------------------------------------------------------------></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></form>
	</body>
</HTML>

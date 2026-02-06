<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MeetingRecordAdminFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.MeetingRecordAdminFrame" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
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
											<td class="dingbat" align="left" width="80%">行政院金融監督管理委員會保險局第
												<asp:textbox id="TextBoxMeetingNumber" runat="server" Columns="2"></asp:textbox>次
												<asp:dropdownlist id="DropDownListType" runat="server" CssClass="navLink" AutoPostBack="True"></asp:dropdownlist><asp:label id="LabelResult" runat="server" ForeColor="Red"></asp:label></td>
											<td align="left" width="20%" rowSpan="2">
												<table width="100%">
													<tr>
														<td align="center" colSpan="2">
															<asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button>
															<asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button>
														</td>
													</tr>
													<tr>
														<td align="center" colspan="2">
															<asp:button id="ButtonRecordInsert" runat="server" CssClass="nav" Text="新增"></asp:button>
															<asp:button id="ButtonRecordUpdate" runat="server" CssClass="nav" Text="修改"></asp:button>
															<asp:button id="ButtonRecordDelete" runat="server" CssClass="nav" Text="刪除"></asp:button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%">
													<tr>
														<td class="legal">日期</td>
														<td colSpan="3"><asp:textbox id="TextBoxMeetingDate" runat="server" Columns="10"></asp:textbox><asp:textbox id="TextBoxStartTime" runat="server" Columns="4"></asp:textbox>～
															<asp:textbox id="TextBoxEndTime" runat="server" Columns="4"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">地點</td>
														<td colSpan="3"><ajax:ajaxpanel id="AjaxPanelPlace" runat="server">
																<asp:dropdownlist id="DropDownListPlace" runat="server" AutoPostBack="True" CssClass="footer" OnSelectedIndexChanged="DropDownListPlace_SelectedIndexChanged"></asp:dropdownlist>
																<asp:TextBox id="TextBoxPlaceName" runat="server"></asp:TextBox>
															</ajax:ajaxpanel></td>
													</tr>
													<tr>
														<td class="legal">主題</td>
														<td colSpan="3"><asp:textbox id="TextBoxTitle" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">出席人員</td>
														<td colSpan="3"><asp:textbox id="TextBoxPresentPerson" runat="server" Columns="60" TextMode="MultiLine" Rows="2"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">列席人員</td>
														<td colSpan="3"><asp:textbox id="TextBoxObserver" runat="server" Columns="60"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">主席</td>
														<td><asp:dropdownlist id="DropDownListChairPerson" runat="server" CssClass="footer"></asp:dropdownlist></td>
														<td class="legal">記錄</td>
														<td><asp:dropdownlist id="DropDownListScribe" runat="server" CssClass="footer"></asp:dropdownlist></td>
													</tr>
												</table>
											</td>
										</tr>
										<%--
										<tr>
											<td align="center" width="100%" colSpan="2"><asp:placeholder id="PlaceHolderResolution" runat="server"></asp:placeholder></td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2">
												<ajax:ajaxpanel id="AjaxPanelActiveResolution" runat="server">
													<TABLE cellSpacing="0" cellPadding="1" align="center" border="0">
														<TR>
															<TD width="40">
																<asp:button id="ButtonResolutionAction" runat="server" CssClass="nav" Width="40"></asp:button></TD>
															<TD width="64">
																<asp:textbox id="TextBoxResolutionNumber" runat="server" Width="64"></asp:textbox></TD>
															<TD width="240">
																<asp:textbox id="TextBoxContent" runat="server" Rows="2" TextMode="MultiLine" Width="240"></asp:textbox></TD>
															<TD width="64">
																<asp:dropdownlist id="DropDownListMainOffice" runat="server" AutoPostBack="True" CssClass="footer"
																	OnSelectedIndexChanged="DropDownListMainOffice_SelectedIndexChanged" Width="64"></asp:dropdownlist></TD>
															<TD width="120">
																<asp:dropdownlist id="DropDownListAffair" CssClass="footer" Width="120" Runat="server"></asp:dropdownlist></TD>
															<TD width="64">
																<asp:dropdownlist id="DropDownListAssistOffice" runat="server" CssClass="footer" Width="64"></asp:dropdownlist></TD>
															<TD width="80">
																<asp:dropdownlist id="DropDownListSketch" runat="server" CssClass="footer" Width="80"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</ajax:ajaxpanel>
											</td>
										</tr>
										--%>
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

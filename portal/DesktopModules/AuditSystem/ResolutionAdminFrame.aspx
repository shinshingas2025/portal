<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ResolutionAdminFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ResolutionAdminFrame" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
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
	<body bottomMargin="0" leftMargin="0" background="/PortalFiles/WebImage/AuditSystem/1x1.gif"
		topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
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
											<td class="dingbat" align="center" width="100%" colSpan="2">決議事項</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%" align="center">
													<tr>
														<td>決議編號</td>
														<td colSpan="3"><asp:textbox id="TextBoxResolutionNumber" Runat="server"></asp:textbox>自動編號<asp:checkbox id="CheckBoxAutoIncrease1" Runat="server" Checked="True"></asp:checkbox></td>
													</tr>
													<tr>
														<td>決議內容</td>
														<td colSpan="3"><asp:textbox id="TextBoxContent" Runat="server" Rows="4" TextMode="MultiLine"></asp:textbox></td>
													</tr>
													<tr>
														<td>備註</td>
														<td colSpan="3"><asp:textbox id="TextBoxNote" Runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td>主(協)辦單位</td>
														<td><asp:textbox id="TextBoxMainUnit" Runat="server"></asp:textbox></td>
														<td>預結期限</td>
														<td><asp:textbox id="TextBoxForecastDate" Runat="server"></asp:textbox><asp:checkbox id="chkNotify" runat="server" Text="提醒我" AutoPostBack="True"></asp:checkbox></td>
													</tr>
													<tr>
														<td>管考現況</td>
														<td><asp:dropdownlist id="DropDownListAuditState" Runat="server"></asp:dropdownlist></td>
														<td>完結</td>
														<td><asp:checkbox id="CheckBoxFinish" Runat="server"></asp:checkbox></td>
													</tr>
												</table>
											</td>
										<tr>
											<td align="center" colSpan="2"><asp:button id="ButtonEntityInsert" runat="server" Text="新增" CssClass="nav"></asp:button><asp:button id="ButtonEntityUpdate" runat="server" Text="修改" CssClass="nav"></asp:button><asp:button id="ButtonEntityDelete" runat="server" Text="刪除" CssClass="nav"></asp:button><asp:button id="ButtonReturn" Runat="server" Text="返回查詢頁" CssClass="nav"></asp:button></td>
										</tr>
										<tr>
											<td>
												<table width="100%" align="center">
													<tr>
														<td><ajax:ajaxpanel id="AjaxPanelEvent" runat="server">
																<TABLE style="BORDER-COLLAPSE: collapse" height="320" cellSpacing="1" cellPadding="1" width="100%"
																	align="center" bgColor="#ffffff" border="1">
																	<TR>
																		<TH height="32">
																			決議來源</TH></TR>
																	<TR>
																		<TD align="center">
																			<TABLE width="100%" align="center">
																				<TR>
																					<TH>
																						來源類別</TH>
																					<TH>
																					</TH>
																				</TR>
																				<TR>
																					<TD>
																						<asp:DropDownList id="DropDownListEventType" Runat="server" OnSelectedIndexChanged="DropDownListEventType_SelectedIndexChanged"
																							AutoPostBack="True"></asp:DropDownList></TD>
																					<TD>
																						<asp:DropDownList id="DropDownListMiddleType" Runat="server" OnSelectedIndexChanged="DropDownListMiddleType_SelectedIndexChanged"
																							AutoPostBack="True"></asp:DropDownList></TD>
																				</TR>
																				<TR>
																					<TD align="center" colSpan="2">
																						<asp:ListBox id="ListBoxEventOption" Runat="server" Width="200"></asp:ListBox></TD>
																				</TR>
																				<TR>
																					<TD align="center" colSpan="2">
																						<asp:ImageButton id="ImageButtonEventInsert" onclick="ImageButtonEventInsert_Click" runat="server"
																							ImageUrl="/PortalFiles/WebImage/AuditSystem/dn.gif"></asp:ImageButton>
																						<asp:ImageButton id="ImageButtonEventDelete" onclick="ImageButtonEventDelete_Click" runat="server"
																							ImageUrl="/PortalFiles/WebImage/AuditSystem/delete.gif"></asp:ImageButton></TD>
																				</TR>
																				<TR>
																					<TD align="center" colSpan="2">
																						<asp:ListBox id="ListboxEvent" Runat="server" Width="200"></asp:ListBox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD align="center" height="32">
																			<asp:button id="ButtonEventSave" onclick="ButtonEventSave_Click" runat="server" Text="儲存" CssClass="nav"></asp:button></TD>
																	</TR>
																</TABLE>
															</ajax:ajaxpanel></td>
														<td><ajax:ajaxpanel id="AjaxpanelAudit" runat="server">
																<TABLE style="BORDER-COLLAPSE: collapse" height="320" cellSpacing="1" cellPadding="1" width="100%"
																	align="center" bgColor="#ffffff" border="1">
																	<TR>
																		<TH height="32">
																			管考註記</TH></TR>
																	<TR>
																		<TD align="center">
																			<TABLE width="100%" align="center">
																				<TR>
																					<TH>
																						註記類別</TH>
																					<TH>
																						編號</TH>
																					<TH>
																						自動編號</TH></TR>
																				<TR>
																					<TD>
																						<asp:dropdownlist id="DropDownListAuditOption" Runat="server" OnSelectedIndexChanged="DropDownListAuditOption_SelectedIndexChanged"
																							AutoPostBack="True"></asp:dropdownlist></TD>
																					<TD>
																						<asp:textbox id="TextBoxAuditValue" Runat="server" Columns="1"></asp:textbox></TD>
																					<TD>
																						<asp:checkbox id="CheckBoxAutoIncrease2" Runat="server" Checked="True"></asp:checkbox></TD>
																				</TR>
																				<TR>
																					<TD align="center" colSpan="3">
																						<asp:imagebutton id="ImageButtonAuditInsert" onclick="ImageButtonAuditInsert_Click" Runat="server"
																							ImageUrl="/PortalFiles/WebImage/AuditSystem/dn.gif"></asp:imagebutton>
																						<asp:imagebutton id="ImageButtonAuditDelete" onclick="ImageButtonAuditDelete_Click" Runat="server"
																							ImageUrl="/PortalFiles/WebImage/AuditSystem/delete.gif"></asp:imagebutton></TD>
																				</TR>
																				<TR>
																					<TD align="center" colSpan="3">
																						<asp:listbox id="ListBoxAudit" Runat="server" Width="200"></asp:listbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD align="center" height="32">
																			<asp:button id="ButtonAuditSave" onclick="ButtonAuditSave_Click" runat="server" Text="儲存" CssClass="nav"></asp:button></TD>
																	</TR>
																</TABLE>
															</ajax:ajaxpanel></td>
														<td><ajax:ajaxpanel id="AjaxpanelOffice" runat="server">
																<TABLE style="BORDER-COLLAPSE: collapse" height="320" cellSpacing="1" cellPadding="1" width="100%"
																	align="center" bgColor="#ffffff" border="1">
																	<TR>
																		<TH height="32">
																			主辦組室</TH></TR>
																	<TR>
																		<TD align="center">
																			<asp:listbox id="ListBoxOfficeOption" Runat="server" Width="120"></asp:listbox></TD>
																	</TR>
																	<TR>
																		<TD align="center">
																			<asp:ImageButton id="ImageButtonOfficeInsert" onclick="ImageButtonOfficeInsert_Click" Runat="server"
																				ImageUrl="/PortalFiles/WebImage/AuditSystem/dn.gif"></asp:ImageButton>
																			<asp:ImageButton id="ImageButtonOfficeDelete" onclick="ImageButtonOfficeDelete_Click" Runat="server"
																				ImageUrl="/PortalFiles/WebImage/AuditSystem/delete.gif"></asp:ImageButton></TD>
																	</TR>
																	<TR>
																		<TD align="center">
																			<asp:ListBox id="ListBoxOffice" Runat="server" Width="120"></asp:ListBox></TD>
																	</TR>
																	<TR>
																		<TD align="center" height="32">
																			<asp:button id="ButtonOfficeSave" onclick="ButtonOfficeSave_Click" runat="server" Text="儲存"
																				CssClass="nav"></asp:button></TD>
																	</TR>
																</TABLE>
															</ajax:ajaxpanel></td>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<!----------------------------------------------------------------------------------------------------------------------> 
			</TD></TR></TABLE></form>
	</body>
</HTML>

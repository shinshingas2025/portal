<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PolicyInsuranceLawCheckFormFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.PolicyInsuranceLawCheckFormFrame" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0"
		background="/PortalFiles/WebImage/AuditSystem/1x1.gif">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
					<td width="100%" bgColor="#ffffff">
						<TABLE width="100%" border="0">
							<TR>
								<TD vAlign="top" align="center">
									<!---------------------------------------------------------------------------------------------------------------------->
									<table cellSpacing="0" cellPadding="0" align="center" border="0">
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" align="center" border="0">
													<tr>
														<td width="300" align="left">
															<table cellSpacing="0" cellPadding="0" align="left" width="100%" border="0">
																<tr>
																	<td>案由</td>
																	<td><asp:textbox id="TextBoxCause" runat="server" TextMode="MultiLine" Rows="4"></asp:textbox></td>
																</tr>
																<tr>
																	<td>案關本局內容</td>
																	<td><asp:textbox id="TextBoxConcern" runat="server" TextMode="MultiLine" Rows="6"></asp:textbox></td>
																</tr>
															</table>
														</td>
														<td width="480" align="left">
															<table cellSpacing="0" cellPadding="0" align="left" width="100%" border="0">
																<tr>
																	<td>
																		<table cellSpacing="0" cellPadding="0" align="left" width="100%" border="0">
																			<tr>
																				<td>
																					<table cellSpacing="0" cellPadding="0" align="left" border="0">
																						<tr>
																							<td width="200"><ajax:ajaxpanel id="AjaxPanelMeeting" runat="server">
																									<TABLE style="BORDER-COLLAPSE: collapse" height="160" cellSpacing="1" cellPadding="1" width="100%"
																										align="left" bgColor="#ffffff" border="1">
																										<TR>
																											<TD>會次次別</TD>
																											<TD>
																												<asp:dropdownlist id="DropDownListMeetingNumber" runat="server" OnSelectedIndexChanged="DropDownListMeetingNumber_SelectedIndexChanged"
																													AutoPostBack="True"></asp:dropdownlist></TD>
																										</TR>
																										<TR>
																											<TD>開會日期</TD>
																											<TD>
																												<asp:label id="LabelMeetingDate" runat="server" CssClass="promo"></asp:label></TD>
																										</TR>
																										<TR>
																											<TD>開會時間</TD>
																											<TD class="promo">
																												<asp:label id="LabelStartTime" runat="server"></asp:label>～
																												<asp:label id="LabelEndTime" runat="server"></asp:label></TD>
																										</TR>
																										<TR>
																											<TD>開會地點</TD>
																											<TD>
																												<asp:label id="LabelPlace" runat="server" CssClass="promo"></asp:label></TD>
																										</TR>
																										<TR>
																											<TD>主席</TD>
																											<TD>
																												<asp:label id="LabelChairPerson" runat="server" CssClass="promo"></asp:label></TD>
																										</TR>
																									</TABLE>
																								</ajax:ajaxpanel></td>
																							<td>
																								<table cellSpacing="1" cellPadding="1" align="left" bgcolor="#ffffff" border="1" width="100%"
																									style="BORDER-COLLAPSE: collapse" height="160">
																									<tr>
																										<td>主管機關</td>
																										<td><asp:dropdownlist id="DropDownListManagementInstitution" runat="server"></asp:dropdownlist></td>
																									</tr>
																									<tr>
																										<td>承辦人</td>
																										<td><asp:dropdownlist id="DropDownListPolicyLawUndertaker" runat="server"></asp:dropdownlist></td>
																									</tr>
																									<tr>
																										<td>公文文號</td>
																										<td><asp:textbox id="TextBoxDocumentNumber" runat="server"></asp:textbox></td>
																									</tr>
																									<tr>
																										<td>簽報種類</td>
																										<td><asp:dropdownlist id="DropDownListSign" runat="server"></asp:dropdownlist></td>
																									</tr>
																								</table>
																							</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																			<tr>
																				<td>
																					<table cellSpacing="0" cellPadding="0" align="left" border="0" width="100%">
																						<tr>
																							<td>擬辦</td>
																							<td><asp:dropdownlist id="DropDownListDraft" runat="server"></asp:dropdownlist></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center"><asp:button id="ButtonFormPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button><asp:button id="ButtonFormInsert" runat="server" CssClass="nav" Text="新增"></asp:button><asp:button id="ButtonFormUpdate" runat="server" CssClass="nav" Text="修改"></asp:button><asp:button id="ButtonFormDelete" runat="server" CssClass="nav" Text="刪除"></asp:button><asp:button id="ButtonFormNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></td>
										</tr>
										<tr>
											<td width="100%">
												<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<tr>
														<td align="center" width="100%"><asp:placeholder id="PlaceHolderComment" runat="server"></asp:placeholder></td>
													</tr>
													<tr>
														<td align="center" width="100%">
															<table cellSpacing="0" cellPadding="0" align="center" border="0">
																<TR>
																	<TD width="40" align="center"><asp:button id="ButtonCommentAction" runat="server" CssClass="nav" Width="40"></asp:button></TD>
																	<TD width="80" align="center"><asp:textbox id="TextBoxCommentNumber" runat="server" Width="80"></asp:textbox></TD>
																	<TD width="360" align="center"><asp:textbox id="TextBoxCommentContent" runat="server" Width="360"></asp:textbox></TD>
																</TR>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" align="left" border="0" width="100%">
													<tr>
														<td>
															<table cellSpacing="0" cellPadding="0" align="left" border="0" width="300">
																<tr>
																	<td><ajax:ajaxpanel id="AjaxpanelLaw" runat="server">
																			<TABLE style="BORDER-COLLAPSE: collapse" height="300" cellSpacing="1" cellPadding="1" width="100%"
																				align="left" bgColor="#ffffff" border="1">
																				<TR>
																					<TD>法規名稱</TD>
																					<TD colSpan="3">
																						<asp:dropdownlist id="DropDownListLaw" OnSelectedIndexChanged="DropDownListLaw_SelectedIndexChanged"
																							AutoPostBack="True" Runat="server"></asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD>法規訂定日期</TD>
																					<TD>
																						<asp:label id="LabelConstitutionDate" CssClass="promo" Runat="server"></asp:label></TD>
																					<TD>審議階段</TD>
																					<TD>
																						<asp:label id="LabelDiscussion" CssClass="promo" Runat="server"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD>法規條次及內容</TD>
																					<TD colSpan="3">
																						<asp:label id="LabelLawContent" CssClass="promo" Runat="server"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD>母法依據</TD>
																					<TD colSpan="3">
																						<asp:label id="LabelParent" CssClass="promo" Runat="server"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</ajax:ajaxpanel>
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" align="left" border="0" width="100%">
																<tr>
																	<td>
																		<table cellSpacing="1" cellPadding="1" align="left" bgcolor="#ffffff" border="1" width="100%"
																			style="BORDER-COLLAPSE: collapse" height="300">
																			<tr>
																				<td><asp:label id="LabelInsuranceMark" Runat="server">應配合開辦險種</asp:label></td>
																				<td><asp:dropdownlist id="DropDownListInsurance" Runat="server"></asp:dropdownlist></td>
																				<td><asp:label id="LabelPolicyInsuranceUndertakerMark" Runat="server">承辦人</asp:label></td>
																				<td><asp:dropdownlist id="DropDownListPolicyInsuranceUndertaker" Runat="server"></asp:dropdownlist></td>
																			</tr>
																			<tr>
																				<td><asp:label id="LabelProcessDateMark" Runat="server">納辦日期</asp:label></td>
																				<td><asp:textbox id="TextBoxProcessDate" Runat="server" Columns="6"></asp:textbox></td>
																				<td><asp:label id="LabelForecastDateMark" Runat="server">預定完成日期</asp:label></td>
																				<td><asp:textbox id="TextBoxForecastDate" Runat="server" Columns="6"></asp:textbox>
																					<asp:PlaceHolder id="PlaceHolderInsuranceScheduleLink" runat="server"></asp:PlaceHolder></td>
																			</tr>
																			<tr>
																				<td><asp:label id="LabelOutsideProcessStateMark" Runat="server">辦理情形</asp:label></td>
																				<td colSpan="3"><asp:textbox id="TextBoxOutsideProcessState" Runat="server"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td><asp:label id="LabelMemberMark" Runat="server">小組成員</asp:label></td>
																				<td colSpan="3"><ajax:ajaxpanel id="AjaxpanelMember" runat="server">
																						<TABLE cellSpacing="0" cellPadding="0" align="left" border="0">
																							<TR>
																								<TD>
																									<asp:listbox id="ListBoxMember" runat="server"></asp:listbox></TD>
																								<TD>
																									<asp:imagebutton id="ImageButtonLeft" onclick="ImageButtonLeft_Click" runat="server" ImageUrl="/PortalFiles/WebImage/AuditSystem/lt.gif"></asp:imagebutton><BR>
																									<asp:imagebutton id="ImageButtonRight" onclick="ImageButtonRight_Click" runat="server" ImageUrl="/PortalFiles/WebImage/AuditSystem/rt.gif"></asp:imagebutton></TD>
																								<TD>
																									<asp:listbox id="ListboxMemberList" runat="server"></asp:listbox></TD>
																							</TR>
																						</TABLE>
																					</ajax:ajaxpanel>
																				</td>
																			</tr>
																			<tr>
																				<td><asp:label id="LabelInsideProcessStateMark" Runat="server">本局辦理</asp:label></td>
																				<td colSpan="3"><asp:textbox id="TextBoxInsideProcessState" Runat="server"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td><asp:label id="LabelConcludeDateMark" Runat="server">辦結日期</asp:label></td>
																				<td><asp:textbox id="TextBoxConcludeDate" Runat="server" Columns="6"></asp:textbox></td>
																				<td><asp:label id="LabelConcludeNumberMark" Runat="server">辦結文號</asp:label></td>
																				<td><asp:textbox id="TextBoxConcludeNumber" Runat="server"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td align="center" colSpan="4"><asp:button id="ButtonInsurancePrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button><asp:button id="ButtonInsuranceInsert" runat="server" CssClass="nav" Text="新增"></asp:button><asp:button id="ButtonInsuranceUpdate" runat="server" CssClass="nav" Text="修改"></asp:button><asp:button id="ButtonInsuranceDelete" runat="server" CssClass="nav" Text="刪除"></asp:button><asp:button id="ButtonInsuranceNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!----------------------------------------------------------------------------------------------------------------------></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

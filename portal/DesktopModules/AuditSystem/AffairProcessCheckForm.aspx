<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AffairProcessCheckForm.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.AffairProcessCheckForm" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal.AuditSystem.Module" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>校園聯名網</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
			<LINK href="../../css/AuditSystem1.css" type="text/css" rel="stylesheet">
				<style type="text/css">.style2 { FONT-SIZE: 14px }
	</style>
				<script language="javascript">
	function AlterDiv1Height(myHeight) {
		var tempdiv=DIV1.style;
		tempdiv.height=myHeight;
	}
	function AlterDiv2Height(myHeight) {
		var tempdiv=DIV2.style;
		tempdiv.height=myHeight;
	}
	function AlterDiv3Height(myHeight) {
		var tempdiv=DIV3.style;
		tempdiv.height=myHeight;
	}
				</script>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><FONT face="新細明體"></FONT></P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=160 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">各項業務辦理管考表</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' ></td>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif' ></td>
					</tr>
					<tr>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' ></td>
						<td width="100%" bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE>
											<TR>
												<TH class="dingbat" colSpan="2">
													行政院金融監督管理保險局各項業務辦理管考表
												</TH>
											</TR>
											<TR>
												<TD>
													<TABLE>
														<TR>
															<TD>
																<ajax:ajaxpanel id="AjaxPanelPlace" runat="server">
																	<TABLE width="100%">
																		<TR>
																			<TD>
																				<TABLE cellSpacing="0" cellPadding="0">
																					<TR>
																						<TD>應辦事項：</TD>
																						<TD>
																							<asp:dropdownlist id="DropDownListAffair" runat="server" CssClass="footer" Width="480" AutoPostBack="true"
																								OnSelectedIndexChanged="DropDownListAffair_SelectedIndexChanged"></asp:dropdownlist></TD>
																					</TR>
																				</TABLE>
																			</TD>
																			<TD>
																				<TABLE cellSpacing="0" cellPadding="0" align="right">
																					<TR>
																						<TD>重要程度：</TD>
																						<TD>
																							<asp:dropdownlist id="DropDownListPriority" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
																		<TR>
																			<TD colSpan="2">
																				<TABLE cellSpacing="0" cellPadding="0">
																					<TR>
																						<TD>決議應辦事項：</TD>
																						<TD class="sidebarFooter" width="600">
																							<asp:label id="LabelResolutionContent" runat="server"></asp:label></TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
																		<TR>
																			<TD colspan="2">歷史資料<input type="button" id="ButtonAlterDiv1Small" onclick="AlterDiv1Height(16);" value="隱藏"><input type="button" id="ButtonAlterDiv1Big" onclick="AlterDiv1Height(280);" value="展開">
																				<DIV style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; OVERFLOW: scroll; BORDER-LEFT: 1px solid; WIDTH: 680px; BORDER-BOTTOM: 1px solid; HEIGHT: 80px; TEXT-OVERFLOW: ellipsis"
																					align="left" id="DIV1" runat="server">
																					<asp:PlaceHolder id="PlaceHolderProcessHistory" Runat="server" OnLoad="DropDownListAffair_SelectedIndexChanged"></asp:PlaceHolder></DIV>
																			</TD>
																		</TR>
																	</TABLE>
															</TD>
															</ajax:ajaxpanel>
														</TR>
														<TR>
															<TD>
																會管資料<input type="button" id="ButtonAlterDiv2Small" onclick="AlterDiv2Height(16);" value="隱藏"><input type="button" id="ButtonAlterDiv2Big" onclick="AlterDiv2Height(280);" value="展開">
																<div align="center" id="DIV2" name="DIV2" style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; OVERFLOW: scroll; BORDER-LEFT: 1px solid; WIDTH: 700px; BORDER-BOTTOM: 1px solid; HEIGHT: 16px; TEXT-OVERFLOW: ellipsis">
																	<TABLE cellpadding="1" cellspacing="1" border="0" align="left" width="100%">
																		<TR>
																			<TD>
																				<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																					<TR>
																						<TD><SPAN class="legal">本<BR>會<BR>考<BR>管<BR>事</SPAN></TD>
																						<TD>
																							<asp:textbox id="TextBoxAssociationAffair" runat="server" TextMode="MultiLine" Rows="6" Columns="16"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD colSpan="2">
																							<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																								<TR>
																									<TD>會管編號</TD>
																									<TD>
																										<asp:textbox id="TextBoxAssociationNumber" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>會管會次別</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListAssociationMeetingNumber" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																								<TR>
																									<TD>會管日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxAssociationDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>會管預結日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxAssociationForecastDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>會管管考現況</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListAssociationState" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																							</TABLE>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																			<TD>
																				<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																					<TR>
																						<TD class="legal">委<BR>
																							員<BR>
																							管<BR>
																							考<BR>
																							事</TD>
																						<TD>
																							<asp:textbox id="TextBoxCouncilAffair" runat="server" TextMode="MultiLine" Rows="6" Columns="16"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD colSpan="2">
																							<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																								<TR>
																									<TD>委管編號</TD>
																									<TD>
																										<asp:textbox id="TextBoxCouncilNumber" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>委管會次別</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListCouncilMeetingNumber" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																								<TR>
																									<TD>委管日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxCouncilDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>委管預結日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxCouncilForecastDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>委管管考現況</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListCouncilState" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																							</TABLE>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																			<TD>
																				<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																					<TR>
																						<TD class="legal">局<BR>
																							務<BR>
																							管<BR>
																							考<BR>
																							事</TD>
																						<TD>
																							<asp:textbox id="TextBoxBureauAffair" runat="server" TextMode="MultiLine" Rows="6" Columns="16"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD colSpan="2">
																							<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																								<TR>
																									<TD>局管編號</TD>
																									<TD>
																										<asp:textbox id="TextBoxBureauNumber" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>局管會次別</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListBureauMeetingNumber" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																								<TR>
																									<TD>局管日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxBureauDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>局管預結日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxBureauForecastDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>局管管考現況</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListBureauState" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																							</TABLE>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																			<TD>
																				<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																					<TR>
																						<TD class="legal">組<BR>
																							務<BR>
																							管<BR>
																							考<BR>
																							事</TD>
																						<TD>
																							<asp:textbox id="TextBoxSectionAffair" runat="server" TextMode="MultiLine" Rows="6" Columns="16"></asp:textbox></TD>
																					</TR>
																					<TR>
																						<TD colSpan="2">
																							<TABLE cellpadding="0" cellspacing="0" border="0" align="center">
																								<TR>
																									<TD>組管編號</TD>
																									<TD><FONT face="新細明體">
																											<asp:textbox id="TextBoxSectionNumber" runat="server" Columns="10"></asp:textbox></FONT></TD>
																								</TR>
																								<TR>
																									<TD>組管會次別</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListSectionMeetingNumber" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																								<TR>
																									<TD>組管日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxSectionDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>組管預結日期</TD>
																									<TD>
																										<asp:textbox id="TextBoxSectionForecastDate" runat="server" Columns="10"></asp:textbox></TD>
																								</TR>
																								<TR>
																									<TD>組管管考現況</TD>
																									<TD>
																										<asp:dropdownlist id="DropDownListSectionState" runat="server" CssClass="footer"></asp:dropdownlist></TD>
																								</TR>
																							</TABLE>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
																	</TABLE>
																</div>
															</TD>
														</TR>
													</TABLE>
												</TD>
												<TD vAlign="top">
													<TABLE>
														<TR>
															<TD>主辦組室：</TD>
															<TD>
																<asp:dropdownlist id="DropDownListMainOffice" runat="server" CssClass="footer" AutoPostBack="True"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>主辦科：</TD>
															<TD>
																<asp:dropdownlist id="DropDownListMainBranch" runat="server" CssClass="footer"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>主辦科承辦：</TD>
															<TD>
																<asp:dropdownlist id="DropDownListMainBranchUndertaker" runat="server" CssClass="footer"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>協辦組室：</TD>
															<TD>
																<asp:dropdownlist id="DropDownListAssistOffice" runat="server" CssClass="footer"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>協辦科：</TD>
															<TD>
																<asp:dropdownlist id="DropDownListAssistBranch" runat="server" CssClass="footer"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2">
													<asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button>
													<asp:button id="ButtonInsert" runat="server" CssClass="nav" Text="新增"></asp:button>
													<asp:button id="ButtonUpdate" runat="server" CssClass="nav" Text="修改"></asp:button>
													<asp:button id="ButtonDelete" runat="server" CssClass="nav" Text="刪除"></asp:button>
													<asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></TD>
											</TR>
											<TR>
												<TD width="100%" colSpan="2">
													處理情形<input type="button" id="ButtonAlterDiv3Small" onclick="AlterDiv3Height(16);" value="隱藏"><input type="button" id="ButtonAlterDiv3Big" onclick="AlterDiv3Height(280);" value="展開">
													<div align="left" id="DIV3" style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; OVERFLOW: scroll; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; HEIGHT: 160px; TEXT-OVERFLOW: ellipsis">
														<asp:placeholder id="PlaceHolderProcess" runat="server"></asp:placeholder>
													</div>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<div align="left" id="DIV4" style="BORDER-RIGHT: 0px solid; BORDER-TOP: 0px solid; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px solid; HEIGHT: 160px; TEXT-OVERFLOW: ellipsis">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD width="52">
																	<asp:button id="ButtonProcessUpdate" runat="server" CssClass="nav" width="48"></asp:button></TD>
																<TD width="82"><FONT face="新細明體">
																		<asp:textbox id="TextBoxProcessDate" runat="server" Columns="7"></asp:textbox></FONT></TD>
																<TD width="302"><FONT face="新細明體">
																		<asp:textbox id="TextBoxProcessState" runat="server" TextMode="MultiLine" Rows="4" Columns="35"></asp:textbox></FONT></TD>
																<TD width="90">
																	<asp:textbox id="TextBoxNote" runat="server" TextMode="MultiLine" Rows="4" Columns="8"></asp:textbox></TD>
																<TD>
																	<asp:placeholder id="PlaceHolderAttribute" Runat="server"></asp:placeholder></TD>
																<TD width="40">
																	<asp:button id="ButtonProcessMore" runat="server" CssClass="nav"></asp:button></TD>
															</TR>
														</TABLE>
													</div>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2"></TD>
											</TR>
										</TABLE>
										<!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
							</TABLE>
						</td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></td>
					</tr>
					<tr>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ></td>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>

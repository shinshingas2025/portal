<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.AuditSystemReport" CodeBehind="AuditSystemReport.ascx.vb" AutoEventWireup="false" %>
<table cellSpacing="0" cellPadding="0" width="98%" border="0">
	<tr>
		<td colSpan="3"><ASPNETPORTAL:TITLE id="Title1" EditShow="false" EditText="管理資料" EditUrl="~/DesktopModules/Audit/AuditList.aspx"
				runat="server"></ASPNETPORTAL:TITLE></td>
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
						<!----------------------------------------------------------------------------------------------------------------------><ajax:ajaxpanel id="AjaxPanelPlace" runat="server">
							<TABLE class="TTable1" id="Table1" height="400" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TR vAlign="top">
									<TH width="10%" height="16">
										Menu</TH>
									<TH width="90%" height="16">
										ReportDesktop</TH></TR>
								<TR vAlign="top">
									<TD align="center" width="10%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR>
												<TD align="center"><IMG alt="資料報表" src="/PortalFiles/WebImage/AuditSystem/DataReport.gif" border="1"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton10" onclick="LinkButton1_Click" runat="server" WorkID="21">
														<img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckReport.gif" border="0"
															alt="各組業務辦理管考報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton11" onclick="LinkButton1_Click" runat="server" WorkID="22">
														<img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckReportByAttribute.gif"
															border="0" alt="各類業務辦理管考報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton12" onclick="LinkButton1_Click" runat="server" WorkID="23">
														<img src="/PortalFiles/WebImage/AuditSystem/MeetingRecordReport.gif" border="0" alt="會議記錄報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton13" onclick="LinkButton1_Click" runat="server" WorkID="24">
														<img src="/PortalFiles/WebImage/AuditSystem/SectionResolutionCheckReport.gif" border="0"
															alt="組務會議追蹤檢查報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton1" onclick="LinkButton1_Click" runat="server" WorkID="41">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportMeetingFrame02.gif" border="0"
															alt="局務會議追蹤檢查報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton2" onclick="LinkButton1_Click" runat="server" WorkID="42">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportMeetingFrame01.gif" border="0"
															alt="委員會議追蹤檢查報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton3" onclick="LinkButton1_Click" runat="server" WorkID="43">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame03.gif" border="0"
															alt="主委交辦追蹤檢查報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton4" onclick="LinkButton1_Click" runat="server" WorkID="44">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame02.gif" border="0"
															alt="月月有成績報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton5" onclick="LinkButton1_Click" runat="server" WorkID="45">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame04.gif" border="0"
															alt="各組室重要施政計畫報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton6" onclick="LinkButton1_Click" runat="server" WorkID="46">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame08.gif" border="0"
															alt="重要施政行事曆報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton7" onclick="LinkButton1_Click" runat="server" WorkID="47">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame09.gif" border="0"
															alt="新聞稿報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton8" onclick="LinkButton1_Click" runat="server" WorkID="48">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame07.gif" border="0"
															alt="重大輿情擬答報表" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton9" onclick="LinkButton1_Click" runat="server" WorkID="49">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame06.gif" border="0"
															alt="法規命令異動目錄" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton14" onclick="LinkButton1_Click" runat="server" WorkID="4A">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame05.gif" border="0"
															alt="行政規則異動目錄" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton15" onclick="LinkButton1_Click" runat="server" WorkID="4B">
														<img src="/PortalFiles/WebImage/AuditSystem/ReportFrame01.gif" border="0"
															alt="課程報名名冊" /></asp:LinkButton></TD>
											</TR>
										</TABLE>
									</TD>
									<TD align="center" width="90%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR vAlign="top">
												<TD align="center">
													<asp:PlaceHolder id="PlaceHolderWorkDesktop" runat="server"></asp:PlaceHolder></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</ajax:ajaxpanel>
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

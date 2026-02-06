<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.AuditSystemDesktop" CodeBehind="AuditSystemDesktop.ascx.vb" AutoEventWireup="false" %>
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
										WorkDesktop</TH></TR>
								<TR vAlign="top">
									<TD align="center" width="10%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR>
												<TD align="center"><IMG alt="資料維護" src="/PortalFiles/WebImage/AuditSystem/DataMaintain.gif" border="1">
												</TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton4" onclick="LinkButton1_Click" runat="server" WorkID="50">
														<img src="/PortalFiles/WebImage/AuditSystem/ResolutionAdmin.gif" border="0" alt="決議事項" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton5" onclick="LinkButton1_Click" runat="server" WorkID="1">
														<img src="/PortalFiles/WebImage/AuditSystem/MeetingRecord.gif" border="0" alt="會議記錄" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton6" onclick="LinkButton1_Click" runat="server" WorkID="2">
														<img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckForm.gif" border="0" alt="各項業務辦理管考表" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton7" onclick="LinkButton1_Click" runat="server" WorkID="3">
														<img src="/PortalFiles/WebImage/AuditSystem/NewsRelease.gif" border="0" alt="新聞稿" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton8" onclick="LinkButton1_Click" runat="server" WorkID="4">
														<img src="/PortalFiles/WebImage/AuditSystem/CouncilmanInstruction.gif" border="0" alt="委員交辦" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton1" onclick="LinkButton1_Click" runat="server" WorkID="5">
														<img src="/PortalFiles/WebImage/AuditSystem/LawAdmin.gif" border="0" alt="法規管理" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton3" onclick="LinkButton1_Click" runat="server" WorkID="6">
														<img src="/PortalFiles/WebImage/AuditSystem/PolicyInsuranceLawCheckForm.gif" border="0"
															alt="政策保險法規管理" />
													</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center"><IMG alt="資料檢索" src="/PortalFiles/WebImage/AuditSystem/DataQuery.gif" border="1"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton9" onclick="LinkButton1_Click" runat="server" WorkID="11">
														<img src="/PortalFiles/WebImage/AuditSystem/DatabaseQuery.gif" border="0" alt="資料檢索" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center"><IMG alt="代碼維護" src="/PortalFiles/WebImage/AuditSystem/CodeMaintain.gif" border="1"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton14" onclick="LinkButton1_Click" runat="server" WorkID="31">
														<img src="/PortalFiles/WebImage/AuditSystem/NormalCodeAdmin.gif" border="0" alt="一般代碼" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton15" onclick="LinkButton1_Click" runat="server" WorkID="32">
														<img src="/PortalFiles/WebImage/AuditSystem/AttributeCodeAdmin.gif" border="0" alt="處理情形屬性代碼" /></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:LinkButton id="Linkbutton2" onclick="LinkButton1_Click" runat="server" WorkID="33">
														<img src="/PortalFiles/WebImage/AuditSystem/InsuranceCodeAdmin.gif" border="0" alt="保險代碼" /></asp:LinkButton></TD>
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

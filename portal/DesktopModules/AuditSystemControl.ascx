<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.AuditSystemControl" CodeBehind="AuditSystemControl.ascx.vb" AutoEventWireup="false" %>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPORTAL:TITLE id="Title1" runat="server" EditUrl="~/DesktopModules/Audit/AuditList.aspx" EditText="管理資料"
				EditShow="false"></ASPNETPORTAL:TITLE>
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="#ffffff" width="100%">
			<TABLE border="0" width="100%">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="33%" align="center"><a href='DesktopModules/AuditSystem/NormalCodeAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/normalcodeadmin.gif" border="0" alt="一般代碼管理"></a></td>
								<td width="33%" align="center"><a href='DesktopModules/AuditSystem/AttributeCodeAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/attributecodeadmin.gif" border="0" alt="處理屬性代碼管理"></a></td>
								<td width="33%" align="center"><a href='DesktopModules/AuditSystem/InsuranceCodeAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/insurancecodeadmin.gif" border="0" alt="保險代碼管理"></a></td>
							</tr>
							<TR>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/AffairProcessCheckForm.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckForm.gif" border="0" alt="各項業務辦理管考表"></a></td>
								<td align="center" width="34%"><a href='DesktopModules/AuditSystem/AffairProcessCheckReport.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckReport.gif" border="0"
											alt="各組業務辦理管考報表"></a></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/AffairProcessCheckReportByAttribute.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/AffairProcessCheckReportByAttribute.gif"
											border="0" alt="各類業務辦理管考報表"></a></td>
							</TR>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/MeetingRecordAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/MeetingRecord.gif" border="0" alt="會議記錄"></a></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/PolicyMeetingRecordList.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/PolicyMeetingRecordList.gif" border="0" alt="政策保險會議列表"></a></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/MeetingRecordReport.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/MeetingRecordReport.gif" border="0" alt="會議記錄報表"></a></td>
							</tr>
							<tr>
								<td align="center" width="33%"></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/SectionResolutionCheckReport.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/SectionResolutionCheckReport.gif" border="0"
											alt="組務會議追蹤檢查報表"></a></td>
							</tr>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/NewsReleaseAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/NewsRelease.gif" border="0" alt="新聞稿"></a></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/NewsReleaseList.aspx'><img src="images/NewsReleaseList.gif" border="0" alt="新聞稿列表"></a></td>
							</tr>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/CouncilmanInstructionAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/CouncilmanInstruction.gif" border="0" alt="委員交辦"></a></td>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/CouncilmanInstructionList.aspx'><img src="images/CouncilmanInstructionList.gif" border="0" alt="委員交辦列表"></a></td>
							</tr>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/DatabaseQuery.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/DatabaseQuery.gif" border="0" alt="資料庫檢索"></a></td>
								<td align="center" width="33%"></td>
							</tr>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/LawAdmin.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/LawAdmin.gif" border="0" alt="法規管理"></a></td>
								<td align="center" width="33%"></td>
							</tr>
							<tr>
								<td align="center" width="33%"><a href='DesktopModules/AuditSystem/PolicyInsuranceLawCheckForm.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>'><img src="/PortalFiles/WebImage/AuditSystem/PolicyInsuranceLawCheckForm.gif" border="0" alt="政策保險法規"></a></td>
								<td align="center" width="33%"></td>
							</tr>
						</TABLE>
						<!---------------------------------------------------------------------------------------------------------------------->
					</TD>
				</TR>
			</TABLE>
		</td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
	</tr>
	<tr>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>

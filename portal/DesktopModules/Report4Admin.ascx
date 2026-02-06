<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.Report4Admin" CodeBehind="Report4Admin.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<table cellSpacing="0" cellPadding="0" width="98%" border="0">
	<tr>
		<td colSpan="3"><ASPNETPORTAL:TITLE id="Title1" EditShow="false" EditText="管理報表" EditUrl="~/DesktopModules/Report/ReportAdmin.aspx"
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
					<TD vAlign="top" align="center" width="100%">
						<!---------------------------------------------------------------------------------------------------------------------->
						<span class="ItemTitle">
							<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="1%"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
									<td width="99%"><a href='DesktopModules/Report/TalentWantedListGroupByTime.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>'>求才登記區間名冊</a></td>
								</tr>
								<tr>
									<td width="1%"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
									<td width="99%"><a href='DesktopModules/Report/FlowRateGroupBySchool.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>'>各校流量分析報表</a></td>
								</tr>
								<tr>
									<td width="1%"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
									<td width="99%"><a href='DesktopModules/Report/JobWantedListGroupBySchool.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>'>各校求職登記數據統計表</a></td>
								</tr>
								<tr>
									<td width="1%"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
									<td width="99%"><a href='DesktopModules/Report/ModuleUsageGroupBySchool.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>'>各校管理模組使用狀況統計表</a></td>
								</tr>
							</TABLE>
						</span>
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

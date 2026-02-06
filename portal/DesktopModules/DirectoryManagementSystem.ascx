<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.DirectoryManagementSystem" CodeBehind="DirectoryManagementSystem.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<table width="98%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<ASPNETPORTAL:TITLE id="Title1" runat="server" EditUrl="~/DesktopModules/DirectoryManagementSystem/DirectoryManagementSystemAdmin.aspx"
				EditText="管理資料" EditShow="false"></ASPNETPORTAL:TITLE>
		</td>
	</tr>
	<tr>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
		<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
	</tr>
	<tr>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
		<td bgcolor="#ffffff">
			<TABLE border="0" width="100%">
				<TR>
					<TD valign="top" align="center">
						<!---------------------------------------------------------------------------------------------------------------------->
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td align="center" width="100%"><a href='DesktopModules/DirectoryManagementSystem/DMSBrowse.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>&amp;parentID=2006010100000001'><img src="images/DMS/tech0033.gif" border="0" alt="目錄管理系統"></a></td>
							</TR>
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

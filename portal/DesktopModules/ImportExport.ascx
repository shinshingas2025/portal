<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.ImportExport" CodeBehind="ImportExport.ascx.vb" AutoEventWireup="false" %>
<table cellSpacing="0" cellPadding="0" width="98%" border="0">
	<tr>
		<td colSpan="3"><ASPNETPORTAL:TITLE id="Title1" runat="server" editshow="true" EditUrl="~/DesktopModules/ImportExport/ImportExportAdmin.aspx"
				EditText="管理資料"></ASPNETPORTAL:TITLE></td>
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
						<TABLE class="TTable1" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td align="center" width="50%">
									<asp:Label id="Label1" runat="server" CssClass="subhead">設定檔：</asp:Label><asp:Label id="LabelImportTitle" runat="server" CssClass="normal"></asp:Label><A href='DesktopModules/ImportExport/ImportUser.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>' >
										<BR>
										匯入資料</A></td>
								<td align="center" width="50%">
									<asp:Label id="Label2" runat="server" CssClass="subhead">設定檔：</asp:Label><asp:Label id="LabelExportTitle" runat="server" CssClass="normal"></asp:Label><A href='DesktopModules/ImportExport/ExportUser.aspx?sid=<%=Request.Params("sid")%>&mid=<%=ModuleId%>&tabid=<%=tabid%>&tabindex=<%=tabindex%>' >
										<BR>
										匯出資料</A></td>
							</TR>
						</TABLE>
					</TD>
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

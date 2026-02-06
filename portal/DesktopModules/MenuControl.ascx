<%@ Register TagPrefix="uc1" TagName="DesktopNormalTitle" Src="../DesktopNormalTitle.ascx" %>
<%@ Control language="vb" Inherits="ASPNET.StarterKit.Portal.MenuControl" CodeBehind="MenuControl.ascx.vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleTitle" Src="../DesktopModuleTitle.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<uc1:DesktopModuleTitle id="DesktopModuleTitle1" runat="server" EditShow="false"></uc1:DesktopModuleTitle>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="ttable"
							height="100%">
							<TR>
								<TD width="200" vAlign="top"><FONT face="新細明體">
										<!--<iewc:treeview id="TreeView2" runat="server" Width="200px" ExpandLevel="1" AutoPostBack="True"
											Height="100%"></iewc:treeview>-->
                                    <asp:TreeView ID="TreeView1" runat="server" >
                                       
                                    </asp:TreeView>
                                    </FONT></TD>
								<TD>
									<iframe id="Iframe1" frameBorder="0" width="100%" height="1000" runat="server" class="ttable" ></iframe></TD>
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
		<td height="29"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
		<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' width="100%" height=29><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
		<td height="29"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
	</tr>
</table>
<asp:XmlDataSource ID="myXmlDataSource" runat="server" DataFile="D:\ShinUser\Documents\Visual Studio 2012\Projects\portal\portal\PortalFiles\xml\User\CAdmin.xml"></asp:XmlDataSource>
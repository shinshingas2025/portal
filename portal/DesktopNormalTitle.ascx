<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DesktopNormalTitle.ascx.vb" Inherits="DesktopNormalTitle" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
	<TR>
		<TD width=1 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0010.gif'><IMG 
      src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></TD>
		<TD width="<%=ModuleTitle.Text.Length * 13 %>px" 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif'>
			<asp:label id="ModuleTitle" runat="server" EnableViewState="false" cssclass="Head"></asp:label></TD>
		<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0011.gif'><IMG 
      src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></TD>
		<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0011.gif'>
		<TD width=45 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0010.gif'>
		</TD>
	</TR>
</TABLE>

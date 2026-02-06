<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VoteResult.aspx.vb" Inherits="ASPNET.StarterKit.Portal.VoteResult"%>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P align="center"><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><BR>
			</P>
			<BR>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0" align="center"
				bgColor="#ffffff">
				<TR>
					<TD align="center"><FONT face="新細明體">
							<asp:label id="lblQuestion" runat="server" CssClass="Head"></asp:label></FONT></TD>
				</TR>
				<TR>
					<TD align="center"><FONT face="新細明體">
							<asp:panel id="Panel1" runat="server"></asp:panel></FONT><FONT face="新細明體"></FONT></TD>
				</TR>
				<TR>
					<TD align="center"><asp:linkbutton id="linkBack" runat="server">返回</asp:linkbutton></TD>
				</TR>
			</TABLE>
			<P><FONT face="新細明體"></FONT></P>
		</form>
	</body>
</HTML>

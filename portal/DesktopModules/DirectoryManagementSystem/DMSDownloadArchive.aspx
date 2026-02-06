<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DMSDownloadArchive.aspx.vb" Inherits="ASPNET.StarterKit.Portal.DMSDownloadArchive" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
			<LINK href="../../css/DMS/styles.css" type="text/css" rel="stylesheet">
				<style type="text/css">
.style1 { FONT-SIZE: 16px }
</style>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table class="margin2" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">下載檔案</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td></td>
						<td></td>
						<td></td>
					</tr>
					<tr>
						<td></td>
						<td width="100%">
							<TABLE class="border2" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="stats1">下載檔案：
										<asp:hyperlink class="text" id="HyperLink1" runat="server"></asp:hyperlink>
										<asp:Label id="LabelResult" runat="server" ForeColor="Red"></asp:Label></td>
								</tr>
								<tr>
									<td class="login1">檔案密碼：
										<asp:textbox CssClass="ftext1" id="TextBoxPassword" runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="center">
										<asp:Button id="ButtonOK" runat="server" Text="確定"></asp:Button>
										<asp:Button id="ButtonCancel" runat="server" Text="取消"></asp:Button><asp:button id="ButtonReturn" runat="server" Text="返回"></asp:button></td>
								</tr>
							</TABLE>
						</td>
						<td></td>
					</tr>
					<tr>
						<td></td>
						<td></td>
						<td></td>
					</tr>
				</table>
			</P>
		</form>
		<CENTER></CENTER>
	</body>
</HTML>

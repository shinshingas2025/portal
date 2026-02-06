<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DMSBrowse.aspx.vb" Inherits="ASPNET.StarterKit.Portal.DMSBrowse" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Import Namespace="System.IO" %>
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
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table width="750" border="0" align="center" cellPadding="0" cellSpacing="0" class="margin2">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">目錄管理系統</asp:label></td>
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
							<TABLE width="100%" cellpadding="0" cellspacing="0" class="border2">
								<tr>
									<td><asp:button id="ButtonAddFolder" runat="server" CssClass="button1" Text="新增目錄"></asp:button><asp:button id="ButtonAddArchive" runat="server" CssClass="button1" Text="新增檔案"></asp:button></td>
								</tr>
								<tr>
									<td><asp:button id="ButtonReturnParentDirectory" runat="server" CssClass="button1" Text="回上層目錄"></asp:button><asp:button id="ButtonReturnHomeDirectory" runat="server" CssClass="button1" Text="回根目錄"></asp:button><asp:button id="ButtonDirectoryTree" runat="server" CssClass="button1" Text="目錄結構"></asp:button></td>
								</tr>
								<tr>
									<td class="dir1">目前目錄：
										<asp:label id="LabelCurrentDirectory" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td class="policy1">目錄權限：
										<asp:label id="LabelDirectoryPermission" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td><span class="border1">
											<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
										</span></td>
								</tr>
								<tr>
									<td align="center"><asp:button id="Button2" runat="server" Text="返回"></asp:button></td>
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

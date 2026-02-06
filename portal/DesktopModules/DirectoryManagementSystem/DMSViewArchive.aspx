<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DMSViewArchive.aspx.vb" Inherits="ASPNET.StarterKit.Portal.DMSViewArchive" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P><FONT face="新細明體"></FONT>&nbsp;</P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=160 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="LabelDetail" runat="server" CssClass="itemtitle">瀏覽檔案</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
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
						<td bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
											border="0">
											<tr>
												<td align="center" colSpan="3"><FONT face="新細明體"></FONT></td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td><FONT face="新細明體">文件型態</FONT></td>
															<td><asp:label id="LabelDocumentType" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">檔案連結</FONT></td>
															<td><asp:label id="LabelURL" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">名稱</FONT></td>
															<td align="left"><asp:label id="LabelName" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">關鍵字集</FONT></td>
															<td><asp:label id="LabelMetaData" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">主版本數</FONT></td>
															<td><asp:label id="LabelMajorRevision" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">次版本數</FONT></td>
															<td><asp:label id="LabelMinorRevision" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">擁有人</FONT></td>
															<td><FONT face="新細明體"><asp:label id="LabelOwner" runat="server"></asp:label></FONT></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">權限</FONT></td>
															<td><asp:label id="LabelPermission" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">密碼</FONT></td>
															<td><FONT face="新細明體"><asp:label id="LabelPassword" runat="server"></asp:label></FONT></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">描述</FONT></td>
															<td><asp:label id="LabelDescription" runat="server"></asp:label></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3"><asp:button id="ButtonReturn" runat="server" Text="返回"></asp:button></td>
											</tr>
										</TABLE>
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
			</P>
		</form>
	</body>
</HTML>

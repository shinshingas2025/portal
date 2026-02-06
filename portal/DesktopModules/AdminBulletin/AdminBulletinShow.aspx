<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminBulletinShow.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AdminBulletinShow" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>校園聯名網</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><FONT face="新細明體"></FONT></P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=160 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">訊息詳細資料</asp:label></td>
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
													<table border="1" width="100%" style="BORDER-COLLAPSE: collapse" bgcolor="#ffffff" cellPadding="1"
														cellSpacing="1" align="left">
														<tr>
															<td width="10%"><asp:label id="Label1" runat="server" CssClass="subhead">訊息型態：</asp:label></td>
															<td align="left" height="28"><asp:label id="LabelBulletinType" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="10%" height="22"><asp:label id="Label2" runat="server" CssClass="subhead">主題：</asp:label></td>
															<td height="22"><asp:label id="LabelTitle" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="10%" vAlign="top" height="91"><asp:label id="Label3" runat="server" CssClass="subhead">內容：</asp:label></td>
															<td vAlign="top" height="91"><asp:label id="LabelDescription" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="10%" height="22"><asp:label id="Label8" runat="server" CssClass="subhead">相關連結：</asp:label></td>
															<td height="22">
																<asp:HyperLink id="HyperLinkAffiliatedURL" runat="server" CssClass="normal" ImageUrl="~/images/link.gif"></asp:HyperLink></td>
														</tr>
														<tr>
															<td width="10%" height="22"><asp:label id="Label4" runat="server" CssClass="subhead">發佈單位：</asp:label></td>
															<td height="22"><asp:label id="LabelAnnounceUnit" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td align="center" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																	<tr>
																		<td width="71">
																			<asp:Label id="Label5" runat="server" CssClass="subhead">起始日期：</asp:Label></td>
																		<td>
																			<asp:Label id="LabelEnableDate" runat="server" CssClass="normal"></asp:Label></td>
																		<td>
																			<asp:Label id="Label6" runat="server" CssClass="subhead">終止日期：</asp:Label></td>
																		<td>
																			<asp:Label id="LabelDisableDate" runat="server" CssClass="normal"></asp:Label></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td align="center" colSpan="2">
																<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" height="86">
																	<tr>
																		<td width="10%"><asp:label id="Label12" runat="server" CssClass="subhead">附件1：</asp:label></td>
																		<td height="28"><asp:PlaceHolder ID="PlaceHolder1" Runat="server"></asp:PlaceHolder></td>
																	</tr>
																	<tr>
																		<td width="10%"><asp:label id="Label13" runat="server" CssClass="subhead">附件2：</asp:label></td>
																		<td height="30"><asp:PlaceHolder ID="Placeholder2" Runat="server"></asp:PlaceHolder></td>
																	</tr>
																	<tr>
																		<td width="10%"><asp:label id="Label14" runat="server" CssClass="subhead">附件3：</asp:label></td>
																		<td><asp:PlaceHolder ID="Placeholder3" Runat="server"></asp:PlaceHolder></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colspan="3">
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
											</tr>
										</TABLE>
										<!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
							</TABLE>
						</td>
						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
					</tr>
					<tr>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AuditShow.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditShow" %>
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
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
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
          ><asp:label id="LabelDetail" runat="server" CssClass="itemtitle">詳細稽核資料</asp:label></td>
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
															<td width="79"><asp:label id="Label1" runat="server" CssClass="subhead">使用者</asp:label></td>
															<td align="left"><asp:label id="LabelUserName" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><asp:label id="Label2" runat="server" CssClass="subhead">模組</asp:label></td>
															<td><asp:label id="LabelModuleName" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><asp:label id="Label3" runat="server" CssClass="subhead">操作型態</asp:label></td>
															<td><asp:label id="LabelActionType" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td width="79"><asp:label id="Label4" runat="server" CssClass="subhead">時間</asp:label></td>
															<td><asp:label id="LabelCreatedDate" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label5" runat="server" CssClass="subhead">來源</asp:label></td>
															<td><asp:label id="LabelSender" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label6" runat="server" CssClass="subhead">服務物件</asp:label></td>
															<td><asp:label id="LabelReceiver" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label7" runat="server" CssClass="subhead">使用服務</asp:label></td>
															<td><asp:label id="LabelService" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label8" runat="server" CssClass="subhead">主鍵值</asp:label></td>
															<td><asp:label id="LabelPrimaryKey" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label9" runat="server" CssClass="subhead">備註</asp:label></td>
															<td><asp:label id="LabelDescription" runat="server" CssClass="normal"></asp:label></td>
														</tr>
														<tr>
															<td><asp:label id="Label10" runat="server" CssClass="subhead">詳細資訊</asp:label></td>
															<td><div style="BORDER-RIGHT:1px solid; BORDER-TOP:1px solid; OVERFLOW:scroll; BORDER-LEFT:1px solid; WIDTH:600px; BORDER-BOTTOM:1px solid; TEXT-OVERFLOW:ellipsis"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></div>
															</td>
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
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>

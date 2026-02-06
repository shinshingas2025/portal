<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuestBookView.aspx.vb" Inherits="ASPNET.StarterKit.Portal.GuestBookView" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner>
			<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">詳細資料</asp:label></td>
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
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<!---------------------------------------------------------------------------------------------------------------------->
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td vAlign="top">
														<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD width="108">
																	<asp:Label id="Label1" runat="server" CssClass="subhead">標題：</asp:Label></TD>
																<TD>
																	<P><asp:label id="LabelTitle" runat="server" CssClass="normal"></asp:label></P>
																</TD>
															</TR>
															<TR>
																<TD colSpan="2">
																	<HR width="100%" SIZE="1">
																</TD>
															</TR>
															<TR>
																<TD vAlign="top" width="108" height="82">
																	<asp:Label id="Label2" runat="server" CssClass="subhead">留言內容：</asp:Label></TD>
																<TD vAlign="top">
																	<P><asp:label id="LabelDescription" runat="server"></asp:label></P>
																</TD>
															</TR>
															<TR>
																<TD width="108">
																	<asp:Label id="Label3" runat="server" CssClass="subhead">時間：</asp:Label></TD>
																<TD>
																	<asp:label id="LabelCreatedDate" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="108">
																	<asp:Label id="Label4" runat="server" CssClass="subhead">留言者：</asp:Label></TD>
																<TD>
																	<asp:label id="LabelCreatedByUser" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="108">
																	<asp:Label id="Label5" runat="server" CssClass="subhead">電子郵件帳號：</asp:Label></TD>
																<TD>
																	<asp:Label id="LabelEmail" runat="server" Visible="False"></asp:Label>
																	<asp:Label id="LabelEmailText" runat="server" Visible="False"></asp:Label></TD>
															</TR>
															<TR>
																<TD vAlign="top" colSpan="2" height="12">
																	<HR width="100%" SIZE="1">
																</TD>
															</TR>
															<TR>
																<TD vAlign="top" width="108" height="110">
																	<asp:Label id="Label6" runat="server" CssClass="subhead">回覆：</asp:Label></TD>
																<TD height="110">
																	<asp:Label id="LabelReply" runat="server"></asp:Label></TD>
															</TR>
														</TABLE>
														</FONT></FONT>
														<P></P>
													</td>
												</tr>
												<tr>
													<td align="center">
														<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
												</tr>
											</table>
											<!---------------------------------------------------------------------------------------------------------------------->
										</TD>
									</TR>
								</TBODY></TABLE>
						</td>
						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
					</tr>
					<tr>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    width="100%"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</TBODY></table>
		</form>
	</body>
</HTML>

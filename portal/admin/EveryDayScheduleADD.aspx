<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EveryDayScheduleADD.aspx.vb" Inherits="EveryDayScheduleADD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>長官批示提醒</title>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<BR>
			</FONT>
			<table cellSpacing="0" cellPadding="0" width="570" align="center" border="0" height="258">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=143 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">長官批示提醒新增</asp:label></td>
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
						<td vAlign="top" bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<!---------------------------------------------------------------------------------------------------------------------->
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體">
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="134">
																<asp:Label id="Label3" runat="server" CssClass="normal">決議編號：</asp:Label></TD>
															<TD width="23">
																<asp:Label id="txtReentityID" runat="server">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD width="134">
																<asp:Label id="Label4" runat="server" CssClass="normal">內容：</asp:Label></TD>
															<TD width="23">
																<asp:TextBox id="txtTitle" runat="server" Width="306px" TextMode="MultiLine" Columns="40" Rows="4"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label1" runat="server" CssClass="normal">截止日期：</asp:label></TD>
															<TD width="23"><asp:textbox id="txtDeadline" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134">
																<asp:Label id="Label2" runat="server" CssClass="normal">到期幾天前通知：</asp:Label></TD>
															<TD width="23">
																<asp:TextBox id="txtNotify" runat="server" Width="72px">0</asp:TextBox></TD>
														</TR>
														<TR>
															<TD width="134"></TD>
															<TD width="23">
																<asp:Button id="btnOK" runat="server" Text="確定"></asp:Button></TD>
														</TR>
													</TABLE>
												</FONT>
											</DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
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
				</TBODY></table>
		</form>
	</body>
</HTML>

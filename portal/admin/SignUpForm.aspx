<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SignUpForm.aspx.vb" Inherits="SignUpForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>長官批示提醒</title>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<BR>
			</FONT>
			<table height="258" cellSpacing="0" cellPadding="0" width="570" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=66 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">報名表</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' >
										<asp:label id="lblresult" runat="server" ForeColor="Red"></asp:label></td>
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
											<!----------------------------------------------------------------------------------------------------------------------><FONT face="新細明體">
												<DIV>
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="134"><asp:label id="Label9" runat="server" CssClass="normal">課程名稱：</asp:label></TD>
															<TD width="23">
																<asp:Label id="ClassTitle" runat="server" Width="356px"></asp:Label></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label3" runat="server" CssClass="normal">姓名：</asp:label></TD>
															<TD width="23"><asp:textbox id="StudentName" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label4" runat="server" CssClass="normal">身分證字號：</asp:label></TD>
															<TD width="23"><asp:textbox id="StudentID" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label1" runat="server" CssClass="normal">出生日期：</asp:label></TD>
															<TD width="23"><asp:textbox id="StudentBirth" runat="server" Width="152px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label2" runat="server" CssClass="normal">上課假別：</asp:label></TD>
															<TD width="23"><asp:textbox id="ClassType" runat="server" Width="152px">0</asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134" height="16"><asp:label id="Label5" runat="server" CssClass="normal">期別：</asp:label></TD>
															<TD width="23" height="16"><asp:textbox id="ClassNumber" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="134"><asp:label id="Label6" runat="server" CssClass="normal">電子郵件網址：</asp:label></TD>
															<TD width="23">
																<asp:TextBox id="ClassEmail" runat="server" Width="336px"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD width="134" height="15">
																<asp:Label id="Label8" runat="server" CssClass="normal">備註：</asp:Label></TD>
															<TD width="23" height="15">
																<asp:TextBox id="Remark" runat="server" TextMode="MultiLine" Columns="40" Rows="4"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD width="134"></TD>
															<TD width="23">
																<P align="center">
																	<asp:Button id="btnOK" runat="server" Text="確定"></asp:Button></P>
															</TD>
														</TR>
													</TABLE>
												</DIV>
											</FONT>
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

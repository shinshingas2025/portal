<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VotesEdit.aspx.vb" Inherits="ASPNET.StarterKit.Portal.VotesEdit" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
					<TBODY>
						<tr>
							<td colSpan="3">
								<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
									<tr>
										<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
										<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">連結詳細資料</asp:label></td>
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
												<TABLE id="Table1" height="281" cellSpacing="0" cellPadding="0" width="100%" align="center"
													border="0">
													<TR>
														<TD align="center" colSpan="3"><asp:label id="Label1" runat="server" CssClass="Head">線上投票編輯</asp:label></TD>
													</TR>
													<TR>
														<TD class="SubHead" width="35" height="20"><FONT face="新細明體">題目縮寫</FONT></TD>
														<TD width="497" height="20"><asp:textbox id="TextBoxQuestionAlias" runat="server" Width="328px"></asp:textbox></TD>
														<TD width="214" height="20"><FONT face="新細明體"></FONT></TD>
													</TR>
													<TR>
														<TD class="SubHead" width="35" height="101"><FONT face="新細明體">題目描述</FONT></TD>
														<TD width="497" height="101"><FONT face="新細明體"><asp:textbox id="txtQuestion" runat="server" TextMode="MultiLine" Height="87px" Width="330px"></asp:textbox></FONT></TD>
														<TD width="214" height="101">
															<P><asp:radiobutton id="RadioButtonSingle" runat="server" Checked="True" GroupName="SelectMode" Text="單選"></asp:radiobutton></P>
															<P><asp:radiobutton id="RadioButtonMultiple" runat="server" GroupName="SelectMode" Text="複選"></asp:radiobutton></P>
														</TD>
													</TR>
													<TR>
														<TD class="SubHead" vAlign="top" width="35" height="157"><FONT face="新細明體">答案</FONT></TD>
														<TD width="497" height="157"><FONT face="新細明體">
																<TABLE id="Table2" height="117" cellSpacing="0" cellPadding="0" width="332" border="0">
																	<TR>
																		<TD vAlign="top" width="145"><asp:textbox id="txtAnswer" runat="server" TextMode="MultiLine" Height="32px" Width="168px"></asp:textbox></TD>
																		<TD width="14"><asp:imagebutton id="imageRight" runat="server" ImageUrl="../../images/rt.gif"></asp:imagebutton><asp:imagebutton id="ImageLeft" runat="server" ImageUrl="../../images/delete.gif"></asp:imagebutton></TD>
																		<TD vAlign="top"><asp:listbox id="listAnswers" runat="server" Height="141px" Width="127px"></asp:listbox></TD>
																	</TR>
																</TABLE>
															</FONT>
														</TD>
														<TD width="214" height="157">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="0">
																<TR>
																	<TD><FONT face="新細明體">
																			<asp:Label id="Label2" runat="server" CssClass="subhead">起始日期</asp:Label></FONT></TD>
																	<TD><asp:textbox id="TextBox1" runat="server" Width="96px"></asp:textbox>
																		<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="日期格式不符!" ValidationExpression="\d{4}/\d{2}/\d{2}"
																			ControlToValidate="TextBox1" CssClass="normalred"></asp:RegularExpressionValidator></TD>
																	<TD><FONT face="新細明體">
																			<asp:LinkButton id="LinkButton1" runat="server">月曆</asp:LinkButton>
																			<asp:Calendar id="Calendar1" runat="server" Visible="False"></asp:Calendar></FONT></TD>
																</TR>
																<TR>
																	<TD><FONT face="新細明體">
																			<asp:Label id="Label3" runat="server" CssClass="subhead">終止日期</asp:Label></FONT></TD>
																	<TD>
																		<asp:TextBox id="TextBox2" runat="server" Width="94px"></asp:TextBox>
																		<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="日期格式不符!" ValidationExpression="\d{4}/\d{2}/\d{2}"
																			ControlToValidate="TextBox2" CssClass="normalred"></asp:RegularExpressionValidator>
																		<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="終止日期大於起始日期!" ControlToValidate="TextBox2"
																			ControlToCompare="TextBox1" Operator="GreaterThanEqual" Type="Date" CssClass="normalred"></asp:CompareValidator></TD>
																	<TD><FONT face="新細明體">
																			<asp:LinkButton id="LinkButton2" runat="server">月曆</asp:LinkButton>
																			<asp:Calendar id="Calendar2" runat="server" Visible="False"></asp:Calendar></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center"></TD>
														<td width="116">
															<table border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																	<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																		<asp:linkbutton id="OKLinkbutton" runat="server" CssClass="CommandButton">確定</asp:linkbutton></td>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																</tr>
															</table>
														</td>
														<td>
															<table border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
																	<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																		<asp:linkbutton id="ReturnLinkButton" runat="server" CssClass="CommandButton">返回</asp:linkbutton></td>
																	<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
																</tr>
															</table>
														</td>
													</TR>
												</TABLE>
												<!---------------------------------------------------------------------------------------------------------------------->
												<DIV><FONT face="新細明體"></FONT></DIV>
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
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
							<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
						</tr>
					</TBODY></table>
		</form>
		</P>
	</body>
</HTML>

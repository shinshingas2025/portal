<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContactList.aspx.vb" Inherits="ASPNET.StarterKit.Portal.ContactList" %>
<%@ Register TagPrefix="uc1" TagName="DesktopNormalTitle" Src="../../DesktopNormalTitle.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
	</HEAD>
	<BODY bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
			<form id="Form1" method="post" runat="server">
				<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
				<P>
					<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
						<tr>
							<td colSpan="3"><uc1:desktopnormaltitle id="DesktopNormalTitle1" runat="server" titletext="網站意見反映表"></uc1:desktopnormaltitle></td>
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
							<td width="100%" bgColor="#ffffff">
								<TABLE width="100%" border="0">
									<TR>
										<TD vAlign="top" align="center">
											<!---------------------------------------------------------------------------------------------------------------------->
											<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
												border="0">
												<tr>
													<td align="center" colSpan="3">
														<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
															<tr>
																<td width="323"><FONT face="新細明體">&nbsp;
																		<asp:label id="Label1" runat="server" CssClass="subhead">起始日期：</asp:label><asp:textbox id="TextBoxStartDate" runat="server" Width="112px"></asp:textbox><FONT size="2">(Ex:2005/05/05)</FONT>
																		<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="normalred" ErrorMessage="請輸入起始日期!"
																			Display="Dynamic" ControlToValidate="TextBoxStartDate"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="normalred" ErrorMessage="日期格式(西元年/月/日)"
																			Display="Dynamic" ControlToValidate="TextBoxStartDate" ValidationExpression="\d{1,4}/\d{1,2}/\d{1,2}"></asp:regularexpressionvalidator></FONT></td>
																<td><FONT face="新細明體"><asp:label id="Label2" runat="server" CssClass="subhead">終止日期：</asp:label><asp:textbox id="TextBoxEndDate" runat="server" Width="103px"></asp:textbox><FONT size="2">(Ex:2005/05/05)</FONT>
																		<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="normalred" ErrorMessage="請輸入終止日期!"
																			Display="Dynamic" ControlToValidate="TextBoxEndDate"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" CssClass="normalred" ErrorMessage="日期格式(西元年/月/日)"
																			Display="Dynamic" ControlToValidate="TextBoxEndDate" ValidationExpression="\d{1,4}/\d{1,2}/\d{1,2}"></asp:regularexpressionvalidator><asp:comparevalidator id="CompareValidator1" runat="server" CssClass="normalred" ErrorMessage="起始日期需小於或等於終止日期!"
																			Display="Dynamic" ControlToValidate="TextBoxEndDate" ControlToCompare="TextBoxStartDate" Operator="GreaterThanEqual"></asp:comparevalidator></FONT></td>
															</tr>
														</table>
													</td>
												</tr>
												<tr>
													<td align="center" colSpan="3"><asp:button id="ButtonOK" runat="server" Text="查詢"></asp:button></td>
												</tr>
												<tr>
													<td align="center" colSpan="3"><iframe id="Iframe1" frameBorder="0" width="100%" height="400" runat="server"></iframe></td>
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
	</BODY>
</HTML>


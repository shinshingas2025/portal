<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="JobWantedListGroupBySchool.aspx.vb" Inherits="ASPNET.StarterKit.Portal.JobWantedListGroupBySchool" %>
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
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=200 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">各校求職登記數據統計表</asp:label></td>
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
						<td bgColor="#ffffff" width="100%">
							<TABLE width="100%" border="0">
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
											border="0">
											<tr>
												<td align="left" colSpan="3">
													<table width="100%" border="0" cellSpacing="0" cellPadding="0" align="center">
														<tr>
															<td><FONT face="新細明體">&nbsp;
																	<asp:Label id="Label1" runat="server" CssClass="subhead">查詢起始日期：</asp:Label>
																	<asp:TextBox id="TextBoxStartDate" runat="server"></asp:TextBox>
																	<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入起始日期!" Display="Dynamic"
																		ControlToValidate="TextBoxStartDate" CssClass="normalred"></asp:RequiredFieldValidator>
																	<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="日期格式(西元年/月/日)" Display="Dynamic"
																		ControlToValidate="TextBoxStartDate" ValidationExpression="\d{1,4}/\d{1,2}/\d{1,2}" CssClass="normalred"></asp:RegularExpressionValidator></FONT></td>
															<td><FONT face="新細明體">
																	<asp:Label id="Label2" runat="server" CssClass="subhead">查詢終止日期：</asp:Label><asp:TextBox id="TextBoxEndDate" runat="server"></asp:TextBox>
																	<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入終止日期!" Display="Dynamic"
																		ControlToValidate="TextBoxEndDate" CssClass="normalred"></asp:RequiredFieldValidator>
																	<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="日期格式(西元年/月/日)" Display="Dynamic"
																		ControlToValidate="TextBoxEndDate" ValidationExpression="\d{1,4}/\d{1,2}/\d{1,2}" CssClass="normalred"></asp:RegularExpressionValidator>
																	<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="起始日期需小於或等於終止日期!" Display="Dynamic"
																		ControlToValidate="TextBoxEndDate" ControlToCompare="TextBoxStartDate" Operator="GreaterThanEqual"
																		CssClass="normalred"></asp:CompareValidator></FONT></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="left" colSpan="3"><FONT face="新細明體">
														<asp:Label id="Label3" runat="server" CssClass="subhead">畢業年度：</asp:Label>
														<asp:TextBox id="TextBoxGradYear" runat="server"></asp:TextBox>
														<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="請輸入畢業年度!" Display="Dynamic"
															ControlToValidate="TextBoxGradYear" CssClass="normalred"></asp:RequiredFieldValidator>
														<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="畢業年度格式(西元年)" ControlToValidate="TextBoxGradYear"
															ValidationExpression="\d{1,4}" CssClass="normalred"></asp:RegularExpressionValidator></FONT>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<asp:Button id="ButtonOK" runat="server" Text="查詢"></asp:Button></td>
											</tr>
											<tr>
												<td align="center" colSpan="3"><iframe id="Iframe1" frameBorder="0" width="100%" height="400" runat="server"></iframe></td>
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

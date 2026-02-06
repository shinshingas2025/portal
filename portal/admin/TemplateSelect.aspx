<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TemplateSelect.aspx.vb" Inherits="ASPNET.StarterKit.Portal.TemplateSelect" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body  leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:DesktopPortalBanner id="DesktopPortalBanner1" runat="server"></uc1:DesktopPortalBanner><FONT face="新細明體"><BR>
					<table cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
						<TBODY>
							<tr>
								<td colSpan="3">
									<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
										<tr>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
											<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">選擇網站版型</asp:label></td>
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
													<TABLE id="Table2" height="16" cellSpacing="0" cellPadding="0" width="646" align="center"
														border="0">
														<TR>
															<TD>
																<asp:Label id="lblmsg" runat="server" CssClass="normalred"></asp:Label>
															</TD>
															<TD align="right">
																										<table border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif'></td>
															<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif'  >
																<asp:LinkButton id="linkOK" runat="server" CssClass="CommandButton">確定</asp:LinkButton></td>
															<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif'></td>
														</tr>
													</table>
															
																</TD>
														</TR>
													</TABLE>
				</FONT>
			<P></P>
			<asp:DataList id="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" DataKeyField="itemid">
				<SelectedItemTemplate>
					<TABLE class="TTable" cellSpacing="0" cellPadding="0">
						<TR>
							<TD>
								<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD><font color="red" size="2">已選擇</font><br>
											<font size="2" color="blue">
												<%# Container.DataItem("Name") %>
											</font>
										</TD>
									</TR>
									<TR>
										<TD><IMG height=10 src='<%# Container.DataItem("TitlePic") %>' width=120>
										</TD>
									</TR>
									<TR>
										<TD><IMG height=100 src='<%# Container.DataItem("BGPic") %>' width=120>
										</TD>
							</TD>
						</TR>
					</TABLE>
					</TD></TR></TBODY></TABLE>
				</SelectedItemTemplate>
				<ItemTemplate>
					<TABLE class="TTable" cellSpacing="0" cellPadding="0">
						<TR>
							<TD>
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TBODY>
										<TR>
											<TD><FONT size="2">
													<asp:LinkButton id="LinkButton1" runat="server">選擇</asp:LinkButton><br>
													<%# Container.DataItem("Name") %>
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD><IMG height=10 src='<%# Container.DataItem("TitlePic") %>' width=120>
											</TD>
										</TR>
										<TR>
											<TD><IMG height=100 src='<%# Container.DataItem("BGPic") %>' width=120>
											</TD>
							</TD>
						</TR>
					</TABLE>
					</TD></TR></TBODY></TABLE>
				</ItemTemplate>
			</asp:DataList>
			<!---------------------------------------------------------------------------------------------------------------------->
			<DIV></DIV>
			</TD></TR></TBODY></TABLE></TD>
			<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
			</TR>
			<tr>
				<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
				<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
				<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
			</tr>
			</TBODY></TABLE>
		</form>
		</FONT></P>
	</body>
</HTML>

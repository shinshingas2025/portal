<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CouncilmanInstructionAdmin.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.CouncilmanInstructionAdmin" %>
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
			<LINK href="../../css/AuditSystem1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=240 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">委員交辦管理</asp:label></td>
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
						<td width="100%" bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
											border="0">
											<tr>
												<td class="dingbat" align="center" width="100%" colSpan="2">委員交辦</td>
											</tr>
											<tr>
												<td align="center">
													<table width="100%">
														<tr>
															<td class="legal">主題</td>
															<td><asp:textbox id="TextBoxTitle" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td class="legal">描述</td>
															<td><asp:textbox id="TextBoxDescription" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td class="legal">交辦內容</td>
															<td><asp:textbox id="TextBoxInstruction" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td class="legal">備註</td>
															<td><asp:textbox id="TextBoxNote" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td class="legal">交辦時間</td>
															<td><asp:textbox id="TextboxInstructionDate" runat="server"></asp:textbox></td>
														</tr>
													</table>
												</td>
												<td align="left" width="20%">
													<table width="100%">
														<tr>
															<td align="center" colSpan="2"><asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button><asp:button id="ButtonInstructionInsert" runat="server" CssClass="nav" Text="新增"></asp:button><asp:button id="ButtonInstructionUpdate" runat="server" CssClass="nav" Text="修改"></asp:button><asp:button id="ButtonInstructionDelete" runat="server" CssClass="nav" Text="刪除"></asp:button><asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td class="dingbat" align="center" width="100%" colSpan="2">相關委員</td>
											</tr>
											<tr>
												<td align="center" width="100%" colSpan="2"><asp:placeholder id="PlaceHolderCouncilman" runat="server"></asp:placeholder></td>
											</tr>
											<tr>
												<td align="center" width="100%" colSpan="2">
													<TABLE cellSpacing="0" cellPadding="1" align="center" border="0">
														<TR>
															<TD width="40"><asp:button id="ButtonCouncilmanAction" runat="server" CssClass="nav" Width="40"></asp:button></TD>
															<TD width="240"><asp:dropdownlist id="DropDownListCouncilman" runat="server" CssClass="footer" width="240"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</td>
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

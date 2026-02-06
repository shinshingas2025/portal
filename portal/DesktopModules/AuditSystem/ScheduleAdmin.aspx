<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ScheduleAdmin.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ScheduleAdmin" %>
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
			<LINK href="../../css/AuditSystem1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
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
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">行事曆</asp:label></td>
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
											<TR valign="top">
												<td width="30%"><asp:calendar id="Calendar1" NextPrevFormat="ShortMonth" TitleFormat="Month" SelectionMode="DayWeekMonth"
														Runat="server"></asp:calendar></td>
												<td>
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="100%">
																<fieldset>
																	<table cellSpacing="0" cellPadding="0" align="left" border="0">
																		<tr>
																			<td width="48">開始時間</td>
																			<td><asp:textbox id="TextBoxStartTime" runat="server"></asp:textbox></td>
																			<td width="48">結束時間</td>
																			<td><asp:textbox id="TextBoxEndTime" runat="server"></asp:textbox></td>
																			<td rowSpan="4"><asp:button id="ButtonInsert" runat="server" CssClass="nav" Text="新增"></asp:button>
																		  <asp:button id="ButtonUpdate" runat="server" CssClass="nav" Text="修改"></asp:button></td>
																		</tr>
																		<tr>
																			<td width="48">主旨</td>
																			<td colSpan="3"><asp:textbox id="TextBoxTitle" runat="server" TextMode="SingleLine" Columns="60"></asp:textbox></td>
																		</tr>
																		<tr>
																			<td width="48">內容</td>
																			<td colSpan="3"><asp:textbox id="TextBoxDescription" runat="server" TextMode="MultiLine" Columns="48"></asp:textbox></td>
																		</tr>
																		<tr>
																			<td width="48">備註</td>
																			<td colSpan="3"><asp:textbox id="TextBoxNote" runat="server" Columns="60"></asp:textbox></td>
																		</tr>
																	</table>
																</fieldset>
															</td>
														</tr>
														<tr>
															<td width="100%">
																<fieldset>
																	<table cellSpacing="0" cellPadding="0" align="left" border="0">
																		<tr>
																			<td width="48">搜尋文字</td>
																			<td colSpan="3"><asp:textbox id="TextBoxQuery" runat="server" Columns="60"></asp:textbox></td>
																			<td><asp:button id="ButtonQuery" runat="server" CssClass="nav" Text="搜尋"></asp:button><asp:button id="ButtonDelete" runat="server" CssClass="nav" Text="刪除選取項目"></asp:button></td>
																		</tr>
																		<tr>
																			<td colSpan="5" width="100%">
																				<table cellSpacing="0" cellPadding="0" border="0" width="100%">
																					<tr>
																						<th width="5%">
																							選擇</th>
																						<th width="20%">
																							開始時間</th>
																						<th width="20%">
																							結束時間</th>
																						<th width="55%">
																							主題</th></tr>
																				</table>
																			</td>
																		</tr>
																		<tr>
																			<td colSpan="5" width="100%"><asp:datalist id="DataListResult" runat="server" DataKeyField="EntityID" Width="100%">
																					<ItemTemplate>
																						<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																							<TR>
																								<td width="5%">
																									<asp:RadioButton ID="RadioButton1" Runat="server" AutoPostBack="true" OnCheckedChanged="DataListResult_SelectedIndexChanged"></asp:RadioButton>
																								</td>
																								<TD width="20%">
																									<ASP:LABEL id="Label3" runat="server">
																										<%# DataBinder.Eval(Container.DataItem, "StartDateString") %>
																									</ASP:LABEL></TD>
																								<TD width="20%">
																									<ASP:LABEL id="Label1" runat="server">
																										<%# DataBinder.Eval(Container.DataItem, "EndDateString") %>
																									</ASP:LABEL></TD>
																								<TD width="55%">
																									<ASP:LABEL id="Label2" runat="server">
																										<%# DataBinder.Eval(Container.DataItem, "Title") %>
																									</ASP:LABEL>
																								</TD>
																							</TR>
																						</TABLE>
																					</ItemTemplate>
																				</asp:datalist></td>
																		</tr>
																	</table>
																</fieldset>
															</td>
														</tr>
													</table>
												</td>
											</TR>
											<tr>
												<td width="100%" colSpan="2"><asp:calendar id="Calendar2" runat="server" NextPrevFormat="ShortMonth" SelectionMode="None" Width="100%"></asp:calendar></td>
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

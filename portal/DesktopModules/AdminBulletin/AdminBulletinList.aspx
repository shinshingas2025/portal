<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminBulletinList.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AdminBulletinList" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>校園聯名網</title>
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
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><FONT face="新細明體"><BR>
					<BR>
				</FONT>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=160 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">聯名e網訊息清單</asp:label></td>
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
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR>
												<th width="4%">
												</th>
												<th width="76%">
													主題</th>
												<th width="20%">
													發佈單位/發佈日期</th>
											</TR>
											<tr>
												<td align="center" colSpan="3">
													<asp:datalist id="DataList1" runat="server" DataKeyField="EntityID" Width="100%" OnItemCommand="ShowBulletin">
														<ItemTemplate>
															<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																<TR>
																	<td width="10" valign="top"><Img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0007.gif' alt='項目'></td>
																	<TD valign="top">
																		<ASP:LABEL id="Label1" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "Title") %>
																		</ASP:LABEL></TD>
																	<TD width="150">
																		<ASP:LABEL id="Label2" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "AnnounceUnit") %>
																		</ASP:LABEL><br>
																		<ASP:LABEL id="Label3" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>
																		</ASP:LABEL>
																	</TD>
																	<TD width="10%">
																		<asp:Button id="ButtonView" runat="server" Text="詳細"></asp:Button></TD>
																</TR>
															</TABLE>
														</ItemTemplate>
													</asp:datalist>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="5%"><asp:linkbutton id="LinkButtonBulletinListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonBulletinListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
															<td align="center" width="80%"><asp:placeholder id="PlaceHolderBulletinListPageIndex" runat="server"></asp:placeholder></td>
															<td width="5%"><asp:linkbutton id="LinkButtonBulletinListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonBulletinListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button>
												</td>
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

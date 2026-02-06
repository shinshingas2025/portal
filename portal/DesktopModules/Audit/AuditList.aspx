<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AuditList.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditList" %>
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
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table cellSpacing="0" cellPadding="0" width="800" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">稽核清單</asp:label></td>
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
									<TD vAlign="top" align="center" width="100%">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE id="Table0" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<tr>
												<td>使用者名稱</td>
												<td><asp:textbox id="TextBoxUserName" runat="server"></asp:textbox></td>
												<td colspan="2">操作型態<asp:radiobutton id="RadioButtonInsert" runat="server" Text="新增" GroupName="RadioButtonActionType"></asp:radiobutton><asp:radiobutton id="RadioButtonUpdate" runat="server" Text="修改" GroupName="RadioButtonActionType"></asp:radiobutton><asp:radiobutton id="RadioButtonDelete" runat="server" Text="刪除" GroupName="RadioButtonActionType"></asp:radiobutton>
													<asp:RadioButton id="RadioButtonAll" runat="server" Text="全部" GroupName="RadioButtonActionType"></asp:RadioButton></td>
											</tr>
											<tr>
												<td>使用模組</td>
												<td><asp:dropdownlist id="DropDownListModule" runat="server"></asp:dropdownlist></td>
												<td>起始時間
													<asp:textbox id="TextBoxStartTime" runat="server"></asp:textbox></td>
												<td>終止時間
													<asp:textbox id="TextBoxEndTime" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td align="center" colSpan="4"><asp:button id="ButtonQuery" runat="server" Text="查詢"></asp:button><asp:button id="ButtonCancel" runat="server" Text="取消"></asp:button><asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
											</tr>
										</TABLE>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TR>
												<th width="10%">
												</th>
												<th width="20%">
													使用者</th>
												<th width="30%">
													模組</th>
												<th width="10%">
													操作型態</th>
												<th width="30%">
													時間</th></TR>
											<tr>
												<td align="center" colSpan="5"><asp:datalist id="DataList1" runat="server" BorderWidth="1px" GridLines="Both" CellPadding="4"
														BackColor="White" BorderStyle="None" BorderColor="#CC9966" OnItemCommand="ShowAudit" Width="100%" DataKeyField="EntityID">
														<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
														<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
														<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
														<ItemTemplate>
															<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																<TR>
																	<TD width="10%">
																		<asp:Button id="ButtonView" runat="server" Text="詳細"></asp:Button></TD>
																	<TD width="20%">
																		<ASP:LABEL id="Label1" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "CreatedByUser") %>
																		</ASP:LABEL></TD>
																	<TD width="30%">
																		<ASP:LABEL id="Label2" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "ModuleName") %>
																		</ASP:LABEL></TD>
																	<TD width="10%">
																		<ASP:LABEL id="Label3" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "ActionName") %>
																		</ASP:LABEL></TD>
																	<TD width="30%">
																		<ASP:LABEL id="Label4" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>
																		</ASP:LABEL></TD>
																</TR>
															</TABLE>
														</ItemTemplate>
														<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
													</asp:datalist></td>
											</tr>
											<tr>
												<td align="center" colSpan="5">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="5%"><asp:linkbutton id="LinkButtonAuditListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonAuditListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
															<td align="center" width="80%"><asp:placeholder id="PlaceHolderAuditListPageIndex" runat="server"></asp:placeholder></td>
															<td width="5%"><asp:linkbutton id="LinkButtonAuditListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonAuditListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="5">
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
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>

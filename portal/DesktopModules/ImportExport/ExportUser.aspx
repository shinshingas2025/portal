<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExportUser.aspx.vb" Inherits="ASPNET.StarterKit.Portal.ExportUser" %>
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
				<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=100 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">訊息清單</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></td>
						<td width="100%" 
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
								<TR>
									<TD vAlign="top" align="center" width="100%">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<tr>
												<td align="center" colSpan="4">
													<table cellSpacing="0" cellPadding="0" align="left" border="0">
														<tr>
															<th>
																標題：</th>
															<td><asp:label id="LabelTitle" runat="server"></asp:label></td>
														</tr>
														<tr>
															<th>
																說明：</th>
															<td><asp:label id="LabelDescription" runat="server"></asp:label></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="4">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
														<tr>
															<td>教育程度</td>
															<td><asp:dropdownlist id="DropDownList1" runat="server">
																	<asp:ListItem Value="1">博士</asp:ListItem>
																	<asp:ListItem Value="2">碩士</asp:ListItem>
																	<asp:ListItem Value="3">大學</asp:ListItem>
																	<asp:ListItem Value="4">專科</asp:ListItem>
																	<asp:ListItem Value="5">高職</asp:ListItem>
																	<asp:ListItem Value="6">高中</asp:ListItem>
																	<asp:ListItem Value="7">國中</asp:ListItem>
																	<asp:ListItem Value="8">國小</asp:ListItem>
																	<asp:ListItem Value="9" Selected="True">不限</asp:ListItem>
																</asp:dropdownlist></td>
															<td>畢肆業</td>
															<td><asp:radiobutton id="RadioButton1" runat="server" Text="畢業" GroupName="RadioButtonGRADU"></asp:radiobutton><asp:radiobutton id="RadioButton2" runat="server" Text="肆業" GroupName="RadioButtonGRADU"></asp:radiobutton><asp:radiobutton id="RadioButton3" runat="server" Text="在學" GroupName="RadioButtonGRADU"></asp:radiobutton><asp:radiobutton id="Radiobutton4" runat="server" Text="不限" GroupName="RadioButtonGRADU" Checked="True"></asp:radiobutton></td>
														</tr>
													</table>
												</td>
											</tr>
											<TR>
												<th width="10%">
													選擇</th>
												<th width="20%">
													姓名</th>
												<th width="30%">
													身分證字號</th>
												<th width="40%">
													出生日期</th></TR>
											<tr>
												<td align="center" colSpan="4"><asp:datalist id="DataList1" runat="server" BorderWidth="1px" GridLines="Both" CellPadding="4"
														BackColor="White" BorderStyle="None" BorderColor="#CC9966" Width="100%" DataKeyField="LABOR_ID">
														<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
														<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
														<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
														<ItemTemplate>
															<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																<TR>
																	<TD width="10%">
																		<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox></TD>
																	<TD width="20%">
																		<ASP:LABEL id="Label1" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "Name") %>
																		</ASP:LABEL></TD>
																	<TD width="30%">
																		<ASP:LABEL id="Label2" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "IDNO") %>
																		</ASP:LABEL></TD>
																	<TD width="40%">
																		<ASP:LABEL id="Label3" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "BIRTH") %>
																		</ASP:LABEL></TD>
																</TR>
															</TABLE>
														</ItemTemplate>
														<SeparatorTemplate>
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD background='images/dot.gif' width="100%">
																	</TD>
																</TR>
															</TABLE>
														</SeparatorTemplate>
														<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
													</asp:datalist></td>
											</tr>
											<tr>
												<td align="center" colSpan="4">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="5%"><asp:linkbutton id="LinkButtonExportUserTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonExportUserPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
															<td align="center" width="80%"><asp:placeholder id="PlaceHolderExportUserPageIndex" runat="server"></asp:placeholder></td>
															<td width="5%"><asp:linkbutton id="LinkButtonExportUserPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
															<td width="5%"><asp:linkbutton id="LinkButtonExportUserTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="4"><asp:button id="ButtonQuery" runat="server" Text="搜尋"></asp:button><asp:button id="ButtonExportUser" runat="server" Text="匯出"></asp:button><asp:button id="ButtonCancel" runat="server" Text="取消"></asp:button>
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
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

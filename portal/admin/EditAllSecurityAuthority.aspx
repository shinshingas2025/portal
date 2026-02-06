<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditAllSecurityAuthority.aspx.vb" Inherits="EIIS.EditAllSecurityAuthority" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Community</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles//WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">權限管理</asp:label></td>
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
											<!----------------------------------------------------------------------------------------------------------------------><FONT face="新細明體">
												<TABLE class="ttable" id="Table4" borderColor="#000000" cellSpacing="0" borderColorDark="#ffffff"
													cellPadding="0" width="100%" border="1">
													<TR>
														<TD colSpan="2">
															<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 68px"><FONT color="#ff0000" size="2">項目狀態</FONT></TD>
																	<TD style="WIDTH: 280px"><asp:button id="btnUpdate" runat="server" BorderStyle="Ridge" Text="修改本項目" Font-Size="X-Small"></asp:button><asp:button id="btnDelete" runat="server" BorderStyle="Ridge" Text="刪除本項目" Font-Size="X-Small"></asp:button></TD>
																	<TD style="WIDTH: 130px"><asp:label id="errmsg" runat="server" CssClass="normalred"></asp:label></TD>
																	<TD style="WIDTH: 103px">
																		<P align="right"><FONT size="2">類別：</FONT></P>
																	</TD>
																	<TD align="right" width="50"><FONT size="2"><asp:dropdownlist id="newType" runat="server">
																				<asp:ListItem Value="Groups" Selected="True">群組</asp:ListItem>
																				<asp:ListItem Value="UserInfo">使用者</asp:ListItem>
																			</asp:dropdownlist></FONT></TD>
																	<TD width="50"><asp:button id="btnAdd" runat="server" BorderStyle="Ridge" Text="新增子項目" Font-Size="X-Small"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD colSpan="2">
															<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 82px"><FONT size="2">項目編號：</FONT></TD>
																	<TD><asp:label id="txtobjID" runat="server" Font-Size="X-Small"></asp:label></TD>
																	<TD><FONT size="2">類別：</FONT></TD>
																	<TD><asp:dropdownlist id="txtsrcName" runat="server">
																			<asp:ListItem Value="Groups" Selected="True">群組</asp:ListItem>
																			<asp:ListItem Value="UserInfo">使用者</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD><FONT size="2">上層項目：</FONT></TD>
																	<TD><asp:textbox id="txtPID" runat="server" Font-Size="X-Small" Width="40px" ReadOnly="True"></asp:textbox></TD>
																	<TD><FONT color="#ff0000" size="2">名稱：</FONT></TD>
																	<TD><asp:textbox id="txtObjName" runat="server" Font-Size="X-Small" Width="64px"></asp:textbox></TD>
																	<TD><FONT size="2">數值：</FONT></TD>
																	<TD><asp:textbox id="txtObjValue" runat="server" Font-Size="X-Small" Width="50px" ReadOnly="True"></asp:textbox></TD>
																	<TD><FONT size="2"><FONT color="#ff0000">序號</FONT>：</FONT></TD>
																	<TD><asp:textbox id="txtSeqno" runat="server" Font-Size="X-Small" Width="26px"></asp:textbox></TD>
																	<TD><FONT size="2">狀態：</FONT></TD>
																	<TD><asp:textbox id="txtState" runat="server" Font-Size="X-Small" Width="42px"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 210px" bgColor="gainsboro"><asp:button id="Button1" runat="server" BorderStyle="Groove" Text="權限狀況" Font-Size="X-Small"
																Enabled="False"></asp:button><asp:button id="btnTreeRefresh" runat="server" BorderStyle="Ridge" Text="重新整理" Font-Size="X-Small"></asp:button></TD>
														<TD bgColor="gainsboro"><asp:button id="Button2" runat="server" BorderStyle="Groove" Text="項目屬性" Font-Size="X-Small"
																Enabled="False"></asp:button><asp:button id="AddLiginID" runat="server" BorderStyle="Ridge" Text="新增帳號" Font-Size="X-Small"
																ToolTip="新增目前選取節點使用者的帳號"></asp:button><asp:button id="LoginRefresh" runat="server" BorderStyle="Ridge" Text="重新整理" Font-Size="X-Small"></asp:button></TD>
													</TR>
													<TR>
														<TD vAlign="top"><asp:panel id="Panel1" runat="server" Width="100%">
																<iewc:treeview id="TreeView1" runat="server" Width="100%" ExpandLevel="1" AutoPostBack="True"></iewc:treeview>
															</asp:panel></TD>
														<TD vAlign="top">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD><asp:datagrid id="DataGrid2" runat="server" CssClass="TTable" BorderStyle="None" Font-Size="X-Small"
																			Width="100%" AllowPaging="True" PageSize="2" ForeColor="Black" AutoGenerateColumns="False"
																			BorderColor="#DEDFDE" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical">
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																			<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																			<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																			<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																			<Columns>
																				<asp:BoundColumn DataField="GroupID" HeaderText="群組ID"></asp:BoundColumn>
																				<asp:BoundColumn DataField="GroupName" HeaderText="名稱"></asp:BoundColumn>
																				<asp:BoundColumn DataField="Description" HeaderText="描述"></asp:BoundColumn>
																				<asp:BoundColumn DataField="state" HeaderText="狀態"></asp:BoundColumn>
																			</Columns>
																			<PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid><asp:datagrid id="DataGrid3" runat="server" CssClass="TTable" BorderStyle="None" Font-Size="X-Small"
																			Width="100%" AllowPaging="True" PageSize="2" ForeColor="Black" AutoGenerateColumns="False" BorderColor="#DEDFDE"
																			BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical">
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																			<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																			<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																			<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																			<Columns>
																				<asp:BoundColumn DataField="UID" HeaderText="使用者ID"></asp:BoundColumn>
																				<asp:BoundColumn DataField="Cname" HeaderText="姓名"></asp:BoundColumn>
																				<asp:BoundColumn DataField="IDNum" HeaderText="身份證號"></asp:BoundColumn>
																				<asp:BoundColumn DataField="TelMobile" HeaderText="行動電話"></asp:BoundColumn>
																				<asp:BoundColumn DataField="Email" HeaderText="電子郵件"></asp:BoundColumn>
																				<asp:ButtonColumn Text="編輯" CommandName="Select"></asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid><asp:datagrid id="DataGrid1" runat="server" CssClass="TTable" BorderStyle="None" Font-Size="X-Small"
																			Width="100%" AllowPaging="True" PageSize="2" ForeColor="Black" AutoGenerateColumns="False" BorderColor="#DEDFDE"
																			BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical" DataKeyField="LoginID">
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																			<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																			<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																			<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																			<Columns>
																				<asp:BoundColumn DataField="LoginID" ReadOnly="True" HeaderText="帳號"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="密碼">
																					<ItemTemplate>
																						<asp:Label id=lblPassword runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Password") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id=txtPassword runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Password") %>' Width="80px" TextMode="MultiLine" Rows="3">
																						</asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="有效日期起">
																					<ItemTemplate>
																						<asp:Label id=lblStartDate runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id=txtStartDate runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate") %>' Width="80px">
																						</asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="有效日期迄">
																					<ItemTemplate>
																						<asp:Label id=lblEndDate runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id=txtEndDate runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate") %>' Width="80px">
																						</asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="停用">
																					<ItemTemplate>
																						<asp:Label id=lblstate runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.state") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkstate" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.state") %>'></asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
																				<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD bgColor="buttonface"><asp:button id="Button3" runat="server" BorderStyle="Groove" Text="本項目功能" Font-Size="X-Small"
																			Enabled="False"></asp:button><asp:button id="addfunction" runat="server" BorderStyle="Ridge" Text="匯入功能" Font-Size="X-Small"></asp:button><asp:button id="FunRefresh" runat="server" BorderStyle="Ridge" Text="重新整理" Font-Size="X-Small"></asp:button></TD>
																</TR>
																<TR>
																	<TD vAlign="top"><asp:datagrid id="DataGrid4" runat="server" CssClass="TTable" BorderStyle="None" Font-Size="X-Small"
																			Width="100%" AllowPaging="True" PageSize="5" ForeColor="Black" AutoGenerateColumns="False" BorderColor="#DEDFDE"
																			BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical" DataKeyField="RoleID" OnDeleteCommand="Functoin_Delete">
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																			<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																			<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																			<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																			<Columns>
																				<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
																				<asp:BoundColumn DataField="DomainID" ReadOnly="True" HeaderText="功能編號"></asp:BoundColumn>
																				<asp:BoundColumn DataField="objName" ReadOnly="True" HeaderText="功能名稱"></asp:BoundColumn>
																				<asp:BoundColumn DataField="srcName" ReadOnly="True" HeaderText="類型"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="增">
																					<ItemTemplate>
																						<asp:Label id=lblIlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ilevel") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkIlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Ilevel") %>'>
																						</asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="刪">
																					<ItemTemplate>
																						<asp:Label id=lblDlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Dlevel") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkDlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Dlevel") %>'>
																						</asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="改">
																					<ItemTemplate>
																						<asp:Label id=lblUlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ulevel") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkUlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Ulevel") %>'>
																						</asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="查">
																					<ItemTemplate>
																						<asp:Label id=lblQlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Qlevel") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkQlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Qlevel") %>'>
																						</asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="檢">
																					<ItemTemplate>
																						<asp:Label id=lblClevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Clevel") %>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:CheckBox id="chkClevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Clevel") %>'>
																						</asp:CheckBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
																				<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
																			</Columns>
																			<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</FONT>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV></DIV>
										</TD>
									</TR>
								</TBODY>
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
				</TBODY>
			</table>
		</form>
	</body>
</HTML>

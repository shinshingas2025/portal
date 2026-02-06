<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditAllWebFormSetting.aspx.vb" Inherits="EditAllWebFormSetting" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<%@ Import Namespace="EIIS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DomainsView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
		<LINK href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">網站內容維護</asp:label></td>
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
											<TABLE class="TTable" id="Table5" borderColor="#000000" cellSpacing="0" borderColorDark="#ffffff"
												cellPadding="1" width="100%" align="center" border="1">
												<TR>
													<TD colSpan="2"><FONT face="新細明體">
															<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 164px"><FONT color="#cc0000" size="2">項目狀態</FONT></TD>
																	<TD style="WIDTH: 419px"><asp:button id="btnUpdate" runat="server" Text="修改索引" BorderStyle="Groove"></asp:button><asp:button id="btnDelete" runat="server" Text="刪除項目" BorderStyle="Groove"></asp:button><asp:button id="btnTreeRefresh" runat="server" Text="重新整理" BorderStyle="Groove" ></asp:button></TD>
																	<TD style="WIDTH: 409px" align="right"><FONT size="2">種類</FONT></TD>
																	<TD style="WIDTH: 60px" align="right"><FONT size="2"><asp:dropdownlist id="newType" runat="server">
																				<asp:ListItem Value="Joblist" Selected="True">索引標籤</asp:ListItem>
																				<asp:ListItem Value="Function">模組</asp:ListItem>
																			</asp:dropdownlist></FONT></TD>
																	<TD><asp:button id="btnAdd" runat="server" Text="新增子項目" BorderStyle="Groove"></asp:button></TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD colSpan="2"><FONT face="新細明體">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD><FONT size="2">項目編號</FONT></TD>
																	<TD><asp:label id="txtobjID" runat="server" ></asp:label></TD>
																	<TD><FONT size="2">上層編號</FONT></TD>
																	<TD><asp:textbox id="txtPID" runat="server"  Width="50px"></asp:textbox></TD>
																	<TD><FONT size="2">項目種類</FONT></TD>
																	<TD><asp:dropdownlist id="selsrcName" runat="server">
																			<asp:ListItem Value="Joblist" Selected="True">索引標籤</asp:ListItem>
																			<asp:ListItem Value="Function">模組</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD><FONT size="2">項目名稱</FONT></TD>
																	<TD><asp:textbox id="txtObjName" runat="server"  Width="85px"></asp:textbox></TD>
																	<TD><FONT size="2">數值</FONT></TD>
																	<TD><asp:textbox id="txtObjValue" runat="server"  Width="54px"></asp:textbox></TD>
																	<TD><FONT size="2">序號</FONT></TD>
																	<TD><asp:textbox id="txtSeqno" runat="server"  Width="27px"></asp:textbox></TD>
																	<TD><FONT size="2">狀態</FONT></TD>
																	<TD><asp:textbox id="txtState" runat="server"  Width="34px" AutoPostBack="True"></asp:textbox></TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 263px" bgColor="activeborder"><asp:label id="Label1" runat="server" >網站結構</asp:label></TD>
													<TD bgColor="activeborder"><FONT face="新細明體" size="2">模組</FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 263px" vAlign="top"><asp:panel id="Panel1" runat="server" >
															<!--<iewc:treeview id="TreeView2" runat="server" Width="200px" ExpandLevel="1" AutoPostBack="True"
											Height="100%"></iewc:treeview>-->
                                    <asp:TreeView ID="TreeView1" runat="server" >
                                       
                                    </asp:TreeView>
														</asp:panel></TD>
													<TD vAlign="top" align="left">
														<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD><asp:datagrid id="DataGrid1" runat="server" BorderStyle="None"  Width="100%"
																		CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#DEDFDE" AutoGenerateColumns="False"
																		DataKeyField="funno" GridLines="Vertical" ForeColor="Black">
																		<FooterStyle BackColor="#CCCC99"></FooterStyle>
																		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="funno" ReadOnly="True" HeaderText="編號"></asp:BoundColumn>
																			<asp:TemplateColumn HeaderText="模組名稱">
																				<ItemTemplate>
																					<asp:Label id=lblFunctionID runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FunctionID") %>'>
																					</asp:Label>
																				</ItemTemplate>
																				<EditItemTemplate>
																					<asp:TextBox id=txtFunctionID runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FunctionID") %>' Width="113px">
																					</asp:TextBox>
																				</EditItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="功能描述">
																				<ItemTemplate>
																					<asp:Label id=lblDescription runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																					</asp:Label>
																				</ItemTemplate>
																				<EditItemTemplate>
																					<asp:TextBox id=txtDescription runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' Width="113px">
																					</asp:TextBox>
																				</EditItemTemplate>
																			</asp:TemplateColumn>
																			<asp:BoundColumn DataField="ModuleDefid" ReadOnly="True" HeaderText="模組種類"></asp:BoundColumn>
																			<asp:TemplateColumn HeaderText="位置">
																				<ItemTemplate>
																					<asp:Label id=lblPaneName runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.paneName") %>'>
																					</asp:Label>
																				</ItemTemplate>
																				<EditItemTemplate>
																					<asp:DropDownList id=txtPaneName runat="server" SelectedIndex='<%# mid(DataBinder.Eval(Container, "DataItem.paneName"),1,1) %>'>
																						<asp:ListItem Value="0-leftPane">左</asp:ListItem>
																						<asp:ListItem Value="1-contentPane">中</asp:ListItem>
																						<asp:ListItem Value="2-rightPane">右</asp:ListItem>
																					</asp:DropDownList>
																				</EditItemTemplate>
																			</asp:TemplateColumn>
																			<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
																		</Columns>
																		<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																	</asp:datagrid></TD>
															</TR>
															<TR>
																<TD>
																	<HR width="100%" SIZE="1">
																</TD>
															</TR>
															<TR>
																<TD><FONT face="新細明體"><BR>
																		<BR>
																	</FONT>
																	<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
																		<TR>
																			<TD style="WIDTH: 104px"><FONT face="新細明體"><asp:label id="Label2" runat="server" Width="144px" CssClass="normal">左邊項目(0-leftPane)</asp:label></FONT></TD>
																			<TD style="WIDTH: 15px"><FONT face="新細明體"></FONT></TD>
																			<TD style="WIDTH: 103px"><FONT face="新細明體"><asp:label id="Label3" runat="server" Width="144px" CssClass="normal">中間項目(1-contentPane )</asp:label></FONT></TD>
																			<TD style="WIDTH: 3px"></TD>
																			<TD style="WIDTH: 117px"><asp:label id="Label4" runat="server" Width="144px" CssClass="normal">右邊項目(2-rightPane)</asp:label></TD>
																			<TD></TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 104px" vAlign="top" align="left"><asp:listbox id="lstLeftPane" runat="server" Width="150px" Height="150px"></asp:listbox></TD>
																			<TD style="WIDTH: 15px" vAlign="bottom"><FONT face="新細明體">&nbsp;
																					<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD><asp:imagebutton id="LPaneRight" runat="server" ImageUrl="../images/rt.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="LPaneUp" runat="server" ImageUrl="../images/up.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="LPaneDown" runat="server" ImageUrl="../images/dn.gif"></asp:imagebutton><BR>
																							</TD>
																						</TR>
																						<TR>
																							<TD><BR>
																								<BR>
																								<BR>
																							</TD>
																						</TR>
																					</TABLE>
																				</FONT>
																			</TD>
																			<TD style="WIDTH: 103px" vAlign="top"><asp:listbox id="lstCenterPane" runat="server" Width="150px" Height="150px"></asp:listbox></TD>
																			<TD style="WIDTH: 4px" vAlign="bottom"><FONT face="新細明體">
																					<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD><asp:imagebutton id="CPaneLeft" runat="server" ImageUrl="../images/lt.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="CPaneRight" runat="server" ImageUrl="../images/rt.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="CPaneUp" runat="server" ImageUrl="../images/up.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="CPaneDown" runat="server" ImageUrl="../images/dn.gif"></asp:imagebutton><BR>
																							</TD>
																						</TR>
																						<TR>
																							<TD><BR>
																								<BR>
																								<BR>
																							</TD>
																						</TR>
																					</TABLE>
																				</FONT>
																			</TD>
																			<TD style="WIDTH: 117px" vAlign="top"><asp:listbox id="lstRightPane" runat="server" Width="150px" Height="150px"></asp:listbox></TD>
																			<TD vAlign="bottom"><FONT face="新細明體">
																					<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD><asp:imagebutton id="RPaneLeft" runat="server" ImageUrl="../images/lt.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="RPaneUp" runat="server" ImageUrl="../images/up.gif"></asp:imagebutton><BR>
																								<BR>
																								<asp:imagebutton id="RPaneDown" runat="server" ImageUrl="../images/dn.gif"></asp:imagebutton><BR>
																							</TD>
																						</TR>
																						<TR>
																							<TD><BR>
																								<BR>
																								<BR>
																							</TD>
																						</TR>
																					</TABLE>
																				</FONT>
																			</TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV></DIV>
										</TD>
									</TR>
								</TBODY>
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
				</TBODY>
			</table>
		</form>
	</body>
</HTML>

<%@ Import Namespace="EIIS" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditAllContextViewSetting.aspx.vb" Inherits="EditAllContextViewSetting" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
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
	<body bottomMargin=0 leftMargin=0 
background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
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
          ><asp:label id="Label7" runat="server" CssClass="head">組織內容維護</asp:label></td>
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
																	<TD style="WIDTH: 419px"><asp:button id="btnUpdate" runat="server" BorderStyle="Groove" Text="修改組織"></asp:button><asp:button id="btnDelete" runat="server" BorderStyle="Groove" Text="刪除組織"></asp:button><asp:button id="btnTreeRefresh" runat="server" BorderStyle="Groove" Text="重新整理" ></asp:button></TD>
																	<TD style="WIDTH: 409px" align="right"></TD>
																	<TD style="WIDTH: 60px" align="right"><FONT size="2"></FONT></TD>
																	<TD><asp:button id="btnAdd" runat="server" BorderStyle="Groove" Text="新增組織"></asp:button></TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD colSpan="2"><FONT face="新細明體">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD><FONT size="2">編號：</FONT></TD>
																	<TD>
																		<P align="left"><asp:label id="txtobjID" runat="server" ></asp:label></P>
																	</TD>
																	<TD><FONT size="2">上層編號：</FONT></TD>
																	<TD><asp:textbox id="txtPID" runat="server"  Width="50px"></asp:textbox></TD>
																	<TD><FONT size="2"></FONT></TD>
																	<TD></TD>
																	<TD><FONT size="2">項目名稱：</FONT></TD>
																	<TD><asp:textbox id="txtObjName" runat="server"  Width="177px"></asp:textbox></TD>
																	<TD><FONT size="2">數值：</FONT></TD>
																	<TD><asp:textbox id="txtObjValue" runat="server"  Width="54px"></asp:textbox></TD>
																	<TD><FONT size="2">序號：</FONT></TD>
																	<TD><asp:textbox id="txtSeqno" runat="server"  Width="27px"></asp:textbox></TD>
																	<TD><FONT size="2">狀態：</FONT></TD>
																	<TD><asp:textbox id="txtState" runat="server"  Width="34px" AutoPostBack="True"></asp:textbox></TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 263px" bgColor="activeborder"><asp:label id="Label1" runat="server" >組織結構</asp:label></TD>
													<TD bgColor="activeborder">
														<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD><FONT size="2">組織成員</FONT></TD>
																<TD align="right">
																	<asp:button id="addmember" runat="server" Text="新增成員" BorderStyle="Groove"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 263px" vAlign="top"><asp:panel id="Panel1" runat="server" Height="380px">
														<!--<iewc:treeview id="TreeView2" runat="server" Width="200px" ExpandLevel="1" AutoPostBack="True"
											Height="100%"></iewc:treeview>-->
                                    <asp:TreeView ID="TreeView1" runat="server" >
                                       
                                    </asp:TreeView>
														</asp:panel></TD>
													<TD vAlign="top" align="left">
														<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD><asp:datagrid id="DataGrid1" runat="server" BorderStyle="None"  Width="100%"
																		ForeColor="Black" GridLines="Vertical" DataKeyField="UID" BorderColor="#DEDFDE" BorderWidth="1px"
																		BackColor="White" CellPadding="4" AutoGenerateColumns="False">
																		<FooterStyle BackColor="#CCCC99"></FooterStyle>
																		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
																		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
																		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
																		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="UID" HeaderText="ID"></asp:BoundColumn>
																			<asp:BoundColumn DataField="Cname" HeaderText="姓名"></asp:BoundColumn>
																			<asp:BoundColumn DataField="sex" HeaderText="性別"></asp:BoundColumn>
																			<asp:BoundColumn DataField="TITLE" HeaderText="職稱"></asp:BoundColumn>
																			<asp:BoundColumn DataField="TELmobile" HeaderText="電話"></asp:BoundColumn>
																		</Columns>
																		<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
																	</asp:datagrid></TD>
															</TR>
															<TR>
																<TD><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD><FONT face="新細明體"><BR>
																		<BR>
																	</FONT>
																</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
						<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></td>
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

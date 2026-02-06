<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubscriptionAdmin.aspx.vb" Inherits="ASPNET.StarterKit.Portal.SubscriptionAdmin" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<title>管理電子報</title>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner><BR>
			<BR>
			</TD>
			<TABLE id="Table7" cellSpacing="3" cellPadding="3" width="800" border="0" align="center">
				<TR>
					<TD width="50%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
										<TR>
											<TD width="1"><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></TD>
											<TD width=118 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif'>
												<asp:label id="Label3" runat="server" CssClass="head">電子報表頭管理</asp:label></TD>
											<TD><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></TD>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></TD>
							</TR>
							<TR>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></TD>
								<TD bgColor="#ffffff">
									<TABLE width="100%" border="0">
										<TR>
											<TD vAlign="top" align="center"><!---------------------------------------------------------------------------------------------------------------------->  <!---------------------------------------------------------------------------------------------------------------------->
												<DIV><FONT face="新細明體">
														<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="176">
															<TR>
																<TD align="left" colSpan="2">
																	<asp:datalist id="DataList1" runat="server" DataKeyField="EntityID">
																		<ItemTemplate>
																			<asp:CheckBox id=Edit1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' AutoPostBack="False">
																			</asp:CheckBox>
																		</ItemTemplate>
																	</asp:datalist></TD>
															</TR>
															<TR>
																<TD align="center" colSpan="2">
																	<asp:linkbutton id="SubscriptionPageUp" runat="server">上一頁</asp:linkbutton>
																	<asp:linkbutton id="SubscriptionPageDown" runat="server">下一頁</asp:linkbutton></TD>
															</TR>
															<TR>
																<TD align="center" colSpan="2">
																	<asp:button id="SubscriptionInsert" runat="server" Text="新增"></asp:button>
																	<asp:button id="SubscriptionSelect" runat="server" Text="選擇"></asp:button>
																	<asp:button id="SubscriptionUpdate" runat="server" Text="修改"></asp:button>
																	<asp:Button id="SubscriptionListImport" runat="server" Text="匯入訂閱清單"></asp:Button>
																	<asp:button id="SubscriptionListEdit" runat="server" Text="編輯訂閱清單"></asp:button>
																	<asp:button id="SubscriptionDelete" runat="server" Text="刪除"></asp:button></TD>
															</TR>
														</TABLE>
													</FONT>
												</DIV>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></TD>
							</TR>
							<TR>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></TD>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="50%">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
							<TR>
								<TD colSpan="3">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
										<TR>
											<TD width="1"><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></TD>
											<TD width=133 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif'>
												<asp:label id="Label4" runat="server" CssClass="head">電子報資料檔管理</asp:label></TD>
											<TD><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></TD>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></TD>
							</TR>
							<TR>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></TD>
								<TD bgColor="#ffffff">
									<TABLE id="Table3" width="100%" border="0">
										<TR>
											<TD vAlign="top" align="center"><!---------------------------------------------------------------------------------------------------------------------->  <!---------------------------------------------------------------------------------------------------------------------->
												<DIV><FONT face="新細明體">
														<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="195">
															<TR>
																<TD align="left">
																	<asp:datalist id="DataList2" runat="server" DataKeyField="EntityID">
																		<ItemTemplate>
																			<asp:CheckBox id="Edit2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' AutoPostBack="False">
																			</asp:CheckBox>
																		</ItemTemplate>
																	</asp:datalist></TD>
															</TR>
															<TR>
																<TD align="center" colSpan="2">
																	<asp:linkbutton id="EPaperPageUp" runat="server">上一頁</asp:linkbutton>
																	<asp:linkbutton id="EPaperPageDown" runat="server">下一頁</asp:linkbutton></TD>
															</TR>
															<TR>
																<TD align="center" colSpan="2">
																	<asp:button id="EPaperInsert" runat="server" Text="新增"></asp:button>
																	<asp:button id="EPaperSelect" runat="server" Text="選擇"></asp:button>
																	<asp:button id="EPaperUpdate" runat="server" Text="修改"></asp:button>
																	<asp:button id="EPaperDelete" runat="server" Text="刪除"></asp:button></TD>
															</TR>
														</TABLE>
													</FONT>
												</DIV>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></TD>
							</TR>
							<TR>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></TD>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" height="0">
							<TR>
								<TD colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
										<TR>
											<TD width="1"><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></TD>
											<TD width=198 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif'>
												<asp:label id="Label7" runat="server" CssClass="itemtitle">電子報發報排程管理</asp:label></TD>
											<TD><IMG 
                  src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></TD>
								<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></TD>
							</TR>
							<TR>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></TD>
								<TD bgColor="#ffffff">
									<TABLE width="100%" border="0">
										<TR>
											<TD vAlign="top" align="center"><!---------------------------------------------------------------------------------------------------------------------->
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD vAlign="top">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="itemtitle">已選擇之表頭</TD>
																	<TD class="itemtitle">已選擇之檔案</TD>
																</TR>
																<TR>
																	<TD vAlign="top">
																		<asp:listbox id="ListBoxSubscription" runat="server" Height="42px" Width="120"></asp:listbox>
																		<asp:imagebutton id="ImageButtonSubscriptionDelete" runat="server" ImageUrl="~/images/delete.gif"></asp:imagebutton></TD>
																	<TD>
																		<asp:listbox id="ListBoxEPaper" runat="server" Height="73px" Width="120" SelectionMode="Multiple"></asp:listbox>
																		<asp:imagebutton id="ImageButtonEPaperDelete" runat="server" ImageUrl="~/images/delete.gif"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
														<%--
														<TD vAlign="top">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="itemtitle">派送時間</TD>
																	<TD class="itemtitle">派送行程</TD>
																</TR>
																<TR>
																	<TD>
																		<asp:textbox id="TextBoxDeliverDate" runat="server"></asp:textbox>
																		<asp:linkbutton id="LinkButtonCalendarSwitch" runat="server">月曆</asp:linkbutton>
																		<asp:calendar id="Calendar1" runat="server" Visible="False"></asp:calendar></TD>
																	<TD>
																		<asp:radiobutton id="RadioButtonDeliverEnable" runat="server" Text="啟動" GroupName="DeliverMark" Checked="True"></asp:radiobutton>
																		<asp:radiobutton id="RadioButtonDeliverDisable" runat="server" Text="停止" GroupName="DeliverMark"></asp:radiobutton></TD>
																</TR>
															</TABLE>
														</TD>
																--%>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="10%"></TD>
																	<TD width="367"></TD>
																	<TD align="right" width="40%">
																		<asp:button id="EDeliverManagerInsert" runat="server" Text="新增"></asp:button>
																		<asp:button id="EDeliverManagerOK" runat="server" Text="確定" Visible="False"></asp:button></TD>
																</TR>
																<TR>
																	<TD width="10%" colSpan="3">
																		<HR width="100%" SIZE="1">
																	</TD>
																</TR>
																<TR>
																	<Th width="10%" align="left">
																		編號</Th>
																	<Th width="50%" align="left">
																		電子報表頭</Th>
																	<Th width="40%" align="left">
																		電子報檔案</Th>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<asp:datalist id="DataList3" runat="server" DataKeyField="EntityID" Width="100%">
																<ItemTemplate>
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<tr>
																			<td width="10%">
																				<asp:CheckBox id=Edit3 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' AutoPostBack="False">
																				</asp:CheckBox></td>
																			<td width="50%">
																				<asp:Label id="Label1" runat="server">
																					<%# DataBinder.Eval(Container.DataItem, "SubscriptionTitle") %>
																				</asp:Label>
																			</td>
																			<td width="40%">
																				<asp:Label id="Label2" runat="server">
																					<%# DataBinder.Eval(Container.DataItem, "EPaperTitle") %>
																				</asp:Label>
																			</td>
																		</tr>
																	</table>
																</ItemTemplate>
															</asp:datalist></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<asp:linkbutton id="EDeliverManagerPageUp" runat="server">上一頁</asp:linkbutton>
															<asp:linkbutton id="EDeliverManagerPageDown" runat="server">下一頁</asp:linkbutton></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<asp:button id="EDeliverManagerUpdate" runat="server" Text="修改"></asp:button>
															<asp:button id="EDeliverManagerDelete" runat="server" Text="刪除"></asp:button>
															<asp:button id="EDeliverManagerSend" runat="server" Text="派送"></asp:button>
															<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></TD>
													</TR>
												</TABLE> <!----------------------------------------------------------------------------------------------------------------------></TD>
										</TR>
									</TABLE>
								</TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></TD>
							</TR>
							<TR>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></TD>
								<TD 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></TD>
								<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

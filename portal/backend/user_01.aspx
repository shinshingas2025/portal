<%@ Page Language="vb" AutoEventWireup="false" Codebehind="user_01.aspx.vb" Inherits="user_01"%>
<HTML>
	<HEAD>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<DIV align="justify">
				<table>
					<tr>
						<td bgColor="#a6c4e1"></td>
						<td width="930" bgColor="#6699cc"></td>
						<td bgColor="#a6c4e1"></td>
					</tr>
					<tr>
						<td bgColor="#d2e1f0"></td>
						<td width="930">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
								<p></p>
								<tr>
									<td vAlign="middle" align="center">
										<P align="left"><FONT color="red" size="2"><FONT color="#003366" size="2"><FONT color="red" size="2"><B>&nbsp; 
															&gt;&gt;</B> <FONT color="#003366" size="2">新用戶申請查詢</FONT></FONT></FONT></FONT></P>
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center" width="748">
										<DIV align="left">
											<table id="Table4" cellSpacing="4" cellPadding="4" width="679" align="left" border="0">
												<TR>
													<TD vAlign="top" align="left">
														<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="493" border="0">
															<TR>
																<TD width="4" height="23"></TD>
																<TD width="366" height="23">
																	<P align="center"><asp:label id="msgbox" runat="server" CssClass="normal" ForeColor="Red" Width="366"></asp:label></P>
																</TD>
																<TD width="35" height="23"></TD>
															</TR>
															<TR>
																<TD width="4" height="25"><FONT face="新細明體"><asp:radiobutton id="applydateO" runat="server" CssClass="normal" Width="104px" Text="申請日期" GroupName="AA"
																			Checked="True"></asp:radiobutton></FONT></TD>
																<TD width="366" height="25"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:20010809)</FONT></TD>
																<TD width="35" height="25"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="16"><FONT face="新細明體"><asp:radiobutton id="ProcessDateO" runat="server" CssClass="normal" Width="112px" Text="處理日期" GroupName="AA"></asp:radiobutton></FONT></TD>
																<TD width="366" height="16"><asp:textbox id="ProcessSDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label4" runat="server">─</asp:label><asp:textbox id="ProcessEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:20010809)</FONT></TD>
																<TD width="35" height="16"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="19"><FONT face="新細明體"><asp:label id="Label1" runat="server" CssClass="normal" Width="96px">處理情形</asp:label></FONT></TD>
																<TD width="366" height="19"><FONT face="新細明體"><asp:dropdownlist id="status" runat="server">
																			<asp:ListItem Value="0">未處理</asp:ListItem>
																			<asp:ListItem Value="1">已處理</asp:ListItem>
																		</asp:dropdownlist></FONT></TD>
																<TD width="35" height="19"><asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button></TD>
															</TR>
															<TR>
																<TD width="4" height="14"></TD>
																<TD width="366" height="14"></TD>
																<TD width="35" height="14"></TD>
															</TR>
															<TR>
																<TD width="4" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																<TD width="366" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																<TD width="35" height="14"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																<TD width="366" height="25"><asp:label id="Creater" runat="server" ></asp:label></TD>
																<TD width="35" height="25"><FONT face="新細明體"><asp:button id="btnPrint" runat="server" Width="43px" Text="列印"></asp:button></FONT></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<tr>
													<td vAlign="top" align="center"><asp:datagrid id="dgCart" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
															DataKeyField="EntityID" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White" BackColor="White"
															GridLines="None" CellSpacing="1">
															<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
															<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
															<EditItemStyle  Width="600px"></EditItemStyle>
															<AlternatingItemStyle ></AlternatingItemStyle>
															<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
															<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="EntityID" ReadOnly="True"></asp:BoundColumn>
																<asp:BoundColumn DataField="Appl_Kind" ReadOnly="True" HeaderText="裝置事項">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="am01_name" ReadOnly="True" HeaderText="申請人">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="am01_id_no" ReadOnly="True" HeaderText="ID">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="am01_telno2" ReadOnly="True" HeaderText="電話">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Email" ReadOnly="True" HeaderText="Email">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="createtime" ReadOnly="True" HeaderText="申請日期">
																	<HeaderStyle ForeColor="White"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ProcessTime" ReadOnly="True" HeaderText="處理日期">
																	<HeaderStyle Width="10%"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="operator" ReadOnly="True" HeaderText="執行人員">
																	<HeaderStyle Width="10%"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="SendTime" ReadOnly="True" HeaderText="匯入日期"></asp:BoundColumn>
																<asp:BoundColumn DataField="SendID" ReadOnly="True" HeaderText="申請號碼"></asp:BoundColumn>
																<asp:TemplateColumn HeaderText="處理情形">
																	<ItemTemplate>
																		<asp:CheckBox id=CheckBox1 runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.status") %>' Enabled="False">
																		</asp:CheckBox>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:CheckBox id=txtStatus runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.status") %>'>
																		</asp:CheckBox>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="處理"></asp:EditCommandColumn>
																<asp:ButtonColumn Text="列印" CommandName="Select"></asp:ButtonColumn>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:Button id=Button1 runat="server" Text="匯入MIS" Enabled='<%#getMode(DataBinder.Eval(Container, "DataItem.SendTimeStr"), DataBinder.Eval(Container, "DataItem.status"))%>' CommandName="send">
																		</asp:Button>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
																Mode="NumericPages"></PagerStyle>
														</asp:datagrid>
														<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
														</FONT>
														<p><asp:label id="Message" runat="server"></asp:label></p>
													</td>
												</tr>
											</table>
										</DIV>
										<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
										</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
										<P align="left"><br>
										</P>
										<p align="left"><FONT face="新細明體"></FONT></p>
									</td>
								</tr>
							</table>
						</td>
						<td bgColor="#d2e1f0">&nbsp;</td>
					</tr>
				</table>
			</DIV>
		</form>
	</body>
</HTML>

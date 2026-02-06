<%@ Page Language="vb" AutoEventWireup="false" Codebehind="wmember_01.aspx.vb" Inherits="wmember_01" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<DIV align="justify">
				<table>
					<tr>
						<td bgColor="#a6c4e1"></td>
						<td width="930" bgColor="#6699cc"><FONT face="新細明體"></FONT></td>
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
															&gt;&gt;</B> <FONT color="#003366" size="2">會員修改資料記錄查詢</FONT></FONT></FONT></FONT></P>
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
																<FONT color="#003366" size="3">查詢條件</FONT></TR>
															<TR>
																<TD width="4" height="23">
																	<P align="left"><FONT color="#003366" size="2"></FONT>&nbsp;</P>
																</TD>
																<TD width="366" height="23">
																	<P align="center"><asp:label id="msgbox" runat="server" Width="366" ForeColor="Red" CssClass="normal"></asp:label></P>
																</TD>
																<TD width="35" height="23"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="25"><FONT face="新細明體"><asp:radiobutton id="applydateO" runat="server" Width="104px" CssClass="normal" Checked="True" GroupName="AA"
																			Text="註冊日期"></asp:radiobutton></FONT></TD>
																<TD width="366" height="25"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><BR>
																	<FONT face="細明體" color="#3399cc" size="2">(Ex:990809，空白表全部)</FONT></TD>
																<TD width="35" height="25"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="19"><FONT face="新細明體"><asp:label id="likeFlag" runat="server" Width="96px" CssClass="normal">會員狀態</asp:label></FONT></TD>
																<TD width="366" height="19"><FONT face="新細明體"><asp:dropdownlist id="status" runat="server">
																			<asp:ListItem Value="0" Selected="True">全部</asp:ListItem>
																			<asp:ListItem Value="1">已啟動、已設定用戶號碼</asp:ListItem>
																			<asp:ListItem Value="2">已啟動、尚未設定用戶號碼</asp:ListItem>
																			<asp:ListItem Value="3">尚未啟動</asp:ListItem>
																			<asp:ListItem Value="4">授權碼發送失敗</asp:ListItem>
																			<asp:ListItem Value="5">停權</asp:ListItem>
																		</asp:dropdownlist></FONT></TD>
															</TR>
															<TR>
																<TD width="114"><asp:dropdownlist id="likeSelect" runat="server" Width="112px">
																		<asp:ListItem Value="wm_id" Selected="True">身份證號碼(統一編號)</asp:ListItem>
																		<asp:ListItem Value="wm_email">電子信箱</asp:ListItem>
																		<asp:ListItem Value="wm_user_name">申請人姓名(承辦人姓名)</asp:ListItem>
																		<asp:ListItem Value="wm_mobile">行動電話</asp:ListItem>
																	</asp:dropdownlist></TD>
																<TD width="624"><asp:textbox id="likeContent" runat="server" Width="160px"></asp:textbox></TD>
																<FONT face="新細明體">&nbsp;</FONT>
																<TD width="35" height="19"><asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button></TD>
															</TR>
															<TR>
																<TD width="4" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																<TD width="366" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																<TD width="35" height="14"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																<TD width="366" height="25"><asp:label id="Creater" runat="server" ></asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<tr>
													<td vAlign="top" align="center">
														<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="850px" CellSpacing="1" GridLines="None" BackColor="White"
																BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="wm_no"
																AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
																<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
																<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
																<EditItemStyle  Width="600px"></EditItemStyle>
																<AlternatingItemStyle ></AlternatingItemStyle>
																<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
																<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="ORGFLAG" ReadOnly="True" HeaderText="身份別">
																		<HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="wm_no">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
																		<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_tel_oo" ReadOnly="True" HeaderText="連絡電話(O)">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_tel_h" ReadOnly="True" HeaderText="連絡電話(H)">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="wm_email" ReadOnly="True" HeaderText="電子信箱">
																		<HeaderStyle Width="15%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="add_datetime" ReadOnly="True" HeaderText="註冊日期">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="OPENFLAG" ReadOnly="True" HeaderText="會員狀態">
																		<HeaderStyle Width="16%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="wm_org_flag" ReadOnly="True"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="wm_no" ReadOnly="True"></asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="查詢">
																		<ItemTemplate>
																			<asp:linkbutton id="btndetail" text="內容" runat="server" CommandName="detail" Width="3%"></asp:linkbutton>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
																	Mode="NumericPages"></PagerStyle>
															</asp:datagrid></DIV>
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

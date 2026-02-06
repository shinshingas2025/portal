<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Receipt_Send_Record.aspx.vb" Inherits="Receipt_Send_Record" %>
<HTML>
	<body>
		<form id="Form2" runat="server">
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
							<tr>
								<td vAlign="middle" align="center">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="400">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">電子繳費憑證發送記錄管理&nbsp;</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" CssClass="normal" ForeColor="Red"></asp:label></td>
							</tr>
							<tr>
								<td id="TD1" vAlign="top" align="center" width="748" runat="server">
									<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="left" height="92">
												<TABLE height="112" cellSpacing="0" cellPadding="0" width="472" border="0" ms_1d_layout="TRUE">
													<TR>
														<TD>
															<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="493" border="0">
																<TR>
																	<TD width="4" height="16"><FONT face="新細明體"><asp:label id="Label3" runat="server" CssClass="normal" Width="96px">用戶執行日期</asp:label></FONT></TD>
																	<TD width="338" height="16"><asp:textbox id="ProcessSDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><asp:label id="Label4" runat="server">─</asp:label><asp:textbox id="ProcessEDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:0990809)</FONT></TD>
																	<TD width="43" height="16"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="4" height="19"><FONT face="新細明體"><asp:label id="Label1" runat="server" CssClass="normal" Width="96px">執行動作</asp:label></FONT></TD>
																	<TD width="338" height="19"><FONT face="新細明體"><asp:dropdownlist id="ActionInt" runat="server">
																				<asp:ListItem Value="0">全部</asp:ListItem>
																				<asp:ListItem Value="1">下載</asp:ListItem>
																				<asp:ListItem Value="2">補寄電子檔</asp:ListItem>
																				<asp:ListItem Value="3">補寄紙本</asp:ListItem>
																			</asp:dropdownlist></FONT></TD>
																	<TD width="43" height="19"></TD>
																</TR>
																<TR>
																	<TD width="4" height="14"><FONT face="新細明體" size="2"><STRONG><asp:dropdownlist id="KeyWordInt" runat="server">
																					<asp:ListItem Value="0">身份證號碼(統一編號)</asp:ListItem>
																					<asp:ListItem Value="1">電子信箱</asp:ListItem>
																					<asp:ListItem Value="2">申請人姓名(承辦人姓名)</asp:ListItem>
																					<asp:ListItem Value="3">行動電話</asp:ListItem>
																					<asp:ListItem Value="4">用戶號碼</asp:ListItem>
																				</asp:dropdownlist></STRONG></FONT></TD>
																	<TD width="338" height="14"><FONT face="新細明體"><asp:textbox id="KeyWordStr" runat="server"></asp:textbox></FONT></TD>
																	<TD width="43" height="14"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="4" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG></STRONG></FONT></FONT></TD>
																	<TD width="338" height="25"><FONT face="新細明體"></FONT></TD>
																	<TD width="43" height="25"><FONT face="新細明體"><asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<hr>
												<FONT face="新細明體"></FONT>
											</TD>
										</TR>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="740px" CellSpacing="1" GridLines="None" BackColor="White"
														BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" AllowPaging="True"
														AutoGenerateColumns="False" AllowSorting="True">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<SelectedItemStyle  Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
															BackColor="#9471DE"></SelectedItemStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="ActionDate" HeaderText="執行時間"></asp:BoundColumn>
															<asp:BoundColumn DataField="rul_house_no" HeaderText="用戶號碼"></asp:BoundColumn>
															<asp:BoundColumn DataField="wm_user_name" HeaderText="用戶姓名"></asp:BoundColumn>
															<asp:BoundColumn DataField="Action" HeaderText="執行動作"></asp:BoundColumn>
															<asp:BoundColumn DataField="rul_data_ym" HeaderText="繳費憑證年月"></asp:BoundColumn>
															<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)"></asp:BoundColumn>
															<asp:BoundColumn DataField="rul_email" HeaderText="電子信箱"></asp:BoundColumn>
															<asp:BoundColumn DataField="wm_mobile" HeaderText="行動電話"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="wm_No" HeaderText="用戶序號"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="rul_no" HeaderText="使用者序號"></asp:BoundColumn>
															<asp:ButtonColumn DataTextField="Action1" HeaderText="處理" CommandName="Select"></asp:ButtonColumn>
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												</FONT>
												<P id="P1" runat="server"><asp:label id="Message" runat="server"></asp:label></P>
											</td>
										</tr>
									</table>
									<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
									</p>
									<p><FONT face="新細明體"></FONT></p>
								</td>
							</tr>
						</table>
					</td>
					<td bgColor="#d2e1f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

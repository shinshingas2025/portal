<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Batch_Record_Search.aspx.vb" Inherits="Batch_Record_Search" %>
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
											<td width="497">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">電子繳費憑證批次發送記錄查詢</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" ForeColor="Red" CssClass="normal"></asp:label></td>
							</tr>
							<tr>
								<td id="TD1" vAlign="top" align="center" width="748">
									<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="left" height="92">
												<TABLE height="112" cellSpacing="0" cellPadding="0" width="736" border="0" ms_1d_layout="TRUE">
													<TR>
														<TD width="597">
															<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="728" border="0">
																<TR>
																	<TD width="35" height="24"><FONT face="新細明體"><asp:label id="Label3" runat="server" CssClass="normal" Width="96px">發送日期</asp:label></FONT></TD>
																	<TD width="423" height="24"><asp:textbox id="ProcessSDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><asp:label id="Label4" runat="server">─</asp:label><asp:textbox id="ProcessEDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:0990809)</FONT></TD>
																</TR>
																<TR>
																	<TD width="35" height="13"><FONT face="新細明體"><asp:label id="Label1" runat="server" CssClass="normal" Width="96px">用戶號碼</asp:label></FONT></TD>
																	<TD width="423" height="13"><asp:textbox id="HouseNO" runat="server" Width="86px" MaxLength="11"></asp:textbox><FONT face="細明體" color="#3399cc" size="2"></FONT></TD>
																</TR>
																<TR>
																	<TD width="35" height="13"><FONT face="新細明體"><asp:label id="Label5" runat="server" CssClass="normal" Width="96px">繳費憑證年月</asp:label></FONT></TD>
																	<TD width="423" height="13"><asp:textbox id="ReceiptDate" runat="server" Width="86px" MaxLength="5"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:09908)</FONT></TD>
																</TR>
																<TR>
																	<TD width="28" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG></STRONG></FONT></FONT></TD>
																	<TD align="right" width="700" height="25"><FONT face="新細明體">&nbsp;<asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
																			<asp:button id="Button1" runat="server" Text="列印明細表"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
																			<asp:button id="Button2" runat="server" Text="列印統計表"></asp:button></FONT></TD>
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
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="740px" AllowSorting="True" AutoGenerateColumns="False"
														AllowPaging="True" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White"
														BackColor="White" GridLines="None" CellSpacing="1">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<SelectedItemStyle  Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
															BackColor="#9471DE"></SelectedItemStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="rb_no" HeaderText="批次號碼"></asp:BoundColumn>
															<asp:BoundColumn DataField="rb_start_datetime" HeaderText="執行開始時間"></asp:BoundColumn>
															<asp:BoundColumn DataField="EndDate" HeaderText="執行結束時間"></asp:BoundColumn>
															<asp:BoundColumn DataField="rb_run_user" HeaderText="管理者"></asp:BoundColumn>
															<asp:BoundColumn DataField="RStatus" HeaderText="執行結果"></asp:BoundColumn>
															<asp:ButtonColumn Text="選取" DataTextField="rb_success" HeaderText="成功筆數" CommandName="Select1"></asp:ButtonColumn>
															<asp:ButtonColumn Text="選取" DataTextField="rb_failure" HeaderText="失敗筆數" CommandName="Select2"></asp:ButtonColumn>
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

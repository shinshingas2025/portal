<%@ Page Language="vb" AutoEventWireup="false" Codebehind="member_trans_log.aspx.vb" Inherits="member_trans_log" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<HTML>
	<body>
		<form id="Form1" runat="server">
			<!-- NAME: index.tpl --><tr>
				<td bgcolor="#A6C4E1"></td>
				<td bgcolor="#6699CC" width="930"></td>
				<td bgcolor="#A6C4E1"></td>
			</tr>
			<tr>
				<td bgcolor="#D2E1F0"></td>
				<td width="930">
					<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
						<tr>
							<td vAlign="middle" align="center">
								<table cellSpacing="0" cellPadding="3" width="100%" border="0">
									<tr>
										<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">查詢批次刪除拆表與終止戶資料</font></font></td>
									</tr>
									<tr align="left">
										<td>
											<table cellSpacing="0" cellPadding="0" width="704" border="0">
												<tr>
													<td width="114">
														<P align="center">&nbsp;<FONT face="新細明體" color="#0066ff">查詢條件</FONT></P>
													</td>
													<td width="444">
														<P align="center">&nbsp;
															<asp:label id="msgbox" runat="server" ForeColor="Red"></asp:label></P>
													</td>
													<TD width="91"></TD>
												</tr>
												<tr>
													<td width="114"><FONT face="新細明體">執行日期</FONT></td>
													<td width="444">&nbsp;
														<asp:textbox id="txtDateStart" runat="server" Width="68px" MaxLength="7"></asp:textbox><asp:label id="Label1" runat="server">─</asp:label><asp:textbox id="txtDateEnd" runat="server" Width="68px" MaxLength="7"></asp:textbox><FONT color="#3399cc">(Ex:990809;空白表全部)</FONT><FONT face="新細明體"></FONT></td>
													<TD><FONT face="新細明體">
															<asp:button id="inquire" runat="server" Text="查詢"></asp:button>&nbsp;
															<asp:button id="Button1" runat="server" Text="列印"></asp:button></FONT></TD>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td vAlign="top" align="center" width="748">
								<table id="Table4" cellSpacing="4" cellPadding="4" width="95%" align="left" border="0">
									<tr>
										<td><FONT face="新細明體">刪除原因：１.拆表 ２.終止戶 ３.三期未繳費 ４.用戶更名</FONT>
										</td>
									</tr>
									<tr>
										<td vAlign="top" align="center"><asp:datagrid id="dgCart" runat="server" Width="704px" AllowSorting="True" AutoGenerateColumns="False"
												AllowPaging="True" DataKeyField="hnc_no" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White"
												BackColor="White" GridLines="None" CellSpacing="1">
												<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
												<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
												<EditItemStyle  Width="600px"></EditItemStyle>
												<AlternatingItemStyle ></AlternatingItemStyle>
												<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
												<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="hnc_house_no" HeaderText="用戶號碼">
														<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="hnc_house_address" HeaderText="地址">
														<HeaderStyle ForeColor="White" Width="55%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="hnc_del_reason" HeaderText="刪除原因">
														<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="hnc_del_datetime" HeaderText="刪除時間">
														<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
													</asp:BoundColumn>
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
							</td>
						</tr>
					</table>
				</td>
				<td bgcolor="#D2E1F0">&nbsp;</td>
			</tr>
			<tr bgcolor="#000000">
				<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

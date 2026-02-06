<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ers_send_detailMgt.aspx.vb" Inherits="ers_send_detailMgt" %>
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
										<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">查詢用戶歷史交易資料</font></font></td>
									</tr>
									<tr align="left">
										<td>
											<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="1">
												<TR>
													<TD width="89"><FONT size="2"><STRONG>身份證號碼<BR>
																(統一編號)</STRONG></FONT></TD>
													<TD width="245"><asp:label id="lbluser_id" runat="server"  Width="136px"></asp:label>
														<asp:Label id="lblwm_no" runat="server" Visible="False">Label</asp:Label></TD>
													<TD><FONT size="2"><STRONG>會員姓名</STRONG></FONT></TD>
													<TD><asp:label id="lbluser_name" runat="server"  Width="231px"></asp:label></TD>
												</TR>
												<TR>
													<TD width="89"><FONT face="新細明體" size="2"><STRONG>用戶號碼</STRONG></FONT></TD>
													<TD width="245"><asp:label id="lblhouse_no" runat="server"  Width="128px"></asp:label></TD>
													<TD><FONT face="新細明體" size="2"><STRONG>用戶姓名</STRONG></FONT></TD>
													<TD><FONT size="2"><asp:label id="lblhouse_name" runat="server" Width="120px"></asp:label></FONT></TD>
												</TR>
											</TABLE>
											<P align="center"><INPUT type="button" value="回上一頁" onClick="javascript:history.go(-1);"></P>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td vAlign="top" align="center" width="748">
								<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" align="left"
									border="0">
									<tr>
										<td vAlign="top" align="center"><asp:datagrid id="dgCart" runat="server" Width="704px" AllowSorting="True" AutoGenerateColumns="False"
												AllowPaging="True" DataKeyField="add_user" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White"
												BackColor="White" GridLines="None" CellSpacing="1">
												<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
												<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
												<EditItemStyle  Width="600px"></EditItemStyle>
												<AlternatingItemStyle ></AlternatingItemStyle>
												<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
												<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="add_datetime" HeaderText="執行時間">
														<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="add_user" HeaderText="執行者">
														<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="action" HeaderText="執行動作">
														<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="rul_data_ym" HeaderText="繳費憑證年月">
														<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="rul_email" HeaderText="電子信箱">
														<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
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

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="user_03.aspx.vb" Inherits="user_03" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
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
					<table width="100%" border="0" cellpadding="3" cellspacing="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font size="2" color="red"><b>&gt;&gt;</b> <font size="2" color="#003366">電子對帳單申請查詢</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" width="748">
					<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
						<tr>
							<td align="center" valign="top">
								<form id="Form1" method="post" runat="server">
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" CellSpacing="1" GridLines="None" BackColor="White" BorderColor="White"
											CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="acno"
											AllowPaging="True" AutoGenerateColumns="False" Width="550px" AllowSorting="True">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="acnumber" HeaderText="用戶號碼">
													<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="actel" HeaderText="聯絡電話">
													<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="acemail" HeaderText="電子信箱">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="createdate" HeaderText="日期">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
									</FONT>
									<P><asp:label id="Message" runat="server"></asp:label></P>
								</form>
							</td>
						</tr>
					</table>
					<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
					</p>
					<p><FONT face="新細明體"></FONT></p>
				</td>
			</tr>
		</table>
	</td>
	<td bgcolor="#D2E1F0">&nbsp;</td>
</tr>
<tr bgcolor="#000000">
	<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="download_grp2.aspx.vb" Inherits="download_grp2" %>
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
							<td width="26%"><font size="2" color="red"><b>&gt;&gt;</b> <font size="2" color="#003366"><FONT color="#003366">
											投資人訊息檔案</FONT>群組管理</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" width="748">
					<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
						<tr>
							<td align="center">
								<form id="Form1" method="post" runat="server">
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" GridLines="None" AllowSorting="True" PageSize="3" OnCancelCommand="dgCart_Cancel"
											OnDeleteCommand="dgCart_Delete" OnUpdateCommand="dgCart_Update" OnEditCommand="dgCart_Edit"
											Width="600px" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True"
											DataKeyField="no" ShowFooter="True" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
											CellSpacing="1">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="it_name" HeaderText="群組">
													<HeaderStyle ForeColor="White" Width="60%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="it_order" HeaderText="排列順序">
													<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="no" DataNavigateUrlFormatString="download_grp2.aspx?no={0}"
													DataTextField="no" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<%--
									<P><FONT face="新細明體">
											<asp:button id="btnFirstPage" runat="server" Text="第一頁" CommandName="第一頁" ToolTip="檢視第一頁資料"></asp:button><asp:button id="btnPreviousPage" runat="server" Text="上一頁" CommandName="上一頁" ToolTip="檢視上一頁資料"></asp:button><asp:button id="btnNextPage" runat="server" Text="下一頁" CommandName="下一頁" ToolTip="檢視下一頁資料"></asp:button><asp:button id="btnLastPage" runat="server" Text="最後一頁" CommandName="最後一頁" ToolTip="檢視最後一頁資料"></asp:button><BR>
									</P>
									--%>
									</FONT>
									<P><asp:Label id="Message" runat="server"></asp:Label></P>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
											border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="80" bgColor="lavender" height="27">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>群組名稱</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" height="27" colSpan="3"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
															<asp:textbox id="txtname" runat="server" Width="331px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="lavender" height="35"><FONT color="#000000" size="2"><STRONG>排列順序</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" height="34" colSpan="3"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體">
															<asp:textbox id="txtorder" runat="server" Width="32px" Height="25px"></asp:textbox></FONT><font color="#660033" size="2">(如:1、2、3...)</font></TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<INPUT id='ittype' name="ittype" type='hidden' value='DOWN'>
														<% If (Request("no") IS Nothing) Then %>
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除">
														<% 
								Else 
								Response.write("<INPUT id='no' type='hidden' value='" & Request("no") & "'>")
							%>
														<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
														<% End If %>
														</FONT></TD>
												</TR>
												<TR>
													<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
												</TR>
											</TBODY>
										</TABLE>
									</P>
								</form>
								</FORM></td>
						</tr>
					</table>
					<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
					<P><br>
					</P>
					<p><FONT face="新細明體"></FONT></p>
				</td>
			</tr>
		</table>
	</td>
	<td bgcolor="#D2E1F0">&nbsp;</td>
</tr>
<tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

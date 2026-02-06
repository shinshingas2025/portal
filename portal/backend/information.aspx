<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="information.aspx.vb" Inherits="information" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<!-- NAME: index.tpl --><tr>
	<td bgcolor="#A6C4E1">&nbsp;</td>
	&nbsp;
	<td bgcolor="#6699CC" width="930"></td>
	&nbsp;
	<td bgcolor="#A6C4E1">&nbsp;</td>
	&nbsp;
</tr>
<tr>
	<td bgcolor="#D2E1F0">&nbsp;</td>
	<td width="930">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
			<tr>
				<td vAlign="middle" align="center">
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">公司訊息管理</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" width="748">
					<DIV align="left">
						<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" align="left"
							border="0">
							<tr>
								<td align="center">
									<form id="Form1" method="post" runat="server">
										<asp:datagrid id="dgCart" runat="server" AllowSorting="True" PageSize="3" OnCancelCommand="dgCart_Cancel"
											OnDeleteCommand="dgCart_Delete" OnUpdateCommand="dgCart_Update" OnEditCommand="dgCart_Edit"
											Width="600px" AutoGenerateColumns="False" AllowPaging="True" DataKeyField="iforno" ShowFooter="True"
											BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" BorderColor="White" BackColor="White"
											GridLines="None" CellSpacing="1">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="iforsubject" HeaderText="資訊主旨">
													<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="iforcontent" HeaderText="資訊內容">
													<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="sdate" HeaderText="上架日期">
													<HeaderStyle Width="12%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="edate" HeaderText="下架日期">
													<HeaderStyle ForeColor="White" Width="12%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="iforno" DataNavigateUrlFormatString="information.aspx?iforno={0}"
													HeaderText="操作" NavigateUrl="編輯">
													<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" CommandName="Delete">
													<HeaderStyle Width="8%"></HeaderStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle NextPageText="下一頁"  Font-Names="細明體" PrevPageText="上一頁" HorizontalAlign="Right"
												ForeColor="Black" BackColor="#C6C3C6" PageButtonCount="20" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
										</FONT>
										<p><asp:label id="Message" runat="server"></asp:label>
										<p>
											<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
												width="600" bgColor="#003399" border="0">
												<FONT face="新細明體"></FONT>
												<TBODY>
													<TR>
														<TD width="82" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>主題</STRONG></FONT></FONT></P>
														</TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtsubject" runat="server" Width="376px"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD width="82" bgColor="#e6e6fa" height="27"><STRONG><FONT size="2">上下架日期</FONT></STRONG></TD>
														<TD bgColor="#ffffff" colSpan="3" height="27"><asp:textbox id="SDATE" runat="server" Width="96px"></asp:textbox><FONT face="新細明體">～<asp:textbox id="EDATE" runat="server" Width="96px"></asp:textbox><STRONG><FONT size="2">(如:2005/01/01)</FONT></STRONG>
															</FONT>
														</TD>
													</TR>
													<TR>
														<TD width="82" bgColor="#e6e6fa" height="27"><FONT face="新細明體" size="2"><STRONG>內容提供單位</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"><asp:dropdownlist id="provider" runat="server"></asp:dropdownlist></FONT></TD>
													</TR>
													<TR>
														<TD width="82" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>內容</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtcontent" runat="server" Width="376px" TextMode="MultiLine" Height="136px"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD width="82" bgColor="lavender" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG><FONT face="新細明體" size="2"><STRONG>執行單位</STRONG></FONT></STRONG></FONT></FONT></TD>
														<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">
																<P><asp:label id="createGroup" runat="server" ></asp:label>
															</FONT>
										</p>
								</td>
							</tr>
							<TR>
								<TD width="82" bgColor="#e6e6fa" height="28"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></FONT></TD>
								<TD bgColor="#ffffff" colSpan="3" height="28"><asp:label id="Creater" runat="server" ></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffffff" colSpan="4">
									<% If (Request("iforno") IS Nothing) Then %>
									<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除">
									<% 
											Else 
											Response.write("<INPUT id='iforno' type='hidden' value='" & Request("iforno") & "'>")
										%>
									<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
									<% End If %>
									</FONT></TD>
							</TR>
							<TR>
								<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
							</TR>
						</table>
					</FORM></FORM></P></td>
			</tr>
		</table>
		</DIV><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
		<P><br>
		</P>
		<p><FONT face="新細明體"></FONT></p>
	</td>
</tr>
</TBODY></TABLE></TD><td bgcolor="#D2E1F0">&nbsp;</td>
</TR><tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

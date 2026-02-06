<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="hotnews.aspx.vb" Inherits="hotnews" aspcompat="true" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<!-- NAME: index.tpl --><tr>
	<td bgcolor="#A6C4E1"></td>
	<td bgcolor="#A6C4E1">
	<td width="930">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
			<tr>
				<td vAlign="middle" align="center">
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">最新消息管理</font></font></td>
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
										<asp:datagrid id="dgCart" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="3"
											ShowFooter="True" DataKeyField="newno" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#E7E7FF"
											BackColor="White" Width="600px" OnEditCommand="dgCart_Edit" OnUpdateCommand="dgCart_Update"
											OnDeleteCommand="dgCart_Delete" OnCancelCommand="dgCart_Cancel" PageSize="3" AllowSorting="True"
											GridLines="Horizontal">
											<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle  BackColor="#F7F7F7"></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="new_subject" HeaderText="消息主題">
													<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="new_content" HeaderText="消息內容">
													<HeaderStyle ForeColor="White" Width="45%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="newno" DataNavigateUrlFormatString="hotnews.aspx?newno={0}"
													HeaderText="編輯" NavigateUrl="編輯">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" HeaderText="刪除" CommandName="Delete">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="#4A3C8C"
												BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<%--
									<P><FONT face="新細明體">
											<asp:button id="btnFirstPage" runat="server" Text="第一頁" CommandName="第一頁" ToolTip="檢視第一頁資料"></asp:button><asp:button id="btnPreviousPage" runat="server" Text="上一頁" CommandName="上一頁" ToolTip="檢視上一頁資料"></asp:button><asp:button id="btnNextPage" runat="server" Text="下一頁" CommandName="下一頁" ToolTip="檢視下一頁資料"></asp:button><asp:button id="btnLastPage" runat="server" Text="最後一頁" CommandName="最後一頁" ToolTip="檢視最後一頁資料"></asp:button><BR>
									</P>
									--%>
										</FONT>
										<p><asp:label id="Message" runat="server"></asp:label>
										<p>
											<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
												border="0">
												<FONT face="新細明體"></FONT>
												<TBODY>
													<TR>
														<TD width="113" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>主題</STRONG></FONT></FONT></P>
														</TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtsubject" runat="server" Width="376px"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD width="113" bgColor="#e6e6fa" height="27"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>上下架日期</STRONG></FONT></FONT></TD>
														<TD bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="SDATE" runat="server" Width="100px" MaxLength="10"></asp:textbox>～<asp:textbox id="EDATE" runat="server" Width="100px" MaxLength="10"></asp:textbox><STRONG>(ex:2005/01/09)</STRONG></FONT></TD>
													</TR>
													<TR>
														<TD width="113" bgColor="#e6e6fa" height="27"><FONT face="新細明體" size="2"><STRONG>內容提供單位</STRONG></FONT></TD>
														<TD bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"><asp:dropdownlist id="provider" runat="server"></asp:dropdownlist></FONT></TD>
													</TR>
													<TR>
														<TD width="113" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>內容</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtcontent" runat="server" Width="376px" Height="136px" TextMode="MultiLine"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD width="113" bgColor="#e6e6fa" height="26"><FONT face="新細明體" size="2"><STRONG>執行單位</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="26"><asp:label id="createGroup" runat="server" ></asp:label></TD>
													</TR>
													<TR>
														<TD width="113" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><asp:label id="Creater" runat="server" ></asp:label></TD>
													</TR>
													<TR>
														<TD align="center" bgColor="#ffffff" colSpan="4">
															<% If (Request("newno") IS Nothing) Then %>
															<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除"></FONT>
															<% 
											Else 
											Response.write("<INPUT id='newno' type='hidden' value='" & Request("newno") & "'>")
										%>
															<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
															<% End If %>
														</TD>
													</TR>
													<TR>
														<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
													</TR>
												</TBODY></TABLE>
									</form>
									</FORM></P></td>
							</tr>
						</table>
					</DIV>
					<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
					</FONT>
					<P align="left"><br>
					</P>
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

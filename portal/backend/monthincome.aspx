<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="monthincome.aspx.vb" Inherits="monthincome" aspcompat="true" %>
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
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">每月營業額</font></font></td>
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
										<asp:datagrid id="dgCart" runat="server" OnCancelCommand="dgCart_Cancel" OnDeleteCommand="dgCart_Delete"
											OnUpdateCommand="dgCart_Update" OnEditCommand="dgCart_Edit" Width="680px" BackColor="White"
											DataKeyField="newno" BorderColor="Navy" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3"
											BorderWidth="1px" BorderStyle="Dotted">
											<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" BorderWidth="2px" ForeColor="#F7F7F7" BorderStyle="Dotted"
												BackColor="#738A9C"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle  BorderWidth="2px" BackColor="#F7F7F7"></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" BorderWidth="2px" ForeColor="#4A3C8C" BorderStyle="Ridge"
												BackColor="#E7E7FF"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px"
												ForeColor="#F7F7F7" VerticalAlign="Middle" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="year" HeaderText="年度">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon01" HeaderText="1月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon02" HeaderText="2月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon03" HeaderText="3月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon04" HeaderText="4月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon05" HeaderText="5月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon06" HeaderText="6月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon07" HeaderText="7月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon08" HeaderText="8月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon09" HeaderText="9月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon10" HeaderText="10月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon11" HeaderText="11月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mon12" HeaderText="12月">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="newno" DataNavigateUrlFormatString="monthincome.aspx?newno={0}"
													HeaderText="編輯" NavigateUrl="編輯">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" HeaderText="刪除" CommandName="Delete">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle BorderWidth="2px"  Font-Names="細明體" BorderColor="Black" HorizontalAlign="Right"
												ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<%--
									<P><FONT face="新細明體">
											<asp:button id="btnFirstPage" runat="server" Text="第一頁" CommandName="第一頁" ToolTip="檢視第一頁資料"></asp:button><asp:button id="btnPreviousPage" runat="server" Text="上一頁" CommandName="上一頁" ToolTip="檢視上一頁資料"></asp:button><asp:button id="btnNextPage" runat="server" Text="下一頁" CommandName="下一頁" ToolTip="檢視下一頁資料"></asp:button><asp:button id="btnLastPage" runat="server" Text="最後一頁" CommandName="最後一頁" ToolTip="檢視最後一頁資料"></asp:button><BR>
									</P>
									--%>
										</FONT>
										<p><asp:label id="Message" runat="server"></asp:label>
										<p>
											<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="500" bgColor="#003399"
												border="0">
												<FONT face="新細明體"></FONT>
												<TBODY>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>年度</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="year" runat="server" Width="50px"></asp:textbox>(民國年:999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>1月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox1" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>2月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox2" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>3月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox3" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>4月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox4" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>5月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox5" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>6月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox6" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>7月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox7" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>8月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox8" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>9月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox9" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>10月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox10" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>11月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox11" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="lavender" height="27">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>12月</STRONG></FONT></FONT></P>
														</TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體" size="2"><asp:textbox id="Textbox12" runat="server" Width="150px"></asp:textbox>(Ex:999,999,999)</FONT></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="#e6e6fa" height="26"><FONT face="新細明體" size="2"><STRONG>執行單位</STRONG></FONT></TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="26"><asp:label id="createGroup" runat="server" ></asp:label></TD>
													</TR>
													<TR>
														<TD align="right" width="185" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
														<TD width="315" bgColor="#ffffff" colSpan="3" height="28"><asp:label id="Creater" runat="server" ></asp:label></TD>
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
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

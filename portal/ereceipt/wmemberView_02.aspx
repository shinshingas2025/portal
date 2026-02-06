<%@ Register TagPrefix="uc1" TagName="footer" Src="../backend/_footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="wmemberView_02.aspx.vb" Inherits="wmemberView_02" codePage="65001" %>
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=utf-8">
	<body>
		<form id="Form1" method="post" runat="server">
			<table>
				<!-- NAME: index.tpl -->
				<TBODY>
  <tr>
						<td bgColor="#a6c4e1"><FONT face="新細明體"></FONT></td>
						<td width="930" bgColor="#6699cc"><FONT face="新細明體"></FONT></td>
						<td bgColor="#a6c4e1"></td>
					</tr>
  <tr>
						<td bgColor="#d2e1f0"></td>
						<td width="930">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
								<TBODY>
									<tr>
										<td vAlign="middle" align="left" height="45">
											<table cellSpacing="0" cellPadding="3" width="100%" border="0">
												<tr>
													<td width="94">&nbsp;</td>
													<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">會員修改資料記錄查詢</font></font></td>
													<td width="65%">&nbsp;</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td vAlign="top" align="center" width="748" colSpan="1"><table id="Table4" height="250" cellSpacing="4" cellPadding="4" width="95%" align="center"
												border="1">
												<TBODY>
													<tr>
														<td vAlign="top" align="center">
															<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
															</FONT>
															<p><asp:label id="Message" runat="server"></asp:label></p>
															<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
																<TBODY>
																	<TR>
																		<TD align="center" colSpan="4"><FONT face="新細明體" size="3"><STRONG>會員資料</STRONG></FONT></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label4" runat="server" Width="96px"><FONT size="2"><STRONG>最後異動日期</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" height="24"><asp:label id="lb_upd_datetime" runat="server"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label1" runat="server" Width="96px"><FONT size="2"><STRONG>註冊日期</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" height="24"><asp:label id="lb_add_datetime" runat="server"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label2" runat="server" Width="96px"><FONT size="2"><STRONG>會員狀態</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" height="24"><asp:label id="OPENFLAG" runat="server" Width="200px"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label5" runat="server" Width="96px"><FONT size="2"><STRONG>身份別</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" height="24"><asp:label id="ORGFLAG" runat="server" Width="96px"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label3" runat="server" Width="96px"><FONT size="2"><STRONG>會員狀態</br>(統一編號)</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_id" runat="server"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label7" runat="server" Width="96px"><FONT size="2"><STRONG>申請人姓名</br>(承辦人姓名)</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_user_name" runat="server"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label12" runat="server" Width="96px"><FONT size="2"><STRONG>公司名稱</br>(機關名稱)</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_user_o_name" runat="server"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label6" runat="server" Width="96px"><FONT size="2"><STRONG>連絡電話(O)</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="230" colSpan="1" height="24"><asp:label id="lb_tel_o" runat="server" Width="150px"></asp:label><asp:label id="lb_tel_o2" runat="server"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label9" runat="server" Width="96px"><FONT size="2"><STRONG>連絡電話(H)</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_tel_h" runat="server"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label8" runat="server" Width="96px"><FONT size="2"><STRONG>行動電話</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_mobile" runat="server"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label10" runat="server" Width="96px"><FONT size="2"><STRONG>電子信箱</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_email" runat="server"></asp:label></TD>
																		<TD width="4" height="24"><FONT face="新細明體"><asp:label id="Label11" runat="server" Width="96px"><FONT size="2"><STRONG>是否列印紙本</STRONG></FONT></asp:label></FONT></TD>
																		<TD width="211" colSpan="1" height="24"><asp:label id="lb_paper" runat="server"></asp:label></TD>
																	</TR>
																</TBODY></TABLE>
														</td>
													</tr>
												</TBODY></table>
											<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
											</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
									<tr>
									<TR>
										<TD align="center" colSpan="4"><FONT face="新細明體" size="3"><STRONG>歷史異動資料</STRONG></FONT></TD>
									</TR>
									<TR>
										<td vAlign="top" align="center">
											<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="900px" AllowSorting="True" AutoGenerateColumns="False"
													AllowPaging="True" DataKeyField="wm_no" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
													BorderColor="White" BackColor="White" GridLines="None" CellSpacing="1">
													<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
													<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
													<AlternatingItemStyle ></AlternatingItemStyle>
													<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
													<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="wm_no" ReadOnly="True"></asp:BoundColumn>
														<asp:TemplateColumn Visible="False" HeaderText="序號">
															<ItemTemplate>
																<FONT face="新細明體">
																	<asp:Label id=no runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_no") %>'>
																	</asp:Label></FONT>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="啟用別">
															<ItemTemplate>
																<FONT face="新細明體">
																	<asp:Label id="FLAG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_open_flag") %>'>
																	</asp:Label></FONT>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="">
															<ItemTemplate>
																<FONT face="新細明體">
																	<asp:Textbox id="wmno" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_no") %>'>
																	</asp:Textbox></FONT>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="add_datetime" ReadOnly="True" HeaderText="異動日期">
															<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="add_user" HeaderText="異動者">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
															<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UPDTYPE" HeaderText="異動別">
															<HeaderStyle Width="8%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
															<HeaderStyle Width="8%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="wm_tel_oo" ReadOnly="True" HeaderText="連絡電話(O)">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="wm_tel_h" ReadOnly="True" HeaderText="連絡電話(H)">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="wm_email" ReadOnly="True" HeaderText="電子信箱">
															<HeaderStyle Width="8%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="OPENFLAG" ReadOnly="True" HeaderText="會員狀態">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="mhis_memo" ReadOnly="True" HeaderText="處理說明">
															<HeaderStyle Width="25%"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></DIV>
									<tr>
										<td colSpan="4">
											<P align="center"><FONT face="新細明體"><asp:button id="btnreturn" runat="server" Text="返回"></asp:button></FONT></P>
										</td>
									</tr>
							</FONT></td>
					</tr></td></tr></TBODY></table>
			</td> 
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></tr></TBODY></table></form>
	</body>
</HTML>

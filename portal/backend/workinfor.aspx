<%@ Page Language="vb" AutoEventWireup="false" Codebehind="workinfor.aspx.vb" Inherits="workinfor" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<!-- NAME: index.tpl --><tr>
	<td bgcolor="#A6C4E1"></td>
	<td bgcolor="#6699CC" width="930"></td>
	<td bgcolor="#A6C4E1"></td>
</tr>
<tr>
	<td bgcolor="#D2E1F0"></td>
	<td width="930">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
			<TBODY>
				<tr>
					<td vAlign="middle" align="center">
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr>
								<td width="94">&nbsp;</td>
								<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">施工通告管理</font></font></td>
								<td width="65%">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" align="center" width="748">
						<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
							<TBODY>
								<tr>
									<td align="center">
										<form id="Form1" method="post" runat="server">
											<DIV align="left">
												<asp:datagrid id="dgCart" runat="server" AllowSorting="True" PageSize="3" OnDeleteCommand="dgCart_Delete"
													OnUpdateCommand="dgCart_Update" Width="600px" AutoGenerateColumns="False" AllowPaging="True"
													DataKeyField="workno" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
													BorderColor="White" BackColor="White" GridLines="None" CellSpacing="1">
													<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
													<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
													<EditItemStyle  Width="600px"></EditItemStyle>
													<AlternatingItemStyle ></AlternatingItemStyle>
													<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
													<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="施工項目">
															<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
															<ItemTemplate>
																<%#Container.DataItem("wkgrpname")%>
																<FONT face="新細明體"></FONT>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="worksubject" HeaderText="工程名稱">
															<HeaderStyle ForeColor="White" Width="40%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="edate" HeaderText="下架日期">
															<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="workno" DataNavigateUrlFormatString="workinfor.aspx?workno={0}"
															DataTextField="workno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
															<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
														</asp:HyperLinkColumn>
														<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
													</Columns>
													<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></DIV>
											<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
											</FONT>
											<P><asp:label id="Message" runat="server"></asp:label></P>
											<P align="left">
												<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
													width="600" bgColor="#003399" border="0">
													<FONT face="新細明體"></FONT>
													<TBODY>
														<TR>
															<TD width="149" bgColor="lavender" colSpan="1" height="19" rowSpan="1"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>施工項目</STRONG></FONT></FONT></TD>
															<TD bgColor="#ffffff" colSpan="3" height="19"><asp:label id="txtdbworkgrp" runat="server"></asp:label><asp:dropdownlist id="txtworkgrp" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="27">
																<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG><FONT color="#000000" size="2"><STRONG>工程名稱</STRONG></FONT></STRONG></FONT></FONT></P>
															</TD>
															<TD bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtsubject" runat="server" Width="376px"></asp:textbox></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="#e6e6fa" height="27"><STRONG><FONT size="2">工程地點</FONT></STRONG></TD>
															<TD bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體">
																	<asp:textbox id="workaddress" runat="server" Width="376px" TextMode="MultiLine"></asp:textbox></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="26"><FONT color="#000000" size="2"><STRONG>工程起始日期時間</STRONG></FONT></TD>
															<TD bgColor="#ffffff" colSpan="3" height="26"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtwkdate" runat="server" Width="80px" Height="22px" MaxLength="10"></asp:textbox><FONT size="2"><STRONG>(如:2005/01/01)</FONT>
																	<asp:textbox id="txtwktime" runat="server" Width="80px" Height="22px" MaxLength="5"></asp:textbox><FONT size="2"><STRONG>(如:18:30)</FONT></STRONG></STRONG></FONT></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="26"><FONT color="#000000" size="2"><STRONG>工程結束日期時間</STRONG></FONT></TD>
															<TD bgColor="#ffffff" colSpan="3" height="26"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtwkdateend" runat="server" Width="80px" Height="22px" MaxLength="10"></asp:textbox><FONT size="2"><STRONG>(如:2005/01/01)</FONT>
																	<asp:textbox id="txtwktimeend" runat="server" Width="80px" Height="22px" MaxLength="5"></asp:textbox><FONT size="2"><STRONG>(如:18:30)</FONT></STRONG></STRONG></FONT></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>承裝商</STRONG></FONT></TD>
															<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtmember" runat="server" Width="376px" Height="22px"></asp:textbox></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>現場負責人員</STRONG></FONT></TD>
															<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtcontroler" runat="server" Width="376px" Height="22px"></asp:textbox></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="#e6e6fa" height="28"><STRONG><FONT size="2">聯絡電話</FONT></STRONG></TD>
															<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
																	<asp:textbox id="tel" runat="server" Width="164px" Height="22px"></asp:textbox></FONT></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="28">
																<P><FONT color="#000000" size="2"><STRONG>檢驗員</STRONG></FONT></P>
															</TD>
															<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><asp:textbox id="checker" runat="server" Width="376px" Height="22px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="149" bgColor="lavender" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>上下架日期</STRONG></FONT></FONT></TD>
															<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">
																	<P><asp:textbox id="SDATE" runat="server" Width="80px" MaxLength="10"></asp:textbox>～
																		<asp:textbox id="EDATE" runat="server" Width="80px" MaxLength="10"></asp:textbox>
																	(如:2005/01/01)</FONT>
											</P>
									</td>
								</tr>
								<TR>
									<TD width="149" bgColor="#e6e6fa" height="28"><STRONG><FONT size="2">內容提供單位</FONT></STRONG></TD>
									<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
											<asp:dropdownlist id="provider" runat="server"></asp:dropdownlist></FONT></TD>
								</TR>
								<TR>
									<TD width="149" bgColor="#e6e6fa" height="28"><STRONG><FONT size="2">執行單位</FONT></STRONG></TD>
									<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
											<asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD width="149" bgColor="#e6e6fa" height="28"><STRONG><FONT size="2">執行人員</FONT></STRONG></TD>
									<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
											<asp:label id="Creater" runat="server" ></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD width="149" bgColor="#e6e6fa" height="28"><FONT face="新細明體"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG>最後執行單位</STRONG></FONT></FONT><FONT face="新細明體"><FONT face="新細明體"></FONT></FONT></FONT></TD>
									<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
											<asp:label id="modifierGroup" runat="server" ></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD width="149" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>最後執行人員</STRONG></FONT></TD>
									<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT face="新細明體">
												<asp:label id="Modifier" runat="server" ></asp:label></FONT></FONT></TD>
								</TR>
								<TR>
									<TD align="center" bgColor="#ffffff" colSpan="4">
										<% If (Request("workno") IS Nothing) Then %>
										<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除">
										<% 
											Else 
											Response.write("<INPUT id='workno' type='hidden' value='" & Request("workno") & "'>")
										%>
										<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
										<% End If %>
										</FONT></TD>
								</TR>
								<TR>
									<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
								</TR>
							</TBODY></table>
						</P></FORM></FORM></td>
				</tr>
			</TBODY></table>
		<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
		</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
		<P><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
		</P>
		<p><FONT face="新細明體"></FONT></p>
	</td>
</tr>
</TBODY></TABLE></TD><td bgcolor="#D2E1F0">&nbsp;</td>
</TR><tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></TR></TBODY>
<P></P>
</FORM></TR></TBODY></TABLE></TR></TBODY></TABLE>

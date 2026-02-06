<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="faq_item.aspx.vb" Inherits="faq_item" %>
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
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">問題資料管理</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
           <form id="Form1" method="post" runat="server">
            <tr>
				<td vAlign="middle" align="center">
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">查詢群組</font></font></td>
							<td width="65%">
                                <asp:dropdownlist id="selfaqgrp"  runat="server" autopostback  ></asp:dropdownlist>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center" width="748">
					<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
						<tr>
							<td align="center">
							
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" CellSpacing="1" BorderStyle="Ridge" BorderWidth="2px"
											CellPadding="3" ShowFooter="True" DataKeyField="faqno" AllowPaging="True" AutoGenerateColumns="False"
											BorderColor="White" BackColor="White" Width="600px" OnDeleteCommand="dgCart_Delete" AllowSorting="True"
											GridLines="None">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="群組">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
													<ItemTemplate>
														<%#Container.DataItem("faqgrpname")%>
														<FONT face="新細明體"></FONT>
													</ItemTemplate>
												</asp:TemplateColumn>
                                                <asp:BoundColumn DataField="faqsort" HeaderText="顯示順序">
													<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="faqquestion" HeaderText="問題">
													<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="faqanswer" HeaderText="回答">
													<HeaderStyle ForeColor="White" Width="40%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="faq_item.aspx?faqno={0}"
													DataTextField="faqno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
													<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
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
									<P><asp:label id="Message" runat="server"></asp:label></P>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
											border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="80" bgColor="#e6e6fa" height="27"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>群組</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><asp:label id="txtdbfaqgrp" runat="server"></asp:label><asp:dropdownlist id="txtfaqgrp" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="#e6e6fa" height="27"><FONT face="新細明體" size="2"><STRONG>內容提供單位</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="27">
														<asp:dropdownlist id="provider" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="lavender" height="27">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>問題</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtquestion" runat="server" Width="376px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>回答</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtanswer" runat="server" Width="376px" Height="136px" TextMode="MultiLine"></asp:textbox></FONT></TD>
												</TR>
                                                <TR>
													<TD width="80" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>排序</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體">
                                                        <asp:textbox id="txtfaqsort" runat="server" ></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行單位</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:label id="createGroup" runat="server" ></asp:label></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28">
														<asp:label id="Creater" runat="server" ></asp:label></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>更新日期</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
															<asp:label id="revisetime" runat="server" ></asp:label></FONT></TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<% If (Request("faqno") IS Nothing) Then %>
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
														<% 
											Else 
											Response.write("<INPUT id='faqno' type='hidden' value='" & Request("faqno") & "'>")
										%>
														<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
														<% End If %>
														<INPUT type="reset" value="清除"></FONT></TD>
												</TR>
												<TR>
													<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
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
	<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

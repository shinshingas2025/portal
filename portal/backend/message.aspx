<%@ Page Language="vb" AutoEventWireup="false" Codebehind="message.aspx.vb" Inherits="message" aspcompat="true" %>
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
			<tr>
				<td vAlign="middle" align="center">
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">跑馬燈管理</font></font></td>
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
										<asp:datagrid id="dgCart" runat="server" CellSpacing="1" GridLines="None" BackColor="White" BorderColor="White"
											CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="msgno"
											AllowPaging="True" AutoGenerateColumns="False" Width="600px" OnEditCommand="dgCart_Edit" OnUpdateCommand="dgCart_Update"
											OnDeleteCommand="dgCart_Delete" OnCancelCommand="dgCart_Cancel" PageSize="3" AllowSorting="True">
											
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="msgsubject" HeaderText="訊息內容">
													<HeaderStyle ForeColor="White" Width="70%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EDATE" HeaderText="下架日期">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="msgno" DataNavigateUrlFormatString="message.aspx?msgno={0}" DataTextField="msgno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
										<FONT face="新細明體">
											<BR>
									</P></FONT>
									<p><asp:label id="Msg" runat="server"></asp:label>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
											width="600" bgColor="#003399" border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="82" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">訊息<FONT color="#000000">內容<BR>
																		(重大資訊)</FONT></FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtsubject" runat="server" Width="444px" Height="102px" TextMode="MultiLine"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="82" bgColor="lavender" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>上下架日期</STRONG></FONT></FONT></TD>
													<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">
															<P>
																<asp:textbox id="SDATE" runat="server" Width="88px"></asp:textbox>～<asp:textbox id="EDATE" runat="server" Width="90px"></asp:textbox>
															(如:2005/01/01)</FONT>
									</P>
							</td>
						</tr>
						<TR>
							<TD width="82" bgColor="#e6e6fa" height="28"><FONT size="2"><STRONG>內容提供單位</STRONG></FONT></TD>
							<TD bgColor="#ffffff" colSpan="3" height="28">
								<asp:dropdownlist id="provider" runat="server"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD width="82" bgColor="#e6e6fa" height="28"><FONT size="2"><STRONG>執行單位</STRONG></FONT></TD>
							<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">
									<asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD width="82" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
							<TD bgColor="#ffffff" colSpan="3" height="28">
								<asp:label id="Creater" runat="server" ></asp:label></TD>
						</TR>
						<TR>
							<TD align="center" bgColor="#ffffff" colSpan="4">
								<% If (Request("msgno") IS Nothing) Then %>
								<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除"></FONT>
								<% 
								Else 
								Response.write("<INPUT id='msgno' type='hidden' value='" & Request("msgno") & "'>")
							%>
								<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
								<% End If %>
							</TD>
						</TR>
						<TR>
							<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
						</TR>
					</table></P></FORM></FORM></td>
			</tr>
		</table>
		<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
		</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
		<P><br>
		</P>
		<p><FONT face="新細明體"></FONT></p>
	</td>
</tr></TBODY></TABLE></TD><td bgcolor="#D2E1F0">&nbsp;</td> </TR><tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

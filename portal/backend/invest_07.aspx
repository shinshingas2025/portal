<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="invest_07.aspx.vb" Inherits="invest_07" %>
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
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <FONT color="#003366"><font size="2">
											公司治理管理<BR>
										</font></FONT></font>
							</td>
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
								<form id="Form1" method="post" encType="multipart/form-data" runat="server">
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" GridLines="None" AllowSorting="True" PageSize="3" OnDeleteCommand="dgCart_Delete"
											Width="600px" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True"
											DataKeyField="invno" ShowFooter="True" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
											CellSpacing="1">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="invname" HeaderText="公司治理主旨">
													<HeaderStyle ForeColor="White" Width="50%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="檔案" DataNavigateUrlField="invfile" DataNavigateUrlFormatString="../UpFile/{0}"
													DataTextField="invfile" HeaderText="附表" NavigateUrl="檔案">
													<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="invno" DataNavigateUrlFormatString="invest_07.aspx?invno={0}"
													DataTextField="invno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
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
									<P><asp:label id="Message" runat="server"></asp:label></P>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
											border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="109" bgColor="lavender" height="28">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>公司治理主旨</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtname" runat="server" Width="376px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="109" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>附表上傳</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:label id="txtdbfile" runat="server"></asp:label><INPUT id="txtfile" type="file" size="43" name="txtfile" runat="server">
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<% If (Request("invno") IS Nothing) Then %>
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
														<% 
											Else 
											Response.write("<INPUT id='invno' type='hidden' value='" & Request("invno") & "'>")
										%>
														<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
														<% End If %>
														<INPUT type="reset" value="清除"></FONT></TD>
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
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></ASP:FILEUPLOAD>

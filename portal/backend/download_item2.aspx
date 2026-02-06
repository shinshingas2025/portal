<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="download_item2.aspx.vb" Inherits="download_item2" %>
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
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <FONT color="#003366">投資人訊息檔案 <font size="2">
											管理</font></FONT></font></td>
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
								<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
									<DIV align="left">
										<asp:datagrid id="dgCart" runat="server" CellSpacing="1" BorderStyle="Ridge" BorderWidth="2px"
											CellPadding="3" ShowFooter="True" DataKeyField="dwno" AllowPaging="True" AutoGenerateColumns="False"
											BorderColor="White" BackColor="White" Width="600px" OnDeleteCommand="dgCart_Delete" AllowSorting="True"
											GridLines="None" PageSize="20">
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="群組">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
													<ItemTemplate>
														<%#Container.DataItem("dwgrpname")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="dwname" HeaderText="檔案名稱">
													<HeaderStyle ForeColor="White" Width="40%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="檔案" DataNavigateUrlField="dwfile" DataNavigateUrlFormatString="../../UpFile2/{0}"
													DataTextField="dwfile" HeaderText="檔案" NavigateUrl="檔案">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="dwno" DataNavigateUrlFormatString="download_item2.aspx?dwno={0}"
													DataTextField="dwno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
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
													<TD width="80" bgColor="#e6e6fa" height="53"><FONT face="新細明體">
															<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>群組</STRONG></FONT></FONT></P>
														</FONT>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="53"><asp:dropdownlist id="txtdwgrp" runat="server"></asp:dropdownlist><asp:label id="txtdbdwgrp" runat="server" Width="366px"></asp:label></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="lavender" height="41">
														<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>檔案名稱</STRONG></FONT></FONT></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="41"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtname" runat="server" Width="376px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="80" bgColor="lavender" height="55"><FONT color="#000000" size="2"><STRONG>檔案上傳</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="55"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體">
															<asp:label id="txtdbfile" runat="server" Width="368px"></asp:label><INPUT type="file" id="txtfile" name="txtfile" runat="server" size="43">
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<% If (Request("dwno") IS Nothing) Then %>
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
														<% 
											Else 
											Response.write("<INPUT id='dwno' type='hidden' value='" & Request("dwno") & "'>")
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
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></ASP:FILEUPLOAD>

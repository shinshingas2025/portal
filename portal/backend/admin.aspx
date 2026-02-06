<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="admin.aspx.vb" Inherits="admin" %>
<ASPNETCOMMERCE:HEADER id="Header1" runat="server"></ASPNETCOMMERCE:HEADER>
<!-- NAME: index.tpl --><tr>
	<td bgcolor="#A6C4E1">&nbsp;</td>
	<td bgcolor="#6699CC" width="930"><IMG src="images/title.gif"></td>
	<td bgcolor="#A6C4E1">&nbsp;</td>
</tr>
<tr>
	<td bgcolor="#D2E1F0">&nbsp;</td>
	<td width="930">
		<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
			<tr>
				<td vAlign="top" bgColor="#a6c4e1" height="50">
					<table id="Table2" cellSpacing="4" cellPadding="2" width="100%" border="0">
						<tr>
							<td><IMG height="18" src="images/title2.gif" width="140" border="0"></td>
						</tr>
						<tr>
							<td align="center"><font color="#666666"><%=Session("LoginID")%></font></td>
						</tr>
					</table>
				</td>
				<td vAlign="middle" align="center">&nbsp;<font color="#ff0000"></font></td>
			</tr>
			<tr>
				<td vAlign="top" width="152" bgColor="#6699cc">
					<table id="Table3" cellSpacing="4" cellPadding="2" width="100%" border="0">
						<tr>
							<td><IMG height="18" src="images/title1.gif" width="140"></td>
						</tr>
						<tr>
							<td><uc1:newmenu id="_NewMenu1" runat="server"></uc1:newmenu></td>
						</tr>
					</table>
					<p>&nbsp;</p>
				</td>
				<td vAlign="top" align="center" width="748">
					<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
						<tr>
							<td align="center">
								<form id="Form1" method="post" runat="server">
									<asp:datagrid id="dgCart" runat="server" GridLines="None" AllowSorting="True" PageSize="5" OnCancelCommand="dgCart_Cancel"
										OnDeleteCommand="dgCart_Delete" OnUpdateCommand="dgCart_Update" OnEditCommand="dgCart_Edit"
										Width="600px" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True"
										DataKeyField="userno" ShowFooter="True" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
										CellSpacing="1">
										<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
										<SelectedItemStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
										<EditItemStyle Font-Size="X-Small" Width="600px"></EditItemStyle>
										<AlternatingItemStyle Font-Size="X-Small"></AlternatingItemStyle>
										<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
										<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="類別">
												<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												<ItemTemplate>
													<%#Container.DataItem("usergrpname")%>
													<FONT face="新細明體"></FONT>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="userid" ReadOnly="True" HeaderText="帳號">
												<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="userpw" HeaderText="密碼">
												<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="name" HeaderText="姓名">
												<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="email" HeaderText="電子郵件">
												<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" CancelText="取消" EditText="編輯">
												<HeaderStyle Width="40px"></HeaderStyle>
											</asp:EditCommandColumn>
											<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete">
												<HeaderStyle Width="40px"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Font-Size="X-Small" Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<P><FONT face="新細明體"> 
										<!-- <asp:button id="btnFirstPage" runat="server" Text="第一頁" CommandName="第一頁" ToolTip="檢視第一頁資料"></asp:button><asp:button id="btnPreviousPage" runat="server" Text="上一頁" CommandName="上一頁" ToolTip="檢視上一頁資料"></asp:button><asp:button id="btnNextPage" runat="server" Text="下一頁" CommandName="下一頁" ToolTip="檢視下一頁資料"></asp:button><asp:button id="btnLastPage" runat="server" Text="最後一頁" CommandName="最後一頁" ToolTip="檢視最後一頁資料"></asp:button><BR> -->
									</P>
									</FONT><p><asp:Label id="Message" runat="server"></asp:Label>
									<p>
										<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
											width="600" bgColor="#003399" border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="91" bgColor="lavender" height="27"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>群組</STRONG></FONT></FONT></TD>
													<TD width="185" bgColor="#ffffff" height="27"><FONT face="新細明體"><asp:dropdownlist id="txtusergrp" runat="server"></asp:dropdownlist></ASP:LISTITEM></FONT></TD>
													<TD width="84" bgColor="lavender" height="27"><FONT face="新細明體"></FONT></TD>
													<TD bgColor="#ffffff" height="27"><FONT face="新細明體"></FONT></TD>
												</TR>
												<TR>
													<TD width="91" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>帳號</STRONG></FONT></TD>
													<TD width="185" bgColor="#ffffff" height="28"><asp:textbox id="txtuserid" runat="server" Width="100px"></asp:textbox></TD>
													<TD width="84" bgColor="lavender" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>密碼</STRONG></FONT></FONT></TD>
													<TD bgColor="#ffffff" height="28"><FONT face="新細明體"><asp:textbox id="txtuserpw" runat="server" Width="100px" TextMode="Password"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="91" bgColor="lavender" height="37"><STRONG><FONT color="#000000" size="2">姓名</FONT></STRONG></TD>
													<TD width="185" bgColor="#ffffff" height="37"><FONT face="新細明體"><asp:textbox id="txtname" runat="server" Width="100px"></asp:textbox></FONT></TD>
													<TD width="84" bgColor="lavender" height="37"><STRONG><FONT color="#000000" size="2">Email</FONT></STRONG></TD>
													<TD bgColor="#ffffff" height="37"><FONT face="新細明體"><asp:textbox id="txtemail" runat="server" Width="167px"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4"><asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除"></FONT></TD>
												</TR>
												<TR>
													<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label></TD>
												</TR>
											</TBODY></TABLE>
								</form>
								</FORM></P></td>
						</tr>
					</table>
					<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
					</p>
					<p><FONT face="新細明體"></FONT></p>
				</td>
			</tr>
			<tr>
				<td bgColor="#d2e1f0" colSpan="2" height="2"><IMG height="1" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
		</table>
	</td>
	<td bgcolor="#D2E1F0">&nbsp;</td>
</tr>
<tr bgcolor="#000000">
	<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

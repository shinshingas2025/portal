<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="../backend/_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="startmember_04.aspx.vb" Inherits="startmember_04" aspcompat="true" codePage="65001" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../backend/_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="../backend/_Header.ascx" %>
<SCRIPT LANGUAGE="JavaScript">
function checkNumberOfWords(thisWords, wordNum) {
	alength = 0;
	for(var i=0;i<thisWords.length;i++) {
		if(thisWords.charAt(i).charCodeAt()<=255) {
	    	alength++;
	  	} else {
	    	alength+=2;
	    }
	}
	
	if (alength > Number(wordNum)) {
		alert("字數過多!\n請控制在中文100字內或英文200字以內");
		document.Form1.mhismemo.focus();
		return false;
	}
	return true;
}
</SCRIPT>
<META http-equiv="Content-Type" content="text/html; charset=utf-8">
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
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">會員基本資料管理</font></font></td>
							<td width="65%">&nbsp;</td>
						</tr>
					</table>
					<P align="left"><FONT face="新細明體">您勾選要『</FONT><asp:label id="label1" runat="server"></asp:label><FONT face="新細明體">』的資料如下：</FONT><asp:label id="Label2" runat="server"></asp:label>
					</P>
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
											ShowFooter="True" DataKeyField="wm_no" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#E7E7FF"
											BackColor="White" Width="800px" PageSize="3" AllowSorting="True" GridLines="Horizontal">
											<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle  BackColor="#F7F7F7"></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn Visible="False" HeaderText="編號">
													<ItemTemplate>
														<FONT face="新細明體">
															<asp:Label id=email runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_email") %>'>
															</asp:Label></FONT>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="編號">
													<ItemTemplate>
														<FONT face="新細明體">
															<asp:Label id="no" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_no") %>'>
															</asp:Label></FONT>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="ORGFLAG" ReadOnly="True" HeaderText="身份別">
													<HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
													<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_tel_o" ReadOnly="True" HeaderText="連絡電話(O)">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_tel_h" ReadOnly="True" HeaderText="連絡電話(H)">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="wm_email" ReadOnly="True" HeaderText="電子信箱">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="add_datetime" ReadOnly="True" HeaderText="註冊日期">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OPENFLAG" ReadOnly="True" HeaderText="會員狀態">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
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
										<p><asp:label id="Message" align="center" runat="server" Width="64px"></asp:label>
										<p>
											<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
												border="0">
												<FONT face="新細明體"></FONT>
												<TBODY>
													<TR>
														<TD width="113" bgColor="white" height="28"><FONT color="#000000" size="2"><STRONG>處理說明</STRONG></FONT></TD>
														<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="mhismemo" runat="server" Width="376px" Height="136px" TextMode="MultiLine" onBlur="return checkNumberOfWords(this.value, 200)"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD align="center" bgColor="#ffffff" colSpan="4"><asp:button id="btnUpdate" runat="server" Text="確定送出"></asp:button></FONT><asp:button id="btnreturn" runat="server" Text="返回"></asp:button></TD>
													</TR>
													<TR>
														<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
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
<!-- END: index.tpl -->

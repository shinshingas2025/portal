<%@ Page Language="vb" AutoEventWireup="false" Codebehind="receipt_ad.aspx.vb" Inherits="receipt_ad" aspcompat="true" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<SCRIPT LANGUAGE="JavaScript">
function checkNumberOfWords(thisWords, wordNum, rowlin) {
	alength = 0;
	for(var i=0;i<thisWords.length;i++) {
		if(thisWords.charAt(i).charCodeAt()<=255) {
	    	alength++;
	  	} else {
	    	alength+=2;
	    }
	}
	
	if (alength > Number(wordNum)) {
		alert("字數過多!\n請控制在中文45字內或英文90字以內");
		if (rowlin == 1){
			document.Form1.txtad_content1.focus();
		}else if (rowlin == 2){
			document.Form1.txtad_content2.focus();
		}else if (rowlin == 3){
			document.Form1.txtad_content3.focus();
		}
		return false;
	}
	return true;
}
</SCRIPT>
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
					<table cellSpacing="0" cellPadding="3" width="100%" border="0" id="Table2">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">收據廣告文字管理</font></font></td>
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
									<DIV align="left"><asp:datagrid id="dgCart" runat="server" CellSpacing="1" GridLines="None" BackColor="White" BorderColor="White"
											CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="adno" AllowPaging="True"
											AutoGenerateColumns="False" Width="600px" OnEditCommand="dgCart_Edit" OnDeleteCommand="dgCart_Delete" OnCancelCommand="dgCart_Cancel"
											PageSize="3" AllowSorting="True">
											<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
											<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
											<EditItemStyle  Width="600px"></EditItemStyle>
											<AlternatingItemStyle ></AlternatingItemStyle>
											<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
											<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="ad_content1" HeaderText="訊息內容1">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ad_content2" HeaderText="訊息內容2">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ad_content3" HeaderText="訊息內容3">
													<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ad_start_date" HeaderText="上架日期">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ad_end_date" HeaderText="下架日期">
													<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="adno" DataNavigateUrlFormatString="receipt_ad.aspx?adno={0}"
													DataTextField="adno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
													<HeaderStyle ForeColor="White"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
											</Columns>
											<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<FONT face="新細明體">
										<BR>
										<P></P>
									</FONT>
									<p><asp:label id="Msg" runat="server"></asp:label>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
											width="600" bgColor="#003399" border="0">
											<FONT face="新細明體"></FONT>
											<TBODY>
												<TR>
													<TD width="82" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">廣告行一</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtad_content1" runat="server" Width="450px" MaxLength="90" onBlur="return checkNumberOfWords(this.value, 90, 1)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="82" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">廣告行二</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtad_content2" runat="server" Width="450px" MaxLength="90" onBlur="return checkNumberOfWords(this.value, 90, 2)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="82" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">廣告行三</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtad_content3" runat="server" Width="450px" MaxLength="90" onBlur="return checkNumberOfWords(this.value, 90, 3)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="82" bgColor="lavender" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>上下架日期</STRONG></FONT></FONT></TD>
													<TD bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">
															<P><asp:textbox id="txtad_start_date" runat="server" Width="88px" MaxLength="7"></asp:textbox>～<asp:textbox id="txtad_end_date" runat="server" Width="90px" MaxLength="7"></asp:textbox>
															(Ex:990809)</FONT>
									</P>
							</td>
						</tr>
						<TR>
							<TD align="center" bgColor="#ffffff" colSpan="4">
								<% If (Request("adno") IS Nothing) Then %>
								<asp:button id="btnAdd" runat="server" Text="新增"></asp:button><INPUT type="reset" value="清除"></FONT>
								<% 
								Else 
								Response.write("<INPUT id='adno' type='hidden' value='" & Request("adno") & "'>")
							%>
								<asp:button id="btnupdate" runat="server" Text="修改"></asp:button>
								<asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
								<asp:button id="btnReturn" runat="server" Text="返回"></asp:button>
								<% End If %>
							</TD>
						</TR>
						<TR>
							<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
						</TR>
					</table>
					</P></FORM></FORM></td>
			</tr>
		</table>
	</td>
</tr>
</TBODY></TABLE></TD><td bgcolor="#D2E1F0">&nbsp;</td>
</TR><tr bgcolor="#000000">
	<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
</tr>
<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>

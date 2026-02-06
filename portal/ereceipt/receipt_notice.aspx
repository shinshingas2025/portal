<%@ Page Language="vb" AutoEventWireup="false" Codebehind="receipt_notice.aspx.vb" Inherits="receipt_notice" aspcompat="true" %>
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
		alert("字數過多!\n請控制在中文18字內或英文36字以內");
		if (rowlin == 1){
			document.Form1.txtnotice_content1.focus();
		}else if (rowlin == 2){
			document.Form1.txtnotice_content2.focus();
		}else if (rowlin == 3){
			document.Form1.txtnotice_content3.focus();
		}else if (rowlin == 4){
			document.Form1.txtnotice_content4.focus();
		}else if (rowlin == 5){
			document.Form1.txtnotice_content5.focus();
		}else if (rowlin == 6){
			document.Form1.txtnotice_content6.focus();
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
					<table cellSpacing="0" cellPadding="3" width="100%" border="0">
						<tr>
							<td width="94">&nbsp;</td>
							<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">收據注意事項電話內容管理</font></font></td>
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
									<DIV align="left"><FONT face="新細明體"></FONT>&nbsp;</DIV>
									<P align="left">
										<TABLE id="Table5" height="216" cellSpacing="1" borderColorDark="black" cellPadding="1"
											width="600" bgColor="#003399" border="0">
											<TBODY>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行一</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content1" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 1)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行二</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content2" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 2)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行三</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content3" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 3)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行四</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content4" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 4)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行五</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content5" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 5)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD width="84" bgColor="lavender" height="28">
														<P align="left"><STRONG><FONT size="2">行六</FONT></STRONG></P>
													</TD>
													<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtnotice_content6" runat="server" Width="450px" MaxLength="36" onBlur ="return checkNumberOfWords(this.value, 36, 6)"></asp:textbox></FONT></TD>
												</TR>
												<TR>
													<TD align="center" bgColor="#ffffff" colSpan="4">
														<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
														<asp:button id="btnupdate" runat="server" Text="確定"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
												</TR>
											</TBODY></TABLE>
									</P>
								</form>
								</FORM></td>
						</tr>
					</table>
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

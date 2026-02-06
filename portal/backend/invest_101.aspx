<%@ Page Language="vb" AutoEventWireup="false" Codebehind="invest_101.aspx.vb" Inherits="invest_101" %>
<HEAD>
	<title>tmp</title>
	<META http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
</HEAD>
<body MS_POSITIONING="FlowLayout">
	<FORM id="Form1" method="post" runat="server">
		<table cellSpacing="0" cellPadding="0" width="164" border="0">
			<tr>
				<td width="24"><FONT face="新細明體"><IMG src="/PortalFiles/WebImage/2/2_0003.gif"></FONT></td>
				<TD vAlign="top" width="140" bgColor="#0099cc">
					<P><FONT size="2">&nbsp;<FONT color="#ffffff">財務報告書上傳</FONT></FONT></P>
				</TD>
			</tr>
		</table>
		<P><asp:datagrid id="dgCart" runat="server" CellSpacing="1" GridLines="None" AllowSorting="True"
				OnDeleteCommand="dgCart_Delete" Width="100%" BackColor="White" BorderColor="White" AutoGenerateColumns="False"
				AllowPaging="True" ShowFooter="True" CellPadding="2" BorderWidth="0px" BorderStyle="Ridge"
				DataKeyField="invno">
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<EditItemStyle  Width="600px"></EditItemStyle>
				<AlternatingItemStyle ></AlternatingItemStyle>
				<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
				<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="fyear" HeaderText="年度">
						<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="filename1" HeaderText="第一季財務報告書">
						<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="filename2" HeaderText="第二季財務報告書">
						<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="filename3" HeaderText="第三季財務報告書">
						<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="filename4" HeaderText="第四季財務報告書">
						<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="invno" DataNavigateUrlFormatString="invest_101.aspx?invno={0}"
						DataTextField="invno" HeaderText="操作" NavigateUrl="編輯" DataTextFormatString="編輯">
						<HeaderStyle ForeColor="White"></HeaderStyle>
					</asp:HyperLinkColumn>
					<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<DIV></DIV>
			<DIV align="left"><FONT face="新細明體">
					<P><asp:label id="Message" runat="server"></asp:label></P>
					<P align="left">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399" border="0">
							<FONT face="新細明體"></FONT>
							<TBODY>
								<TR>
									<TD width="125" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>年度</STRONG></FONT></FONT></P>
									</TD>
									<TD width="400" bgColor="#ffffff" colSpan="2" height="28"><FONT face="新細明體"><asp:textbox id="fyear" runat="server" Width="50px"></asp:textbox></FONT></TD>
								</TR>
							</TBODY></TABLE>
						<STRONG><FONT color="#ff3333" size="2">※ 下面 8 個檔案相加，大小不可超過 10MB</FONT></STRONG><br>
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="650" bgColor="#003399" border="0">
							<TBODY>
								<TR>
									<TD width="150" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>季別</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>財務報告書</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>合併財務報告書</STRONG></FONT></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD width="150" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>第一季</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox1" runat="server" Width="200px"></asp:textbox><br>
										<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="txtdbfile1" runat="server"></asp:label><br>
										<INPUT id="txtfile1" type="file" size="25" name="txtfile1" runat="server">
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox2" runat="server" Width="200px"></asp:textbox><br>
											<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="atxtdbfile1" runat="server"></asp:label><br>
											<INPUT id="atxtfile1" type="file" size="25" name="atxtfile1" runat="server"> </FONT>
									</TD>
								</TR>
								<TR>
									<TD width="150" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>第二季</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox3" runat="server" Width="200px"></asp:textbox><br>
											<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="txtdbfile2" runat="server"></asp:label><br>
											<INPUT id="txtfile2" type="file" size="25" name="txtfile2" runat="server"> </FONT>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox4" runat="server" Width="200px"></asp:textbox><br>
											<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="atxtdbfile2" runat="server"></asp:label><br>
											<INPUT id="atxtfile2" type="file" size="25" name="atxtfile2" runat="server"> </FONT>
									</TD>
								</TR>
								<TR>
									<TD width="150" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>第三季</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox5" runat="server" Width="200px"></asp:textbox><br>
											<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="txtdbfile3" runat="server"></asp:label><br>
											<INPUT id="txtfile3" type="file" size="25" name="txtfile3" runat="server"> </FONT>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體"><FONT color="#000000" size="2">檔名:</FONT><asp:textbox id="Textbox6" runat="server" Width="200px"></asp:textbox><br>
											<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="atxtdbfile3" runat="server"></asp:label><br>
											<INPUT id="atxtfile3" type="file" size="25" name="atxtfile3" runat="server"> </FONT>
									</TD>
								</TR>
								<TR>
									<TD width="150" bgColor="lavender" height="28">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>第四季</STRONG></FONT></FONT></P>
									</TD>
									<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體">檔名:</FONT><asp:textbox id="Textbox7" runat="server" Width="200px"></asp:textbox><br>
										<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="txtdbfile4" runat="server"></asp:label><br>
										<INPUT id="txtfile4" type="file" size="25" name="txtfile4" runat="server">
				</FONT></TD>
				<TD width="300" bgColor="#ffffff" height="28"><FONT face="新細明體">檔名:</FONT><asp:textbox id="Textbox8" runat="server" Width="200px"></asp:textbox><br>
					<FONT color="#000000" size="2">檔案上傳:</FONT><asp:label id="atxtdbfile4" runat="server"></asp:label><br>
					<INPUT id="atxtfile4" type="file" size="25" name="atxtfile4" runat="server"> </FONT></TD>
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
						<INPUT type="reset" value="清除"> </FONT></TD>
				</TR>
				<TR>
					<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
				</TR>
			</TBODY></TABLE></FONT></P>
		</DIV></FONT></FORM>
</body>

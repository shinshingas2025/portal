<%@ Page Language="vb" AutoEventWireup="false" Codebehind="send_detail_tmp.aspx.vb" Inherits="send_detail_tmp" codePage="65001" %>
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- NAME: index.tpl -->
	</HEAD>
	<BODY>
		<table cellSpacing="0" cellPadding="0" width="174" border="0">
			<tr>
				<td width="24"><FONT face="新細明體"><IMG src="/PortalFiles/WebImage/2/2_0003.gif"></FONT></td>
				<TD vAlign="top" width="150" bgColor="#0099cc">
					<P><FONT size="2">&nbsp;<FONT color="#ffffff">保險商品送件--附件建立</FONT></FONT></P>
				</TD>
			</tr>
		</table>
		<form id="form1" runat="server">
			<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
				border="0">
				<TR>
					<TD width="80" bgColor="lavender" height="28">
						<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>送件文號</STRONG></FONT></FONT></STRONG></FONT></FONT></P>
					</TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">20060608001</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><FONT color="#000000" size="2"><STRONG>商品名稱</STRONG></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT face="新細明體" size="2">法商佳迪福人壽永福傷害還本保險</FONT></FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28">
						<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>公司文號</STRONG></FONT></FONT></P>
					</TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"></FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28">
						<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>日期</STRONG></FONT></FONT></P>
					</TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">2006/5/19</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28">
						<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>審查方式</STRONG></FONT></FONT></P>
					</TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">備查</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><STRONG><FONT face="新細明體" size="2">送審次數</FONT></STRONG></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">第一次</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>保險型態</STRONG></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">新商品</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>保險類別</STRONG></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體" size="2">傷害保險</FONT></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"></TD>
				</TR>
				<TR>
					<TD width="80" bgColor="#e6e6fa" height="28"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG>更新日期</STRONG></FONT></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffffff" colSpan="4">
						<% If (Request("invno") IS Nothing) Then %>
						<asp:button id="btnAdd" runat="server" Text="送件"></asp:button>
						<% 
											Else 
											Response.write("<INPUT id='invno' type='hidden' value='" & Request("invno") & "'>")
										%>
						<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
						<% End If %>
						<INPUT type="reset" value="清除"></FONT></TD>
				</TR>
				<TR>
					<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
				</TR>
			</TABLE>
			<P></P>
			<hr>
			<P></P>
			<DIV align="left"><asp:datagrid id="dgCart" runat="server" GridLines="None" AllowSorting="True" PageSize="9" OnDeleteCommand="dgCart_Delete"
					Width="100%" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True" DataKeyField="invno"
					ShowFooter="True" CellPadding="2" BorderWidth="0px" BorderStyle="Ridge">
					<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
					<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
					<EditItemStyle  Width="600px"></EditItemStyle>
					<AlternatingItemStyle ></AlternatingItemStyle>
					<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
					<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
					<Columns>
						<asp:BoundColumn HeaderText="狀態"></asp:BoundColumn>
						<asp:BoundColumn DataField="invname" HeaderText="文件名稱">
							<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:HyperLinkColumn Text="檔案" DataNavigateUrlField="invfile" DataNavigateUrlFormatString="../UpFile/{0}"
							DataTextField="invfile" HeaderText="附表" NavigateUrl="檔案">
							<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
						</asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="檔案上傳" DataNavigateUrlField="invno" DataNavigateUrlFormatString="send_file_tmp.aspx?invno={0}"
							DataTextField="invno" HeaderText="操作" NavigateUrl="檔案上傳" DataTextFormatString="檔案上傳">
							<HeaderStyle ForeColor="White"></HeaderStyle>
						</asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="線上建檔"></asp:HyperLinkColumn>
						<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
						Mode="NumericPages"></PagerStyle>
				</asp:datagrid></FONT></DIV>
		</form>
	</BODY>
</HTML>
 

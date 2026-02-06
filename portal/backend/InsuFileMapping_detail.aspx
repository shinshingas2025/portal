<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InsuFileMapping_detail.aspx.vb" Inherits="InsuFileMapping_detail" codePage="65001" %>
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
					<P><FONT size="2">&nbsp;<FONT color="#ffffff"><FONT color="#ffffff">險種對應附件檔案設定</FONT></FONT></FONT></P>
				</TD>
			</tr>
		</table>
		<form id="form1" runat="server">
			<TABLE id="Table5" height="60" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
				border="0">
				<TR>
					<TD width="95" bgColor="lavender" height="28" style="WIDTH: 95px">
						<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>型態</STRONG></FONT></FONT></STRONG></FONT></FONT></P>
					</TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體" size="2">新商品</FONT></TD>
				</TR>
				<TR>
					<TD width="95" bgColor="#e6e6fa" height="28" style="WIDTH: 95px"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD width="95" bgColor="#e6e6fa" height="28" style="WIDTH: 95px"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG>更新日期</STRONG></FONT></FONT></TD>
					<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT size="2"></FONT></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffffff" colSpan="4"><FONT size="2">
							<% If (Request("invno") IS Nothing) Then %>
							<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
							<% 
											Else 
											Response.write("<INPUT id='invno' type='hidden' value='" & Request("invno") & "'>")
										%>
							<asp:button id="btnupdate" runat="server" Text="修改" Visible="False"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
							<% End If %>
							<INPUT type="reset" value="清除"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><FONT size="2"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></FONT></TD>
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
						<asp:BoundColumn DataField="invname" HeaderText="文件名稱">
							<HeaderStyle ForeColor="White" Width="50%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:HyperLinkColumn Text="檔案" DataNavigateUrlField="invfile" DataNavigateUrlFormatString="../UpFile/{0}"
							DataTextField="invfile" HeaderText="附表" NavigateUrl="檔案">
							<HeaderStyle ForeColor="White" Width="40%"></HeaderStyle>
						</asp:HyperLinkColumn>
						<asp:ButtonColumn Text="刪除" HeaderText="操作" CommandName="Delete">
							<HeaderStyle Width="10%"></HeaderStyle>
						</asp:ButtonColumn>
					</Columns>
					<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
						Mode="NumericPages"></PagerStyle>
				</asp:datagrid></FONT></DIV>
		</form>
	</BODY>
</HTML>
 

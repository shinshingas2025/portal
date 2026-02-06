<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InsuFileMapping.aspx.vb" Inherits="InsuFileMapping" codePage="65001" %>
<HTML>
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
						<P><FONT size="2">&nbsp;<FONT color="#ffffff">險種對應附件檔案設定</FONT></FONT></P>
					</TD>
				</tr>
			</table>
			<FONT face="新細明體">
				<P><asp:datagrid id="dgCart" runat="server" GridLines="None" AllowSorting="True" PageSize="6" OnDeleteCommand="dgCart_Delete"
						Width="100%" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True"
						DataKeyField="faqno" ShowFooter="True" CellPadding="2" BorderWidth="0px" BorderStyle="Ridge">
						<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
						<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
						<EditItemStyle  Width="600px"></EditItemStyle>
						<AlternatingItemStyle ></AlternatingItemStyle>
						<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
						<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="type1" HeaderText="型態">
								<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:HyperLinkColumn Text="設定檔案" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="InsuFileMapping_detail.aspx?faqno={0}"
								DataTextField="faqno" HeaderText="操作" NavigateUrl="設定檔案" DataTextFormatString="設定檔案">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:ButtonColumn Text="刪除" CommandName="Delete">
								<HeaderStyle Width="8%"></HeaderStyle>
							</asp:ButtonColumn>
						</Columns>
						<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
							Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
				<P><asp:label id="Message" runat="server"></asp:label><FONT face="新細明體">
						<asp:textbox id="txtquestion" runat="server" Width="24px" Visible="False"></asp:textbox><FONT face="新細明體">
							<asp:textbox id="txtanswer" runat="server" Width="24px" Visible="False"></asp:textbox>
							<asp:textbox id="txtdbfaqgrp" runat="server" Width="24px" Visible="False"></asp:textbox>
							<asp:textbox id="txt_type" runat="server" Width="32px" Visible="False"></asp:textbox>
							<asp:dropdownlist id="txttype" runat="server" Visible="False">
								<asp:ListItem Value="單一型">單一型</asp:ListItem>
								<asp:ListItem Value="綜合(組合)型">綜合(組合)型</asp:ListItem>
							</asp:dropdownlist>
							<asp:dropdownlist id="txtfaqgrp" runat="server" Visible="False">
								<asp:ListItem Value="傳統型">傳統型</asp:ListItem>
								<asp:ListItem Value="投資型">投資型</asp:ListItem>
							</asp:dropdownlist></FONT></FONT></P>
				<hr>
				<P align="left">
					<TABLE id="Table5" height="60" cellSpacing="1" cellPadding="1" width="632" bgColor="#003399"
						border="0">
						<TBODY>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>型態</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28"><asp:dropdownlist id="Dropdownlist1" runat="server">
										<asp:ListItem Value="新商品">新商品</asp:ListItem>
										<asp:ListItem Value="部分變更商品">部分變更商品</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><asp:label id="Creater" runat="server" ></asp:label><asp:label id="txtdbtype" runat="server" Width="24px" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>更新日期</STRONG></FONT></TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:label id="revisetime" runat="server" ></asp:label></FONT></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffffff" colSpan="4">
									<% If (Request("faqno") IS Nothing) Then %>
									<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
									<% 
											Else 
											Response.write("<INPUT id='faqno' type='hidden' value='" & Request("faqno") & "'>")
										%>
									<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
									<% End If %>
									<INPUT type="reset" value="清除">
			</FONT></TD></TR></TBODY></TABLE></P></FONT>
			<table id="Table1" cellSpacing="0" cellPadding="0" width="748" border="0">
				<tr>
				</tr>
			</table>
			</TD></TR></FORM>
	</body>
</HTML>
 

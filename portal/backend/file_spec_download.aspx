<%@ Page Language="vb" AutoEventWireup="false" Codebehind="file_spec_download.aspx.vb" Inherits="file_spec_download" %>
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
					<P><FONT size="2">&nbsp;<FONT color="#ffffff">檔案送件規格文件下載</FONT></FONT></P>
				</TD>
			</tr>
		</table>
		<P><FONT face="新細明體"><FONT size="2"><STRONG>保險商品性質 </STRONG></FONT>
				<asp:dropdownlist id="Dropdownlist1" runat="server">
					<asp:ListItem Value="全部">全部</asp:ListItem>
					<asp:ListItem Value="新商品">新商品</asp:ListItem>
					<asp:ListItem Value="部分變更商品">部分變更商品</asp:ListItem>
				</asp:dropdownlist><FONT face="新細明體"></FONT></FONT></P>
		<P><FONT face="新細明體">
				<asp:button id="btnupdatecel" runat="server" Text="查詢"></asp:button></P>
		</FONT>
		<P>
			<asp:datagrid id="dgCart" runat="server" BorderStyle="Ridge" BorderWidth="0px" CellPadding="2"
				DataKeyField="invno" AllowPaging="True" AutoGenerateColumns="False" BorderColor="White" BackColor="White"
				Width="100%" OnDeleteCommand="dgCart_Delete" PageSize="9" AllowSorting="True" GridLines="None"
				ShowFooter="True">
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<EditItemStyle  Width="600px"></EditItemStyle>
				<AlternatingItemStyle  BackColor="#F7F7F7"></AlternatingItemStyle>
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
					<asp:HyperLinkColumn Text="下載" DataNavigateUrlField="invno" DataTextField="invno" HeaderText="操作" NavigateUrl="下載"
						DataTextFormatString="下載">
						<HeaderStyle ForeColor="White" Width="30px"></HeaderStyle>
					</asp:HyperLinkColumn>
				</Columns>
				<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
					Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<DIV></DIV>
			<DIV align="left"><FONT face="新細明體">
					<P>
						<asp:label id="Message" runat="server"></asp:label></P>
					<P align="left">
				</FONT>
			&nbsp;</P>
		</DIV></FONT></FORM>
</body>
 

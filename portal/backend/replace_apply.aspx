<%@ Page Language="vb" AutoEventWireup="false" Codebehind="replace_apply.aspx.vb" Inherits="replace_apply" codePage="65001" %>
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
			<table cellSpacing="0" cellPadding="0" width="210" border="0">
				<tr>
					<td width="24"><FONT face="新細明體"><IMG src="/PortalFiles/WebImage/2/2_0003.gif"></FONT></td>
					<TD vAlign="top" width="185" bgColor="#0099cc">
						<P><FONT size="2">&nbsp;<FONT color="#ffffff">保險商品--申請抽換及抽換作業</FONT></FONT></P>
					</TD>
				</tr>
			</table>
			<FONT face="新細明體">
				<P><asp:datagrid id="dgCart" runat="server" BorderStyle="Ridge" BorderWidth="0px" CellPadding="2"
						ShowFooter="True" DataKeyField="faqno" AllowPaging="True" AutoGenerateColumns="False" BorderColor="White"
						BackColor="White" Width="100%" OnDeleteCommand="dgCart_Delete" PageSize="6" AllowSorting="True"
						GridLines="None">
						<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
						<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
						<EditItemStyle  Width="600px"></EditItemStyle>
						<AlternatingItemStyle ></AlternatingItemStyle>
						<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
						<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="state" HeaderText="狀態">
								<HeaderStyle ForeColor="White" Width="6%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="faqquestion" HeaderText="送件文號">
								<HeaderStyle ForeColor="White" Width="12%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="faqanswer" HeaderText="商品名稱">
								<HeaderStyle ForeColor="White" Width="36%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="type1" HeaderText="保險型態">
								<HeaderStyle ForeColor="White" Width="12%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="solution" HeaderText="審查方式">
								<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:HyperLinkColumn Text="申請抽換" DataNavigateUrlField="faqno" DataTextField="faqno" HeaderText="操作" NavigateUrl="申請抽換"
								DataTextFormatString="申請抽換">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:HyperLinkColumn Text="取消抽換" DataNavigateUrlField="faqno" DataTextField="faqno" NavigateUrl="取消抽換"
								DataTextFormatString="取消抽換">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:HyperLinkColumn Text="附件抽換" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="replace_detail_tmp.aspx?faqno={0}"
								DataTextField="faqno" NavigateUrl="附件抽換" DataTextFormatString="附件抽換">
								<HeaderStyle Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
						</Columns>
						<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
							Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
				<P><asp:label id="Message" runat="server"></asp:label><FONT face="新細明體">
						<asp:textbox id="txtquestion" runat="server" Width="24px" Visible="False"></asp:textbox><FONT face="新細明體">
							<asp:textbox id="txtdbfaqgrp" runat="server" Width="16px" Visible="False"></asp:textbox><FONT face="新細明體">
								<asp:textbox id="txtanswer" runat="server" Width="40px" Visible="False"></asp:textbox>
								<asp:dropdownlist id="txtfaqgrp" runat="server" Visible="False"></asp:dropdownlist>
								<asp:dropdownlist id="txttype" runat="server" Visible="False"></asp:dropdownlist>
								<asp:textbox id="txt_type" runat="server" Width="32px" Visible="False"></asp:textbox>
								<asp:label id="Creater" runat="server" Visible="False" ></asp:label>
								<asp:label id="txtdbtype" runat="server" Width="24px" Visible="False"></asp:label><FONT face="新細明體">
									<asp:label id="revisetime" runat="server" Visible="False" ></asp:label>
									<asp:button id="btnAdd" runat="server" Visible="False" Text="新增"></asp:button>
									<asp:button id="btnupdate" runat="server" Visible="False" Text="修改"></asp:button>
									<asp:button id="btnupdatecel" runat="server" Visible="False" Text="取消"></asp:button></FONT></FONT></FONT></FONT></P>
			</FONT>
		</FORM>
	</body>
</HTML>
 

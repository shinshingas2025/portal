<%@ Page Language="vb" AutoEventWireup="false" Codebehind="send_master_tmp.aspx.vb" Inherits="send_master_tmp" codePage="65001" %>
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
			<table cellSpacing="0" cellPadding="0" width="115" border="0">
				<tr>
					<td width="24"><FONT face="新細明體"><IMG src="/PortalFiles/WebImage/2/2_0003.gif"></FONT></td>
					<TD vAlign="top" width="90" bgColor="#0099cc">
						<P><FONT size="2">&nbsp;<FONT color="#ffffff">保險商品送件</FONT></FONT></P>
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
							<asp:BoundColumn DataField="faqquestion" HeaderText="送件文號">
								<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="faqanswer" HeaderText="商品名稱">
								<HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="type1" HeaderText="型態">
								<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="type5" HeaderText="保險商品類別">
								<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="solution" HeaderText="審查方式">
								<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="send_detail_tmp.aspx?faqno={0}"
								DataTextField="faqno" HeaderText="操作" NavigateUrl="上檔" DataTextFormatString="上檔">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="send_master.tmp.aspx?faqno={0}"
								DataTextField="faqno" NavigateUrl="編輯" DataTextFormatString="編輯">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:ButtonColumn Text="刪除" CommandName="Delete">
								<HeaderStyle Width="8%"></HeaderStyle>
							</asp:ButtonColumn>
						</Columns>
						<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
							Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
				<P><asp:label id="Message" runat="server"></asp:label>
					<asp:dropdownlist id="txtfaqgrp" runat="server" Width="64px" Visible="False">
						<asp:ListItem Value="依據勞工退休金條例相關規定辦理之年金保險商品">依據勞工退休金條例相關規定辦理之年金保險商品</asp:ListItem>
						<asp:ListItem Value="應提存保證給付責任準備金之投資型保險商品">應提存保證給付責任準備金之投資型保險商品</asp:ListItem>
						<asp:ListItem Value="新型態之保險商品">新型態之保險商品</asp:ListItem>
					</asp:dropdownlist>
					<asp:dropdownlist id="txttype" runat="server" Width="40px" Visible="False">
						<asp:ListItem Value="依[人身保險商品應注意事項]第15條規定">依[人身保險商品應注意事項]第15條規定</asp:ListItem>
						<asp:ListItem Value="依[人身保險商品應注意事項]第15條規定">依[人身保險商品應注意事項]第15條規定</asp:ListItem>
					</asp:dropdownlist></P>
				<hr>
				<P align="left">
					<TABLE id="Table5" height="470" cellSpacing="1" cellPadding="1" width="632" bgColor="#003399"
						border="0">
						<TBODY>
							<TR>
								<TD width="85" bgColor="lavender" height="27">
									<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>送件文號</STRONG></FONT></FONT></P>
								</TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtquestion" runat="server" Width="104px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>商品名稱</STRONG></FONT></TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtanswer" runat="server" Width="376px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="27">
									<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>公司文號</STRONG></FONT></FONT></P>
								</TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><asp:textbox id="Textbox2" runat="server" Width="32px"></asp:textbox><FONT face="新細明體">&nbsp;字第
										<asp:textbox id="Textbox3" runat="server" Width="88px"></asp:textbox>&nbsp;號</FONT></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="25"><FONT face="新細明體">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>日期</STRONG></FONT></FONT></P>
									</FONT>
								</TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="25"><asp:textbox id="txtdbfaqgrp" runat="server" Width="104px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="27"><FONT face="新細明體">
										<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>審查方式</STRONG></FONT></FONT></P>
									</FONT>
								</TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="27">
									<P><asp:radiobutton id="RadioButton1" runat="server" Text="核准"></asp:radiobutton>&nbsp;<asp:dropdownlist id="etxtfaqgrp" runat="server" Width="288px">
											<asp:ListItem Value="依據勞工退休金條例相關規定辦理之年金保險商品">依據勞工退休金條例相關規定辦理之年金保險商品</asp:ListItem>
											<asp:ListItem Value="應提存保證給付責任準備金之投資型保險商品">應提存保證給付責任準備金之投資型保險商品</asp:ListItem>
											<asp:ListItem Value="新型態之保險商品">新型態之保險商品</asp:ListItem>
										</asp:dropdownlist></P>
									<P><asp:radiobutton id="RadioButton2" runat="server" Text="備查"></asp:radiobutton>&nbsp;<asp:dropdownlist id="etxttype" runat="server">
											<asp:ListItem Value="依[人身保險商品應注意事項]第15條規定">依[人身保險商品應注意事項]第15條規定</asp:ListItem>
											<asp:ListItem Value="符合[保險商品銷售前程序作業準則]第2條核准制商品得改為以備查方式辦理">符合[保險商品銷售前程序作業準則]第2條核准制商品得改為以備查方式辦理</asp:ListItem>
										</asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><STRONG><FONT face="新細明體" size="2">審查次數</FONT></STRONG></TD>
								<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">第
										<asp:textbox id="txt_type" runat="server" Width="32px"></asp:textbox>&nbsp;次審查</FONT></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>型態</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28"><asp:dropdownlist id="Dropdownlist1" runat="server">
										<asp:ListItem Value="新商品">新商品</asp:ListItem>
										<asp:ListItem Value="部分變更商品">部分變更商品</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>性質1</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28"><asp:dropdownlist id="Dropdownlist2" runat="server">
										<asp:ListItem Value="個人保險">個人保險</asp:ListItem>
										<asp:ListItem Value="團體保險">團體保險</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>性質2</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28"><asp:dropdownlist id="Dropdownlist6" runat="server">
										<asp:ListItem Value="單一型">單一型</asp:ListItem>
										<asp:ListItem Value="綜合(組合)型">綜合(組合)型</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>保險商品種類</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28"><asp:dropdownlist id="Dropdownlist3" runat="server">
										<asp:ListItem Value="傳統型">傳統型</asp:ListItem>
										<asp:ListItem Value="投資型">投資型</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD width="85" bgColor="#e6e6fa" colSpan="1" height="28" rowSpan="1"><FONT face="新細明體" size="2"><STRONG>保險商品類別</STRONG></FONT></TD>
								<TD width="370" bgColor="#ffffff" height="28">
									<P><FONT face="新細明體"><asp:dropdownlist id="Dropdownlist4" runat="server">
												<asp:ListItem Value="傳統型人壽保險">傳統型人壽保險</asp:ListItem>
												<asp:ListItem Value="傳統型年金保險">傳統型年金保險</asp:ListItem>
												<asp:ListItem Value="傷害保險">傷害保險</asp:ListItem>
												<asp:ListItem Value="健康保險">健康保險</asp:ListItem>
												<asp:ListItem Value="利率變動型人壽保險">利率變動型人壽保險</asp:ListItem>
												<asp:ListItem Value="利率變動型年金保險">利率變動型年金保險</asp:ListItem>
												<asp:ListItem Value="萬能人壽保險">萬能人壽保險</asp:ListItem>
											</asp:dropdownlist><asp:dropdownlist id="Dropdownlist5" runat="server">
												<asp:ListItem Value="投資型人壽保險">投資型人壽保險</asp:ListItem>
												<asp:ListItem Value="投資型年金保險">投資型年金保險</asp:ListItem>
											</asp:dropdownlist></P>
			</FONT></TD></TR>
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
					<INPUT type="reset" value="清除"> </FONT></TD>
			</TR>
			</TBODY></TABLE></P></FONT>
			<table id="Table1" cellSpacing="0" cellPadding="0" width="748" border="0">
				<tr>
				</tr>
			</table>
			</TD></TR></FORM>
	</body>
</HTML>
 

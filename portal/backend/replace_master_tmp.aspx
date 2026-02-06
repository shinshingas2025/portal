<%@ Page Language="vb" AutoEventWireup="false" Codebehind="replace_master_tmp.aspx.vb" Inherits="replace_master_tmp" codePage="65001" %>
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
				<P><asp:datagrid id="dgCart" GridLines="None" AllowSorting="True" PageSize="6" OnDeleteCommand="dgCart_Delete"
						Width="100%" BackColor="White" BorderColor="White" AutoGenerateColumns="False" AllowPaging="True"
						DataKeyField="faqno" ShowFooter="True" CellPadding="2" BorderWidth="0" BorderStyle="Ridge"
						CellSpacing="0" runat="server">
						<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
						<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
						<EditItemStyle  Width="600px"></EditItemStyle>
						<AlternatingItemStyle ></AlternatingItemStyle>
						<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
						<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="faqquestion" HeaderText="送件文號">
								<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="faqanswer" HeaderText="商品名稱">
								<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:TemplateColumn HeaderText="審查方式">
								<HeaderStyle ForeColor="White" Width="11%"></HeaderStyle>
								<ItemTemplate>
									<%#Container.DataItem("faqgrpname")%>
									<FONT face="新細明體"></FONT>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="保險性質">
								<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
								<ItemTemplate>
									<%#Container.DataItem("type")%>
									<FONT face="新細明體"></FONT>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="send_detail_tmp.aspx?faqno={0}"
								DataTextField="faqno" HeaderText="操作" NavigateUrl="上檔" DataTextFormatString="上檔">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:HyperLinkColumn Text="編輯" DataNavigateUrlField="faqno" DataNavigateUrlFormatString="faq_item.aspx?faqno={0}"
								DataTextField="faqno" NavigateUrl="編輯" DataTextFormatString="編輯">
								<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
						<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
							Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
				<P><asp:label id="Message" runat="server"></asp:label></P>
				<hr>
				<P align="left">
					<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
						border="0">
						<TR>
							<TD width="85" bgColor="lavender" height="27">
								<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>送件文號</STRONG></FONT></FONT></P>
							</TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtquestion" Width="104px" runat="server"></asp:textbox><asp:textbox id="txtdbfaqgrp" Width="16px" runat="server" Visible="False"></asp:textbox></FONT></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>商品名稱</STRONG></FONT></TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:textbox id="txtanswer" Width="376px" runat="server"></asp:textbox></FONT></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" height="27">
								<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>公司文號</STRONG></FONT></FONT></P>
							</TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><asp:textbox id="Textbox2" Width="32px" runat="server"></asp:textbox><FONT face="新細明體">&nbsp;字第
									<asp:textbox id="Textbox3" Width="88px" runat="server"></asp:textbox>&nbsp;號</FONT></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" height="25"><FONT face="新細明體">
									<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>日期</STRONG></FONT></FONT></P>
								</FONT>
							</TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="25"><asp:dropdownlist id="txtfaqgrp" runat="server"></asp:dropdownlist><asp:dropdownlist id="txttype" runat="server"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" height="27"><FONT face="新細明體">
									<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>審查方式</STRONG></FONT></FONT></P>
								</FONT>
							</TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="27"><asp:radiobutton id="RadioButton1" runat="server" Text="審查"></asp:radiobutton><asp:radiobuttonlist id="RadioButtonList1" Width="464px" BorderStyle="Double" runat="server" Font-Size="Smaller">
									<asp:ListItem Value="依據勞工退休金條例相關規定辦理之年金保險商品">依據勞工退休金條例相關規定辦理之年金保險商品</asp:ListItem>
									<asp:ListItem Value="應提存保證給付責任準備金之投資型保險商品">應提存保證給付責任準備金之投資型保險商品</asp:ListItem>
									<asp:ListItem Value="新型態之保險商品">新型態之保險商品</asp:ListItem>
								</asp:radiobuttonlist><asp:radiobutton id="RadioButton2" runat="server" Text="備查"></asp:radiobutton><asp:radiobuttonlist id="Radiobuttonlist7" Width="464px" BorderStyle="Double" runat="server" Font-Size="Smaller">
									<asp:ListItem Value="依[人身保險商品應注意事項]第15條規定">依[人身保險商品應注意事項]第15條規定</asp:ListItem>
									<asp:ListItem Value="符合保險商品銷售前程序作業準則第21條核准制商品得改為以備查方式辦理">符合保險商品銷售前程序作業準則第21條核准制商品得改為以備查方式辦理</asp:ListItem>
								</asp:radiobuttonlist></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" height="28"><STRONG><FONT face="新細明體" size="2">審查次數</FONT></STRONG></TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體">第
									<asp:textbox id="txt_type" Width="32px" runat="server"></asp:textbox>&nbsp;次審查</FONT></TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" colSpan="1" height="28" rowSpan="1"><FONT face="新細明體" size="2"><STRONG>保險商品性質</STRONG></FONT></TD>
							<TD width="370" bgColor="#ffffff" height="28"><FONT face="新細明體"></FONT><FONT face="新細明體">
									<TABLE id="Table2" height="381" cellSpacing="1" cellPadding="1" width="433" border="1">
										<TR>
											<TD colSpan="3"><asp:radiobuttonlist id="RadioButtonList2" Width="152px" runat="server" Height="46px">
													<asp:ListItem Value="新商品">新商品</asp:ListItem>
													<asp:ListItem Value="部分變更商品">部分變更商品</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:radiobuttonlist id="RadioButtonList3" Width="104px" runat="server">
													<asp:ListItem Value="個人保險">個人保險</asp:ListItem>
													<asp:ListItem Value="團體保險">團體保險</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:radiobuttonlist id="RadioButtonList4" Width="444px" runat="server">
													<asp:ListItem Value="傳統型人壽保險、傳統型年金保險、傷害保險或健康保險">傳統型人壽保險、傳統型年金保險、傷害保險或健康保險</asp:ListItem>
													<asp:ListItem Value="利率變動型人壽保險獲利率變動型年金保險">利率變動型人壽保險獲利率變動型年金保險</asp:ListItem>
													<asp:ListItem Value="萬能人壽保險">萬能人壽保險</asp:ListItem>
													<asp:ListItem Value="其他">其他</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:radiobuttonlist id="RadioButtonList5" Width="444px" runat="server">
													<asp:ListItem Value="投資型人壽保險">投資型人壽保險</asp:ListItem>
													<asp:ListItem Value="投資型年金保險">投資型年金保險</asp:ListItem>
													<asp:ListItem Value="其他">其他</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD colSpan="3"><asp:radiobuttonlist id="RadioButtonList6" Width="256px" runat="server">
													<asp:ListItem Value="一般型">一般型</asp:ListItem>
													<asp:ListItem Value="綜合（組合）型保險">綜合（組合）型保險</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
									</TABLE>
								</FONT>
							</TD>
						</TR>
						<TR>
							<TD width="85" bgColor="#e6e6fa" height="28"><FONT face="新細明體" size="2"><STRONG>執行人員</STRONG></FONT></TD>
							<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><asp:label id="Creater" runat="server" ></asp:label><asp:label id="txtdbtype" Width="24px" runat="server" Visible="False"></asp:label></TD>
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
 

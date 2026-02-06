<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Webmember_01.aspx.vb" Inherits="Webmember_01" codePage="65001" %>
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="javascript">
		//全選功能
        function SelectAll(spanChk) 
			{ 
			// Added as ASPX uses SPAN for checkbox 
			// var oItem = spanChk.children; 


			var theBox=spanChk;// oItem.item(0) 
			xState=theBox.checked; 

			elm=theBox.form.elements; 
			for(i=13;i<elm.length;i++) 
			if(elm[i].type=="checkbox" && elm[i].id!=theBox.id) 
			{ 
			//elm[i].click(); 
			if(elm[i].checked!=xState) 
			// elm[i].click(); 
			elm[i].checked=xState; 
			} 
			} 
		
		</script>
	</HEAD>
	<body text="#000000">
		<form id="Form2" runat="server">
			<table>
				<tr>
					<td bgColor="#a6c4e1"></td>
					<td width="930" bgColor="#6699cc"><FONT face="新細明體"></FONT></td>
					<td bgColor="#a6c4e1"></td>
				</tr>
				<tr>
					<td bgColor="#d2e1f0"></td>
					<td width="930">
						<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
							<tr>
								<td vAlign="middle" align="center">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="431">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">會員基本資料管理</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="748">
									<table id="Table4" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="left" height="92">
												<TABLE height="112" cellSpacing="0" cellPadding="0" width="572" border="0" ms_1d_layout="TRUE">
													<TR>
														<TD>
															<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="493" border="0">
																<TR>
																	<TD width="177" height="33"><FONT face="新細明體"><asp:label id="Label4" runat="server" CssClass="normal" Width="96px">會員註冊日期</asp:label></FONT></TD>
																	<TD width="624" height="33"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="7"></asp:textbox><BR>
																		<FONT face="細明體" color="#3399cc" size="2">(Ex:990809，空白表全部)</FONT>
																	<TD width="127" height="33"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="121"><FONT face="新細明體"><asp:label id="Label6" runat="server" CssClass="normal" Width="160px">會員註冊狀態</asp:label></FONT></TD>
																	<TD width="624" height="121"><FONT face="新細明體"><asp:checkbox id="CheckBox1" runat="server" Text="已啟動、已設定用戶號碼" Checked="True" AutoPostBack="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox2" runat="server" Text="已啟動、尚未設定用戶號碼" Checked="false" AutoPostBack="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox3" runat="server" Text="尚未啟動" Checked="false" AutoPostBack="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox4" runat="server" Text="授權碼發送失敗" Checked="false" AutoPostBack="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox5" runat="server" Text="停權" Checked="false" AutoPostBack="True"></asp:checkbox></FONT></TD>
																	<TD width="127" height="121"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="88"><FONT face="新細明體"><asp:label id="Label7" runat="server" CssClass="normal" Width="112px">身份別(可複選)</asp:label></FONT></TD>
																	<TD width="624" height="88"><FONT face="新細明體"><asp:checkbox id="Checkbox6" runat="server" Text="個人用戶" Checked="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox7" runat="server" Text="營業用戶" Checked="True"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox8" runat="server" Text="機關用戶" Checked="True"></asp:checkbox></FONT></TD>
																	<TD width="127" height="88"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="114"><asp:dropdownlist id="likeSelect" runat="server" Width="112px">
																			<asp:ListItem Value="wm_id" Selected="True">身份證號碼(統一編號)</asp:ListItem>
																			<asp:ListItem Value="wm_email">電子信箱</asp:ListItem>
																			<asp:ListItem Value="wm_user_name">申請人姓名(承辦人姓名)</asp:ListItem>
																			<asp:ListItem Value="wm_mobile">行動電話</asp:ListItem>
																		</asp:dropdownlist></TD>
																	<TD width="624"><FONT face="新細明體">&nbsp;</FONT>
																		<asp:textbox id="likeContent" runat="server" Width="160px"></asp:textbox>
																	</TD>
																	<TD width="127"><asp:button id="btnSearch" runat="server" Text="查詢"></asp:button></TD>
																</TR>
																<TR>
																	<TD width="177" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																	<TD width="624" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																	<TD width="127" height="14"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																	<TD width="624" height="25"><asp:label id="Creater" runat="server" ></asp:label></TD>
																	<TD width="127" height="25"><FONT face="新細明體"></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<hr>
												<P align="center">
													<asp:label id="msgbox" runat="server" CssClass="normal" ForeColor="Red"></asp:label></P>
											</TD>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="850px" CellSpacing="1" GridLines="None" BackColor="White"
														BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="wm_no"
														AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="wm_no" ReadOnly="True"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="全選 ">
																<HeaderTemplate>
																	<asp:CheckBox id="headercheck" onclick="javascript:SelectAll(this);" runat="server"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:CheckBox id="itemcheck" runat="server"></asp:CheckBox></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="序號">
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:Label id=no runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_no") %>'>
																		</asp:Label></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="啟用別">
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:Label id="FLAG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_open_flag") %>'>
																		</asp:Label></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="啟用別">
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:Label id="OPENFLAG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OPENFLAG") %>'>
																		</asp:Label></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="">
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:Textbox id="wmno" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wm_no") %>'>
																		</asp:Textbox></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="ORGFLAG" ReadOnly="True" HeaderText="身份別">
																<HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)">
																<HeaderStyle Width="12%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="wm_no">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
																<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_tel_oo" ReadOnly="True" HeaderText="連絡電話(O)">
																<HeaderStyle Width="12%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_tel_h" ReadOnly="True" HeaderText="連絡電話(H)">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_email" ReadOnly="True" HeaderText="電子信箱">
																<HeaderStyle Width="20%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="add_datetime" ReadOnly="True" HeaderText="註冊日期">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="OPENFLAG" ReadOnly="True" HeaderText="狀態">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="wm_no" DataNavigateUrlFormatString="memberEdit.aspx?wm_no={0}"
																HeaderText="修改" NavigateUrl="修改">
																<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
															</asp:HyperLinkColumn>
															<asp:TemplateColumn HeaderText="啟動">
																<ItemTemplate>
																	<asp:linkbutton id="start_button" text="啟動" runat="server" CommandName="start"></asp:linkbutton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="停權">
																<ItemTemplate>
																	<asp:linkbutton id="stop_button" text="停權" runat="server" CommandName="stop"></asp:linkbutton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="未啟動">
																<ItemTemplate>
																	<asp:linkbutton id="nonstart_button" text="未啟動" runat="server" CommandName="nonstart"></asp:linkbutton>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												</FONT>
												<P><asp:button id="Button2" runat="server" Text="重寄授權碼" Visible="False"></asp:button><asp:button id="Button1" runat="server" Text="未設用戶號碼通知" Visible="False"></asp:button></P>
												<P><asp:label id="Message" runat="server"></asp:label></P>
											</td>
										</tr>
									</table>
									<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
									</p>
									<p><FONT face="新細明體"></FONT></p>
								</td>
							</tr>
						</table>
					</td>
					<td bgColor="#d2e1f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

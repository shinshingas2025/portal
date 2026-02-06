<%@ Page Language="vb" AutoEventWireup="false" Codebehind="member_011.aspx.vb" Inherits="member_011" codePage="65001" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="javascript">
		//全選功能
        function SelectAll(spanChk) 
			{ 
			// Added as ASPX uses SPAN for checkbox 
			// var oItem = spanChk.children; 


			var theBox=spanChk;// oItem.item(0) 
			xState=theBox.checked; 

			elm=theBox.form.elements; 
			for(i=0;i<elm.length;i++) 
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
													<FONT color="#003366">會員註冊資料及狀態查詢</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" ForeColor="Red" CssClass="normal"></asp:label></td>
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
																	<TD width="624" height="33"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:20010809，空白表全部)</FONT></TD>
																	<TD width="127" height="33"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="121"><FONT face="新細明體"><asp:label id="Label6" runat="server" CssClass="normal" Width="160px">會員註冊狀態(可複選)</asp:label></FONT></TD>
																	<TD width="624" height="121"><FONT face="新細明體"><asp:checkbox id="CheckBox1" runat="server" Checked="True" Text="已啟動、已設定用戶號碼"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox2" runat="server" Checked="True" Text="已啟動、尚未設定用戶號碼"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox3" runat="server" Checked="True" Text="尚未啟動"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox4" runat="server" Checked="True" Text="授權碼發送失敗"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox5" runat="server" Checked="True" Text="停權"></asp:checkbox></FONT></TD>
																	<TD width="127" height="121"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="88"><FONT face="新細明體"><asp:label id="Label7" runat="server" CssClass="normal" Width="112px">身份別(可複選)</asp:label></FONT></TD>
																	<TD width="624" height="88"><FONT face="新細明體"><asp:checkbox id="Checkbox6" runat="server" Checked="True" Text="個人用戶"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox7" runat="server" Checked="True" Text="營業用戶"></asp:checkbox><br>
																			<asp:checkbox id="Checkbox8" runat="server" Checked="True" Text="機關用戶"></asp:checkbox></FONT></TD>
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
																		<asp:textbox id="likeContent" runat="server" Width="160px"></asp:textbox></TD>
																	<TD width="127"><asp:button id="btnSearch" runat="server" Text="查詢"></asp:button></TD>
																</TR>
																<TR>
																	<TD width="177" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																	<TD width="624" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" Font-Size="X-Small"></asp:label></FONT></TD>
																	<TD width="127" height="14"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="177" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																	<TD width="624" height="25"><asp:label id="Creater" runat="server" Font-Size="X-Small"></asp:label></TD>
																	<TD width="127" height="25"><FONT face="新細明體"><asp:button id="btnPrint" runat="server" Width="43px" Text="列印" Visible="False"></asp:button></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<hr>
											</TD>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="850px" AllowSorting="True" AutoGenerateColumns="False"
														AllowPaging="True" DataKeyField="wm_no" ShowFooter="True" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
														BorderColor="White" BackColor="White" GridLines="None" CellSpacing="1">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<EditItemStyle Font-Size="X-Small" HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle Font-Size="X-Small"></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="ORGFLAG" ReadOnly="True" HeaderText="身份別">
																<HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
																<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_tel_o" ReadOnly="True" HeaderText="連絡電話(O)">
																<HeaderStyle Width="10%"></HeaderStyle>
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
															<asp:EditCommandColumn Visible="False" ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
														</Columns>
														<PagerStyle Font-Size="X-Small" Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												</FONT>
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

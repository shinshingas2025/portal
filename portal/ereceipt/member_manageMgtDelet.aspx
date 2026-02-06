<%@ Page Language="vb" AutoEventWireup="false" Codebehind="member_manageMgtDelet.aspx.vb" Inherits="member_manageMgtDelet" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
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
	<body>
		<form id="Form1" runat="server">
			<!-- NAME: index.tpl --><tr>
				<td bgcolor="#A6C4E1"></td>
				<td bgcolor="#6699CC" width="930"></td>
				<td bgcolor="#A6C4E1"></td>
			</tr>
			<tr>
				<td bgcolor="#D2E1F0"></td>
				<td width="930">
					<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
						<tr>
							<td vAlign="middle" align="center">
								<table cellSpacing="0" cellPadding="3" width="100%" border="0">
									<tr>
										<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">會員用戶號碼管理</font></font></td>
									</tr>
									<tr align="left">
										<td>
											<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="1">
												<TR>
													<TD width="89"><FONT size="2"><STRONG>註冊日期</STRONG></FONT></TD>
													<TD width="245"><asp:label id="lbladd_datetime" runat="server"  Width="136px"></asp:label></TD>
													<TD><FONT size="2"><STRONG>身份別</STRONG></FONT></TD>
													<TD><asp:label id="lblwm_org_flag" runat="server"  Width="231px"></asp:label></TD>
												</TR>
												<% if gorg<> 1 then %>
												<TR>
													<TD width="89"><FONT face="新細明體" size="2"><STRONG>公司名稱<BR>
																(機關名稱)</STRONG></FONT></TD>
													<TD colSpan="3"><asp:label id="lblwm_user_o_name" runat="server"  Width="128px"></asp:label></TD>
												</TR>
												<% end if %>
												<TR>
													<TD width="89"><FONT size="2"><STRONG>身份證號碼<BR>
																(統一編號)</STRONG></FONT></TD>
													<TD width="245"><asp:label id="lblwm_id" runat="server"  Width="136px"></asp:label><asp:label id="lblwm_no" runat="server" Visible="False">lblwm_no</asp:label></TD>
													<TD><FONT size="2"><STRONG>申請人姓名<BR>
																(承辦人姓名)</STRONG></FONT></TD>
													<TD><asp:label id="lblwm_user_name" runat="server"  Width="231px"></asp:label></TD>
												</TR>
												<TR>
													<TD width="89"><FONT face="新細明體" size="2"><STRONG>連絡電話(O)</STRONG></FONT></TD>
													<TD width="245"><asp:label id="lblwm_tel_o" runat="server"  Width="128px"></asp:label></TD>
													<TD><FONT face="新細明體" size="2"><STRONG>連絡電話(H)</STRONG></FONT></TD>
													<TD><FONT size="2"><asp:label id="lblwm_tel_h" runat="server" Width="120px"></asp:label></FONT></TD>
												</TR>
												<TR>
													<TD width="89"><FONT face="新細明體" size="2"><STRONG>行動電話</STRONG></FONT></TD>
													<TD colSpan="3"><asp:label id="lblwm_mobile" runat="server"  Width="128px"></asp:label></TD>
												</TR>
												<TR>
													<TD width="89"><FONT face="新細明體" size="2"><STRONG>電子郵件</STRONG></FONT></TD>
													<TD colSpan="3"><asp:label id="lblwm_email" runat="server"  Width="128px"></asp:label></TD>
												</TR>
											</TABLE>
											<P align="center">
												<asp:button id="btnReturn" runat="server" Text="返回"></asp:button></P>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td vAlign="top" align="center" width="748">
								<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" align="left"
									border="0">
									<tr>
										<td vAlign="top" align="center"><asp:datagrid id="dgCart" runat="server" Width="704px" CellSpacing="1" GridLines="None" BackColor="White"
												BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="mh_no" AllowPaging="True"
												AutoGenerateColumns="False" AllowSorting="True">
												<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
												<SelectedItemStyle  Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
												<EditItemStyle  Width="600px"></EditItemStyle>
												<AlternatingItemStyle ></AlternatingItemStyle>
												<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
												<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
												<Columns>
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
															<asp:Label id=mh_no runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mh_no") %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="用戶號碼">
														<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
														<ItemTemplate>
															<FONT face="新細明體">
																<asp:Label id=mh_house_no runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mh_house_no") %>'>
																</asp:Label>
															</FONT>
														</ItemTemplate>
													</asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="mh_gen_user" HeaderText="推廣人員">
														<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="user_name" HeaderText="用戶姓名">
														<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="user_addr" HeaderText="用戶地址">
														<HeaderStyle ForeColor="White"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="add_datetime" HeaderText="設定日期">
														<HeaderStyle ForeColor="White" Width="20%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
													Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
											</FONT>
											<p><asp:label id="Message" runat="server"></asp:label></p>
											<P>
												<TABLE id="Table5" cellSpacing="1" borderColorDark="black" cellPadding="1" width="600"
													bgColor="#003399" border="0">
													<TR>
														<TD width="74" bgColor="lavender" height="28"><STRONG><FONT size="2">處理說明</FONT></STRONG></TD>
														<TD width="147" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><asp:textbox id="txtmhis_memo" runat="server" Width="400px" MaxLength="125" Height="136px" TextMode="MultiLine"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD align="center" bgColor="#ffffff" colSpan="4"><asp:button id="btnDelete" runat="server" Text="刪除"></asp:button></TD>
													</TR>
													<TR>
														<TD align="left" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server"  ForeColor="Red"></asp:label></TD>
													</TR>
												</TABLE>
											</P>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
				<td bgcolor="#D2E1F0">&nbsp;</td>
			</tr>
			<tr bgcolor="#000000">
				<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

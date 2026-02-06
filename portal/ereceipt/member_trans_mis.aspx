<%@ Page Language="vb" AutoEventWireup="false" Codebehind="member_trans_mis.aspx.vb" Inherits="member_trans_mis" %>
<HTML>
	<HEAD>
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
		<form id="Form2" runat="server">
			<table>
				<tr>
					<td bgColor="#a6c4e1"></td>
					<td width="930" bgColor="#6699cc"></td>
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
											<td width="559">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">會員資料轉入MIS-Oracle 作業</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" ForeColor="Red" CssClass="normal"></asp:label></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="748">
									<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" CellSpacing="1" GridLines="None" BackColor="White" BorderColor="White"
														CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="wm_no" AllowPaging="True"
														AutoGenerateColumns="False" AllowSorting="True" Width="950px">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="ORGFLAG" ReadOnly="True" HeaderText="身份別">
																<HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_id" HeaderText="身份證號碼(統一編號)">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="add_datetime" HeaderText="異動日期<br>時間">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CHGFLAG" HeaderText="異動別">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_user_name" ReadOnly="True" HeaderText="申請人姓名">
																<HeaderStyle ForeColor="White" Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_house_no" HeaderText="用戶號碼">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_mobile" ReadOnly="True" HeaderText="行動電話">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wm_tel_oo" ReadOnly="True" HeaderText="連絡電話(O)">
																<HeaderStyle Width="15%"></HeaderStyle>
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
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
												</FONT>
												<P><asp:label id="Message" runat="server"></asp:label></P>
												<p><asp:button id="Button1" runat="server" Text="轉入MIS"></asp:button></p>
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

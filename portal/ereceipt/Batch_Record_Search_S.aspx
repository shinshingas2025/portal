<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Batch_Record_Search_S.aspx.vb" Inherits="Batch_Record_Search_S" %>
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
											<td width="534">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">電子繳費憑證批次發送記錄查詢</FONT></FONT></td>
											<td width="361"><font color="red" size="2"><font color="#003366" size="2"></font></font></td>
											<td width="65%">&nbsp;</td>
										</tr>
									</table>
									<asp:label id="msgbox" runat="server" CssClass="normal" ForeColor="Red"></asp:label></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="748">
									<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="left" height="119">
												<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="600" border="2">
													<TR>
														<TD width="74" height="21"><FONT face="新細明體"><asp:label id="Label6" runat="server" Width="72px" Font-Bold="True">批次號碼</asp:label></FONT></TD>
														<TD width="183" height="21"><asp:label id="lblBatchNo" runat="server" Width="144px"></asp:label></TD>
														<TD width="115" height="21"><FONT face="新細明體"><asp:label id="Label4" runat="server" Width="72px" Font-Bold="True">管理者</asp:label></FONT></TD>
														<TD height="21"><asp:label id="lblManager" runat="server" Width="120px"></asp:label></TD>
													</TR>
													<TR>
														<TD width="74"><asp:label id="Label1" runat="server" Width="112px" Font-Bold="True">執行開始時間</asp:label></TD>
														<TD width="183"><asp:label id="lblStartTime" runat="server" Width="152px"></asp:label></TD>
														<TD width="115"><asp:label id="Label7" runat="server" Width="114px" Font-Bold="True">執行結束時間</asp:label></TD>
														<TD><FONT face="新細明體"><asp:label id="lblEndTime" runat="server" Width="173px"></asp:label></FONT></TD>
													</TR>
													<TR>
														<TD width="74"><asp:label id="Label3" runat="server" Width="72px" Font-Bold="True">成功筆數</asp:label></TD>
														<TD width="183"><FONT face="新細明體"><asp:label id="lblSeccess" runat="server" Width="88px"></asp:label></FONT></TD>
														<TD width="115"><asp:label id="Label8" runat="server" Width="72px" Font-Bold="True">失敗筆數</asp:label></TD>
														<TD><FONT face="新細明體"><asp:label id="lblFailure" runat="server" Width="72px"></asp:label></FONT></TD>
													</TR>
												</TABLE>
												<P></P>
												<P>
													<hr>
													<FONT face="新細明體">
														<div align="center">&nbsp;<asp:label id="lblSorF" runat="server" Width="183px" Font-Bold="True">發送成功明細</asp:label></div>
													</FONT>
												<P></P>
											</TD>
										</TR>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="680px" CellSpacing="1" GridLines="None" BackColor="White"
														BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<SelectedItemStyle  Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
															BackColor="#9471DE"></SelectedItemStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="全選">
																<HeaderStyle Width="10%"></HeaderStyle>
																<HeaderTemplate>
																	<asp:CheckBox id="headercheck" onclick="javascript:SelectAll(this);" runat="server" Text="全選"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:CheckBox id="itemcheck" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="HouseNo" HeaderText="用戶編號"></asp:BoundColumn>
															<asp:BoundColumn DataField="ReceiptDate" HeaderText="繳費憑證年月"></asp:BoundColumn>
															<asp:BoundColumn DataField="Email" HeaderText="電子郵件"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="SendEmail" HeaderText="發送信箱"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="WmNo" HeaderText="主檔序號"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="UserName" HeaderText="用戶名稱"></asp:BoundColumn>
															<asp:BoundColumn DataField="WmId" HeaderText="身份證號碼(統一編號)"></asp:BoundColumn>
															<asp:ButtonColumn Text="補寄紙本" HeaderText="處理" CommandName="Select"></asp:ButtonColumn>
															<asp:BoundColumn Visible="False" DataField="RbNo" HeaderText="序號"></asp:BoundColumn>
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
												</DIV>
												<P>
													<asp:Button id="Button2" runat="server" Text="補寄電子檔"></asp:Button></P>
												<FONT face="新細明體">
                                                <br />
                                                <br />
                                                </FONT>
                                                
                                                <asp:Label id="Msg1" runat="server" ForeColor="Blue"></asp:Label>
											</td>
										</tr>
									</table>
									<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
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

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="user_02.aspx.vb" Inherits="user_02" %>
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
											<td width="266">&nbsp;<FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT>
													<FONT color="#003366">自報度數查詢</FONT></FONT></td>
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
											<TD vAlign="top" align="left" height="92">
												<TABLE height="112" cellSpacing="0" cellPadding="0" width="472" border="0" ms_1d_layout="TRUE">
													<TR>
														<TD>
															<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="493" border="0">
																<TR>
																	<TD width="4" height="24"><FONT face="新細明體"><asp:radiobutton id="applydateO" runat="server" CssClass="normal" Width="104px" Text="申請日期" GroupName="AA"
																				Checked="True"></asp:radiobutton></FONT></TD>
																	<TD width="338" height="24"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:20010809)</FONT></TD>
																	<TD width="35" height="24"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="4" height="16"><FONT face="新細明體"><asp:radiobutton id="ProcessDateO" runat="server" CssClass="normal" Width="112px" Text="處理日期" GroupName="AA"></asp:radiobutton></FONT></TD>
																	<TD width="338" height="16"><asp:textbox id="ProcessSDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label4" runat="server">─</asp:label><asp:textbox id="ProcessEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><FONT face="細明體" color="#3399cc" size="2">(Ex:20010809)</FONT></TD>
																	<TD width="35" height="16"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="4" height="19"><FONT face="新細明體"><asp:label id="Label1" runat="server" CssClass="normal" Width="96px">處理情形</asp:label></FONT></TD>
																	<TD width="338" height="19"><FONT face="新細明體"><asp:dropdownlist id="status" runat="server">
																				<asp:ListItem Value="0">未處理</asp:ListItem>
																				<asp:ListItem Value="1">已處理</asp:ListItem>
																			</asp:dropdownlist></FONT></TD>
																	<TD width="35" height="19"><asp:button id="btnSearch" runat="server" Text="查詢 "></asp:button></TD>
																</TR>
																<TR>
																	<TD width="4" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																	<TD width="338" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																	<TD width="35" height="14"><FONT face="新細明體"></FONT></TD>
																</TR>
																<TR>
																	<TD width="4" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																	<TD width="338" height="25"><asp:label id="Creater" runat="server" ></asp:label></TD>
																	<TD width="35" height="25"><FONT face="新細明體"><asp:button id="btnPrint" runat="server" Width="43px" Text="列印"></asp:button></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<hr>
												<asp:button id="YETbtn" runat="server" Text="未處理"></asp:button><asp:button id="OKbtn" runat="server" Text="已處理"></asp:button><FONT face="新細明體"></FONT></TD>
										</TR>
										<tr>
											<td vAlign="top" align="center">
												<DIV align="left"><asp:datagrid id="dgCart" runat="server" Width="550px" CellSpacing="1" GridLines="None" BackColor="White"
														BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="EntityID"
														AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
														<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
														<SelectedItemStyle  Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
															BackColor="#9471DE"></SelectedItemStyle>
														<EditItemStyle  HorizontalAlign="Center" Width="600px"></EditItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
														<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="全選 ">
																<HeaderStyle Width="5%"></HeaderStyle>
																<HeaderTemplate>
																	<asp:CheckBox id="headercheck" onclick="javascript:SelectAll(this);" runat="server"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:CheckBox id=itemcheck runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Status") %>'>
																	</asp:CheckBox>
																</ItemTemplate>
																<EditItemTemplate>
																	<asp:CheckBox id=txtStatus runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Status") %>'>
																	</asp:CheckBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="冊別">
																<HeaderStyle Width="8%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Vol_no") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="用戶號碼">
																<HeaderStyle Width="12%"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label id=AccountNo runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AccountNo") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="SelfNumber" ReadOnly="True" HeaderText="度數">
																<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="telno" HeaderText="聯絡電話">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ReadOnly="True"
																HeaderText="自報日期">
																<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ProcessTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ReadOnly="True"
																HeaderText="處理時間">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="執行單位">
																<HeaderStyle Width="12%"></HeaderStyle>
																<ItemTemplate>
																	<asp:literal runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.groupname") %>'>
																	</asp:literal>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Operator" ReadOnly="True" HeaderText="執行人員">
																<HeaderStyle Width="12%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:EditCommandColumn Visible="False" ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
															<asp:TemplateColumn Visible="False" HeaderText="EntityID">
																<ItemTemplate>
																	<FONT face="新細明體">
																		<asp:Label id=EntityID runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EntityID") %>'>
																		</asp:Label></FONT>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
												<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
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

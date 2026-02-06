<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="contactAdmin.aspx.vb" Inherits="contactAdmin" %>
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
										<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">意見反映指派</font></font></td>
									</tr>
									<tr align="left">
										<td>
											<table height="141" cellSpacing="0" cellPadding="0" width="704" border="0">
												<tr>
													<td width="114">
														<P align="center">&nbsp;<FONT face="新細明體" color="#0066ff">查詢條件</FONT></P>
													</td>
													<td width="444">
														<P align="center">&nbsp;
															<asp:label id="msgbox" runat="server" ForeColor="Red"></asp:label></P>
													</td>
													<TD width="91"><FONT face="新細明體"></FONT></TD>
												</tr>
												<tr>
													<td width="114">&nbsp;
														<asp:radiobutton id="refDate" runat="server" Text="反映日期" Checked="True" GroupName="AA"></asp:radiobutton></td>
													<td width="444">&nbsp;<asp:textbox id="refDateStart" runat="server" MaxLength="8" Width="68px"></asp:textbox><asp:label id="Label1" runat="server">─</asp:label><asp:textbox id="refDateEnd" runat="server" MaxLength="8" Width="68px"></asp:textbox><FONT color="#3399cc">(Ex:20010809)</FONT><FONT face="新細明體"></FONT></td>
													<TD><FONT face="新細明體"></FONT></TD>
												</tr>
												<tr>
													<td width="114">&nbsp;
														<asp:radiobutton id="dealDate" runat="server" Text="處理日期" GroupName="AA"></asp:radiobutton></td>
													<td width="444">&nbsp;<asp:textbox id="dealDateStart" runat="server" MaxLength="8" Width="68px"></asp:textbox><asp:label id="Label2" runat="server">─</asp:label><asp:textbox id="dealDateEnd" runat="server" MaxLength="8" Width="70px"></asp:textbox><FONT color="#3399cc">(Ex:20010809)</FONT></td>
													<TD><FONT face="新細明體"></FONT></TD>
												</tr>
												<tr>
													<td width="114">
														<P align="center">&nbsp;<FONT face="新細明體" size="3">處理狀態</FONT></P>
													</td>
													<td width="444">&nbsp;<asp:dropdownlist id="dealStatus" runat="server">
															<asp:ListItem Value="9" Selected="True">全部</asp:ListItem>
															<asp:ListItem Value="0">未指派</asp:ListItem>
															<asp:ListItem Value="1">處理中</asp:ListItem>
															<asp:ListItem Value="2">已處理</asp:ListItem>
															<asp:ListItem Value="3">已結案</asp:ListItem>
														</asp:dropdownlist></td>
													<TD><asp:button id="inquire" runat="server" Text="查詢"></asp:button></TD>
												</tr>
												<TR>
													<TD width="114">
														<P align="center"><FONT face="新細明體" size="3">意見類別</FONT></P>
													</TD>
													<TD width="444"><FONT face="新細明體">&nbsp;
															<asp:dropdownlist id="cnttype" runat="server">
																<asp:ListItem Value="9" Selected="True">全部</asp:ListItem>
																<asp:ListItem Value="1">一般服務</asp:ListItem>
																<asp:ListItem Value="2">漏氣報修</asp:ListItem>
															</asp:dropdownlist></FONT></TD>
													<TD></TD>
												</TR>												
												<TR>
													<TD width="114"><FONT face="新細明體"><asp:dropdownlist id="likeSelect" runat="server" Width="112px">
																<asp:ListItem Value="cntname" Selected="True">反映人姓名</asp:ListItem>
																<asp:ListItem Value="cnttel">聯絡電話</asp:ListItem>
																<asp:ListItem Value="cntcontent">主旨</asp:ListItem>
																<asp:ListItem Value="cntsubject">內容</asp:ListItem>
															</asp:dropdownlist></FONT></TD>
													<TD width="444"><FONT face="新細明體">&nbsp;</FONT>
														<asp:textbox id="likeContent" runat="server" Width="160px"></asp:textbox></TD>
													<TD></TD>
												</TR>
											</table>
											<hr>
											<table>
												<tr>
													<td><asp:button id="assign" runat="server" Text="指派"></asp:button><asp:button id="noAssign" runat="server" Text="取消指派"></asp:button></td>
													<td><asp:button id="closeCase" runat="server" Text="已辦結"></asp:button><asp:button id="noClose" runat="server" Text="取消辦結"></asp:button></td>
												</tr>
											</table>
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
												BorderColor="White" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" ShowFooter="True" DataKeyField="cntno" AllowPaging="True"
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
													<asp:TemplateColumn Visible="False" HeaderText="編號">
														<ItemTemplate>
															<FONT face="新細明體">
																<asp:Label id=cntno runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cntno") %>'>
																</asp:Label></FONT>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="cntdateno" HeaderText="反映序號">
														<HeaderStyle Width="10px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cntsubject" HeaderText="意見主旨">
														<HeaderStyle ForeColor="White" Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cntcontent" HeaderText="意見內容">
														<HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cntName" HeaderText="姓名">
														<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cnttel" HeaderText="電話">
														<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cntemail" HeaderText="電子郵件">
														<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="createdate" HeaderText="反映日期">
														<HeaderStyle ForeColor="White" Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="status" HeaderText="處理狀態">
														<HeaderStyle Width="8px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="userName" HeaderText="處理人員">
														<HeaderStyle Width="8px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="assigndate" HeaderText="指派日期">
														<HeaderStyle Width="8px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cnttype_name" HeaderText="意見分類">
														<HeaderStyle Width="8px"></HeaderStyle>
													</asp:BoundColumn>													
													<asp:TemplateColumn>
														<ItemTemplate>
															<a href="contactView.aspx?cntno=<%# DataBinder.Eval(Container, "DataItem.cntno") %>">內容</a>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle  Font-Names="細明體" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"
													Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
											</FONT>
											<p><asp:label id="Message" runat="server"></asp:label></p>
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
				<td bgcolor="#D2E1F0">&nbsp;</td>
			</tr>
			<tr bgcolor="#000000">
				<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

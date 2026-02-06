<%@ Page Language="vb" AutoEventWireup="false" Codebehind="contact_report.aspx.vb" Inherits="contact_report" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<HTML>
	<body>
		<form id="Form1" runat="server">
			<!-- NAME: index.tpl -->
			<tr>
				<td bgcolor="#A6C4E1"></td>
				<td bgcolor="#6699CC" width="930"></td>
				<td bgcolor="#A6C4E1"></td>
			</tr>
			<tr>
				<td bgcolor="#D2E1F0"></td>
				<td width="930">
					<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
						<tr>
							<td vAlign="middle" align="center" height="161">
								<table cellSpacing="0" cellPadding="3" width="100%" border="0">
									<tr>
										<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">意見反映查詢列表</font></font></td>
									</tr>
									<tr align="left">
										<td>
											<table height="141" cellSpacing="0" cellPadding="0" width="704" border="0">
												<tr>
													<td width="93">
														<P align="center">&nbsp;<FONT face="新細明體" color="#0066ff">查詢條件</FONT></P>
													</td>
													<td width="489">
														<P align="center">&nbsp;
															<asp:label id="msgbox" runat="server" ForeColor="Red"></asp:label></P>
													</td>
													<TD width="91"></TD>
												</tr>
												<tr>
													<td width="93">&nbsp;
														<asp:radiobutton id="refDate" runat="server" Text="反映日期" Checked="True" GroupName="AA"></asp:radiobutton></td>
													<td width="489">&nbsp;
														<asp:textbox id="refDateStart" runat="server" MaxLength="8" Width="68px"></asp:textbox><asp:label id="Label1" runat="server">─</asp:label><asp:textbox id="refDateEnd" runat="server" MaxLength="8" Width="68px"></asp:textbox><FONT color="#3399cc">(Ex:20010809)</FONT><FONT face="新細明體"></FONT></td>
													<TD><FONT face="新細明體"></FONT></TD>
												</tr>
												<TR>
													<td width="93">
														<P align="right"><FONT face="新細明體">
																<asp:radiobutton id="dealDate" runat="server" GroupName="AA" Text="處理日期" Visible="True"></asp:radiobutton></FONT></P>
													</td>
													<td width="489"><FONT face="新細明體">&nbsp;</FONT>
														<asp:textbox id="dealDateStart" runat="server" Width="68px" MaxLength="8" Visible="True"></asp:textbox>
														<asp:label id="Label2" runat="server" Visible="True">─</asp:label>
														<asp:textbox id="dealDateEnd" runat="server" Width="70px" MaxLength="8" Visible="True"></asp:textbox></td>
													<TD></TD>
												</TR>
												<TR>
													<td width="93" height="25">
														<P align="right"><FONT face="新細明體">
																<asp:radiobutton id="closeDate" runat="server" GroupName="AA" Text="結案日期" Visible="True"></asp:radiobutton></FONT></P>
													</td>
													<td width="489" height="25"><FONT face="新細明體">&nbsp;</FONT>
														<asp:textbox id="closeDateStart" runat="server" Width="68px" MaxLength="8" Visible="True"></asp:textbox>
														<asp:label id="Label3" runat="server" Visible="True">─</asp:label>
														<asp:textbox id="closeDateEnd" runat="server" Width="70px" MaxLength="8" Visible="True"></asp:textbox></td>
													<TD height="25"><FONT face="新細明體"></FONT></TD>
												</TR>
												<tr>
													<td width="93">
														<P align="right">&nbsp; 案件狀態</P>
													</td>
													<td width="489">&nbsp;
														<asp:dropdownlist id="dealStatus" runat="server">
															<asp:ListItem Value="9" Selected="True">全部</asp:ListItem>
															<asp:ListItem Value="0">未指派</asp:ListItem>
															<asp:ListItem Value="1">處理中</asp:ListItem>
															<asp:ListItem Value="2">已處理</asp:ListItem>
															<asp:ListItem Value="3">已結案</asp:ListItem>
														</asp:dropdownlist></td>
													<TD><FONT face="新細明體"></FONT></TD>
												</tr>
												<TR>
													<TD width="93"><FONT face="新細明體">
															<P align="center"><FONT face="新細明體" size="3">意見類別</FONT></P>
														</FONT>
													</TD>
													<TD width="489"><FONT face="新細明體">&nbsp;
															<asp:dropdownlist id="cnttype" runat="server">
																<asp:ListItem Value="9" Selected="True">全部</asp:ListItem>
																<asp:ListItem Value="1">一般服務</asp:ListItem>
																<asp:ListItem Value="2">漏氣報修</asp:ListItem>
															</asp:dropdownlist></FONT></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD width="94">
														<asp:dropdownlist id="likeSelect" runat="server" Width="112px" Visible="False">
															<asp:ListItem Value="cntname" Selected="True">反映人姓名</asp:ListItem>
															<asp:ListItem Value="cnttel">聯絡電話</asp:ListItem>
															<asp:ListItem Value="cntcontent">主旨</asp:ListItem>
															<asp:ListItem Value="cntsubject">內容</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD width="489"><FONT face="新細明體">&nbsp;</FONT>
														<asp:textbox id="likeContent" runat="server" Width="160px" Visible="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD width="94"></TD>
													<TD width="489"><FONT face="新細明體"></FONT></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD width="94"></TD>
													<TD width="489"><FONT face="新細明體">
															<asp:button id="inquire" runat="server" Text="ㄧ般列印"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:button id="Button1" runat="server" Text=" 簡要列印"></asp:button></FONT></TD>
													<TD></TD>
												</TR>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<TR>
							<TD vAlign="top" align="center" width="748">
								<p><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><br>
								</p>
								<p><FONT face="新細明體"></FONT></p>
							</TD>
						</TR>
					</table>
				</td>
				<td bgcolor="#D2E1F0">&nbsp;</td>
			</tr>
			<tr bgcolor="#000000">
				<td height="1" colspan="3" bgColor="#000000"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

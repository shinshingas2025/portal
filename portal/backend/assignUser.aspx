<%@ Page Language="vb" AutoEventWireup="false" Codebehind="assignUser.aspx.vb" Inherits="assignUser" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="_Header.ascx" %>
<HTML>
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
										<td height="143">
											<table height="113" cellSpacing="0" cellPadding="0" width="704" border="0">
												<tr>
													<TD width="114"><FONT face="新細明體"><FONT face="新細明體">請選擇單位：</FONT></FONT></TD>
													<TD width="166"><asp:dropdownlist id="groupName" runat="server" Width="144px" AutoPostBack="True"></asp:dropdownlist></TD>
													<td width="153">&nbsp;<FONT face="新細明體">請選擇欲指派的人：</FONT></td>
													<td width="146">
														<P align="center">&nbsp;
															<asp:dropdownlist id="userName" runat="server" Width="136px"></asp:dropdownlist></P>
													</td>
													<TD width="91"></TD>
												</tr>
												<tr>
													<TD width="114"><asp:button id="confirm" runat="server" Text="確定"></asp:button></TD>
													<TD width="166"></TD>
													<td width="153">&nbsp;</td>
													<td width="146">&nbsp;</td>
													<TD><FONT face="新細明體"></FONT></TD>
												</tr>
												<tr>
													<TD width="114"></TD>
													<TD width="166"></TD>
													<td width="153">
														<P align="center"><FONT face="新細明體"></FONT>&nbsp;</P>
													</td>
													<td width="146">&nbsp;</td>
													<TD></TD>
												</tr>
											</table>
											<asp:label id="msgbox" runat="server" ForeColor="Red"></asp:label></td>
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

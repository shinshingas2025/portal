<%@ Page Language="vb" AutoEventWireup="false" Codebehind="wmember_02.aspx.vb" Inherits="wmember_02" %>
<%@ Register TagPrefix="uc1" TagName="NewMenu" Src="../backend/_NewMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../backend/_footer.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="Header" Src="../backend/_Header.ascx" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<table>
				<tr>
					<td><FONT face="新細明體"></FONT></td>
					<td width="930">
						<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
							<tr>
								<td vAlign="middle" align="center">
									<P align="left"><FONT color="red" size="2"><FONT color="#003366" size="2"><FONT color="red" size="2"><B>&nbsp; 
														&gt;&gt;</B> <FONT color="#003366" size="2">RW016會員異動資料明細表</FONT></FONT></FONT></FONT></P>
								</td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="748">
									<DIV align="left">
										<table id="Table4" cellSpacing="4" cellPadding="4" width="679" align="left" border="0">
											<TBODY>
												<TR>
													<TD vAlign="top" align="left">
														<TABLE id="Table2" height="82" cellSpacing="0" cellPadding="0" width="493" border="0">
															<TR>
																<TD width="4" height="23"><FONT face="新細明體"></FONT></TD>
																<TD width="366" height="23">
																	<P align="center"><asp:label id="msgbox" runat="server" Width="366" ForeColor="Red" CssClass="normal"></asp:label></P>
																</TD>
																<TD width="35" height="23"></TD>
															</TR>
															<TR>
																<TD width="4" height="16"><FONT face="新細明體"><asp:label id="applydateO" runat="server" Width="104px" Text="異動日期"></asp:label></FONT></TD>
																<TD width="366" height="16"><asp:textbox id="ApplySDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><asp:label id="Label3" runat="server">─</asp:label><asp:textbox id="ApplyEDATE" runat="server" Width="86px" MaxLength="8"></asp:textbox><BR>
																	<FONT face="細明體" color="#3399cc" size="2">(Ex:990809，空白表全部)</FONT></TD>
																<TD width="35" height="16"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="16"><FONT face="新細明體"><asp:label id="ProcessDateO" runat="server" Width="160px" CssClass="normal" Text="身份證號碼(統一編號)"></asp:label></FONT></TD>
																<TD width="366" height="16"><asp:textbox id="wm_id" runat="server" Width="100px" MaxLength="10"></asp:textbox></TD>
																<TD width="35" height="16"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="19"><FONT face="新細明體"><asp:label id="Label1" runat="server" Width="96px" CssClass="normal">管理者</asp:label></FONT></TD>
																<TD width="366" height="16"><asp:textbox id="add_user" runat="server" Width="100px" MaxLength="30"></asp:textbox></TD>
																<TD width="35" height="19"></TD>
															</TR>
															<TR>
																<TD width="4" height="14"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label2" runat="server" Width="72px">執行單位</asp:label></STRONG></FONT></TD>
																<TD width="366" height="14"><FONT face="新細明體"><asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
																<TD width="35" height="14"><FONT face="新細明體"></FONT></TD>
															</TR>
															<TR>
																<TD width="4" height="25"><FONT face="新細明體"><FONT face="新細明體" size="2"><STRONG><asp:label id="Label5" runat="server" Width="64px">執行人員</asp:label></STRONG></FONT></FONT></TD>
																<TD width="366" height="25"><asp:label id="Creater" runat="server" ></asp:label></TD>
																<TD width="35" height="25"><FONT face="新細明體"><asp:button id="btnPrint" runat="server" Width="43px" Text="列印"></asp:button></FONT></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
								</td>
							</tr>
						</table>
						</DIV> <FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
						<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
						<P align="left"><FONT face="新細明體"></FONT><br>
						</P>
						<p align="left"><FONT face="新細明體"></FONT></p>
					</td>
				</tr>
			</table>
			</TD>
			<td>&nbsp;</td>
			</TR></TBODY></TABLE>
			<uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

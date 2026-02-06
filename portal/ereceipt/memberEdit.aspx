<%@ Page Language="vb" AutoEventWireup="false" Codebehind="memberEdit.aspx.vb" Inherits="memberEdit" codePage="65001" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../backend/_footer.ascx" %>
<HTML>
	<META http-equiv="Content-Type" content="text/html; charset=utf-8">
	<body>
		<form id="Form1" method="post" runat="server">
			<table>
				<!-- NAME: index.tpl -->
				<TBODY>
					<tr>
						<td bgColor="#a6c4e1"><FONT face="新細明體"></FONT></td>
						<td width="930" bgColor="#6699cc"><FONT face="新細明體"></FONT></td>
						<td bgColor="#a6c4e1"></td>
					</tr>
					<tr>
						<td bgColor="#d2e1f0"></td>
						<td width="930">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
								<TBODY>
									<tr>
										<td vAlign="middle" align="left" height="45">
											<table cellSpacing="0" cellPadding="3" width="100%" border="0">
												<tr>
													<td width="94">&nbsp;</td>
													<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">會員基本資料管理</font></font></td>
													<td width="65%">&nbsp;</td>
												</tr>
											</table>
											<FONT face="新細明體">會員資料修改</FONT>
										</td>
									</tr>
									<tr>
										<td vAlign="top" align="center" width="748">
											<table id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%" border="0">
												<TBODY>
													<tr>
														<td vAlign="top" align="center">
															<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
															</FONT>
															<p><asp:label id="Message" runat="server"></asp:label>
															</p>
															<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TBODY>
																	<TR>
																		<TD><FONT face="新細明體" size="2"><STRONG>會員狀態:</STRONG></FONT></TD>
																		<TD colSpan="3"><asp:label id="OPENFLAG" runat="server" ></asp:label></TD>
																	</TR>
																	<TR>
																		<TD><STRONG><FONT size="2">身份別:</FONT></STRONG></TD>
																		<TD colSpan="3"><asp:label id="ORGFLAG" runat="server" ></asp:label></TD>
																	</TR>
																	<TR>
																		<TD><FONT size="2"><STRONG>身份證字號(統一編號):</STRONG></FONT></TD>
																		<TD colSpan="3"><asp:label id="wm_id" runat="server" ></asp:label><asp:label id="wm_no" runat="server" Visible="False" ></asp:label></TD>
																	</TR>
																	<TR>
																		<TD><FONT size="2"><STRONG>公司名稱(機關名稱):</STRONG></FONT></TD>
																		<TD colSpan="3"><asp:textbox id="wm_user_o_name" runat="server" Width="235px" MaxLength="125"></asp:textbox><asp:textbox id="wm_user_o_name_org" Visible="false" Enabled="False" runat="server" Width="81px"></asp:textbox></TD>
																	</TR>
																	<TR>
																	</TR>
																	<TR>
																		<TD><FONT size="2"><STRONG>用戶姓名(承辦人姓名):</STRONG></FONT></TD>
																		<TD colSpan="3"><asp:textbox id="wm_user_name" runat="server" MaxLength="50"></asp:textbox><asp:textbox id="wm_user_name_org" Visible="false" Enabled="False" runat="server"></asp:textbox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" Font-Size="10" ErrorMessage="(承辦人姓名是必填欄位)"
																				ControlToValidate="wm_user_name"></asp:RequiredFieldValidator></TD>
																	</TR>
																	<TR>
																		<TD><FONT face="新細明體" size="2"><STRONG>連絡電話(O):</STRONG></FONT></TD>
																		<TD colSpan="3"><asp:textbox id="wm_tel_o1" runat="server" Width="30px" MaxLength="3"></asp:textbox><FONT size="2">－</FONT><asp:textbox id="wm_tel_o3" runat="server" Width="100px" MaxLength="8"></asp:textbox><FONT size="2">分機:</FONT><asp:textbox id="wm_tel_o2" runat="server" Width="50px" MaxLength="5"></asp:textbox><asp:textbox id="wm_tel_o_org" Visible="false" Enabled="False" runat="server"></asp:textbox><asp:textbox id="wm_tel_o2_org" Visible="false" Enabled="False" runat="server"></asp:textbox>
																		</TD>
																	</TR>
																	<TR>
																		<TD><FONT face="新細明體" size="2"><STRONG>連絡電話(H):</STRONG></FONT></TD>
																		<TD><asp:textbox id="wm_tel_h1" runat="server" Width="30px" MaxLength="3"></asp:textbox><FONT size="2">－</FONT><asp:textbox id="wm_tel_h3" runat="server" Width="100px" MaxLength="8"></asp:textbox><asp:textbox id="wm_tel_h_org" Visible="false" Enabled="False" runat="server"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD><FONT face="新細明體" size="2"><STRONG>行動電話:</STRONG></FONT></TD>
																		<TD><asp:textbox id="wm_mobile" runat="server" Width="138px" MaxLength="10"></asp:textbox><asp:textbox id="wm_mobile_org" Visible="false" Enabled="False" runat="server"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD><FONT face="新細明體" size="2"><STRONG>電子信箱:</STRONG></FONT></TD>
																		<TD><asp:textbox id="wm_email" runat="server" Width="200px"></asp:textbox>
																			<asp:Button ID="button1" text="檢核信箱" runat="server"></asp:Button>
																			<asp:textbox id="wm_email_org" Visible="false" Enabled="False" runat="server"></asp:textbox>
																			<asp:Label id="Label1" runat="server"  ForeColor="Red"></asp:Label>
																			<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="wm_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
																				ErrorMessage="RegularExpressionValidator">(格式不符)</asp:regularexpressionvalidator>
																			<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic" Font-Size="10" ErrorMessage="(電子信箱是必填欄位)"
																				ControlToValidate="wm_email"></asp:RequiredFieldValidator></TD>
																		<FONT size="2"></FONT>
														</td>
													</tr>
													<TR>
														<TD height="32"><FONT face="新細明體" size="2"><STRONG>是否另寄紙本繳費憑證:</STRONG></FONT></TD>
														<TD height="32">&nbsp;
															<asp:radiobutton id="rb_paper_flag_1" runat="server" Width="41px" Text="是" GroupName="rbPAPERFLAG"
																Height="20px"></asp:radiobutton><asp:radiobutton id="rb_paper_flag_2" runat="server" Width="41px" Text="否" Checked="True" GroupName="rbPAPERFLAG"
																Height="20px"></asp:radiobutton><asp:textbox id="wm_paper_flag_org" Visible="False" Enabled="False" runat="server"></asp:textbox></TD>
													</TR>
													<TR>
														<TD><FONT face="新細明體" size="2"><STRONG>處理說明</STRONG></FONT></TD>
														<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="mhismemo" runat="server" Columns="50" Rows="5" MaxLength="255" TextMode="MultiLine"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD colSpan="4">
															<P align="center"><FONT face="新細明體"><asp:button id="btnupdate" runat="server" Text="確定送出"></asp:button><asp:button id="btnreturn" runat="server" Text="返回"></asp:button></FONT></P>
														</TD>
													</TR>
												</TBODY></table>
										</td>
									</tr>
								</TBODY></table>
							<FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
							</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
							<P align="left"><asp:label id="txtresult" runat="server"  ForeColor="Red"></asp:label></P>
							<p><FONT face="新細明體"></FONT></p>
						</td>
					</tr>
				</TBODY></table>
			</TD>
			<td bgColor="#d2e1f0">&nbsp;</td>
			</TR>
			<tr bgColor="#000000">
				<td bgColor="#000000" colSpan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer>
			<FONT face="新細明體"></FONT></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></form>
	</body>
</HTML>

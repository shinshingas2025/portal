<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="contactEdit.aspx.vb" Inherits="contactEdit" %>
<HTML>
	<body>
		<form id="Form1" method="post" runat="server">
			<table>
				<!-- NAME: index.tpl -->
				<TBODY>
					<tr>
						<td bgcolor="#a6c4e1"><FONT face="新細明體"></FONT></td>
						<td bgcolor="#6699cc" width="930"></td>
						<td bgcolor="#a6c4e1"></td>
					</tr>
					<tr>
						<td bgcolor="#d2e1f0"></td>
						<td width="930">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="930" border="0">
								<TBODY>
									<tr>
										<td vAlign="middle" align="center" height="45">
											<table cellSpacing="0" cellPadding="3" width="100%" border="0">
												<tr>
													<td width="94">&nbsp;</td>
													<td width="26%"><font color="red" size="2"><b>&gt;&gt;</b> <font color="#003366" size="2">意見反映查詢</font></font></td>
													<td width="65%">&nbsp;</td>
												</tr>
											</table>
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
		</form>
		</P>
		<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
			<TR>
				<TD><FONT face="新細明體" size="2"><STRONG>編號</STRONG></FONT></TD>
				<TD colSpan="3"><asp:label id="cntno" runat="server" ></asp:label></TD>
			</TR>
			<TR>
				<TD><STRONG><FONT size="2">反映主旨</FONT></STRONG></TD>
				<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="cntsubject" runat="server" Width="376px" TextMode="MultiLine" ReadOnly="True"></asp:textbox></FONT></TD>
			</TR>
			<TR>
				<TD><FONT size="2"><STRONG>姓名</STRONG></FONT></TD>
				<TD>
					<asp:textbox id="cntName" runat="server" Width="138px" ReadOnly="True"></asp:textbox></TD>
				<TD><FONT size="2"><STRONG>電子郵件</STRONG></FONT></TD>
				<TD>
					<asp:textbox id="cntemail" runat="server" Width="235px" ReadOnly="True"></asp:textbox></TD>
			</TR>
			<TR>
				<TD><FONT face="新細明體" size="2"><STRONG>連絡電話</STRONG></FONT></TD>
				<TD>
					<asp:textbox id="cnttel" runat="server" Width="138px" ReadOnly="True"></asp:textbox></TD>
				<TD><FONT face="新細明體" size="2"><STRONG>反映日期</STRONG></FONT></TD>
				<TD>
					<asp:textbox id="createdate" runat="server" Width="138px" ReadOnly="True"></asp:textbox><FONT size="2">(如：2005/01/01)</FONT></TD>
			</TR>
			<TR>
				<TD><FONT face="新細明體" size="2"><STRONG>內容</STRONG></FONT></TD>
				<TD colSpan="3"><FONT face="新細明體">
						<asp:textbox id="cntcontent" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:textbox></FONT></TD>
			</TR>
			<TR>
				<TD colSpan="4" height="9"><FONT face="新細明體">
						<HR width="100%" SIZE="1">
					</FONT>
				</TD>
			</TR>
			<TR>
				<TD><FONT size="2"><STRONG>處理單位</STRONG></FONT></TD>
				<TD><FONT face="新細明體">
						<asp:label id="createGroup" runat="server" ></asp:label></FONT></TD>
				<TD><STRONG><FONT size="2">處理人員</FONT></STRONG></TD>
				<TD><FONT face="新細明體">
						<asp:label id="Creater" runat="server" ></asp:label></FONT></TD>
			</TR>
			<TR>
				<TD><STRONG><FONT size="2">處理情形</FONT></STRONG></TD>
				<TD>
					<asp:DropDownList id="workstatus" runat="server">
						<asp:ListItem Value="" Selected="True">未處理</asp:ListItem>
						<asp:ListItem Value="1">已處理</asp:ListItem>
					</asp:DropDownList></TD>
				<TD><FONT size="2"><STRONG>處理日期</STRONG></FONT></TD>
				<TD><FONT face="新細明體">
						<asp:textbox id="workdate" runat="server" Width="138px"></asp:textbox><FONT size="2">(如：2005/01/01)</FONT></FONT></TD>
			</TR>
			<TR>
				<TD height="21"><FONT size="2"><STRONG>備註</STRONG></FONT></TD>
				<TD colSpan="3" height="21"><FONT face="新細明體">
						<asp:textbox id="remark" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:textbox></FONT></TD>
			</TR>
			<TR>
				<TD colSpan="4">
					<P align="center"><FONT face="新細明體">
							<asp:button id="btnupdate" runat="server" Text="修改"></asp:button>
							<asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button></FONT></P>
				</TD>
			</TR>
		</TABLE>
		</TD></TR></TBODY></TABLE> <FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體">
		</FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
		<P><br>
		</P>
		<p><FONT face="新細明體"></FONT></p>
		</TD></TR></TBODY></TABLE></TD>
		<td bgcolor="#d2e1f0">&nbsp;</td>
		</TR>
		<tr bgcolor="#000000">
			<td bgColor="#000000" colspan="3" height="1"><IMG height="1" alt="" src="images/spacer.gif" width="4" border="0"></td>
		</tr>
		<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer><FONT face="新細明體"></FONT></TBODY></TABLE></body>
</HTML>

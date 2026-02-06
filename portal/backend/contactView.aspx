<%@ Page Language="vb" AutoEventWireup="false" Codebehind="contactView.aspx.vb" Inherits="contactView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>contactMgt</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%">
				<TR>
					<TD width="94">&nbsp;</TD>
					<TD width="26%"><FONT color="red" size="2"><B>&gt;&gt;</B> <FONT color="#003366" size="2">意見反映內容</FONT></FONT></TD>
					<TD width="65%">&nbsp;</TD>
				</TR>
			</TABLE>
			<TABLE id="Table4" height="320" cellSpacing="4" cellPadding="4" width="95%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<%--<P><FONT face="新細明體"><asp:button id="btnFirstPage" runat="server" ToolTip="檢視第一頁資料" CommandName="第一頁" Text="第一頁"></asp:button><asp:button id="btnPreviousPage" runat="server" ToolTip="檢視上一頁資料" CommandName="上一頁" Text="上一頁"></asp:button><asp:button id="btnNextPage" runat="server" ToolTip="檢視下一頁資料" CommandName="下一頁" Text="下一頁"></asp:button><asp:button id="btnLastPage" runat="server" ToolTip="檢視最後一頁資料" CommandName="最後一頁" Text="最後一頁"></asp:button><BR>
									</P>--%>
							</FONT>
							<P><asp:label id="Message" runat="server"></asp:label></P>
							<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="1">
								<TR>
									<TD width="61"><FONT face="新細明體" size="2"><STRONG>編號</STRONG></FONT></TD>
									<TD colSpan="3"><asp:label id="cntno" runat="server" ></asp:label></TD>
								</TR>
								<TR>
									<TD width="61"><FONT face="新細明體" size="2"><STRONG>反映序號</STRONG></FONT></TD>
									<TD colSpan="3"><asp:label id="cntdateno" runat="server"  Width="104px"></asp:label></TD>
								</TR>
								<TR>
									<TD width="61"><STRONG><FONT size="2">反映主旨</FONT></STRONG></TD>
									<TD colSpan="3"><FONT face="新細明體"><asp:label id="cntsubject" runat="server"  Width="432px"></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD width="61"><FONT size="2"><STRONG>姓名</STRONG></FONT></TD>
									<TD width="245"><asp:label id="cntName" runat="server"  Width="136px"></asp:label></TD>
									<TD><FONT size="2"><STRONG>電子郵件</STRONG></FONT></TD>
									<TD><asp:label id="cntemail" runat="server"  Width="231px"></asp:label></TD>
								</TR>
								<TR>
									<TD width="61"><FONT face="新細明體" size="2"><STRONG>連絡電話</STRONG></FONT></TD>
									<TD width="245"><asp:label id="cnttel" runat="server"  Width="128px"></asp:label></TD>
									<TD><FONT face="新細明體" size="2"><STRONG>反映日期</STRONG></FONT></TD>
									<TD><FONT size="2"><asp:label id="createdate" runat="server" Width="120px"></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD width="61"><FONT face="新細明體" size="2"><STRONG>內容</STRONG></FONT></TD>
									<TD colSpan="3"><FONT face="新細明體"><asp:label id="cntcontent" runat="server"  Width="423px" Height="20px"></asp:label></FONT></TD>
								</TR>
								<!--<TR>
									<TD colSpan="4" height="9"></TD>
								</TR>--></TABLE>
							<br>
							<TABLE id="Table3" height="476" cellSpacing="0" cellPadding="1" width="658" border="1">
								<TR>
									<TD width="207"><STRONG><FONT size="2">處理狀態</FONT></STRONG></TD>
									<TD colSpan="5"><asp:label id="workstatus" runat="server"  Width="112px"></asp:label><FONT face="新細明體"></FONT><STRONG><FONT size="2"></FONT></STRONG><FONT face="新細明體"></FONT></TD>
								</TR>
								<TR>
									<TD width="207"><FONT size="2"><STRONG>初次處理單位</STRONG></FONT></TD>
									<TD><asp:label id="createGroup" runat="server"  Width="128px"></asp:label></TD>
									<TD><STRONG><FONT size="2">初次處理人員</FONT></STRONG></TD>
									<TD><FONT face="新細明體"><asp:label id="myoperator" runat="server"  Width="160px"></asp:label></FONT></TD>
									<TD><FONT size="2"><STRONG>初次處理日期</STRONG></FONT></TD>
									<TD><FONT face="新細明體"><FONT size="2"><asp:label id="workDate" runat="server"  Width="160px"></asp:label></FONT></FONT></TD>
								</TR>
								<TR>
									<TD width="207"><FONT size="2"><STRONG>最後處理單位</STRONG></FONT></TD>
									<TD><asp:label id="lastGroup" runat="server"  Width="128px"></asp:label></TD>
									<TD><FONT face="新細明體"><STRONG><FONT size="2">最後處理人員</FONT></STRONG></FONT></TD>
									<TD><FONT face="新細明體"><asp:label id="lastOperator" runat="server"  Width="160px"></asp:label></FONT></TD>
									<TD><FONT size="2"><STRONG>最後處理日期</STRONG></FONT></TD>
									<TD><FONT face="新細明體"><FONT size="2"><asp:label id="lastWorkDate" runat="server" Width="160px"></asp:label></FONT></FONT></TD>
								</TR>
								<TR>
									<TD width="207"><FONT size="2"><STRONG>結案處理單位</STRONG></FONT></TD>
									<TD><asp:label id="endGroup" runat="server"  Width="128px"></asp:label></TD>
									<TD><FONT face="新細明體"><FONT face="新細明體"><STRONG><FONT size="2">結案處理人員</FONT></STRONG></FONT></FONT></TD>
									<TD><FONT face="新細明體"><asp:label id="endOperator" runat="server"  Width="160px"></asp:label></FONT></TD>
									<TD><FONT face="新細明體"><STRONG><FONT size="2">結案處理日期</FONT></STRONG></FONT></TD>
									<TD><FONT face="新細明體"><FONT size="2"><asp:label id="endWorkDate" runat="server"  Width="160px"></asp:label></FONT></FONT></TD>
								</TR>
								<TR>
									<TD width="207" height="164"><FONT size="2"><STRONG>處理情形</STRONG></FONT></TD>
									<TD colSpan="5" height="164"><FONT face="新細明體"><asp:textbox id="remark" runat="server" Width="545px" Height="154px" TextMode="MultiLine" Enabled="False"></asp:textbox></FONT></TD>
								</TR>
								<TR>
									<TD colSpan="6">
										<P align="center"><FONT face="新細明體"><asp:button id="btnupdate" runat="server" Text="修改" Visible="False" Enabled="False"></asp:button><asp:button id="btnupdatecel" runat="server" Text="返回"></asp:button><asp:button id="print" runat="server" Text="列印"></asp:button></FONT></P>
									</TD>
								</TR>
							</TABLE>
							<P align="left"><asp:label id="txtresult" runat="server"  ForeColor="Red"></asp:label></P>
						</TD>
					</TR>
				</TBODY></TABLE>
		</form>
	</body>
</HTML>

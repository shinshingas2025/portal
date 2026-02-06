<%@ Register TagPrefix="uc1" TagName="footer" Src="_footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Contact_deatail_report.aspx.vb" Inherits="Contact_deatail_report"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Contact_deatail_report</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server"> <!-- NAME: index.tpl --><tr>
				<td bgcolor="#A6C4E1"></td>
				<td bgcolor="#6699CC" width="930"></td>
				<td bgcolor="#A6C4E1"></td>
			</tr>
			<tr>
				<td bgcolor="#D2E1F0"></td>
				<td width="930">
					<TABLE id="Table1" height="384" cellSpacing="0" cellPadding="0" width="698" border="0">
						<tr>
							<td vAlign="top" align="center" width="864">
								<table height="141" cellSpacing="0" cellPadding="0" width="704" border="0">
									<tr>
										<td width="150">
											<P align="center">&nbsp;<FONT face="新細明體" color="#0066ff">網站意見反映列表</FONT></P>
										</td>
										<td width="472">
											<P align="center">&nbsp;</P>
										</td>
										<TD width="91"></TD>
									</tr>
									<tr>
										<td width="150">&nbsp;
											<asp:radiobutton id="refDate" runat="server" Text="反映日期" Checked="True" GroupName="AA"></asp:radiobutton></td>
										<td width="472">&nbsp;
											<asp:textbox id="refDateStart" runat="server" MaxLength="8" Width="68px"></asp:textbox><asp:label id="Label1" runat="server">─</asp:label><asp:textbox id="refDateEnd" runat="server" MaxLength="8" Width="68px"></asp:textbox><FONT color="#3399cc">(Ex:20010809)</FONT><FONT face="新細明體"></FONT></td>
										<TD><FONT face="新細明體"></FONT></TD>
									</tr>
									<tr>
										<td width="150">&nbsp;
											<asp:radiobutton id="dealDate" runat="server" Text="處理日期" GroupName="AA"></asp:radiobutton></td>
										<td width="472">&nbsp;
											<asp:textbox id="dealDateStart" runat="server" MaxLength="8" Width="68px"></asp:textbox><asp:label id="Label2" runat="server">─</asp:label><asp:textbox id="dealDateEnd" runat="server" MaxLength="8" Width="70px"></asp:textbox><FONT color="#3399cc">(Ex:20010809)</FONT></td>
										<TD><FONT face="新細明體"></FONT></TD>
									</tr>
									<tr>
										<td width="150">
											<P align="center">&nbsp;<FONT face="新細明體" size="3">處理狀態</FONT></P>
										</td>
										<td width="472"><FONT face="新細明體">&nbsp;</FONT>
											<asp:dropdownlist id="dealStatus" runat="server">
												<asp:ListItem Value="9" Selected="True">全部</asp:ListItem>
												<asp:ListItem Value="0">未指派</asp:ListItem>
												<asp:ListItem Value="1">處理中</asp:ListItem>
												<asp:ListItem Value="2">已處理</asp:ListItem>
												<asp:ListItem Value="3">已結案</asp:ListItem>
											</asp:dropdownlist></td>
										<TD></TD>
									</tr>
									<TR>
										<TD width="150">
											<P align="center"><asp:dropdownlist id="likeSelect" runat="server" Width="112px">
													<asp:ListItem Value="cntname" Selected="True">反映人姓名</asp:ListItem>
													<asp:ListItem Value="cnttel">聯絡電話</asp:ListItem>
													<asp:ListItem Value="cntcontent">主旨</asp:ListItem>
													<asp:ListItem Value="cntsubject">內容</asp:ListItem>
												</asp:dropdownlist></P>
										</TD>
										<TD width="472"><FONT face="新細明體">&nbsp;</FONT>
											<asp:textbox id="likeContent" runat="server" Width="160px"></asp:textbox></TD>
										<TD><asp:button id="inquire" runat="server" Text="列印"></asp:button></TD>
									</TR>
								</table>
							</td>
						</tr>
					</TABLE>
				</td>
				<td bgcolor="#D2E1F0"></td>
			</tr>
			<tr bgcolor="#000000">
				<td bgColor="#000000" colspan="3" height="1"></td>
			</tr>
			<!-- END: index.tpl --><uc1:footer id="_footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

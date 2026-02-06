<%@ Page Language="vb" AutoEventWireup="false" Codebehind="member_trans_mis_result.aspx.vb" Inherits="member_trans_mis_result" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>member_trans_mis_result</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="600" border="0" align="center">
					<TR>
						<TD>
							<P><FONT face="新細明體"><FONT size="2"><FONT color="#ff0000"><STRONG>&gt;&gt;</STRONG> </FONT><FONT color="#003366">
											會員基本資料轉入MIS(Oracle)作業</FONT></FONT></FONT></P>
						</TD>
					</TR>
				</TABLE>
				<br>
				<table id="table2" width="600" cellspacing="0" cellpadding="0" border="1" align="center">
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">總筆數</FONT></td>
						<td><asp:Label id="lblTotalC" runat="server"></asp:Label>筆</FONT></td>
					</tr>
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">執行成功</FONT></td>
						<td><asp:Label id="lblSuccess" runat="server"></asp:Label>筆 </FONT></td>
					</tr>
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">不須更新</FONT></td>
						<td><asp:Label id="lblskipCount" runat="server"></asp:Label>筆 </FONT>
						</td>
					</tr>
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">不須更新用戶號碼:</FONT>
						</td>
						<td><asp:Label id="lblskip_house_string" runat="server"></asp:Label></FONT>
						</td>
					</tr>
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">執行失敗</FONT></td>
						<td><asp:Label id="lblFailure" runat="server"></asp:Label>筆</FONT></td>
					</tr>
					<tr>
						<td width="208" valign="top"><FONT face="新細明體">執行失敗用戶號碼:</FONT>
						</td>
						<td><asp:Label id="lblFailure_house_string" runat="server"></asp:Label></FONT>
						</td>
					</tr>
                    <tr>
                        <td width="208" valign="top"><FONT face="新細明體"></FONT>
						</td>
						<td><asp:Label id="lblsMsg" runat="server"></asp:Label></FONT>
						</td>
                    </tr>
				</table>
			</div>
		</form>
	</body>
</HTML>

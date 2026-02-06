<%@ Page Language="vb" AutoEventWireup="false" Codebehind="send_file_tmp.aspx.vb" Inherits="send_file_tmp" %>
<HTML>
	<HEAD>
		<title>tmp</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<FORM id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="90" border="0">
				<tr>
					<td width="24"><FONT face="新細明體"><IMG src="/PortalFiles/WebImage/2/2_0003.gif"></FONT></td>
					<TD vAlign="top" width="66" bgColor="#0099cc">
						<P><FONT size="2">&nbsp;<FONT color="#ffffff">檔案上傳</FONT></FONT></P>
					</TD>
				</tr>
			</table>
			<P align="left">
				<TABLE id="Table5" height="216" cellSpacing="1" cellPadding="1" width="600" bgColor="#003399"
					border="0">
					<TR>
						<TD width="80" bgColor="lavender" height="28">
							<P><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG>文件名稱</STRONG></FONT></FONT></P>
						</TD>
						<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"><asp:textbox id="txtname" runat="server" Width="376px"></asp:textbox></FONT></TD>
					</TR>
					<TR>
						<TD width="80" bgColor="lavender" height="28"><FONT color="#000000" size="2"><STRONG>附表上傳</STRONG></FONT></TD>
						<TD width="185" bgColor="#ffffff" colSpan="3" height="28"><FONT face="新細明體"><FONT color="#000000" size="2"><STRONG></STRONG></FONT></FONT><FONT face="新細明體"><asp:label id="txtdbfile" runat="server"></asp:label><INPUT id="txtfile" type="file" size="43" name="txtfile" runat="server">
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="4">
							<% If (Request("invno") IS Nothing) Then %>
							<asp:button id="btnAdd" runat="server" Text="新增"></asp:button>
							<% 
											Else 
											Response.write("<INPUT id='invno' type='hidden' value='" & Request("invno") & "'>")
										%>
							<asp:button id="btnupdate" runat="server" Text="修改"></asp:button><asp:button id="btnupdatecel" runat="server" Text="取消"></asp:button>
							<% End If %>
							<INPUT type="reset" value="清除"></FONT></TD>
					</TR>
					<TR>
						<TD align="left" width="173" bgColor="#ffffff" colSpan="4"><asp:label id="txtResult" runat="server" ForeColor="Red" ></asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
	</body>
</HTML>
 

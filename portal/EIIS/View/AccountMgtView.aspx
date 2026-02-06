<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AccountMgtView.aspx.vb" Inherits="AccountMgtView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AccountMgtView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 312px; POSITION: absolute; TOP: 8px; HEIGHT: 187px"
					cellSpacing="1" borderColorDark="black" cellPadding="1" width="312" border="0">
					<TR>
						<TD style="WIDTH: 90px"><FONT color="#330099" size="2"><STRONG>帳號</STRONG></FONT></TD>
						<TD style="WIDTH: 145px" colSpan="2">
							<asp:TextBox id="txtLoginID" runat="server" Width="100px"></asp:TextBox><FONT size="2"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 90px; HEIGHT: 23px"><STRONG><FONT color="#330099" size="2">密碼</FONT></STRONG></TD>
						<TD style="WIDTH: 145px; HEIGHT: 23px" colSpan="2">
							<asp:TextBox id="txtPassword1" runat="server" Width="160px" TextMode="Password"></asp:TextBox><FONT size="2"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 90px"><STRONG><FONT color="#330099" size="2">密碼確認</FONT></STRONG></TD>
						<TD style="WIDTH: 145px" colSpan="2">
							<asp:TextBox id="txtPassword2" runat="server" Width="160px" TextMode="Password"></asp:TextBox><FONT size="2"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 90px"><FONT color="#330099" size="2"><STRONG>帳號起迄日</STRONG></FONT></TD>
						<TD style="WIDTH: 145px" colSpan="2">
							<asp:TextBox id="txtStartDate" runat="server" Width="88px"></asp:TextBox>~
							<asp:TextBox id="txtEndDate" runat="server" Width="88px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 93px" align="left" colSpan="2"></TD>
						<TD style="WIDTH: 125px" align="right">
							<asp:Button id="btnAdd" runat="server" Text="確定"></asp:Button><INPUT type="reset" value="清除"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 93px" align="left" colSpan="3">
							<asp:Label id="txtResult" runat="server" ForeColor="Red" ></asp:Label></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

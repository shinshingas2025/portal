<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="_Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Default</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="697" align="center" background="../Images/LoginBk.jpg"
				border="0" style="WIDTH: 697px; HEIGHT: 416px">
				<TR>
					<TD style="WIDTH: 294px; HEIGHT: 362px" colSpan="3"><FONT face="新細明體"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 527px; HEIGHT: 15px" align="right"><FONT face="新細明體"></FONT></TD>
					<TD style="WIDTH: 133px; HEIGHT: 15px"><FONT face="新細明體">
							<asp:Label id="lblerror" runat="server"></asp:Label></FONT></TD>
					<TD style="HEIGHT: 15px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 527px; HEIGHT: 15px" align="right"><FONT face="新細明體"><IMG alt="" src="../Images/username.jpg"></FONT></TD>
					<TD style="WIDTH: 133px; HEIGHT: 15px"><FONT face="新細明體">
							<asp:TextBox id="txtLoginID" runat="server" Width="100px"></asp:TextBox></FONT></TD>
					<TD style="HEIGHT: 15px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 527px" align="right"><FONT face="新細明體"><IMG alt="" src="../Images/password.jpg"></FONT></TD>
					<TD style="WIDTH: 133px"><FONT face="新細明體">
							<asp:TextBox id="txtPassword" runat="server" Width="100px" TextMode="Password"></asp:TextBox></FONT></TD>
					<TD><FONT face="新細明體">
							<asp:LinkButton id="linkOK" runat="server" ForeColor="Navy" Font-Size="X-Small">確定</asp:LinkButton></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

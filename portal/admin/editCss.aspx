<%@ Page Language="vb" AutoEventWireup="false" Codebehind="editCss.aspx.vb" Inherits="editCss" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>editCss</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P><FONT face="新細明體">
					<asp:RadioButtonList id="RadioButtonList1" runat="server">
						<asp:ListItem Value="CSS1">CSS1</asp:ListItem>
						<asp:ListItem Value="CSS2">CSS2</asp:ListItem>
					</asp:RadioButtonList></FONT></P>
			<P><FONT face="新細明體">
					<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></FONT></P>
			<P><FONT face="新細明體"><INPUT type="file">
					<asp:Button id="Button2" runat="server" Text="Button"></asp:Button></FONT></P>
			<P><FONT face="新細明體"><IMG alt="" src="../Data/Admin.gif"></P>
			</FONT>
		</form>
	</body>
</HTML>

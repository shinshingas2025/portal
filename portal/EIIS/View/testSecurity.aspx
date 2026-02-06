<%@ Page Language="vb" AutoEventWireup="false" Codebehind="testSecurity.aspx.vb" Inherits="testSecurity" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>testSecurity</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="Button1" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 40px" runat="server"
				Text="Button"></asp:button><asp:textbox id="txtLoginID" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 32px"
				runat="server"></asp:textbox><iewc:treeview id="TreeView1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 80px" runat="server"
				AutoPostBack="True"></iewc:treeview>
			<asp:ListBox id="ListBox1" style="Z-INDEX: 104; LEFT: 344px; POSITION: absolute; TOP: 96px" runat="server"
				Width="152px" Height="128px"></asp:ListBox>
			<asp:TextBox id="txtfunno" style="Z-INDEX: 105; LEFT: 344px; POSITION: absolute; TOP: 32px" runat="server"
				Width="152px"></asp:TextBox>
			<asp:Button id="Button2" style="Z-INDEX: 106; LEFT: 512px; POSITION: absolute; TOP: 32px" runat="server"
				Text="Button"></asp:Button>
			<asp:TextBox id="txtTrue" style="Z-INDEX: 107; LEFT: 344px; POSITION: absolute; TOP: 64px" runat="server"
				Width="152px"></asp:TextBox>
			<asp:Button id="Button3" style="Z-INDEX: 108; LEFT: 512px; POSITION: absolute; TOP: 248px" runat="server"
				Text="Button"></asp:Button>
			<asp:TextBox id="txtLogin" style="Z-INDEX: 109; LEFT: 320px; POSITION: absolute; TOP: 240px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtFun" style="Z-INDEX: 110; LEFT: 320px; POSITION: absolute; TOP: 264px" runat="server"></asp:TextBox></form>
	</body>
</HTML>

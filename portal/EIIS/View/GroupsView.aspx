<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GroupsView.aspx.vb" Inherits="GroupsView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>GroupsView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="300" border="0" class="TTable">
				<TR>
					<TD><FONT size="2">編號</FONT></TD>
					<TD>
						<asp:Label id="txtGroupid" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD><FONT size="2">群組名稱</FONT></TD>
					<TD>
						<asp:TextBox id="txtGroupName" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD><FONT size="2">描述</FONT></TD>
					<TD>
						<asp:TextBox id="txtDescription" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD><FONT size="2">狀態</FONT></TD>
					<TD>
						<asp:TextBox id="txtstate" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD><FONT face="新細明體" size="2">次序</FONT></TD>
					<TD>
						<asp:TextBox id="txtSeqno" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><FONT face="新細明體">
							<asp:Button id="btnAdd" runat="server" Text="確定"></asp:Button><INPUT type="reset" value="清除"></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

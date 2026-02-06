<%@ Page Language="vb" AutoEventWireup="false" Codebehind="JobListView.aspx.vb" Inherits="JobListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>JobListView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
					<TR>
						<TD>
							<asp:Label id="Label1" runat="server" >名稱</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtJoblist" runat="server" Width="214px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label2" runat="server" >次序</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtSeqno" runat="server" Width="112px">1</asp:TextBox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right">
							<asp:Button id="btnOK" runat="server" Text="確定"></asp:Button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

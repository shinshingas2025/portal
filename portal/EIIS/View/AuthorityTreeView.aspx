<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AuthorityTreeView.aspx.vb" Inherits="AuthorityTreeView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AuthorityTreeView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
				height="100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD background="../Images/0001.gif" colSpan="2" height="50"><FONT face="標楷體" color="#ffffff" size="5"><STRONG>&nbsp;資訊管理系統</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD bgColor="#003300" colSpan="2" height="20"><FONT face="新細明體"></FONT></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="150"><iewc:treeview id="TreeView1" runat="server" ExpandLevel="3" AutoPostBack="True" SelectExpands="True"></iewc:treeview></TD>
					<TD><iframe runat="server" width="100%" height="100%" frameBorder="no" id="IFRAME1"></iframe>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

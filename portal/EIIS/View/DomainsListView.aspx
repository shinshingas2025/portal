<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DomainsListView.aspx.vb" Inherits="DomainsListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DomainsList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>
							<asp:CheckBoxList id="chklist" runat="server" Width="100%" Font-Size="X-Small" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">增</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">刪</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">改</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">查</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">檢</asp:ListItem>
							</asp:CheckBoxList></TD>
						<TD align="right" width="50">
							<asp:LinkButton id="linkOK" runat="server" Font-Size="X-Small">確定</asp:LinkButton></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:panel id="Panel1" runat="server" Width="100%" Height="408px" BorderStyle="Solid" BorderWidth="1px"
								BackColor="White" BorderColor="Gray">
								<iewc:treeview id="TreeView1" runat="server" AutoPostBack="True"></iewc:treeview>
							</asp:panel></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

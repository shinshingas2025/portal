<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ImportDomains.aspx.vb" Inherits="ImportDomains" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
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
							<asp:CheckBoxList id="chklist" runat="server" Width="100%"  RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">增</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">刪</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">改</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">查</asp:ListItem>
								<asp:ListItem Value="1" Selected="True">檢</asp:ListItem>
							</asp:CheckBoxList></TD>
						<TD align="right" width="50">
							<asp:LinkButton id="linkOK" runat="server" >確定</asp:LinkButton></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:panel id="Panel1" runat="server" Width="100%" Height="408px" BorderStyle="Solid" BorderWidth="1px"
								BackColor="White" BorderColor="Gray">
								<!--<iewc:treeview id="TreeView2" runat="server" Width="200px" ExpandLevel="1" AutoPostBack="True"
											Height="100%"></iewc:treeview>-->
                                    <asp:TreeView ID="TreeView1" runat="server" >
                                       
                                    </asp:TreeView>
							</asp:panel></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

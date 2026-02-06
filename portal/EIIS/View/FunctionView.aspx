<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FunctionView.aspx.vb" Inherits="FunctionView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FunctionView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 448px; POSITION: absolute; TOP: 8px; HEIGHT: 192px"
				cellSpacing="1" cellPadding="1" width="448" border="0">
				<TR>
					<TD style="WIDTH: 56px"><FONT color="#ff0000" size="2">模組種類</FONT></TD>
					<TD colSpan="3"><asp:dropdownlist id="txtModuleType" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT face="新細明體" color="#ff0000" size="2">模組名稱</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtFunctionID" runat="server" Width="349px"></asp:textbox><FONT color="#330099" size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT color="#ff0000" size="2">位置</FONT></TD>
					<TD colSpan="3"><asp:dropdownlist id="txPanelName" runat="server">
							<asp:ListItem Value="0-leftPane">左</asp:ListItem>
							<asp:ListItem Value="1-contentPane" Selected="True">中</asp:ListItem>
							<asp:ListItem Value="2-rightPane">右</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT face="新細明體" color="#330099" size="2">功能描述</FONT></TD>
					<TD colSpan="3"><FONT face="新細明體"><asp:textbox id="txtDescription" runat="server" Width="352px" Rows="3" TextMode="MultiLine"></asp:textbox><FONT color="#330099" size="2"></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px; HEIGHT: 29px"><FONT face="新細明體" color="#330099" size="2">程式名稱</FONT></TD>
					<TD style="HEIGHT: 29px"><asp:textbox id="txtExeFileName" runat="server" Width="232px"></asp:textbox><FONT color="#330099" size="2"></FONT></TD>
					<TD style="WIDTH: 35px; HEIGHT: 29px"><FONT face="新細明體" color="#330099" size="2">次序</FONT></TD>
					<TD style="HEIGHT: 29px" colSpan="3"><FONT face="新細明體"><FONT color="#330099" size="2"><asp:textbox id="txtSeqno" runat="server" Width="104px">1</asp:textbox></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT face="新細明體" color="#330099" size="2">路徑</FONT></TD>
					<TD style="WIDTH: 234px"><FONT face="新細明體"><asp:textbox id="txtLogicalFilePath" runat="server" Width="233px"></asp:textbox><FONT color="#330099" size="2"></FONT></FONT></TD>
					<TD style="WIDTH: 35px"><FONT face="新細明體" color="#330099" size="2">參數</FONT></TD>
					<TD><asp:textbox id="txtExeCMDLine" runat="server" Width="104px"></asp:textbox><FONT color="#330099" size="2"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT face="新細明體" color="#ff0000" size="2"></FONT></TD>
					<TD style="WIDTH: 234px"><FONT face="新細明體"></FONT></TD>
					<TD style="WIDTH: 35px"><FONT face="新細明體" color="#ff0000" size="2"></FONT></TD>
					<TD align="left"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 56px"><FONT face="新細明體"></FONT></TD>
					<TD style="WIDTH: 234px"><FONT face="新細明體"></FONT></TD>
					<TD style="WIDTH: 35px"><FONT face="新細明體"></FONT></TD>
					<TD align="right"><asp:button id="btnOK" runat="server" Text="確定"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

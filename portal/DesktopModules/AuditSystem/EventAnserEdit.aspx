<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EventAnserEdit.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.EventAnserEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SchedulePoint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<TABLE id="Table1" height="348" cellSpacing="0" cellPadding="0" width="760" border="0">
					<TR>
						<TD width="119" height="13"><asp:label id="Label8" runat="server" CssClass="normal">編號</asp:label></TD>
						<TD width="271" height="13"><asp:label id="EntityID" runat="server" CssClass="normal">自動給值</asp:label></TD>
						<TD width="74" height="13"></TD>
						<TD height="13"></TD>
					</TR>
					<TR>
						<TD width="119" height="13">刋登<asp:label id="Label7" runat="server" CssClass="normal">日期</asp:label></TD>
						<TD width="271" height="13"><asp:dropdownlist id="txtYear" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:dropdownlist>年
							<asp:dropdownlist id="txtMonth" runat="server">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
								<asp:ListItem Value="4">4</asp:ListItem>
								<asp:ListItem Value="5">5</asp:ListItem>
								<asp:ListItem Value="6">6</asp:ListItem>
								<asp:ListItem Value="7">7</asp:ListItem>
								<asp:ListItem Value="8">8</asp:ListItem>
								<asp:ListItem Value="9">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
							</asp:dropdownlist>月
							<asp:dropdownlist id="txtDay" runat="server"></asp:dropdownlist>日</TD>
						<TD width="74" height="13"><asp:label id="Label3" runat="server" CssClass="normal">撰稿記者</asp:label></TD>
						<TD height="13"><asp:textbox id="Recorder" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119"><asp:label id="Label1" runat="server" CssClass="normal">報紙名稱</asp:label></TD>
						<TD width="271"><asp:textbox id="Newspaper" runat="server"></asp:textbox></TD>
						<TD width="74"><asp:label id="Label4" runat="server" CssClass="normal">版次</asp:label></TD>
						<TD><asp:textbox id="Version" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="59"><asp:label id="Label2" runat="server" CssClass="normal">議題</asp:label></TD>
						<TD width="271" colSpan="3" height="59"><asp:textbox id="Subject" runat="server" TextMode="MultiLine" Columns="50" Rows="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="53"><asp:label id="aaa" runat="server" CssClass="normal">輿情重點</asp:label></TD>
						<TD width="271" colSpan="3" height="53"><asp:textbox id="Point" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="71"><asp:label id="Label5" runat="server" CssClass="normal">簡答(請採標題式回答)</asp:label></TD>
						<TD width="271" colSpan="3" height="71"><asp:textbox id="Answer" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="106"><asp:label id="Label6" runat="server" CssClass="normal">備註</asp:label></TD>
						<TD width="271" colSpan="3" height="106"><asp:textbox id="Remark" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" colSpan="4">
							<asp:label id="lblResult" runat="server" CssClass="normal"></asp:label></TD>
					</TR>
				</TABLE>
			</FONT>
			<asp:button id="btnOK" runat="server" Text="確定"></asp:button>
			<asp:button id="btnBackup" runat="server" Text="返回"></asp:button></form>
	</body>
</HTML>

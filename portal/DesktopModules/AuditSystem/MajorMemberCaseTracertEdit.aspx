<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MajorMemberCaseTracertEdit.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.MajorMemberCaseTracertEdit" %>
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
						<TD width="119" height="13"><asp:label id="Label1" runat="server" CssClass="normal">來文者</asp:label></TD>
						<TD width="271" height="13"><asp:textbox id="ComeFrom" runat="server"></asp:textbox></TD>
						<TD width="74" height="13">來文日期</TD>
						<TD height="13"><asp:dropdownlist id="txtYear" runat="server">
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
					</TR>
					<TR>
						<TD width="119" height="13"><asp:label id="Label7" runat="server" CssClass="normal">交辦日期</asp:label></TD>
						<TD width="271" height="13"><asp:dropdownlist id="ToYear" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:dropdownlist>年
							<asp:dropdownlist id="ToMonth" runat="server">
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
							<asp:dropdownlist id="ToDay" runat="server"></asp:dropdownlist>日</TD>
						<TD width="74" height="13"><asp:label id="Label3" runat="server" CssClass="normal">主辦單位</asp:label></TD>
						<TD height="13"><asp:textbox id="Unit" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="19"><asp:label id="Label4" runat="server" CssClass="normal">辦結期限</asp:label></TD>
						<TD width="271" height="19"><asp:dropdownlist id="dlYear" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:dropdownlist>年
							<asp:dropdownlist id="dlMonth" runat="server">
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
							<asp:dropdownlist id="dlday" runat="server"></asp:dropdownlist>日</TD>
						<TD width="74" height="19"></TD>
						<TD height="19"></TD>
					</TR>
					<TR>
						<TD width="119" height="59"><asp:label id="Label2" runat="server" CssClass="normal">案由</asp:label></TD>
						<TD width="271" colSpan="3" height="59"><asp:textbox id="cases" runat="server" Rows="4" Columns="50" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="53"><asp:label id="aaa" runat="server" CssClass="normal">辦理情形</asp:label></TD>
						<TD width="271" colSpan="3" height="53"><asp:textbox id="WorkStatus" runat="server" Rows="5" Columns="50" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="119" height="30"><asp:label id="Label6" runat="server" CssClass="normal">備註</asp:label></TD>
						<TD width="271" colSpan="3" height="30"><asp:dropdownlist id="remark" runat="server">
								<asp:ListItem Value="已結案">已結案</asp:ListItem>
								<asp:ListItem Value="未結案" Selected="True">未結案</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD width="119" colSpan="4"><asp:label id="lblResult" runat="server" CssClass="normal"></asp:label></TD>
					</TR>
				</TABLE>
			</FONT>
			<asp:button id="btnOK" runat="server" Text="確定"></asp:button><asp:button id="btnBackup" runat="server" Text="返回"></asp:button></form>
	</body>
</HTML>

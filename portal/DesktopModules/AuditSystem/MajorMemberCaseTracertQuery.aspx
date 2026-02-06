<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MajorMemberCaseTracertQuery.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.MajorMemberCaseTracertQuery" %>
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
						<TD width="113" height="15"><asp:label id="Label7" runat="server" CssClass="normal">來文日期</asp:label></TD>
						<TD height="15"><asp:dropdownlist id="txtYearS" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:dropdownlist>年
							<asp:dropdownlist id="txtMonthS" runat="server">
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
							<asp:dropdownlist id="txtDayS" runat="server"></asp:dropdownlist>日 ~
							<asp:dropdownlist id="txtYearE" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:dropdownlist>年
							<asp:dropdownlist id="txtMonthE" runat="server">
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
							<asp:dropdownlist id="txtDayE" runat="server"></asp:dropdownlist>日
							<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button></TD>
					</TR>
					<TR>
						<TD width="113" height="16"><A href="MajorMemberCaseTracertEdit.aspx">新增</A></TD>
						<TD height="16"></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="38" colSpan="2"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="688px" BorderColor="#999999"
								BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" Font-Size="X-Small"
								AllowPaging="True" DataKeyField="EntityID">
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ComeFrom" HeaderText="來文者"></asp:BoundColumn>
									<asp:BoundColumn DataField="ComeFromDate" HeaderText="來文日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="Unit" HeaderText="主辦單位"></asp:BoundColumn>
									<asp:BoundColumn DataField="CASES" HeaderText="案由"></asp:BoundColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

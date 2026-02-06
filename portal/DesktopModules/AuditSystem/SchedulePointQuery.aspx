<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SchedulePointQuery.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.SchedulePointQuery" %>
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
						<TD width="78" height="15">
							<asp:Label id="Label7" runat="server" CssClass="normal">日期</asp:Label>區間</TD>
						<TD height="15">
							<asp:DropDownList id="txtYearS" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:DropDownList>年
							<asp:DropDownList id="txtMonthS" runat="server">
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
							</asp:DropDownList>月
							<asp:DropDownList id="txtDayS" runat="server"></asp:DropDownList>日 ~
							<asp:DropDownList id="txtYearE" runat="server">
								<asp:ListItem Value="95">95</asp:ListItem>
								<asp:ListItem Value="96">96</asp:ListItem>
								<asp:ListItem Value="97">97</asp:ListItem>
							</asp:DropDownList>年
							<asp:DropDownList id="txtMonthE" runat="server">
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
							</asp:DropDownList>月
							<asp:DropDownList id="txtDayE" runat="server"></asp:DropDownList>日
							<asp:Button id="btnQuery" runat="server" Text="查詢"></asp:Button>
						</TD>
					</TR>
					<TR>
						<TD width="78" height="16"><a href="EditSchedulePoint.aspx">新增</a></TD>
						<TD height="16"></TD>
					</TR>
					<TR>
						<TD width="38" colSpan="2" vAlign="top">
							<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="688px" BorderColor="#999999"
								BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical"
								ForeColor="Black" Font-Size="X-Small" AllowPaging="True" DataKeyField="EntityID">
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="StartDate" HeaderText="日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="LawAndWork" HeaderText="法令與重要措施"></asp:BoundColumn>
									<asp:BoundColumn DataField="Nationals" HeaderText="國際與兩岸"></asp:BoundColumn>
									<asp:BoundColumn DataField="ActiveMeeting" HeaderText="活動與會議"></asp:BoundColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

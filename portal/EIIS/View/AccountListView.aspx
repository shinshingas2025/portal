<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AccountListView.aspx.vb" Inherits="AccountListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AccountListView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 48px" runat="server"
					Width="232px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
					CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" DataKeyField="LoginID"
					Font-Size="X-Small">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="LoginID" HeaderText="LoginID"></asp:BoundColumn>
						<asp:BoundColumn DataField="Password" HeaderText="Password"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<asp:TextBox id="txtSearch" style="Z-INDEX: 102; LEFT: 72px; POSITION: absolute; TOP: 16px" runat="server"
					Font-Size="X-Small" Width="97px" Height="24px"></asp:TextBox>
				<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server"
					Font-Size="X-Small">帳號</asp:Label>
				<asp:Button id="btnSearch" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 16px"
					runat="server" Text="搜尋"></asp:Button></FONT>
		</form>
	</body>
</HTML>

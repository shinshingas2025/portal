<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AccountView.aspx.vb" Inherits="AccountView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AccountView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體" color="#330099">
				<asp:datagrid id="dgCart" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 136px" runat="server"
					Width="360px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
					CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" OnEditCommand="dgCart_Edit"
					OnUpdateCommand="dgCart_Update" OnDeleteCommand="dgCart_Delete" OnCancelCommand="dgCart_Cancel"
					PageSize="3" AllowSorting="True" ShowFooter="True" DataKeyField="LoginID">
					<SelectedItemStyle Font-Size="X-Small" Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<EditItemStyle Font-Size="X-Small"></EditItemStyle>
					<AlternatingItemStyle Font-Size="X-Small"></AlternatingItemStyle>
					<ItemStyle Font-Size="10pt" Font-Names="arial" ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Size="10pt" Font-Names="新細明體" Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="LoginID" ReadOnly="True" HeaderText="LoginID">
							<HeaderStyle Width="100px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Password">
							<HeaderStyle Width="100px"></HeaderStyle>
							<ItemTemplate>
								<%# Container.DataItem("Password") %>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id="txtPassword" Text='<%# Container.DataItem("Password") %>' runat="server" Width="50" />
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" CancelText="取消" EditText="編輯">
							<HeaderStyle Width="40px"></HeaderStyle>
						</asp:EditCommandColumn>
						<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete">
							<HeaderStyle Width="40px"></HeaderStyle>
						</asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<TABLE id="Table1" style="WIDTH: 360px; HEIGHT: 117px" cellSpacing="1" borderColorDark="black"
					cellPadding="1" width="360" border="0">
					<TR>
						<TD style="WIDTH: 243px"><FONT color="#330099"><STRONG>LoginID</STRONG></FONT></TD>
						<TD style="WIDTH: 127px">
							<asp:TextBox id="txtLoginID" runat="server" Width="100px"></asp:TextBox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 243px; HEIGHT: 23px"><STRONG><FONT color="#330099">Password</FONT></STRONG></TD>
						<TD style="WIDTH: 127px; HEIGHT: 23px">
							<asp:TextBox id="txtPassword1" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD>
						<TD style="HEIGHT: 23px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 243px"><STRONG><FONT color="#330099">Password Confirm</FONT></STRONG></TD>
						<TD style="WIDTH: 127px">
							<asp:TextBox id="txtPassword2" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD>
						<TD>
							<asp:Button id="btnAdd" runat="server" Text="確定"></asp:Button><INPUT type="reset" value="清除"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 261px" align="left" colSpan="2">
							<asp:Label id="txtResult" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></TD>
						<TD style="WIDTH: 125px" align="right"></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

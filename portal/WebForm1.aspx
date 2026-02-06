<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid1" runat="server" DataKeyField="stuid" OnUpdateCommand="update" OnCancelCommand="cancel"
				OnEditCommand="edit" CssClass="border" CellPadding="5" BorderWidth="0px" CellSpacing="1" AutoGenerateColumns="False">
				<ItemStyle CssClass="item"></ItemStyle>
				<HeaderStyle CssClass="header"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="姓名">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"stuname") %>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox id="name" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"stuname") %>' Width="88px">
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="學院">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"depname") %>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList ID="dep" Runat="server">
										<asp:ListItem Value="1">AAA</asp:ListItem>
						<asp:ListItem Value="2">BBB</asp:ListItem>
						<asp:ListItem Value="3">CCC</asp:ListItem>
							</asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
				</Columns>
			</asp:datagrid>
	
		</form>
	</body>
</HTML>

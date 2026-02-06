<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CommunityView.aspx.vb" Inherits="EIIS.CommunityView" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Community</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<TABLE class="TTable" id="Table1" borderColor="#000000" cellSpacing="0" borderColorDark="#ffffff"
					cellPadding="0" width="100%" border="1">
					<TR>
						<TD bgColor="activeborder" colSpan="3">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 68px"><FONT color="#ff0000" size="2">節點狀態</FONT></TD>
									<TD><asp:button id="btnUpdate" runat="server" Font-Size="X-Small" Text="修改本節點" BorderStyle="Ridge"></asp:button><asp:button id="btnDelete" runat="server" Font-Size="X-Small" Text="刪除本節點" BorderStyle="Ridge"></asp:button></TD>
									<TD style="WIDTH: 130px"></TD>
									<TD style="WIDTH: 103px"><asp:button id="btnAdd" runat="server" Font-Size="X-Small" Text="新增子節點" BorderStyle="Ridge"></asp:button></TD>
									<TD align="right" width="50"><FONT size="2">類別：</FONT></TD>
									<TD width="50"><asp:dropdownlist id="newType" runat="server">
											<asp:ListItem Value="Groups" Selected="True">群組</asp:ListItem>
											<asp:ListItem Value="UserInfo">使用者</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD bgColor="activeborder" colSpan="3">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><FONT size="2">節點編號：</FONT></TD>
									<TD><asp:label id="txtobjID" runat="server" Font-Size="X-Small"></asp:label></TD>
									<TD><FONT size="2">類別：</FONT></TD>
									<TD><asp:dropdownlist id="txtsrcName" runat="server">
											<asp:ListItem Value="Groups" Selected="True">群組</asp:ListItem>
											<asp:ListItem Value="UserInfo">使用者</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD><FONT size="2">父節點：</FONT></TD>
									<TD><asp:textbox id="txtPID" runat="server" Font-Size="X-Small" ReadOnly="True" Width="40px"></asp:textbox></TD>
									<TD><FONT color="#ff0000" size="2">名稱：</FONT></TD>
									<TD><asp:textbox id="txtObjName" runat="server" Font-Size="X-Small" Width="88px"></asp:textbox></TD>
									<TD><FONT size="2">數值：</FONT></TD>
									<TD><asp:textbox id="txtObjValue" runat="server" Font-Size="X-Small" ReadOnly="True" Width="80px"></asp:textbox></TD>
									<TD><FONT size="2"><FONT color="#ff0000">序號</FONT>：</FONT></TD>
									<TD><asp:textbox id="txtSeqno" runat="server" Font-Size="X-Small" Width="50px"></asp:textbox></TD>
									<TD><FONT size="2">狀態：</FONT></TD>
									<TD><asp:textbox id="txtState" runat="server" Font-Size="X-Small" Width="42px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px" vAlign="top" align="left" bgColor="activeborder"><asp:button id="Button1" runat="server" Font-Size="X-Small" Text="組識樹" BorderStyle="Groove"
								Enabled="False"></asp:button><asp:button id="btnTreeRefresh" runat="server" Font-Size="X-Small" Text="重新整理" BorderStyle="Ridge"></asp:button></TD>
						<td style="HEIGHT: 22px" bgColor="activeborder"><FONT color="#000000" size="2"><asp:button id="Button2" runat="server" Font-Size="X-Small" Text="節點屬性" BorderStyle="Groove"
									Enabled="False"></asp:button><asp:button id="AddLiginID" runat="server" Font-Size="X-Small" Text="新增帳號" BorderStyle="Ridge"
									ToolTip="新增目前選取節點使用者的帳號"></asp:button><asp:button id="LoginRefresh" runat="server" Font-Size="X-Small" Text="重新整理" BorderStyle="Ridge"></asp:button></FONT></td>
						<TD style="HEIGHT: 22px" bgColor="activeborder"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" rowSpan="3"><asp:panel id="Panel1" runat="server" Height="418px">
								<iewc:treeview id="TreeView1" runat="server" AutoPostBack="True" ExpandLevel="1"></iewc:treeview>
							</asp:panel></TD>
						<TD vAlign="top"><asp:datagrid id="DataGrid2" runat="server" Font-Size="X-Small" BorderStyle="Solid" Width="100%"
								CssClass="TTable" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999"
								AutoGenerateColumns="False" ForeColor="Black" PageSize="2" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="GroupID" HeaderText="群組ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="GroupName" HeaderText="名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="Description" HeaderText="描述"></asp:BoundColumn>
									<asp:BoundColumn DataField="state" HeaderText="狀態"></asp:BoundColumn>
								</Columns>
								<PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:datagrid><asp:datagrid id="DataGrid3" runat="server" Font-Size="X-Small" BorderStyle="Solid" Width="100%"
								CssClass="TTable" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999"
								AutoGenerateColumns="False" ForeColor="Black" PageSize="2" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="UID" HeaderText="使用者ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="Cname" HeaderText="姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="IDNum" HeaderText="身份證號"></asp:BoundColumn>
									<asp:BoundColumn DataField="TelMobile" HeaderText="行動電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="Email" HeaderText="電子郵件"></asp:BoundColumn>
									<asp:ButtonColumn Text="編輯" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:datagrid><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" BorderStyle="Solid" Width="100%"
								CssClass="TTable" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999"
								AutoGenerateColumns="False" ForeColor="Black" PageSize="2" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="LoginID" ReadOnly="True" HeaderText="帳號"></asp:BoundColumn>
									<asp:BoundColumn DataField="Password" ReadOnly="True" HeaderText="密碼"></asp:BoundColumn>
									<asp:BoundColumn DataField="StartDate" HeaderText="有效日期起"></asp:BoundColumn>
									<asp:BoundColumn DataField="EndDate" HeaderText="有效日期迄"></asp:BoundColumn>
									<asp:BoundColumn DataField="memo" HeaderText="備註"></asp:BoundColumn>
									<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:datagrid></TD>
						<TD vAlign="top"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" bgColor="activeborder"><FONT size="2"><asp:button id="Button3" runat="server" Font-Size="X-Small" Text="節點功能" BorderStyle="Groove"
									Enabled="False"></asp:button><asp:button id="addfunction" runat="server" Font-Size="X-Small" Text="匯入功能" BorderStyle="Ridge"></asp:button><asp:button id="FunRefresh" runat="server" Font-Size="X-Small" Text="重新整理" BorderStyle="Ridge"></asp:button></FONT></TD>
						<td></td>
					</TR>
					<TR>
						<TD vAlign="top" align="left" bgColor="activeborder"><asp:datagrid id="DataGrid4" runat="server" Font-Size="X-Small" BorderStyle="Solid" Width="100%"
								CssClass="TTable" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999" AutoGenerateColumns="False"
								ForeColor="Black" OnDeleteCommand="Functoin_Delete" AllowPaging="True" DataKeyField="RoleID" PageSize="5">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="DomainID" ReadOnly="True" HeaderText="功能編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="objName" ReadOnly="True" HeaderText="功能名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="srcName" ReadOnly="True" HeaderText="類型"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="增">
										<ItemTemplate>
											<asp:Label id=lblIlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ilevel") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox id="chkIlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Ilevel") %>'>
											</asp:CheckBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="刪">
										<ItemTemplate>
											<asp:Label id=lblDlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Dlevel") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox id="chkDlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Dlevel") %>'>
											</asp:CheckBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="改">
										<ItemTemplate>
											<asp:Label id=lblUlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ulevel") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox id="chkUlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Ulevel") %>'>
											</asp:CheckBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="查">
										<ItemTemplate>
											<asp:Label id=lblQlevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Qlevel") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox id="chkQlevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Qlevel") %>'>
											</asp:CheckBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="檢">
										<ItemTemplate>
											<asp:Label id=lblClevel runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Clevel") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox id="chkClevel" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Clevel") %>'>
											</asp:CheckBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:datagrid></TD>
						<td></td>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

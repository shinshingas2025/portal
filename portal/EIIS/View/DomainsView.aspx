<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DomainsView.aspx.vb" Inherits="DomainsView" %>
<%@ Import Namespace="EIIS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DomainsView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="TTable" id="Table5" borderColor="#000000" cellSpacing="0" borderColorDark="#ffffff"
				cellPadding="1" width="100%" border="1">
				<TR>
					<TD bgColor="activeborder" colSpan="2"><FONT face="新細明體">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 164px"><FONT color="#cc0000" size="2">節點狀態</FONT></TD>
									<TD style="WIDTH: 693px" bgColor="activeborder"><asp:button id="btnUpdate" runat="server" Text="修改節點" BorderStyle="Groove"></asp:button><asp:button id="btnDelete" runat="server" Text="刪除節點" BorderStyle="Groove"></asp:button></TD>
									<TD style="WIDTH: 409px" align="right"><asp:button id="btnTreeRefresh" runat="server" Text="重新整理" BorderStyle="Groove" Font-Size="X-Small"></asp:button><asp:button id="btnAdd" runat="server" Text="新增子節點" BorderStyle="Groove"></asp:button></TD>
									<TD style="WIDTH: 60px" align="right"><FONT size="2">種類</FONT></TD>
									<TD><asp:dropdownlist id="newType" runat="server">
											<asp:ListItem Value="Joblist" Selected="True">功能群組</asp:ListItem>
											<asp:ListItem Value="Function">功能</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD bgColor="activeborder" colSpan="2"><FONT face="新細明體">
							<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><FONT size="2">編號</FONT></TD>
									<TD><asp:label id="txtobjID" runat="server" Font-Size="X-Small"></asp:label></TD>
									<TD><FONT size="2">父節點</FONT></TD>
									<TD><asp:textbox id="txtPID" runat="server" Font-Size="X-Small" Width="50px"></asp:textbox></TD>
									<TD><FONT size="2">種類</FONT></TD>
									<TD><asp:dropdownlist id="selsrcName" runat="server">
											<asp:ListItem Value="Joblist" Selected="True">功能群組</asp:ListItem>
											<asp:ListItem Value="Function">功能</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD><FONT size="2">名稱</FONT></TD>
									<TD><asp:textbox id="txtObjName" runat="server" Font-Size="X-Small" Width="85px"></asp:textbox></TD>
									<TD><FONT size="2">數值</FONT></TD>
									<TD><asp:textbox id="txtObjValue" runat="server" Font-Size="X-Small" Width="80px"></asp:textbox></TD>
									<TD><FONT size="2">序號</FONT></TD>
									<TD><asp:textbox id="txtSeqno" runat="server" Font-Size="X-Small" Width="50px"></asp:textbox></TD>
									<TD><FONT size="2">狀態</FONT></TD>
									<TD><asp:textbox id="txtState" runat="server" Font-Size="X-Small" Width="50px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 263px" bgColor="activeborder"><asp:label id="Label1" runat="server" Font-Size="X-Small">功能結構</asp:label></TD>
					<TD bgColor="activeborder"><FONT face="新細明體" size="2">功能</FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 263px" vAlign="top"><asp:panel id="Panel1" runat="server" Height="380px">
							<iewc:treeview id="TreeView1" runat="server" AutoPostBack="True" ExpandLevel="2"></iewc:treeview>
						</asp:panel></TD>
					<TD vAlign="top" align="left"><asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" Font-Size="X-Small" Width="100%"
							DataKeyField="funno" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="funno" ReadOnly="True" HeaderText="編號"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="程式ID">
									<ItemTemplate>
										<asp:Label id=lblFunctionID runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FunctionID") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=txtFunctionID runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FunctionID") %>' Width="113px">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="功能描述">
									<ItemTemplate>
										<asp:Label id=lblDescription runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=txtDescription runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' Width="113px">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="程式名稱">
									<ItemTemplate>
										<asp:Label ID=lblExeFileName runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExeFileName") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID=txtExeFileName runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExeFileName") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ModuleDefid" ReadOnly="True" HeaderText="模組種類"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="位置">
									<ItemTemplate>
										<asp:Label id=lblPaneName runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.paneName") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:DropDownList id=txtPaneName runat="server" SelectedIndex='<%# mid(DataBinder.Eval(Container, "DataItem.paneName"),1,1) %>'>
											<asp:ListItem Value="0-leftPane">左</asp:ListItem>
											<asp:ListItem Value="1-contentPane">中</asp:ListItem>
											<asp:ListItem Value="2-rightPane">右</asp:ListItem>
										</asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="路徑">
									<ItemTemplate>
										<asp:Label id=lblLogicalFilePath runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LogicalFilePath") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=txtLogicalFilePath runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LogicalFilePath") %>' Width="126px">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="參數">
									<ItemTemplate>
										<asp:Label id=lblExeCMDLine runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExeCMDLine") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=txtExeCMDLine runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExeCMDLine") %>' Width="58px">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

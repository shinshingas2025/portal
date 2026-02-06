<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditRecordAuthority.aspx.vb" Inherits="EditRecordAuthority" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditRecordAuthority</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
			<LINK href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="5" cellPadding="5" width="100%" border="0">
				<TR>
					<TD align="center" bgColor="#ccffcc" colSpan="2">
						<P align="left"><asp:label id="Label8" runat="server" CssClass="normal">一般權限</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
										<TR>
											<TD></TD>
											<TD><asp:label id="Label6" runat="server" CssClass="normal">自已</asp:label></TD>
											<TD><asp:label id="Label5" runat="server" CssClass="normal">群組</asp:label></TD>
											<TD><asp:label id="Label1" runat="server" CssClass="normal">其他</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" runat="server" CssClass="normal">查詢</asp:label></TD>
											<TD><asp:checkbox id="CQ" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="GQ" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="OQ" runat="server"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label3" runat="server" CssClass="normal">修改</asp:label></TD>
											<TD><asp:checkbox id="CU" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="GU" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="OU" runat="server"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label4" runat="server" CssClass="normal">刪除</asp:label></TD>
											<TD><asp:checkbox id="CD" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="GD" runat="server"></asp:checkbox></TD>
											<TD><asp:checkbox id="OD" runat="server"></asp:checkbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:button id="btnOK" runat="server" Text="更新"></asp:button></TD>
					<TD vAlign="top"></TD>
				</TR>
				<TR>
					<TD bgColor="#ccffcc" colSpan="2"><asp:label id="Label9" runat="server">特殊權限</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2"><FONT face="新細明體">
							<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top">
											<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TBODY>
													<TR>
														<TD><asp:label id="Label10" runat="server" CssClass="normal">現有權限</asp:label>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" ForeColor="Black" GridLines="Vertical"
							CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999"
							Width="100%" DataKeyField="itemid" AutoGenerateColumns="False">
							<FooterStyle BackColor="#CCCCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Authtype" HeaderText="型態"></asp:BoundColumn>
								<asp:BoundColumn DataField="AuthID" HeaderText="名稱"></asp:BoundColumn>
								<asp:BoundColumn DataField="AuthMask" HeaderText="權限"></asp:BoundColumn>
								<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			</TD>
			<TD vAlign="top">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD><FONT face="新細明體"><asp:label id="Label11" runat="server">新增組織權限</asp:label></FONT></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label7" runat="server" CssClass="normal">組織結構</asp:label></TD>
					</TR>
					<TR>
						<TD><iewc:treeview id="TreeView1" runat="server" ExpandLevel="1" AutoPostBack="True"></iewc:treeview></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table4" height="28" cellSpacing="1" cellPadding="1" width="252" border="0">
								<TR>
									<TD><asp:checkbox id="NQuery" runat="server" CssClass="normal" Text="查詢"></asp:checkbox></TD>
									<TD><asp:checkbox id="NUpdate" runat="server" CssClass="normal" Text="修改"></asp:checkbox></TD>
									<TD><asp:checkbox id="NDelete" runat="server" CssClass="normal" Text="刪除"></asp:checkbox></TD>
									<TD><asp:button id="btnADD" runat="server" Text="加入"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
			</TR></TBODY></TABLE></FONT></TD></TR></TBODY></TABLE></form>
	</body>
</HTML>

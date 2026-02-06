<%@ Import Namespace="EIIS" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AddOrgMember.aspx.vb" Inherits="AddOrgMember" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>組織維護</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../EIIS.css" type="text/css" rel="stylesheet">
		<LINK href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/Portalfiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<TABLE cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
							<TR>
								<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></TD>
								<TD width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">人員查詢</asp:label></TD>
								<TD><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></TD>
					<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' ></TD>
					<TD width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif' ></TD>
				</TR>
				<TR>
					<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' ></TD>
					<TD bgColor="#ffffff"><FONT face="新細明體">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="400" border="0">
								<TR>
									<TD style="WIDTH: 49px"><asp:label id="Label1" runat="server" CssClass="normal">姓名</asp:label></TD>
									<TD><asp:textbox id="Cname" runat="server" Width="152px"></asp:textbox></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 49px"><asp:label id="Label3" runat="server" CssClass="normal">電話</asp:label></TD>
									<TD><asp:textbox id="TelCompany" runat="server"></asp:textbox></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Text="查詢"></asp:button></TD>
								</TR>
								<TR>
									<TD colSpan="4">查詢結果</TD>
								</TR>
								<TR>
									<TD colSpan="4"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
											BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black"
											Font-Size="X-Small" AllowSorting="True" ShowFooter="True" AllowPaging="True">
											<FooterStyle BackColor="#CCCCCC"></FooterStyle>
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
											<Columns>
												<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="UID" HeaderText="ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="cname" HeaderText="姓名"></asp:BoundColumn>
												<asp:BoundColumn DataField="TelCompany" HeaderText="公司電話"></asp:BoundColumn>
												<asp:BoundColumn DataField="Email" HeaderText="電子郵件"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 49px" align="right" colSpan="4"><asp:button id="btnOK" runat="server" Text="選擇"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
					<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></TD>
				</TR>
				<TR>
					<TD><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif' ></TD>
					<TD 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ></TD>
					<TD><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>

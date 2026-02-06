<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EveryDaySchedule.aspx.vb" Inherits="EveryDaySchedule" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>長官批示提醒</title>
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<BR>
			</FONT>
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=100 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">長官批示提醒</asp:label></td>
									<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif' ></td>
						<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif' ></td>
					</tr>
					<tr>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' ></td>
						<td vAlign="top" bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<!----------------------------------------------------------------------------------------------------------------------><asp:datagrid id="DataGrid1" runat="server" Font-Size="X-Small" CellPadding="3" BackColor="White"
												BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" Width="384px" AutoGenerateColumns="False" DataKeyField="EntityID">
												<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
												<ItemStyle ForeColor="#000066"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="deadline" HeaderText="截止日期">
														<HeaderStyle Width="80px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="title" HeaderText="項目">
														<HeaderStyle Width="250px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
										</TD>
									</TR>
								</TBODY></TABLE>
						</td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif' ></td>
					</tr>
					<tr>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif' ></td>
						<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ></td>
						<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif' ></td>
					</tr>
				</TBODY></table>
		</form>
	</body>
</HTML>

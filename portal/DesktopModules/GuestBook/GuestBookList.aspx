<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page language="vb" CodeBehind="GuestBookList.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.GuestBookList" %>
<HTML>
	<HEAD>
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner><FONT face="新細明體"><BR>
				<BR>
			</FONT>
			<table cellSpacing="0" cellPadding="0" width="80%" border="0" align="center">
				<tr vAlign="top">
					<td colSpan="3"><FONT face="新細明體">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<TR>
									<TD width="1"><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif'></TD>
									<TD width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif'>
										<asp:label id="Label7" runat="server" CssClass="head">留言列表</asp:label></TD>
									<TD><IMG 
            src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'></TD>
									<TD></TD>
								</TR>
							</TABLE>
							<BR>
						</FONT>
					</td>
				</tr>
				<tr>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
				</tr>
				<tr>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' width=5><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
					<td width="100%" align="center" bgcolor="#ffffff">
						<asp:datagrid id="myDataGrid" runat="server" AutoGenerateColumns="False" OnPageIndexChanged="PageChanged"
							PageSize="8" AllowPaging="True" DataKeyField="EntityID" BorderColor="#3366CC" BorderStyle="None"
							BorderWidth="0px" BackColor="White" CellPadding="4" ShowFooter="False" ShowHeader="False"
							Width="100%">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<table border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td bgcolor="#ffffff" width="100%">
													<table border="0" cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td>
																<span class="itemtitle">留言者：</span>
																<asp:Label Runat="server" ID="Label2" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"CreatedByUser") %>
																</asp:Label>
															</td>
															<td>
																<span class="itemtitle">留言時間：</span>
																<asp:Label Runat="server" ID="Label4" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"CreatedDate") %>
																</asp:Label>
															</td>
														</tr>
														<tr>
															<td colspan="4">
																<asp:Label Runat="server" CssClass="normal" ID="Label3" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"Title") %>
																</asp:Label>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="閱覽" ItemStyle-Font-Size="10" DataNavigateUrlField="EntityID" DataNavigateUrlFormatString="~/DesktopModules/GuestBook/GuestBookView.aspx?EntityID={0}"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><br>
						<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button>
					</td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
				</tr>
				<tr>
					<td width="5"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

<%@ Page language="vb" CodeBehind="VotesList.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.VotesList" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="3"><aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner></td>
				</tr>
				<tr>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
				</tr>
				<tr>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif' width=5><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
					<td align="center"><asp:datagrid id="myDataGrid" runat="server" ShowFooter="False" ShowHeader="False" CellPadding="4"
							BackColor="White" BorderWidth="0px" BorderStyle="None" BorderColor="#3366CC" DataKeyField="EntityID" AllowPaging="True"
							PageSize="8" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" OnEditCommand="myDataGrid_EditedIndexChanged"
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
															<td>標題：
																<asp:Label Runat="server" ID="Label2" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"QuestionAlias") %>
																</asp:Label>
															</td>
															<td>起始時間：
																<asp:Label Runat="server" ID="Label1" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"EnableDate") %>
																</asp:Label>
															</td>
															<td>結束時間：
																<asp:Label Runat="server" ID="Label3" NAME="Label1">
																	<%# DataBinder.Eval(Container.DataItem,"DisableDate") %>
																</asp:Label>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="投票" CommandName="Select"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="看結果"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
				</tr>
				<tr>
					<td width="5"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
					<td align="center">
						<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
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

<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ResolutionQueryFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.ResolutionQueryFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href="../../css/AuditSystem1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="/PortalFiles/WebImage/AuditSystem/1x1.gif"
		topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
					<td width="100%" bgColor="#ffffff">
						<TABLE width="100%" border="0">
							<TR>
								<TD vAlign="top" align="center">
									<!---------------------------------------------------------------------------------------------------------------------->
									<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
										border="0">
										<tr>
											<td class="dingbat" align="center" width="100%" colspan="2">決議事項</td>
										</tr>
										<tr>
											<td align="center">
												<table align="left" width="100%">
													<tr>
														<td>查詢欄位</td>
														<td>
															<asp:DropDownList ID="DropDownListQueryColumn" Runat="server">
																<asp:ListItem Value="ResolutionNumber" Selected="True">決議編號</asp:ListItem>
																<asp:ListItem Value="Content">決議內容</asp:ListItem>
															</asp:DropDownList>
														</td>
														<td><asp:TextBox ID="TextBoxQuery" Runat="server"></asp:TextBox></td>
														<td><asp:Button ID="ButtonQuery" Runat="server" Text="查詢"></asp:Button></td>
													</tr>
													<tr>
														<td colspan="4">
															<table align="left" width="100%">
																<asp:DataList ID="DataList1" Runat="server" DataKeyField="EntityID" OnEditCommand="LinkButtonSelect_Click">
																	<HeaderTemplate>
																		<tr>
																			<th>
																				編輯</th><th>決議編號</th><th>決議內容</th>
																		</tr>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<tr>
																			<td>
																				<asp:LinkButton ID="LinkButtonSelect" Runat="server" CommandName="Edit">選擇</asp:LinkButton>
																			</td>
																			<td>
																				<%# DataBinder.Eval(Container, "DataItem.ResolutionNumber") %>
																			</td>
																			<td>
																				<%# Right("                              " & DataBinder.Eval(Container, "DataItem.Content") , 30) %>
																			</td>
																		</tr>
																	</ItemTemplate>
																</asp:DataList>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<!----------------------------------------------------------------------------------------------------------------------></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

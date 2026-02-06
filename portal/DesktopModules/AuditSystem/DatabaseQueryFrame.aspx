<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DatabaseQueryFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.DatabaseQueryFrame" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0" background=/PortalFiles/WebImage/AuditSystem/1x1.gif>
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" bgColor="#ffffff">
						<TABLE width="100%" border="0">
							<TR>
								<TD vAlign="top" align="center">
									<!---------------------------------------------------------------------------------------------------------------------->
									<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
										border="0">
										<tr>
											<td>
												<table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
													<tr>
														<td class="legal">查詢欄位：
															<asp:DropDownList id="DropDownListQueryColumn" runat="server" CssClass="footer">
																<asp:ListItem Value="ResolutionContent" Selected="True">決議事項</asp:ListItem>
																<asp:ListItem Value="ProcessState">處理情形</asp:ListItem>
															</asp:DropDownList>
														</td>
														<td class="legal">查詢字串：
															<asp:TextBox id="TextBoxQueryString" runat="server"></asp:TextBox>
															<asp:Button id="ButtonOK" runat="server" Text="確定"></asp:Button></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<th width="5%" align="center" class="dingbat">
												查詢結果</th>
										</tr>
										<tr>
											<td colspan="2" align="center" width="100%">
												<asp:PlaceHolder id="PlaceHolderEntitysList" runat="server"></asp:PlaceHolder></td>
										</tr>
										<tr>
											<td align="center">
												<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<tr>
														<td width="5%"><asp:linkbutton id="LinkButtonEntitysListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
														<td width="5%"><asp:linkbutton id="LinkButtonEntitysListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
														<td align="center" width="80%"><asp:placeholder id="PlaceHolderEntitysListPageIndex" runat="server"></asp:placeholder></td>
														<td width="5%"><asp:linkbutton id="LinkButtonEntitysListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
														<td width="5%"><asp:linkbutton id="LinkButtonEntitysListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
									<!----------------------------------------------------------------------------------------------------------------------></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

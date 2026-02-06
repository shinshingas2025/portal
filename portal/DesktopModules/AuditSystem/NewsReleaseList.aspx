<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewsReleaseList.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.NewsReleaseList" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" style="BACKGROUND-COLOR: #ffffcc" method="post" encType="multipart/form-data"
			runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
					<th align="left" width="5%">
						選擇</th>
					<th align="left" width="20%">
						類別</th>
					<th align="left" width="60%">
						新聞主題</th>
					<th align="left" width="15%">
						新聞時間</th></tr>
				<tr>
					<td width="100%" colSpan="4"><asp:datalist id="DataList1" runat="server" Width="100%" DataKeyField="EntityID">
							<ItemTemplate>
								<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<td width="5%">
											<asp:RadioButton ID="RadioButton1" Runat="server" OnCheckedChanged="DataList1_SelectedIndexChanged"
												AutoPostBack="true"></asp:RadioButton>
										</td>
										<TD width="20%">
											<ASP:LABEL id="Label3" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "CategorizationName") %>
											</ASP:LABEL></TD>
										<TD width="60%">
											<ASP:LABEL id="Label1" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "Title") %>
											</ASP:LABEL></TD>
										<TD width="15%">
											<ASP:LABEL id="Label2" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "NewsDateString") %>
											</ASP:LABEL>
										</TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist></td>
				</tr>
				<tr>
					<td align="center" colSpan="4">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td width="5%"><asp:linkbutton id="LinkButtonNewsListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
								<td width="5%"><asp:linkbutton id="LinkButtonNewsListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
								<td align="center" width="80%"><asp:placeholder id="PlaceHolderNewsListPageIndex" runat="server"></asp:placeholder></td>
								<td width="5%"><asp:linkbutton id="LinkButtonNewsListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
								<td width="5%"><asp:linkbutton id="LinkButtonNewsListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

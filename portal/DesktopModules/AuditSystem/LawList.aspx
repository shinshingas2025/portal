<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LawList.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.LawList" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server" style="BACKGROUND-COLOR:#ffffcc">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<tr>
					<th width="5%" align="left">
						選擇</th>
					<th width="20%" align="left">
						法律名稱</th>
					<th width="60%" align="left">
						母法名稱</th>
					<th width="15%" align="left">
						法律時間</th>
				</tr>
				<tr>
					<td colspan="4" width="100%"><asp:datalist id="DataList1" runat="server" DataKeyField="EntityID" Width="100%">
							<ItemTemplate>
								<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
									<TR>
										<td width="5%">
											<asp:RadioButton ID="RadioButton1" Runat="server" OnCheckedChanged="DataList1_SelectedIndexChanged"
												AutoPostBack="true"></asp:RadioButton>
										</td>
										<TD width="20%">
											<ASP:LABEL id="Label3" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "Name") %>
											</ASP:LABEL></TD>
										<TD width="60%">
											<ASP:LABEL id="Label1" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "ParentName") %>
											</ASP:LABEL></TD>
										<TD width="15%">
											<ASP:LABEL id="Label2" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "ConstitutionDateString") %>
											</ASP:LABEL>
										</TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist></td>
				</tr>
				<tr>
					<td align="center" colspan="4">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td width="5%"><asp:linkbutton id="LinkButtonEntityListTenPageUp" runat="server" CssClass="normal">上十頁</asp:linkbutton></td>
								<td width="5%"><asp:linkbutton id="LinkButtonEntityListPageUp" runat="server" CssClass="normal">上一頁</asp:linkbutton></td>
								<td align="center" width="80%"><asp:placeholder id="PlaceHolderEntityListPageIndex" runat="server"></asp:placeholder></td>
								<td width="5%"><asp:linkbutton id="LinkButtonEntityListPageDown" runat="server" CssClass="normal">下一頁</asp:linkbutton></td>
								<td width="5%"><asp:linkbutton id="LinkButtonEntityListTenPageDown" runat="server" CssClass="normal">下十頁</asp:linkbutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

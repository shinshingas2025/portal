<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LawViewFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.LawViewFrame" %>
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
											<td class="dingbat" align="center" width="100%">法規</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%">
													<tr>
														<td class="navLink"><asp:Label id="LabelName" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td class="promo"><asp:Label id="LabelContent" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td class="legal">審議階段：
															<asp:Label id="LabelDiscussion" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td class="legal">建立時間：
															<asp:Label id="LabelConstitutionDate" runat="server"></asp:Label></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="dingbat" align="center" width="100%" colSpan="2">法規附件</td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2">
												<asp:PlaceHolder id="PlaceHolderAppend" runat="server"></asp:PlaceHolder>
											</td>
										</tr>
										<tr>
											<td align="center" colspan="2">
												<asp:button id="ButtonParent" runat="server" CssClass="nav" Text="上一層"></asp:button>
												<asp:button id="ButtonChild" runat="server" CssClass="nav" Text="下一層"></asp:button>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="2">
												<asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button>
												<asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></TD>
										</TR>
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

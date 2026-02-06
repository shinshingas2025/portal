<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewsReleaseAdminFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.NewsReleaseAdminFrame" %>
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
											<td class="dingbat" align="center" width="80%">新聞稿標頭</td>
											<td>類別<asp:dropdownlist id="DropDownListCategorization" runat="server" CssClass="navLink" AutoPostBack="True"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%">
													<tr>
														<td class="legal">主題</td>
														<td><asp:textbox id="TextBoxTitle" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">描述</td>
														<td><asp:textbox id="TextBoxDescription" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">開頭</td>
														<td><asp:textbox id="TextBoxOpening" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">結尾</td>
														<td><asp:textbox id="TextBoxEnding" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">發佈單位</td>
														<td><asp:dropdownlist id="DropDownListReleaseUnit" runat="server" CssClass="footer"></asp:dropdownlist></td>
													</tr>
													<tr>
														<td class="legal">聯絡人員</td>
														<td><asp:dropdownlist id="DropDownListLiaisoner" runat="server" CssClass="footer"></asp:dropdownlist></td>
													</tr>
													<tr>
														<td class="legal">新聞時間</td>
														<td><asp:textbox id="TextboxNewsDate" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">起始時間</td>
														<td><asp:textbox id="TextBoxStartDate" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">結束時間</td>
														<td><asp:textbox id="TextBoxEndDate" runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td class="legal">相關聯結</td>
														<td><asp:textbox id="TextboxRelationURL" runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
											<td align="left" width="20%">
												<table width="100%">
													<tr>
														<td align="center" colSpan="2">
															<asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button>
															<asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button>
														</td>
													</tr>
													<tr>
														<td align="center" colSpan="2">
															<asp:button id="ButtonNewsInsert" runat="server" CssClass="nav" Text="新增"></asp:button>
															<asp:button id="ButtonNewsUpdate" runat="server" CssClass="nav" Text="修改"></asp:button>
															<asp:button id="ButtonNewsDelete" runat="server" CssClass="nav" Text="刪除"></asp:button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="dingbat" align="center" width="100%" colSpan="2">新聞稿內容</td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2"><asp:placeholder id="PlaceHolderContent" runat="server"></asp:placeholder></td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2">
												<TABLE cellSpacing="0" cellPadding="1" align="center" border="0">
													<TR>
														<TD width="40"><asp:button id="ButtonContentAction" runat="server" CssClass="nav" Width="40"></asp:button></TD>
														<TD width="48"><asp:textbox id="TextBoxContentNumber" runat="server" Width="48"></asp:textbox></TD>
														<TD width="480"><asp:textbox id="TextBoxContent" runat="server" Width="480" TextMode="MultiLine" Rows="2"></asp:textbox></TD>
														<TD width="40"><asp:textbox id="TextBoxContentOrder" runat="server" Width="40"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td class="dingbat" align="center" width="100%" colSpan="2">新聞稿附件</td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2"><asp:placeholder id="PlaceholderAppend" runat="server"></asp:placeholder></td>
										</tr>
										<tr>
											<td align="center" width="100%" colSpan="2">
												<TABLE cellSpacing="0" cellPadding="1" align="center" border="0">
													<TR>
														<TD width="40"><asp:button id="ButtonAppendAction" runat="server" CssClass="nav" Width="40"></asp:button></TD>
														<TD width="160"><asp:textbox id="TextboxAppendName" runat="server" Width="160"></asp:textbox></TD>
														<TD width="240"><asp:textbox id="TextboxAppendDescription" runat="server" Width="240"></asp:textbox></TD>
														<TD width="120"><input id="AppendFile" type="file" name="AppendFile" runat="server" size="5"></TD>
														<TD width="40"><asp:textbox id="TextBoxAppendOrder" runat="server" Width="40"></asp:textbox></TD>
													</TR>
												</TABLE>
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

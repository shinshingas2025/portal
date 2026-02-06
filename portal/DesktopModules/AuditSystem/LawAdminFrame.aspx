<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LawAdminFrame.aspx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Module.LawAdminFrame" %>
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
											<td class="dingbat" align="center" width="100%" colspan="2">法規標頭</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%">
													<tr>
														<td class="legal">法規名稱</td>
														<td><asp:textbox id="TextBoxName" runat="server"></asp:textbox></td>
														<td class="legal">法規型態</td>
														<td><asp:DropDownList ID="DropDownListType" Runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="legal">異動性質</td>
														<td><asp:DropDownList ID="DropDownListVariationType" Runat="server"></asp:DropDownList>
														</td>
														<td class="legal">公（發）佈機關</td>
														<td><asp:DropDownList ID="DropDownListConstitutionInstitution" Runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="legal">法規訂定日期</td>
														<td><asp:textbox id="TextboxConstitutionDate" runat="server"></asp:textbox></td>
														<td class="legal">審議階段</td>
														<td>
															<asp:DropDownList id="DropDownListDiscussion" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="legal">承辦單位</td>
														<td><asp:DropDownList ID="DropDownListUndertakerInstitution" Runat="server"></asp:DropDownList>
														</td>
														<td class="legal">文號</td>
														<td><asp:TextBox ID="TextBoxDocumentNumber" Runat="server"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="legal">母法依據</td>
														<td><asp:DropDownList id="DropDownListParent" runat="server"></asp:DropDownList></td>
													</tr>
												</table>
											</td>
											<td align="left" width="20%">
												<table width="100%">
													<tr>
														<td align="center" colspan="2">
															<asp:button id="ButtonParent" runat="server" CssClass="nav" Text="上一層"></asp:button>
															<asp:button id="ButtonChild" runat="server" CssClass="nav" Text="下一層"></asp:button>
														</td>
													</tr>
													<tr>
														<td align="center" colSpan="2">
															<asp:button id="ButtonPrevious" runat="server" CssClass="nav" Text="上一筆"></asp:button>
															<asp:button id="ButtonNext" runat="server" CssClass="nav" Text="下一筆"></asp:button></td>
													</tr>
													<tr>
														<td align="center" colspan="2">
															<asp:button id="ButtonEntityInsert" runat="server" CssClass="nav" Text="新增"></asp:button>
															<asp:button id="ButtonEntityUpdate" runat="server" CssClass="nav" Text="修改"></asp:button>
															<asp:button id="ButtonEntityDelete" runat="server" CssClass="nav" Text="刪除"></asp:button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td class="dingbat" align="center" width="100%" colSpan="2">法規內容</td>
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
								<td class="dingbat" align="center" width="100%" colSpan="2">法規附件</td>
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
						<!----------------------------------------------------------------------------------------------------------------------></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

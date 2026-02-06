<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExportColumnEdit.aspx.vb" Inherits="ASPNET.StarterKit.Portal.ExportColumnEdit" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P><FONT face="新細明體"></FONT>&nbsp;</P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="60%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">匯出欄位修改</asp:label></td>
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
						<td bgColor="#ffffff">
							<TABLE width="100%" border="0">
								<TR>
									<TD vAlign="top" align="center">
										<!---------------------------------------------------------------------------------------------------------------------->
										<TABLE class="TTable1" id="Table1" cellSpacing="3" cellPadding="3" width="100%" align="center"
											border="0">
											<tr>
												<td align="center"><asp:label id="Label4" runat="server" CssClass="subhead">標題</asp:label></td>
												<td><asp:textbox id="TextBoxTitle" runat="server"></asp:textbox></td>
												<td align="center"><asp:label id="Label6" runat="server" CssClass="subhead">描述</asp:label></td>
												<td><asp:textbox id="TextBoxDescription" runat="server"></asp:textbox></td>
												<td>
													<asp:RadioButton id="RadioButtonOrderByHand" runat="server" Text="人工排序" GroupName="RadioButtonOrder"></asp:RadioButton>
													<asp:RadioButton id="RadioButtonAutoOrder" runat="server" Text="自動排序" GroupName="RadioButtonOrder"></asp:RadioButton></td>
												<td>
													<asp:Label id="LabelResult" runat="server"></asp:Label>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="6" width="100%"><asp:datalist id="DataList1" runat="server" Width="900" DataKeyField="EntityID" RepeatColumns="3"
														RepeatDirection="Horizontal">
														<ItemTemplate>
															<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																<TR>
																	<TD width="5%">
																		<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox></TD>
																	<TD width="75%">
																		<ASP:LABEL id="Label1" runat="server" CssClass="itemtitle">
																			<%# DataBinder.Eval(Container.DataItem, "ColumnName") %>(<%# DataBinder.Eval(Container.DataItem, "Description") %>)
																		</ASP:LABEL></TD>
																	<TD width="20%">
																		<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList></TD>
																</TR>
															</TABLE>
														</ItemTemplate>
													</asp:datalist></td>
											</tr>
											<tr>
												<td align="center" colspan="6" width="100%">
													<asp:Button id="ButtonOK" runat="server" Text="確定"></asp:Button>
													<asp:Button id="ButtonCancel" runat="server" Text="取消"></asp:Button>
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
											</tr>
										</TABLE>
										<!----------------------------------------------------------------------------------------------------------------------></TD>
								</TR>
							</TABLE>
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
				</table>
			</P>
		</form>
	</body>
</HTML>

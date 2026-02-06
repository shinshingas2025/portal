<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DMSAddArchive.aspx.vb" Inherits="ASPNET.StarterKit.Portal.DMSAddArchive" %>
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
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server" encType="multipart/form-data">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner></P>
			<P><FONT face="新細明體"></FONT>&nbsp;</P>
			<P>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=160 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="LabelDetail" runat="server" CssClass="itemtitle">新增檔案</asp:label></td>
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
												<td align="center" colSpan="3"><FONT face="新細明體"></FONT></td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td><FONT face="新細明體">文件型態</FONT></td>
															<td>
																<asp:DropDownList id="DropDownListDocumentType" runat="server"></asp:DropDownList></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">檔案<FONT face="新細明體">上傳</FONT></FONT></td>
															<td><input id="UploadFile1" type="file" runat="server" NAME="UploadFileName1"></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">檔案連結</FONT></td>
															<td><asp:textbox id="TextboxURL" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">名稱</FONT></td>
															<td align="left"><asp:textbox id="TextBoxName" runat="server"></asp:textbox>
																<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName" ErrorMessage="請輸入檔案名稱!"
																	Display="Dynamic"></asp:RequiredFieldValidator></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">關鍵字集</FONT></td>
															<td><asp:textbox id="TextboxMetaData" runat="server"></asp:textbox>
																<asp:CheckBox id="CheckBoxSaveKeyword" runat="server" Text="儲存關鍵字"></asp:CheckBox></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">關鍵字</FONT></td>
															<td><FONT face="新細明體">
																	<asp:ListBox id="ListBoxMetaKeyWord" runat="server" AutoPostBack="True"></asp:ListBox>
																</FONT>
															</td>
														</tr>
														<tr>
															<td><FONT face="新細明體">主版本數</FONT></td>
															<td><asp:textbox id="TextboxMajorRevision" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">次版本數</FONT></td>
															<td><asp:textbox id="TextboxMinorRevision" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">擁有人</FONT></td>
															<td><FONT face="新細明體"><asp:dropdownlist id="DropDownListOwner" runat="server"></asp:dropdownlist></FONT></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">權限</FONT></td>
															<td><asp:dropdownlist id="DropDownListPermission" runat="server">
																	<asp:ListItem Value="A">權限模式A</asp:ListItem>
																	<asp:ListItem Value="B">權限模式B</asp:ListItem>
																	<asp:ListItem Value="C">權限模式C</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
														<tr>
															<td width="79"><FONT face="新細明體">密碼</FONT></td>
															<td><asp:textbox id="TextBoxPassword" runat="server"></asp:textbox><asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="密碼不符!" ControlToValidate="TextBoxPassword"
																	ControlToCompare="TextBoxPasswordConfirm"></asp:comparevalidator></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">密碼確認</FONT></td>
															<td><asp:textbox id="TextBoxPasswordConfirm" runat="server"></asp:textbox></td>
														</tr>
														<tr>
															<td><FONT face="新細明體">描述</FONT></td>
															<td><asp:textbox id="TextBoxDescription" runat="server"></asp:textbox></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<asp:Button id="ButtonOK" runat="server" Text="確定"></asp:Button>
													<asp:Button id="ButtonCancel" runat="server" Text="取消"></asp:Button><asp:button id="ButtonReturn" runat="server" Text="返回"></asp:button></td>
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
						<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
					</tr>
				</table>
			</P>
		</form>
	</body>
</HTML>

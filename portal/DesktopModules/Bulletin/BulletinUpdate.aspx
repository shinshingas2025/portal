<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BulletinUpdate.aspx.vb" Inherits="ASPNET.StarterKit.Portal.BulletinUpdate" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>校園聯名網</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<LINK href='/Portalfiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet >
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
					<tr>
						<td colSpan="3" width="100%">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">編輯訊息</asp:label></td>
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
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<tr>
												<td align="center" colSpan="3">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="161"><asp:label id="Label1" runat="server" CssClass="subhead">訊息型態</asp:label></td>
															<td width="525"><asp:radiobutton id="RadioButtonTypeIndividual" runat="server" CssClass="normal" Text="私有訊息" GroupName="RadioButtonType"></asp:radiobutton><asp:radiobutton id="RadioButtonTypeCommunity" runat="server" CssClass="normal" Text="公眾訊息" GroupName="RadioButtonType"></asp:radiobutton></td>
														</tr>
														<tr>
															<td width="161"><asp:label id="Label2" runat="server" CssClass="subhead">顯示順序</asp:label></td>
															<td width="525"><asp:dropdownlist id="DropDownListDisplayOrder" runat="server"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td width="161"><asp:label id="Label3" runat="server" CssClass="subhead">主題</asp:label></td>
															<td width="525"><asp:textbox id="TextBoxTitle" runat="server" Width="440px"></asp:textbox></td>
														</tr>
														<tr>
															<td vAlign="top" width="161"><asp:label id="Label4" runat="server" CssClass="subhead">內容</asp:label></td>
															<td width="525"><asp:textbox id="TextBoxDescription" runat="server" Width="440px" Columns="7" Height="100px"
																	TextMode="MultiLine"></asp:textbox></td>
														</tr>
														<tr>
															<td width="161"><asp:label id="Label19" runat="server" CssClass="subhead">相關連結</asp:label></td>
															<td width="525"><asp:textbox id="TextboxAffiliatedURL" runat="server" Width="440px"></asp:textbox></td>
														</tr>
														<tr>
															<td width="161"><asp:label id="Label5" runat="server" CssClass="subhead">發佈單位</asp:label></td>
															<td width="525"><asp:textbox id="TextBoxAnnounceUnit" runat="server" Width="440px" ReadOnly="True"></asp:textbox></td>
														</tr>
														<tr>
															<td align="center" width="458" colSpan="2"><table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																	<tr>
																		<td width="114"><asp:label id="Label6" runat="server" CssClass="subhead">起始日期</asp:label></td>
																		<td width="191"><asp:textbox id="TextBoxEnableDate" runat="server" Width="104px"></asp:textbox><asp:linkbutton id="LinkButtonEnableDate" runat="server" CssClass="subhead">月曆</asp:linkbutton><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="normalred" ValidationExpression="\d{4}/\d{1,2}/\d{1,2}"
																				ControlToValidate="TextBoxEnableDate" ErrorMessage="日期格式錯誤!"></asp:regularexpressionvalidator><asp:calendar id="CalendarEnableDate" runat="server" CssClass="normal" Visible="False"></asp:calendar></td>
																		<td width="82"><asp:label id="Label8" runat="server" CssClass="subhead">終止日期</asp:label></td>
																		<td width="180"><asp:textbox id="TextboxDisableDate" runat="server" Width="102px"></asp:textbox><asp:linkbutton id="LinkButtonDisableDate" runat="server" CssClass="subhead">月曆</asp:linkbutton><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" CssClass="normalred" ValidationExpression="\d{4}/\d{1,2}/\d{1,2}"
																				ControlToValidate="TextboxDisableDate" ErrorMessage="日期格式錯誤!" Display="Dynamic"></asp:regularexpressionvalidator><asp:comparevalidator id="CompareValidator1" runat="server" CssClass="normalred" ControlToValidate="TextboxDisableDate"
																				ErrorMessage="終止日期小於起始日期!" Display="Dynamic" Operator="GreaterThanEqual" ControlToCompare="TextBoxEnableDate"></asp:comparevalidator><asp:calendar id="CalendarDisableDate" runat="server" CssClass="normal" Visible="False"></asp:calendar></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3">
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														<tr>
															<td width="99"><asp:label id="Label9" runat="server" CssClass="subhead">上傳檔案</asp:label></td>
															<td><input id="UploadFile1" type="file" runat="server" NAME="UploadFileName1"></td>
														</tr>
														<tr>
															<td width="99"><asp:label id="Label10" runat="server" CssClass="subhead">上傳檔案</asp:label></td>
															<td><input id="UploadFile2" type="file" runat="server" NAME="UploadFileName2"></td>
														</tr>
														<tr>
															<td width="99"><asp:label id="Label11" runat="server" CssClass="subhead">上傳檔案</asp:label></td>
															<td><input id="UploadFile3" type="file" runat="server" NAME="UploadFileName3"></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colSpan="3"><asp:button id="ButtonOK" runat="server" Text="確定"></asp:button><asp:button id="ButtonCancel" runat="server" Text="取消"></asp:button>
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

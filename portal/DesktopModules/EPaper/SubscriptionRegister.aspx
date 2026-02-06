<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubscriptionRegister.aspx.vb" Inherits="ASPNET.StarterKit.Portal.SubscriptionRegister" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<HTML>
	<HEAD>
		<title>訂閱電子報</title>
		<META http-equiv="Content-Type" content="text/html; charset=BIG5">
		<link href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server"></aspnetportal:banner><BR>
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
							<tr>
								<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
								<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">訂閱電子報</asp:label></td>
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
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colspan="2">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td>
															<asp:Label id="Label1" runat="server" CssClass="subhead">姓名</asp:Label></td>
														<td>
															<asp:TextBox id="TextBoxName" runat="server"></asp:TextBox></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label2" runat="server" CssClass="subhead">電子郵件信箱</asp:Label></td>
														<td>
															<asp:TextBox id="TextBoxEmail" runat="server"></asp:TextBox>
															<asp:RegularExpressionValidator id="RegularExpressionValidatorEmail" runat="server" ErrorMessage="電子郵件信箱位址不正確!"
																ControlToValidate="TextBoxEmail" ValidationExpression="\S+\@\S+" Display="Dynamic" CssClass="normalred"></asp:RegularExpressionValidator>
															<asp:RequiredFieldValidator id="RequiredFieldValidatorEmail" runat="server" ErrorMessage="未輸入電子郵件信箱!" ControlToValidate="TextBoxEmail"
																Display="Dynamic" CssClass="normalred"></asp:RequiredFieldValidator></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label3" runat="server" CssClass="subhead">性別</asp:Label></td>
														<td>
															<asp:RadioButton id="RadioButtonMale" runat="server" Text="男" GroupName="RadioButtonSex" CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonFemale" runat="server" Text="女" GroupName="RadioButtonSex" CssClass="normal"></asp:RadioButton></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label4" runat="server" CssClass="subhead">教育程度</asp:Label></td>
														<td>
															<asp:RadioButton id="RadioButtonEducation1" runat="server" Text="國小" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation2" runat="server" Text="國中" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation3" runat="server" Text="高職" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation4" runat="server" Text="高中" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation5" runat="server" Text="專科" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation6" runat="server" Text="大學" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation7" runat="server" Text="碩士" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation8" runat="server" Text="博士" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonEducation9" runat="server" Text="其他" GroupName="RadioButtonEducation"
																CssClass="normal"></asp:RadioButton></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label5" runat="server" CssClass="subhead">年收入</asp:Label></td>
														<td>
															<asp:RadioButton id="RadioButtonSalary1" runat="server" Text="30萬以下" GroupName="RadioButtonSalary"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonSalary2" runat="server" Text="31-50萬" GroupName="RadioButtonSalary"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonSalary3" runat="server" Text="51-80萬" GroupName="RadioButtonSalary"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonSalary4" runat="server" Text="81-100萬" GroupName="RadioButtonSalary"
																CssClass="normal"></asp:RadioButton>
															<asp:RadioButton id="RadioButtonSalary5" runat="server" Text="100萬以上" GroupName="RadioButtonSalary"
																CssClass="normal"></asp:RadioButton></td>
													</tr>
													<tr>
														<td height="19">
															<asp:Label id="Label6" runat="server" CssClass="subhead">出生日期</asp:Label></td>
														<td height="19">
															<asp:TextBox id="TextBoxBirthday" runat="server"></asp:TextBox>
															<asp:LinkButton id="LinkButtonCalendar" runat="server" CssClass="normal">月曆</asp:LinkButton>
															<asp:Calendar id="Calendar1" runat="server" Visible="False" CssClass="normal"></asp:Calendar></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label8" runat="server" CssClass="subhead">居住縣市</asp:Label></td>
														<td>
															<asp:DropDownList id="DropDownListCountry" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label9" runat="server" CssClass="subhead">職業</asp:Label></td>
														<td>
															<asp:DropDownList id="DropDownListJob" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label10" runat="server" CssClass="subhead">職稱</asp:Label></td>
														<td>
															<asp:DropDownList id="DropDownListTitle" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td>
															<asp:Label id="Label11" runat="server" CssClass="subhead">從何處得知訊息</asp:Label></td>
														<td>
															<asp:DropDownList id="DropDownListInformation" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td colspan="2" align="center">
															<asp:Button id="ButtonOK" runat="server" Text="確定"></asp:Button>
															<asp:Button id="ButtonCancel" runat="server" Text="取消"></asp:Button>
															<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!----------------------------------------------------------------------------------------------------------------------></TD>
							</TR>
						</TABLE>
					</td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
				</tr>
				<tr>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
					<td 
    background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' 
    ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

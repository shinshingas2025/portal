<%@ Page language="vb" CodeBehind="EditContacts.aspx.vb" AutoEventWireup="false" Inherits="ASPNET.StarterKit.Portal.EditContacts" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Banner" Src="~/DesktopPortalBanner.ascx" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='/portalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif'>
		<form runat="server">
			<aspnetportal:banner id="SiteHeader" runat="server" />
			
			
			
						<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<TBODY>
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=80 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">詳細資料</asp:label></td>
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
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<!---------------------------------------------------------------------------------------------------------------------->
			<table width="100%" cellspacing="0" cellpadding="0" border="0">

				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr valign="top">
								<td width="150">
									&nbsp;
								</td>
								<td>
									<table width="500" cellspacing="0" cellpadding="0" border="0">
										<tr>
											<td align="left" class="Head">
												連絡人詳細資料
											</td>
										</tr>
										<tr>
											<td colspan="2">
												<hr noshade size="1">
											</td>
										</tr>
									</table>
									<table width="750" cellspacing="0" cellpadding="0" border="0">
										<tr valign="top">
											<td width="100" class="SubHead">
												名稱:
											</td>
											<td rowspan="5">
												&nbsp;
											</td>
											<td align="left">
												<asp:textbox id="NameField" cssclass="NormalTextBox" width="136px" columns="30" maxlength="50"
													runat="server" />
												<asp:requiredfieldvalidator display="Static" runat="server" errormessage="您必須輸入有效名稱" controltovalidate="NameField"
													id="Requiredfieldvalidator1" />
											</td>
											<td width="25" rowspan="5">
												&nbsp;
											</td>
											<td class="Normal" width="250">
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												角色:
											</td>
											<td>
												<asp:textbox id="RoleField" cssclass="NormalTextBox" width="208px" columns="30" maxlength="100"
													runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												電子郵件:
											</td>
											<td>
												<asp:textbox id="EmailField" cssclass="NormalTextBox" width="248px" columns="30" maxlength="100"
													runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												連絡人 1:
											</td>
											<td>
												<asp:textbox id="Contact1Field" cssclass="NormalTextBox" width="136px" columns="30" maxlength="250"
													runat="server" />
											</td>
										</tr>
										<tr valign="top">
											<td class="SubHead">
												連絡人 2:
											</td>
											<td>
												<asp:textbox id="Contact2Field" cssclass="NormalTextBox" width="135px" columns="30" maxlength="250"
													runat="server" />
											</td>
										</tr>
									</table>
									<p>
										<asp:linkbutton id="updateButton" text="更新" runat="server" class="CommandButton" borderstyle="none" />
										&nbsp;
										<asp:linkbutton id="cancelButton" text="取消" causesvalidation="False" runat="server" class="CommandButton"
											borderstyle="none" />
										&nbsp;
										<asp:linkbutton id="deleteButton" text="刪除此項目" causesvalidation="False" runat="server" class="CommandButton"
											borderstyle="none" />
										<hr noshade size="1" width="500">
										<span class="Normal">建立者
                                            <asp:label id="CreatedBy" runat="server" />
                                            建立日期
                                            <asp:label id="CreatedDate" runat="server" />
                                            <br>
                                        </span>
									<P></P>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
											<!---------------------------------------------------------------------------------------------------------------------->
											<DIV><FONT face="新細明體"></FONT></DIV>
										</TD>
									</TR>
								</TBODY>
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
				</TBODY></table>
		</form>
	</body>
</HTML>

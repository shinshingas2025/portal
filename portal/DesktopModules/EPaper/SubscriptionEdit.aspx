<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubscriptionEdit.aspx.vb" Inherits="ASPNET.StarterKit.Portal.SubscriptionEdit" %>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<link 
href='/PortalFiles/css/<%=Request.Params("sid")%>.css' 
type=text/css rel=stylesheet>
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner>
				<table cellSpacing="0" cellPadding="0" width="60%" align="center" border="0">
					<tr>
						<td colSpan="3">
							<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
								<tr>
									<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
									<td width=120 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="itemtitle">電子報編輯</asp:label></td>
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
										<TABLE id="Table1" height="281" cellSpacing="0" cellPadding="0" width="100%" align="center"
											border="0">
											<TR>
												<TD align="center" width="731" colSpan="3" height="20"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD class="SubHead" width="35" height="20"><FONT face="新細明體">電子報標題</FONT></TD>
												<TD width="290" height="20"><asp:textbox id="TextBoxTitle" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="請輸入標題!"></asp:requiredfieldvalidator></TD>
												<TD width="365" height="20"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD class="SubHead" width="35" height="20"><FONT face="新細明體">電子報描述</FONT></TD>
												<TD width="290" height="20"><FONT face="新細明體"><asp:textbox id="TextBoxDescription" runat="server" Width="344px" Height="56px" TextMode="MultiLine"></asp:textbox></FONT></TD>
												<TD width="365" height="20">
													<P><asp:radiobutton id="RadioButtonDisable" runat="server" Text="未上線" GroupName="SelectMode" Checked="True"></asp:radiobutton></P>
													<P><asp:radiobutton id="RadioButtonEnable" runat="server" Text="上線" GroupName="SelectMode"></asp:radiobutton><asp:label id="LabelEnable" runat="server" Visible="False" ForeColor="Red"></asp:label></P>
													<P><asp:radiobutton id="RadioButtonHistory" runat="server" Text="歷史檔" GroupName="SelectMode"></asp:radiobutton></P>
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="3"><asp:button id="ButtonOK" runat="server" Text="確定"></asp:button><asp:button id="ButtonCancel" runat="server" Text="取消"></asp:button>
													<asp:Button id="ButtonReturn" runat="server" Text="返回"></asp:Button></td>
											</tr>
										</TABLE>
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
		</P>
	</body>
</HTML>

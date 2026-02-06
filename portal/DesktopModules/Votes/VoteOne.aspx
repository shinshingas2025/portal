<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VoteOne.aspx.vb" Inherits="ASPNET.StarterKit.Portal.VoteOne" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Bottom" Src="~/DesktopModuleBottom.ascx"%>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="~/DesktopPortalBanner.ascx" %>
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
		<form id="Form1" method="post" runat="server">
			<P><uc1:desktopportalbanner id="DesktopPortalBanner1" runat="server"></uc1:desktopportalbanner><FONT face="新細明體"></FONT></P>
			<TABLE class="TTable" id="Table1" height="0" cellSpacing="0" cellPadding="0" width="50%"
				align="center" border="0">
				<TR>
					<td><asp:label id="Label1" runat="server" CssClass="subhead">投票主題：</asp:label></td>
					<TD colSpan="2"><asp:label id="VoteSubject" runat="server" CssClass="SubSubHead"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><FONT face="新細明體">
							<HR align="right" width="80%" SIZE="1">
						</FONT>
					</TD>
				</TR>
				<tr>
					<td><asp:label id="Label2" runat="server" CssClass="subhead">投票內容：</asp:label></td>
					<td colSpan="2"><asp:label id="VoteDescription" runat="server" CssClass="normal"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top"><asp:label id="Label3" runat="server" CssClass="subhead">投票選項：</asp:label></td>
					<td colSpan="2"><asp:placeholder id="OptionControl" runat="server"></asp:placeholder></td>
				</tr>
				<TR>
					<TD><asp:label id="Label4" runat="server" CssClass="subhead">投票時間：</asp:label></TD>
					<TD><asp:label id="VoteDateLabel" runat="server" CssClass="small" Font-Size="X-Small"></asp:label></TD>
				</TR>
				<tr>
					<td><FONT face="新細明體"></FONT></td>
					<td><asp:label id="ResultLabel" runat="server" Font-Size="X-Small"></asp:label></td>
					<td>
						<table cellPadding="0" align="right" border="0" cellspacing0>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></td>
											<td 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                ><asp:linkbutton id="VoteLinkButton" runat="server" CssClass="CommandButton">我要投票</asp:linkbutton></td>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></td>
										</tr>
									</table>
								</td>
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></td>
											<td 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                ><asp:linkbutton id="ResultLinkButton" runat="server" CssClass="CommandButton">看結果</asp:linkbutton></td>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></td>
										</tr>
									</table>
								</td>
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn01.gif' ></td>
											<td 
                background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn02.gif' 
                ><asp:linkbutton id="ReturnLinkButton" runat="server" CssClass="CommandButton">返回</asp:linkbutton></td>
											<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Btn03.gif' ></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SendMail.aspx.vb" Inherits="SendMail"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>郵件寄送</title>
		<link rel="stylesheet" href='/PortalFiles/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body bottomMargin=0 leftMargin=0 
background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' 
topMargin=0 rightMargin=0 marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<P>
				<FONT face="新細明體"></FONT>&nbsp;</P>
			<P><FONT face="新細明體">&nbsp;</P>
			<table width="500" border="0" cellpadding="0" cellspacing="0" align="center">
				<tr>
					<td colspan="3">
						<table cellSpacing="0" cellPadding="0" width="98%" align="right" border="0">
							<tr>
								<td width="1"><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0003.gif' ></td>
								<td width=144 
          background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0004.gif' 
          ><asp:label id="Label7" runat="server" CssClass="head">郵件寄送</asp:label></td>
								<td><IMG src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif' ></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div01.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div02.gif'></td>
					<td width="1"><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div03.gif'></td>
				</tr>
				<tr>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div04.gif'></td>
					<td bgcolor="#ffffff" width="100%">
						<table width="100%" border="0">
							<tr>
								<td>
									<!------------------------------------------------------------------------------------------>
									<TABLE id="Table1" height="244" cellSpacing="0" cellPadding="0" width="584" border="0"
										align="center">
										<TR>
											<TD width="96">
												<asp:Label id="Label1" runat="server" CssClass="normal">收件人</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtTo" runat="server" Columns="60"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD width="96" height="27">
												<asp:Label id="Label2" runat="server" CssClass="normal">郵件主題</asp:Label></TD>
											<TD height="27">
												<asp:TextBox id="txtSubject" runat="server" Columns="60"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD width="96" height="150">
												<asp:Label id="Label3" runat="server" CssClass="normal">內容</asp:Label></TD>
											<TD height="150">
												<asp:TextBox id="txtBody" runat="server" TextMode="MultiLine" Rows="10" Columns="60"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD width="96" height="26"></TD>
											<TD height="26">
												<asp:Label id="lblResult" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></TD>
										</TR>
										<TR>
											<TD width="96" height="27"></TD>
											<TD height="27">
												<P align="center">
													<asp:Button id="btnSend" runat="server" Text="送出"></asp:Button></P>
											</TD>
										</TR>
										<TR>
											<TD width="96"></TD>
											<TD></TD>
										</TR>
									</TABLE>
									</FONT> 
									<!------------------------------------------------------------------------------------------------>
								</td>
							</tr>
						</table>
					</td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div05.gif'></td>
				</tr>
				<tr>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div06.gif'></td>
					<td background='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif' ><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div07.gif'></td>
					<td><img src='/PortalFiles/WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_Div08.gif'></td>
				</tr>
			</table>
		</form>
		</FONT>
	</body>
</HTML>

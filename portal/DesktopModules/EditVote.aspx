<%@ Register TagPrefix="uc1" TagName="DesktopPortalBanner" Src="../DesktopPortalBanner.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditVote.aspx.vb" Inherits="ASPNET.StarterKit.Portal.EditVote" %>
<%@ Import Namespace="ASPNET.StarterKit.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<link rel="stylesheet" href='<%=Global.GetApplicationPath(Request)%>/css/<%=Request.Params("sid")%>.css' type="text/css">
	</HEAD>
	<body  leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0"  background='../WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0002.gif' >
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:DesktopPortalBanner id="DesktopPortalBanner1" runat="server"></uc1:DesktopPortalBanner>
				<TABLE id="Table1" height="281" cellSpacing="0" cellPadding="0" width="400" border="0"
					align="center">
					<TR>
						<TD width="35" colSpan="2">
							<asp:Label id="Label1" runat="server" Width="376px" CssClass="Head">新增線上投票</asp:Label></TD>
					</TR>
					<TR>
						<TD width="35" height="20" class="SubHead"><FONT face="新細明體">題目</FONT></TD>
						<TD height="20"><FONT face="新細明體">
								<asp:TextBox id="txtQuestion" runat="server" Width="344px" Height="56px" TextMode="MultiLine"></asp:TextBox></FONT></TD>
					</TR>
					<TR>
						<TD width="35" valign="top" height="157" class="SubHead"><FONT face="新細明體">答案</FONT></TD>
						<TD height="157"><FONT face="新細明體">
								<TABLE id="Table2" height="117" cellSpacing="0" cellPadding="0" width="332" border="0">
									<TR>
										<TD vAlign="top" width="145">
											<asp:TextBox id="txtAnswer" runat="server" Height="136px" TextMode="MultiLine"></asp:TextBox></TD>
										<TD width="14">
											<asp:ImageButton id="imageRight" runat="server" ImageUrl="../images/rt.gif"></asp:ImageButton>
											<asp:ImageButton id="ImageLeft" runat="server" ImageUrl="../images/delete.gif"></asp:ImageButton></TD>
										<TD vAlign="top">
											<asp:ListBox id="listAnswers" runat="server" Width="116px" Height="144px"></asp:ListBox></TD>
									</TR>
								</TABLE>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="35"></TD>
						<TD align="right"><FONT face="新細明體">
								<asp:LinkButton id="linkOK" runat="server" CssClass="CommandButton">確定</asp:LinkButton></FONT></TD>
					</TR>
				</TABLE>
				<FONT face="新細明體"></FONT>
			</P>
		</form>
	</body>
</HTML>

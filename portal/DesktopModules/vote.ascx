<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="ASPNET.StarterKit.Portal.vote" CodeBehind="vote.ascx.vb" language="vb" AutoEventWireup="false" %>
<aspnetportal:title editurl="~/DesktopModules/EditVote.aspx" edittext="編輯" runat="server" id="Title1" />
<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="TTable">
	<TR>
		<TD>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD height="17"></TD>
					<TD height="17">
						<Img src='WebImage/<%=Request.Params("sid")%>/<%=Request.Params("sid")%>_0005.gif'  alt=項目>
						<FONT face="新細明體">
							<asp:Label id="lblquestion" runat="server" CssClass="subhead"></asp:Label></FONT></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:RadioButtonList id="ralistAnswer" runat="server" Font-Size="X-Small"></asp:RadioButtonList></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right">
						<asp:Label id="lblResult" runat="server" Font-Size="X-Small"></asp:Label>&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="LinkButton1" runat="server" CssClass="CommandButton">我要投票</asp:LinkButton><FONT face="新細明體">&nbsp;
						</FONT>
						<asp:LinkButton id="linkResult" runat="server" CssClass="CommandButton">看結果</asp:LinkButton><BR>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>

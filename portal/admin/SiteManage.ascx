<%@ Control Inherits="ASPNET.StarterKit.Portal.SiteManage" CodeBehind="SiteManage.ascx.vb" language="vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="DesktopModuleTitle" Src="../DesktopModuleTitle.ascx" %>
<FONT face="新細明體">
	<uc1:desktopmoduletitle id="DesktopModuleTitle1" runat="server"></uc1:desktopmoduletitle><BR>
	<BR>
	<BR>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
		<TR>
			<TD class="subhead" vAlign="top" width="115">現有網站編號</TD>
			<TD><asp:listbox id="ListBox1" runat="server"></asp:listbox></TD>
			<TD vAlign="bottom"></TD>
		</TR>
		<TR>
			<TD class="subhead" width="115">新增網站編號</TD>
			<TD><asp:textbox id="txtSiteNo" runat="server" Width="100px"></asp:textbox></TD>
			<TD align="left"><asp:linkbutton id="LinkButton1" runat="server" CssClass="CommandButton">新增</asp:linkbutton></TD>
		</TR>
		<TR>
			<TD width="115"></TD>
			<TD><asp:label id="lblResult" runat="server"></asp:label></TD>
			<TD></TD>
		</TR>
	</TABLE>
</FONT>

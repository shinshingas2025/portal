<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RSSList.ascx.vb" Inherits="ASPNET.StarterKit.Portal.RSSList" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<ASPNETPortal:title EditText="新增資料" EditUrl="~/DesktopModules/announce.aspx" runat="server" id="Title1" />
<asp:Repeater id="Repeater1" runat="server">
	<HeaderTemplate>
		<table border="0" style="width: 240px; font-size: x-small; color: black; font-family: Verdana;">
			<thead>
				<tr style="font-weight: bold;">
					<td><%#Me.Title%></td>
				</tr>
				<tr style="font-style: italic;">
					<td><%#Me.Description%></td>
				</tr>
			</thead>
	</HeaderTemplate>
	<ItemTemplate>
		<tr bgcolor="LightBlue">
			<td>
				<asp:HyperLink id="Hyperlink1" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "link") %>' Visible="True" Target=_blank ForeColor="#000000" runat="server" >
					<%# DataBinder.Eval(Container.DataItem, "title") %>
				</asp:HyperLink>
			</td>
		</tr>
		<tr bgcolor="Ivory">
			<td style="color: CornFlowerBlue;">
				<%# DataBinder.Eval(Container.DataItem, "description") %>
			</td>
		</tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
		<tr bgcolor="Orange">
			<td>
				<asp:HyperLink id="editLink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "link") %>' Visible="True" Target=_blank ForeColor="#000000" runat="server" >
					<%# DataBinder.Eval(Container.DataItem, "title") %>
				</asp:HyperLink>
			</td>
		</tr>
		<tr bgcolor="Ivory">
			<td style="color: CornFlowerBlue;">
				<%# DataBinder.Eval(Container.DataItem, "description") %>
			</td>
		</tr>
	</AlternatingItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>

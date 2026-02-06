<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="ASPNET.StarterKit.Portal.Roles" CodeBehind="Roles.ascx.vb" language="vb" AutoEventWireup="false" %>
<ASPNETPortal:title runat="server" id="Title1" />
<table cellpadding="2" cellspacing="0" border="0">
	<tr valign="top">
		<td class="Normal" width="100">
			&nbsp;
		</td>
		<td>
			<asp:DataList id="rolesList" DataKeyField="RoleID" runat="server">
				<ItemTemplate>
					<asp:ImageButton ImageUrl="~/images/edit.gif" CommandName="edit" AlternateText="編輯此項目" runat="server" />
					<asp:ImageButton ImageUrl="~/images/delete.gif" CommandName="delete" AlternateText="刪除此項目" runat="server" />
					&nbsp;&nbsp;
					<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "RoleName") %>' cssclass="Normal" runat="server" />
				</ItemTemplate>
				<EditItemTemplate>
					<asp:Textbox id="roleName" width="200" cssclass="NormalTextBox" Text='<%# DataBinder.Eval(Container.DataItem, "RoleName") %>' runat="server" />
					&nbsp;
					<asp:LinkButton Text="套用" CommandName="apply" cssclass="CommandButton" runat="server" />
					&nbsp;
					<asp:LinkButton Text="變更角色成員" CommandName="members" cssclass="CommandButton" runat="server" />
				</EditItemTemplate>
			</asp:DataList>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:LinkButton cssclass="CommandButton" Text="新增角色" runat="server" id="AddRoleBtn">
                新增角色</asp:LinkButton>
		</td>
	</tr>
</table>

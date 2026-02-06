<%@ Control Inherits="ASPNET.StarterKit.Portal.Users" CodeBehind="Users.ascx.vb" language="vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>

<ASPNETPortal:title runat="server" id="Title1" />
<table cellpadding="2" cellspacing="0" border="0" >
    <tr valign="top">
        <td width="100">
            &nbsp;
        </td>
        <td class="Normal">
            <asp:Literal id="Message" runat="server" />
            <br><br>
        </td>
    </tr>
    <tr valign="top">
        <td>
            &nbsp;
        </td>
        <td class="Normal">
            註冊的使用者:&nbsp;
            <asp:DropDownList id="allUsers" DataTextField="Email" DataValueField="UserID" runat="server" />
            &nbsp;
            <asp:ImageButton ImageUrl="~/images/edit.gif" CommandName="edit" AlternateText="編輯此使用者" runat="server" ID="EditBtn" />
            <asp:ImageButton ImageUrl="~/images/delete.gif" AlternateText="刪除此使用者" runat="server" ID="DeleteBtn" />
            &nbsp;
            <asp:LinkButton id="addNew" cssclass="CommandButton" CommandName="Add" Text="新增使用者" runat="server" />
        </td>
    </tr>
</table>

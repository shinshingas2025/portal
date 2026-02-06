<%@ Control Inherits="ASPNET.StarterKit.Portal.SiteSettings" CodeBehind="SiteSettings.ascx.vb" language="vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/DesktopModuleTitle.ascx"%>

<ASPNETPortal:title runat="server" id=Title1 />
<table cellpadding="2" cellspacing="0" border="0">
    <tr>
        <td width="100" class="Normal">
            網站標題:
        </td>
        <td colspan="2" class="NormalTextBox">
            <asp:Textbox id="siteName" width="240" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="Normal">
            一直顯示編輯按鈕?:
        </td>
        <td colspan="2" class="Normal">
            <asp:CheckBox id="showEdit" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td colspan="2">
            <asp:LinkButton id="applyBtn" class="CommandButton" Text="套用變更" runat="server" />
        </td>
    </tr>
</table>

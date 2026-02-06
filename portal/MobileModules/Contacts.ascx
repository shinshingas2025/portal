<%@ Control Language="vb" Inherits="ASPNET.StarterKit.Portal.MobilePortalModuleControl" Debug="true" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/MobileModuleTitle.ascx" %>
<%@ Register TagPrefix="ASPNETPortal" Namespace="ASPNET.StarterKit.Portal.MobileControls" Assembly="ASPNETPortal" %>
<%@ import Namespace="System.Data" %>

<%--

    The Contacts Mobile User Control renders Contacts modules in the
    mobile portal. 

    The control consists of two pieces: a summary panel that is rendered when
    portal view shows a summarized view of all modules, and a multi-part panel 
    that renders the module details.

--%>

<script runat="server">

    Dim ds as DataSet = Nothing
    Dim currentIndex as Int32 = 0
    
    '*********************************************************************
    '
    ' Page_Load Event Handler
    '
    ' The Page_Load event handler on this User Control is used to
    ' obtain a DataSet of contact information from the Contacts
    ' database, and then databind the results to the module contents.
    '
    '*********************************************************************
    
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) 
    
        ' Obtain announcement information from Contacts table
        Dim ct As ASPNET.StarterKit.Portal.ContactsDB = New ASPNET.StarterKit.Portal.ContactsDB()
        ds = ct.GetContacts(ModuleId)
    
        ' DataBind User Control
        DataBind()
    End Sub
    
    '*********************************************************************
    '
    ' SummaryView_OnClick Event Handler
    '
    ' The SummaryView_OnClick event handler is called when the user
    ' clicks on the link in the summary view. It shows the list of
    ' contacts.
    '
    '*********************************************************************
    
    Sub SummaryView_OnClick(ByVal sender As Object, ByVal e As EventArgs) 
    
        ' Switch the visible pane of the multi-panel view to show
        ' the list of contacts.
        MainView.ActivePane = ContactsList
    
        ' Make the parent tab switch to details mode, showing this module.
        Tab.ShowDetails(Me)
    End Sub
    
    '*********************************************************************
    '
    ' ContactsList_OnItemCommand Event Handler
    '
    ' The ContactsList_OnItemCommand event handler is called when the user
    ' clicks on a contact in the contact list. It shows the details of the
    ' contact.
    '
    '*********************************************************************
    
    Sub ContactsList_OnItemCommand(ByVal sender As Object, ByVal e As ListCommandEventArgs) 
    
        currentIndex = e.ListItem.Index
        ContactDetails.DataBind()
    
        ' Switch the visible pane of the multi-panel view to show
        ' contact details.
        MainView.ActivePane = ContactDetails
    
        ' rebind the details panel
        ContactDetails.DataBind()
    End Sub
    
    '*********************************************************************
    '
    ' DetailsView_OnClick Event Handler
    '
    ' The DetailsView_OnClick event handler is called when the user
    ' clicks on a link in the contact details view to return to the
    ' list of contacts.
    '
    '*********************************************************************
    
    Sub DetailsView_OnClick(ByVal sender As Object, ByVal e As EventArgs) 
    
        ContactsList.DataBind()
    
        ' Switch the visible pane of the multi-panel view to show
        ' the list of contacts.
        MainView.ActivePane = ContactsList
    End Sub
    
    
    '*********************************************************************
    '
    ' GetPhoneNumber Method
    '
    ' The GetPhoneNumber method extracts a phone number from a contact
    ' entry, if possible, using a regular expression search.
    '
    '*********************************************************************
    
    Private Function GetPhoneNumber(ByVal s As String) as String
    
        If Not (s = String.Empty) Then
    
            ' Look for a phone number.
            Dim phoneMatch as Match = Regex.Match(s, "\+?(\d{3,4}-+.*)+")
            If phoneMatch.Success = True Then
				s = phoneMatch.ToString()
			Else
				s = String.Empty
			End If
        End If
    
        Return s
    End Function
    
    '*********************************************************************
    '
    ' FormatChildField Method
    '
    ' The FormatChildField method returns the selected field as a string,
    ' if the row is not empty.  If empty, it returns String.Empty.
    '
    '*********************************************************************
    
    Private Function FormatChildField (ByVal fieldName as String) as String
    
        If ds.Tables(0).Rows.Count > 0 Then
            return ds.Tables(0).Rows(currentIndex)(fieldName).ToString()
        Else
            return String.Empty
        End If
    End Function

</script>

<mobile:Panel id="summary" runat="server">
    <mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
        <Choice filter="isJScript">
            <CONTENTTEMPLATE>
                <ASPNETPortal:TITLE runat="server" ID="Title1"/>
                <font face="Verdana" size="-2">按一下 <a runat="server" onserverclick="SummaryView_OnClick" ID="A1">這裡</a> 存取連絡人目錄。</font> 
                <br />
            </CONTENTTEMPLATE>
        </Choice>
    </mobile:DeviceSpecific>
</mobile:Panel>
<ASPNETPORTAL:MULTIPANEL id="MainView" runat="server" Font-Name="Verdana" Font-Size="Small">
    <ASPNETPORTAL:CHILDPANEL id="ContactsList" runat="server">
        <ASPNETPORTAL:TITLE runat="server" ID="Title2"/>
        <mobile:List id="List1" runat="server" OnItemCommand="ContactsList_OnItemCommand" DataTextField="Name" DataSource="<%# ds %>">
            <DeviceSpecific>
                <Choice filter="isJScript">
                    <HeaderTemplate>
                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <font face="Verdana" size="-2"><a href='<%# "mailto:" & DataBinder.Eval(CType(Container,MobileListItem).DataItem, "Email") %>'> <%# DataBinder.Eval(CType(Container,MobileListItem).DataItem, "Name") %> </a></font> 
                            </td>
                            <td align="right">
                                <font face="Verdana" size="-2"> 
                                <asp:LinkButton runat="server" Text="詳細資訊" ID="Linkbutton1"/>
                                </font> 
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </Choice>
            </DeviceSpecific>
        </mobile:List>
    </ASPNETPORTAL:CHILDPANEL>
    <ASPNETPORTAL:CHILDPANEL id="ContactDetails" runat="server">
        <ASPNETPORTAL:TITLE runat="server" Text='<%# FormatChildField("Name") %>' ID="Title3"/>
        <b>角色:</b>
        <mobile:Label id="Label1" runat="server" Text='<%# FormatChildField("Role") %>'></mobile:Label>
        <b>電子郵件:</b>
        <mobile:Link id="Link1" runat="server" Text='<%# FormatChildField("Email") %>' NavigateUrl='<%# "mailto:" & FormatChildField("Email") %>'></mobile:Link>
        <b>連絡人:</b>
        <br />
        <mobile:PhoneCall id="PhoneCall1" runat="server" Text='<%# FormatChildField("Contact1") %>' Visible='<%# FormatChildField("Contact1") <> String.Empty %>' PhoneNumber='<%# GetPhoneNumber(FormatChildField("Contact1")) %>' AlternateFormat="{0}"></mobile:PhoneCall>
        <mobile:PhoneCall id="PhoneCall2" runat="server" Text='<%# FormatChildField("Contact2") %>' Visible='<%# FormatChildField("Contact2") <> String.Empty %>' PhoneNumber='<%# GetPhoneNumber(FormatChildField("Contact2")) %>' AlternateFormat="{0}"></mobile:PhoneCall>
        <ASPNETPORTAL:LINKCOMMAND onclick="DetailsView_OnClick" runat="server" Text="back to list" ID="Linkcommand1"/>
    </ASPNETPORTAL:CHILDPANEL>
</ASPNETPORTAL:MULTIPANEL>

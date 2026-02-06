<%@ Control language="VB" Inherits="ASPNET.StarterKit.Portal.MobilePortalModuleControl" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Register TagPrefix="ASPNETPortal" TagName="Title" Src="~/MobileModuleTitle.ascx" %>
<%@ Register TagPrefix="ASPNETPortal" Namespace="ASPNET.StarterKit.Portal.MobileControls" Assembly="ASPNETPortal" %>
<%@ Import Namespace="System.Data" %>
<%--

    The Announcements Mobile User Control renders announcement modules in the
    portal for mobile devices. 

    The control consists of two pieces: a summary panel that is rendered when
    portal view shows a summarized view of all modules, and a multi-part panel 
    that renders the module details.

--%>
<script runat="server">

    Private ds As DataSet = Nothing
    Private currentIndex As Integer = 0

    '*********************************************************************
    '
    ' Page_Load Event Handler
    '
    ' The Page_Load event handler on this User Control is used to
    ' obtain a DataSet of announcement information from the Announcements
    ' table, and then databind the results to the module contents.  It uses 
    ' the ASPNET.StarterKit.PortalAnnouncementsDB() data component 
    ' to encapsulate all data functionality.
    '
    '*******************************************************

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' Obtain announcement information from Announcements table
        Dim announcements As New ASPNET.StarterKit.Portal.AnnouncementsDB()
        ds = announcements.GetAnnouncements(ModuleId)

        ' DataBind the User Control
        DataBind()

    End Sub


    '*********************************************************************
    '
    ' SummaryView_OnItemCommand Event Handler
    '
    ' The SummaryView_OnItemCommand event handler is called when the user
    ' clicks on a "More" link in the summary view. It calls the
    ' ShowAnnouncementDetails utility method to show details of the
    ' announcement.
    '
    '*********************************************************************

    Sub SummaryView_OnItemCommand(ByVal sender As Object, ByVal e As RepeaterCommandEventArgs)

        ShowAnnouncementDetails(e.Item.ItemIndex)

    End Sub


    '*********************************************************************
    '
    ' AnnouncementsList_OnItemCommand Event Handler
    '
    ' The AnnouncementsList_OnItemCommand event handler is called when the user
    ' clicks on an item in the list of announcements. It calls the
    ' ShowAnnouncementDetails utility method to show details of the
    ' announcement.
    '
    '*********************************************************************

    Sub AnnouncementsList_OnItemCommand(ByVal sender As Object, ByVal e As ListCommandEventArgs)

        ShowAnnouncementDetails(e.ListItem.Index)

    End Sub


    '*********************************************************************
    '
    ' DetailsView_OnClick Event Handler
    '
    ' The DetailsView_OnClick event handler is called when the user 
    ' clicks in the details view to return to the summary view.
    '
    '*********************************************************************

    Sub DetailsView_OnClick(ByVal sender As Object, ByVal e As EventArgs)

        ' Make the parent tab show module summaries again.
        Tab.SummaryView = True

    End Sub


    '*********************************************************************
    '
    ' ShowAnnouncementDetails Method
    '
    ' The ShowAnnouncementDetails method sets the active pane of
    ' the module to the details view, and shows the details of the
    ' given item.
    '
    '*********************************************************************'

    Sub ShowAnnouncementDetails(ByVal itemIndex As Integer)

        currentIndex = itemIndex

        ' Switch the visible pane of the multi-panel view to show
        ' announcement details
        MainView.ActivePane = AnnouncementDetails

        ' Rebind the details panel
        AnnouncementDetails.DataBind()

        ' Make the parent tab switch to details mode, showing this module
        Tab.ShowDetails(Me)

    End Sub
    
    '*********************************************************************
    '
    ' FormatChildField Method
    '
    ' The FormatChildField method returns the selected field as a string,
    ' if the row is not empty.  If empty, it returns String.Empty.
    '
    '*********************************************************************

    Function FormatChildField (fieldName As String) As String
    
        If ds.Tables(0).Rows.Count > 0 Then 
            return ds.Tables(0).Rows(currentIndex)(fieldName).ToString()
        Else
            return String.Empty
        End If
            
    End Function            


</script>
<mobile:Panel id="summary" runat="server">
    <DeviceSpecific>
        <Choice Filter="isJScript">
            <ContentTemplate>
                <ASPNETPortal:Title runat="server" />
                <font face="Verdana" size="-2">
                    <asp:Repeater id="announcementList" DataSource="<%# ds %>" OnItemCommand="SummaryView_OnItemCommand" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton runat="server">
                                <%# DataBinder.Eval(Container.DataItem, "Title") %>
                            </asp:LinkButton>
                            <br>
                        </ItemTemplate>
                    </asp:Repeater>
                </font>
                <br>
            </ContentTemplate>
        </Choice>
    </DeviceSpecific>
</mobile:Panel>
<ASPNETPortal:MultiPanel id="MainView" Font-Name="Verdana" Font-Size="Small" runat="server">
    <ASPNETPortal:ChildPanel id="AnnouncementsList" runat="server">
        <ASPNETPortal:Title runat="server" />
        <mobile:List runat="server" DataTextField="Title" DataSource="<%# ds %>" OnItemCommand="AnnouncementsList_OnItemCommand" />
    </ASPNETPortal:ChildPanel>
    <ASPNETPortal:ChildPanel id="AnnouncementDetails" runat="server">
        <ASPNETPortal:Title runat="server" Text='<%# FormatChildField("Title") %>' />
        <mobile:TextView runat="server" Text='<%# FormatChildField("Description") %>' />
        <mobile:Link runat="server" NavigateUrl='<%# FormatChildField("MobileMoreLink") %>' Visible='<%# FormatChildField("MobileMoreLink") <> String.Empty %>' Text="參閱相關資訊" />
        <ASPNETPortal:LinkCommand runat="server" OnClick="DetailsView_OnClick" Text="back" />
    </ASPNETPortal:ChildPanel>
</ASPNETPortal:MultiPanel>

Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class announces
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents myDataList As System.Web.UI.WebControls.DataList

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load event handler on this User Control is used to
        ' obtain a DataReader of event information from the Events
        ' table, and then databind the results to a templated DataList
        ' server control.  It uses the ASPNET.StarterKit.PortalEventDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Obtain the list of events from the Events table
            ' and bind to the DataList Control
            ' cherry add check 是否已登入及是否有編輯權限
            Dim events As New ASPNET.StarterKit.Portal.AnnounceDB
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If Request.IsAuthenticated = False And _portalSettings.ActiveTab.TabIndex = 0 Then
                myDataList.DataSource = events.GetEvents(ModuleId, CType(Session("sid"), String))
            Else
                Dim au As New AuthorityBO
                If Not au.checkAuthorityEdit(Context.User.Identity.Name, ModuleId, 7, Me.Page) Then
                    myDataList.DataSource = events.GetEvents(ModuleId, CType(Session("sid"), String))
                Else
                    myDataList.DataSource = events.GetEventsAll(ModuleId, CType(Session("sid"), String))
                End If
            End If
            myDataList.DataBind()

        End Sub

    End Class

End Namespace

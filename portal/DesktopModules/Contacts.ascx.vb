Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class Contacts
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid

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
        ' obtain a DataReader of contact information from the Contacts
        ' table, and then databind the results to a DataGrid
        ' server control.  It uses the ASPNET.StarterKit.PortalContactsDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Obtain contact information from Contacts table
            ' and bind to the DataGrid Control
            Dim contacts As New ASPNET.StarterKit.Portal.ContactsDB()

            myDataGrid.DataSource = contacts.GetContacts(ModuleId, CType(Session("sid"), String))
            myDataGrid.DataBind()

        End Sub

    End Class

End Namespace
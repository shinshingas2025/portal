Namespace ASPNET.StarterKit.Portal

    Public MustInherit Class Users
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

        Protected WithEvents Message As System.Web.UI.WebControls.Literal
        Protected WithEvents allUsers As System.Web.UI.WebControls.DropDownList
        Protected WithEvents addNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents EditBtn As System.Web.UI.WebControls.ImageButton
        Protected WithEvents DeleteBtn As System.Web.UI.WebControls.ImageButton

        Private tabIndex As Integer = 0
        Private tabId As Integer = 0


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
        ' The Page_Load server event handler on this user control is used
        ' to populate the current roles settings from the configuration system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Verify that the current user has access to access this page
            If PortalSecurity.IsInRoles("Admins") = False And PortalSecurity.IsInRoles("s" & CType(Session("sid"), String)) = False Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If

            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If

            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If

            ' If this is the first visit to the page, bind the role data to the datalist
            If Page.IsPostBack = False Then
                BindData()
            End If

        End Sub


        '*******************************************************
        '
        ' The DeleteUser_Click server event handler is used to add
        ' a new security role for this portal
        '
        '*******************************************************

        Private Sub DeleteUser_Click(ByVal Sender As Object, ByVal e As ImageClickEventArgs) Handles DeleteBtn.Click

            ' get user id from dropdownlist of users
            Dim users As New UsersDB()
            users.DeleteUser(Int32.Parse(allUsers.SelectedItem.Value))

            ' Rebind list
            BindData()

        End Sub


        '*******************************************************
        '
        ' The EditUser_Click server event handler is used to add
        ' a new security role for this portal
        '
        '*******************************************************
        Private Sub EditUser_Click(ByVal Sender As Object, ByVal e As CommandEventArgs) Handles EditBtn.Command, addNew.Command

            ' get user id from dropdownlist of users
            Dim userId As Integer = -1
            Dim _userName As String = ""

            If e.CommandName = "edit" Then

                userId = Int32.Parse(allUsers.SelectedItem.Value)
                _userName = allUsers.SelectedItem.Text

            End If

            ' redirect to edit page
            Response.Redirect(("~/Admin/ManageUsers.aspx?userId=" & userId & "&username=" & _userName & "&tabindex=" & tabIndex & "&tabid=" & tabId & "&sid=" & CType(Session("sid"), String)))

        End Sub


        '*******************************************************
        '
        ' The BindData helper method is used to bind the list of
        ' users for this portal to an asp:DropDownList server control
        '
        '*******************************************************

        Sub BindData()

            ' change the message between Windows and Forms authentication
            If Context.User.Identity.AuthenticationType <> "Forms" Then

                Message.Text = "使用者必須註冊才能檢視安全內容。使用者可以利用「註冊」表單將自己加入，系統管理員則可以運用上方的「安全性角色」函式，將使用者加入特定的角色。此部分讓系統管理員能直接管理使用者及其安全性角色。"

            Else

                Message.Text = "網域使用者不需註冊即可存取「所有使用者」可用的入口內容。系統管理員可以運用上方的「安全性角色」函式，將使用者加入特定角色。此部分讓系統管理員能直接管理使用者及其安全性角色。"

            End If

            ' Get the list of registered users from the database
			Dim roles As New RolesDB()

            ' bind all portal users to dropdownlist
			allUsers.DataSource = roles.GetUsers()
            allUsers.DataBind()

        End Sub

    End Class

End Namespace

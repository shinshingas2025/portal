Imports System.IO
Namespace ASPNET.StarterKit.Portal
    Public Class SiteManage
        Inherits ASPNET.StarterKit.Portal.PortalModuleControl

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
        Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSiteNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblResult As System.Web.UI.WebControls.Label

        '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
        '請勿刪除或移動它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
            '請勿使用程式碼編輯器進行修改。
            InitializeComponent()
        End Sub

#End Region
        Private tabIndex As Integer = 0
        Private tabId As Integer = 0
        Private sid As String = ""

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁
            ' Verify that the current user has access to access this page
            'If PortalSecurity.IsInRoles("Admins") = False And PortalSecurity.IsInRoles("s" & CType(Session("sid"), String)) = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If
            Dim au As New AuthorityBO
            If Not au.checkAuthorityEdit(Context.User.Identity.Name, ModuleId, 7, Me.Page) Then
                Response.Redirect("~/Admin/EditAccessDenied.aspx")
            End If
            au = Nothing
            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If
            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If
            If Not (Request.Params("sid") Is Nothing) Then
                sid = CType(Request.Params("sid"), String)

            End If
            If Not IsPostBack Then
                getDir()
            End If
        End Sub

        Private Sub getDir()
            '   Response.Redirect("~/Admin/TemplateSelect.aspx?tabindex=" & tabIndex & "&tabid=" & tabId & "&sid=" & sid)

            Dim dr As String
            Dim drs() As String = Directory.GetDirectories(Server.MapPath("WebImage"))

            For Each dr In drs

                ListBox1.Items.Add(dr.Substring(dr.LastIndexOf("\") + 1))
            Next

        End Sub

        Private Sub addSite()
            Dim fs As File

            Dim dr As Directory
            Dim newDir As String = Server.MapPath("WebImage") & "\" & txtSiteNo.Text.Trim
            If dr.Exists(newDir) = True Then
                lblResult.Text = "編號重覆!"
                Exit Sub
            End If

            dr.CreateDirectory(newDir)

            CopyFile(txtSiteNo.Text.Trim)
            lblResult.Text = "新增成功!"
            ListBox1.Items.Add(txtSiteNo.Text.Trim)

        End Sub

        Private Sub CopyFile(ByVal tmpNO As String)
            Dim fs As File
            Dim sourceFile As String
            Dim DestFile As String
            Dim i As Integer


            For i = 1 To 5
                'sourceFile = "/WebTemplate/" & "01" & "/000" & i & ".gif"
                Select Case i
                    Case 1, 2, 3, 4
                        sourceFile = "/WebTemplate/001_000" & i & ".gif"
                    Case 5
                        sourceFile = "/WebTemplate/001_000" & i & ".gif"
                End Select

                ' sourceFile = "C:\Program Files\ASP.NET Starter Kits\ASP.NET Portal (VBVS)\PortalVBVS\Template\qlt2112.gif"
                DestFile = "WebImage/" & tmpNO & "/" & tmpNO & "_000" & i & ".gif"

                fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)

            Next i

            sourceFile = "/WebTemplate/001.css"
            DestFile = "css/" & tmpNO & ".css"
            fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)

            sourceFile = "/WebTemplate/Template.xml"
            DestFile = "xml/" & tmpNO & ".xml"
            fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)

            fs = Nothing
        End Sub

        Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
            addSite()
        End Sub
    End Class
End Namespace

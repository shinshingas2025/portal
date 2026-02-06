Imports System.IO
Namespace ASPNET.StarterKit.Portal


    Public Class TemplateSelect
        Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents linkOK As System.Web.UI.WebControls.LinkButton
        Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblmsg As System.Web.UI.WebControls.Label

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
        Private sid As String = ""

        Private tabId As Integer = 0

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁()
            'Session("sid") = "9999"
            '    If PortalSecurity.IsInRoles("Admins") = False And PortalSecurity.IsInRoles("s" & CType(Session("sid"), String)) = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            '   End If

            ' Calculate userid
            If Not (Request.Params("sid") Is Nothing) Then
                sid = Request.Params("sid")
            End If


            If Not (Request.Params("tabid") Is Nothing) Then
                tabId = Int32.Parse(Request.Params("tabid"))
            End If

            If Not (Request.Params("tabindex") Is Nothing) Then
                tabIndex = Int32.Parse(Request.Params("tabindex"))
            End If

            If Not IsPostBack Then
                Call fillTemplatePic()
            End If


        End Sub

        Private Sub fillTemplatePic()
            Dim objTemplate As New WebTemplateDB
            DataList1.DataSource = objTemplate.GetTemplates.Tables(0).DefaultView()
            DataList1.DataBind()

        End Sub


        Private Function CopyFile(ByVal tmpNO As String) As Boolean
            Dim fs As File
            Dim sourceFile As String
            Dim DestFile As String
            Dim i As Integer


            For i = 1 To 19
                'sourceFile = "/WebTemplate/" & "01" & "/000" & i & ".gif"
                Select Case i
                    Case 1, 2, 3, 4, 5, 6, 7, 8
                        sourceFile = "/WebTemplate/" & tmpNO & "_000" & i & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & CType(Session("sid"), String) & "/" & CType(Session("sid"), String) & "_000" & CType(i, String) & ".gif"
                    Case 9, 10, 11
                        sourceFile = "/WebTemplate/" & tmpNO & "_Btn0" & CType(i - 8, String) & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & CType(Session("sid"), String) & "/" & CType(Session("sid"), String) & "_Btn0" & CType(i - 8, String) & ".gif"

                    Case 12, 13, 14, 15, 16, 17, 18, 19
                        sourceFile = "/WebTemplate/" & tmpNO & "_Div0" & CType(i - 11, String) & ".gif"
                        DestFile = "/PortalFiles/WebImage/" & CType(Session("sid"), String) & "/" & CType(Session("sid"), String) & "_Div0" & CType(i - 11, String) & ".gif"


                End Select

                ' sourceFile = "C:\Program Files\ASP.NET Starter Kits\ASP.NET Portal (VBVS)\PortalVBVS\Template\qlt2112.gif"
                If fs.Exists(Server.MapPath(sourceFile)) Then
                    fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)
                Else
                    lblmsg.Text = "'" & Server.MapPath(sourceFile) & "' 檔案不存在!"
                    Exit Function
                End If

            Next i

            sourceFile = "/WebTemplate/" & tmpNO & ".css"
            DestFile = "/PortalFiles/css/" & CType(Session("sid"), String) & ".css"
            If fs.Exists(Server.MapPath(sourceFile)) Then
                fs.Copy(Server.MapPath(sourceFile), Server.MapPath(DestFile), True)
            Else
                lblmsg.Text = "'" & Server.MapPath(sourceFile) & "' 檔案不存在!"
                Exit Function
            End If
            Return True
            fs = Nothing
        End Function

        Private Sub linkOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkOK.Click

            If DataList1.SelectedIndex < 0 Then
                lblmsg.Text = "請選擇版型!"
                Exit Sub

            End If

            Dim tempNO As String


            tempNO = CType(DataList1.DataKeys(DataList1.SelectedIndex), String)

            If CopyFile(tempNO) = True Then
                Response.Redirect(("~/DesktopDefault.aspx?sid=" & sid & "&tabindex=0&tabid=1"))
            End If
        End Sub



        Private Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
            lblmsg.Text = ""
            DataList1.SelectedIndex = e.Item.ItemIndex
            Call fillTemplatePic()

        End Sub
    End Class


End Namespace

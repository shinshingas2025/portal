Imports System.IO
Namespace ASPNET.StarterKit.Portal


    Public Class EditVote
        Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtQuestion As System.Web.UI.WebControls.TextBox
        Protected WithEvents listAnswers As System.Web.UI.WebControls.ListBox
        Protected WithEvents txtAnswer As System.Web.UI.WebControls.TextBox
        Protected WithEvents imageRight As System.Web.UI.WebControls.ImageButton
        Protected WithEvents linkOK As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ImageLeft As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        Private moduleId As Integer = 0
        Private tabId As Integer = 0

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '在這裡放置使用者程式碼以初始化網頁()
            'Session("sid") = "9999"
            'If PortalSecurity.IsInRoles("Admins") = False Then
            '    Response.Redirect("~/Admin/EditAccessDenied.aspx")
            'End If

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
            moduleId = Int32.Parse(Request.Params("Mid"))

            If Not IsPostBack Then
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If
        End Sub


        Private Sub linkOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkOK.Click
 

            SaveQuestion()

            Response.Redirect(CType(ViewState("UrlReferrer"), String))
        End Sub

        Private Sub SaveQuestion()
            Dim objVoteBO As New VoteDB
            Dim voteid As Integer
            Dim i As Integer
            voteid = objVoteBO.AddVoteQuestion(moduleId, txtQuestion.Text.Trim, sid, "")
            For i = 0 To listAnswers.Items.Count - 1
                Dim litem As New ListItem
                litem = listAnswers.Items(i)

                objVoteBO.AddVoteAnswer(voteid, litem.Text, "")
                litem = Nothing
            Next i

        End Sub


        Private Sub imageRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imageRight.Click
            If txtAnswer.Text.Trim <> "" Then
                listAnswers.Items.Add(txtAnswer.Text)
            End If
        End Sub

        Private Sub ImageLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageLeft.Click
            Dim si As New ListItem
            si = listAnswers.SelectedItem
            If Not si Is Nothing Then
                listAnswers.Items.Remove(si)
            End If
        End Sub
    End Class


End Namespace

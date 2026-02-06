Namespace ASPNET.StarterKit.Portal


    Public Class VoteResult
        Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

        '此為 Web Form 設計工具所需的呼叫。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
        Protected WithEvents linkBack As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblQuestion As System.Web.UI.WebControls.Label

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
        Private voteid As Integer = 0

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
            ' moduleId = Int32.Parse(Request.Params("Mid"))
            voteid = Int32.Parse(Request.Params("voteid"))
            If Not IsPostBack Then
                ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

            End If

                GetResult()

        End Sub




        Private Sub GetResult()
            Dim objVoteBO As New VoteDB
            Dim dr As SqlDataReader
            dr = objVoteBO.GetSingleVoteQuestion(voteid)
            Dim HtmlBody As String
            Dim total As Integer

            Dim txtBody As New Literal
            HtmlBody = "<TABLE align=center id=""Table1"" cellSpacing=""2"" cellPadding=""2""  border=""0"" class=TTable1>"

            While dr.Read

                total += CType(dr.Item("Result"), Integer)
            End While
            If total = 0 Then
                total = 1
            End If
            dr = objVoteBO.GetSingleVoteQuestion(voteid)
            While dr.Read
                lblQuestion.Text = CType(dr.Item("Question"), String)
                HtmlBody &= "<TR><TD class=""subhead"">"
                HtmlBody &= CType(dr.Item("Answer"), String)
                HtmlBody &= "</TD><TD >"
                HtmlBody &= "<IMG SRC=""../images/bar.jpg"" height=""16"" width=" & CType(CType(dr.Item("Result"), Integer) / total * 400, String) & " Align=TextTop>"
                HtmlBody &= "</TD><TD class=""SubSubHead"">"
                HtmlBody &= CType(CType(dr.Item("Result"), Integer) / total * 100, Integer) & "%"
                HtmlBody &= "</TD</TR>"


            End While
            HtmlBody &= "</TABLE>"

            txtBody.Text = HtmlBody
            Panel1.Controls.Add(txtBody)
        End Sub



        Private Sub linkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkBack.Click
            Response.Redirect(CType(ViewState("UrlReferrer"), String))
        End Sub
    End Class

End Namespace

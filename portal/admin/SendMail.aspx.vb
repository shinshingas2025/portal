Public Class SendMail
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label
	Protected WithEvents Label2 As System.Web.UI.WebControls.Label
	Protected WithEvents Label3 As System.Web.UI.WebControls.Label
	Protected WithEvents btnSend As System.Web.UI.WebControls.Button
	Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
	Protected WithEvents txtBody As System.Web.UI.WebControls.TextBox
	Protected WithEvents lblResult As System.Web.UI.WebControls.Label
	Protected WithEvents Label7 As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
    End Sub

	Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
		If SendMail() = True Then
			lblResult.Text = "信件已送出!"
		Else
			lblResult.Text = "信件寄送失敗!"
		End If
	End Sub

	Public Function SendMail() As Boolean

		Dim ML As New Mail

		Dim pwd As String
		Dim mailBody As String
		Dim email As String

		ML.From = "lewishuang@rpti3.com.tw"

		ML.Subject = txtSubject.Text.Trim

		ML.SendTo = txtTo.Text.Trim


		ML.Body = txtBody.Text.Trim

		If ML.SendMail = True Then
			Return True

		Else
		Return False

		End If
	End Function
End Class

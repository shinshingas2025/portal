Public Class table_del1
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label

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
        Dim cm01 As New MsgBO
        Dim cm02 As New WorkBO
        Dim cm03 As New StopBO
        Dim cm04 As New ProductsBO
        Dim cm05 As New SecurityBO
        Dim cm06 As New InvestBO
        Dim cm07 As New DownloadBO
        Dim cm08 As New FaqBO
        Dim cm09 As New HotnewsBO
        Dim cm10 As New IforBO
        Dim cm11 As New ItemBO
        Dim cm12 As New ContactBO

        cm01.DeleteAll()
        cm02.DeleteAll()
        cm03.DeleteAll()
        cm04.DeleteAll()
        cm05.DeleteAll()
        cm06.DeleteAll()
        cm07.DeleteAll()
        cm08.DeleteAll()
        cm09.DeleteAll()
        cm10.DeleteAll()
        cm11.DeleteAll()
        cm12.DeleteAll()

        txtResult.Text = "刪除成功!"
    End Sub

End Class

Imports System.Configuration

Public Class Contact_deatail_report
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents refDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents refDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents refDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents dealDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents dealDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents inquire As System.Web.UI.WebControls.Button

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e7%b6%b2%e7%ab%99%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%98%a0%e8%a1%a8&rc:Parameters=false"


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim status As String = likeSelect.SelectedValue
        '處理狀態
        If status = "9" Then
            status = "%"
        ElseIf status = "0" Then
            status = "0"
        ElseIf status = "1" Then
            status = "1"
        ElseIf status = "2" Then
            status = "2"
        ElseIf status = "3" Then
            status = "3"
        End If

        '反映日期
        Dim sdate1 As String
        Dim edate1 As String
        If refDate.Checked = True Then
            sdate1 = refDateStart.Text
            edate1 = refDateEnd.Text
        ElseIf refDate.Checked = False Then
            sdate1 = "2000/01/01"
            edate1 = "3000/01/01"
        End If

        '處理日期
        Dim sdate2 As String
        Dim edate2 As String
        If dealDate.Checked = True Then
            sdate2 = dealDateStart.Text
            edate2 = dealDateEnd.Text
        ElseIf dealDate.Checked = False Then
            sdate2 = "2000/01/01"
            edate2 = "3000/01/01"
        End If

        '其他
        Dim cntname As String
        Dim cnttel As String
        Dim cntcontent As String
        Dim cntsubject As String
        If likeSelect.SelectedValue = "反映姓名" Then
            cntname = "%" & likeContent.Text & "%"
            cnttel = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "聯絡電話" Then
            cnttel = "%" & likeContent.Text & "%"
            cntname = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "主旨" Then
            cntcontent = "%" & likeContent.Text & "%"
            cnttel = "%"
            cntname = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "內容" Then
            cntsubject = "%" & likeContent.Text & "%"
            cnttel = "%"
            cntcontent = "%"
            cntname = "%"
        End If

        Response.Redirect(IFrameSrc & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&myStartDate2=" & sdate2 & "&myEndDate2=" & edate2 _
        & "&cntname=" & cntname & "&concontent=" & cntcontent & "&workstatus=" & status & "&cnttel=" & cnttel & "&cntsubject=" & cntsubject)

    End Sub
End Class

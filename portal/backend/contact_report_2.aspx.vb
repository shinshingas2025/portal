Imports System.Configuration
Public Class contact_report_2
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents refDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents refDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents refDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents dealDateStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents dealDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents closeDate As System.Web.UI.WebControls.RadioButton  ' cherry add 20071226
    Protected WithEvents closeDateStart As System.Web.UI.WebControls.TextBox ' cherry add 20071226
    Protected WithEvents closeDateEnd As System.Web.UI.WebControls.TextBox   ' cherry add 20071226
    Protected WithEvents dealStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents inquire As System.Web.UI.WebControls.Button
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Radiobutton1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents cnttype As System.Web.UI.WebControls.DropDownList

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%98%a0%e7%b8%bd%e8%a1%a8&rc:Parameters=false"
    Private IFrameSrc2 As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e7%b6%b2%e7%ab%99%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%87%89%e8%a1%a8_%e7%b0%a1&rc:Parameters=false"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
    End Sub



    Private Sub inquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inquire.Click
        Dim status As String = dealStatus.SelectedValue
        Dim scnttype As String = cnttype.SelectedValue

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

        '意見分類
        scnttype = "2"


        '反映日期
        Dim sdate1 As String
        Dim edate1 As String
        Dim checkstatus As String
        checkstatus = ""
        If refDate.Checked = True Then
            'sdate1 = Left(refDateStart.Text, 4) + "/" + Mid(refDateStart.Text, 5, 2) + "/" + Right(refDateStart.Text, 2)
            'edate1 = Left(refDateEnd.Text, 4) + "/" + Mid(refDateEnd.Text, 5, 2) + "/" + Right(refDateEnd.Text, 2)
            sdate1 = refDateStart.Text
            edate1 = refDateEnd.Text
            checkstatus = "1"
        ElseIf refDate.Checked = False Then
            sdate1 = "20000101"
            edate1 = "30000101"
        End If

        '處理日期
        Dim sdate2 As String
        Dim edate2 As String
        If dealDate.Checked = True Then
            sdate2 = Left(dealDateStart.Text, 4) + "/" + Mid(dealDateStart.Text, 5, 2) + "/" + Right(dealDateStart.Text, 2)
            edate2 = Left(dealDateEnd.Text, 4) + "/" + Mid(dealDateEnd.Text, 5, 2) + "/" + Right(dealDateEnd.Text, 2)
            checkstatus = "2"
        ElseIf dealDate.Checked = False Then
            sdate2 = "2000/01/01"
            edate2 = "3000/01/01"
        End If

        '結案日期 cherry add 20071226
        Dim sdate3 As String
        Dim edate3 As String
        If closeDate.Checked = True Then
            sdate3 = Left(closeDateStart.Text, 4) + "/" + Mid(closeDateStart.Text, 5, 2) + "/" + Right(closeDateStart.Text, 2)
            edate3 = Left(closeDateEnd.Text, 4) + "/" + Mid(closeDateEnd.Text, 5, 2) + "/" + Right(closeDateEnd.Text, 2)
            checkstatus = "3"
        ElseIf closeDate.Checked = False Then
            sdate3 = "2000/01/01"
            edate3 = "3000/01/01"
        End If

        '其他
        Dim cntname As String
        Dim cnttel As String
        Dim cntcontent As String
        Dim cntsubject As String
        If likeSelect.SelectedValue = "cntname" Then
            If likeContent.Text <> "" Then
                cntname = "%" & likeContent.Text & "%"
            Else
                cntname = "%"
            End If
            cnttel = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cnttel" Then
            If likeContent.Text <> "" Then
                cnttel = "%" & likeContent.Text & "%"
            Else
                cnttel = "%"
            End If
            cntname = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cntcontent" Then
            If likeContent.Text <> "" Then
                cntcontent = "%" & likeContent.Text & "%"
            Else
                cntcontent = "%"
            End If
            cnttel = "%"
            cntname = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cntsubject" Then
            If likeContent.Text <> "" Then
                cntsubject = "%" & likeContent.Text & "%"
            Else
                cntsubject = "%"
            End If
            cnttel = "%"
            cntcontent = "%"
            cntname = "%"
        End If

        'Response.Redirect(IFrameSrc & " & myStartDate = " & sdate1 & " & myEndDate = " & edate1 & " & myStartDate2 = " & sdate2 & " & myEndDate2 = " & edate2 & " & cntname = " & cntname & " & concontent = " & cntcontent & " & workstatus = " & status & " & cnttel = " & cnttel & " & cntsubject = " & cntsubject)
        'Response.Redirect(IFrameSrc & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&myStartDate2=" & sdate2 & "&myEndDate2=" & edate2 & "&status=" & status & "&myStartDate3=" & sdate3 & "&myEndDate3=" & edate3 & "&checkstatus=" & checkstatus)
        'Response.Redirect(IFrameSrc & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&myStartDate2=" & sdate2 & "&myEndDate2=" & edate2 & "&status=" & status)
        Response.Redirect(IFrameSrc & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&status=" & status & "&cnttype=" & scnttype)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim status As String = dealStatus.SelectedValue
        Dim scnttype As String = cnttype.SelectedValue

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

        '意見分類
        scnttype = "2"

        '反映日期
        Dim sdate1 As String
        Dim edate1 As String
        Dim checkstatus As String
        If refDate.Checked = True Then
            'sdate1 = Left(refDateStart.Text, 4) + "/" + Mid(refDateStart.Text, 5, 2) + "/" + Right(refDateStart.Text, 2)
            'edate1 = Left(refDateEnd.Text, 4) + "/" + Mid(refDateEnd.Text, 5, 2) + "/" + Right(refDateEnd.Text, 2)
            'checkstatus = "1"
            sdate1 = refDateStart.Text
            edate1 = refDateEnd.Text
        ElseIf refDate.Checked = False Then
            sdate1 = "20000101"
            edate1 = "30000101"
        End If

        '處理日期
        Dim sdate2 As String
        Dim edate2 As String
        If dealDate.Checked = True Then
            sdate2 = Left(dealDateStart.Text, 4) + "/" + Mid(dealDateStart.Text, 5, 2) + "/" + Right(dealDateStart.Text, 2)
            edate2 = Left(dealDateEnd.Text, 4) + "/" + Mid(dealDateEnd.Text, 5, 2) + "/" + Right(dealDateEnd.Text, 2)
            checkstatus = "2"
        ElseIf dealDate.Checked = False Then
            sdate2 = "2000/01/01"
            edate2 = "3000/01/01"
        End If

        '結案日期 cherry add 20071226
        Dim sdate3 As String
        Dim edate3 As String
        If closeDate.Checked = True Then
            sdate3 = Left(closeDateStart.Text, 4) + "/" + Mid(closeDateStart.Text, 5, 2) + "/" + Right(closeDateStart.Text, 2)
            edate3 = Left(closeDateEnd.Text, 4) + "/" + Mid(closeDateEnd.Text, 5, 2) + "/" + Right(closeDateEnd.Text, 2)
            checkstatus = "3"
        ElseIf closeDate.Checked = False Then
            sdate3 = "2000/01/01"
            edate3 = "3000/01/01"
        End If

        '其他
        Dim cntname As String
        Dim cnttel As String
        Dim cntcontent As String
        Dim cntsubject As String
        If likeSelect.SelectedValue = "cntname" Then
            If likeContent.Text <> "" Then
                cntname = "%" & likeContent.Text & "%"
            Else
                cntname = "%"
            End If
            cnttel = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cnttel" Then
            If likeContent.Text <> "" Then
                cnttel = "%" & likeContent.Text & "%"
            Else
                cnttel = "%"
            End If
            cntname = "%"
            cntcontent = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cntcontent" Then
            If likeContent.Text <> "" Then
                cntcontent = "%" & likeContent.Text & "%"
            Else
                cntcontent = "%"
            End If
            cnttel = "%"
            cntname = "%"
            cntsubject = "%"
        ElseIf likeSelect.SelectedValue = "cntsubject" Then
            If likeContent.Text <> "" Then
                cntsubject = "%" & likeContent.Text & "%"
            Else
                cntsubject = "%"
            End If
            cnttel = "%"
            cntcontent = "%"
            cntname = "%"
        End If

        'Response.Redirect(IFrameSrc2 & " & myStartDate = " & sdate1 & " & myEndDate = " & edate1 & " & myStartDate2 = " & sdate2 & " & myEndDate2 = " & edate2 & " & cntname = " & cntname & " & concontent = " & cntcontent & " & workstatus = " & status & " & cnttel = " & cnttel & " & cntsubject = " & cntsubject)
        'Response.Redirect(IFrameSrc2 & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&myStartDate2=" & sdate2 & "&myEndDate2=" & edate2 & "&status=" & status)
        'Response.Redirect(IFrameSrc2 & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&myStartDate2=" & sdate2 & "&myEndDate2=" & edate2 & "&status=" & status & "&myStartDate3=" & sdate3 & "&myEndDate3=" & edate3 & "&checkstatus=" & checkstatus)
        Response.Redirect(IFrameSrc2 & "&myStartDate=" & sdate1 & "&myEndDate=" & edate1 & "&status=" & status & "&cnttype=" & scnttype)
    End Sub

    Private Sub dealDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dealDate.CheckedChanged

    End Sub

    Private Sub refDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refDate.CheckedChanged

    End Sub

    Private Sub closeDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeDate.CheckedChanged
        ' cherry add 20071226

    End Sub
End Class

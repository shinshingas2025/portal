Public Class member_011
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents ApplyEDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ApplySDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents msgbox As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox3 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox4 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox5 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Checkbox6 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox7 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox8 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents likeSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents likeContent As System.Web.UI.WebControls.TextBox
    Protected WithEvents Message As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region
    Dim objDR As DataRow
    Dim objCartDT As DataTable
    Dim AppEDATE, AppSDATE, ProSdate, ProEdate, sendSDATE, sendEDATE As String
    Dim chkCheckBox1 As String = "Y"
    Dim chkCheckBox2 As String = "Y"
    Dim chkCheckBox3 As String = "Y"
    Dim chkCheckBox4 As String = "Y"
    Dim chkCheckBox5 As String = "Y"
    Dim chkCheckBox6 As String = "Y"
    Dim chkCheckBox7 As String = "Y"
    Dim chkCheckBox8 As String = "Y"
    Dim likeSel As String
    Dim likeContxt As String

    Dim ReportServer As String = Configration.ReportServerURL

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------
        ' objCartDT = CType(Session("Cart"), DataTable)
        If Not IsPostBack Then
            Call GetUser(context.User.Identity.Name.Trim)
            'ApplySDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
            'ApplyEDATE.Text = CType(Year(Now), String) + Right("00" + CType(Month(Now), String), 2) + Right("00" + CType(Day(Now), String), 2)
        End If
    End Sub

    Private Sub GetUser(ByVal user As String)
        Dim objUser As New UserInfoBO
        Dim objDeptBO As New OrgBO
        Dim objDept As New DeptExtendOrgEntity
        Dim dt As New DataTable
        dt = objUser.QueryUserInfo(user)
        If dt.Rows.Count > 0 Then
            objDept.DeptID = dt.Rows(0).Item("Dept")
            Creater.Text = dt.Rows(0).Item("Cname")
            dt = objDeptBO.QueryDept(objDept)
            If dt.Rows.Count > 0 Then
                createGroup.Text = dt.Rows(0).Item("objname")
            End If
        End If

    End Sub

    Sub showData()
        Dim se As New WebmemberDotDAO
        Dim tmpAppEDATE As String
        Dim tmpAppSDATE As String

        'CheckBox1.Checked 選擇已啟動、已設定用戶號碼資料
        'CheckBox2.Checked 選擇已啟動、尚未設定用戶號碼資料
        'CheckBox3.Checked 選擇尚未啟動資料
        'CheckBox4.Checked 選擇授權碼發送失敗資料
        'CheckBox5.Checked 選擇停權資料
        'CheckBox6.Checked 選擇個人用戶
        'CheckBox7.Checked 選擇營業用戶
        'CheckBox8.Checked 選擇機關用戶

        If (ApplySDATE.Text.Trim <> "") Then
            tmpAppSDATE = ApplySDATE.Text.Trim
            tmpAppSDATE = Left(tmpAppSDATE, 4) + "/" + Mid(tmpAppSDATE, 5, 2) + "/" + CType(Right(tmpAppSDATE, 2), String) + " 00:00:00"
        Else
            tmpAppSDATE = "1900/01/01 00:00:00"
        End If

        If (ApplySDATE.Text.Trim <> "") Then
            tmpAppEDATE = ApplyEDATE.Text.Trim
            tmpAppEDATE = Left(tmpAppEDATE, 4) + "/" + Mid(tmpAppEDATE, 5, 2) + "/" + CType(Right(tmpAppEDATE, 2), String) + " 23:59:59"
        Else
            tmpAppEDATE = "2099/12/31 23:59:59"
        End If
        sendSDATE = tmpAppSDATE
        sendEDATE = tmpAppEDATE

        If CheckBox1.Checked = False Then
            chkCheckBox1 = "N"
        End If
        If Checkbox2.Checked = False Then
            chkCheckBox2 = "N"
        End If
        If Checkbox3.Checked = False Then
            chkCheckBox3 = "N"
        End If
        If Checkbox4.Checked = False Then
            chkCheckBox4 = "N"
        End If
        If Checkbox5.Checked = False Then
            chkCheckBox5 = "N"
        End If
        If Checkbox6.Checked = False Then
            chkCheckBox6 = "N"
        End If
        If Checkbox7.Checked = False Then
            chkCheckBox7 = "N"
        End If
        If Checkbox8.Checked = False Then
            chkCheckBox8 = "N"
        End If


        '全文檢索內容
        likeSel = Me.likeSelect.SelectedValue
        likeContxt = Me.likeContent.Text.Trim

        objCartDT = se.QueryMemDate(sendSDATE, sendEDATE, chkCheckBox1, chkCheckBox2, chkCheckBox3, chkCheckBox4, chkCheckBox5, chkCheckBox6, chkCheckBox7, chkCheckBox8, likeSel, likeContxt)

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '查詢結果
        msgbox.Text = ""
        showData()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPRNT As String = ""
        showData()
        msgbox.Text = ""
        strPRNT &= ReportServer & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e8%87%aa%e5%a0%b1%e5%ba%a6%e6%95%b8%e4%b8%80%e8%a6%bd%e8%a1%a8&s"
        strPRNT &= "endSDATE=" & sendSDATE
        strPRNT &= "&sendEDATE=" & sendEDATE
        strPRNT &= "&chkCheckBox1=" & chkCheckBox1
        strPRNT &= "&chkCheckBox2=" & chkCheckBox2
        strPRNT &= "&chkCheckBox3=" & chkCheckBox3
        strPRNT &= "&chkCheckBox4=" & chkCheckBox4
        strPRNT &= "&chkCheckBox5=" & chkCheckBox5
        strPRNT &= "&chkCheckBox6=" & chkCheckBox6
        strPRNT &= "&chkCheckBox7=" & chkCheckBox7
        strPRNT &= "&chkCheckBox8=" & chkCheckBox8
        strPRNT &= "&likeSel=" & likeSel
        strPRNT &= "&likeContxt=" & likeContxt
        strPRNT &= "&rc:Parameters=false"

        Response.Redirect(strPRNT)

    End Sub

End Class

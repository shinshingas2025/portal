Imports System.Configuration
Public Class contactMgt_2
    Inherits System.Web.UI.Page

    'Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%98%a0%e5%96%ae&rc:Parameters=false"
    Private IFrameSrc As String = ConfigurationSettings.AppSettings("ReportServerURL") & "?%2f%e6%ac%a3%e6%ac%a3%e5%a0%b1%e8%a1%a8%2f%e6%84%8f%e8%a6%8b%e5%8f%8d%e6%98%a0&rc:Parameters=false"

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents cntno As System.Web.UI.WebControls.Label
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtresult As System.Web.UI.WebControls.Label
    Protected WithEvents cntsubject As System.Web.UI.WebControls.Label
    Protected WithEvents cntName As System.Web.UI.WebControls.Label
    Protected WithEvents cntemail As System.Web.UI.WebControls.Label
    Protected WithEvents cnttel As System.Web.UI.WebControls.Label
    Protected WithEvents createdate As System.Web.UI.WebControls.Label
    Protected WithEvents cntcontent As System.Web.UI.WebControls.Label
    Protected WithEvents remark As System.Web.UI.WebControls.TextBox
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents workstatus As System.Web.UI.WebControls.Label
    Protected WithEvents cntdateno As System.Web.UI.WebControls.Label
    Protected WithEvents workDate As System.Web.UI.WebControls.Label
    Protected WithEvents lastWorkDate As System.Web.UI.WebControls.Label
    Protected WithEvents endWorkDate As System.Web.UI.WebControls.Label
    Protected WithEvents myoperator As System.Web.UI.WebControls.Label
    Protected WithEvents lastOperator As System.Web.UI.WebControls.Label
    Protected WithEvents endOperator As System.Web.UI.WebControls.Label
    Protected WithEvents print As System.Web.UI.WebControls.Button
    Protected WithEvents lastGroup As System.Web.UI.WebControls.Label
    Protected WithEvents endGroup As System.Web.UI.WebControls.Label

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


        If Not IsPostBack Then

            Dim objcntBO As New ContactBO
            Dim dt As DataTable
            Dim statusIndex As String

            cntno.Text = Request.Params("cntno").ToString
            dt = objcntBO.Query(CType(cntno.Text, Integer))
            If dt.Rows.Count > 0 Then
                '讀取資料庫的資料
                If Not IsDBNull(dt.Rows(0).Item("cntdateno")) Then
                    cntdateno.Text = CType(dt.Rows(0).Item("cntdateno"), String)
                End If
                cntsubject.Text = CType(dt.Rows(0).Item("cntsubject"), String)
                cntName.Text = CType(dt.Rows(0).Item("cntname"), String)
                cntemail.Text = CType(dt.Rows(0).Item("cntemail"), String)
                cnttel.Text = CType(dt.Rows(0).Item("cnttel"), String)
                createdate.Text = CType(dt.Rows(0).Item("createdate"), String)
                cntcontent.Text = CType(dt.Rows(0).Item("cntcontent"), String)
                '判斷處理狀態
                statusIndex = CType(dt.Rows(0).Item("workstatus"), String).Trim
                Select Case statusIndex
                    Case "0"    '未指派
                        workstatus.Text = "未指派"
                    Case "1"    '處理中
                        workstatus.Text = "處理中"
                    Case "2"    '已處理
                        workstatus.Text = "已處理"
                    Case "3"    '已結案
                        workstatus.Text = "已結案"
                End Select

                myoperator.Text = CType(dt.Rows(0).Item("operator"), String)
                If Not IsDBNull(dt.Rows(0).Item("workdate")) Then
                    workDate.Text = CType(dt.Rows(0).Item("workdate"), String)
                End If
                lastOperator.Text = CType(dt.Rows(0).Item("lastoperator"), String)
                If Not IsDBNull(dt.Rows(0).Item("lastworkdate")) Then
                    lastWorkDate.Text = CType(dt.Rows(0).Item("lastworkdate"), String)
                End If
                endOperator.Text = CType(dt.Rows(0).Item("endoperator"), String)
                If Not IsDBNull(dt.Rows(0).Item("endworkdate")) Then
                    endWorkDate.Text = CType(dt.Rows(0).Item("endworkdate"), String)
                End If
                remark.Text = CType(dt.Rows(0).Item("remark"), String)

                'createGroup.Text = CType(dt.Rows(0).Item("WorkUnit"), String)
                'If CType(dt.Rows(0).Item("workstatus"), String).Trim = "0" Then
                'workstatus.Text = "未處理"
                'ElseIf CType(dt.Rows(0).Item("workstatus"), String).Trim = "1" Then
                'workstatus.Text = "已處理"
                'End If
                'workstatus.SelectedValue = CType(dt.Rows(0).Item("workstatus"), String).Trim
                'workDate.Text = CType(dt.Rows(0).Item("workdate1"), String)
                '顯示執行單位
                'If myoperator.Text.Trim <> "" Then
                '    Call GetUser(context.User.Identity.Name.Trim)
                'End If
                '顯示執行單位、處理人員名稱
                If myoperator.Text.Trim <> "" Then
                    Call GetUser(myoperator.Text.Trim, 1)
                End If
                If lastOperator.Text.Trim <> "" Then
                    Call GetUser(lastOperator.Text.Trim, 2)
                End If
                If endOperator.Text.Trim <> "" Then
                    Call GetUser(endOperator.Text.Trim, 3)
                End If

            End If


        End If
    End Sub
    '顯示執行單位、處理人員名稱
    Private Sub GetUser(ByVal user As String, ByVal num As Integer)
        Dim objUser As New UserInfoBO
        'Dim objDeptBO As New OrgBO
        Dim objvUserInfoBO As New vUserInfoBO
        Dim objDept As New DeptExtendOrgEntity
        Dim dt As New DataTable
        '顯示處理人員名稱
        dt = objUser.QueryUserInfo(user)
        If dt.Rows.Count > 0 Then
            objDept.DeptID = dt.Rows(0).Item("Dept")

            Select num
                Case 1
                    myoperator.Text = dt.Rows(0).Item("Cname")
                Case 2
                    lastOperator.Text = dt.Rows(0).Item("Cname")
                Case 3
                    endOperator.Text = dt.Rows(0).Item("Cname")
            End Select
            '顯示執行單位
            'dt = objDeptBO.QueryDept(objDept)
            dt = objvUserInfoBO.QueryUnit(user)
            If dt.Rows.Count > 0 Then
                '從"組織結構"讀取單位名稱
                'Select Case num
                '    Case 1
                '        createGroup.Text = dt.Rows(0).Item("objname")
                '    Case 2
                '        lastGroup.Text = dt.Rows(0).Item("objname")
                '    Case 3
                '        endGroup.Text = dt.Rows(0).Item("objname")
                'End Select

                '從"帳號管理"讀取單位名稱
                Select Case num
                    Case 1
                        createGroup.Text = dt.Rows(0).Item("GroupName")
                    Case 2
                        lastGroup.Text = dt.Rows(0).Item("GroupName")
                    Case 3
                        endGroup.Text = dt.Rows(0).Item("GroupName")
                End Select

            End If
        End If

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim objcnt As New Encontact
        Dim objcntBO As New ContactBO
        Dim newOperator As String

        If Me.remark.Text <> "" Then
            '設定要更新的資料
            newOperator = Context.User.Identity.Name

            If newOperator <> "" Then       '判斷登入ID sessiongg是否存在
                If remark.Text.Trim <> "" And myoperator.Text.Trim = "" Then
                    objcnt.myoperator = newOperator
                    'objcnt.workdate = Year(Now()).ToString & "/" & Month(Now()).ToString & "/" & Day(Now()).ToString & " " & Hour(Now()).ToString & ":" & Minute(Now()).ToString & ":" & Second(Now()).ToString
                    objcnt.workdate = Format(Now(), "yyyy/MM/dd hh:mm:ss")
                    objcnt.workstatus = "2"     '已處理
                ElseIf remark.Text.Trim <> "" And myoperator.Text.Trim <> "" Then
                    objcnt.lastoperator = newOperator
                    objcnt.lastworkdate = Format(Now(), "yyyy/MM/dd hh:mm:ss")
                    'objcnt.lastworkdate = Year(Now()).ToString & "/" & Month(Now()).ToString & "/" & Day(Now()).ToString & " " & Hour(Now()).ToString & ":" & Minute(Now()).ToString & ":" & Second(Now()).ToString
                End If
                'context.User.Identity.Name取得登入者ID
                'objcnt.operator = context.User.Identity.Name
                'objcnt.workdate = Year(Now()).ToString & "/" & Month(Now()).ToString & "/" & Day(Now()).ToString
                'objcnt.workdate = Now().ToString
                'objcnt.workstatus = workstatus.Text
                objcnt.cntno = cntno.Text.Trim
                objcnt.remark = remark.Text.Trim

                '更新資料
                objcntBO.Update(objcnt)

                txtresult.Text = "資料已更新!"
            Else
                Response.Redirect("../DesktopDefault.aspx")
            End If
        Else
            txtresult.Text = "尚未輸入回覆內容!"
        End If
    End Sub

    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("Contact_2.aspx")
    End Sub


    Private Sub print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print.Click
        Dim str As String = cntno.Text
        Dim myRandom As Integer = New Random(Now.Second).Next

        Response.Redirect(IFrameSrc & "&MyRandomArg=" & myRandom & "&myCntDateNo=" & str)
    End Sub
End Class

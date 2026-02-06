Public Class dividend
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnupdatecel As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents createGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Creater As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents year As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox13 As System.Web.UI.WebControls.TextBox

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網
        Dim it As New item
        Dim wk As New DividendBO
        Dim dt As New DataTable
        Dim urlnewno As String

        '---------------------------------------------
        '  If (Session("LoginID") Is Nothing) Then
        '  Response.Redirect("login.aspx")
        '  End If
        '---------------------------------------------
        urlnewno = Request("newno")

        objCartDT = CType(Session("Cart"), DataTable)

        If Not IsPostBack Then
            Call GetDept()
        End If
        If urlnewno Is Nothing Then
            Call showData()
            Call GetUser(context.User.Identity.Name.Trim)
        Else
            If Not IsPostBack Then
                dt = wk.Query(urlnewno)
                year.Text = CType(dt.Rows(0).Item("year"), String)
                Textbox1.Text = CType(dt.Rows(0).Item("mon01"), String)
                Textbox2.Text = CType(dt.Rows(0).Item("mon02"), String)
                Textbox3.Text = CType(dt.Rows(0).Item("mon03"), String)
                Textbox4.Text = CType(dt.Rows(0).Item("mon04"), String)
                Textbox5.Text = CType(dt.Rows(0).Item("mon05"), String)
                Textbox6.Text = CType(dt.Rows(0).Item("mon06"), String)
                Textbox7.Text = CType(dt.Rows(0).Item("mon07"), String)
                viewstate("Creater") = CType(dt.Rows(0).Item("creater"), String)
                Call GetUser(viewstate("Creater"))
            End If

        End If

    End Sub

    Private Function checkFields() As Boolean
        txtResult.Text = ""
        '檢查年度,民國年
        If CType(year.Text, String) = "" Then
            txtResult.Text = "年度資料不可空白!"
            Return False
        End If

        Return True

    End Function
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

    Private Sub GetDept()
        Dim objDO As New DeptDAO
        Dim dt As DataTable
        dt = objDO.GetDeptList.Tables(0)
        Dim i As Integer

        Dim objlistItem1 As New ListItem
        objlistItem1.Text = ""
        objlistItem1.Value = ""

        For i = 0 To dt.Rows.Count - 1
            Dim objlistItem As New ListItem
            objlistItem.Text = CType(dt.Rows(i).Item("DeptName"), String)
            objlistItem.Value = CType(dt.Rows(i).Item("DeptID"), String)
        Next i


    End Sub

    Sub dgCart_Edit(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = e.Item.ItemIndex

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Cancel(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        dgCart.EditItemIndex = -1

        dgCart.DataSource = objCartDT
        dgCart.DataBind()
    End Sub

    Sub dgCart_Update(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        Dim mon01 As TextBox
        Dim mon02 As TextBox
        Dim mon03 As TextBox
        Dim mon04 As TextBox
        Dim mon05 As TextBox
        Dim mon06 As TextBox
        Dim mon07 As TextBox
        Dim mon08 As TextBox
        Dim mon09 As TextBox
        Dim mon10 As TextBox
        Dim mon11 As TextBox
        Dim mon12 As TextBox
        Dim year As TextBox
        Dim newno As String
        Dim ac As New Endividend
        Dim sc As New DividendBO

        newno = dgCart.DataKeys(e.Item.ItemIndex).ToString()
        year = CType(e.Item.Cells(0).Controls(0), TextBox)
        mon01 = CType(e.Item.Cells(1).Controls(0), TextBox)
        mon02 = CType(e.Item.Cells(2).Controls(0), TextBox)
        mon03 = CType(e.Item.Cells(3).Controls(0), TextBox)
        mon04 = CType(e.Item.Cells(4).Controls(0), TextBox)
        mon05 = CType(e.Item.Cells(5).Controls(0), TextBox)
        mon06 = CType(e.Item.Cells(6).Controls(0), TextBox)
        mon07 = CType(e.Item.Cells(7).Controls(0), TextBox)
        mon08 = CType(e.Item.Cells(8).Controls(0), TextBox)
        mon09 = CType(e.Item.Cells(9).Controls(0), TextBox)
        mon10 = CType(e.Item.Cells(10).Controls(0), TextBox)
        mon11 = CType(e.Item.Cells(11).Controls(0), TextBox)
        mon12 = CType(e.Item.Cells(12).Controls(0), TextBox)

        For Each objDR In objCartDT.Rows
            If Trim(CType(objDR("newno"), String)) = newno.Trim Then
                ac.year = year.Text.Trim
                ac.mon01 = mon01.Text.Trim
                ac.mon02 = mon02.Text.Trim
                ac.mon03 = mon03.Text.Trim
                ac.mon04 = mon04.Text.Trim
                ac.mon05 = mon05.Text.Trim
                ac.mon06 = mon06.Text.Trim
                ac.mon07 = mon07.Text.Trim
                ac.newno = CType(newno, Integer)
                sc.Update(ac)
                Exit For
            End If
        Next
        dgCart.EditItemIndex = -1
        Call showData()
    End Sub

    Sub showData()
        Dim se As New DividendBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
    End Sub


    Sub dgCart_Delete(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        Dim sc As New DividendBO
        Dim userid As String
        userid = Trim(CType(dgCart.DataKeys(e.Item.ItemIndex), String))
        ' objCartDT.Rows(e.Item.ItemIndex).Delete()
        'Session("cart") = objCartDT
        'dgCart.DataSource = objCartDT
        sc.Delete(userid)
        txtResult.Text = "刪除成功!"
        Call showData()

    End Sub


    Private Sub NavigateToPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim PageInfo As String = CType(sender, Button).CommandName
        Select Case PageInfo
            Case "第一頁"
                dgCart.CurrentPageIndex = 0
            Case "上一頁"
                If (dgCart.CurrentPageIndex > 0) Then
                    dgCart.CurrentPageIndex -= 1
                End If
            Case "下一頁"
                If (dgCart.CurrentPageIndex < (dgCart.PageCount - 1)) Then
                    dgCart.CurrentPageIndex += 1
                End If
            Case "最後一頁"
                dgCart.CurrentPageIndex = (dgCart.PageCount - 1)
        End Select
        Call showData()
        'dgCart.DataSource = objCartDT
        'dgCart.DataBind()
    End Sub

    Private Sub ShowPageStatus(ByVal nRecords As Integer)
        Message.Text = _
        "共有<b><FONT color= #ff0000> " & nRecords & " </FONT></b>筆資料," & _
        "總共有<b><FONT color= #ff0000> " & dgCart.PageCount & " </FONT></b>頁" & "," & _
        "目前是第<b><FONT color= #ff0000> " & (dgCart.CurrentPageIndex + 1) & " </FONT></b>頁"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If checkFields() = False Then
            Exit Sub
        End If
        Dim cm As New DividendBO
        Dim cn As New Endividend
        Dim dtYY As DataTable

        cn.year = year.Text.Trim
        cn.mon01 = Textbox1.Text.Trim
        cn.mon02 = Textbox2.Text.Trim
        cn.mon03 = Textbox3.Text.Trim
        cn.mon04 = Textbox4.Text.Trim
        cn.mon05 = Textbox5.Text.Trim
        cn.mon06 = Textbox6.Text.Trim
        cn.mon07 = Textbox7.Text.Trim
        cn.creater = context.User.Identity.Name.Trim

        '查詢年份是否重覆
        dtYY = cm.YearQuery(cn.year)

        'isert 資料
        cm.Insert(cn)
        txtResult.Text = "新增成功!"

        '清空欄位
        year.Text = ""
        Textbox1.Text = ""
        Textbox2.Text = ""
        Textbox3.Text = ""
        Textbox4.Text = ""
        Textbox5.Text = ""
        Textbox6.Text = ""
        Textbox7.Text = ""

        Call showData()

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click

        If checkFields() = False Then
            Exit Sub
        End If
        Dim cn As New Endividend
        Dim sc As New DividendBO
        Dim test As String

        cn.newno = CType(Request("newno").ToString, Integer)
        cn.year = CType(Request("year").ToString, Integer)
        cn.mon01 = Request("Textbox1").ToString
        cn.mon02 = Request("Textbox2").ToString
        cn.mon03 = Request("Textbox3").ToString
        cn.mon04 = Request("Textbox4").ToString
        cn.mon05 = Request("Textbox5").ToString
        cn.mon06 = Request("Textbox6").ToString
        cn.mon07 = Request("Textbox7").ToString

        test = CType(sc.Update(cn), String)

        txtResult.Text = "修改成功!"

        Response.Redirect("dividend.aspx")
    End Sub

    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatecel.Click
        Response.Redirect("dividend.aspx")
    End Sub

    Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call showData()
    End Sub


End Class


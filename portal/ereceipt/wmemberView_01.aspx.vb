Public Class wmemberView_01
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents ORGFLAG As System.Web.UI.WebControls.Label
    Protected WithEvents wm_id As System.Web.UI.WebControls.Label
    Protected WithEvents wm_no As System.Web.UI.WebControls.Label
    Protected WithEvents cntcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_user_o_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_user_o_name_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents w_tel_h_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_upd_datetime As System.Web.UI.WebControls.Label
    Protected WithEvents lb_add_date As System.Web.UI.WebControls.Label
    Protected WithEvents lb_add_datetime As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_id As System.Web.UI.WebControls.Label
    Protected WithEvents lb_user_name As System.Web.UI.WebControls.Label
    Protected WithEvents OPENFLAG As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_tel_o As System.Web.UI.WebControls.Label
    Protected WithEvents lb_tel_o2 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_tel_h As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_mobile As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents lb_email As System.Web.UI.WebControls.Label
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnreturn As System.Web.UI.WebControls.Button

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
    Dim objorg As New Enwebmember
    Dim no As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------

        If Not IsPostBack Then
            Dim objwmrBO As New WebmemberBO
            Dim dt As DataTable
            Dim paperflag As String
            Dim org_flag As String

            no = Request.Params("wm_no").ToString
            'wm_no.Text = no
            dt = objwmrBO.Query(no)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0).Item("upd_datetime2")) Then
                    lb_upd_datetime.Text = "　"
                Else
                    'lb_upd_datetime.Text = Left(CType(dt.Rows(0).Item("upd_datetime"), String), 10)
                    lb_upd_datetime.Text = CType(dt.Rows(0).Item("add_datetime2"), String)
                End If
                If IsDBNull(dt.Rows(0).Item("upd_datetime2")) Then
                    lb_add_datetime.Text = "　"
                Else
                    'lb_add_datetime.Text = Left(CType(dt.Rows(0).Item("add_datetime"), String), 10)
                    lb_add_datetime.Text = CType(dt.Rows(0).Item("add_datetime2"), String)
                End If
                OPENFLAG.Text = CType(dt.Rows(0).Item("openflag"), String)
                ORGFLAG.Text = CType(dt.Rows(0).Item("orgflag"), String)
                lb_id.Text = CType(dt.Rows(0).Item("wm_id"), String)
                lb_user_name.Text = CType(dt.Rows(0).Item("wm_user_name"), String)
                'lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o")
                'lb_tel_o2.Text = dt.Rows(0).Item("wm_tel_o2")
                If Trim(dt.Rows(0).Item("wm_tel_o")) <> "" And Trim(dt.Rows(0).Item("wm_tel_o")) <> "-" Then
                    If Trim(dt.Rows(0).Item("wm_tel_o2")) <> "" And Trim(dt.Rows(0).Item("wm_tel_o2")) <> "-" Then
                        lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o") + "分機" + dt.Rows(0).Item("wm_tel_o2")
                    Else
                        lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o")
                    End If
                Else
                    lb_tel_o.Text = "　"
                End If
                If (dt.Rows(0).Item("wm_tel_h")) <> "" And Trim(dt.Rows(0).Item("wm_tel_h")) <> "-" Then
                    lb_tel_h.Text = dt.Rows(0).Item("wm_tel_h")
                Else
                    lb_tel_h.Text = "　"
                End If
                If (dt.Rows(0).Item("wm_mobile")) <> "" And Trim(dt.Rows(0).Item("wm_mobile")) <> "-" Then
                    lb_mobile.Text = dt.Rows(0).Item("wm_mobile")
                Else
                    lb_mobile.Text = "　"
                End If
                lb_email.Text = dt.Rows(0).Item("wm_email")
                'Dim a As String = Session("UserName")

                objCartDT = objwmrBO.house_Query2(no)

                dgCart.DataSource = objCartDT
                dgCart.DataBind()
                'ShowPageStatus(objCartDT.Rows.Count)

            End If

        End If
    End Sub

    Private Sub dgCart_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
        dgCart.CurrentPageIndex = e.NewPageIndex
        Call SearchPorcess()
    End Sub

    Private Sub SearchPorcess()
        'If applydateO.Checked = True Then
        '    If ApplySDATE.Text.Trim = "" And ApplyEDATE.Text.Trim = "" Then
        '        msgbox.Text = "請輸入查詢日期!"
        '        Exit Sub
        '    ElseIf ApplySDATE.Text.Trim <> "" And ApplyEDATE.Text.Trim = "" Then
        '        ApplyEDATE.Text = ApplySDATE.Text
        '    End If

        'End If
        Dim objwmrBO As New WebmemberBO
        Dim dt As DataTable
        Dim paperflag As String
        Dim org_flag As String

        no = Request.Params("wm_no").ToString
        'wm_no.Text = no
        dt = objwmrBO.Query(no)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0).Item("upd_datetime2")) Then
                lb_upd_datetime.Text = ""
            Else
                'lb_upd_datetime.Text = Left(CType(dt.Rows(0).Item("upd_datetime"), String), 10)
                lb_upd_datetime.Text = CType(dt.Rows(0).Item("add_datetime2"), String)
            End If
            If IsDBNull(dt.Rows(0).Item("upd_datetime2")) Then
                lb_add_datetime.Text = ""
            Else
                'lb_add_datetime.Text = Left(CType(dt.Rows(0).Item("add_datetime"), String), 10)
                lb_add_datetime.Text = CType(dt.Rows(0).Item("add_datetime2"), String)
            End If
            OPENFLAG.Text = CType(dt.Rows(0).Item("openflag"), String)
            ORGFLAG.Text = CType(dt.Rows(0).Item("orgflag"), String)
            lb_id.Text = CType(dt.Rows(0).Item("wm_id"), String)
            lb_user_name.Text = CType(dt.Rows(0).Item("wm_user_name"), String)
            'lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o")
            'lb_tel_o2.Text = dt.Rows(0).Item("wm_tel_o2")
            If Trim(dt.Rows(0).Item("wm_tel_o")) <> "" And Trim(dt.Rows(0).Item("wm_tel_o")) <> "-" Then
                If Trim(dt.Rows(0).Item("wm_tel_o2")) <> "" And Trim(dt.Rows(0).Item("wm_tel_o2")) <> "-" Then
                    lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o") + "分機" + dt.Rows(0).Item("wm_tel_o2")
                Else
                    lb_tel_o.Text = dt.Rows(0).Item("wm_tel_o")
                End If

            Else
                lb_tel_o.Text = " "
            End If
            If Trim(dt.Rows(0).Item("wm_tel_h")) <> "" And Trim(dt.Rows(0).Item("wm_tel_h")) <> "-" Then
                lb_tel_h.Text = dt.Rows(0).Item("wm_tel_h")
            Else
                lb_tel_h.Text = " "
            End If
            lb_mobile.Text = dt.Rows(0).Item("wm_mobile")
            lb_email.Text = dt.Rows(0).Item("wm_email")
            'Dim a As String = Session("UserName")

            objCartDT = objwmrBO.house_Query2(no)

            dgCart.DataSource = objCartDT
            dgCart.DataBind()
        End If

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objwmr As New Enwebmember
        Dim objwmrBO As New WebmemberBO
        Dim objhsy As New Enhistory
        Dim obj As New Enhistory
        Dim objhsyBO As New WebmemberBO
        Dim dt As DataTable
        Dim upduser As String
        Dim i As Integer
        Dim Count As Integer
        Dim houseno As String

        ''objwmr.useroname = wm_user_o_name.Text
        ''objwmr.username = wm_user_name.Text
        ''objwmr.telo = wm_tel_o.Text
        'no = Request.Params("wm_no").ToString

        'dt = objwmrBO.house_Query(wm_no.Text)

        ''If Me.mhismemo.Text <> "" Then
        'For i = 0 To dt.Rows.Count - 1
        '    If Not IsDBNull(dt.Rows(i).Item("mh_house_no")) Then
        '        'If i = (dt.Rows.Count - 1) Then
        '        '    houseno = houseno + CType(dt.Rows(i).Item("mh_house_no"), String)
        '        'Else
        '        '    houseno = houseno + CType(dt.Rows(i).Item("mh_house_no"), String) + ","
        '        'End If
        '        objhsy.houseno = CType(dt.Rows(i).Item("mh_house_no"), String)
        '    Else
        '        'houseno = ""
        '        objhsy.houseno = ""
        '    End If
        '    objhsy.no = dt.Rows(i).Item("wm_no")
        '    objhsy.password = CType(dt.Rows(i).Item("wm_password"), String)
        '    objhsy.id = CType(dt.Rows(i).Item("wm_id"), String)
        '    objhsy.orgflag = dt.Rows(i).Item("wm_org_flag")
        '    objhsy.openflag = dt.Rows(i).Item("wm_open_flag")
        '    If rb_paper_flag_1.Checked = True Then
        '        If wm_paper_flag_org.Text = "Y" Then
        '            objhsy.paperflag = "-"
        '        Else
        '            objhsy.paperflag = "Y"
        '        End If
        '    Else
        '        If wm_paper_flag_org.Text = "N" Then
        '            objhsy.paperflag = "-"
        '        Else
        '            objhsy.paperflag = "N"
        '        End If
        '    End If
        '    objhsy.username = wm_user_name.Text
        '    objhsy.useroname = wm_user_o_name.Text
        '    'If (String.Compare(wm_user_name.Text, wm_user_name_org.Text)) = 0 Then
        '    'If (String.Compare(wm_user_name.Text, wm_user_name_org.Text)) = 0 Then
        '    '    objhsy.username = "-"
        '    'Else
        '    '    objhsy.username = wm_user_name.Text
        '    'End If
        '    'If (String.Compare(wm_user_o_name.Text, wm_user_o_name_org.Text)) = 0 Then
        '    '    objhsy.useroname = "-"
        '    'Else
        '    '    objhsy.useroname = wm_user_o_name.Text
        '    'End If
        '    If (String.Compare(wm_tel_h.Text, wm_tel_h_org.Text)) = 0 Then
        '        objhsy.telh = "-"
        '    Else
        '        objhsy.telh = wm_tel_h.Text
        '    End If
        '    If (String.Compare(wm_tel_o.Text, wm_tel_o_org.Text)) = 0 Then
        '        objhsy.telo = "-"
        '    Else
        '        objhsy.telo = wm_tel_o.Text
        '    End If
        '    If (String.Compare(wm_tel_o2.Text, wm_tel_o2_org.Text)) = 0 Then
        '        objhsy.telo2 = "-"
        '    Else
        '        objhsy.telo2 = wm_tel_o2.Text
        '    End If
        '    If (String.Compare(wm_mobile.Text, wm_mobile_org.Text)) = 0 Then
        '        objhsy.mobile = "-"
        '    Else
        '        objhsy.mobile = wm_mobile.Text
        '    End If
        '    If (String.Compare(wm_email.Text, wm_email_org.Text)) = 0 Then
        '        objhsy.email = "-"
        '    Else
        '        objhsy.email = wm_email.Text
        '    End If

        '    objhsy.adduser = context.User.Identity.Name
        '    objhsy.updatetype = "2"
        '    objhsy.transtype = "0"

        '    'If Not IsDBNull(dt.Rows(i).Item("mh_house_no")) Then
        '    '    objhsy.houseno = dt.Rows(i).Item("mh_house_no")
        '    'Else
        '    '    objhsy.houseno = ""
        '    'End If
        '    If mhismemo.Text = "" Then
        '        objhsy.mhismemo = ""
        '    Else
        '        objhsy.mhismemo = mhismemo.Text
        '    End If

        '    objwmrBO.Insert_history(objhsy)
        'Next i

        ''objhsy.houseno = houseno

        '''If Not IsDBNull(houseno) Then
        '''    objhsy.houseno = Right(houseno, 1)
        '''End If
        '''If Not IsDBNull(houseno) Then
        '''    Count = 1
        '''    objhsy.houseno = houseno.Remove(houseno.Length, Count)
        '''End If

        ''objwmrBO.Insert_history(objhsy)

        'obj.no = no
        'obj.useroname = Request("wm_user_o_name").ToString
        'obj.username = Request("wm_user_name").ToString
        'obj.telo = Request("wm_tel_o").ToString
        'obj.telo2 = Request("wm_tel_o2").ToString
        'obj.telh = Request("wm_tel_h").ToString
        'obj.mobile = Request("wm_mobile").ToString
        'obj.email = Request("wm_email").ToString
        'If rb_paper_flag_1.Checked = True Then
        '    obj.paperflag = "Y"
        'Else
        '    obj.paperflag = "N"
        'End If

        'objwmrBO.Update_member(obj)
        'txtresult.Text = "資料已更新!"
        ''Else
        ''txtresult.Text = "尚未輸入處理說明!"
        ''End If


        ''If dt.Rows.Count > 0 Then
        ''    objhsy.no = dt.Rows(0).Item("wm_no")
        ''    objhsy.password = dt.Rows(0).Item("wm_password")
        ''    objhsy.id = CType(dt.Rows(0).Item("wm_id"), String)
        ''    objhsy.orgflag = dt.Rows(0).Item("wm_org_flag")
        ''    objhsy.openflag = dt.Rows(0).Item("wm_open_flag")
        ''    objhsy.username = wm_user_name.Text
        ''    objhsy.useroname = wm_user_o_name.Text
        ''    objhsy.telh = wm_tel_h.Text
        ''    objhsy.telo = wm_tel_o.Text
        ''    objhsy.telo2 = wm_tel_o2.Text
        ''    objhsy.adduser = context.User.Identity.Name

        ''    objwmrBO.Insert_history(objhsy)

        ''    'objhsy.upduser = context.User.Identity.Name

        ''End If

        ''objhsyBO.Insert_history(objhsy)

    End Sub

    Private Sub btnreturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn.Click
        Response.Redirect("wmember_01.aspx")
    End Sub

End Class

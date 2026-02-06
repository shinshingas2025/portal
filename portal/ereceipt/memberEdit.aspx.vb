Public Class memberEdit
    Inherits System.Web.UI.Page

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents OPENFLAG As System.Web.UI.WebControls.Label
    Protected WithEvents ORGFLAG As System.Web.UI.WebControls.Label
    Protected WithEvents wm_id As System.Web.UI.WebControls.Label
    Protected WithEvents rb_paper_flag_1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rb_paper_flag_2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents btnupdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnreturn As System.Web.UI.WebControls.Button
    Protected WithEvents wm_no As System.Web.UI.WebControls.Label
    Protected WithEvents cntcontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents mhismemo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtresult As System.Web.UI.WebControls.Label
    Protected WithEvents wm_user_o_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_user_o_name_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_user_name_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_o2_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_user_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_o_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_mobile_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_email_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents w_tel_h_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_mobile As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_email As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_paper_flag_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_h_org As System.Web.UI.WebControls.TextBox
    Protected WithEvents CustomValidator2 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents wm_tel_o1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_o3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_o2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_h1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents wm_tel_h3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator

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
            wm_no.Text = no
            dt = objwmrBO.Query(no)
            If dt.Rows.Count > 0 Then
                OPENFLAG.Text = CType(dt.Rows(0).Item("openflag"), String)
                ORGFLAG.Text = CType(dt.Rows(0).Item("orgflag"), String)
                wm_id.Text = CType(dt.Rows(0).Item("wm_id"), String)
                wm_user_o_name.Text = CType(dt.Rows(0).Item("wm_user_o_name"), String)
                wm_user_name.Text = CType(dt.Rows(0).Item("wm_user_name"), String)
                'If Not IsDBNull(dt.Rows(0).Item("wm_tel_o")) Then
                If Trim(dt.Rows(0).Item("wm_tel_o")) <> "" Then
                    Dim Data As String() = (CType(dt.Rows(0).Item("wm_tel_o"), String)).Split("-")
                    wm_tel_o1.Text = Data(0)
                    wm_tel_o3.Text = Data(1)
                    wm_tel_o2.Text = dt.Rows(0).Item("wm_tel_o2")
                Else
                    wm_tel_o1.Text = ""
                    wm_tel_o3.Text = ""
                    wm_tel_o2.Text = ""
                End If
                'If Not IsDBNull(dt.Rows(0).Item("wm_tel_h")) Then
                If Trim(dt.Rows(0).Item("wm_tel_h")) <> "" Then
                    Dim Data1 As String() = (CType(dt.Rows(0).Item("wm_tel_h"), String)).Split("-")
                    wm_tel_h1.Text = Data1(0)
                    wm_tel_h3.Text = Data1(1)
                Else
                    wm_tel_h1.Text = ""
                    wm_tel_h3.Text = ""
                End If
                wm_mobile.Text = dt.Rows(0).Item("wm_mobile")
                wm_email.Text = dt.Rows(0).Item("wm_email")
                paperflag = CType(dt.Rows(0).Item("wm_paper_flag"), String)
                org_flag = CType(dt.Rows(0).Item("wm_org_flag"), String)
                ''.SelectedValue = CType(dt.Rows(0).Item("workstatus"), String).Trim
                'wm_paper_flag = CType(dt.Rows(0).Item("wm_paper_flag"), String)
                '
                wm_user_o_name_org.Text = CType(dt.Rows(0).Item("wm_user_o_name"), String)
                wm_user_name_org.Text = CType(dt.Rows(0).Item("wm_user_name"), String)
                wm_tel_o_org.Text = CType(dt.Rows(0).Item("wm_tel_o"), String)
                wm_tel_o2_org.Text = CType(dt.Rows(0).Item("wm_tel_o2"), String)
                wm_tel_h_org.Text = CType(dt.Rows(0).Item("wm_tel_h"), String)
                wm_mobile_org.Text = CType(dt.Rows(0).Item("wm_mobile"), String)
                wm_email_org.Text = CType(dt.Rows(0).Item("wm_email"), String)
                wm_paper_flag_org.Text = CType(dt.Rows(0).Item("wm_paper_flag"), String)

                'objorg.telo = dt.Rows(0).Item("wm_tel_o")
                'objorg.telo2 = dt.Rows(0).Item("wm_tel_o2")
                'objorg.telh = dt.Rows(0).Item("wm_tel_h")
                'objorg.mobile = dt.Rows(0).Item("wm_mobile")
                'objorg.email = dt.Rows(0).Item("wm_email")
                'objorg.paperflag = CType(dt.Rows(0).Item("wm_paper_flag"), String)
                If org_flag = "1" Then
                    rb_paper_flag_1.Enabled = False
                    rb_paper_flag_2.Enabled = False
                End If
                If paperflag = "Y" Then
                    rb_paper_flag_1.Checked = True
                    rb_paper_flag_2.Checked = False
                Else
                    rb_paper_flag_1.Checked = False
                    rb_paper_flag_2.Checked = True
                End If
                mhismemo.Text = ""

            End If

        End If
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
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
        Dim systime As Date
        Dim systime1 As String

        'systime = Now()
        'systime1 = systime.ToString("yyyy/MM/dd HH:mm:ss")

        'objwmr.useroname = wm_user_o_name.Text
        'objwmr.username = wm_user_name.Text
        'objwmr.telo = wm_tel_o.Text
        If CheckDataAll() <> 0 Then
            no = Request.Params("wm_no").ToString

            dt = objwmrBO.house_Query(wm_no.Text)
            systime = Now()
            systime1 = systime.ToString("yyyy/MM/dd HH:mm:ss")

            'If Me.mhismemo.Text <> "" Then
            For i = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(i).Item("mh_house_no")) Then
                    'If i = (dt.Rows.Count - 1) Then
                    '    houseno = houseno + CType(dt.Rows(i).Item("mh_house_no"), String)
                    'Else
                    '    houseno = houseno + CType(dt.Rows(i).Item("mh_house_no"), String) + ","
                    'End If
                    objhsy.houseno = CType(dt.Rows(i).Item("mh_house_no"), String)
                Else
                    'houseno = ""
                    objhsy.houseno = ""
                End If
                objhsy.no = dt.Rows(i).Item("wm_no")
                'objhsy.password = CType(dt.Rows(i).Item("wm_password"), String)
                objhsy.password = "-"
                objhsy.id = CType(dt.Rows(i).Item("wm_id"), String)
                objhsy.orgflag = dt.Rows(i).Item("wm_org_flag")
                'objhsy.openflag = dt.Rows(i).Item("wm_open_flag")
                objhsy.openflag = "-"
                If rb_paper_flag_1.Checked = True Then
                    If wm_paper_flag_org.Text = "Y" Then
                        objhsy.paperflag = "-"
                    Else
                        objhsy.paperflag = "Y"
                    End If
                Else
                    If wm_paper_flag_org.Text = "N" Then
                        objhsy.paperflag = "-"
                    Else
                        objhsy.paperflag = "N"
                    End If
                End If
                'objhsy.username = wm_user_name.Text
                'objhsy.useroname = wm_user_o_name.Text
                'If (String.Compare(wm_user_name.Text, wm_user_name_org.Text)) = 0 Then
                wm_user_name_org.Text = CType(dt.Rows(i).Item("wm_user_name"), String)
                If (String.Compare(wm_user_name.Text, wm_user_name_org.Text)) = 0 Then
                    objhsy.username = "-"
                Else
                    objhsy.username = wm_user_name.Text
                End If
                wm_user_o_name_org.Text = CType(dt.Rows(i).Item("wm_user_o_name"), String)
                If (String.Compare(wm_user_o_name.Text, wm_user_o_name_org.Text)) = 0 Then
                    objhsy.useroname = "-"
                Else
                    objhsy.useroname = wm_user_o_name.Text
                End If
                Dim tel_h, tel_o As String
                tel_h = wm_tel_h1.Text.Trim() + "-" + wm_tel_h3.Text.Trim()
                wm_tel_h_org.Text = CType(dt.Rows(i).Item("wm_tel_h"), String)
                If (String.Compare(tel_h, Trim(wm_tel_h_org.Text))) = 0 Then
                    objhsy.telh = "-"
                Else
                    objhsy.telh = tel_h
                End If
                tel_o = wm_tel_o1.Text.Trim() + "-" + wm_tel_o3.Text.Trim()
                wm_tel_o_org.Text = CType(dt.Rows(i).Item("wm_tel_o"), String)
                If (String.Compare(tel_o, Trim(wm_tel_o_org.Text))) = 0 Then
                    objhsy.telo = "-"
                Else
                    objhsy.telo = tel_o
                End If
                wm_tel_o2_org.Text = CType(dt.Rows(i).Item("wm_tel_o2"), String)
                If (String.Compare(wm_tel_o2.Text, wm_tel_o2_org.Text)) = 0 Then
                    objhsy.telo2 = "-"
                Else
                    objhsy.telo2 = wm_tel_o2.Text
                End If
                wm_mobile_org.Text = CType(dt.Rows(i).Item("wm_mobile"), String)
                If (String.Compare(wm_mobile.Text, wm_mobile_org.Text)) = 0 Then
                    objhsy.mobile = "-"
                Else
                    objhsy.mobile = wm_mobile.Text
                End If
                wm_email_org.Text = CType(dt.Rows(i).Item("wm_email"), String)
                If (String.Compare(wm_email.Text, wm_email_org.Text)) = 0 Then
                    objhsy.email = "-"
                Else
                    objhsy.email = wm_email.Text
                End If
                'objhsy.openflag = CType(dt.Rows(i).Item("wm_open_flag"), String)
                'objhsy.adduser = context.User.Identity.Name
                objhsy.adduser = Session("UserName")
                objhsy.updatetype = "2"
                objhsy.transtype = "0"

                'If Not IsDBNull(dt.Rows(i).Item("mh_house_no")) Then
                '    objhsy.houseno = dt.Rows(i).Item("mh_house_no")
                'Else
                '    objhsy.houseno = ""
                'End If
                If mhismemo.Text = "" Then
                    objhsy.mhismemo = ""
                Else
                    objhsy.mhismemo = mhismemo.Text
                End If
                objhsy.adddate1 = systime1

                objwmrBO.Insert_history(objhsy)
            Next i

            '新增用戶house_list歷史檔
            objwmrBO.webmember_history_house(objhsy)

            'objhsy.houseno = houseno

            ''If Not IsDBNull(houseno) Then
            ''    objhsy.houseno = Right(houseno, 1)
            ''End If
            ''If Not IsDBNull(houseno) Then
            ''    Count = 1
            ''    objhsy.houseno = houseno.Remove(houseno.Length, Count)
            ''End If

            'objwmrBO.Insert_history(objhsy)
            Dim telo As String
            Dim telh As String
            telo = wm_tel_o1.Text.Trim() + "-" + wm_tel_o3.Text.Trim()
            telh = wm_tel_h1.Text.Trim() + "-" + wm_tel_h3.Text.Trim()

            obj.no = no
            obj.id = wm_id.Text
            obj.useroname = Request("wm_user_o_name").ToString
            obj.username = Request("wm_user_name").ToString
            obj.telo = telo
            obj.telo2 = Request("wm_tel_o2").ToString
            obj.telh = telh
            obj.mobile = Request("wm_mobile").ToString
            obj.email = Request("wm_email").ToString
            If rb_paper_flag_1.Checked = True Then
                obj.paperflag = "Y"
            Else
                obj.paperflag = "N"
            End If
            obj.adddate1 = systime1
            'obj.adduser = context.User.Identity.Name
            obj.adduser = Session("username")

            objwmrBO.Update_member(obj)
            txtresult.Text = "資料已更新!"

        End If

        'Else
        'txtresult.Text = "尚未輸入處理說明!"
        'End If


        'If dt.Rows.Count > 0 Then
        '    objhsy.no = dt.Rows(0).Item("wm_no")
        '    objhsy.password = dt.Rows(0).Item("wm_password")
        '    objhsy.id = CType(dt.Rows(0).Item("wm_id"), String)
        '    objhsy.orgflag = dt.Rows(0).Item("wm_org_flag")
        '    objhsy.openflag = dt.Rows(0).Item("wm_open_flag")
        '    objhsy.username = wm_user_name.Text
        '    objhsy.useroname = wm_user_o_name.Text
        '    objhsy.telh = wm_tel_h.Text
        '    objhsy.telo = wm_tel_o.Text
        '    objhsy.telo2 = wm_tel_o2.Text
        '    objhsy.adduser = context.User.Identity.Name

        '    objwmrBO.Insert_history(objhsy)

        '    'objhsy.upduser = context.User.Identity.Name

        'End If

        'objhsyBO.Insert_history(objhsy)

    End Sub

    Private Sub btnreturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn.Click
        Response.Redirect("Webmember_01.aspx")
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim objwmrBO As New WebmemberBO
        Dim email As String
        Dim dt As DataTable

        email = Trim(wm_email.Text)

        If email <> "" Then
            dt = objwmrBO.mail(email)

            If dt.Rows.Count > 0 Then
                Label1.Text = "電子信箱已重覆！"
            Else
                Label1.Text = "電子信箱無重覆！"
            End If

        End If
    End Sub

#Region "CheckDataAll　檢查輸入的值是否符合要求"
    Function CheckDataAll() As Integer
        Dim ReMsg As Integer = 0

        If ((Left(wm_tel_o3.Text, 1) = "1") Or (Left(wm_tel_o3.Text, 1) = "0")) And Trim(wm_tel_o3.Text) <> "" Then
            txtresult.Text = "聯絡電話(Ｏ)第一碼錯誤"
            Return ReMsg
        End If

        'If (Left(wm_tel_h.Text, 1) = "0" Or Left(wm_tel_h.Text, 1) = "1") And Trim(wm_tel_h.Text) <> "" Then
        If ((Left(wm_tel_h3.Text, 1) = "1") Or (Left(wm_tel_o3.Text, 1) = "0")) And Trim(wm_tel_h3.Text) <> "" Then
            txtresult.Text = "聯絡電話(Ｈ)第一碼錯誤"
            Return ReMsg
        End If

        If Len(wm_mobile.Text) <> 10 And Trim(wm_mobile.Text) <> "" Then
            txtresult.Text = "手機號碼長度不對"
            Return ReMsg
        End If

        If (Trim(wm_mobile.Text) <> "" And Left(wm_mobile.Text, 2) <> "09") Then
            txtresult.Text = "行動電話第一碼錯誤"
            Return ReMsg
        End If

        If (Trim(wm_email.Text) = "") Then
            txtresult.Text = "電子信箱不得為空白"
            Return ReMsg
        End If

        '1140115 增加判斷如電子郵件有修正，需要按『檢核信箱』

        If (Trim(wm_email.Text) <> Trim(wm_email_org.Text) And Trim(Label1.Text) = "") Then
            txtresult.Text = "電子郵件有修改，請按『檢核信箱』"
            Return ReMsg
        End If
        If Trim(wm_mobile.Text) = "" And Trim(wm_tel_h3.Text) = "" And Trim(wm_tel_o3.Text) = "" Then
            txtresult.Text = "行動電話和連絡電話最少要填一項"
            Return ReMsg
        Else
            ReMsg = 1
        End If

        Return ReMsg
    End Function
#End Region

   
End Class

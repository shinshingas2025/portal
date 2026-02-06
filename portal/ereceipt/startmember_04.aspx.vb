Imports System.Web.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class startmember_04
    Inherits System.Web.UI.Page
    Private thread_status As Boolean = False
    Private ErrCodeHT As Hashtable = New Hashtable
    Private RightCodeHT As Hashtable = New Hashtable
    Private stream As NetworkStream
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator2 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents mhismemo As System.Web.UI.WebControls.TextBox
    Private tcpClient As TcpClient

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgCart As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents txtResult As System.Web.UI.WebControls.Label
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
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
    Dim no As String
    Dim openflag As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------

        Dim it As New item
        Dim wk As New WebmemberBO
        Dim dt As New DataTable
        Dim urlwmno As String

        Dim objwmr As New Enwebmember
        Dim objwmrBO As New WebmemberBO
        Dim paperflag As String

        If Not IsPostBack Then
            'label1.Text = "啟動"
            'Label2.Text = ""

            no = Request.Params("wm_no").ToString
            dt = objwmrBO.Query(no)

            If dt.Rows.Count > 0 Then
                openflag = dt.Rows(0).Item("wm_open_flag")
                label1.Text = "停權"
            End If

            dgCart.DataSource = dt
            dgCart.DataBind()
            'ShowPageStatus(dt.Rows.Count)
        End If

        'Call showData()
        'If Not IsPostBack Then
        'Call showData()
        'Else       
        'If Not IsPostBack Then
        '    Call GetDept()
        'End If
        'If urlnewno Is Nothing Then
        '    Call showData()
        '    Call GetUser(context.User.Identity.Name.Trim)
        'Else
        '    If Not IsPostBack Then
        '        dt = wk.Query(urlnewno)
        '        txtsubject.Text = CType(dt.Rows(0).Item("new_subject"), String)
        '        txtcontent.Text = Replace(CType(dt.Rows(0).Item("new_content"), String), "<BR>", Chr(13))
        '        SDATE.Text = CType(Year(CType(dt.Rows(0).Item("sdate"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("sdate"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("sdate"), Date)), String), 2)
        '        EDATE.Text = CType(Year(CType(dt.Rows(0).Item("EDATE"), Date)), String) & "/" & Right("0" & CType(Month(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2) & "/" & Right("0" & CType(Day(CType(dt.Rows(0).Item("EDATE"), Date)), String), 2)
        '        viewstate("Creater") = CType(dt.Rows(0).Item("creater"), String)
        '        provider.SelectedValue = CType(dt.Rows(0).Item("provider"), String).Trim
        '        Call GetUser(viewstate("Creater"))
        '    End If

        'End If

        'End If



    End Sub

    Sub showData()
        Dim se As New HotnewsBO
        objCartDT = se.Query
        Session("cart") = objCartDT
        dgCart.DataSource = objCartDT
        dgCart.DataBind()
        ShowPageStatus(objCartDT.Rows.Count)
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

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    If checkFields() = False Then
    '        Exit Sub
    '    End If
    '    Dim cm As New HotnewsBO
    '    Dim cn As New Enhotnews
    '    cn.newsubject = txtsubject.Text.Trim
    '    cn.newcontent = txtcontent.Text.Trim

    '    'cn.newlink = txtlink.Text.Trim
    '    cn.creater = context.User.Identity.Name.Trim
    '    cn.SDATE = CType(SDATE.Text.Trim, Date)
    '    cn.EDATE = CType(SDATE.Text.Trim, Date)
    '    cn.Provider = provider.SelectedValue
    '    cm.Insert(cn)

    '    txtResult.Text = "新增成功!"
    '    txtsubject.Text = ""
    '    txtcontent.Text = ""
    '    Call showData()

    'End Sub

    'Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click

    '    If checkFields() = False Then
    '        Exit Sub
    '    End If
    '    Dim cn As New Enhotnews
    '    Dim sc As New HotnewsBO
    '    Dim test As String

    '    cn.newno = CType(Request("newno").ToString, Integer)
    '    cn.newsubject = Request("txtsubject").ToString
    '    cn.newcontent = Request("txtcontent").ToString

    '    cn.SDATE = Request("SDATE").ToString
    '    cn.EDATE = Request("EDATE").ToString
    '    cn.Provider = Request("provider").ToString

    '    test = CType(sc.Update(cn), String)

    '    txtResult.Text = "修改成功!"

    '    Response.Redirect("hotnews.aspx")
    'End Sub

    Private Sub btnupdatecel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("hotnews.aspx")
    End Sub

    'Private Sub dgCart_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCart.PageIndexChanged
    '    dgCart.CurrentPageIndex = e.NewPageIndex
    '    Call showData()
    'End Sub


    Private Sub btnreturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn.Click
        Response.Redirect("Webmember_01.aspx")
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objDao As New RECENTDAO
        Dim se As New WebmemberBO
        Dim sWmOpenCode As String
        Dim MailMessage As New System.Web.Mail.MailMessage
        Dim Body As String
        Dim i As Integer
        Dim dt As New DataTable
        Dim houseno As String
        Dim systime As Date
        Dim systime1 As String

        Dim objwmr As New Enwebmember
        Dim objhsy As New Enhistory
        Dim obj As New Enhistory
        Dim email As Label
        Dim name As Label
        Dim wmno As Label
        Dim objDataGridItem As DataGridItem

        txtResult.Text = ""

        'If Me.mhismemo.Text <> "" Then
        no = Request.Params("wm_no").ToString
        SMTPCodeAdd()

        For Each objDataGridItem In dgCart.Items
            email = objDataGridItem.FindControl("email")
            wmno = objDataGridItem.FindControl("no")

            Try
                'sWmOpenCode = objDao.GetWmOpenCode1(email.Text).ToString
                sWmOpenCode = objDao.GetWmOpenCode2(Trim(wmno.Text)).ToString
                If sWmOpenCode.Length > 0 Then
                    Dim DataA(1) As String '= Split(sWmOpenCode, " ")
                    'DataA(0) = Trim(Right(sWmOpenCode, 12))
                    'DataA(1) = Trim(Left(sWmOpenCode, Len(sWmOpenCode) - 15))
                    'SMTPCodeAdd()
                    DataA(0) = Trim(sWmOpenCode)
                    MailMessage.BodyFormat = MailFormat.Html
                    MailMessage.From = "contactus@shinshingas.com.tw"
                    MailMessage.To = email.Text
                    MailMessage.Subject = "欣欣天然氣電子繳費憑證會員資格停權通知"
                    Body = "親愛的客戶" & DataA(0) & "，您好！<br/><br/><br/>"
                    Body = Body & "您的資料異常，因此會員資格被停權；<br/>"
                    Body = Body & "如有需要，請點選<a  href=""mailto:contactus@shinshingas.com.tw" & """><font color=red size=3>『聯絡我們』</font></a>或電洽本公司營業部營收科。<br/><br/><br/>"
                    Body = Body & "謝謝！<br/>"
                    Body = Body & "欣欣天然氣股份有限公司<br/>"

                    MailMessage.Body = Body

                    'If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", MailMessage) = True Then       '"smtp.rpti3.com.tw"
                    If SendEmail("mail.shinshingas.com.tw", 25, True, "contactus", "22325804", MailMessage) = True Then       '"smtp.rpti3.com.tw"
                        Message.Text = "停權通知己寄至您所申請的郵件信箱!"
                        'Response.Redirect("recent_sucess.aspx")
                    Else
                        Message.Text = Err.Number.ToString & " " & Err.Description.ToString & "<br>由於預設的email信箱錯誤, 因此信件無法寄出, 請重新申請!"
                    End If

                Else
                    Message.Text = "請再次確認您輸入的資料!"
                End If
            Catch ex As Exception
                Message.Text = "失敗" & ex.StackTrace
            End Try

            If Message.Text = "停權通知己寄至您所申請的郵件信箱!" Then
                'no = Request.Params("no").ToString
                'dt = se.house_Query(no)
                dt = se.house_Query(Trim(wmno.Text))
                systime = Now()
                systime1 = systime.ToString("yyyy/MM/dd HH:mm:ss")

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
                    objhsy.password = dt.Rows(i).Item("wm_password")
                    'objhsy.username = dt.Rows(i).Item("wm_user_name")
                    'objhsy.useroname = dt.Rows(i).Item("wm_user_o_name")
                    objhsy.username = "-"
                    objhsy.useroname = "-"
                    objhsy.telh = "-"
                    objhsy.telo = "-"
                    objhsy.telo2 = "-"
                    objhsy.mobile = "-"
                    objhsy.email = "-"
                    objhsy.id = dt.Rows(i).Item("wm_id")
                    objhsy.orgflag = dt.Rows(i).Item("wm_org_flag")
                    objhsy.paperflag = "-"
                    objhsy.openflag = "3"
                    'objhsy.adduser = context.User.Identity.Name
                    objhsy.adduser = Session("UserName")
                    objhsy.updatetype = "3"
                    objhsy.transtype = "0"
                    If mhismemo.Text = "" Then
                        objhsy.mhismemo = ""
                    Else
                        objhsy.mhismemo = mhismemo.Text
                    End If
                    objhsy.adddate1 = systime1

                    se.Insert_history(objhsy)
                Next
                '新增歷史檔
                'objhsy.houseno = houseno
                'se.Insert_history(objhsy)

                '刪除用戶號碼
                se.Delete_member(no)

                '更新會員主檔
                obj.no = no
                obj.openflag = "3"
                obj.adddate1 = systime1

                se.Update(obj)
                txtResult.Text = "資料已更新!"
            End If
        Next
        'Else
        'txtResult.Text = "尚未輸入處理說明!"
        'End If

    End Sub

#Region "目前不用"
#If 1 Then
#Region "SendEmail　真正透過Socket送出信件內容"
    Private Function SendEmail(ByVal smtpServer As String, ByVal port As Integer, ByVal ESmtp As Boolean, ByVal username As String, ByVal password As String, ByVal mailMessage As MailMessage) As Boolean
        Dim priority As String
        Dim Html As Boolean
        Dim SendBuffer1() As String = New String(3) {}
        Dim SendBuffer2() As String = New String(0) {}
        Dim SendBufferstr As String
        Dim encData_byte_1() As Byte = New Byte(username.Length) {}
        Dim encData_byte_2() As Byte = New Byte(password.Length) {}
        Dim encData_byte_3() As Byte = New Byte("郵件內容為HTML格，請選擇HTML方式查看".Length) {}
        Dim encData_byte_4() As Byte = New Byte(mailMessage.Body.Length) {}
        Dim i As Integer
        Dim filepath As String

        '測試連接服務器是否成功
        If connect(smtpServer, port) = False Then
            Return False
        End If
        priority = GetPriorityString(mailMessage.Priority)
        If mailMessage.BodyFormat = MailFormat.Html Then
            Html = True
        Else
            Html = False
        End If

        '進行SMTP驗證，現在大部分SMTP服務器都要認證
        If ESmtp = True Then
            SendBuffer1(0) = "EHLO " & smtpServer & vbCrLf
            SendBuffer1(1) = "AUTH LOGIN" & vbCrLf
            'SendBuffer1(2) = username & vbCrLf
            'SendBuffer1(3) = password & vbCrLf
            encData_byte_1 = System.Text.Encoding.Default.GetBytes(username)
            SendBuffer1(2) = Convert.ToBase64String(encData_byte_1) & vbCrLf
            encData_byte_2 = System.Text.Encoding.Default.GetBytes(password)
            SendBuffer1(3) = Convert.ToBase64String(encData_byte_2) & vbCrLf

            If Dialog(SendBuffer1, "SMTP服務器驗證失敗，請核對用戶名和密碼。") = False Then
                SendBuffer1 = Nothing
                Return False
            End If
        Else
            '不需要身份認證
            SendBufferstr = "HELO" & smtpServer & vbCrLf
            If Dialog(SendBufferstr, "") = False Then
                Return False
            End If
        End If

        '發件人地址
        SendBufferstr = "MAIL FROM:<" & mailMessage.From & ">" & vbCrLf
        If Dialog(SendBufferstr, "發件人地址錯誤，或不能為空") = False Then
            Return False
        End If

        SendBuffer2(0) = "RCPT TO:<" & mailMessage.To & ">" & vbCrLf
        If Dialog(SendBuffer2, "收件人地址有誤") = False Then
            Return False
        End If

        SendBufferstr = "DATA" & vbCrLf
        If Dialog(SendBufferstr, "") = False Then
            Return False
        End If

        If mailMessage.Subject = String.Empty Or mailMessage.Subject Is Nothing Then
            SendBufferstr = "Subject:"
        Else
            SendBufferstr = "Subject:" & mailMessage.Subject & vbCrLf
        End If

        SendBufferstr &= "X-Priority:" & priority & vbCrLf
        SendBufferstr &= "X-MSMail-Priority:" & priority & vbCrLf
        SendBufferstr &= "Importance:" & priority & vbCrLf
        SendBufferstr &= "X-Mailer:Lion. Web. Mail. SmtpMail Pubclass [cn]" & vbCrLf
        SendBufferstr &= "MIME-Version: 1.0" & vbCrLf
        If mailMessage.Attachments.Count <> 0 Then
            SendBufferstr &= "Content-Type: multipart/mixed;" & vbCrLf
            If Html = True Then
                SendBufferstr &= " boundary=""=====001_Dragon520636771063_=====""" & vbCrLf & vbCrLf
            Else
                SendBufferstr &= " boundary=""=====001_Dragon303406132050_=====""" & vbCrLf & vbCrLf
            End If
        End If

        If Html = True Then
            If mailMessage.Attachments.Count = 0 Then
                SendBufferstr &= "Content-Type: multipart/alternative;" & vbCrLf
                SendBufferstr &= " boundary=""=====003_Dragon520636771063_=====""" & vbCrLf & vbCrLf
                SendBufferstr &= "This is a multi-part message in MIME format." & vbCrLf & vbCrLf
            Else
                SendBufferstr &= "This is a multi-part message in MIME format." & vbCrLf & vbCrLf
                SendBufferstr &= "--=====001_Dragon520636771063_=====" & vbCrLf
                SendBufferstr &= "Content-Type: multipart/alternative;" & vbCrLf
                SendBufferstr &= " boundary=""=====003_Dragon520636771063_=====""" & vbCrLf & vbCrLf
            End If
            SendBufferstr &= "--=====003_Dragon520636771063_=====" & vbCrLf
            SendBufferstr &= "Content-Type: text/plain;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= " Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_3 = System.Text.Encoding.Default.GetBytes("郵件內容為HTML格式，請選擇HTML方式查看")
            SendBufferstr &= Convert.ToBase64String(encData_byte_3) & vbCrLf & vbCrLf
            SendBufferstr &= "--=====003_Dragon520636771063_=====" & vbCrLf
            SendBufferstr &= "Content-Type: text/html;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_4 = System.Text.Encoding.Default.GetBytes(mailMessage.Body)
            SendBufferstr &= Convert.ToBase64String(encData_byte_4) & vbCrLf
            SendBufferstr &= "--=====003_Dragon520636771063_=====--" & vbCrLf
        Else
            If mailMessage.Attachments.Count <> 0 Then
                SendBufferstr &= "--=====001_Dragon303406132050_=====" & vbCrLf
            End If
            SendBufferstr &= "Content-Type: text/plain;" & vbCrLf
            SendBufferstr &= " charset=""BIG5""" & vbCrLf
            SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf & vbCrLf
            encData_byte_4 = System.Text.Encoding.Default.GetBytes(mailMessage.Body)
            SendBufferstr &= Convert.ToBase64String(encData_byte_4) & vbCrLf
        End If
#If 0 Then
        If mailMessage.Attachments.Count <> 0 Then
            For i = 0 To mailMessage.Attachments.Count - 1
                filepath = mailMessage.Attachments(i)
                If Html = True Then
                    SendBufferstr &= "--=====001_Dragon520636771063_=====" & vbCrLf
                Else
                    SendBufferstr &= "--=====001_Dragon303406132050_=====" & vbCrLf
                End If
                SendBufferstr &= "Content-Type: text/plain" & vbCrLf
                SendBufferstr &= " name=""=?" & "GB2312" & "?B?"
                encData_byte_5 = System.Text.Encoding.Default.GetBytes(filepath.Substring(filepath.LastIndexOf("\\") + 1))
                SendBufferstr &= Convert.ToBase64String(encData_byte_5) & "?=""" & vbCrLf
                SendBufferstr &= "Content-Transfer-Encoding: base64" & vbCrLf
                SendBufferstr &= "Content-Disposition: attachment;" & vbCrLf
                SendBufferstr &= " filename=""=?GB2312?B?" & Convert.ToBase64String(encData_byte_5) & "?=""" & vbCrLf & vbCrLf
                SendBufferstr &= GetStream(filepath) & vbCrLf & vbCrLf
            Next

            If Html = True Then
                SendBufferstr &= "--=====001_Dragon520636771063_=====--" & vbCrLf & vbCrLf
            Else
                SendBufferstr &= "--=====001_Dragon303406132050_=====--" & vbCrLf & vbCrLf
            End If
        End If
#End If
        SendBufferstr &= vbCrLf & "." & vbCrLf
        If Dialog(SendBufferstr, "錯誤信件信息") = False Then
            Return False
        End If

        SendBufferstr &= "QUIT" & vbCrLf
        If Dialog(SendBufferstr, "斷開連接時錯誤") = False Then
            Return False
        End If

        stream.Close()
        tcpClient.Close()
        Return True

    End Function
#End Region

#Region "GetStream　讀取檔案資料"
    Private Function GetStream(ByVal FilePath As String) As String
        Dim FileStr As FileStream
        FileStr = New FileStream(FilePath, FileMode.Open)

        Dim by() As Byte = New Byte(System.Convert.ToInt32(FileStr.Length)) {}
        FileStr.Read(by, 0, by.Length)
        FileStr.Close()
        Return (System.Convert.ToBase64String(by))
    End Function
#End Region

#Region "connect　連接TCPIP"
    Private Function connect(ByVal smtpServer As String, ByVal port As Integer) As Boolean
        Dim s As String
        Dim ipAddr As System.Net.IPAddress
        '創建Tcp連接
        Try
            tcpClient = New tcpClient
            tcpClient.Connect(smtpServer, port)
        Catch ex As Exception
            s = ex.Message
            Return False
        End Try

        stream = tcpClient.GetStream()
        If RightCodeHT(RecvResponse().Substring(0, 3)) Is Nothing Then
            Return False
        End If
        Return True

    End Function
#End Region

#Region "SendCommand　發送SMTP命令"
    '發送SMTP命令
    Private Function SendCommand(ByVal str As String) As Boolean
        Dim WriteBuffer() As Byte = New Byte(str.Length) {}

        If str.Trim = String.Empty Or str Is Nothing Then
            Return True
        End If
        WriteBuffer = System.Text.Encoding.Default.GetBytes(str)

        Try
            stream.Write(WriteBuffer, 0, WriteBuffer.Length)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "RecvResponse　接收SMTP服務器回應"
    '接收SMTP服務器回應
    Private Function RecvResponse() As String
        Dim StreamSize As Integer
        Dim Returnvalue As String = String.Empty
        Dim ReadBuffer() As Byte = New Byte(9216) {}

        Try
            StreamSize = stream.Read(ReadBuffer, 0, ReadBuffer.Length)
        Catch ex As Exception
            Return "false"
        End Try

        If StreamSize = 0 Then
            Return Returnvalue
        Else
            Returnvalue = System.Text.Encoding.Default.GetString(ReadBuffer).Substring(0, StreamSize)
            Return Returnvalue
        End If
    End Function
#End Region

#Region "SMTPCodeAdd　回應代碼訊息表"
    'SMTP回應代碼哈希表
    Private Sub SMTPCodeAdd()
        ErrCodeHT.Add("421", "服務未就緒，關閉傳輸信道")
        ErrCodeHT.Add("432", "需要一個密碼轉換")
        ErrCodeHT.Add("450", "要求的郵件操作未完成，郵箱不可用(例如，郵箱忙)")
        ErrCodeHT.Add("451", "放棄要求的操作；處理過程中出錯")
        ErrCodeHT.Add("452", "系統存儲不足，要求的操作未執行")
        ErrCodeHT.Add("454", "臨時認證失敗")
        ErrCodeHT.Add("500", "郵箱地址錯誤")
        ErrCodeHT.Add("501", "參數格式錯誤")
        ErrCodeHT.Add("502", "命令不可實現")
        ErrCodeHT.Add("503", "服務器需要SMTP驗證")
        ErrCodeHT.Add("504", "命令參數不可實現")
        ErrCodeHT.Add("530", "需要認證")
        ErrCodeHT.Add("534", "認證機制過於簡單")
        ErrCodeHT.Add("538", "當前請求的認證機制需要加密")
        ErrCodeHT.Add("550", "要求的郵件操作未完成，郵箱不可用(例如，郵箱未找到，或不可訪問)")
        ErrCodeHT.Add("551", "用戶非本地，請嘗試<forward-path>")
        ErrCodeHT.Add("552", "過量的存儲分配，要求的操作未執行")
        ErrCodeHT.Add("553", "郵箱名不可用，要求的操作未執行(例如郵箱格式錯誤)")
        ErrCodeHT.Add("554", "傳輸失敗")

        RightCodeHT.Add("220", "服務就緒")
        RightCodeHT.Add("221", "服務關閉傳輸信道")
        RightCodeHT.Add("235", "驗證成功")
        RightCodeHT.Add("250", "要求的郵件操作完成")
        RightCodeHT.Add("251", "非本地用戶，將轉發向<forward-path>")
        RightCodeHT.Add("334", "服務器響應驗證Base64字符串")
        RightCodeHT.Add("354", "開始郵件輸入，以<CRLF>.<CRLF>結束")
    End Sub
#End Region

#Region "Dialog　"
    Private Overloads Function Dialog(ByVal str As String, ByVal errsstr As String) As Boolean
        Dim RR As String
        Dim RRCode As String
        If str Is Nothing Or str.Trim() = String.Empty Then
            Return True
        End If
        If SendCommand(str) Then
            RR = RecvResponse()
            If RR = "false" Then
                Return False
            End If

            RRCode = RR.Substring(0, 3)
            If RightCodeHT(RRCode) Is Nothing Then
                Return True
            Else
                If ErrCodeHT(RRCode) Is Nothing Then
                    Return True
                Else
                    ' Me.Label9.Text = errstr
                    Return False
                End If
            End If
        Else
            'Me.Label9.Text = errstr
            Return False
        End If
    End Function

    Private Overloads Function Dialog(ByVal str() As String, ByVal errstr As String) As Boolean
        Dim i As Integer
        For i = 0 To str.Length - 1
            If Dialog(str(i), "") = False Then
                Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region "GetPriorityString　判斷郵件優先權"
    Private Function GetPriorityString(ByVal mailPriority As MailPriority) As String
        Dim priority As String = "Normal"

        If mailPriority = mailPriority.Low Then
            priority = "Low"
        ElseIf mailPriority = mailPriority.High Then
            priority = "High"
        End If

        Return priority
    End Function
#End Region
#End If
#End Region
End Class


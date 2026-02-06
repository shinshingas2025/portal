Imports System.Web.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class recent
    Inherits System.Web.UI.Page
    Private thread_status As Boolean = False
    Private ErrCodeHT As Hashtable = New Hashtable
    Private RightCodeHT As Hashtable = New Hashtable
    Private stream As NetworkStream
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator2 As System.Web.UI.WebControls.RegularExpressionValidator
    Private tcpClient As TcpClient
#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents Mssage As System.Web.UI.WebControls.Label
    Protected WithEvents form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnReset As System.Web.UI.WebControls.Button
    Protected WithEvents btnOK As System.Web.UI.WebControls.Button
    Protected WithEvents txtWmEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents message As System.Web.UI.WebControls.Label
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator

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
        '---------------------------------------------
        '檢查是否已經LoginID
        If Session("UserName") = "" Then
            Response.Redirect("../DesktopDefault.aspx")
        End If
        '---------------------------------------------

        If Not IsPostBack Then
            txtWmEmail.Text = ""
            message.Text = ""
        End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtWmEmail.Text = ""
        message.Text = ""
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim objDao As New RECENTDAO
        Dim sWmOpenCode As String
        Dim MailMessage As New System.Web.Mail.MailMessage
        Dim Body As String
        Try
            sWmOpenCode = objDao.GetWmOpenCode(txtWmEmail.Text).ToString
            If sWmOpenCode.Length > 0 Then
                Dim DataA(2) As String '= Split(sWmOpenCode, " ")
                DataA(0) = Trim(Right(sWmOpenCode, 12))
                DataA(1) = Trim(Left(sWmOpenCode, Len(sWmOpenCode) - 15))
                SMTPCodeAdd()
                MailMessage.BodyFormat = MailFormat.Html
                MailMessage.From = "ebill@shinshingas.com.tw" ' "camilleliao@rpti3.com.tw"
                MailMessage.To = txtWmEmail.Text
                MailMessage.Subject = "欣欣天然氣-會員註冊授權碼"

                Body = "親愛的客戶" & DataA(1) & "，您好！<br/><br/>"
                Body = Body & "感謝您成為欣欣天然氣網站的會員．<br/><br/>"
                Body = Body & "<font color=blue size=4>請點選下面紅字確認您的電子信箱，以啟動您的會員資格．</font><br/><br/>"
                'Body = Body & "如果點選下面的連結無法正常運作，您可以自行輸入或複製這個網址到您的瀏覽器．<br/><br/>"
                Body = Body & "<a  href=""https://www.shinshingas.com.tw/Activity.aspx?WmOpenCode=" & DataA(0) & """><font color=red size=7>點我啟動會員資格</font></a><br/><br/>"
                Body = Body & "<font color=#588994 size=4>若您無法開啟連結，請複製下方的授權碼，至欣欣天然氣網站（ <a href=""https://www.shinshingas.com.tw/"">https://www.shinshingas.com.tw/</a>) </font><br/> <br/>"
                Body = Body & "點選『電子繳費憑證服務』，選擇『會員登入』頁中之『啟動會員資格』，<br/>"
                Body = Body & "貼上授權碼，即可啟動完成．<br/><br/>"
                Body = Body & "授權碼：" & DataA(0) & "<br/><br/><br/><br/>"
                Body = Body & "謝謝！<br/>"
                Body = Body & "欣欣天然氣公司股份有限公司．<br/>"
#If 0 Then

                Body = "<h1>親愛的客戶！歡迎您</h1><p><br/><br/>" ' "<html><body><h1>WELCOME</h1><p>"
                Body &= "您註冊的身份別是：" & IIf(DataA(3) = "1", "個人用戶", IIf(DataA(3) = "2", "營業用戶", "機關用戶")) & "<br>"
                Body &= "您註冊的身份證號碼是：" & DataA(2) & "<br>"
                Body &= "您註冊的密碼是：" & DataA(1) & "<br><hr>"
                Body &= "請按以下超連結登入以完成註冊程續： <BR><BR><BR>"
                Body = Body & "<a  href=""http://localhost/shinshin/Activity.aspx?WmOpenCode=" & DataA(0) & """><font color=red size=6>點我確認會員認證成功</font></a><br/><br/>"
                Body = Body & "授權碼：" & DataA(0) & "<br/><br/><br/><br/>"
#End If
 MailMessage.Body = Body







                If SendEmail("msa.hinet.net", 25, True, "ebill", "22325804", MailMessage) = True Then       '"smtp.rpti3.com.tw"
                    message.Text = "授權碼己重新寄至您所申請的郵件信箱!"
                    Response.Redirect("recent_sucess.aspx")
                Else
                    message.Text = Err.Number.ToString & " " & Err.Description.ToString & "<br>由於預設的email信箱錯誤, 因此信件無法寄出, 請重新申請!"
                End If

            Else
                message.Text = "請再次確認您輸入的資料!"
        End If
        Catch ex As Exception
            message.Text = "失敗" & ex.StackTrace
        End Try
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
            tcpClient = New TcpClient
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

#If 0 Then
     Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim objDao As New RECENTDAO
        Dim sWmOpenCode As String
        'Dim MailServer As String = "smtp.rpti3.com.tw"
        Dim MailServer As String = "msa.hinet.net" ' "192.168.80.87"
        Dim NewMail As System.Web.Mail.SmtpMail
        Dim MailMessage As New System.Web.Mail.MailMessage
        Dim Body As String

        sWmOpenCode = objDao.GetWmOpenCode(txtWmEmail.Text).ToString
        If sWmOpenCode.Length > 0 Then
            Dim DataA() As String = Split(sWmOpenCode, " ")
            NewMail.SmtpServer = MailServer

            MailMessage.BodyFormat = MailFormat.Html
            MailMessage.From ="ebill@shinshingas.com.tw" ' "yehjyh@yahoo.com.tw" ' "camilleliao@rpti3.com.tw"
            MailMessage.To = txtWmEmail.Text
            MailMessage.Subject = "會員註冊授權碼"
            Body = "<html><body><h1>WELCOME</h1><p>"
            Body &= "您註冊的身份別是:" & IIf(DataA(3) = "1", "個人用戶", IIf(DataA(3) = "2", "營業用戶", "機關用戶")) & "<br>"
            Body &= "您註冊的身份證號碼是:" & DataA(2) & "<br>"
            Body &= "您註冊的密碼是:" & DataA(1) & "<br><hr>"
            Body &= "請按以下超連結登入以完成註冊程續: <BR><BR><BR>"
            Body = Body & "<a  href=""http://localhost/shinshin/Activity.aspx?WmOpenCode=" & DataA(0) & """><font color=red size=6>點我確認會員認證成功</font></a><br/><br/>"
            Body = Body & "授權碼：" & DataA(0) & "<br/><br/><br/><br/>"
            MailMessage.Body = Body
            On Error Resume Next
            ' NewMail.Send(MailMessage)
            'If Err.Number <> 0 Then
            'message.Text = Err.Number.ToString & " " & Err.Description.ToString & "<br>由於預設的email信箱錯誤, 因此信件無法寄出, 請重新申請!"
            'Else
            'message.Text = "授權碼己重新寄至您所申請的email信箱!"
            'End If
        Else
        message.Text = "請再次確認您輸入的資料!"
        End If

    End Sub
#End If
End Class

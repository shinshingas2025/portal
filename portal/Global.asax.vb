Imports System.Web.SessionState
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security
Imports System.Threading
Imports System.Globalization
Imports System.Web.Mail
Imports System.Xml

Imports ASPNET.StarterKit.Portal

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 在應用程式啟動時引發

        '20180419  改存記憶體  反應較快
        Dim tmpXml As New XmlDocument
        tmpXml.Load(Server.MapPath("/zRecord/su35l31j42l4ji3_backend.xml"))
        Application("su35l31j42l4ji3_backend") = tmpXml
        Application("su35l31j42l4ji3_count_backend") = 0

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 在工作階段啟動時引發
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 在各個要求開始時引發


        '本機RUn'
        'If Context.Request.IsSecureConnection = False Then
        '    Response.Redirect(Context.Request.Url.ToString().Replace("http://", "https://"))
        'End If


        '檢查各ip連線數  太多則阻檔  200次 20150728 硬碟吃不消可取消**********************************
        Dim tmpXml As New XmlDocument
        Dim GotIP As Boolean = False
        'tmpXml.Load(Server.MapPath("./zRecord/su35l31j42l4ji3.xml"))

        ''20180419  改存記憶體  反應較快
        'tmpXml = Application("su35l31j42l4ji3_backend")
        'Application("su35l31j42l4ji3_count_backend") += 1

        'If Request.Url.ToString.IndexOf("design_price.aspx") < 0 Then '排除design_price.aspx這頁


        '    If tmpXml.GetElementsByTagName("IPAddress").Count > 0 Then
        '        For Each tmpNode As XmlNode In tmpXml.GetElementsByTagName("IPAddress")

        '            If Trim(tmpNode.InnerText) = Trim(Request.ServerVariables("REMOTE_ADDR")) Then
        '                If tmpNode.Attributes("date").Value = Format(Now, "yyyy/MM/dd") Then
        '                    tmpNode.Attributes("count").Value += 1
        '                Else
        '                    tmpNode.Attributes("count").Value = 1
        '                    tmpNode.Attributes("date").Value = Format(Now, "yyyy/MM/dd")
        '                End If

        '                If tmpNode.Attributes("count").Value > 200 Then
        '                    Select Case tmpNode.Attributes("count").Value
        '                        Case 250
        '                            SendErrMail(tmpNode.InnerText & "連線次數已達到250次", Request.Path + " 檢查到大量連線行為！")
        '                            Response.Redirect("/404notfun.htm")
        '                        Case 500
        '                            SendErrMail(tmpNode.InnerText & "連線次數已達到500次", Request.Path + " 檢查到大量連線行為！")
        '                            Response.Redirect("/404notfun.htm")
        '                        Case Else
        '                            Response.Redirect("/404notfun.htm")
        '                    End Select
        '                Else

        '                End If

        '                GotIP = True
        '                Exit For

        '            End If
        '        Next

        '    End If
        '    If GotIP = False Then
        '        Dim root As XmlNode = tmpXml.DocumentElement
        '        Dim tmp_elem As XmlElement = tmpXml.CreateElement("IPAddress")
        '        tmp_elem.InnerText = Trim(Request.ServerVariables("REMOTE_ADDR"))
        '        tmp_elem.SetAttribute("count", "1")
        '        tmp_elem.SetAttribute("date", Format(Now, "yyyy/MM/dd"))
        '        tmpXml.GetElementsByTagName("IP_List").Item(0).AppendChild(tmp_elem)

        '    End If

        'End If


        'tmpXml.Save(Server.MapPath("./zRecord/su35l31j42l4ji3.xml"))
        '20180419  改存記憶體  反應較快


        'Application("su35l31j42l4ji3_backend") = tmpXml
        'If Application("su35l31j42l4ji3_count_backend") > 100 Then  '每100筆連線存檔一次，減少寫檔次數
        '    Application("su35l31j42l4ji3_count_backend") = 1
        '    tmpXml.Save(Server.MapPath("/zRecord/su35l31j42l4ji3_backend.xml"))
        'End If

        '*****************************************************************





        Dim tabIndex As Integer = 0
        Dim tabId As Integer = 1
        Dim sid As String = ""

        ' Get TabIndex from querystring
        If Not (Request.Params("tabindex") Is Nothing) Then
            tabIndex = CInt(Request.Params("tabindex"))
        End If

        ' Get TabID from querystring
        If Not (Request.Params("tabid") Is Nothing) Then
            tabId = CInt(Request.Params("tabid"))
        End If

        ' Get SchoolID from querystring
        If Not (Request.Params("sid") Is Nothing) Then
            sid = CType(Request.Params("sid"), String)
        Else
            sid = "2"
        End If

        ' Add the PortalSettings object to the context
        If sid = "" Then
            Context.Items.Add("PortalSettings", New PortalSettings(tabIndex, tabId))
        Else
            Context.Items.Add("PortalSettings", New PortalSettings(tabIndex, tabId, sid))
        End If
        ' Read the configuration info from the XML file or retrieve from Cache
        ' and add to the context
        Dim config As Configuration = New Configuration
        If sid = "" Then
            Context.Items.Add("SiteSettings", config.GetSiteSettings())
        Else
            Context.Items.Add("SiteSettings", config.GetSiteSettings(sid))
        End If

        Try
            If Not (Request.UserLanguages Is Nothing) Then
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
                ' Default to English if there are no user languages
            Else
                Thread.CurrentThread.CurrentCulture = New CultureInfo("en-us")
            End If
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture
        Catch ex As Exception
            Thread.CurrentThread.CurrentCulture = New CultureInfo("en-us")
        End Try

        If Request.ServerVariables("Query_String") <> Nothing Then
            If InStr(Request.ServerVariables("Query_String").ToLower, "select") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "insert") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "delete") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "update") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "exec") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "drop") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "print") > 0 Or InStr(Request.ServerVariables("Query_String").ToLower, "union") > 0 Then

                Dim CASEINFO As String

                'CASEINFO = CASEINFO & "<br>發生時間：" & Now.ToLongDateString & " " & Now.ToLongTimeString 
                'CASEINFO = CASEINFO & "<br>發生IP：" & Request.ServerVariables("REMOTE_ADDR") 
                CASEINFO = CASEINFO & "發生時間：" & Now.ToLongDateString & " " & Now.ToLongTimeString & vbCrLf
                CASEINFO = CASEINFO & "發生IP：" & Request.ServerVariables("REMOTE_ADDR") & vbCrLf
                CASEINFO = CASEINFO & "發生之QUERY STRING：" & Request.ServerVariables("Query_String") & vbCrLf
                SendErrMail(CASEINFO & vbCrLf, Request.Path + " 檢查到不良指令碼發送！")


                Response.Write("<table align=center height=100% ><tr><td><center><font color=gray>不正確之指令碼發送,請回上一頁重新操作。<br><br></font></center> </td></tr></table>")
                Response.End()
            End If
        End If



    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 在嘗試驗證使用時引發

        If Request.IsAuthenticated = True Then

            Dim roles() As String

            ' Create the roles cookie if it doesn't exist yet for this session.
            If Request.Cookies("portalroles") Is Nothing Then

                ' Get roles from UserRoles table, and add to cookie
                Dim _user As New UsersDB
                roles = _user.GetRoles(User.Identity.Name)

                ' Create a string to persist the roles
                Dim roleStr As String = ""
                Dim role As String

                For Each role In roles

                    roleStr += role
                    roleStr += ";"

                Next role

                ' Create a cookie authentication ticket.
                '   version
                '   user name
                '   issue time
                '   expires every hour
                '   don't persist cookie
                '   roles
                Dim ticket As New FormsAuthenticationTicket(1,
                 Context.User.Identity.Name,
                 DateTime.Now,
                 DateTime.Now.AddHours(1),
                 False,
                 roleStr)

                ' Encrypt the ticket
                Dim cookieStr As String = FormsAuthentication.Encrypt(ticket)

                ' Send the cookie to the client
                Response.Cookies("portalroles").Value = cookieStr
                Response.Cookies("portalroles").Path = "/"
                Response.Cookies("portalroles").Expires = DateTime.Now.AddMinutes(1)

            Else

                ' Get roles from roles cookie
                Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("portalroles").Value)

                'convert the string representation of the role data into a string array
                Dim userRoles As New ArrayList

                Dim role As String

                For Each role In ticket.UserData.Split(New Char() {";"c})
                    userRoles.Add(role)
                Next role

                roles = CType(userRoles.ToArray(GetType(String)), String())

            End If

            ' Add our own custom principal to the request containing the roles in the auth ticket
            Context.User = New GenericPrincipal(Context.User.Identity, roles)

        End If

    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' 在錯誤發生時引發
        Dim Message As String = ""
        Dim ex As Exception = Server.GetLastError.InnerException
        '記錄錯誤網頁　錯誤資訊　跟錯誤行號
        Message = ""
        Dim tmpstr As String
        Dim errLine As String = ""
        Dim i As Integer = 0

        Try
            For Each tmpstr In Split(ex.StackTrace, " at")
                If InStr(tmpstr, ":line ") > 0 Then
                    errLine = Split(tmpstr, ":line ")(UBound(Split(tmpstr, ":line ")))
                    Message = "發生錯誤之函數：" & Split(tmpstr, " in ")(0)
                    Exit For
                End If
            Next
            Dim CASEINFO As String

            'CASEINFO = CASEINFO & "<br>發生時間：" & Now.ToLongDateString & " " & Now.ToLongTimeString 
            'CASEINFO = CASEINFO & "<br>發生IP：" & Request.ServerVariables("REMOTE_ADDR") 
            CASEINFO = CASEINFO & "發生時間：" & Now.ToLongDateString & " " & Now.ToLongTimeString & vbCrLf
            CASEINFO = CASEINFO & "發生IP：" & Request.ServerVariables("REMOTE_ADDR") & vbCrLf
            CASEINFO = CASEINFO & "發生之QUERY STRING：" & Request.ServerVariables("Query_String") & vbCrLf

            CASEINFO = CASEINFO & "" & Message & vbCrLf
            CASEINFO = CASEINFO & "錯誤行號：" & errLine & vbCrLf



            'SendErrMail("<font color=blue>" & ex.Message & "</font><br><br>" & CASEINFO & "<br><br><br>錯誤堆疊資訊：<br><font color=orange>" & ex.StackTrace & "</font>", Request.Path)
            SendErrMail(ex.Message & vbCrLf & CASEINFO & vbCrLf & "錯誤堆疊資訊：" & ex.StackTrace & "", Request.Path)
            'SendErrMail_Billhunter("<font color=blue>" & ex.Message & "</font><br><br>" & CASEINFO & "<br><br><br>錯誤堆疊資訊：<br><font color=orange>" & ex.StackTrace & "</font>", Request.Path)
            '取得第一個錯誤的錯誤行號


            'Server.ClearError()

            'Response.Redirect("/Land_eloan/ErrPage.aspx")
            Response.Write("<table align=center height=100% ><tr><td><center><font color=gray>系統異常, 已記錄錯誤,請回上一頁重新操作，<br><br>我們將於收到錯誤後儘快改善，造成不便，敬請見諒。</font></center> </td></tr></table>")
            Response.End()

        Catch Globalex As Exception

        End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在工作階段結束時引發
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在應用程式結束時引發
    End Sub

    Public Shared Function GetApplicationPath(ByVal request As HttpRequest) As String
        Dim path As String = String.Empty
        Try
            If request.ApplicationPath <> "/" Then
                path = request.ApplicationPath
            End If
        Catch e As Exception
            Throw e
        End Try

        Return path
    End Function 'GetApplicationPath

    Sub SendErrMail(ByVal ErrStr As String, ByVal ErrPath As String)

        Try

            Dim mySmtpMail As SmtpMail
            mySmtpMail.SmtpServer = "172.16.0.5"
            'mySmtpMail.Send("ShinShinWeb@shinshingas.com.tw", "bacom@shinshingas.com.tw", "對外網站-後檯管理系統 " & ErrPath & " Error通知", ErrStr)
            '1150121 add 
            mySmtpMail.Send("ShinShinWeb@shinshingas.com.tw", "sarah194910001@shinshingas.com.tw", "對外網站-後檯管理系統 " & ErrPath & " Error通知", ErrStr)
            mySmtpMail.Send("ShinShinWeb@shinshingas.com.tw", "shinshingas2025@gmail.com", "對外網站-後檯管理系統 " & ErrPath & " Error通知", ErrStr)

        Catch ex As Exception
            '發信失敗訊息要隱藏，以免影響程式

        End Try

    End Sub
End Class
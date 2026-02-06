<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/Footer.asp"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<!-- #include virtual = "/WinBoard/Private/Emotion.asp" -->
<%
  Function Encode(re, sMsg, bWBCodes, emotion, bNotSig)
    Dim i

    re.Global = True
    re.IgnoreCase = True
    re.Pattern = "\&"
    sMsg = re.Replace(sMsg, "&amp;")
    re.Pattern = "\<"
    sMsg = re.Replace(sMsg, "&lt;")
    re.Pattern = "\>"
    sMsg = re.Replace(sMsg, "&gt;")
    re.Pattern = "\"""
    sMsg = re.Replace(sMsg, "&quot;")
    re.Pattern = "\'"
    sMsg = re.Replace(sMsg, "&#39")
    re.Pattern = "\r"
    sMsg = re.Replace(sMsg, "")
    re.Pattern = "\\\["
    sMsg = re.Replace(sMsg, "[<!-- -->")
    re.Pattern = "\\\("
    sMsg = re.Replace(sMsg, "(<!-- -->")
    If bWBCodes Then
      re.Pattern = "(^|\s)(http:\/\/\S+)"
      sMsg = re.Replace(sMsg, "$1<a href=""$2"" target=""_blank"">$2</a>")
      re.Pattern = "(^|\s)(ftp:\/\/\S+)"
      sMsg = re.Replace(sMsg, "$1<a href=""$2"" target=""_blank"">$2</a>")
      re.Pattern = "(^|\s)([\.\w\-]+\@[\.\w\-]+\.[\.\w\-]+)"
      sMsg = re.Replace(sMsg, "$1<a href=""mailto:$2"">$2</a>")
      re.Pattern = "(^|\s)\\(http:\/\/\S+)"
      sMsg = re.Replace(sMsg, "$1$2")
      re.Pattern = "(^|\s)\\(ftp:\/\/\S+)"
      sMsg = re.Replace(sMsg, "$1$2")
      re.Pattern = "(^|\s)\\([\.\w\-]+\@[\.\w\-]+\.[\.\w\-]+)"
      sMsg = re.Replace(sMsg, "$1$2")
      re.Pattern = "\[img\s*=\s*\&quot\;\s*(\S+)\s*\&quot\;\s*\]"
      sMsg = re.Replace(sMsg, "<img src=""$1"" border=""0"">")
      re.Pattern = "\[img\s*=\s*(\S+)\s*\]"
      sMsg = re.Replace(sMsg, "<img src=""$1"" border=""0"">")
      re.Pattern = "\[url\s*=\s*\&quot\;\s*(\S+)\s*\&quot\;\s*\]((.|\n)*?)\[\/url\]"
      sMsg = re.Replace(sMsg, "<a href=""$1"" target=""_blank"">$2</a>")
      re.Pattern = "\[url\s*=\s*(\S+)\s*\]((.|\n)*?)\[\/url\]"
      sMsg = re.Replace(sMsg, "<a href=""$1"" target=""_blank"">$2</a>")
      re.Pattern = "\[email\s*=\s*\&quot\;([\.\w\-]+\@[\.\w\-]+\.[\.\w\-]+)\s*\&quot\;\s*\]((.|\n)*?)\[\/email\]"
      sMsg = re.Replace(sMsg, "<a href=""mailto:$1"">$2</a>")
      re.Pattern = "\[email\s*=\s*([\.\w\-]+\@[\.\w\-]+\.[\w\-]+)\s*\]((.|\n)*?)\[\/email\]"
      sMsg = re.Replace(sMsg, "<a href=""mailto:$1"">$2</a>")
      re.Pattern = "\[b\]((.|\n)*?)\[\/b\]"
      sMsg = re.Replace(sMsg, "<b>$1</b>")
      re.Pattern = "\[i\]((.|\n)*?)\[\/i\]"
      sMsg = re.Replace(sMsg, "<i>$1</i>")
      re.Pattern = "\[u\]((.|\n)*?)\[\/u\]"
      sMsg = re.Replace(sMsg, "<u>$1</u>")
      re.Pattern = "\[sub\]((.|\n)*?)\[\/sub\]"
      sMsg = re.Replace(sMsg, "<sub>$1</sub>")
      re.Pattern = "\[sup\]((.|\n)*?)\[\/sup\]"
      sMsg = re.Replace(sMsg, "<sup>$1</sup>")
      re.Pattern = "\[center\]((.|\n)*?)\[\/center\]"
      sMsg = re.Replace(sMsg, "<center>$1</center>")
      re.Pattern = "\[1\]((.|\n)*?)\[\/1\]"
      sMsg = re.Replace(sMsg, "<font size=""1"" class=""1"">$1</font>")
      re.Pattern = "\[2\]((.|\n)*?)\[\/2\]"
      sMsg = re.Replace(sMsg, "<font size=""2"" class=""2"">$1</font>")
      re.Pattern = "\[3\]((.|\n)*?)\[\/3\]"
      sMsg = re.Replace(sMsg, "<font size=""3"" class=""3"">$1</font>")
      re.Pattern = "\[4\]((.|\n)*?)\[\/4\]"
      sMsg = re.Replace(sMsg, "<font size=""4"" class=""4"">$1</font>")
      re.Pattern = "\[fixed\]((.|\n)*?)\[\/fixed\]"
      sMsg = re.Replace(sMsg, "<font class=""monospace"">$1</font>")
      re.Pattern = "\[color\s*=\s*\&quot\;\s*([#0-9a-fA-F]+)\s*\&quot\;\s*\]((.|\n)*?)\[\/color\]"
      sMsg = re.Replace(sMsg, "<font color=""$1"">$2</font>")
      re.Pattern = "\[color\s*=\s*([#0-9a-fA-F]+)\s*\]((.|\n)*?)\[\/color\]"
      sMsg = re.Replace(sMsg, "<font color=""$1"">$2</font>")
      re.Pattern = "\(c\)"
      sMsg = re.Replace(sMsg, "&copy;")
      re.Pattern = "\(r\)"
      sMsg = re.Replace(sMsg, "&reg;")
      re.Pattern = "\(tm\)"
      sMsg = re.Replace(sMsg, "&#153;")
      re.Pattern = "\[\&amp\;(\d+)\]"
      sMsg = re.Replace(sMsg, "&#$1;")
      re.Pattern = "\[\&amp\;(\w+)\]"
      sMsg = re.Replace(sMsg, "&$1;")
      For i = 0 To UBound(emotion)
        re.Pattern = "\&"
        sEmotion = re.Replace(emotion(i)(0), "&amp;")
        re.Pattern = "\<"
        sEmotion = re.Replace(sEmotion, "&lt;")
        re.Pattern = "\>"
        sEmotion = re.Replace(sEmotion, "&gt;")
        re.Pattern = "\"""
        sEmotion = re.Replace(sEmotion, "&quot;")
        re.Pattern = "\'"
        sEmotion = re.Replace(sEmotion, "&#39")
        sQuotedEmotion = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(sEmotion, "\", "\\"), ".", "\."), "+", "\+"), "*", "\*"), "?", "\?"), "[", "\["), "^", "\^"), "]", "\]"), "(", "\("), "$", "\$"), ")", "\)")
        re.Pattern = "(^|\s|\])\\\\" & sQuotedEmotion &  "(\[|\s|$)"
        sMsg = re.Replace(sMsg, "$1\<!-- -->" & sEmotion & "$2")
        re.Pattern = "(^|\s|\])\\" & sQuotedEmotion &  "(\[|\s|$)"
        sMsg = re.Replace(sMsg, "$1\<!-- -->" & sEmotion & "$2")
        re.Pattern = "(^|\s|\])" & sQuotedEmotion &  "(\[|\s|$)"
        sMsg = re.Replace(sMsg, "$1<img src=""" & Application("IMAGE_URL") & "/Default/" & emotion(i)(2) & """ border=""0"" valign=""absmiddle"">$2")
      Next
      If bNotSig Then
        re.Pattern = "\[order(=(1|a|A|i|I))?\]((.|\n)*?)\[\/order\]"
        sMsg = re.Replace(sMsg, "<ol type=""$1"">$3</ol>")
        re.Pattern = "\[unorder(=(circle|square|disc))?\]((.|\n)*?)\[\/unorder\]"
        sMsg = re.Replace(sMsg, "<ul type=""$1"">$3</ul>")
        re.Pattern = "\[list(=(1|a|A|i|I))?\]((.|\n)*?)\[\/list\]"
        sMsg = re.Replace(sMsg, "<ol type=""$1"">$3</ol>")
        re.Pattern = "\[list(=(circle|square|disc))?\]((.|\n)*?)\[\/list\]"
        sMsg = re.Replace(sMsg, "<ul type=""$1"">$3</ul>")
        re.Pattern = "\[(\#|\+)(\d)?\]"
        sMsg = re.Replace(sMsg, "<li value=""$2"">")
        re.Pattern = "\[quote\]\n*((.|\n)*?)\n*\[\/quote\]"
        While re.Test(sMsg)
          sMsg = re.Replace(sMsg, "<blockquote><hr>$1<hr></blockquote>")
        WEnd
        re.Pattern = "\[code\]\n*((.|\n)*?)\n*\[\/code\]"
        While re.Test(sMsg)
          sMsg = re.Replace(sMsg, "<blockquote><pre class=""code""><font class=""code"">code:</font><hr>$1<hr></pre></blockquote>")
        WEnd
        re.Pattern = "\[pre\]\n*((.|\n)*?)\n*\[\/pre\]"
        While re.Test(sMsg)
          sMsg = re.Replace(sMsg, "<pre>$1</pre>")
        WEnd
      End If
    End If
    re.Pattern = "\n\n"
    sMsg = re.Replace(sMsg, "<p>")
    re.Pattern = "\n"
    Encode = re.Replace(sMsg, "<br>")
  End Function
    
    Dim objConn, iBID, iCID, sBTitle, sCTitle, i, j, bValidPara, dNow, rst, sNickname, sEmail, sSubject, sMessage, s, bLogin, sSQL, iSig, iErr, re, bWBCodes, bHTMLTags, sEmotion, sQuotedEmotion, iTID, iPID, sSig
  
  dNow = Now
  bLogin = Session("Usr_Logon")
  If Request.Form("FORM_SIGNATURE") = "on" Then
    iSig = 1
    Response.Cookies(Application("COOKIES") & "SIGNATURE") = "1"
    Response.Cookies(Application("COOKIES") & "SIGNATURE").Expires = DateAdd("m", 1, dNow)
  Else
    iSig = 0
    Response.Cookies(Application("COOKIES") & "SIGNATURE").Expires = DateSerial(1980, 1, 1)
  End If
%>
<!-- #include virtual = "/WinBoard/Private/ProcessBID.asp"  -->
<%
  iTID = Request.Form("TID")
  If Len(iTID) > 0 Then
    If Not IsNumeric(iTID) Then
      Response.Write "Error"
      Response.End
    End If
  Else
    iTID = -1
  End If

  iPID = Request.Form("PID")
  If Len(iPID) > 0 Then
    If Not IsNumeric(iPID) Then
      Response.Write "Error"
      Response.End
    End If
  Else
    iPID = -1
  End If

  Set objConn = Server.CreateObject("ADODB.Connection")
  objConn.ConnectionTimeout = Application("TX_Timeout")
  objConn.Open Application("ConnectionString")
  Set rst = Server.CreateObject("ADODB.RecordSet")
  rst.CursorLocation = adUseClient
  rst.Open "SELECT [WBCodes], [HTMLTags] FROM [Boards] WHERE [BID] = " & iBID, objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
  bWBCodes = rst("WBCodes")
  bHTMLTags = rst("HTMLTags")
  rst.Close

  sSubject = Request.Form("FORM_SUBJECT")
  sMessage = Request.Form("FORM_MESSAGE")
  If bLogin Then
    sSQL = "SELECT [Nickname], [Email]"
    If iSig = 1 Then sSQL = sSQL & ", [Signature]"
    rst.Open sSQL & " FROM [Accounts] WHERE [Username] = '" & Session("Usr_Username") & "'", objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
    If rst.EOF Then
      Response.Write "Error"
      Response.End
    End If
    sNickname = rst("Nickname").Value
    sEmail = rst("Email").Value
    If iSig = 1 Then sSig = Replace(rst("Signature").Value, "\n", vbCrLf)
    rst.Close
  Else
    sNickname = Request.Form("FORM_NICKNAME")
    sEmail = Request.Form("FORM_EMAIL")
    Response.Cookies(Application("COOKIES") & "NICKNAME") = sNickname
    Response.Cookies(Application("COOKIES") & "NICKNAME").Expires = DateAdd("m", 1, dNow)
    Response.Cookies(Application("COOKIES") & "EMAIL") = sEmail
    Response.Cookies(Application("COOKIES") & "EMAIL").Expires = DateAdd("m", 1, dNow)
  End If

  iErr = 0
  If Len(sNickname) = 0 Then
    iErr = 1
  ElseIf Len(sEmail) = 0 Then
    iErr = 2
  ElseIf Len(sSubject) = 0 Then
    iErr = 3
  ElseIf Len(sMessage) = 0 Then
    iErr = 4
  End If

  If iErr <> 0 Then
    Session("Tmp_Err") = iErr
    Session("Tmp_Subject") = sSubject
    Session("Tmp_Message") = sMessage
    s = Application("WB_URL") & "/Post.asp?BID=" & iBID
    If iTID <> -1 Then s = s & "&TID=" & iTID : If iPID <> -1 Then s = s & "&PID=" & iPID
    Response.Redirect s
  Else
    objConn.BeginTrans
    On Error Resume Next
    s = FormatDate(dNow, "yyyy-MM-dd hh:mm:ss")
    'sSQL = "INSERT INTO [b" & iBID & "] (Subject, "
    'If bLogin Then sSQL = sSQL & "Username, "
    'sSQL = sSQL & "UEmail, UNickname, "
    'If iTID <> -1 Then sSQL = sSQL & "Root, "
    'sSQL = sSQL & "PostDate, LastPostDate, LastUpdateDate, Host, IP, Signature, BodySrc, BodyHTML) VALUES(N'" & sSubject & "', "
    'If bLogin Then sSQL = sSQL & "'" & Session("Usr_Username") & "', "
    'sSQL = sSQL & "'" & sEmail & "', N'" & sNickname & "', "
    'If iTID <> -1 Then sSQL = sSQL & iTID & ", "
    'sSQL = sSQL & "'" & s & "', '" & s & "', '" & s & "', '" & Request.ServerVariables("REMOTE_HOST") & "', '" & Request.ServerVariables("REMOTE_ADDR") & "', " & iSig & ", N'" & Replace(sMessage, "'", "''") & "', N'"
    rst.Open "B" & iBID, objConn, adOpenForwardOnly, adLockOptimistic, adCmdTable
    rst.AddNew
    rst("Subject") = sSubject
    If bLogin Then rst("Username") = Session("Usr_Username")
    rst("UEmail") = sEmail
    rst("UNickname") = sNickname
    If iTID <> -1 Then rst("Root") = iTID
    rst("PostDate") = s
    rst("LastPostDate") = s
    rst("LastUpdateDate") = s
    rst("Host") = Request.ServerVariables("REMOTE_HOST")
    rst("IP") = Request.ServerVariables("REMOTE_ADDR")
    rst("Signature") = iSIG = 1
    rst("BodySrc") = sMessage
    Set re = Server.CreateObject("VBScript.RegExp")
    'objConn.Execute sSQL & sMessage & "')"
    sMessage = Encode(re, sMessage, bWBCodes, emotion, True)
    If iSig = 1 Then sMessage = sMessage & vbCrLf & "<!-- Signature -->" & vbCrLf & "<hr>" & vbCrLf & Encode(re, sSig, bWBCodes, emotion, False) & vbCrLf & "<!-- Signature -->"
    rst("BodyHTML") = sMessage
    rst.Update
    If Err.Number = 0 Then
      If iTID <> -1 Then objConn.Execute "UPDATE [b" & iBID & "] SET [Replies] = [Replies] + '," & rst("PID").Value & "', [RepliesCnt] = [RepliesCnt] + 1, [LastPostDate] = '" & s & "' WHERE [PID] = " & iTID
      objConn.Execute "UPDATE [Accounts] SET [LastPostDate] = '" & s & "', [TotalPosts] = [TotalPosts] + 1 WHERE [Username] = '" & Session("Usr_Username") & "'"
      If Err.Number = 0 Then
        If iTID = -1 Then sSQL = ", [TotalTopics] = [TotalTopics] + 1" Else sSQL = ""
        objConn.Execute "UPDATE [Boards] SET [LastPostDate] = '" & s & "', [LastUpdateDate] = '" & s & "', [TotalPosts] = [TotalPosts] + 1" & sSQL & " WHERE [BID] = " & iBID
        If Err.Number = 0 Then objConn.Execute "UPDATE [Categories] SET [LastUpdateDate] = '" & s & "', [TotalPosts] = [TotalPosts] + 1" & sSQL & " WHERE [CID] = " & iCID
      End If
    End If
    If Err.Number <> 0 Then
      objConn.RollbackTrans
      Response.Write Err.Description
      Response.End
    Else
      objConn.CommitTrans
    End If
    On Error Goto 0
  End If
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index</a> / <a href="<% = Application("WB_URL") %>/ShowBoard.asp?CID=<% = iCID %>" class="normal"><% = sCTitle %></a> / <a href="<% = Application("WB_URL") %>/ShowTopic.asp?BID=<% = iBID %>" class="normal"><% = sBTitle %></a></b></font></td>
    <td nowrap></td>
  </tr>
</table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="1" class="border">
  <tr>
    <td>
      <table width="100%" cellspacing="1" cellpadding="4" border="0">
        <tr class="category">
          <td><font class="category">Post a new topic</font></td>
        </tr>
        <tr class="body">
          <td>
            <table width="100%" cellspacing="0" cellpadding="2">
              <tr>
                <td colspan="3"><font class="body">Your topic has been posted.</font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Nickname</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sNickname %></font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Email</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sEmail %></font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">To</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sCTitle & " / " & sBTitle %></font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Subject</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sSubject %></font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textarea">Message</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sMessage %></font></td>
              </tr>
              <tr>
                <td colspan="3"><font class="body">&nbsp;</font></td>
              </tr>
              <tr>
                <td colspan="3"><font class="body"><a href="<% = Application("WB_URL") %>/ShowCategory.asp">Back to index.</a><br><a href="<% = Application("WB_URL") %>/ShowTopic.asp?BID=<% = iBID %>">Back to the board.</a></font></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td align="right">
      <font class="sub-normal">Powered by <a href="http://www.drumk.com" target="_blank">WinBoard</a> 2002,<br>Copyright &copy; <a href="http://www.drumk.com" target="_blank">www.drumk.com, Inc.</a> 2002.</font>
    </td>
  </tr>
</table>
</body>
</html>
<%
  If rst.State <> adStateClosed Then rst.Close
  Set rst = Nothing
  objConn.Close
  Set objConn = Nothing
%>
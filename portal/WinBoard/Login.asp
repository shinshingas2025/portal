<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<%
  Dim bLogin, bError, dNow, s

  dNow = Now
  bLogin = Len(Request.Form("Username")) > 0
  If bLogin Then
    Dim objCrypt, objConn, rst, sDate, objMD5
    
    Set objCrypt = Server.CreateObject("CryptLIB.Crypt")

    Set objConn = Server.CreateObject("ADODB.Connection")
    objConn.ConnectionTimeout = Application("TX_Timeout")
    objConn.Open Application("ConnectionString")

    Set rst = Server.CreateObject("ADODB.RecordSet")
    rst.CursorLocation = adUseClient
    rst.Open "SELECT * FROM [Accounts] WHERE [Username] = '" & Request.Form("Username") & "' AND [Password] = '" & objCrypt.UnixCrypt(Left(Request.Form("Username"), 2), Request.Form("Password")) & "'", objConn, adOpenForwardOnly, adLockReadOnly, adCmdText

    bError = rst.EOF
    If Not bError Then
      Set objMD5 = Server.CreateObject("CryptLIB.MD5")
      Session("Usr_Logon") = True
      Session("Usr_Username") = rst("Username").Value
      sDate = FormatDate(dNow, "yyyy-MM-dd hh:mm:ss")
      objMD5.md5_init
      objMD5.md5_append CStr(Session("Usr_Username"))
      objMD5.md5_append sDate
      objMD5.md5_append "abcdBanandgia"
      rst.Close
      rst.Open "Session", objConn, adOpenForwardOnly, adLockOptimistic, adCmdTable
      rst.AddNew
      rst("Hash") = objMD5.md5_finish
      rst("Username") = Session("Usr_Username")
      rst("LoginDate") = sDate
      rst.Update
      s = Request.Servervariables("REMOTE_HOST")
      If Len(s) = 0 Then s = "Null" Else s = "'" & s & "'"
      objConn.Execute "UPDATE [Accounts] SET [LastLoginDate] = '" & FormatDate(dNow, "yyyy-MM-dd hh:mm:ss") & "', [Host] = " & s & ", [IP] = '" & Request.Servervariables("REMOTE_ADDR") & "' WHERE [Username] = '" & Session("Usr_Username") & "'"
      'objConn.Execute "INSERT INTO [Session] (Hash, Username, LoginDate) VALUES('" & CStr(objMD5.md5_finish) & "', '" & Session("Usr_Username") & "', '" & sDate & "')"
      Response.Cookies(Application("COOKIES") & "SESSION") = rst("SID").Value & "A" & rst("Hash").Value
      Response.Cookies(Application("COOKIES") & "SESSION").Expires = DateAdd("m", 1, dNow)
      Set objMD5 = Nothing
    End If

    rst.Close
    Set rst = Nothing
    objConn.Close
    Set objConn = Nothing
    Set objCrypt = Nothing
  End If
  If bLogin And Not bError Then
    'Response.Redirect Application("WB_URL") & "/ShowTopic.asp?BID=1"
    Response.Redirect Session("Tmp_LastVisited")
  Else
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index</a> / </b></font></td>
    <td nowrap></td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="0"><tr><td nowrap><form action="<% = Application("WB_URL") %>/Login.asp" name="form" method="post"></td></tr></table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="1" class="border">
  <tr>
    <td>
      <table width="100%" cellspacing="1" cellpadding="4" border="0">

        <tr class="category">
          <td><font class="category">Login</font></td>
        </tr>
        <tr class="body">
          <td>
            <table width="100%" cellspacing="0" cellpadding="2">
              <tr>
                <td colspan="3"><font class="body"><% If bLogin And bError Then %>Error:<br>&nbsp;&nbsp;<font class="error-body">Your username and/or password are invalid, please try again.</font><br>Please make any changes and try again!<p><% End If %>Please enter your username and password to login. If you do not have an account, please <a href="UltraBoard.PL?action=Register">register</a> an account.</font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Username</font>&nbsp;</td>
                <td width="60%" valign="top" nowrap><input type="text" name="Username" size="40" maxlength="128" class="textbox"></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-textbox">enter your username.</font></td></tr></table></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="passwordbox">Password</font>&nbsp;</td>
                <td width="60%" valign="top" nowrap><input type="password" name="Password" size="45" maxlength="128" class="passwordbox"></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-passwordbox">enter your password.<br><a href="<% = Application("WB_URL") %>/RetrievePassword.asp">lost your password?</a></font></td></tr></table></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><table border="0" cellspacing="0" cellpadding="0"><tr><td><input type="checkbox" name="FORM_REMEMBER_PASSWORD" value="1" class="checkbox"></td><td width="100%"><font class="body">Remember your password?</font></td></tr></table></td>
                
              </tr>
            </table>
            <table border="0" width="100%" cellspacing="0" cellpadding="2">
              <tr>
                <td width="150" valign="top" nowrap>&nbsp;</td>
                <td width="60%" nowrap><input type="submit" value="Login" class="button"> <input type="reset" value="Cancel" class="button"></td>
                <td width="40%" valign="top" nowrap>&nbsp;</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="0"><tr><td nowrap></form></td></tr></table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td align="right">
      <font class="sub-normal">Powered by <a href="http://www.drumk.com" target="_blank" class="normal">WinBoard</a> 2002<br>Copyright &copy; <a href="http://www.drumk.com" target="_blank" class="normal">www.drumk.com, Inc.</a> 2002.</font>
    </td>
  </tr>
</table>
<script language="JavaScript">
<!--
document.form.Username.focus();
//-->
</script>
</body>
</html>
<%
    If Right(Request.ServerVariables("HTTP_REFERER"), 10) <> "Logout.asp" Then Session("Tmp_LastVisited") = Request.ServerVariables("HTTP_REFERER") Else Session("Tmp_LastVisited") = Application("WB_URL") & "/ShowCategory.asp"
  End If
%>
<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<%
  Dim s

  If Session("Usr_Logon") Then
    s = Split(Request.Cookies(Application("COOKIES") & "SESSION"), "A", 2)
    If UBound(s) = 1 Then
      If Len(s(0)) > 0 And IsNumeric(s(0)) Then
        Dim objConn, rstAcc
        Set objConn = Server.CreateObject("ADODB.Connection")
        objConn.ConnectionTimeout = Application("TX_Timeout")
        objConn.Open Application("ConnectionString")
        objConn.Execute "DELETE FROM [Session] WHERE [SID] = " & s(0) & " AND [Hash] = '" & s(1) & "'"
        objConn.Close
        Set objConn = Nothing
      End If
    End If
    Session("Usr_Logon") = False
    Session("Usr_Username") = ""
    Response.Cookies(Application("COOKIES") & "SESSION").Expires = CDate("1980-1-1")
  End If
  'Response.Redirect Request.ServerVariables("HTTP_REFERER")
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index</a> / </b></font></td>
    <td nowrap></td>
  </tr>
</table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="1" class="border">
  <tr>
    <td>
      <table width="100%" cellspacing="1" cellpadding="4" border="0">

        <tr class="category">
          <td><font class="category">Logout</font></td>
        </tr>
        <tr class="body">
          <td>
            <table width="100%" cellspacing="0" cellpadding="2">
              <tr>
                <td colspan="3"><font class="body">You have been logged out.</font></td>
              </tr>
              <tr>
                <td colspan="3"><font class="body">&nbsp;</font></td>
              </tr>
              <tr>
                <td colspan="3"><font class="body"><a href="<% = Application("WB_URL") %>/ShowCategory.asp">Back to index.</a></font></td>
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
      <font class="sub-normal">Powered by <a href="http://www.drumk.com" target="_blank" class="normal">WinBoard</a> 2002<br>Copyright &copy; <a href="http://www.drumk.com" target="_blank" class="normal">www.drumk.com, Inc.</a> 2002.</font>
    </td>
  </tr>
</table>
</body>
</html>
<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/Footer.asp"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<%
  Dim objConn, iBID, iCID, sBTitle, sCTitle, i, j, bValidPara, dNow, rst, iErr, sErr, iTID, iPID, bWBCodes, bHTMLTags
  
  dNow = Now
%>
<!-- #include virtual = "/WinBoard/Private/ProcessBID.asp"  -->
<%
  iTID = Request.QueryString("TID")
  If Len(iTID) > 0 Then
    If Not IsNumeric(iTID) Then
      Response.Write "Error"
      Response.End
    End If
  Else
    iTID = -1
  End If

  iPID = Request.QueryString("PID")
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

  If iTID <> -1 Then
    If Len(Session("Tmp_Subject")) = 0 Then
      rst.Open "SELECT [Subject] FROM [b" & iBID & "] WHERE [PID] = " & iTID, objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
      If Not rst.EOF Then Session("Tmp_Subject") = "Re:" & rst("Subject").Value
      rst.Close
    End If
    If Not (iPID = -1 Or Len(Session("Tmp_Message")) > 0) Then
      rst.Open "SELECT [UNickname], [LastUpdateDate], [BodySrc] FROM [b" & iBID & "] WHERE [PID] = " & iPID, objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
      If Not rst.EOF Then Session("Tmp_Message") = "[quote][b]" & rst("UNickname").Value & FormatDate(rst("LastUpdateDate").Value, " (dd-MM-yyyy hh:mm):[/b]") & vbCrLf & Server.HTMLEncode(rst("BodySrc")) & "[/quote]" & vbCrLf & vbCrLf
      rst.Close
    End If
  End If

  rst.Open "SELECT [WBCodes], [HTMLTags] FROM [Boards] WHERE [BID] = " & iBID, objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
  bWBCodes = rst("WBCodes")
  bHTMLTags = rst("HTMLTags")
  rst.Close

  If Session("Usr_Logon") Then
    rst.Open "SELECT * FROM [Accounts] WHERE [Username] = '" & Session("Usr_Username") & "'", objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
    If rst.EOF Then
      Response.Write "Error"
      Response.End
    End If
  End If

  iErr = Session("Tmp_Err")
  If Session("Tmp_Err") <> 0 Then
    Session("Tmp_Err") = 0
    Select Case iErr
      Case 1:
        sErr = "Nickname"
      Case 2:
        sErr = "Email"
      Case 3:
        sErr = "Subject"
      Case 4:
        sErr = "Message"
    End Select
  End If
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<script language="JavaScript" type="text/javascript">
<!--
  function PopUp ( url, name, width, height, center, resize, scroll, posleft, postop ) {
    if (posleft != 0) { x = posleft }
    if (postop  != 0) { y = postop  }
    if ((parseInt (navigator.appVersion) >= 4 ) && (center)) {
      X = (screen.width  - width ) / 2;
      Y = (screen.height - height) / 2;
    }

    if (scroll != 0) { scroll = 1 }

    var extra = 'width=' + width + ', height=' + height + ', top=' + Y + ', left=' + X + ', resizable=' + resize + ', scrollbars=' + scroll + ', location=no, directories=no, status=no, menubar=no, toolbar=no';
    window.open( url, name, extra );
  }
// -->
</script>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index</a> / <a href="<% = Application("WB_URL") %>/ShowBoard.asp?CID=<% = iCID %>" class="normal"><% = sCTitle %></a> / <a href="<% = Application("WB_URL") %>/ShowTopic.asp?BID=<% = iBID %>" class="normal"><% = sBTitle %></a></b></font></td>
    <td nowrap></td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="0"><tr><td nowrap><form action="DoPost.asp" name="form" method="post"><input type="hidden" name="BID" value="<% = iBID %>"><% If iTID <> -1 Then Response.Write "<input type=""hidden"" name=""TID"" value=""" & iTID & """>" : If iPID <> -1 Then Response.Write "<input type=""hidden"" name=""PID"" value=""" & iPID & """>"%></td></tr></table>
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
                <td colspan="3"><font class="body">Please fill out all required (<font class="required">*</font>) fields.</font></td>
              </tr>
<% If iErr <> 0 Then %>
              <tr>
                <td colspan="3"><font class="body">Error:<br>&nbsp;&nbsp;<font class="error-body">You forgot to fill in the "<% = sErr %>" field.</font><br>Please make any changes and try again!<p>Please fill out all required (<font class="required">*</font>) fields.</font></td>
              </tr>
<% End If %>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Nickname</font>&nbsp;<% If Not Session("Usr_Logon") Then %><font class="required">*</font><% End If %></td>
<% If Session("Usr_Logon") Then %>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = rst("Nickname").Value %></font></td>
<% Else
     i = Request.Cookies(Application("COOKIES") & "NICKNAME")
     If Len(i) > 0 Then i = " value=""" & i & """" %>
                <td width="60%" valign="top" nowrap><input type="text" name="FORM_NICKNAME" size="45" maxlength="128" class="textbox"<% = i %></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-textbox">enter your nickname.</font></td></tr></table></td>
<% End If %>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Email</font>&nbsp;<% If Not Session("Usr_Logon") Then %><font class="required">*</font><% End If %></td>
<% If Session("Usr_Logon") Then %>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = rst("Email").Value %></font></td>
<% Else
     i = Request.Cookies(Application("COOKIES") & "EMAIL")
     If Len(i) > 0 Then i = " value=""" & i & """" %>
                <td width="60%" valign="top" nowrap><input type="text" name="FORM_EMAIL" size="45" maxlength="128" class="textbox"<% = i %></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-textbox">enter your email address.</font></td></tr></table></td>
<% End If
   i = Session("Tmp_Subject")
   If Len(i) > 0 Then i = " value=""" & i & """" : Session("Tmp_Subject") = "" %>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">To</font>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><font class="body"><% = sCTitle & " / " & sBTitle %></font></td>
              </tr>
              <tr>
                <td width="150" valign="top" nowrap><font class="textbox">Subject</font>&nbsp;<font class="required">*</font></td>
                <td width="60%" valign="top" nowrap><input type="text" name="FORM_SUBJECT" size="45" maxlength="128" class="textbox"<% = i %>></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-textbox">write the subject of your new topic.</font></td></tr></table></td>
              </tr>
              <tr>
                <% i = Session("Tmp_Message") : If Len(i) > 0 Then Session("Tmp_Message") = "" %><td width="150" valign="top" nowrap><font class="textarea">Message</font>&nbsp;<font class="required">*</font><br><font class="sub-textarea"><p><a href="javascript:PopUp ('Help.asp?ID=0', 'WB2KHELP', 450, 300, 1, 1)">UltraBoard Codes</a>: <% If bWBCodes Then Response.Write "on" Else Response.Write "off" %><br><a href="javascript:PopUp ('Help.asp?ID=1', 'WB2KHELP', 450, 300, 1, 1)">HTML Tags</a>: <% If bHTMLTags Then Response.Write "on" Else Response.Write "off" %><p><a href="javascript:PopUp ('Help.asp?ID=2', 'WB2KHELP', 450, 300, 1, 1)">Emotions Legend</a></font></td>
                <td width="60%" valign="top" nowrap><textarea name="FORM_MESSAGE" cols="45" rows="10" wrap="soft" class="textarea"><% = i %></textarea></td>
                <td width="40%" valign="top"><table width="100%" cellspacing="0" cellpadding="0" border="0"><tr><td><font class="sub-textarea">write your message here.</font></td></tr></table></td>
              </tr>
<% If Session("Usr_Logon") Then
     If Not IsNull(rst("Signature")) Then %>
              <tr>
                <td width="150" valign="top" nowrap>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><table border="0" cellspacing="0" cellpadding="0"><tr><td><input type="checkbox" name="FORM_SIGNATURE" class="checkbox"<% If Request.Cookies(Application("COOKIES") & "SIGNATURE") = "1" Then Response.Write " checked"%>></td><td width="100%"><font class="body">Include your signature in this post?</font></td></tr></table></td>
              </tr>
<%   End If
   End If %>
              <tr>
                <td width="150" valign="top" nowrap>&nbsp;</td>
                <td valign="top" width="100%" colspan="2"><table border="0" cellspacing="0" cellpadding="0"><tr><td><input type="checkbox" name="FORM_PREVIEW" value="1" class="checkbox"></td><td width="100%"><font class="body">Preview your post?</font></td></tr></table></td>
              </tr>
            </table>
            <table border="0" width="100%" cellspacing="0" cellpadding="2">
              <tr>
                <td width="150" valign="top" nowrap>&nbsp;</td>
                <td width="60%" nowrap><input type="submit" value="Post" class="button"> <input type="reset" value="Cancel" class="button"></td>
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
      <font class="sub-normal">Powered by <a href="http://www.drumk.com" target="_blank">WinBoard</a> 2002,<br>Copyright &copy; <a href="http://www.drumk.com" target="_blank">www.drumk.com, Inc.</a> 2002.</font>
    </td>
  </tr>
</table>
</body>
</html>
<%
  If iPID <> -1 Then i = "&PID=" & iPID Else i = ""
  If iTID <> -1 Then Response.Write "<iframe frameborder=""1"" width=""100%"" marginwidth=""0"" marginheight=""0"" height=""300"" scrolling=""yes"" src=""" & Application("WB_URL") & "/ReadPost.asp?BID=" & iBID & "&TID=" & iTID & i & """></frame>"

  If rst.State <> adStateClosed Then rst.Close
  Set rst = Nothing
  objConn.Close
  Set objConn = Nothing
%>
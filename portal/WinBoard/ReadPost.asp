<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<!-- #include virtual = "/WinBoard/Private/Footer.asp"  -->
<%
  Dim objConn, rstPost, iBID, iCID, sBTitle, sCTitle, iTID, dLastVisited, i, j, dNow, s1, s2, bValidPara, bRegUsr, sLT, sSubject, iPage

  Set objConn = Server.CreateObject("ADODB.Connection")
  objConn.ConnectionTimeout = Application("TX_Timeout")
  objConn.Open Application("ConnectionString")
%>
<!-- #include virtual = "/WinBoard/Private/ProcessBID.asp"  -->
<%
  dNow = Now
  dLastVisited = Request.Cookies(Application("COOKIES") & "BLASTVISITED")(CStr(iBID))
  If Len(dLastVisited) > 0 And IsNumeric(dLastVisited) Then dLastVisited = CDate(dLastVisited) Else dLastVisited = Null

  iTID = Request.QueryString("TID")
  If Len(iTID) = 0 Or Not IsNumeric(iTID) Then
    Response.Write "Error"
    Response.End
  End If

  iPage = Request.QueryString("P")
  If Len(iPage) > 0 And Not IsNumeric(iPage) Then
    Response.Write "Error"
    Response.End
  End If
  iPage = CInt(iPage)
  s1 = Request.Cookies(Application("COOKIES") & "TPAGE")(CStr(iBID) & "A" & CStr(iTID))
  If iPage = 0 And Len(s1) > 0 And IsNumeric(s1) Then iPage = -CInt(s1)
  If iPage = 0 Then iPage = 1

  Set rstPost = Server.CreateObject("ADODB.RecordSet")
  rstPost.CursorLocation = adUseClient
  rstPost.Open "SELECT [Subject], [Replies] FROM [b" & iBID & "] WHERE [PID] = " & iTID, objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
  If rstPost.EOF Then
    Response.Write "Error"
    Response.End
  End If
  sSubject = rstPost("Subject").Value
  s1 = rstPost("Replies").Value
  rstPost.Close

  Response.Cookies(Application("COOKIES") & "BLASTVISITED")(CStr(iBID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "BLASTVISITED").Expires = DateAdd("m", 1, dNow)

  Response.Cookies(Application("COOKIES") & "CLASTVISITED")(CStr(iCID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "CLASTVISITED").Expires = DateAdd("m", 1, dNow)
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index </a> / <a href="<% = Application("WB_URL") %>/ShowBoard.asp?CID=<% = iCID %>" class="normal"><% = sCTitle %></a> / <a href="<% = Application("WB_URL") %>/ShowTopic.asp?BID=<% = iBID %>" class="normal"><% = sBTitle %></a></b></font></td>
    <td nowrap></td>
  </tr>
</table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="1" class="border">
  <tr>
    <td>
      <table border="0" width="100%" cellspacing="1" cellpadding="4">
        <tr class="header">
          <td width="20%" nowrap><font class="header"><b>author</b></font></td>
          <td width="80%"><font class="header"><b>message</b></font></td>
        </tr>
        <tr class="category">
          <td colspan="2">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td width="100%"><font class="category"><b><font class="category"><b><% = sSubject %></b></font></b></font></td>
                <td align="right" nowrap>
                  <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>"><img src="<% = Application("IMAGE_URL") %>/Default/post.gif" width="52" height="20" border="0" alt="Post a new topic"></a></td>
                      <td><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="4" height="20" border="0" alt=""></td>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>&TID=<% = iTID %>"><img src="<% = Application("IMAGE_URL") %>/Default/reply.gif" width="57" height="20" border="0" alt="Reply to this Topic"></a></td>
                      <td><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="4" height="20" border="0" alt=""></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
<%
  rstPost.Open "SELECT [a].[PID], [a].[Subject], [a].[Username], [a].[UEmail], [a].[UNickname], [a].[Replies], [a].[PostDate], [a].[BodyHTML], [b].[Level], [b].[Nickname], [b].[TotalPosts], [b].[RegisteredDate], [b].[ICQ], [c].[Title] FROM [b" & iBID & "] [a] LEFT JOIN [Accounts] [b] ON [a].[Username] = [b].[Username] LEFT JOIN [Groups] [c] ON [b].[GID] = [c].[GID] WHERE [PID] IN (" & iTID & s1 & ")", objConn, adOpenForwardOnly, adLockReadOnly, adCmdText
  rstPost.PageSize = Application("POST_PER_PAGE")

  i = Abs(iPage)
  If i < 1 Or i > rstPost.PageCount Then
    If iPage < 0 And rstPost.PageCount > 0 Then
      i = 1
    Else
      Response.Write "Error"
      Response.End
    End If
  End If
  iPage = i

  s1 = Split(Request.Cookies(Application("COOKIES") & "TPAGE"), "&", -1)
  s2 = Split(Request.Cookies(Application("COOKIES") & "TTIME"), "&", -1)
  Response.Cookies(Application("COOKIES") & "TPAGE") = ""
  Response.Cookies(Application("COOKIES") & "TTIME") = ""
  For i = 0 To UBound(s2)
    s2(i) = Replace(s2(i), "%2E", ".")
    j = InStr(s2(i), "=") + 1
    If DateAdd("d", -1, dLastVisited) < CDate(Mid(s2(i), j)) Then
      Response.Cookies(Application("COOKIES") & "TTIME")(Left(s2(i), j - 2)) = Mid(s2(i), j)
      j = InStr(s2(i), "=") + 1
      Response.Cookies(Application("COOKIES") & "TPAGE")(Left(s1(i), j - 2)) = Mid(s1(i), j)
    End If
  Next
  Response.Cookies(Application("COOKIES") & "TPAGE")(CStr(iBID) & "A" & CStr(iTID)) = iPage
  Response.Cookies(Application("COOKIES") & "TTIME")(CStr(iBID) & "A" & CStr(iTID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "TPAGE").Expires = DateAdd("d", 14, dNow)
  Response.Cookies(Application("COOKIES") & "TTIME").Expires = DateAdd("d", 14, dNow)

  rstPost.AbsolutePage = iPage

  For i = 1 To rstPost.PageSize
    bRegUsr = Not IsNull(rstPost("Username"))
    If bRegUsr Then sLT = Application("LEVEL_" & CStr(rstPost("Level").Value))
%>
        <tr class="row">
          <td class="odd" rowspan="2" valign="top" width="20%" nowrap><% If bRegUsr Then %><table border="0" cellspacing="0" cellpadding="0"><tr><td><font class="row"><b><% = rstPost("Nickname") %></b></font></td></tr></table><font class="sub-row"><% = sLT %><br>in <% = rstPost("Title").Value %></font><br><a href="<% = Application("WB_URL") %>/UserProfile.asp?UID=<% = rstPost("Username") %>" target="_blank"><img src="<% = Application("IMAGE_URL") %>/Default/profile.gif" align="absmiddle" vspace="10" border="0" alt="View this member's profile"></a><% If Not IsNull(rstPost("ICQ")) Then %><img src="http://www.drumk.com/UltraBoard/Public/Images/Default/blank.gif" width="6" height="10" border="0" align="absmiddle"><a href="<% = Application("WB_URL") %>/ICQ.asp?ICQ=<% = rstPost("ICQ") %>"><img src="http://web.icq.com/whitepages/online?icq=<% = rstPost("ICQ") %>&img=5" border="0" align="absmiddle" alt="<% = rstPost("ICQ") %>" vspace="10"></a><% End If %><br><font class="sub-row">posts: <% = rstPost("TotalPosts") %></font><br><font class="sub-row">since: <% = FormatDate(rstPost("RegisteredDate").Value, "dd-MM-yyyy") %></font><% Else %><font class="row"><b><% = rstPost("UNickname") %></b></font><br><a href="mailto:<% = rstPost("UEmail") %>"><img src="<% = Application("IMAGE_URL") %>/Default/email.gif" align="absmiddle" vspace="3" alt="" border="0"></a><% End If %></td>
          <td class="subject" width="80%">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td width="100%"><font class="subject"><% = rstPost("Subject") %></font></td>
                <td align="right" nowrap>
                  <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>&TID=<% = iTID %>&PID=<% = rstPost("PID") %>"><img src="<% = Application("IMAGE_URL") %>/Default/reply_quote.gif" width="104" height="20" border="0" alt="Reply to this topic with quote"></a></td>
                      <td><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="4" height="20" border="0" alt=""></td>
                      <td><a href="<% = Application("WB_URL") %>/ModifyPost.asp?BID=<% = iBID %>&TID=<% = iTID %>&PID=<% = rstPost("PID") %>"><img src="<% = Application("IMAGE_URL") %>/Default/edit.gif" width="63" height="20" border="0" alt="Modify your message"></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr class="row">
          <td class="body" valign="top">
            <table border="0" height="100" width="100%" cellspacing="2" cellpadding="2">
              <tr>
                <td valign="top"><font class="body"><% = rstPost("BodyHTML") %></font></td>
              </tr>
            </table>
            <table border="0" width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><font class="sub-body"><b>Date:</b> <% = FormatDate(rstPost("PostDate").Value, "dd-MM-yyyy on hh:mm:ss") %></font></td>
              </tr>
            </table>
          </td>
        </tr>
<%
    rstPost.MoveNext
    If rstPost.EOF Then Exit For
  Next
%>
        <tr class="category">
          <td colspan="2">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td width="100%"><font class="category"><b><font class="category"><b><% = sSubject %></b></font></b></font></td>
                <td align="right" nowrap>
                  <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>"><img src="<% = Application("IMAGE_URL") %>/Default/post.gif" width="52" height="20" border="0" alt="Post a new topic"></a></td>
                      <td><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="4" height="20" border="0" alt=""></td>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>&TID=<% = iTID %>"><img src="<% = Application("IMAGE_URL") %>/Default/reply.gif" width="57" height="20" border="0" alt="Reply to this Topic"></a></td>
                      <td><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="4" height="20" border="0" alt=""></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr class="status">
          <td colspan="2">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><font class="status"><% If Session("Usr_Logon") And Not IsNull(dLastVisited) Then Response.Write "You last visited: " & FormatDate(dLastVisited, "dd-MM-yyyy hh:mm") %> All times are GMT +8.</font></td>
                <td align="right"><font class="status"><% If iPage > 1 Then Response.Write "<a href=""" & Application("WB_URL") & "/ReadPost.asp?BID=" & iBID & "&TID=" & iTID & "&P=" & (iPage - 1) & """>< Prev. Page</a>" Else Response.Write "< Prev. Page" %> | P.<% = iPage %> | <% If rstPost.PageCount > iPage Then Response.Write "<a href=""" & Application("WB_URL") & "/ReadPost.asp?BID=" & iBID & "&TID=" & iTID & "&P=" & (iPage + 1) & """>Next Page ></a>" Else Response.Write "Next Page >" %> </font></td>
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
      <% Footer "B", iBID %>
    </td>
  </tr>
</table>
</body>
</html>
<%
  rstPost.Close
  Set rstPost = Nothing

  objConn.Close
  Set objConn = Nothing
%>
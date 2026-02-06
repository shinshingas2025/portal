<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<!-- #include virtual = "/WinBoard/Private/Footer.asp"  -->
<% 
  Dim objConn, rstPost, iBID, iCID, sBTitle, sCTitle, dLastVisited, i, j, dNow, iDayPrune, sSQL, bValidPara, iPage

  Set objConn = Server.CreateObject("ADODB.Connection")
  objConn.ConnectionTimeout = Application("TX_Timeout")
  objConn.Open Application("ConnectionString")
%>
<!-- #include virtual = "/WinBoard/Private/ProcessBID.asp"  -->
<%
  dNow = Now
  iPage = Request.QueryString("P")

  If Len(iPage) > 0 And Not IsNumeric(iPage) Then
    Response.Write "Error"
    Response.End
  End If
  iPage = CInt(iPage)

  dLastVisited = Request.Cookies(Application("COOKIES") & "BLASTVISITED")(CStr(iBID))
  If Len(dLastVisited) > 0 And IsNumeric(dLastVisited) Then dLastVisited = CDate(dLastVisited) Else dLastVisited = Null

  iDayPrune = Request.Cookies(Application("COOKIES") & "BDAYPRUNE")(CStr(iBID))

  If iDayPrune <> "*" Then
    If Len(iDayPrune) = 0 Or Not IsNumeric(iDayPrune) Then
      iDayPrune = CInt(Application("DAY_PRUNE"))
      Response.Cookies(Application("COOKIES") & "BDAYPRUNE")(CStr(iBID)) = iDayPrune
      Response.Cookies(Application("COOKIES") & "BDAYPRUNE").Expires = DateAdd("m", 1, dNow)
    Else
      iDayPrune = CInt(iDayPrune)
    End If
  End If

  If IsObject(Session("Rst_Topic")) Then
    If Session("LastTopic") = iBID Then Set rstPost = Session("Rst_Topic")
    Set Session("Rst_Topic") = Nothing
    Session("Rst_Topic") = 0
    Session("LastTopic") = -1
  End If
  If iPage = 0 Or Not IsObject(rstPost) Then
    If iPage = 0 Then iPage = 1
    If IsObject(rstPost) Then
      If rstPost.State <> adStateClosed Then rstPost.Close
    Else
      Set rstPost = Server.CreateObject("ADODB.RecordSet")
      rstPost.CursorLocation = adUseClient
    End If
    sSQL = "SELECT * FROM [b" & iBID & "] WHERE [Root] = 0"
    If iDayPrune <> "*" Then sSQL = sSQL & " AND DATEDIFF(day, [LastPostDate], '" & FormatDate(dNow, "yyyy-MM-dd hh:mm:ss") & "') <= " & iDayPrune
    rstPost.Open sSQL & " ORDER BY [LastPostDate] DESC", objConn, adOpenKeyset, adLockReadOnly, adCmdText
    rstPost.PageSize = Application("HEADLINES_PER_PAGE")
    Set rstPost.ActiveConnection = Nothing
    If rstPost.PageCount > 1 Then Set Session("Rst_Topic") = rstPost : Session("LastTopic") = iBID
  End If

  If iPage > rstPost.PageCount Or iPage < 0 Then
    If rstPost.PageCount > 0 Then
      Response.Write "Error"
      Response.End
    End If
  Else
    rstPost.AbsolutePage = iPage
  End If

  Response.Cookies(Application("COOKIES") & "BLASTVISITED")(CStr(iBID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "BLASTVISITED").Expires = DateAdd("m", 1, dNow)

  Response.Cookies(Application("COOKIES") & "CLASTVISITED")(CStr(iCID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "CLASTVISITED").Expires = DateAdd("m", 1, dNow)
%>
<!-- #include virtual = "/WinBoard/Private/Header.asp"  -->
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="6">
  <tr>
    <td width="100%"><font class="normal"><b><a href="<% = Application("WB_URL") %>/ShowCategory.asp" class="normal">Index</a> / <a href="<% = Application("WB_URL") %>/ShowBoard.asp?CID=<% = iCID %>" class="normal"><% = sCTitle %></a></b></font></td>
    <td nowrap><font class="sub-normal">Show topics</font><br>
      <table border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td nowrap>
            <form name="DayPruneForm" method="post" action="<% = Application("WB_URL") %>/DayPrune.asp"><input type="hidden" name="BID" value="<% = iBID %>">
          </td>
        </tr>
        <tr>
          <td>
            <select name="DayPrune">
              <option value="1">from yesterday</option>
              <option value="2">from last 2 days</option>
              <option value="3">from last 3 days</option>
              <option value="7">from last 7 days</option>
              <option value="14">from last 14 days</option>
              <option value="30">from last 30 days</option>
              <option value="45">from last 45 days</option>
              <option value="60">from last 60 days</option>
              <option value="90">from last 90 days</option>
              <option value="180">from last 180 days</option>
              <option value="360">from last 360 days</option>
              <option value="*">from all the time</option>
            </select>&nbsp;<input type="submit" value="Show">
            <script language="JavaScript">
            <!--
              for (var i = 0; i < document.DayPruneForm.DayPrune.length; i++) {
                if (document.DayPruneForm.DayPrune.options[i].value == '<% = iDayPrune %>') {
                  document.DayPruneForm.DayPrune.options[i].selected = true;
                }
              }
            // -->
            </script>
          </td>
        </tr>
        <tr>
          <td nowrap></form></td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table border="0" width="100%" align="Center" cellspacing="0" cellpadding="1" class="border">
  <tr>
    <td>
      <table border="0" width="100%" cellspacing="1" cellpadding="4">
        <tr class="header">
          <td width="20" nowrap><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="20" height="1" border="0"></td>
          <td width="85%"><font class="header"><b>subject</b></font></td>
          <td width="15%"><font class="header"><b>author</b></font></td>
          <td align="center" nowrap><font class="header"><b>replies</b></font></td>
          <td nowrap><font class="header"><b>last updated</b></font></td>
        </tr>
        <tr class="category">
          <td colspan="7">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td><font class="category"><b><font class="category"><b><% = sBTitle %></b></font></b></font></td>
                <td align="right">
                  <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>"><img src="<% = Application("IMAGE_URL") %>/Default/post.gif" width=52 height=20 border=0></a></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
<%
  If rstPost.PageCount > 0 Then
    Dim sImg, sBold, sBold_, bHot
    For i = 1 To rstPost.PageSize
      bHot = rstPost("RepliesCnt").Value >= Application("HOT")
      Dim dTTime
      dTTime = Request.Cookies(Application("COOKIES") & "TTIME")(CStr(iBID) & "A" & rstPost("PID").Value)
      If Len(dTTime) > 0 And IsNumeric(dTTime) Then dTTime = CDate(dTTime) < rstPost("LastPostDate").Value Else dTTime = True
      If IsNull(dLastVisited) Or (DateAdd("d", -1, dLastVisited) < rstPost("LastPostDate").Value And dTTime) Then
        sImg = "1"
        sBold = "<b>"
        sBold_ = "</b>"
      Else
        sImg = "0"
        sBold = ""
        sBold_ = ""
      End If
      If bHot Then sImg = sImg & "1" Else sImg = sImg & "0"
%>
        <tr class="row">
          <td class="odd" align="center" width="20" nowrap><img src="<% = Application("IMAGE_URL") %>/Default/P<% = sImg %>0.gif" width="14" height="14" border="0" alt=""></td>
          <td class="even"><font class="row"><% = sBold %><a href="<% = Application("WB_URL") %>/ReadPost.asp?BID=<% = iBID %>&TID=<% = rstPost("PID") %>"><% = rstPost("Subject").Value %></a><% = sBold_ %></font></td>
          <td class="even"><font class="row"><% Response.Write sBold : If Not IsNull(rstPost("Username")) Then Response.Write "<a href=" & Application("WB_URL") & "/UserProfile.asp?UID=" & rstPost("Username").Value & ">" & rstPost("UNickname").Value & "</a>" Else Response.Write rstPost("UNickname").Value : Response.Write sBold_ %></font></td>
          <td class="odd" align="center" nowrap><font class="row"><% If bHot Then Response.Write "<b>"%><% = rstPost("RepliesCnt").Value %><% If bHot Then Response.Write "</b>"%></font></td>
          <td class="odd" nowrap><font class="row"><% = sBold %><% = FormatDate(rstPost("LastPostDate").Value, "dd-MM-yyyy hh:mm") %><% = sBold_ %></font></td>
        </tr>
<%
      rstPost.MoveNext
      If rstPost.EOF Then Exit For
    Next
  End If
%>
        <tr class="category">
          <td colspan="7">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td><font class="category"><b><font class="category"><b><% = sBTitle %></b></font></b></font></td>
                <td align="right">
                  <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><a href="<% = Application("WB_URL") %>/Post.asp?BID=<% = iBID %>"><img src="<% = Application("IMAGE_URL") %>/Default/post.gif" width=52 height=20 border=0></a></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr class="status">
          <td colspan="7">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><font class="status"><% If Session("Usr_Logon") And Not IsNull(dLastVisited) Then Response.Write "You last visited: " & FormatDate(dLastVisited, "dd-MM-yyyy hh:mm") %> All times are GMT +8.</font></td>
                <td align="right"><font class="status"><% If iPage > 2 Then Response.Write "<a href=""" & Application("WB_URL") & "/ShowTopic.asp?BID=" & iBID & "&P=" & (iPage - 1) & """>< Prev. Page</a>" Else If iPage = 2 Then Response.Write "<a href=""" & Application("WB_URL") & "/ShowTopic.asp?BID=" & iBID & """>< Prev. Page</a>" Else Response.Write "< Prev. Page" %> | P.<% = iPage %> | <% If rstPost.PageCount > 1 And rstPost.PageCount > iPage Then Response.Write "<a href=""" & Application("WB_URL") & "/ShowTopic.asp?BID=" & iBID & "&P=" & (iPage + 1) & """>Next Page ></a>" Else Response.Write "Next Page >" %> </font></td>
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
    <td valign="top">
      <table border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top"><img src="<% = Application("IMAGE_URL") %>/Default/P100.gif" width="14" height="14" border="0" alt="">&nbsp;</td>
          <td><font class="normal"><b>new posts since your last visit.</b></font></td>
        </tr>
        <tr>
          <td valign="top"><img src="<% = Application("IMAGE_URL") %>/Default/P000.gif" width="14" height="14" border="0" alt="">&nbsp;</td>
          <td><font class="normal">no new posts since your last visit.</font></td>
        </tr>
        <tr>
          <td valign="top"><img src="<% = Application("IMAGE_URL") %>/Default/hot.gif" width="14" height="14" border="0" alt="">&nbsp;</td>
          <td><font class="normal"><b>most replied topic. (more than 10 replies)</b></font></td>
        </tr>
      </table>
    </td>
    <td align="right" valign="top">
      <% Footer "B", iBID %>
    </td>
  </tr>
</table>
</body>
</html>
<%
  If rstPost.PageCount <= 1 Then rstPost.Close
  Set rstPost = Nothing

  objConn.Close
  Set objConn = Nothing
%>
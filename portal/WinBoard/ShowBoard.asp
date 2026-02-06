<%@ Language = VBScript %>
<% Option Explicit
   Response.CacheControl = "no-cache"
   Response.AddHeader "Pragma", "no-cache"
   Response.Expires = -1 %>
<!-- #include virtual = "/WinBoard/Private/adovbs.inc"  -->
<!-- #include virtual = "/WinBoard/Private/Footer.asp"  -->
<!-- #include virtual = "/WinBoard/Private/FormatDate.asp"  -->
<%
  Dim objConn, rstBoard, dBoardLV, dLV, iCID, i, bVal, dNow

  dNow = Now
  dLV = DateSerial(1980, 1, 1)

  iCID = Request.QueryString("CID")
  If Len(iCID) = 0 Or Not IsNumeric(iCID) Then
    Response.Write "Error"
    Response.End
  End If
  iCID = CInt(iCID)

  For i = 0 To UBound(Application("Categories"), 2)
    bVal = Application("Categories")(0, i) = iCID
    If bVal Then Exit For
  Next

  If Not bVal Then
    Response.Write "Error"
    Response.End
  End If

  Set objConn = Server.CreateObject("ADODB.Connection")
  objConn.ConnectionTimeout = Application("TX_Timeout")
  objConn.Open Application("ConnectionString")

  Set rstBoard = Server.CreateObject("ADODB.RecordSet")
  rstBoard.CursorLocation = adUseClient

  Response.Cookies(Application("COOKIES") & "CLASTVISITED")(CStr(iCID)) = CDbl(dNow)
  Response.Cookies(Application("COOKIES") & "CLASTVISITED").Expires = DateAdd("m", 1, dNow)
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
      <table border="0" width="100%" cellspacing="1" cellpadding="4">
        <tr class="header">
          <td width="30" nowrap><img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="30" height="5" border="0"></td>
          <td width="100%"><font class="header"><b>board name</b></font></td>
          <td width="50" align="center" nowrap><font class="header"><b>topics</b></font></td>
          <td width="50" align="center" nowrap><font class="header"><b>posts</b></font></td>
          <td width="120" nowrap><font class="header"><b>last updated</b></font></td>
        </tr>
        <tr class="category">
          <td colspan="5"><font class="category"><b><% = Application("Categories")(1, i) %></b></font></td>
        </tr>
<%
  rstBoard.Open "SELECT [BID], [Title], [Description], [TotalPosts], [TotalTopics], [LastUpdateDate] FROM [Boards] WHERE [Category] = " & iCID & " ORDER BY [Position]", objConn, adOpenKeyset, adLockReadOnly, adCmdText
  While Not rstBoard.EOF
    dBoardLV = Request.Cookies(Application("COOKIES") & "BLASTVISITED")(CStr(rstBoard("BID")))
    If Len(dBoardLV) > 0 And IsNumeric(dBoardLV) And Not IsNull(rstBoard("LastUpdateDate")) Then
      dBoardLV = CDate(dBoardLV)
      If dBoardLV > dLV Then dLV = dBoardLV
      If dBoardLV > rstBoard("LastUpdateDate").Value Then dBoardLV = Null
    Else
      dBoardLV = Null
    End If
%>
        <tr>
          <td class="odd" align="center" nowrap><img src="<% = Application("IMAGE_URL") %>/Default/F<% If IsNull(dBoardLV) Then Response.Write "0" Else Response.Write "1" %>.gif" width="16" height="16" border="0" align="absmiddle"></td>
          <td class="even" valign="top"><font class="row"><b><a href="<% = Application("WB_URL") %>/ShowTopic.asp?BID=<% = rstBoard("BID") %>"><% = rstBoard("Title") %></a></b><br><font class="sub-row"><% = rstBoard("Description") %></font></font></td>
          <td class="odd" valign="top" nowrap><font class="row"><% = rstBoard("TotalTopics") %></font></td>
          <td class="odd" valign="top" nowrap><font class="row"><% = rstBoard("TotalPosts") %></font></td>
          <td class="odd" valign="top" nowrap><font class="row"><% If Not IsNull(rstBoard("LastUpdateDate")) Then Response.Write FormatDate(rstBoard("LastUpdateDate").Value, "dd-MM-yyyy<br>") & "<font class=""sub-row"">" & FormatDate(rstBoard("LastUpdateDate").Value, "hh:mm</font>") %></font></td>
        </tr>
<%
    rstBoard.MoveNext
  WEnd
%>
        <tr class="status">
          <td colspan="5"><font class="status"><% If Session("Usr_Logon") And Not IsNull(dLV) Then Response.Write "You last visited: " & FormatDate(dLV, "dd-MM-yyyy hh:mm") %> All times are GMT +8.</font></td>
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
          <td valign="top"><img src="<% = Application("IMAGE_URL") %>/Default/F1.gif" width="16" height="16" border="0" alt="">&nbsp;</td>
          <td><font class="normal">new posts since your last visit.</font></td>
        </tr>
        <tr>
          <td valign="top"><img src="<% = Application("IMAGE_URL") %>/Default/F0.gif" width="16" height="16" border="0" alt="">&nbsp;</td>
          <td><font class="normal">no new posts since your last visit.</font></td>
        </tr>
       </table>
    </td>
    <td align="right" valign="top">
      <% Footer "", -1 %>
    </td>
  </tr>
</table>
</body>
</html>
<%
  rstBoard.Close
  Set rstBoard = Nothing
  objConn.Close
  Set objConn = Nothing
%>
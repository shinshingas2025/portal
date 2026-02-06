<%@ Language = VBScript %>
<%
  Option Explicit
  Dim iDayPrune, iBID, bNum, dNow

  dNow = Now
  iBID = Request.Form("BID")
  If Len(iBID) > 0 And IsNumeric(iBID) Then
    iDayPrune = Request.Form("DayPrune")
    bNum = IsNumeric(iDayPrune)
    If (Len(iDayPrune) > 0 And bNum) Or iDayPrune = "*" Then
      If bNum Then
        Select Case CInt(iDayPrune)
          Case 1, 2, 3, 7, 14, 30, 45, 60, 90, 180, 360
          Case Else
            iDayPrune = 30
        End Select
      End If
      Response.Cookies(Application("COOKIES") & "BDAYPRUNE")(iBID) = iDayPrune
      Response.Cookies(Application("COOKIES") & "BDAYPRUNE").Expires = DateAdd("m", 1, dNow)
      Response.Redirect Application("WB_URL") & "/ShowTopic.asp?BID=" & Request.Form("BID")
    End If
  End If

  Session("Ack_Msg") = "Invalid board or day prune value."
  Session("Ack_BtnCaption") = "Home"
  Session("Ack_BtnCmd") = "location.replace('" & Application("WB_URL") & "/ShowCategory.asp');"
  Response.Redirect Application("WB_URL") & "/Ack.asp"
%>

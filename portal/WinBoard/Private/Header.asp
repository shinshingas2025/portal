<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Final//EN">
<html>
<head>
<title><% = Application("WINBOARD_TITLE") %></title>
<meta name="GENERATOR" content="WinBoard 0.0">
<meta http-equiv="Content-Type" content="text/html; charset=big5">
<link type="text/css" href="<% = Application("HTML_URL") %>/Default.css" rel="stylesheet">
</head>
<body marginwidth="5" marginheight="5" topmargin="5" leftmargin="5" >
<table width="100%" align="Center" cellspacing="0" cellpadding="1" class="border" border="0">
  <tr>
    <td>
      <table width="100%" cellspacing="1" cellpadding="4" border="0">
        <tr class="title">
          <td><font class="title"><% = Application("WINBOARD_TITLE") %></font><br>
          <font size="1" class="sub-title"><% = Application("WINBOARD_DESCRIPTION") %></font></td>
        </tr>
        <tr class="menu">
          <td>
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
              <tr>
                <td width="100%"><font class="menu"><% Dim s_ : If Session("Usr_Logon") Then s_ = "out" Else s_ = "in" %><a href="<% = Application("WB_URL") %>/Log<% = s_ %>.asp" class="menu">log<% = s_ %><% If Session("Usr_Logon") Then Response.Write " (" & Session("Usr_Username") & ")" %></a><% If Not Session("Usr_Logon") Then Response.Write " &#124; <a href=""" & Application("WB_URL") & "/Register.asp"" class=""menu"">register</a>" %> &#124; <% If Session("Usr_Logon") Then %><a href="<% = Application("WB_URL") %>/UserProfile.asp" class="menu">profile</a> &#124; <% End If %><a href="<% = Application("WB_URL") %>/Search.asp" class="menu">search</a> <a href="<% = Application("WB_URL") %>/Search.asp" class="menu">(today's posts)</a> &#124; <a href="<% = Application("WB_URL") %>/Help.htm" class="menu">help</a></font></td>
                <td align="right" nowrap><font class="menu"><a href="<% = Application("SITE_URL") %>" class="menu" target="_top">back to <% = Application("SITE_TITLE") %></a></font></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<%
  Function Footer(str, id)
    Dim i, bB, bC

    bB = str = "B"
    bC = str = "C"
%><script language="JavaScript" type="text/javascript">
        <!--
          function GoRedirect (){
            if (document.redirect.url.options[document.redirect.url.selectedIndex].value != "") {
              location = "<% = Application("WB_URL") %>/" + document.redirect.url.options[document.redirect.url.selectedIndex].value;
            }
          }
        // -->
      </script>
      <table border="0" cellspacing="0" cellpadding="0">
        <tr><td nowrap><form name="redirect"></td></tr>
        <tr>
          <td align="left"><font class="sub-normal">Go to:</font></td>
        </tr>
        <tr>
          <td><select name="url"><option>Go to...</option><option></option><% For i = 0 To UBound(Application("Categories"), 2) %><option <% If bC And id = Application("Categories")(0, i) Then Response.Write "selected " %>value="ShowBoard.asp?CID=<% = Application("Categories")(0, i) %>"><% = Application("Categories")(1, i) %></option><% Next %><option>======================</option><% For i = 0 To UBound(Application("Boards"), 2) %><option <% If bB And id = Application("Boards")(0, i) Then Response.Write "selected " %>value="ShowTopic.asp?BID=<% = Application("Boards")(0, i) %>"><% = Application("Boards")(1, i) %></option><% Next %></select>&nbsp;<input type="button" value="Go" onclick="GoRedirect()"></td>
        </tr>
        <tr><td nowrap></form></td></tr>
      </table>
      <img src="<% = Application("IMAGE_URL") %>/Default/blank.gif" width="10" height="6" border="0"><br>
      <font class="sub-normal">Powered by <a href="http://www.drumk.com" target="_blank">WinBoard</a> 2002,<br>Copyright &copy; <a href="http://www.drumk.com" target="_blank">www.drumk.com, Inc.</a> 2002.</font><% End Function %>
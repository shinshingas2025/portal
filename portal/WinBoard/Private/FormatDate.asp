<%
  Function LZeroPad(i, l)
    i = CStr(i)
    If Len(i) < l Then
      i = String(l - Len(i), "0") + i
    End If
    LZeroPad = i
  End Function

  Function FormatDate(d, s)
    FormatDate = Replace(Replace(Replace(Replace(Replace(Replace(s, "yyyy", LZeroPad(Year(d), 4)), "MM", LZeroPad(Month(d), 2)), "dd", LZeroPad(Day(d), 2)), "hh", LZeroPad(Hour(d), 2)), "mm", LZeroPad(Minute(d), 2)), "ss", LZeroPad(Second(d), 2))
  End Function
%>
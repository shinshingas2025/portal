Option Explicit
Const BackupPath = "C:\INETPUB\CGI-BIN\UltraBoard\Private\Backups\UB2K-1017394349"
Const ConnectionString = "Provider=sqloledb;Data Source=(local);Initial Catalog=WinBoard;User Id=sa;"
Const vbDirectory = 16
Const adOpenForwardOnly = 0
Const adLockOptimistic = 3
Const adCmdTable = &H0002
Const adEmpty = 0
Const adTinyInt = 16
Const adSmallInt = 2
Const adInteger = 3
Const adBigInt = 20
Const adUnsignedTinyInt = 17
Const adUnsignedSmallInt = 18
Const adUnsignedInt = 19
Const adUnsignedBigInt = 21
Const adSingle = 4
Const adDouble = 5
Const adCurrency = 6
Const adDecimal = 14
Const adNumeric = 131
Const adBoolean = 11
Const adError = 10
Const adUserDefined = 132
Const adVariant = 12
Const adIDispatch = 9
Const adIUnknown = 13
Const adGUID = 72
Const adDate = 7
Const adDBDate = 133
Const adDBTime = 134
Const adDBTimeStamp = 135
Const adBSTR = 8
Const adChar = 129
Const adVarChar = 200
Const adLongVarChar = 201
Const adWChar = 130
Const adVarWChar = 202
Const adLongVarWChar = 203
Const adBinary = 128
Const adVarBinary = 204
Const adLongVarBinary = 205
Const adChapter = 136
Const adFileTime = 64
Const adDBFileTime = 137
Const adPropVariant = 138
Const adVarNumeric = 139

Function IsInteger(s)
  Dim i, c

  For i = 1 To Len(s)
    c = Mid(s, i, 1)
    If c < "0" Or c > "9" Then IsInteger = False : Exit Function
  Next

  IsInteger = True
End Function

Sub RunBatch(oConn, sPathName, ss, sr)
  Dim oTS, oFSO, s, s2

  Set oFSO = CreateObject("Scripting.FileSystemObject")
  Set oTS = oFSO.OpenTextFile(sPathName, 1, False)
  s2 = ""
  While Not oTS.AtEndOfStream
    s = oTS.ReadLine
    If Not IsNull(ss) Then s = Replace(s, "#" & ss & "#", sr)
    Select Case s
      Case "BEGIN TRANSACTION"
        oConn.BeginTrans
      Case "GO"
        oConn.Execute s2
        s2 = ""
      Case "COMMIT"
        oConn.CommitTrans
      Case Else
        s2 = s2 + s
    End Select
  WEnd
  oTS.Close
  Set oTS = Nothing
  Set oFSO = Nothing
End Sub

Function ConvertMessages(sPath, sConnectionString)
  Dim oConn, rs , oRE, oFSO, oTS, s, oMatch, oMatches, i, s2, iItemTypes, sItemNames, sPK, oTS2, iNullness, sDIR, oFolders, oFolder

  Set oRE = CreateObject("VBScript.RegExp")

  For i = 1 To 29
    s = s & "(.*?)"
    If i < 29 Then s = s & "\|\^\|"
  Next

  oRE.Pattern = "^" & s & "$"
  oRE.IgnoreCase = False
  iItemTypes = Array(adInteger, adVarWChar, adVarChar, adVarWChar, adVarWChar, adEmpty, adEmpty, adInteger, adVarChar, adInteger, adEmpty, adDate, adEmpty, adEmpty, adDate, adEmpty, adEmpty, adDate, adEmpty, adInteger, adVarChar, adVarChar, adBoolean, adBoolean, adTinyInt, adBoolean, adBoolean, adBoolean, adInteger, adLongVarWChar, adLongVarWChar)
  sItemNames = Array("PID", "Subject", "Username", "UEmail", "UNickname", "", "", "Root", "Replies", "RepliesCnt", "", "PostDate", "", "", "LastPostDate", "", "", "LastUpdateDate", "", "TotalModified", "Host", "IP", "Notification", "Signature", "Symbol", "Approved", "ReadOnly", "Attachment", "Hits", "BodySrc", "BodyHTML")
  iNullness = Array(0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
  Set oConn = CreateObject("ADODB.Connection")
  oConn.Open sConnectionString
  Set oFSO = CreateObject("Scripting.FileSystemObject")
  Set rs = CreateObject("ADODB.RecordSet")

  Set oFolders = oFSO.GetFolder(sPath).SubFolders
  For Each oFolder In oFolders
    sDIR = LCase(oFolder.Name)
    If Left(sDIR, 1) = "b" And IsInteger(Mid(sDIR, 2)) Then
      RunBatch oConn, "b.sql", "b1", sDIR
      Set oTS = oFSO.OpenTextFile(sPath & "\" & sDIR & "\" & sDIR & ".export", 1, False)
      oTS.ReadLine
      rs.Open sDIR, oConn, adOpenForwardOnly, adLockOptimistic, adCmdTable
      Do While Not oTS.AtEndOfStream
        s = oTS.ReadLine
        Set oMatches = oRE.Execute(s)
        For Each oMatch In oMatches
          rs.AddNew
          sPK = oMatch.SubMatches(0)
          SPK = Left(sPK, Instr(sPK, "|") - 1)
          rs(sItemNames(0)) = CInt(sPK)
          For i = 1 To oMatch.SubMatches.Count - 1
            s = CStr(oMatch.SubMatches(i))
            If Len(s) = 0 And iNullness(i) = -1 Then s = Null
            Select Case iItemTypes(i)
              Case adInteger:
                rs(sItemNames(i)) = CInt(s)
              Case adVarWChar, adVarChar:
                rs(sItemNames(i)) = s
              Case adLongVarWChar:
                rs(sItemNames(i)).AppendChunk s
              Case adDate:
                s2 = CStr(oMatch.SubMatches(i + 1))
                rs(sItemNames(i)) = DateSerial(Mid(s, 7), Mid(s, 4, 2), Left(s, 2)) + TimeSerial(Left(s2, 2), Mid(s2, 4, 2), 0)
              Case adBoolean:
                rs(sItemNames(i)) = s = "1"
            End Select
          Next
          On Error Resume Next
          Set oTS2 = oFSO.OpenTextFile(sPath & "\" & sDIR & "\" & sPK & ".source.pl", 1, False)
          If Err.Number <> 0 Or oTS2.AtEndOfStream Then rs(sItemNames(29)) = "" : Err.Number = 0 Else rs(sItemNames(29)).AppendChunk oTS2.ReadAll
          oTS2.Close
          Set oTS2 = Nothing
          Set oTS2 = oFSO.OpenTextFile(sPath & "\" & sDIR & "\" & sPK & ".post.pl", 1, False)
          If Err.Number <> 0 Or oTS2.AtEndOfStream Then rs(sItemNames(30)) = "" : Err.Number = 0 Else rs(sItemNames(30)).AppendChunk oTS2.ReadAll
          oTS2.Close
          Set oTS2 = Nothing
          On Error Goto 0
          rs.Update
        Next
      Loop
      oTS.Close
      Set oTS = Nothing
      rs.Close
      RunBatch oConn, "b2.sql", "b1", sDIR
    End If
  Next
  Set oFolders = Nothing
  Set oRE = Nothing
  Set oFSO = Nothing
  Set rs = Nothing
  oConn.Close
  Set oConn = Nothing
End Function

Function ConvertAccounts(sPath, sConnectionString)
  Dim oConn, rs , oRE1, oRE2, oFSO, oTS1, oTS2, s, oMatch(1), oMatches(1), i, j, ii, s2, iItemTypes, sItemNames, sPK, iNullness

  Set oRE1 = CreateObject("VBScript.RegExp")
  Set oRE2 = CreateObject("VBScript.RegExp")

  s = ""
  For i = 1 To 24
    s = s & "(.*?)"
    If i < 24 Then s = s & "\|\^\|"
  Next
  oRE1.Pattern = "^" & s & "$"

  s = ""
  For i = 1 To 10
    s = s & "(.*?)"
    If i < 10 Then s = s & "\|\^\|"
  Next
  oRE2.Pattern = "^" & s & "$"

  oRE1.IgnoreCase = False
  oRE2.IgnoreCase = False

  iItemTypes = Array(adVarChar, adChar, adSmallInt, adSmallInt, adInteger, adVarWChar, adVarWChar, adVarWChar, adVarChar, adInteger, adEmpty, adDate, adEmpty, adEmpty, adDate, adEmpty, adEmpty, adDate, adEmpty, adVarChar, adVarChar, adBoolean, adBoolean, adVarChar,  adEmpty, adVarChar, adVarWChar, adVarWChar, adVarWChar, adInteger, adTinyInt, adVarWChar, adVarWChar, adVarChar)
  sItemNames = Array("Username", "Password", "Status", "Level", "GID", "LevelText", "GroupText", "Nickname", "Email", "TotalPosts", "", "RegisteredDate", "", "", "LastPostDate", "", "", "LastLoginDate", "", "Host", "IP", "HideEmail", "Approved", "ParentEmail", "", "Homepage", "Location", "Occupation", "Interest", "ICQ", "Age", "Comments", "Signature", "Photo")
  iNullness = Array(0, 0, 0, 0, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, -1, 0, -1, -1, 0, 0, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1)

  Set oConn = CreateObject("ADODB.Connection")
  oConn.Open sConnectionString
  RunBatch oConn, "Accounts.sql", Null, Null
  Set oFSO = CreateObject("Scripting.FileSystemObject")
  Set oTS1 = oFSO.OpenTextFile(sPath & "\Accounts\Accounts.export", 1, False)
  Set oTS2 = oFSO.OpenTextFile(sPath & "\Profiles\Profiles.export", 1, False)
  oTS1.ReadLine
  oTS2.ReadLine
  Set rs = CreateObject("ADODB.RecordSet")
  rs.Open "Accounts", oConn, adOpenForwardOnly, adLockOptimistic, adCmdTable
  Do While Not oTS1.AtEndOfStream
    Set oMatches(0) = oRE1.Execute(oTS1.ReadLine)
    Set oMatches(1) = oRE2.Execute(oTS2.ReadLine)
    If oMatches(0).Count > 0 And oMatches(1).Count > 0 Then
      Set oMatch(0) = oMatches(0)(0)
      Set oMatch(1) = oMatches(1)(0)
      rs.AddNew
      sPK = oMatch(0).SubMatches(0)
      SPK = Left(sPK, Instr(sPK, "|") - 1)
      rs(sItemNames(0)) = CStr(sPK)
      j = 0
      For ii = 1 To 2
        For i = 1 To oMatch(ii - 1).SubMatches.Count - 1
          s = CStr(oMatch(ii - 1).SubMatches(i))
          If Len(s) = 0 And iNullness(i + j) = -1 Then s = Null
          Select Case iItemTypes(i + j)
            Case adInteger, adSmallInt, adTinyInt:
              If Not IsNull(s) Then rs(sItemNames(i + j)) = CLng(s)
            Case adVarWChar, adVarChar, adChar:
              rs(sItemNames(i + j)).Value = s
            Case adLongVarWChar:
              rs(sItemNames(i + j)).AppendChunk s
            Case adDate:
              If Not IsNull(s) Then
                s2 = CStr(oMatch(ii - 1).SubMatches(i + 1))
                rs(sItemNames(i + j)) = DateSerial(Mid(s, 7), Mid(s, 4, 2), Left(s, 2)) + TimeSerial(Left(s2, 2), Mid(s2, 4, 2), 0)
              End If
            Case adBoolean:
              rs(sItemNames(i + j)) = s = "1"
          End Select
        Next
        j = j + 24
      Next
      rs.Update
    End If
  Loop
  rs.Close
  Set rs = Nothing
  oTS1.Close
  oTS2.Close
  Set oTS1 = Nothing
  Set oTS2 = Nothing
  Set oFSO = Nothing
  Set oRE2 = Nothing
  Set oRE1 = Nothing
  oConn.Close
  Set oConn = Nothing
End Function

Function ConvertOthers(sPath, sConnectionString, sTable, iItemTypes, sItemNames, iNullness)
  Dim oConn, rs , oRE, oFSO, oTS, s, oMatch, oMatches, i, s2, sPK

  Set oRE = CreateObject("VBScript.RegExp")
  s = ""
  For i = 0 To UBound(iItemTypes)
    s = s & "(.*?)"
    If i < UBound(iItemTypes) Then s = s & "\|\^\|"
  Next
  oRE.Pattern = "^" & s & "$"
  oRE.IgnoreCase = False

  Set oConn = CreateObject("ADODB.Connection")
  oConn.Open sConnectionString
  RunBatch oConn, sTable & ".sql", Null, Null
  Set oFSO = CreateObject("Scripting.FileSystemObject")
  Set oTS = oFSO.OpenTextFile(sPath & "\" & sTable & "\" & sTable & ".export", 1, False)
  oTS.ReadLine
  Set rs = CreateObject("ADODB.RecordSet")
  rs.Open sTable, oConn, adOpenForwardOnly, adLockOptimistic, adCmdTable
  Do While Not oTS.AtEndOfStream
    Set oMatches = oRE.Execute(oTS.ReadLine)
    If oMatches.Count > 0 Then
      Set oMatch = oMatches(0)
      rs.AddNew
      sPK = oMatch.SubMatches(0)
      SPK = Left(sPK, Instr(sPK, "|") - 1)
      rs(sItemNames(0)) = CInt(sPK)
      For i = 1 To oMatch.SubMatches.Count - 1
        s = CStr(oMatch.SubMatches(i))
        If Len(s) = 0 And iNullness(i) = -1 Then s = Null
        Select Case iItemTypes(i)
          Case adInteger, adSmallInt, adTinyInt:
            If Not IsNull(s) Then rs(sItemNames(i)) = CLng(s)
          Case adVarWChar, adVarChar, adChar:
            rs(sItemNames(i)).Value = s
          Case adLongVarWChar:
            rs(sItemNames(i)).AppendChunk s
          Case adDate:
            If Not IsNull(s) Then
              s2 = CStr(oMatch.SubMatches(i + 1))
              rs(sItemNames(i)) = DateSerial(Mid(s, 7), Mid(s, 4, 2), Left(s, 2)) + TimeSerial(Left(s2, 2), Mid(s2, 4, 2), 0)
            End If
          Case adBoolean:
            rs(sItemNames(i)) = s = "1"
        End Select
      Next
      rs.Update
    End If
  Loop
  rs.Close
  Set rs = Nothing
  oTS.Close
  Set oTS = Nothing
  Set oFSO = Nothing
  Set oRE = Nothing
  oConn.Close
  Set oConn = Nothing
End Function

Function CreateTable(sConnectionString, sTable)
  Dim oConn

  Set oConn = CreateObject("ADODB.Connection")
  oConn.Open sConnectionString
  RunBatch oConn, sTable & ".sql", Null, Null

  oConn.Close
  Set oConn = Nothing
End Function

Dim iItemTypes, sItemNames, iNullness
If MsgBox("Ready to import the database ?", 1, "WinBoard DB Converter") = 1 Then
  If MsgBox("Import the post tables ?", 1, "WinBoard DB Converter") = 1 Then ConvertMessages BackupPath, ConnectionString

  If MsgBox("Import the table ""Accounts"" ?", 1, "WinBoard DB Converter") = 1 Then ConvertAccounts BackupPath, ConnectionString
  
  If MsgBox("Import the table ""Boards"" ?", 1, "WinBoard DB Converter") = 1 Then
    iItemTypes = Array(adInteger, adVarWChar, adVarWChar, adInteger, adVarWChar, adVarWChar, adVarWChar, adVarWChar, adInteger, adInteger, adSmallInt, adBoolean, adBoolean, adBoolean, adBoolean, adBoolean, adBoolean, adVarWChar, adVarWChar, adEmpty, adDate, adEmpty, adEmpty, adDate, adEmpty, adInteger)
    sItemNames = Array("BID", "Title", "Description", "Category", "MajorModerator", "MajorModeratorNicname", "MajorModeratorEmail", "MinorModerators", "TotalPosts", "TotalTopics", "Status", "WBCodes", "HTMLTags", "NeedApproved", "Subscription", "FileAttach", "Expire", "Redirect", "Skin", "", "LastPostDate", "", "", "LastUpdateDate", "", "Position")
    iNullness = Array(0, 0, -1, 0, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0)
    ConvertOthers BackupPath, ConnectionString, "Boards", iItemTypes, sItemNames, iNullness
  End If

  If MsgBox("Import the table ""Categories"" ?", 1, "WinBoard DB Converter") = 1 Then
    iItemTypes = Array(adInteger, adVarWChar, adVarWChar, adInteger, adInteger, adInteger, adEmpty, adDate, adEmpty, adSmallInt, adSmallInt)
    sItemNames = Array("CID", "Title", "Description", "TotalBoards", "TotalPosts", "TotalTopics", "", "LastUpdateDate", "", "Position", "Status")
    iNullness = Array(0, 0, -1, 0, 0, 0, 0, -1, 0, -1, 0)
    ConvertOthers BackupPath, ConnectionString, "Categories", iItemTypes, sItemNames, iNullness
  End If

  If MsgBox("Import the table ""Groups"" ?", 1, "WinBoard DB Converter") = 1 Then
    iItemTypes = Array(adInteger, adVarWChar, adVarWChar, adVarChar, adInteger, adInteger)
    sItemNames = Array("GID", "Title", "Description", "GroupIcon", "MaxFileSize", "TotalMembers")
    iNullness = Array(0, 0, -1, -1, 0, 0)
    ConvertOthers BackupPath, ConnectionString, "Groups", iItemTypes, sItemNames, iNullness
  End If

  CreateTable ConnectionString, "Session"

  MsgBox "Finished !!", 0, "WinBoard DB Converter"
End If
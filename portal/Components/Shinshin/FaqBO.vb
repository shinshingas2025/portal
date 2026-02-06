Imports System.Data.SqlClient
Public Class FaqBO

    Public Function Query(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        ' strSQL = "Select a.faqno,a.faqgrp,a.faqquestion,a.faqanswer,b.it_name as faqgrpname,a.creater,a.revisetime,a.provider from faq a,item b where a.faqgrp = b.no "

        'modify 1120327 
        strSQL = "Select a.faqno,a.faqgrp,a.faqquestion,a.faqanswer,b.it_name as faqgrpname,a.creater,a.revisetime,a.provider , a.faqsort  from faq a,item b where a.faqgrp = b.no "

        If NO <> "" Then
            strSQL &= " and a.faqno='" & NO & "' "

         End If
        ' strSQL &= "Order by a.faqgrp,a.faqno DESC "
        'modify 1120327
        strSQL &= "Order by a.faqgrp,a.faqsort "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryGrp(Optional ByVal GRP As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        ' strSQL = "Select a.faqno,a.faqgrp,a.faqquestion,a.faqanswer,b.it_name as faqgrpname from faq a,item b where a.faqgrp = b.no "

        'modify 1120328 
        strSQL = "Select a.faqno,a.faqgrp,a.faqquestion,a.faqanswer,b.it_name as faqgrpname , a.faqsort  from faq a,item b where a.faqgrp = b.no "

        If GRP <> "" Then
            strSQL &= " and a.faqgrp='" & GRP & "' "

        End If
        'strSQL &= "Order by a.faqgrp,a.faqno DESC "
        'modify 1120328 
        strSQL &= "Order by a.faqgrp,a.faqsort  "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryKw(Optional ByVal KW As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.faqno,a.faqgrp,a.faqquestion,a.faqanswer,b.it_name as faqgrpname from faq a,item b where a.faqgrp = b.no "

        If KW <> "" Then
            strSQL &= " and a.faqquestion LIKE '%" & KW & "%' and a.faqanswer LIKE '%" & KW & "%' "

        End If
        strSQL &= "Order by a.faqgrp,a.faqno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    'Public Function Insert(ByVal Ne As Enfaq) As Integer
    '    Dim strSQL As String = ""
    '    strSQL = "Insert into faq (faqgrp,faqquestion,faqanswer,creater,provider) values ("
    '    strSQL &= "'" & Ne.faqgrp & "'"
    '    strSQL &= ",'" & Ne.faqquestion & "'"
    '    strSQL &= ",'" & Ne.faqanswer & "'"
    '    strSQL &= ",'" & Ne.creater & "'"
    '    strSQL &= ",'" & Ne.Provider & "'"
    '    strSQL &= ")"
    '    Dim conn As New DBConn2
    '    conn.ExecuteNonQuery(strSQL)
    '    conn.close()
    '    Return 0
    'End Function
    '1120327 modify 
    Public Function Insert(ByVal Ne As Enfaq) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into faq (faqgrp,faqquestion,faqanswer,creater,provider,faqsort) values ("
        strSQL &= "'" & Ne.faqgrp & "'"
        strSQL &= ",'" & Ne.faqquestion & "'"
        strSQL &= ",'" & Ne.faqanswer & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ",'" & Ne.faqsort & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enfaq) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE faq "
        If Ne.faqgrp <> "" Then
            strSQLBody &= ",faqgrp='" & Ne.faqgrp & "'"
        End If
        If Ne.faqquestion <> "" Then
            strSQLBody &= ",faqquestion='" & Ne.faqquestion & "'"
        End If
        If Ne.faqanswer <> "" Then
            strSQLBody &= ",faqanswer='" & Ne.faqanswer & "'"
        End If
        If Ne.creater <> "" Then
            strSQLBody &= ",creater='" & Ne.creater & "'"
        End If

        If Ne.Provider <> "" Then
            strSQLBody &= ",Provider='" & Ne.Provider & "'"
        End If

        If Ne.createdate <> "" Then
            strSQLBody &= ",createdate='" & Ne.createdate & "'"
        End If

        '1120327 add 
        If Ne.faqsort <> 0 Then
            strSQLBody &= ",faqsort=" & Ne.faqsort
        End If

        strSQLBody &= ",revisetime=getdate()"

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where faqno ='" & Ne.faqno & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE faq where faqno = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE faq where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class

Imports System.Data.SqlClient
Public Class ItemBO

    Public Function Query(ByVal TYPE As String, Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from item where it_type = '" & TYPE & "' "

        If NO <> "" Then
            strSQL &= " and no='" & NO & "' "

        End If
        strSQL &= "Order by it_order "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Insert(ByVal Ne As Enitem) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into item (it_parentno,it_type,it_name,it_note1,it_note2,it_order,it_act) values ("
        strSQL &= "'" & Ne.it_parentno & "'"
        strSQL &= ",'" & Ne.it_type & "'"
        strSQL &= ",'" & Ne.it_name & "'"
        strSQL &= ",'" & Ne.it_note1 & "'"
        strSQL &= ",'" & Ne.it_note2 & "'"
        strSQL &= ",'" & Ne.it_order & "'"
        strSQL &= ",'" & Ne.it_act & "'"
        strSQL &= ")"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Update(ByVal Ne As Enitem) As Integer
        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE item "
        If Ne.it_parentno <> "" Then
            strSQLBody &= ",it_parentno='" & Ne.it_parentno & "'"
        End If
        If Ne.it_type <> "" Then
            strSQLBody &= ",it_type='" & Ne.it_type & "'"
        End If
        If Ne.it_name <> "" Then
            strSQLBody &= ",it_name='" & Ne.it_name & "'"
        End If
        If Ne.it_note1 <> "" Then
            strSQLBody &= ",it_note1='" & Ne.it_note1 & "'"
        End If
        If Ne.it_note2 <> "" Then
            strSQLBody &= ",it_note2='" & Ne.it_note2 & "'"
        End If
        If Ne.it_order <> "" Then
            strSQLBody &= ",it_order='" & Ne.it_order & "'"
        End If
        'If Ne.it_act <> "" Then
        'strSQLBody &= ",it_act='" & Ne.it_act & "'"
        'End If
        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where no ='" & Ne.no & "' "
        strSQL &= strSQLWhere
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE item where no = '" & NO & "'"
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

    Public Function QueryTOP(ByVal TYPE As String) As String
        Dim strSQL As String = ""
        Dim dt As DataTable
        Dim dtstr As String

        strSQL = "Select TOP 1 * from item where it_type = '" & TYPE & "' "

        strSQL &= "Order by it_order "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        dtstr = CType(dt.Rows(0).Item("no"), String)

        Return dtstr
    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE item where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class

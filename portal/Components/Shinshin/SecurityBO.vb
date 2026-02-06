Imports System.Data.SqlClient
Public Class SecurityBO

    Public Function CheckSecurity(ByVal objacc As Account) As Integer

        Dim dt As New DataTable
        Dim strSQL As String = ""
        Dim i As Integer
        Dim rNum As Integer
        Dim LoginID As String
        Dim password As String
        Dim Useract As String

        LoginID = objacc.userid
        password = objacc.userpw

        rNum = 0
        strSQL = "Select * From admin where userid = '" & LoginID & "'"

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            rNum = -1
        Else
            strSQL = "Select * From admin where userid = '" & LoginID & "' and userpw = '" & password & "' "
            dt = conn.ReadDataTable(strSQL)
            'Useract = CType(dt.Rows(0).Item("useract"), String)
            If dt.Rows.Count < 1 Then
                rNum = -999
            Else
                'If Useract = 1 Then
                'rNum = dt.Rows.Count
                'Else
                rNum = 1
                'End If

            End If
        End If

        conn.close()

        Return rNum

    End Function
    Public Function GepUserGroup(ByVal objacc As Account) As Integer

        Dim dt As New DataTable
        Dim strSQL As String = ""
        Dim Usergrp As String
        Dim LoginID As String
        Dim password As String
        Dim conn As New DBConn

        LoginID = objacc.userid
        password = objacc.userpw

        strSQL = "Select * From admin where userid = '" & LoginID & "' and userpw = '" & password & "'"
        dt = conn.ReadDataTable(strSQL)
        Usergrp = CType(dt.Rows(0).Item("usergrp"), String)
        conn.close()

        Return Usergrp

    End Function

    Public Function Update(ByVal ac As Account) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE admin "
        If ac.userpw <> "" Then
            strSQLBody &= ",userpw='" & ac.userpw & "'"
        End If
        If ac.name <> "" Then
            strSQLBody &= ",name='" & ac.name & "'"
        End If
        If ac.email <> "" Then
            strSQLBody &= ",email='" & ac.email & "'"
        End If

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where userno ='" & ac.userno & "' "
        strSQL &= strSQLWhere


        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function


    Public Function MapCommunity(ByVal ac As Account) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE admin "

        strSQLBody &= ",userno =" & ac.userno & ""


        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where LoginID='" & ac.userid.Trim & "'"
        strSQL &= strSQLWhere
        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()


        Return 0
    End Function

    Public Function Query(ByVal NO As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select a.userno,a.usergrp,a.userid,a.userpw,a.name,a.email,b.it_name as usergrpname from admin as a,item as b "
        strSQL &= " where a.usergrp = b.no "

        If NO <> "" Then
            strSQL &= " and a.userid ='" & NO & "' "

        End If
        strSQL &= " Order by a.userno DESC "
        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryUID(ByVal UID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from sysSecurity  where UID=" & UID

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Delete(ByVal LoginID As String) As Integer
        Dim strSQL As String = ""

        strSQL = "DELETE  admin where userno='" & LoginID & "'"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ac As Account) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into admin (usergrp,userid,userpw,name,email) values ("
        strSQL &= "'" & Ac.usergrp & "'"
        strSQL &= ",'" & Ac.userid & "'"
        strSQL &= ",'" & Ac.userpw & "'"
        strSQL &= ",'" & Ac.name & "'"
        strSQL &= ",'" & Ac.email & "'"
        strSQL &= ")"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function GetAuthorityByLoginID(ByVal LoginID As String) As Integer
        Dim conn As New DBConn

        Dim myCommand As New SqlCommand("getAuthorityByLoginID_SP", conn.SqlConnection())

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterModuleId As New SqlParameter("@LoginID", SqlDbType.NVarChar, 10)
        parameterModuleId.Value = LoginID
        myCommand.Parameters.Add(parameterModuleId)


        myCommand.ExecuteNonQuery()
        conn.close()
        Dim dt As DataTable

        dt = Query(LoginID)
        Return CType((dt.Rows(0).Item("UID")), Integer)


    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE admin where 1 = 1 "
        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class

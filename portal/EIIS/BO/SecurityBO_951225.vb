Imports System.Data.SqlClient
Public Class SecurityBO

    Public Function CheckSecurity(ByVal objacc As Account) As Integer

        Dim dt As New DataTable
        Dim strSQL As String = ""
        Dim i As Integer
        Dim rNum As Integer
        Dim LoginID As String
        Dim password As String

        LoginID = objacc.LoginID
        password = objacc.Password

        rNum = 0
        strSQL = "Select * From sysSecurity where LoginID= '" & LoginID & "'"

        Dim conn As New DBConn
        dt = conn.ReadDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            rNum = -1
        Else
            strSQL = "Select * From sysSecurity where LoginID= '" & LoginID & "' and password='" & password & "'"
            dt = conn.ReadDataTable(strSQL)
            If dt.Rows.Count = 0 Then
                rNum = -999
            Else
                rNum = CType(dt.Rows(0).Item("UID"), Integer)
            End If
        End If

        conn.close()

        Return rNum

    End Function

    Public Function Update(ByVal ac As Account) As Integer

        Dim strSQL As String = ""
        Dim strSQLHead As String = ""
        Dim strSQLBody As String = ""
        Dim strSQLWhere As String = ""

        strSQLHead = "UPDATE sysSecurity "
        If ac.Password.Trim <> "" Then
            strSQLBody &= ",password='" & ac.Password.Trim & "'"
        End If

        If ac.state.Trim <> "" Then
            strSQLBody &= ",state='" & ac.state.Trim & "'"
        End If

        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where LoginID='" & ac.LoginID.Trim & "'"
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

        strSQLHead = "UPDATE sysSecurity "

        strSQLBody &= ",UID=" & ac.UID & ""


        If strSQLBody <> "" Then strSQLBody = Mid(strSQLBody, 2)
        strSQL = strSQLHead
        If strSQLBody <> "" Then
            strSQL &= " set " & strSQLBody
        End If
        strSQLWhere = " Where LoginID='" & ac.LoginID.Trim & "'"
        strSQL &= strSQLWhere
        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()


        Return 0
    End Function
    Public Function Query(ByVal LoginID As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from vUserMapSecurity "
        If LoginID <> "" Then
            strSQL &= " where LoginID='" & LoginID & "'"

        End If
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

        strSQL = "DELETE  sysSecurity where LoginID='" & LoginID & "'"

        Dim conn As New DBConn
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ac As Account) As Integer
        Dim strSQL As String = ""

        strSQL = "Insert into sysSecurity (UID,LoginID,password,startDate,enddate) values ("
        strSQL &= "'" & Ac.UID & "'"
        strSQL &= ",'" & Ac.LoginID & "'"
        strSQL &= ",'" & Ac.Password & "'"
        strSQL &= ",'" & Ac.StartDate & "'"
        strSQL &= ",'" & Ac.EndDate & "'"
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



End Class

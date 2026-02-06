Imports System.Data.SqlClient

Public Class DBConn

    Dim db As SqlConnection

    Dim ServerIP As String = Configration.DBServerName
    Dim Account As String = Configration.DBUserId
    Dim pwd As String = Configration.DBPassword
    Dim DbName As String = Configration.DBDatabase

    Sub New()
        Call OpenDB(ServerIP, Account, pwd, DbName)
    End Sub

    Sub New(ByVal cn As SqlConnection)
        db = cn
    End Sub

    ReadOnly Property SqlConnection() As Data.SqlClient.SqlConnection
        Get
            Return (db)
        End Get
    End Property

    Private Function OpenDB(ByVal ServerIp As String, ByVal Account As String, ByVal pwd As String, ByVal DbName As String) As Integer
        If db Is Nothing Then
            db = New SqlConnection
        End If
        If Account = "" And pwd = "" Then
            db.ConnectionString = "Pooling=true;integrated security=SSPI;database=" & DbName & ";server=" & ServerIp & ";connect Timeout=30"
        Else
            db.ConnectionString = "server=" & ServerIp & ";uid=" & Account & ";pwd=" & pwd & ";database=" & DbName
            'db.ConnectionString = "server=.;uid=sa;database=northwind"
        End If
        Call db.Open()
    End Function

    Sub ExecuteNonQuery(ByVal SQL As String)
        Dim sc As New SqlCommand

        sc.Connection = db
        sc.CommandType = CommandType.Text
        sc.CommandText = SQL
        sc.ExecuteNonQuery()
        sc = Nothing
    End Sub


    '115/1/22穝糤 把计てよ猭更 (Method Overloading)
    Sub ExecuteNonQuery(ByRef cmd As SqlCommand)
        ' 浪琩硈絬篈狦⊿秨碞ゴ秨ウ (ň窾)
        If db.State = ConnectionState.Closed Then
            db.Open()
        End If

        cmd.Connection = db
        cmd.ExecuteNonQuery()

        ' 癘眔р把计睲硂琌▆戈方睦策篋
        cmd.Parameters.Clear()
        cmd = Nothing
    End Sub

    Function ExecuteSPQuery(ByVal StoredProcedureName As String) As SqlDataReader
        Dim sc As New SqlCommand
        sc.Connection = db
        sc.CommandType = CommandType.StoredProcedure
        sc.CommandText = StoredProcedureName
        'Dim para1 As New SqlClient.SqlParameter
        'para1.ParameterName = "@forumtype"
        'para1.Value = forumtype
        'sc.Parameters.Add(para1)
        Return sc.ExecuteReader()

        sc = Nothing
    End Function


    Function Read(ByRef cmd As SqlCommand) As SqlDataReader
        Dim dr As SqlDataReader

        cmd.Connection = db
        dr = cmd.ExecuteReader
        Read = dr
    End Function

    Function Read(ByVal SQL As String) As SqlDataReader
        Dim sc As New SqlCommand
        Dim dr As SqlDataReader

        sc.Connection = db
        sc.CommandType = CommandType.Text
        sc.CommandText = SQL
        dr = sc.ExecuteReader
        Read = dr
        sc = Nothing

    End Function

    Function ReadDataSet(ByRef cmd As SqlCommand) As DataSet
        Dim da As SqlDataAdapter
        Dim ds As New DataSet

        da = New SqlDataAdapter(cmd)
        da.Fill(ds)
        ReadDataSet = ds
        da = Nothing
    End Function

    Function ReadDataSet(ByVal SQL As String) As DataSet
        Dim da As SqlDataAdapter
        Dim ds As New DataSet

        da = New SqlDataAdapter(SQL, db)
        da.Fill(ds)
        ReadDataSet = ds
        da = Nothing
    End Function

    Function ReadDataTable(ByRef cmd As SqlCommand) As DataTable
        Dim da As SqlDataAdapter
        Dim dt As New DataTable

        da = New SqlDataAdapter(cmd)

        Try
            da.Fill(dt)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & cmd.ToString)
        End Try

    End Function

    '磅︽SQL
    Function ReadDataTable(ByVal SQL As String) As DataTable
        Dim da As SqlDataAdapter
        Dim dt As New DataTable

        da = New SqlDataAdapter(SQL, db)
        Try
            da.Fill(dt)
        Catch ex As Exception
            Err.Raise(-1, "db.ReadDataTable", Err.Description & ":" & SQL)
        End Try
        ReadDataTable = dt

        da = Nothing
    End Function

    Sub Update(ByVal SQL As String, ByVal Dt As DataTable)
        Dim da As SqlDataAdapter
        Dim cb As SqlCommandBuilder

        da = New SqlDataAdapter(SQL, db)
        cb = New SqlCommandBuilder(da)
        Try
            da.Update(Dt)
        Catch ex As Exception
            Err.Raise(-1, "db.Update", Err.Description & ":" & SQL.ToString)
        End Try
        da = Nothing
        cb = Nothing

    End Sub

    Protected Overrides Sub Finalize()
        db.Close()
        db = Nothing
    End Sub

    Public Sub close()

        db.Close()
        db.Dispose()
    End Sub
End Class



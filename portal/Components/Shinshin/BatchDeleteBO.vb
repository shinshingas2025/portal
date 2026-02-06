Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Odbc

Public Class BatchDeleteBO
#Region "delete　刪除批次發送記錄"
    Public Function BatchDelete(ByVal rb_no As String) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString2"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String

        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        cmd.Transaction = tran
        Try
            '刪除1
            sqlstr = "delete from Receipt where temp2=@rb_no"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@rb_no", SqlDbType.NVarChar, 10).Value = rb_no
            result = cmd.ExecuteNonQuery()

            '刪除2
            sqlstr = "delete from Receipt_batch where rb_no=@rb_no"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@rb_no", SqlDbType.NVarChar, 10).Value = rb_no
            result = cmd.ExecuteNonQuery()

            '刪除3
            sqlstr = "delete from Receipt_batch_log where rl_rb_no=@rb_no"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@rb_no", SqlDbType.NVarChar, 10).Value = rb_no
            result = cmd.ExecuteNonQuery()

            tran.Commit()           '交易結束
            con.Close()
            cmd = Nothing
            con = Nothing
            Return result
        Catch ex As Exception
            tran.Rollback()         '交易恢復
            con.Close()
            cmd = Nothing
            con = Nothing
            'Err.Raise(Err.Description & ":" & sqlstr.ToString)
            Return -1
        End Try

    End Function
#End Region




End Class

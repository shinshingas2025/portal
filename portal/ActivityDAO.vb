Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc


Public Class ACTIVITYDAO
    '啟動識別碼
    Public Overridable Function ChangWmOpenFlag(ByVal sWmOpenCode As String) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String

        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        cmd.Transaction = tran

        Try

            '新增歷史檔
            'sqlstr = "Insert into webmember_history  select wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,'2','',wm_id,@upd_datetime,'3','2','' from webmember where wm_open_code=@sWmOpenCode"

            sqlstr = "Insert into webmember_history  select wm_no,wm_password,'-','-','-','-','-','-','-',wm_id,wm_org_flag,'-','2','',wm_id,@upd_datetime,'3','2','' from webmember where wm_open_code=@sWmOpenCode"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            cmd.Parameters.Add("@sWmOpenCode", SqlDbType.NVarChar, 12).Value = sWmOpenCode
            result = cmd.ExecuteNonQuery()

            '啟動會員
            sqlstr = "update webmember set wm_open_code = '',wm_open_flag = '2', upd_user = wm_id, upd_datetime = @upd_datetime where wm_open_code=@sWmOpenCode"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@sWmOpenCode", SqlDbType.NVarChar, 12).Value = sWmOpenCode
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            result = cmd.ExecuteNonQuery()

            tran.Commit()           '交易結束
            Return result
            con.Close()
            cmd = Nothing
            con = Nothing
        Catch ex As Exception
            tran.Rollback()         '交易恢復
            Return result
            con.Close()
            cmd = Nothing
            con = Nothing
        End Try

    End Function


End Class

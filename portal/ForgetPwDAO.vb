Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc


Public Class FORGETPWDAO

    '查詢帳號
    Public Overridable Function GetForgetPw(ByVal sWmOrgFlag As String, ByVal sWmEmail As String, ByVal sWmUserName As String, ByVal sWmId As String) As DataSet

        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Dim myCommand As New SqlCommand("select wm_user_name, wm_id from webmember where wm_org_flag=@sWmOrgFlag and wm_email=@sWmEmail and (wm_user_name = @sWmUserName or wm_id = @sWmId) and wm_open_flag = '2'", myConnection)
        Dim myCommand As New SqlCommand("select wm_user_name, wm_id, wm_open_flag from webmember where wm_org_flag=@sWmOrgFlag and wm_email=@sWmEmail and (wm_user_name = @sWmUserName or wm_id = @sWmId)", myConnection)

        myCommand.Parameters.Add("@sWmOrgFlag", SqlDbType.NVarChar, 1).Value = sWmOrgFlag.Trim()
        myCommand.Parameters.Add("@sWmEmail", SqlDbType.NVarChar, 50).Value = sWmEmail.Trim()
        myCommand.Parameters.Add("@sWmUserName", SqlDbType.NVarChar, 50).Value = sWmUserName.Trim()
        myCommand.Parameters.Add("@sWmId", SqlDbType.NVarChar, 10).Value = sWmId.Trim()
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet

    End Function

    '產生新密碼
    Public Overridable Function UpdateWmPw(ByVal sWmUserName As String, ByVal sWmId As String, ByVal sWmPw As String) As Integer
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
            '更新密碼
            sqlstr = "update webmember set wm_password = @sWmPw, upd_user = @sWmId, upd_datetime = @upd_datetime where wm_user_name = @sWmUserName and wm_id = @sWmId and wm_open_flag = '2'"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@sWmPw", SqlDbType.NVarChar, 40).Value = sWmPw.Trim()
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            cmd.Parameters.Add("@sWmUserName", SqlDbType.NVarChar, 50).Value = sWmUserName.Trim()
            cmd.Parameters.Add("@sWmId", SqlDbType.NVarChar, 10).Value = sWmId.Trim()
            result = cmd.ExecuteNonQuery()

            '新增歷史檔
            ' sqlstr = "Insert into webmember_history  select wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,upd_user,upd_datetime,'2' from webmember where wm_user_name = @sWmUserName and wm_id = @sWmId and wm_open_flag = '2'"

            sqlstr = "Insert into webmember_history  select wm_no,wm_password,'-','-','-','-','-','-','-',wm_id,wm_org_flag,'-','-','-',wm_id,@upd_datetime,'2','2','' from webmember where wm_user_name = @sWmUserName and wm_id = @sWmId and wm_open_flag = '2'"

            cmd.CommandText = sqlstr
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

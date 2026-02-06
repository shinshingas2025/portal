Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Public Class webmemberDAO
    Public Overridable Function GetReceiptData(ByVal StrSql As String) As DataTable
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myCommand As New SqlCommand(StrSql, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet.Tables(0)

    End Function

    Public Overridable Function InsertReceiptData(ByVal SqlStr As String) As Integer
        Dim result As Integer = 0
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function
    Public Overridable Function GetSearchData(ByVal wmNo As String, ByVal user_Id As String) As DataTable
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim strSQL As String = ""
        strSQL = " SELECT  distinct Top 6 d.rl_03 as HouseNo, d.rl_04 as UserName,d.rl_01 as RMonth,c.email as WmEmail FROM Receipt_batch_log d INNER JOIN (SELECT A.mh_house_no AS hno,b.wm_email as email FROM member_house A INNER JOIN"
        strSQL = strSQL & " webmember B ON A.mh_wm_no = B.wm_no WHERE (A.mh_wm_no =@wmno)) c ON c.hno = d.rl_03 WHERE  (d.rl_rb_no <> '0') "
        strSQL = strSQL & " order by HouseNo,RMonth DESC"
        Dim myCommand As New SqlCommand(strSQL, myConnection)
        myCommand.Parameters.Add("@wmno", SqlDbType.VarChar, 20).Value = wmNo
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet.Tables(0)

    End Function

    Public Overridable Function InsertSearchDataLog(ByVal DataValue() As String) As Integer
        Dim result As Integer = 0
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Insert into Receipt_user_log(rul_wm_no,rul_house_no,rul_data_ym,rul_action,rul_status,rul_email,add_user,add_datetime,upd_rul_no)" ',add_user,add_datetime,upd_user,upd_datetime)"
        SqlStr = SqlStr & " Values(              @wm_no,    @house_no,  @data_ym,   @action,   @status,  @email ,   @add_user,@add_datetime,@rulno)"
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(1)
        myCommand.Parameters.Add("@data_ym", SqlDbType.VarChar, 5).Value = DataValue(2)
        myCommand.Parameters.Add("@action", SqlDbType.Char, 1).Value = DataValue(3)
        myCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = DataValue(4)
        myCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = DataValue(5)

        myCommand.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = DataValue(6)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 8).Value = Format(Now, "yyyy/MM/dd HH:mm:ss") ' Today ' DataValue(4)
        myCommand.Parameters.Add("@rulno", SqlDbType.Int, 8).Value = "0" ' DataValue(7)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function


    Public Overridable Function GetMemberInfo(ByVal Org As String, ByVal user_Id As String) As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim strSQL As String = ""
        strSQL = " Select * from webmember where wm_org_flag=@org and wm_id=@user_id and wm_open_flag='2'" ''" & user_no & "'"

        Dim myCommand As New SqlCommand(strSQL, myConnection)
        myCommand.Parameters.Add("@org", SqlDbType.VarChar, 20).Value = Org
        myCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 20).Value = user_Id
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet

    End Function
    Public Overridable Function GetDetail(ByVal wm_no As String) As DataSet
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString")) ' OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim strSQL As String

        strSQL = "SELECT * FROM member_house  where mh_wm_no=@wm_no order by mh_no  "

        Dim myCommand As New SqlCommand(strSQL, myConnection)
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = wm_no
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)
        Return myDataSet
    End Function

    Public Overridable Function DeleteMember(ByVal Org As String, ByVal User_Id As String) As Integer
        Dim result As Integer = 0
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim myCommand As New SqlCommand("delete from webmember where wm_org_flag=@Org and wm_id=@User_Id", myConnection)
        myCommand.Parameters.Add("@Org", SqlDbType.VarChar, 20).Value = Org
        myCommand.Parameters.Add("@user_no", SqlDbType.VarChar, 20).Value = User_Id
        'DeleteDetail(GetMemberAutoWm_no(Org, User_Id))

        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function

    Public Overridable Function DeleteDetailForHouseNo(ByVal house_no As String) As Integer
        Dim result As Integer = 0
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim myCommand As New SqlCommand("delete from member_house where mh_house_no=@house_no", myConnection)
        myCommand.Parameters.Add("@house_no", SqlDbType.Int, 8).Value = Val(house_no)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function

#Region "GetEmailIsRepeat　判斷Webmember資料表的Email是否是重覆"
    Public Function GetEmailIsRepeat(ByVal Email As String) As Integer
        Dim count As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select count(wm_email) from webmember where wm_email='" & Email & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                count = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                count = -1
            End Try
        End While
        myReader.Close()
        Return count
    End Function
#End Region

#Region "GetDetailHouseNoIsRepeat　判斷member_house資料表的用戶號碼是否是重覆"
    Public Function GetDetailHouseNoIsRepeat(ByVal HouseNo As String) As Integer
        Dim count As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select count(mh_house_no) from member_house where mh_house_no='" & HouseNo & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                count = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                count = -1
            End Try
        End While
        myReader.Close()
        Return count
    End Function
#End Region

#Region "GetDetailAutomh_no　讀取member_house的自動累加值給History資料表用"
    Public Overridable Function GetDetailAutomh_no(ByVal wm_no As String, ByVal house_no As String) As Integer
        Dim mh_no As Integer
        Dim valResult As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select mh_no from member_house where mh_house_no='" & house_no & "'" 'mh_wm_no='" & wm_no & "' and 
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                mh_no = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                mh_no = 0
            End Try
        End While
        myReader.Close()

        Return mh_no
    End Function
#End Region

    Public Overridable Function InsertDetailHistory(ByVal DataValue() As String) As Integer
        Dim result As Integer = 0
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Insert into member_house_history(mh_no,mh_wm_no,mh_house_no,mh_ers_flag,add_user,add_datetime,update_type)"
        SqlStr = SqlStr & " Values(@no,@wm_no,@house_no,@ers_flag,@add_user,@add_datetime,@update_type)"
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myCommand.Parameters.Add("@no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = DataValue(1)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(2)
        myCommand.Parameters.Add("@ers_flag", SqlDbType.Char, 1).Value = DataValue(3)
        myCommand.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = DataValue(4)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(4)
        myCommand.Parameters.Add("@update_type", SqlDbType.Char, 1).Value = DataValue(5)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function

    Public Overridable Function InsertUpdateHistory(ByVal HouseNo As String, ByVal WmNo As String, ByVal UpdType As String) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String
        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        ' tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        'cmd.Transaction = tran
        Try
            '新增歷史檔
            sqlstr = "Insert into webmember_history  select wm_no,wm_password,wm_user_name,wm_user_o_name,wm_tel_h,wm_tel_o,wm_tel_o2,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,'2','" & HouseNo & "',wm_id,@upd_datetime,'" & UpdType & "','0','' from webmember where wm_no='" & WmNo & "'"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            result = cmd.ExecuteNonQuery()
            ' tran.Commit()           '交易結束
            'Return result
            con.Close()
            cmd = Nothing
            con = Nothing
        Catch ex As Exception
        End Try
    End Function


    Public Overridable Function InsertDeleteHistory(ByVal HouseNo As String, ByVal WmNo As String, ByVal UpdType As String) As Integer
        Dim result As Integer = 0
        Dim today As Date = Now
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim tran As SqlClient.SqlTransaction
        Dim cmd As SqlClient.SqlCommand
        Dim sqlstr As String
        con.Open()
        cmd = con.CreateCommand()
        cmd.Connection = con
        ' tran = con.BeginTransaction(IsolationLevel.ReadUncommitted) '交易開始
        'cmd.Transaction = tran
        Try
            '新增歷史檔
            sqlstr = "Insert into webmember_history  select wm_no,wm_password,'-','-','-','-','-','-','-',wm_id,wm_org_flag,'-','-','" & HouseNo & "',wm_id,@upd_datetime,'" & UpdType & "','0','' from webmember where wm_no='" & WmNo & "'"
            cmd.CommandText = sqlstr
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
            result = cmd.ExecuteNonQuery()
            ' tran.Commit()           '交易結束
            'Return result
            con.Close()
            cmd = Nothing
            con = Nothing
        Catch ex As Exception
        End Try
    End Function

    Public Overridable Function DeleteDetailForWmNo(ByVal wm_no As Integer) As Integer
        Dim result As Integer = 0
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim myCommand As New SqlCommand("delete from member_house where mh_wm_no=@wm_no", myConnection)
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = wm_no
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function
    Public Overridable Function InsertMember(ByVal DataValue() As String) As String
        Dim entityID As String
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Insert into webmember (wm_password,wm_user_name,wm_tel_h,wm_tel_o,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,wm_open_code,add_user,add_datetime,wm_user_o_name,wm_tel_o2) "
        SqlStr = SqlStr & " values(@password,@user_name,@tel_h,@tel_o,@mobile,@email,@id,@org_flag,@paper_flag,@open_flag,@open_code,@add_user,@add_datetime,@user_o_name,@tel_o2) "
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        'myCommand.Parameters.Add("@no", SqlDbType.Int, 8).Value = ""
        myCommand.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = DataValue(0)
        myCommand.Parameters.Add("@user_name", SqlDbType.VarChar, 50).Value = DataValue(1)
        myCommand.Parameters.Add("@tel_h", SqlDbType.VarChar, 15).Value = DataValue(2)
        myCommand.Parameters.Add("@tel_o", SqlDbType.VarChar, 15).Value = DataValue(3)
        myCommand.Parameters.Add("@mobile", SqlDbType.VarChar, 10).Value = DataValue(4)
        myCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = DataValue(5)
        myCommand.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = DataValue(6)
        myCommand.Parameters.Add("@org_flag", SqlDbType.Char, 1).Value = DataValue(7)
        myCommand.Parameters.Add("@paper_flag", SqlDbType.Char, 1).Value = DataValue(8)
        myCommand.Parameters.Add("@open_flag", SqlDbType.Char, 1).Value = DataValue(9)
        myCommand.Parameters.Add("@open_code", SqlDbType.Char, 12).Value = DataValue(10)
        myCommand.Parameters.Add("@add_user", SqlDbType.VarChar, 125).Value = DataValue(6)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(11)
        myCommand.Parameters.Add("@user_o_name", SqlDbType.VarChar, 125).Value = DataValue(11)
        myCommand.Parameters.Add("@tel_o2", SqlDbType.VarChar, 5).Value = DataValue(12)
        myConnection.Open()
        entityID = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return entityID


    End Function
    Public Overridable Function InsertDetail(ByVal DataValue() As String) As Integer
        Dim result As Integer = 0
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Insert into member_house(mh_wm_no,mh_house_no,mh_ers_flag,add_user,add_datetime)"
        SqlStr = SqlStr & " Values(@wm_no,@house_no,@ers_flag,@add_user,@add_datetime)"
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        'myCommand.Parameters.Add("@no", SqlDbType.Int, 8).Value = ""
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(1)
        myCommand.Parameters.Add("@ers_flag", SqlDbType.Char, 1).Value = DataValue(2)
        myCommand.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = DataValue(3)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(4)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result

#If 0 Then

        SqlStr = " Insert into member_house(mh_no,mh_wm_no,mh_house_no,mh_ers_flag,add_user,add_datetime,update_type)"
        SqlStr = SqlStr & " Values(@no,@wm_no,@house_no,@ers_flag,@add_user,@add_datetime,@update_type)"
        myCommand = SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myCommand.Parameters.Add("@no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = DataValue(1)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(2)
        myCommand.Parameters.Add("@ers_flag", SqlDbType.Char, 1).Value = DataValue(3)
        myCommand.Parameters.Add("@add_user", SqlDbType.VarChar, 20).Value = DataValue(4)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(4)
        myCommand.Parameters.Add("@update_type", SqlDbType.Char, 1).Value = DataValue(5)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
#End If

    End Function

    Function UpdateMemberHouseList(ByVal HouseList As String, ByVal Wm_No As String, ByVal User As String) As String
        Dim SqlStr As String
        Dim entityID As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Update webmember Set wm_house_list=@houselist,"
        SqlStr = SqlStr & " upd_user=@upd_user,upd_datetime=@upd_datetime "
        SqlStr = SqlStr & " where wm_no=@wmno "
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myCommand.Parameters.Add("@houselist", SqlDbType.VarChar, 225).Value = HouseList
        myCommand.Parameters.Add("@upd_user", SqlDbType.VarChar, 20).Value = User
        myCommand.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today
        myCommand.Parameters.Add("@wmno", SqlDbType.Int, 8).Value = Wm_No
        myConnection.Open()
        entityID = myCommand.ExecuteNonQuery()
        myConnection.Close()
    End Function
    Public Overridable Function UpdateMember(ByVal DataValue() As String) As String
        Dim SqlStr As String
        Dim entityID As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Update webmember Set wm_password=@password, wm_user_name=@user_name, wm_tel_h=@tel,wm_tel_o=@telo, wm_mobile=@mobile, "
        SqlStr = SqlStr & "wm_email=@email,  wm_paper_flag=@paper_flag, wm_user_o_name=@user_o_name, wm_tel_o2=@tel_o2, "
        SqlStr = SqlStr & " upd_user=@upd_user,upd_datetime=@upd_datetime "
        SqlStr = SqlStr & " where wm_id=@id and wm_org_flag=@org_flag "
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myCommand.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = DataValue(0)
        myCommand.Parameters.Add("@user_name", SqlDbType.VarChar, 50).Value = DataValue(1)
        myCommand.Parameters.Add("@tel", SqlDbType.VarChar, 15).Value = DataValue(2)
        myCommand.Parameters.Add("@telo", SqlDbType.VarChar, 15).Value = DataValue(3)
        myCommand.Parameters.Add("@mobile", SqlDbType.VarChar, 10).Value = DataValue(4)
        myCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = DataValue(5)
        myCommand.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = DataValue(6)
        myCommand.Parameters.Add("@org_flag", SqlDbType.Char, 1).Value = DataValue(7)
        myCommand.Parameters.Add("@paper_flag", SqlDbType.Char, 1).Value = DataValue(8)
        myCommand.Parameters.Add("@open_flag", SqlDbType.Char, 1).Value = DataValue(9)
        myCommand.Parameters.Add("@upd_user", SqlDbType.VarChar, 20).Value = DataValue(6)
        myCommand.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(11)
        myCommand.Parameters.Add("@user_o_name", SqlDbType.VarChar, 125).Value = DataValue(11)
        myCommand.Parameters.Add("@tel_o2", SqlDbType.VarChar, 5).Value = DataValue(12)

        myConnection.Open()
        entityID = myCommand.ExecuteNonQuery()
        myConnection.Close()


    End Function
    Public Overridable Function UpdateDetail(ByVal DataValue() As String) As Integer
        Dim result As Integer = 0
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        SqlStr = " Update member_house Set mh_ers_flag=@ers_flag,upd_user=@upd_user,upd_datetime=@upd_datetime"
        SqlStr = SqlStr & " Where mh_wm_no=@wm_no and mh_house_no=@house_no"
        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
        myCommand.Parameters.Add("@wm_no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(1)
        myCommand.Parameters.Add("@ers_flag", SqlDbType.Char, 1).Value = DataValue(2)
        myCommand.Parameters.Add("@upd_user", SqlDbType.VarChar, 20).Value = DataValue(3)
        myCommand.Parameters.Add("@upd_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(4)
        myConnection.Open()
        result = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return result
    End Function
    Public Overridable Function GetMemberAutoWm_no(ByVal Org As String, ByVal User_id As String) As Integer
        Dim wm_no As Integer
        Dim valResult As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select wm_no from webmember where wm_org_flag='" & Org & "' and wm_id='" & User_id & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                wm_no = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                wm_no = 0
            End Try
        End While
        myReader.Close()

        Return wm_no
    End Function
    Public Function GetIdNoIsRepeat(ByVal IdOrg As String, ByVal IDNum As String) As Integer
        Dim count As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select count(wm_user_name) from webmember where wm_org_flag='" & IdOrg & "' and wm_id='" & IDNum & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                count = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                count = -1
            End Try
        End While
        myReader.Close()
        Return count
    End Function
    Public Overridable Function GetActivityCode(ByVal ACode As String) As String
        Dim ac_no As String
        Dim OpenFlag As Integer = 0
        Dim valResult As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select wm_user_name,wm_open_flag from webmember where wm_open_code='" & ACode & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                ac_no = CStr(myReader.GetValue(0))
                OpenFlag = CStr(myReader.GetValue(1))
            Catch ex As System.InvalidCastException
                ac_no = ""
            End Try
        End While
        myReader.Close()
        If OpenFlag = 1 Then
            selectSQL = " Update webmember Set wm_open_flag='2' where wm_open_code='" & ACode & "'"
            Dim myCommand1 As New SqlCommand(selectSQL, myConnection)
            myConnection.Open()
            valResult = myCommand1.ExecuteNonQuery()
            myConnection.Close()

        ElseIf OpenFlag = 2 Then
            ac_no = "此帳號早已啟動，不需重覆啟動"
        Else
            ac_no = "此帳號已停用，請洽承辦人員啟用"
        End If
        Return ac_no
    End Function

    Public Function CheckCodeIsRepeat(ByVal OpenCode As String) As Integer
        Dim count As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String

        selectSQL = "select count(wm_user_name) from webmember where wm_open_code='" & OpenCode & "'"
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                count = CStr(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                count = -1
            End Try
        End While
        myReader.Close()
        Return count
    End Function

    Public Overridable Function GetTotalRow() As Integer
        Dim valResult As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim myCommand As New SqlCommand("select count(*) from webmember", myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                valResult = CInt(myReader.GetValue(0))
            Catch ex As System.InvalidCastException
                valResult = 0
            End Try
        End While
        myReader.Close()
        Return valResult
    End Function


    Public Overridable Function WriteMember(ByVal DataValue() As String, ByVal today As Date) As String
        Dim entityID As String
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        ' SqlStr = " Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_tel_h,wm_tel_o,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,add_user,add_datetime,update_type,wm_user_o_name,wm_tel_o2) "
        ' SqlStr = SqlStr & " values(@no,@password,@user_name,@tel_h,@tel_o,@mobile,@email,@id,@org_flag,@paper_flag,@open_flag,@add_user,@add_datetime,@type,@user_o_name,@tel_o2) "

        SqlStr = " Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_tel_h,wm_tel_o,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,add_user,add_datetime,update_type,wm_user_o_name,wm_tel_o2,wm_house_no,trans_type) "
        SqlStr = SqlStr & " values(@no,@password,@user_name,@tel_h,@tel_o,@mobile,@email,@id,@org_flag,@paper_flag,@open_flag,@add_user,@add_datetime,@type,@user_o_name,@tel_o2,@house_no,@transtype) "

        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        'Dim today As Date = Now
        myCommand.Parameters.Add("@no", SqlDbType.Int, 8).Value = DataValue(0)
        myCommand.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = DataValue(1)
        myCommand.Parameters.Add("@user_name", SqlDbType.VarChar, 50).Value = DataValue(2)
        myCommand.Parameters.Add("@tel_h", SqlDbType.VarChar, 15).Value = DataValue(3)
        myCommand.Parameters.Add("@tel_o", SqlDbType.VarChar, 15).Value = DataValue(4)
        myCommand.Parameters.Add("@mobile", SqlDbType.VarChar, 10).Value = DataValue(5)
        myCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = DataValue(6)
        myCommand.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = DataValue(7)
        myCommand.Parameters.Add("@org_flag", SqlDbType.Char, 1).Value = DataValue(8)
        myCommand.Parameters.Add("@paper_flag", SqlDbType.Char, 1).Value = DataValue(9)
        myCommand.Parameters.Add("@open_flag", SqlDbType.Char, 1).Value = DataValue(10)
        myCommand.Parameters.Add("@add_user", SqlDbType.Char, 12).Value = DataValue(7)
        myCommand.Parameters.Add("@add_datetime", SqlDbType.DateTime, 10).Value = today ' DataValue(11)
        myCommand.Parameters.Add("@type", SqlDbType.Char, 1).Value = DataValue(12)
        myCommand.Parameters.Add("@user_o_name", SqlDbType.VarChar, 125).Value = DataValue(13)
        myCommand.Parameters.Add("@tel_o2", SqlDbType.VarChar, 5).Value = DataValue(14)
        myCommand.Parameters.Add("@house_no", SqlDbType.VarChar, 10).Value = DataValue(15)
        myCommand.Parameters.Add("@transtype", SqlDbType.VarChar, 1).Value = DataValue(16)

        myConnection.Open()
        entityID = myCommand.ExecuteNonQuery()
        myConnection.Close()
        Return entityID


    End Function

#If 0 Then
    Public Overridable Function GetMaxItemID(ByVal ItemID As Integer) As Integer
        Dim maxID As Integer
        Dim valResult As Integer
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        Dim selectSQL As String
        selectSQL = "select isnull(max(ItemID),0) ccounter from APPM01 "
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        While myReader.Read()
            Try
                maxID = CType((myReader.GetValue(0)), Integer)

            Catch ex As System.InvalidCastException
                maxID = 0
            End Try
        End While
        myReader.Close()
        valResult = maxID
        valResult = valResult + 1
        Return valResult
    End Function
#End If
End Class

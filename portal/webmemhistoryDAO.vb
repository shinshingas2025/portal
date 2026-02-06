Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class webmemhistoryDAO
    

    Public Overridable Function WriteMember(ByVal DataValue() As String) As String
        Dim entityID As String
        Dim SqlStr As String
        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        ' SqlStr = " Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_tel_h,wm_tel_o,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,add_user,add_datetime,update_type,wm_user_o_name,wm_tel_o2) "
        ' SqlStr = SqlStr & " values(@no,@password,@user_name,@tel_h,@tel_o,@mobile,@email,@id,@org_flag,@paper_flag,@open_flag,@add_user,@add_datetime,@type,@user_o_name,@tel_o2) "

        SqlStr = " Insert into webmember_history (wm_no,wm_password,wm_user_name,wm_tel_h,wm_tel_o,wm_mobile,wm_email,wm_id,wm_org_flag,wm_paper_flag,wm_open_flag,add_user,add_datetime,update_type,wm_user_o_name,wm_tel_o2,wm_house_no,trans_type) "
        SqlStr = SqlStr & " values(@no,@password,@user_name,@tel_h,@tel_o,@mobile,@email,@id,@org_flag,@paper_flag,@open_flag,@add_user,@add_datetime,@type,@user_o_name,@tel_o2,@house_no,@transtype) "

        Dim myCommand As New SqlCommand(SqlStr, myConnection)
        Dim today As Date = Now
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

End Class

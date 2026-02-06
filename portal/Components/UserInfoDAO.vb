Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Public Class UserInfoDAO
	Public Function QueryDS(ByVal DeptID As String) As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("Portal_GetDeptEmp", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterDeptID As New SqlParameter("@DeptID", SqlDbType.NVarChar, 10)
		parameterDeptID.Value = DeptID
		myCommand.SelectCommand.Parameters.Add(parameterDeptID)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function


	Public Function QueryUserInfo(ByVal objUser As User) As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("Portal_GetUserList", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterCname As New SqlParameter("@Cname", SqlDbType.NVarChar, 10)
		parameterCname.Value = objUser.Cname
		myCommand.SelectCommand.Parameters.Add(parameterCname)

		Dim parameterTelCompany As New SqlParameter("@TelCompany", SqlDbType.NVarChar, 10)
		parameterTelCompany.Value = objUser.TelCompany
		myCommand.SelectCommand.Parameters.Add(parameterTelCompany)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function


	Public Function Update(ByVal objUser As User) As Boolean
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
		Dim myCommand As New SqlCommand("Portal_UpdateUserDept", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameterUID As New SqlParameter("@UID", SqlDbType.NVarChar, 50)
		parameterUID.Value = objUser.UID
		myCommand.Parameters.Add(parameterUID)

		Dim parameterDept As New SqlParameter("@Dept", SqlDbType.NVarChar, 50)
		parameterDept.Value = objUser.Dept
		myCommand.Parameters.Add(parameterDept)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function

End Class

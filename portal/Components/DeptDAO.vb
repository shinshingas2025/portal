Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Public Class DeptDAO
	Public Function Insert(ByVal objItem As DeptExtendOrgEntity, Optional ByVal moduleId As Integer = 0, Optional ByVal sid As String = "") As Boolean

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlCommand("Portal_AddDept", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@SID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameterDeptID As New SqlParameter("@DeptID", SqlDbType.Int, 4)
		parameterDeptID.Value = objItem.DeptID
		myCommand.Parameters.Add(parameterDeptID)

		Dim parameterDeptName As New SqlParameter("@DeptName", SqlDbType.NVarChar, 50)
		parameterDeptName.Value = objItem.DeptName
		myCommand.Parameters.Add(parameterDeptName)

		Dim parameterDeptTel As New SqlParameter("@DeptTel", SqlDbType.NVarChar, 50)
		parameterDeptTel.Value = objItem.DeptTel
		myCommand.Parameters.Add(parameterDeptTel)

		Dim parameterManager As New SqlParameter("@Manager", SqlDbType.NVarChar, 50)
		parameterManager.Value = objItem.Manager
		myCommand.Parameters.Add(parameterManager)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function

	Public Function Update(ByVal objItem As OrgEntity, Optional ByVal moduleId As Integer = 0, Optional ByVal sid As String = "") As Boolean
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlCommand("Portal_AddImage", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		parameterModuleId.Value = moduleId
		myCommand.Parameters.Add(parameterModuleId)

		Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		parametersId.Value = sid
		myCommand.Parameters.Add(parametersId)

		Dim parameterobjID As New SqlParameter("@objID", SqlDbType.Int, 4)
		parameterobjID.Value = objItem.objID
		myCommand.Parameters.Add(parameterobjID)

		Dim parameterobjName As New SqlParameter("@objName", SqlDbType.NVarChar, 50)
		parameterobjName.Value = objItem.objName
		myCommand.Parameters.Add(parameterobjName)

		Dim parameterobjValue As New SqlParameter("@objValue", SqlDbType.NVarChar, 50)
		parameterobjValue.Value = objItem.objValue
		myCommand.Parameters.Add(parameterobjValue)

		Dim parameterPID As New SqlParameter("@PID", SqlDbType.Int, 4)
		parameterPID.Value = objItem.PID
		myCommand.Parameters.Add(parameterPID)

		Dim parameterSEQNO As New SqlParameter("@SEQNO", SqlDbType.Int, 4)
		parameterSEQNO.Value = objItem.SEQNO
		myCommand.Parameters.Add(parameterSEQNO)

		Dim parametersrcName As New SqlParameter("@srcName", SqlDbType.NVarChar, 50)
		parametersrcName.Value = objItem.srcName
		myCommand.Parameters.Add(parametersrcName)

		Dim parameterstate As New SqlParameter("@state", SqlDbType.NVarChar, 1)
		parameterstate.Value = objItem.state
		myCommand.Parameters.Add(parameterstate)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function


	Public Function Delete(ByVal objItem As DeptExtendOrgEntity, Optional ByVal moduleId As Integer = 0, Optional ByVal sid As String = "") As Boolean
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlCommand("Portal_DeleteDept", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameterDeptID As New SqlParameter("@DeptID", SqlDbType.NVarChar, 50)
		parameterDeptID.Value = objItem.DeptID
		myCommand.Parameters.Add(parameterDeptID)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function

	Public Function QueryMaxKey() As DataSet

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("Portal_GetDeptMaxKey", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure


		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function


	Public Overridable Function GetDeptList() As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
		Dim myCommand As New SqlCommand("select * from sysDept where Manager='Y' order by DeptID ", myConnection)
		
		Dim myAdapter As New SqlDataAdapter(myCommand)
		Dim myDataSet As New DataSet
		myAdapter.Fill(myDataSet)
		Return myDataSet
	End Function



	Public Function QueryDS(ByVal objItem As OrgEntity, Optional ByVal moduleId As Integer = 0, Optional ByVal sid As String = "") As DataSet

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("Portal_GetOrg", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterobjID As New SqlParameter("@objID", SqlDbType.Int, 4)
		parameterobjID.Value = objItem.objID
		myCommand.SelectCommand.Parameters.Add(parameterobjID)

		Dim parameterobjName As New SqlParameter("@objName", SqlDbType.NVarChar, 50)
		parameterobjName.Value = objItem.objName
		myCommand.SelectCommand.Parameters.Add(parameterobjName)

		Dim parameterobjValue As New SqlParameter("@objValue", SqlDbType.NVarChar, 50)
		parameterobjValue.Value = objItem.objValue
		myCommand.SelectCommand.Parameters.Add(parameterobjValue)

		Dim parameterPID As New SqlParameter("@PID", SqlDbType.Int, 4)
		parameterPID.Value = objItem.PID
		myCommand.SelectCommand.Parameters.Add(parameterPID)

		Dim parameterSEQNO As New SqlParameter("@SEQNO", SqlDbType.Int, 4)
		parameterSEQNO.Value = objItem.SEQNO
		myCommand.SelectCommand.Parameters.Add(parameterSEQNO)

		Dim parametersrcName As New SqlParameter("@srcName", SqlDbType.NVarChar, 50)
		parametersrcName.Value = objItem.srcName
		myCommand.SelectCommand.Parameters.Add(parametersrcName)

		Dim parameterstate As New SqlParameter("@state", SqlDbType.NVarChar, 1)
		parameterstate.Value = objItem.state
		myCommand.SelectCommand.Parameters.Add(parameterstate)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function
End Class

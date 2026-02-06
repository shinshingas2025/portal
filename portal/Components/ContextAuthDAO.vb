Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Public Class ContextAuthDAO
	Public Function QueryObjTableRec(ByVal ObjID As String, ByVal RecID As String) As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
		Dim myCommand As New SqlDataAdapter("GetObjRec", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterObjID As New SqlParameter("@ObjID", SqlDbType.NVarChar, 50)
		parameterObjID.Value = ObjID
		myCommand.SelectCommand.Parameters.Add(parameterObjID)

		Dim parameterRecID As New SqlParameter("@RecID", SqlDbType.NVarChar, 50)
		parameterRecID.Value = RecID
		myCommand.SelectCommand.Parameters.Add(parameterRecID)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function

	Public Function QuerySpecAuthContext(ByVal ObjID As String, ByVal RecID As String, ByVal Authtype As String, ByVal AuthID As String) As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("GetSpecAuthRec", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterObjID As New SqlParameter("@ObjID", SqlDbType.NVarChar, 50)
		parameterObjID.Value = ObjID
		myCommand.SelectCommand.Parameters.Add(parameterObjID)

		Dim parameterRecID As New SqlParameter("@RecID", SqlDbType.NVarChar, 50)
		parameterRecID.Value = RecID
		myCommand.SelectCommand.Parameters.Add(parameterRecID)

		Dim parameterAuthType As New SqlParameter("@AuthType", SqlDbType.NVarChar, 50)
		parameterAuthType.Value = Authtype
		myCommand.SelectCommand.Parameters.Add(parameterAuthType)

		Dim parameterAuthID As New SqlParameter("@AuthID", SqlDbType.NVarChar, 50)
		parameterAuthID.Value = AuthID
		myCommand.SelectCommand.Parameters.Add(parameterAuthID)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function



	Public Function QueryPortal_ConAuth(ByVal ObjID As String, ByVal RecID As String) As DataSet
		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
		Dim myCommand As New SqlDataAdapter("GetRecSpecList", myConnection)

		myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.SelectCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.SelectCommand.Parameters.Add(parametersId)

		Dim parameterObjID As New SqlParameter("@ObjID", SqlDbType.NVarChar, 50)
		parameterObjID.Value = ObjID
		myCommand.SelectCommand.Parameters.Add(parameterObjID)

		Dim parameterRecID As New SqlParameter("@RecID", SqlDbType.NVarChar, 50)
		parameterRecID.Value = RecID
		myCommand.SelectCommand.Parameters.Add(parameterRecID)

		Dim myDataSet As New DataSet
		myCommand.Fill(myDataSet)

		Return myDataSet
	End Function


	Public Function UpdateObjTable(ByVal ObjID As String, ByVal RecID As String, ByVal Permission As String) As Boolean

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
		Dim myCommand As New SqlCommand("Portal_UpdateGenPermission", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameterobjID As New SqlParameter("@objID", SqlDbType.NVarChar, 50)
		parameterobjID.Value = ObjID
		myCommand.Parameters.Add(parameterobjID)

		Dim parameterRecID As New SqlParameter("@RecID", SqlDbType.NVarChar, 50)
		parameterRecID.Value = RecID
		myCommand.Parameters.Add(parameterRecID)

		Dim parameterPermission As New SqlParameter("@Permission", SqlDbType.NVarChar, 50)
		parameterPermission.Value = Permission
		myCommand.Parameters.Add(parameterPermission)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function

	Public Function InsertConAuth(ByVal ObjID As String, ByVal RecID As String, ByVal AuthType As String, ByVal AuthID As String, ByVal AuthMask As String) As Boolean

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
		Dim myCommand As New SqlCommand("Portal_AddConAuth", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameterobjID As New SqlParameter("@objID", SqlDbType.NVarChar, 50)
		parameterobjID.Value = ObjID
		myCommand.Parameters.Add(parameterobjID)

		Dim parameterRecID As New SqlParameter("@RecID", SqlDbType.NVarChar, 50)
		parameterRecID.Value = RecID
		myCommand.Parameters.Add(parameterRecID)

		Dim parameterAuthType As New SqlParameter("@AuthType", SqlDbType.NVarChar, 2)
		parameterAuthType.Value = AuthType
		myCommand.Parameters.Add(parameterAuthType)

		Dim parameterAuthID As New SqlParameter("@AuthID", SqlDbType.NVarChar, 2)
		parameterAuthID.Value = AuthID
		myCommand.Parameters.Add(parameterAuthID)

		Dim parameterAuthMask As New SqlParameter("@AuthMask", SqlDbType.NVarChar, 3)
		parameterAuthMask.Value = AuthMask
		myCommand.Parameters.Add(parameterAuthMask)

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function


	Public Function DeleteConAuth(ByVal itemID As Integer) As Boolean

		Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
		Dim myCommand As New SqlCommand("Portal_DeleteConAuth", myConnection)

		' Mark the Command as a SPROC
		myCommand.CommandType = CommandType.StoredProcedure

		'Dim parameterModuleId As New SqlParameter("@ModuleID", SqlDbType.Int, 4)
		'parameterModuleId.Value = moduleId
		'myCommand.Parameters.Add(parameterModuleId)

		'Dim parametersId As New SqlParameter("@sID", SqlDbType.NVarChar, 5)
		'parametersId.Value = sid
		'myCommand.Parameters.Add(parametersId)

		Dim parameteritemID As New SqlParameter("@itemID", SqlDbType.NVarChar, 50)
		parameteritemID.Value = itemID
		myCommand.Parameters.Add(parameteritemID)

	

		myConnection.Open()
		myCommand.ExecuteNonQuery()
		myConnection.Close()

		Return (True)
	End Function

End Class

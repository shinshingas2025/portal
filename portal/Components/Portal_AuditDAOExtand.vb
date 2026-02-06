Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_AuditDAOExtand
		Inherits Portal_AuditDAO
		Public Overloads Function GetTotalRow(ByVal schoolID As String, ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Audit where SchoolID=@SchoolID and ModuleID=@ModuleID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
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
		Public Overridable Function GetModuleName(ByVal moduleID As Integer) As String
			Dim valResult As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select objName from sysDomains where objID=" & moduleID
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					valResult = CStr(myReader.GetValue(0))
				Catch ex As System.InvalidCastException
					valResult = ""
				End Try
			End While
			Return valResult
		End Function
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal levelID As Integer, ByVal actionID As Integer, ByVal createdByUser As String, ByVal startTime As Date, ByVal endTime As Date) As DataSet
			Dim mySQLString As String = "select * from Portal_Audit where "
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim firstCondition As Boolean = True

			If schoolID <> "" Then
				mySQLString = mySQLString + "SchoolID=@SchoolID "
				firstCondition = False
			End If
			If moduleID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "ModuleID=@ModuleID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and ModuleID=@ModuleID "
				End If
			End If
			If levelID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "LevelID=@LevelID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and LevelID=@LevelID "
				End If
			End If
			If actionID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "ActionID=@ActionID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and ActionID=@ActionID "
				End If
			End If
			If createdByUser <> "" Then
				If firstCondition = True Then
					mySQLString = mySQLString + "CreatedByUser=@CreatedByUser "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and CreatedByUser=@CreatedByUser "
				End If
			End If
			If firstCondition = True Then
				mySQLString = mySQLString + "CreatedDate>=@StartTime and CreatedDate<=@EndTime"
			Else
				mySQLString = mySQLString + " and CreatedDate>=@StartTime and CreatedDate<=@EndTime"
			End If

			mySQLString = mySQLString + " order by EntityID desc"

			Dim myCommand As New SqlCommand(mySQLString, myConnection)

			If schoolID <> "" Then
				myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			End If
			If moduleID <> 0 Then
				myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			End If
			If levelID <> 0 Then
				myCommand.Parameters.Add("@LevelID", SqlDbType.Int, 4).Value = levelID
			End If
			If actionID <> 0 Then
				myCommand.Parameters.Add("@ActionID", SqlDbType.Int, 4).Value = actionID
			End If
			If createdByUser <> "" Then
				myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			End If
			myCommand.Parameters.Add("@StartTime", SqlDbType.DateTime, 8).Value = startTime
			myCommand.Parameters.Add("@EndTime", SqlDbType.DateTime, 8).Value = endTime
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal levelID As Integer, ByVal actionID As Integer, ByVal createdByUser As String, ByVal startTime As Date, ByVal endTime As Date, ByVal rowCount As Integer) As DataSet
			Dim mySQLString As String = "select top " & rowCount & " * from Portal_Audit where "
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim firstCondition As Boolean = True

			If schoolID <> "" Then
				mySQLString = mySQLString + "SchoolID=@SchoolID "
				firstCondition = False
			End If
			If moduleID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "ModuleID=@ModuleID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and ModuleID=@ModuleID "
				End If
			End If
			If levelID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "LevelID=@LevelID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and LevelID=@LevelID "
				End If
			End If
			If actionID <> 0 Then
				If firstCondition = True Then
					mySQLString = mySQLString + "ActionID=@ActionID "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and ActionID=@ActionID "
				End If
			End If
			If createdByUser <> "" Then
				If firstCondition = True Then
					mySQLString = mySQLString + "CreatedByUser=@CreatedByUser "
					firstCondition = False
				Else
					mySQLString = mySQLString + "and CreatedByUser=@CreatedByUser "
				End If
			End If
			If firstCondition = True Then
				mySQLString = mySQLString + "CreatedDate>=@StartTime and CreatedDate<=@EndTime"
			Else
				mySQLString = mySQLString + " and CreatedDate>=@StartTime and CreatedDate<=@EndTime"
			End If

			mySQLString = mySQLString + " order by EntityID desc"

			Dim myCommand As New SqlCommand(mySQLString, myConnection)

			If schoolID <> "" Then
				myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			End If
			If moduleID <> 0 Then
				myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			End If
			If levelID <> 0 Then
				myCommand.Parameters.Add("@LevelID", SqlDbType.Int, 4).Value = levelID
			End If
			If actionID <> 0 Then
				myCommand.Parameters.Add("@ActionID", SqlDbType.Int, 4).Value = actionID
			End If
			If createdByUser <> "" Then
				myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			End If
			myCommand.Parameters.Add("@StartTime", SqlDbType.DateTime, 8).Value = startTime
			myCommand.Parameters.Add("@EndTime", SqlDbType.DateTime, 8).Value = endTime
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Portal_Audit where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Audit where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

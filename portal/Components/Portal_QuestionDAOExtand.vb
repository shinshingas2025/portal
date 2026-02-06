Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_QuestionDAOExtand
		Inherits ASPNET.StarterKit.Portal.Portal_QuestionDAO
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select top " & rowCount & " * from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal searchDate As Date, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select top " & rowCount & " * from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID and EnableDate<=@SearchDate and DisableDate>=@SearchDate order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@SearchDate", SqlDbType.DateTime, 8).Value = searchDate
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalRow(ByVal schoolID As String, ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID", myConnection)
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
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select * from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal searchDate As Date) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select * from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID and EnableDate<=@SearchDate and DisableDate>=@SearchDate order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@SearchDate", SqlDbType.DateTime, 8).Value = searchDate
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select * from Portal_Question where EntityID=@EntityID"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace
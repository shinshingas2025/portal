Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class DMS_FolderDAOExtand
		Inherits DMS_FolderDAO
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal parentID As String, ByVal description As String, ByVal permission As String, ByVal password As String, ByVal modifierID As Integer, ByVal modifiedDate As Date, ByVal groupID As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update DMS_Folder set Name=@Name , ParentID=@ParentID , Description=@Description , Permission=@Permission , Password=@Password , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , GroupID=@GroupID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = description
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password
			myCommand.Parameters.Add("@ModifierID", SqlDbType.Int, 4).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal description As String, ByVal permission As String, ByVal password As String, ByVal modifierID As Integer, ByVal modifiedDate As Date, ByVal groupID As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update DMS_Folder set Name=@Name , Description=@Description , Permission=@Permission , Password=@Password , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , GroupID=@GroupID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = description
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password
			myCommand.Parameters.Add("@ModifierID", SqlDbType.Int, 4).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetTotalRowByParentIDAndName(ByVal parentID As String, ByVal name As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_Folder where ParentID=@ParentID and Name=@Name", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
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
		Public Overridable Function GetTotalRowByParentID(ByVal parentID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_Folder where ParentID=@ParentID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
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
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_Folder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByParentID(ByVal parentID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_Folder where ParentID=@ParentID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_Folder order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from DMS_Folder order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

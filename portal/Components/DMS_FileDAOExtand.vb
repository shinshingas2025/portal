Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class DMS_FileDAOExtand
		Inherits DMS_FileDAO
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal fileName As String, ByVal fileSize As Integer, ByVal folderID As String, ByVal description As String, ByVal metaData As String, ByVal permission As String, ByVal groupID As Integer, ByVal majorRevision As Integer, ByVal minorRevision As Integer, ByVal uRL As String, ByVal password As String, ByVal documentTypeID As String, ByVal fileDataID As String, ByVal flowTypeID As String, ByVal modifierID As Integer, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update DMS_File set Name=@Name , FileName=@FileName , FileSize=@FileSize , FolderID=@FolderID , Description=@Description , MetaData=@MetaData , Permission=@Permission , GroupID=@GroupID , MajorRevision=@MajorRevision , MinorRevision=@MinorRevision , URL=@URL , Password=@Password , DocumentTypeID=@DocumentTypeID , FileDataID=@FileDataID , FlowTypeID=@FlowTypeID , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar, 256).Value = fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int, 4).Value = fileSize
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = description
			myCommand.Parameters.Add("@MetaData", SqlDbType.NText, 16).Value = metaData
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID
			myCommand.Parameters.Add("@MajorRevision", SqlDbType.Int, 4).Value = majorRevision
			myCommand.Parameters.Add("@MinorRevision", SqlDbType.Int, 4).Value = minorRevision
			myCommand.Parameters.Add("@URL", SqlDbType.NVarChar, 1000).Value = uRL
			myCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password
			myCommand.Parameters.Add("@DocumentTypeID", SqlDbType.NVarChar, 16).Value = documentTypeID
			myCommand.Parameters.Add("@FileDataID", SqlDbType.NVarChar, 16).Value = fileDataID
			myCommand.Parameters.Add("@FlowTypeID", SqlDbType.NVarChar, 16).Value = flowTypeID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.Int, 4).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetEntitysByFolderIDAndNameAndVersion(ByVal folderID As String, ByVal name As String, ByVal majorRevision As Integer, ByVal minorRevision As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where FolderID=@FolderID and Name=@Name and MajorRevision=@MajorRevision and MinorRevision=@MinorRevision order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			myCommand.Parameters.Add("@MajorRevision", SqlDbType.Int, 4).Value = majorRevision
			myCommand.Parameters.Add("@MinorRevision", SqlDbType.Int, 4).Value = minorRevision
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByFolderIDAndName(ByVal folderID As String, ByVal name As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where FolderID=@FolderID and Name=@Name order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByFolderIDAndNameAndVersion(ByVal folderID As String, ByVal name As String, ByVal majorRevision As Integer, ByVal minorRevision As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_File where FolderID=@FolderID and Name=@Name and MajorRevision=@MajorRevision and MinorRevision=@MinorRevision", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = name
			myCommand.Parameters.Add("@MajorRevision", SqlDbType.Int, 4).Value = majorRevision
			myCommand.Parameters.Add("@MinorRevision", SqlDbType.Int, 4).Value = minorRevision
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
		Public Overridable Function GetTotalRowByFolderIDAndName(ByVal folderID As String, ByVal name As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_File where FolderID=@FolderID and Name=@Name", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
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
		Public Overridable Function GetTotalRowByFolderID(ByVal folderID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_File where FolderID=@FolderID", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
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
			Dim myCommand As New SqlCommand("select * from DMS_File where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByFolderID(ByVal folderID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where FolderID=@FolderID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar, 16).Value = folderID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from DMS_File order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

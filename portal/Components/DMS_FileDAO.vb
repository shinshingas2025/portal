Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class DMS_FileDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where  order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_File where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from DMS_File where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer,ByVal name As String,ByVal fileName As String,ByVal fileSize As Integer,ByVal folderID As String,ByVal description As String,ByVal metaData As String,ByVal permission As String,ByVal groupID As Integer,ByVal majorRevision As Integer,ByVal minorRevision As Integer,ByVal uRL As String,ByVal password As String,ByVal documentTypeID As String,ByVal fileDataID As String,ByVal flowTypeID As String,ByVal creatorID As Integer,ByVal modifierID As Integer,ByVal createdDate As Date,ByVal modifiedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into DMS_File ( EntityID,ItemID,Name,FileName,FileSize,FolderID,Description,MetaData,Permission,GroupID,MajorRevision,MinorRevision,URL,Password,DocumentTypeID,FileDataID,FlowTypeID,CreatorID,ModifierID,CreatedDate,ModifiedDate ) values ( @EntityID,@ItemID,@Name,@FileName,@FileSize,@FolderID,@Description,@MetaData,@Permission,@GroupID,@MajorRevision,@MinorRevision,@URL,@Password,@DocumentTypeID,@FileDataID,@FlowTypeID,@CreatorID,@ModifierID,@CreatedDate,@ModifiedDate )", myConnection)
			Dim today As Date = Now
			entityID=today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(),2) & Microsoft.VisualBasic.Right("00" & today.Day(),2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(8,8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar,256).Value=name
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar,256).Value=fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int,4).Value=fileSize
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar,16).Value=folderID
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar,1000).Value=description
			myCommand.Parameters.Add("@MetaData", SqlDbType.NText,16).Value=metaData
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@GroupID", SqlDbType.Int,4).Value=groupID
			myCommand.Parameters.Add("@MajorRevision", SqlDbType.Int,4).Value=majorRevision
			myCommand.Parameters.Add("@MinorRevision", SqlDbType.Int,4).Value=minorRevision
			myCommand.Parameters.Add("@URL", SqlDbType.NVarChar,1000).Value=uRL
			myCommand.Parameters.Add("@Password", SqlDbType.NVarChar,50).Value=password
			myCommand.Parameters.Add("@DocumentTypeID", SqlDbType.NVarChar,16).Value=documentTypeID
			myCommand.Parameters.Add("@FileDataID", SqlDbType.NVarChar,16).Value=fileDataID
			myCommand.Parameters.Add("@FlowTypeID", SqlDbType.NVarChar,16).Value=flowTypeID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.Int,4).Value=creatorID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.Int,4).Value=modifierID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal name As String,ByVal fileName As String,ByVal fileSize As Integer,ByVal folderID As String,ByVal description As String,ByVal metaData As String,ByVal permission As String,ByVal groupID As Integer,ByVal majorRevision As Integer,ByVal minorRevision As Integer,ByVal uRL As String,ByVal password As String,ByVal documentTypeID As String,ByVal fileDataID As String,ByVal flowTypeID As String,ByVal creatorID As Integer,ByVal modifierID As Integer,ByVal createdDate As Date,ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update DMS_File set Name=@Name , FileName=@FileName , FileSize=@FileSize , FolderID=@FolderID , Description=@Description , MetaData=@MetaData , Permission=@Permission , GroupID=@GroupID , MajorRevision=@MajorRevision , MinorRevision=@MinorRevision , URL=@URL , Password=@Password , DocumentTypeID=@DocumentTypeID , FileDataID=@FileDataID , FlowTypeID=@FlowTypeID , CreatorID=@CreatorID , ModifierID=@ModifierID , CreatedDate=@CreatedDate , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar,256).Value=name
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar,256).Value=fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int,4).Value=fileSize
			myCommand.Parameters.Add("@FolderID", SqlDbType.NVarChar,16).Value=folderID
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar,1000).Value=description
			myCommand.Parameters.Add("@MetaData", SqlDbType.NText,16).Value=metaData
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@GroupID", SqlDbType.Int,4).Value=groupID
			myCommand.Parameters.Add("@MajorRevision", SqlDbType.Int,4).Value=majorRevision
			myCommand.Parameters.Add("@MinorRevision", SqlDbType.Int,4).Value=minorRevision
			myCommand.Parameters.Add("@URL", SqlDbType.NVarChar,1000).Value=uRL
			myCommand.Parameters.Add("@Password", SqlDbType.NVarChar,50).Value=password
			myCommand.Parameters.Add("@DocumentTypeID", SqlDbType.NVarChar,16).Value=documentTypeID
			myCommand.Parameters.Add("@FileDataID", SqlDbType.NVarChar,16).Value=fileDataID
			myCommand.Parameters.Add("@FlowTypeID", SqlDbType.NVarChar,16).Value=flowTypeID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.Int,4).Value=creatorID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.Int,4).Value=modifierID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL="select max(EntityID) from DMS_File where substring(EntityID,1,8)='" & entityID.substring(0,8) & "'"
			Dim myCommand As New SqlCommand(selectSQL,myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID=CStr(myReader.GetValue(0))
					maxID=maxID.substring(8,8)
				Catch ex As System.InvalidCastException
					maxID="00000000"
				End Try
			End While
			myReader.Close()
			valResult=CInt(Val("&H"&maxID))
			valResult=valResult+1
			Return entityID.substring(0,8) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)),8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_File", myConnection)
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
	End Class
End Namespace

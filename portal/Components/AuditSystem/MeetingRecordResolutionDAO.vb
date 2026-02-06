Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class MeetingRecordResolutionDAO
		Public Overridable Function GetEntity(ByVal meetingRecordID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecordResolution where MeetingRecordID=@MeetingRecordID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal meetingRecordID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecordResolution where MeetingRecordID=@MeetingRecordID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecordResolution where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from MeetingRecordResolution where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal meetingRecordID As String, ByVal itemID As Integer, ByVal permission As String, ByVal permissionGroup As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainOfficeID As String, ByVal assistOfficeID As String, ByVal sketchID As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal state As Integer, ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into MeetingRecordResolution ( EntityID,MeetingRecordID,ItemID,Permission,PermissionGroup,ResolutionNumber,Content,MainOfficeID,AssistOfficeID,SketchID,CreatorID,CreatedDate,ModifierID,ModifiedDate,State,DeletedDate ) values ( @EntityID,@MeetingRecordID,@ItemID,@Permission,@PermissionGroup,@ResolutionNumber,@Content,@MainOfficeID,@AssistOfficeID,@SketchID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@State,@DeletedDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000000" & meetingRecordID, 32) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(32, 8)))
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@SketchID", SqlDbType.NVarChar, 24).Value = sketchID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal meetingRecordID As String, ByVal permission As String, ByVal permissionGroup As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainOfficeID As String, ByVal assistOfficeID As String, ByVal sketchID As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal state As Integer, ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MeetingRecordResolution set MeetingRecordID=@MeetingRecordID , Permission=@Permission , PermissionGroup=@PermissionGroup , ResolutionNumber=@ResolutionNumber , Content=@Content , MainOfficeID=@MainOfficeID , AssistOfficeID=@AssistOfficeID , SketchID=@SketchID , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@SketchID", SqlDbType.NVarChar, 24).Value = sketchID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from MeetingRecordResolution where substring(EntityID,1,32)='" & entityID.Substring(0, 32) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(32, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 32) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MeetingRecordResolution", myConnection)
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

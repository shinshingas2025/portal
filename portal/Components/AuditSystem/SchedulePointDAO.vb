Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class SchedulePointDAO
		Public Overridable Function GetEntity(ByVal EntityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from SchedulePoint where EntityID=@EntityID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = EntityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal DateS As String, ByVal DateE As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from SchedulePoint where StartDate between @DateS and @DateE order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@DateS", SqlDbType.NVarChar, 10).Value = DateS
			myCommand.Parameters.Add("@DateE", SqlDbType.NVarChar, 10).Value = DateE
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from SchedulePoint where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from SchedulePoint where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer, ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal lawAndWork As String, ByVal national As String, ByVal activeMeeting As String, ByVal note1 As String, ByVal note2 As String, ByVal note3 As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into SchedulePoint ( EntityID,ItemID,ScheduleTypeID,EventTypeID,UserID,StartDate,EndDate,LevelID,Title,Description,Note,KeyWord,CreatorID,ModifierID,Permission,PermissionGroup,State,DeletedDate,LawAndWork,Nationals,ActiveMeeting,Note1,Note2,Note3 ) values ( @EntityID,@ItemID,@ScheduleTypeID,@EventTypeID,@UserID,@StartDate,@EndDate,@LevelID,@Title,@Description,@Note,@KeyWord,@CreatorID,@ModifierID,@Permission,@PermissionGroup,@State,@DeletedDate,@LawAndWork,@National,@ActiveMeeting,@Note1,@Note2,@Note3 )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = startDate
			myCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = endDate
			myCommand.Parameters.Add("@LevelID", SqlDbType.Int, 4).Value = levelID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1024).Value = description
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 256).Value = keyWord
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			'	myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			'	myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@LawAndWork", SqlDbType.NVarChar, 800).Value = lawAndWork
			myCommand.Parameters.Add("@National", SqlDbType.NVarChar, 800).Value = national
			myCommand.Parameters.Add("@ActiveMeeting", SqlDbType.NVarChar, 800).Value = activeMeeting
			myCommand.Parameters.Add("@Note1", SqlDbType.NVarChar, 256).Value = note1
			myCommand.Parameters.Add("@Note2", SqlDbType.NVarChar, 256).Value = note2
			myCommand.Parameters.Add("@Note3", SqlDbType.NVarChar, 256).Value = note3
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal lawAndWork As String, ByVal national As String, ByVal activeMeeting As String, ByVal note1 As String, ByVal note2 As String, ByVal note3 As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update SchedulePoint set ScheduleTypeID=@ScheduleTypeID , EventTypeID=@EventTypeID , StartDate=@StartDate , EndDate=@EndDate , LevelID=@LevelID , Title=@Title , Description=@Description , Note=@Note , KeyWord=@KeyWord ,  ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup ,  LawAndWork=@LawAndWork , Nationals=@National , ActiveMeeting=@ActiveMeeting , Note1=@Note1 , Note2=@Note2 , Note3=@Note3 where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
	
			myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = startDate
			myCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = endDate
			myCommand.Parameters.Add("@LevelID", SqlDbType.Int, 4).Value = levelID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1024).Value = description
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 256).Value = keyWord


			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup


			myCommand.Parameters.Add("@LawAndWork", SqlDbType.NVarChar, 800).Value = lawAndWork
			myCommand.Parameters.Add("@National", SqlDbType.NVarChar, 800).Value = national
			myCommand.Parameters.Add("@ActiveMeeting", SqlDbType.NVarChar, 800).Value = activeMeeting
			myCommand.Parameters.Add("@Note1", SqlDbType.NVarChar, 256).Value = note1
			myCommand.Parameters.Add("@Note2", SqlDbType.NVarChar, 256).Value = note2
			myCommand.Parameters.Add("@Note3", SqlDbType.NVarChar, 256).Value = note3
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from SchedulePoint where substring(EntityID,1,8)='" & entityID.Substring(0, 8) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(8, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 8) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from SchedulePoint", myConnection)
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

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO

	Public Class EveryDayScheduleDAO
		Inherits ScheduleDAO
		Public Overloads Function InsertEntity(ByVal itemID As Integer, ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal notifyday As Integer) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into Schedule ( EntityID,ItemID,ScheduleTypeID,EventTypeID,UserID,StartDate,EndDate,LevelID,Title,Description,Note,KeyWord,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ,notifyday) values ( @EntityID,@ItemID,@ScheduleTypeID,@EventTypeID,@UserID,@StartDate,@EndDate,@LevelID,@Title,@Description,@Note,@KeyWord,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate,@notifyday )", myConnection)
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
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@notifyday", SqlDbType.Int, 4).Value = notifyday
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function

		Public Function GetAlertEventByDay(ByVal UserID As String) As DataSet

			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim uid As Integer
			uid = GetUIDbyUserID(UserID)
			Dim myCommand As New SqlCommand(" SELECT DATEDIFF(dd, GETDATE(), EndDate) AS oday,convert(char(4),year( enddate))+'/'+rtrim(convert (char(2),month(enddate)))+'/'+ rtrim(convert(char(2),day(enddate))) deadline, * FROM Schedule WHERE EventTypeID=2 and state=0 and  UserID=" & uid & " and  (DATEDIFF(dd, GETDATE(), EndDate) <= NotifyDay) order by enddate desc ", myConnection)
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = uid
			Dim myAdapter As New SqlDataAdapter(myCommand)

			Dim myDataSet As New DataSet

			myAdapter.Fill(myDataSet)

			Return myDataSet

		End Function

		Public Sub DeleteAlertEventByDay(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("Update Schedule set state=1,deleteddate=getdate() where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub

		Public Function GetUIDbyUserID(ByVal UserID As String) As Integer

			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))

			Dim myCommand As New SqlCommand(" SELECT * FROM sysCommunity WHERE  objvalue='" & UserID & "'", myConnection)
			myCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 20).Value = UserID
			Dim myAdapter As New SqlDataAdapter(myCommand)

			Dim myDataSet As New DataSet

			myAdapter.Fill(myDataSet)
			If myDataSet.Tables(0).Rows.Count > 0 Then
				Return CType(myDataSet.Tables(0).Rows(0).Item("objid"), Integer)
			End If


		End Function
	End Class

End Namespace
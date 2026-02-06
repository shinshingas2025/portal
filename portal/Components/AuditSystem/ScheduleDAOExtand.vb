Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ScheduleDAOExtand
		Inherits ScheduleDAO
		Public Overloads Function GetEntitysByScheduleTypeIDAndEventTypeIDAndUserIDAndQueryString(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal queryString As String, ByVal startBound As Date, ByVal endBound As Date) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID and UserID=@UserID and StartDate<=@EndBound and EndDate>=@StartBound and (Title like @QueryString1 or Description like @QueryString2 or Note like @QueryString3) order by ItemID", myConnection)
			queryString = "%" & queryString & "%"
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			myCommand.Parameters.Add("@StartBound", SqlDbType.DateTime, 8).Value = startBound
			myCommand.Parameters.Add("@EndBound", SqlDbType.DateTime, 8).Value = endBound
			myCommand.Parameters.Add("@QueryString1", SqlDbType.NVarChar, queryString.Length).Value = queryString
			myCommand.Parameters.Add("@QueryString2", SqlDbType.NVarChar, queryString.Length).Value = queryString
			myCommand.Parameters.Add("@QueryString3", SqlDbType.NVarChar, queryString.Length).Value = queryString
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID and UserID=@UserID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startBound As Date, ByVal endBound As Date) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID and UserID=@UserID and StartDate<=@EndBound and EndDate>=@StartBound order by ItemID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			myCommand.Parameters.Add("@StartBound", SqlDbType.DateTime, 8).Value = startBound
			myCommand.Parameters.Add("@EndBound", SqlDbType.DateTime, 8).Value = endBound
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByScheduleTypeIDAndEventTypeIDAndUserID(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startBound As Date, ByVal endBound As Date, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID and UserID=@UserID and StartDate<=@EndBound and EndDate>=@StartBound order by ItemID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			myCommand.Parameters.Add("@StartBound", SqlDbType.DateTime, 8).Value = startBound
			myCommand.Parameters.Add("@EndBound", SqlDbType.DateTime, 8).Value = endBound
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByScheduleTypeIDAndEventTypeIDAndUserIDAndQueryString(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal queryString As String, ByVal startBound As Date, ByVal endBound As Date) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID and UserID=@UserID and StartDate<=@EndBound and EndDate>=@StartBound and (Title like @QueryString1 or Description like @QueryString2 or Note like @QueryString3)", myConnection)
			queryString = "%" & queryString & "%"
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID
			myCommand.Parameters.Add("@StartBound", SqlDbType.DateTime, 8).Value = startBound
			myCommand.Parameters.Add("@EndBound", SqlDbType.DateTime, 8).Value = endBound
			myCommand.Parameters.Add("@QueryString1", SqlDbType.NVarChar, queryString.Length).Value = queryString
			myCommand.Parameters.Add("@QueryString2", SqlDbType.NVarChar, queryString.Length).Value = queryString
			myCommand.Parameters.Add("@QueryString3", SqlDbType.NVarChar, queryString.Length).Value = queryString
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
		Public Overridable Function GetEntitysByScheduleTypeIDAndEventTypeID(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where ScheduleTypeID=@ScheduleTypeID and EventTypeID=@EventTypeID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			myCommand.Parameters.Add("@EventTypeID", SqlDbType.Int, 4).Value = eventTypeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByScheduleTypeID(ByVal scheduleTypeID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where ScheduleTypeID=@ScheduleTypeID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ScheduleTypeID", SqlDbType.Int, 4).Value = scheduleTypeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Schedule where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function InsertEntity(ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into Schedule ( EntityID,ItemID,ScheduleTypeID,EventTypeID,UserID,StartDate,EndDate,LevelID,Title,Description,Note,KeyWord ) values ( @EntityID,@ItemID,@ScheduleTypeID,@EventTypeID,@UserID,@StartDate,@EndDate,@LevelID,@Title,@Description,@Note,@KeyWord )", myConnection)
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
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Schedule set ScheduleTypeID=@ScheduleTypeID , EventTypeID=@EventTypeID , UserID=@UserID , StartDate=@StartDate , EndDate=@EndDate , LevelID=@LevelID , Title=@Title , Description=@Description , Note=@Note , KeyWord=@KeyWord where EntityID=@EntityID", myConnection)
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
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal scheduleTypeID As Integer, ByVal eventTypeID As Integer, ByVal userID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal levelID As Integer, ByVal title As String, ByVal description As String, ByVal note As String, ByVal keyWord As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Schedule set ScheduleTypeID=@ScheduleTypeID , EventTypeID=@EventTypeID , UserID=@UserID , StartDate=@StartDate , EndDate=@EndDate , LevelID=@LevelID , Title=@Title , Description=@Description , Note=@Note , KeyWord=@KeyWord , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
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
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class MeetingRecordDAOExtand
		Inherits MeetingRecordDAO
		Public Overridable Function GetTotalRowByQueryString(ByVal queryString As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim sqlString As String = ""
			sqlString = sqlString & "SELECT	count(*) "
			sqlString = sqlString & "FROM	MeetingRecord Record "
			sqlString = sqlString & "	INNER JOIN MeetingRecordResolution Resolution ON Record.EntityID=Resolution.MeetingRecordID "
			sqlString = sqlString & "WHERE	Resolution.Content like @QueryString "
			queryString = "%" & queryString & "%"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@QueryString", SqlDbType.NVarChar, queryString.Length).Value = queryString
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
		Public Overridable Function GetEntitysByQueryString(ByVal queryString As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim sqlString As String = ""
			sqlString = sqlString & "SELECT	top " & rowCount & " Code1.Name AS MeetingTypeName, "
			sqlString = sqlString & "	Record.TypeID AS MeetingTypeID, "
			sqlString = sqlString & "	Record.MeetingNumber AS MeetingNumber, "
			sqlString = sqlString & "	Record.MeetingDate AS MeetingDate, "
			sqlString = sqlString & " Record.Title AS Title, "
			sqlString = sqlString & "	Resolution.ResolutionNumber AS ResolutionNumber, "
			sqlString = sqlString & "	Resolution.Content AS ResolutionContent, "
			sqlString = sqlString & "	Code2.Name AS MainOfficeName, "
			sqlString = sqlString & " Record.EntityID as EntityID "
			sqlString = sqlString & "FROM	MeetingRecord Record "
			sqlString = sqlString & "	INNER JOIN MeetingRecordResolution Resolution ON Record.EntityID=Resolution.MeetingRecordID "
			sqlString = sqlString & "	LEFT OUTER JOIN NormalCode Code1 ON Code1.EntityID=Record.TypeID "
			sqlString = sqlString & "	LEFT OUTER JOIN NormalCode Code2 ON Code2.EntityID=Resolution.MainOfficeID "
			sqlString = sqlString & "WHERE	Resolution.Content like @QueryString "
			queryString = "%" & queryString & "%"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@QueryString", SqlDbType.NVarChar, queryString.Length).Value = queryString
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByQueryString(ByVal queryString As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim sqlString As String = ""
			sqlString = sqlString & "SELECT	Code1.Name AS MeetingTypeName, "
			sqlString = sqlString & "	Record.TypeID AS MeetingTypeID, "
			sqlString = sqlString & "	Record.MeetingNumber AS MeetingNumber, "
			sqlString = sqlString & "	Record.MeetingDate AS MeetingDate, "
			sqlString = sqlString & " Record.Title AS Title, "
			sqlString = sqlString & "	Resolution.ResolutionNumber AS ResolutionNumber, "
			sqlString = sqlString & "	Resolution.Content AS ResolutionContent, "
			sqlString = sqlString & "	Code2.Name AS MainOfficeName, "
			sqlString = sqlString & " Record.EntityID as EntityID "
			sqlString = sqlString & "FROM	MeetingRecord Record "
			sqlString = sqlString & "	INNER JOIN MeetingRecordResolution Resolution ON Record.EntityID=Resolution.MeetingRecordID "
			sqlString = sqlString & "	LEFT OUTER JOIN NormalCode Code1 ON Code1.EntityID=Record.TypeID "
			sqlString = sqlString & "	LEFT OUTER JOIN NormalCode Code2 ON Code2.EntityID=Resolution.MainOfficeID "
			sqlString = sqlString & "WHERE	Resolution.Content like @QueryString "
			queryString = "%" & queryString & "%"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@QueryString", SqlDbType.NVarChar, queryString.Length).Value = queryString
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetResolutionContentByResolutionNumberAndMeetingNumber(ByVal resolutionNumber As String, ByVal meetingNumber As Integer) As String
			Dim valResult As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select MeetingRecordResolution.Content from MeetingRecord inner join MeetingRecordResolution on MeetingRecord.EntityID=MeetingRecordResolution.MeetingRecordID where MeetingRecord.MeetingNumber=@MeetingNumber and MeetingRecordResolution.ResolutionNumber=@ResolutionNumber", myConnection)
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
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
			myReader.Close()
			Return valResult
		End Function
		Public Overridable Function GetTotalRowByResolutionNumberAndMeetingNumber(ByVal resolutionNumber As String, ByVal meetingNumber As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MeetingRecord inner join MeetingRecordResolution on MeetingRecord.EntityID=MeetingRecordResolution.MeetingRecordID where MeetingRecord.MeetingNumber=@MeetingNumber and MeetingRecordResolution.ResolutionNumber=@ResolutionNumber", myConnection)
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
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
		Public Overridable Function GetTotalRowByTypeIDAndMeetingNumber(ByVal typeID As String, ByVal meetingNumber As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MeetingRecord where TypeID=@TypeID and MeetingNumber=@MeetingNumber", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
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
		Public Overridable Function GetEntityIDByTypeIDAndMeetingNumber(ByVal typeID As String, ByVal meetingNumber As Integer) As String
			Dim valResult As String = ""
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID from MeetingRecord where TypeID=@TypeID and MeetingNumber=@MeetingNumber", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
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
			myReader.Close()
			Return valResult
		End Function
		Public Overridable Function GetItemIDByTypeID(ByVal typeID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID,ItemID from MeetingRecord where TypeID=@TypeID order by ItemID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByTypeID(ByVal typeID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MeetingRecord where TypeID=@TypeID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
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
		Public Overridable Function GetEntitysByTypeID(ByVal typeID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from MeetingRecord where TypeID=@TypeID order by ItemID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByTypeID(ByVal typeID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecord where TypeID=@TypeID order by ItemID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecord where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from MeetingRecord order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal typeID As String, ByVal meetingNumber As Integer, ByVal meetingDate As Date, ByVal startTime As String, ByVal endTime As String, ByVal placeID As String, ByVal presentPerson As String, ByVal observer As String, ByVal chairPersonID As String, ByVal scribeID As String, ByVal title As String, ByVal placeName As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MeetingRecord set TypeID=@TypeID , MeetingNumber=@MeetingNumber , MeetingDate=@MeetingDate , StartTime=@StartTime , EndTime=@EndTime , PlaceID=@PlaceID , PresentPerson=@PresentPerson , Observer=@Observer , ChairPersonID=@ChairPersonID , ScribeID=@ScribeID , Title=@Title , PlaceName=@PlaceName where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
			myCommand.Parameters.Add("@MeetingDate", SqlDbType.DateTime, 8).Value = meetingDate
			myCommand.Parameters.Add("@StartTime", SqlDbType.NVarChar, 4).Value = startTime
			myCommand.Parameters.Add("@EndTime", SqlDbType.NVarChar, 4).Value = endTime
			myCommand.Parameters.Add("@PlaceID", SqlDbType.NVarChar, 24).Value = placeID
			myCommand.Parameters.Add("@PresentPerson", SqlDbType.NVarChar, 1024).Value = presentPerson
			myCommand.Parameters.Add("@Observer", SqlDbType.NVarChar, 1024).Value = observer
			myCommand.Parameters.Add("@ChairPersonID", SqlDbType.NVarChar, 24).Value = chairPersonID
			myCommand.Parameters.Add("@ScribeID", SqlDbType.NVarChar, 24).Value = scribeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 256).Value = title
			myCommand.Parameters.Add("@PlaceName", SqlDbType.NVarChar, 64).Value = placeName
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal typeID As String, ByVal meetingNumber As Integer, ByVal meetingDate As Date, ByVal startTime As String, ByVal endTime As String, ByVal placeID As String, ByVal presentPerson As String, ByVal observer As String, ByVal chairPersonID As String, ByVal scribeID As String, ByVal title As String, ByVal placeName As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MeetingRecord set TypeID=@TypeID , MeetingNumber=@MeetingNumber , MeetingDate=@MeetingDate , StartTime=@StartTime , EndTime=@EndTime , PlaceID=@PlaceID , PresentPerson=@PresentPerson , Observer=@Observer , ChairPersonID=@ChairPersonID , ScribeID=@ScribeID , Title=@Title , PlaceName=@PlaceName , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
			myCommand.Parameters.Add("@MeetingDate", SqlDbType.DateTime, 8).Value = meetingDate
			myCommand.Parameters.Add("@StartTime", SqlDbType.NVarChar, 4).Value = startTime
			myCommand.Parameters.Add("@EndTime", SqlDbType.NVarChar, 4).Value = endTime
			myCommand.Parameters.Add("@PlaceID", SqlDbType.NVarChar, 24).Value = placeID
			myCommand.Parameters.Add("@PresentPerson", SqlDbType.NVarChar, 1024).Value = presentPerson
			myCommand.Parameters.Add("@Observer", SqlDbType.NVarChar, 1024).Value = observer
			myCommand.Parameters.Add("@ChairPersonID", SqlDbType.NVarChar, 24).Value = chairPersonID
			myCommand.Parameters.Add("@ScribeID", SqlDbType.NVarChar, 24).Value = scribeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 256).Value = title
			myCommand.Parameters.Add("@PlaceName", SqlDbType.NVarChar, 64).Value = placeName
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal typeID As String, ByVal meetingNumber As Integer, ByVal meetingDate As Date, ByVal startTime As String, ByVal endTime As String, ByVal placeID As String, ByVal presentPerson As String, ByVal observer As String, ByVal chairPersonID As String, ByVal scribeID As String, ByVal title As String, ByVal placeName As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into MeetingRecord ( EntityID,TypeID,ItemID,MeetingNumber,MeetingDate,StartTime,EndTime,PlaceID,PresentPerson,Observer,ChairPersonID,ScribeID,Title,PlaceName ) values ( @EntityID,@TypeID,@ItemID,@MeetingNumber,@MeetingDate,@StartTime,@EndTime,@PlaceID,@PresentPerson,@Observer,@ChairPersonID,@ScribeID,@Title,@PlaceName )", myConnection)
			entityID = Microsoft.VisualBasic.Right("000000000000000000000000" & typeID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(24, 8)))
			myCommand.Parameters.Add("@MeetingNumber", SqlDbType.Int, 4).Value = meetingNumber
			myCommand.Parameters.Add("@MeetingDate", SqlDbType.DateTime, 8).Value = meetingDate
			myCommand.Parameters.Add("@StartTime", SqlDbType.NVarChar, 4).Value = startTime
			myCommand.Parameters.Add("@EndTime", SqlDbType.NVarChar, 4).Value = endTime
			myCommand.Parameters.Add("@PlaceID", SqlDbType.NVarChar, 24).Value = placeID
			myCommand.Parameters.Add("@PresentPerson", SqlDbType.NVarChar, 1024).Value = presentPerson
			myCommand.Parameters.Add("@Observer", SqlDbType.NVarChar, 1024).Value = observer
			myCommand.Parameters.Add("@ChairPersonID", SqlDbType.NVarChar, 24).Value = chairPersonID
			myCommand.Parameters.Add("@ScribeID", SqlDbType.NVarChar, 24).Value = scribeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 256).Value = title
			myCommand.Parameters.Add("@PlaceName", SqlDbType.NVarChar, 64).Value = placeName
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class MeetingRecordResolutionDAOExtand
		Inherits MeetingRecordResolutionDAO
		Public Overridable Function GetMaxResolutionNumber(ByVal resolutionNumber As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(ResolutionNumber) from MeetingRecordResolution where substring(ResolutionNumber,1,14)='" & resolutionNumber.Substring(0, 14) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(14, 2)
				Catch ex As System.InvalidCastException
					maxID = "00"
				End Try
			End While
			myReader.Close()
			valResult = CInt(maxID)
			valResult = valResult + 1
			Return resolutionNumber.Substring(0, 14) & Microsoft.VisualBasic.Right("00" & CStr(valResult), 2)
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecordResolution where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByMeetingRecordID(ByVal meetingRecordID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MeetingRecordResolution where MeetingRecordID=@MeetingRecordID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
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
		Public Overridable Function GetEntitysByMeetingRecordID(ByVal meetingRecordID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MeetingRecordResolution where MeetingRecordID=@MeetingRecordID order by ItemID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal meetingRecordID As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainOfficeID As String, ByVal assistOfficeID As String, ByVal sketchID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MeetingRecordResolution set MeetingRecordID=@MeetingRecordID , ResolutionNumber=@ResolutionNumber , Content=@Content , MainOfficeID=@MainOfficeID , AssistOfficeID=@AssistOfficeID , SketchID=@SketchID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@SketchID", SqlDbType.NVarChar, 24).Value = sketchID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal meetingRecordID As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainOfficeID As String, ByVal assistOfficeID As String, ByVal sketchID As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MeetingRecordResolution set MeetingRecordID=@MeetingRecordID , ResolutionNumber=@ResolutionNumber , Content=@Content , MainOfficeID=@MainOfficeID , AssistOfficeID=@AssistOfficeID , SketchID=@SketchID , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@SketchID", SqlDbType.NVarChar, 24).Value = sketchID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal meetingRecordID As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainOfficeID As String, ByVal assistOfficeID As String, ByVal sketchID As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into MeetingRecordResolution ( EntityID,MeetingRecordID,ItemID,ResolutionNumber,Content,MainOfficeID,AssistOfficeID,SketchID ) values ( @EntityID,@MeetingRecordID,@ItemID,@ResolutionNumber,@Content,@MainOfficeID,@AssistOfficeID,@SketchID )", myConnection)
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000000" & meetingRecordID, 32) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(32, 8)))
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@SketchID", SqlDbType.NVarChar, 24).Value = sketchID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

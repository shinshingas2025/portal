Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyLawCheckFormDAOExtand
		Inherits PolicyLawCheckFormDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntityID() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID from PolicyLawCheckForm order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from PolicyLawCheckForm order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByLawID(ByVal lawID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyLawCheckForm where LawID=@LawID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
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
		Public Overridable Function GetItemID() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select ItemID from PolicyLawCheckForm order by ItemID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByLawID(ByVal lawID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from PolicyLawCheckForm where LawID=@LawID order by EntityID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByLawID(ByVal lawID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where LawID=@LawID order by EntityID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByMeetingRecordID(ByVal meetingRecordID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyLawCheckForm where MeetingRecordID=@MeetingRecordID", myConnection)
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
		Public Overloads Function GetEntitysByMeetingRecordID(ByVal meetingRecordID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from PolicyLawCheckForm where MeetingRecordID=@MeetingRecordID order by EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByMeetingRecordID(ByVal meetingRecordID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where MeetingRecordID=@MeetingRecordID order by EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal meetingRecordID As String, ByVal lawID As String, ByVal cause As String, ByVal managementInstitutionID As String, ByVal undertakerID As String, ByVal documentNumber As String, ByVal signID As String, ByVal concern As String, ByVal draftID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyLawCheckForm set MeetingRecordID=@MeetingRecordID , LawID=@LawID , Cause=@Cause , ManagementInstitutionID=@ManagementInstitutionID , UndertakerID=@UndertakerID , DocumentNumber=@DocumentNumber , SignID=@SignID , Concern=@Concern , DraftID=@DraftID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@Cause", SqlDbType.NVarChar, 256).Value = cause
			myCommand.Parameters.Add("@ManagementInstitutionID", SqlDbType.NVarChar, 24).Value = managementInstitutionID
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@SignID", SqlDbType.NVarChar, 24).Value = signID
			myCommand.Parameters.Add("@Concern", SqlDbType.NVarChar, 256).Value = concern
			myCommand.Parameters.Add("@DraftID", SqlDbType.NVarChar, 24).Value = draftID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal meetingRecordID As String, ByVal lawID As String, ByVal cause As String, ByVal managementInstitutionID As String, ByVal undertakerID As String, ByVal documentNumber As String, ByVal signID As String, ByVal concern As String, ByVal draftID As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyLawCheckForm set MeetingRecordID=@MeetingRecordID , LawID=@LawID , Cause=@Cause , ManagementInstitutionID=@ManagementInstitutionID , UndertakerID=@UndertakerID , DocumentNumber=@DocumentNumber , SignID=@SignID , Concern=@Concern , DraftID=@DraftID , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@Cause", SqlDbType.NVarChar, 256).Value = cause
			myCommand.Parameters.Add("@ManagementInstitutionID", SqlDbType.NVarChar, 24).Value = managementInstitutionID
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@SignID", SqlDbType.NVarChar, 24).Value = signID
			myCommand.Parameters.Add("@Concern", SqlDbType.NVarChar, 256).Value = concern
			myCommand.Parameters.Add("@DraftID", SqlDbType.NVarChar, 24).Value = draftID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal meetingRecordID As String, ByVal lawID As String, ByVal cause As String, ByVal managementInstitutionID As String, ByVal undertakerID As String, ByVal documentNumber As String, ByVal signID As String, ByVal concern As String, ByVal draftID As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyLawCheckForm ( EntityID,ItemID,MeetingRecordID,LawID,Cause,ManagementInstitutionID,UndertakerID,DocumentNumber,SignID,Concern,DraftID ) values ( @EntityID,@ItemID,@MeetingRecordID,@LawID,@Cause,@ManagementInstitutionID,@UndertakerID,@DocumentNumber,@SignID,@Concern,@DraftID )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar, 32).Value = meetingRecordID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@Cause", SqlDbType.NVarChar, 256).Value = cause
			myCommand.Parameters.Add("@ManagementInstitutionID", SqlDbType.NVarChar, 24).Value = managementInstitutionID
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@SignID", SqlDbType.NVarChar, 24).Value = signID
			myCommand.Parameters.Add("@Concern", SqlDbType.NVarChar, 256).Value = concern
			myCommand.Parameters.Add("@DraftID", SqlDbType.NVarChar, 24).Value = draftID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

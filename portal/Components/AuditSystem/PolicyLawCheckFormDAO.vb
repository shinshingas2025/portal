Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyLawCheckFormDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		'Public Overridable Function GetEntitys(ByVal itemID As Integer) As DataSet
		'	Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
		'	Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where ItemID=@ItemID order by EntityID desc", myConnection)
		'	myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
		'	Dim myAdapter As New SqlDataAdapter(myCommand)
		'	Dim myDataSet As New DataSet
		'	myAdapter.Fill(myDataSet)
		'	Return myDataSet
		'End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawCheckForm where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from PolicyLawCheckForm where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer,ByVal meetingRecordID As String,ByVal lawID As String,ByVal cause As String,ByVal managementInstitutionID As String,ByVal undertakerID As String,ByVal documentNumber As String,ByVal signID As String,ByVal concern As String,ByVal draftID As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyLawCheckForm ( EntityID,ItemID,MeetingRecordID,LawID,Cause,ManagementInstitutionID,UndertakerID,DocumentNumber,SignID,Concern,DraftID,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ) values ( @EntityID,@ItemID,@MeetingRecordID,@LawID,@Cause,@ManagementInstitutionID,@UndertakerID,@DocumentNumber,@SignID,@Concern,@DraftID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate )", myConnection)
			Dim today As Date = Now
			entityID=today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(),2) & Microsoft.VisualBasic.Right("00" & today.Day(),2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(8,8)))
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar,32).Value=meetingRecordID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar,16).Value=lawID
			myCommand.Parameters.Add("@Cause", SqlDbType.NVarChar,256).Value=cause
			myCommand.Parameters.Add("@ManagementInstitutionID", SqlDbType.NVarChar,24).Value=managementInstitutionID
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar,24).Value=undertakerID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar,32).Value=documentNumber
			myCommand.Parameters.Add("@SignID", SqlDbType.NVarChar,24).Value=signID
			myCommand.Parameters.Add("@Concern", SqlDbType.NVarChar,256).Value=concern
			myCommand.Parameters.Add("@DraftID", SqlDbType.NVarChar,24).Value=draftID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal meetingRecordID As String,ByVal lawID As String,ByVal cause As String,ByVal managementInstitutionID As String,ByVal undertakerID As String,ByVal documentNumber As String,ByVal signID As String,ByVal concern As String,ByVal draftID As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyLawCheckForm set MeetingRecordID=@MeetingRecordID , LawID=@LawID , Cause=@Cause , ManagementInstitutionID=@ManagementInstitutionID , UndertakerID=@UndertakerID , DocumentNumber=@DocumentNumber , SignID=@SignID , Concern=@Concern , DraftID=@DraftID , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@MeetingRecordID", SqlDbType.NVarChar,32).Value=meetingRecordID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar,16).Value=lawID
			myCommand.Parameters.Add("@Cause", SqlDbType.NVarChar,256).Value=cause
			myCommand.Parameters.Add("@ManagementInstitutionID", SqlDbType.NVarChar,24).Value=managementInstitutionID
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar,24).Value=undertakerID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar,32).Value=documentNumber
			myCommand.Parameters.Add("@SignID", SqlDbType.NVarChar,24).Value=signID
			myCommand.Parameters.Add("@Concern", SqlDbType.NVarChar,256).Value=concern
			myCommand.Parameters.Add("@DraftID", SqlDbType.NVarChar,24).Value=draftID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL="select max(EntityID) from PolicyLawCheckForm where substring(EntityID,1,8)='" & entityID.substring(0,8) & "'"
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
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyLawCheckForm", myConnection)
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

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class AffairProcessCheckFormDAO
		Public Overridable Function GetEntity(ByVal groupID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from AffairProcessCheckForm where GroupID=@GroupID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar,24).Value=groupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal groupID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from AffairProcessCheckForm where GroupID=@GroupID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar,24).Value=groupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from AffairProcessCheckForm where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,32).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from AffairProcessCheckForm where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,32).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal groupID As String, ByVal itemID As Integer, ByVal permissionGroup As String, ByVal permission As String, ByVal affairID As String, ByVal priorityID As String, ByVal mainOfficeID As String, ByVal mainBranchID As String, ByVal mainBranchUndertakerID As String, ByVal assistOfficeID As String, ByVal assistBranchID As String, ByVal associationNumber As String, ByVal associationMeetingNumber As Integer, ByVal associationAffair As String, ByVal associationDate As Date, ByVal associationForecastDate As Date, ByVal associationStateID As String, ByVal councilNumber As String, ByVal councilMeetingNumber As Integer, ByVal councilAffair As String, ByVal councilDate As Date, ByVal councilForecastDate As Date, ByVal councilStateID As String, ByVal bureauNumber As String, ByVal bureauMeetingNumber As Integer, ByVal bureauAffair As String, ByVal bureauDate As Date, ByVal bureauForecastDate As Date, ByVal bureauStateID As String, ByVal sectionNumber As String, ByVal sectionMeetingNumber As Integer, ByVal sectionAffair As String, ByVal sectionDate As Date, ByVal sectionForecastDate As Date, ByVal sectionStateID As String,byval resolutionID as string, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal state As Integer, ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into AffairProcessCheckForm ( EntityID,GroupID,ItemID,PermissionGroup,Permission,AffairID,PriorityID,MainOfficeID,MainBranchID,MainBranchUndertakerID,AssistOfficeID,AssistBranchID,AssociationNumber,AssociationMeetingNumber,AssociationAffair,AssociationDate,AssociationForecastDate,AssociationStateID,CouncilNumber,CouncilMeetingNumber,CouncilAffair,CouncilDate,CouncilForecastDate,CouncilStateID,BureauNumber,BureauMeetingNumber,BureauAffair,BureauDate,BureauForecastDate,BureauStateID,SectionNumber,SectionMeetingNumber,SectionAffair,SectionDate,SectionForecastDate,SectionStateID,ResolutionID,CreatorID,CreatedDate,ModifierID,ModifiedDate,State,DeletedDate ) values ( @EntityID,@GroupID,@ItemID,@PermissionGroup,@Permission,@AffairID,@PriorityID,@MainOfficeID,@MainBranchID,@MainBranchUndertakerID,@AssistOfficeID,@AssistBranchID,@AssociationNumber,@AssociationMeetingNumber,@AssociationAffair,@AssociationDate,@AssociationForecastDate,@AssociationStateID,@CouncilNumber,@CouncilMeetingNumber,@CouncilAffair,@CouncilDate,@CouncilForecastDate,@CouncilStateID,@BureauNumber,@BureauMeetingNumber,@BureauAffair,@BureauDate,@BureauForecastDate,@BureauStateID,@SectionNumber,@SectionMeetingNumber,@SectionAffair,@SectionDate,@SectionForecastDate,@SectionStateID,@ResolutionID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@State,@DeletedDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("000000000000000000000000" & groupID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 24).Value = groupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(24, 8)))
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@AffairID", SqlDbType.NVarChar, 24).Value = affairID
			myCommand.Parameters.Add("@PriorityID", SqlDbType.NVarChar, 24).Value = priorityID
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@MainBranchID", SqlDbType.NVarChar, 24).Value = mainBranchID
			myCommand.Parameters.Add("@MainBranchUndertakerID", SqlDbType.NVarChar, 24).Value = mainBranchUndertakerID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@AssistBranchID", SqlDbType.NVarChar, 24).Value = assistBranchID
			myCommand.Parameters.Add("@AssociationNumber", SqlDbType.NVarChar, 16).Value = associationNumber
			myCommand.Parameters.Add("@AssociationMeetingNumber", SqlDbType.Int, 4).Value = associationMeetingNumber
			myCommand.Parameters.Add("@AssociationAffair", SqlDbType.NVarChar, 256).Value = associationAffair
			myCommand.Parameters.Add("@AssociationDate", SqlDbType.DateTime, 8).Value = associationDate
			myCommand.Parameters.Add("@AssociationForecastDate", SqlDbType.DateTime, 8).Value = associationForecastDate
			myCommand.Parameters.Add("@AssociationStateID", SqlDbType.NVarChar, 24).Value = associationStateID
			myCommand.Parameters.Add("@CouncilNumber", SqlDbType.NVarChar, 16).Value = councilNumber
			myCommand.Parameters.Add("@CouncilMeetingNumber", SqlDbType.Int, 4).Value = councilMeetingNumber
			myCommand.Parameters.Add("@CouncilAffair", SqlDbType.NVarChar, 256).Value = councilAffair
			myCommand.Parameters.Add("@CouncilDate", SqlDbType.DateTime, 8).Value = councilDate
			myCommand.Parameters.Add("@CouncilForecastDate", SqlDbType.DateTime, 8).Value = councilForecastDate
			myCommand.Parameters.Add("@CouncilStateID", SqlDbType.NVarChar, 24).Value = councilStateID
			myCommand.Parameters.Add("@BureauNumber", SqlDbType.NVarChar, 16).Value = bureauNumber
			myCommand.Parameters.Add("@BureauMeetingNumber", SqlDbType.Int, 4).Value = bureauMeetingNumber
			myCommand.Parameters.Add("@BureauAffair", SqlDbType.NVarChar, 256).Value = bureauAffair
			myCommand.Parameters.Add("@BureauDate", SqlDbType.DateTime, 8).Value = bureauDate
			myCommand.Parameters.Add("@BureauForecastDate", SqlDbType.DateTime, 8).Value = bureauForecastDate
			myCommand.Parameters.Add("@BureauStateID", SqlDbType.NVarChar, 24).Value = bureauStateID
			myCommand.Parameters.Add("@SectionNumber", SqlDbType.NVarChar, 16).Value = sectionNumber
			myCommand.Parameters.Add("@SectionMeetingNumber", SqlDbType.Int, 4).Value = sectionMeetingNumber
			myCommand.Parameters.Add("@SectionAffair", SqlDbType.NVarChar, 256).Value = sectionAffair
			myCommand.Parameters.Add("@SectionDate", SqlDbType.DateTime, 8).Value = sectionDate
			myCommand.Parameters.Add("@SectionForecastDate", SqlDbType.DateTime, 8).Value = sectionForecastDate
			myCommand.Parameters.Add("@SectionStateID", SqlDbType.NVarChar, 24).Value = sectionStateID
			myCommand.Parameters.Add("@ResolutionID", SqlDbType.NVarChar, 16).Value = resolutionID
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
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal groupID As String, ByVal permissionGroup As String, ByVal permission As String, ByVal affairID As String, ByVal priorityID As String, ByVal mainOfficeID As String, ByVal mainBranchID As String, ByVal mainBranchUndertakerID As String, ByVal assistOfficeID As String, ByVal assistBranchID As String, ByVal associationNumber As String, ByVal associationMeetingNumber As Integer, ByVal associationAffair As String, ByVal associationDate As Date, ByVal associationForecastDate As Date, ByVal associationStateID As String, ByVal councilNumber As String, ByVal councilMeetingNumber As Integer, ByVal councilAffair As String, ByVal councilDate As Date, ByVal councilForecastDate As Date, ByVal councilStateID As String, ByVal bureauNumber As String, ByVal bureauMeetingNumber As Integer, ByVal bureauAffair As String, ByVal bureauDate As Date, ByVal bureauForecastDate As Date, ByVal bureauStateID As String, ByVal sectionNumber As String, ByVal sectionMeetingNumber As Integer, ByVal sectionAffair As String, ByVal sectionDate As Date, ByVal sectionForecastDate As Date, ByVal sectionStateID As String,byval resolutionID as string, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal state As Integer, ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update AffairProcessCheckForm set GroupID=@GroupID , PermissionGroup=@PermissionGroup , Permission=@Permission , AffairID=@AffairID , PriorityID=@PriorityID , MainOfficeID=@MainOfficeID , MainBranchID=@MainBranchID , MainBranchUndertakerID=@MainBranchUndertakerID , AssistOfficeID=@AssistOfficeID , AssistBranchID=@AssistBranchID , AssociationNumber=@AssociationNumber , AssociationMeetingNumber=@AssociationMeetingNumber , AssociationAffair=@AssociationAffair , AssociationDate=@AssociationDate , AssociationForecastDate=@AssociationForecastDate , AssociationStateID=@AssociationStateID , CouncilNumber=@CouncilNumber , CouncilMeetingNumber=@CouncilMeetingNumber , CouncilAffair=@CouncilAffair , CouncilDate=@CouncilDate , CouncilForecastDate=@CouncilForecastDate , CouncilStateID=@CouncilStateID , BureauNumber=@BureauNumber , BureauMeetingNumber=@BureauMeetingNumber , BureauAffair=@BureauAffair , BureauDate=@BureauDate , BureauForecastDate=@BureauForecastDate , BureauStateID=@BureauStateID , SectionNumber=@SectionNumber , SectionMeetingNumber=@SectionMeetingNumber , SectionAffair=@SectionAffair , SectionDate=@SectionDate , SectionForecastDate=@SectionForecastDate , SectionStateID=@SectionStateID , ResolutionID=@ResolutionID , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 24).Value = groupID
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@AffairID", SqlDbType.NVarChar, 24).Value = affairID
			myCommand.Parameters.Add("@PriorityID", SqlDbType.NVarChar, 24).Value = priorityID
			myCommand.Parameters.Add("@MainOfficeID", SqlDbType.NVarChar, 24).Value = mainOfficeID
			myCommand.Parameters.Add("@MainBranchID", SqlDbType.NVarChar, 24).Value = mainBranchID
			myCommand.Parameters.Add("@MainBranchUndertakerID", SqlDbType.NVarChar, 24).Value = mainBranchUndertakerID
			myCommand.Parameters.Add("@AssistOfficeID", SqlDbType.NVarChar, 24).Value = assistOfficeID
			myCommand.Parameters.Add("@AssistBranchID", SqlDbType.NVarChar, 24).Value = assistBranchID
			myCommand.Parameters.Add("@AssociationNumber", SqlDbType.NVarChar, 16).Value = associationNumber
			myCommand.Parameters.Add("@AssociationMeetingNumber", SqlDbType.Int, 4).Value = associationMeetingNumber
			myCommand.Parameters.Add("@AssociationAffair", SqlDbType.NVarChar, 256).Value = associationAffair
			myCommand.Parameters.Add("@AssociationDate", SqlDbType.DateTime, 8).Value = associationDate
			myCommand.Parameters.Add("@AssociationForecastDate", SqlDbType.DateTime, 8).Value = associationForecastDate
			myCommand.Parameters.Add("@AssociationStateID", SqlDbType.NVarChar, 24).Value = associationStateID
			myCommand.Parameters.Add("@CouncilNumber", SqlDbType.NVarChar, 16).Value = councilNumber
			myCommand.Parameters.Add("@CouncilMeetingNumber", SqlDbType.Int, 4).Value = councilMeetingNumber
			myCommand.Parameters.Add("@CouncilAffair", SqlDbType.NVarChar, 256).Value = councilAffair
			myCommand.Parameters.Add("@CouncilDate", SqlDbType.DateTime, 8).Value = councilDate
			myCommand.Parameters.Add("@CouncilForecastDate", SqlDbType.DateTime, 8).Value = councilForecastDate
			myCommand.Parameters.Add("@CouncilStateID", SqlDbType.NVarChar, 24).Value = councilStateID
			myCommand.Parameters.Add("@BureauNumber", SqlDbType.NVarChar, 16).Value = bureauNumber
			myCommand.Parameters.Add("@BureauMeetingNumber", SqlDbType.Int, 4).Value = bureauMeetingNumber
			myCommand.Parameters.Add("@BureauAffair", SqlDbType.NVarChar, 256).Value = bureauAffair
			myCommand.Parameters.Add("@BureauDate", SqlDbType.DateTime, 8).Value = bureauDate
			myCommand.Parameters.Add("@BureauForecastDate", SqlDbType.DateTime, 8).Value = bureauForecastDate
			myCommand.Parameters.Add("@BureauStateID", SqlDbType.NVarChar, 24).Value = bureauStateID
			myCommand.Parameters.Add("@SectionNumber", SqlDbType.NVarChar, 16).Value = sectionNumber
			myCommand.Parameters.Add("@SectionMeetingNumber", SqlDbType.Int, 4).Value = sectionMeetingNumber
			myCommand.Parameters.Add("@SectionAffair", SqlDbType.NVarChar, 256).Value = sectionAffair
			myCommand.Parameters.Add("@SectionDate", SqlDbType.DateTime, 8).Value = sectionDate
			myCommand.Parameters.Add("@SectionForecastDate", SqlDbType.DateTime, 8).Value = sectionForecastDate
			myCommand.Parameters.Add("@SectionStateID", SqlDbType.NVarChar, 24).Value = sectionStateID
			myCommand.Parameters.Add("@ResolutionID", SqlDbType.NVarChar, 16).Value = resolutionID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from AffairProcessCheckForm where substring(EntityID,1,24)='" & entityID.Substring(0, 24) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(24, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 24) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from AffairProcessCheckForm", myConnection)
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

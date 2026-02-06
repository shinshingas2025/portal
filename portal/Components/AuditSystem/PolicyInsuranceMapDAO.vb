Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyInsuranceMapDAO
		Public Overridable Function GetEntity(ByVal policyLawID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMap where PolicyLawID=@PolicyLawID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar,16).Value=policyLawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal policyLawID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMap where PolicyLawID=@PolicyLawID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar,16).Value=policyLawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMap where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,24).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from PolicyInsuranceMap where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,24).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal policyLawID As String,ByVal itemID As Integer,ByVal insuranceID As String,ByVal processDate As Date,ByVal forecastDate As Date,ByVal outsideProcessState As String,ByVal insideProcessState As String,ByVal undertakerID As String,ByVal concludeDate As Date,ByVal concludeNumber As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyInsuranceMap ( EntityID,PolicyLawID,ItemID,InsuranceID,ProcessDate,ForecastDate,OutsideProcessState,InsideProcessState,UndertakerID,ConcludeDate,ConcludeNumber,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ) values ( @EntityID,@PolicyLawID,@ItemID,@InsuranceID,@ProcessDate,@ForecastDate,@OutsideProcessState,@InsideProcessState,@UndertakerID,@ConcludeDate,@ConcludeNumber,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate )", myConnection)
			entityID= Microsoft.VisualBasic.Right("0000000000000000" & policyLawID,16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,24).Value=entityID
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar,16).Value=policyLawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(16,8)))
			myCommand.Parameters.Add("@InsuranceID", SqlDbType.NVarChar,16).Value=insuranceID
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime,8).Value=processDate
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime,8).Value=forecastDate
			myCommand.Parameters.Add("@OutsideProcessState", SqlDbType.NVarChar,1024).Value=outsideProcessState
			myCommand.Parameters.Add("@InsideProcessState", SqlDbType.NVarChar,1024).Value=insideProcessState
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar,24).Value=undertakerID
			myCommand.Parameters.Add("@ConcludeDate", SqlDbType.DateTime,8).Value=concludeDate
			myCommand.Parameters.Add("@ConcludeNumber", SqlDbType.NVarChar,32).Value=concludeNumber
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
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal policyLawID As String,ByVal insuranceID As String,ByVal processDate As Date,ByVal forecastDate As Date,ByVal outsideProcessState As String,ByVal insideProcessState As String,ByVal undertakerID As String,ByVal concludeDate As Date,ByVal concludeNumber As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyInsuranceMap set PolicyLawID=@PolicyLawID , InsuranceID=@InsuranceID , ProcessDate=@ProcessDate , ForecastDate=@ForecastDate , OutsideProcessState=@OutsideProcessState , InsideProcessState=@InsideProcessState , UndertakerID=@UndertakerID , ConcludeDate=@ConcludeDate , ConcludeNumber=@ConcludeNumber , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar,16).Value=policyLawID
			myCommand.Parameters.Add("@InsuranceID", SqlDbType.NVarChar,16).Value=insuranceID
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime,8).Value=processDate
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime,8).Value=forecastDate
			myCommand.Parameters.Add("@OutsideProcessState", SqlDbType.NVarChar,1024).Value=outsideProcessState
			myCommand.Parameters.Add("@InsideProcessState", SqlDbType.NVarChar,1024).Value=insideProcessState
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar,24).Value=undertakerID
			myCommand.Parameters.Add("@ConcludeDate", SqlDbType.DateTime,8).Value=concludeDate
			myCommand.Parameters.Add("@ConcludeNumber", SqlDbType.NVarChar,32).Value=concludeNumber
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,24).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL="select max(EntityID) from PolicyInsuranceMap where substring(EntityID,1,16)='" & entityID.substring(0,16) & "'"
			Dim myCommand As New SqlCommand(selectSQL,myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID=CStr(myReader.GetValue(0))
					maxID=maxID.substring(16,8)
				Catch ex As System.InvalidCastException
					maxID="00000000"
				End Try
			End While
			myReader.Close()
			valResult=CInt(Val("&H"&maxID))
			valResult=valResult+1
			Return entityID.substring(0,16) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)),8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyInsuranceMap", myConnection)
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

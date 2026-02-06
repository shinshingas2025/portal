Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyInsuranceMapDAOExtand
		Inherits PolicyInsuranceMapDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByPolicyLawID(ByVal policyLawID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyInsuranceMap where PolicyLawID=@PolicyLawID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = PolicyLawID
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
		Public Overloads Function GetEntitysByPolicyLawID(ByVal policyLawID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from PolicyInsuranceMap where PolicyLawID=@PolicyLawID order by ItemID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = PolicyLawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntityIDByPolicyLawID(ByVal policyLawID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID from PolicyInsuranceMap where PolicyLawID=@PolicyLawID order by ItemID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByPolicyLawID(ByVal policyLawID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMap where PolicyLawID=@PolicyLawID order by ItemID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyLawID As String, ByVal insuranceID As String, ByVal processDate As Date, ByVal forecastDate As Date, ByVal outsideProcessState As String, ByVal insideProcessState As String, ByVal undertakerID As String, ByVal concludeDate As Date, ByVal concludeNumber As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyInsuranceMap set PolicyLawID=@PolicyLawID , InsuranceID=@InsuranceID , ProcessDate=@ProcessDate , ForecastDate=@ForecastDate , OutsideProcessState=@OutsideProcessState , InsideProcessState=@InsideProcessState , UndertakerID=@UndertakerID , ConcludeDate=@ConcludeDate , ConcludeNumber=@ConcludeNumber where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@InsuranceID", SqlDbType.NVarChar, 16).Value = insuranceID
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime, 8).Value = forecastDate
			myCommand.Parameters.Add("@OutsideProcessState", SqlDbType.NVarChar, 1024).Value = outsideProcessState
			myCommand.Parameters.Add("@InsideProcessState", SqlDbType.NVarChar, 1024).Value = insideProcessState
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@ConcludeDate", SqlDbType.DateTime, 8).Value = concludeDate
			myCommand.Parameters.Add("@ConcludeNumber", SqlDbType.NVarChar, 32).Value = concludeNumber
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyLawID As String, ByVal insuranceID As String, ByVal processDate As Date, ByVal forecastDate As Date, ByVal outsideProcessState As String, ByVal insideProcessState As String, ByVal undertakerID As String, ByVal concludeDate As Date, ByVal concludeNumber As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyInsuranceMap set PolicyLawID=@PolicyLawID , InsuranceID=@InsuranceID , ProcessDate=@ProcessDate , ForecastDate=@ForecastDate , OutsideProcessState=@OutsideProcessState , InsideProcessState=@InsideProcessState , UndertakerID=@UndertakerID , ConcludeDate=@ConcludeDate , ConcludeNumber=@ConcludeNumber , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@InsuranceID", SqlDbType.NVarChar, 16).Value = insuranceID
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime, 8).Value = forecastDate
			myCommand.Parameters.Add("@OutsideProcessState", SqlDbType.NVarChar, 1024).Value = outsideProcessState
			myCommand.Parameters.Add("@InsideProcessState", SqlDbType.NVarChar, 1024).Value = insideProcessState
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@ConcludeDate", SqlDbType.DateTime, 8).Value = concludeDate
			myCommand.Parameters.Add("@ConcludeNumber", SqlDbType.NVarChar, 32).Value = concludeNumber
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal policyLawID As String, ByVal insuranceID As String, ByVal processDate As Date, ByVal forecastDate As Date, ByVal outsideProcessState As String, ByVal insideProcessState As String, ByVal undertakerID As String, ByVal concludeDate As Date, ByVal concludeNumber As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyInsuranceMap ( EntityID,PolicyLawID,ItemID,InsuranceID,ProcessDate,ForecastDate,OutsideProcessState,InsideProcessState,UndertakerID,ConcludeDate,ConcludeNumber ) values ( @EntityID,@PolicyLawID,@ItemID,@InsuranceID,@ProcessDate,@ForecastDate,@OutsideProcessState,@InsideProcessState,@UndertakerID,@ConcludeDate,@ConcludeNumber )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & policyLawID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@InsuranceID", SqlDbType.NVarChar, 16).Value = insuranceID
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime, 8).Value = forecastDate
			myCommand.Parameters.Add("@OutsideProcessState", SqlDbType.NVarChar, 1024).Value = outsideProcessState
			myCommand.Parameters.Add("@InsideProcessState", SqlDbType.NVarChar, 1024).Value = insideProcessState
			myCommand.Parameters.Add("@UndertakerID", SqlDbType.NVarChar, 24).Value = undertakerID
			myCommand.Parameters.Add("@ConcludeDate", SqlDbType.DateTime, 8).Value = concludeDate
			myCommand.Parameters.Add("@ConcludeNumber", SqlDbType.NVarChar, 32).Value = concludeNumber
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

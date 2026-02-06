Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyInsuranceMemberMapDAOExtand
		Inherits PolicyInsuranceMemberMapDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMemberMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByPolicyInsuranceID(ByVal policyInsuranceID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyInsuranceMemberMap where PolicyInsuranceID=@PolicyInsuranceID", myConnection)
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
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
		Public Overloads Function GetEntitysByPolicyInsuranceID(ByVal policyInsuranceID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from PolicyInsuranceMemberMap where PolicyInsuranceID=@PolicyInsuranceID order by ItemID", myConnection)
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByPolicyInsuranceID(ByVal policyInsuranceID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyInsuranceMemberMap where PolicyInsuranceID=@PolicyInsuranceID order by ItemID", myConnection)
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function InsertEntity(ByVal policyInsuranceID As String, ByVal memberID As String, ByVal typeID As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyInsuranceMemberMap ( EntityID,PolicyInsuranceID,ItemID,MemberID,TypeID ) values ( @EntityID,@PolicyInsuranceID,@ItemID,@MemberID,@TypeID )", myConnection)
			entityID = Microsoft.VisualBasic.Right("000000000000000000000000" & policyInsuranceID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(24, 8)))
			myCommand.Parameters.Add("@MemberID", SqlDbType.NVarChar, 24).Value = memberID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyInsuranceID As String, ByVal memberID As String, ByVal typeID As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyInsuranceMemberMap set PolicyInsuranceID=@PolicyInsuranceID , MemberID=@MemberID , TypeID=@TypeID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
			myCommand.Parameters.Add("@MemberID", SqlDbType.NVarChar, 24).Value = memberID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyInsuranceID As String, ByVal memberID As String, ByVal typeID As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyInsuranceMemberMap set PolicyInsuranceID=@PolicyInsuranceID , MemberID=@MemberID , TypeID=@TypeID , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyInsuranceID", SqlDbType.NVarChar, 24).Value = policyInsuranceID
			myCommand.Parameters.Add("@MemberID", SqlDbType.NVarChar, 24).Value = memberID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

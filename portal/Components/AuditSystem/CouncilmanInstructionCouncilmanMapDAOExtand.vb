Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class CouncilmanInstructionCouncilmanMapDAOExtand
		Inherits CouncilmanInstructionCouncilmanMapDAO
		Public Overloads Function InsertEntity(ByVal councilmanInstructionID As String, ByVal typeID As Integer, ByVal councilmanID As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into CouncilmanInstructionCouncilmanMap ( EntityID,CouncilmanInstructionID,ItemID,TypeID,CouncilmanID ) values ( @EntityID,@CouncilmanInstructionID,@ItemID,@TypeID,@CouncilmanID )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & councilmanInstructionID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar, 16).Value = councilmanInstructionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@CouncilmanID", SqlDbType.NVarChar, 24).Value = councilmanID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal councilmanInstructionID As String, ByVal typeID As Integer, ByVal councilmanID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstructionCouncilmanMap set CouncilmanInstructionID=@CouncilmanInstructionID , TypeID=@TypeID , CouncilmanID=@CouncilmanID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar, 16).Value = councilmanInstructionID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@CouncilmanID", SqlDbType.NVarChar, 24).Value = councilmanID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal councilmanInstructionID As String, ByVal typeID As Integer, ByVal councilmanID As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstructionCouncilmanMap set CouncilmanInstructionID=@CouncilmanInstructionID , TypeID=@TypeID , CouncilmanID=@CouncilmanID , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar, 16).Value = councilmanInstructionID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@CouncilmanID", SqlDbType.NVarChar, 24).Value = councilmanID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetTotalRowByCouncilmanInstructionID(ByVal councilmanInstructionID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from CouncilmanInstructionCouncilmanMap where CouncilmanInstructionID=@CouncilmanInstructionID", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar, 16).Value = councilmanInstructionID
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
		Public Overridable Function GetEntitysByCouncilmanInstructionID(ByVal councilmanInstructionID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstructionCouncilmanMap where CouncilmanInstructionID=@CouncilmanInstructionID order by ItemID", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar, 16).Value = councilmanInstructionID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstructionCouncilmanMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

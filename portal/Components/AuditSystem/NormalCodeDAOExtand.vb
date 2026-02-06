Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class NormalCodeDAOExtand
		Inherits NormalCodeDAO
		Public Overridable Function GetNameByEntityID(ByVal entityID As String) As String
			Dim valResult As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select Name from NormalCode where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
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
		Public Overloads Function InsertEntity(ByVal groupID As String, ByVal name As String, ByVal description As String, ByVal displayOrder As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into NormalCode ( EntityID,GroupID,ItemID,Name,Description,DisplayOrder ) values ( @EntityID,@GroupID,@ItemID,@Name,@Description,@DisplayOrder )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & groupID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 16).Value = groupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal state As Integer, ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NormalCode set State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NormalCode set State=@State , DeletedDate=@DeletedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal description As String, ByVal displayOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NormalCode set Name=@Name , Description=@Description , DisplayOrder=@DisplayOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal description As String, ByVal displayOrder As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NormalCode set Name=@Name , Description=@Description , DisplayOrder=@DisplayOrder , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NormalCode where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByGroupID(ByVal groupID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NormalCode where GroupID=@GroupID order by DisplayOrder", myConnection)
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 16).Value = groupID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByGroupID(ByVal groupID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from NormalCode where GroupID=@GroupID", myConnection)
			myCommand.Parameters.Add("@GroupID", SqlDbType.NVarChar, 16).Value = groupID
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

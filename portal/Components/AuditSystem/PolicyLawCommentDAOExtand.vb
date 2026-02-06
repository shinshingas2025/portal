Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class PolicyLawCommentDAOExtand
		Inherits PolicyLawCommentDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawComment where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = EntityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByPolicyLawID(ByVal policyLawID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from PolicyLawComment where PolicyLawID=@PolicyLawID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
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
		Public Overloads Function GetEntitysByPolicyLawID(ByVal policyLawID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from PolicyLawComment where PolicyLawID=@PolicyLawID order by DisplayOrder", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyLawID As String, ByVal commentNumber As String, ByVal comment As String, ByVal displayOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyLawComment set PolicyLawID=@PolicyLawID , CommentNumber=@CommentNumber , Comment=@Comment , DisplayOrder=@DisplayOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@CommentNumber", SqlDbType.NVarChar, 16).Value = commentNumber
			myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 2048).Value = comment
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal policyLawID As String, ByVal commentNumber As String, ByVal comment As String, ByVal displayOrder As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update PolicyLawComment set PolicyLawID=@PolicyLawID , CommentNumber=@CommentNumber , Comment=@Comment , DisplayOrder=@DisplayOrder , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@CommentNumber", SqlDbType.NVarChar, 16).Value = commentNumber
			myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 2048).Value = comment
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal policyLawID As String, ByVal commentNumber As String, ByVal comment As String, ByVal displayOrder As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into PolicyLawComment ( EntityID,PolicyLawID,ItemID,CommentNumber,Comment,DisplayOrder ) values ( @EntityID,@PolicyLawID,@ItemID,@CommentNumber,@Comment,@DisplayOrder )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & policyLawID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@PolicyLawID", SqlDbType.NVarChar, 16).Value = policyLawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@CommentNumber", SqlDbType.NVarChar, 16).Value = commentNumber
			myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 2048).Value = comment
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

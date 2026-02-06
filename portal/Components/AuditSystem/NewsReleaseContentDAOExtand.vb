Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class NewsReleaseContentDAOExtand
		Inherits NewsReleaseContentDAO
		Public Overridable Function GetTotalRowByNewsReleaseID(ByVal newsReleaseID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from NewsReleaseContent where NewsReleaseID=@NewsReleaseID", myConnection)
			myCommand.Parameters.Add("@NewsReleaseID", SqlDbType.NVarChar, 32).Value = newsReleaseID
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
		Public Overridable Function GetEntitysByNewsReleaseID(ByVal newsReleaseID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NewsReleaseContent where NewsReleaseID=@NewsReleaseID order by DisplayOrder", myConnection)
			myCommand.Parameters.Add("@NewsReleaseID", SqlDbType.NVarChar, 32).Value = newsReleaseID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NewsReleaseContent where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function InsertEntity(ByVal newsReleaseID As String, ByVal contentNumber As String, ByVal content As String, ByVal displayOrder As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into NewsReleaseContent ( EntityID,NewsReleaseID,ItemID,ContentNumber,Content,DisplayOrder ) values ( @EntityID,@NewsReleaseID,@ItemID,@ContentNumber,@Content,@DisplayOrder )", myConnection)
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000000" & newsReleaseID, 32) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myCommand.Parameters.Add("@NewsReleaseID", SqlDbType.NVarChar, 32).Value = newsReleaseID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(32, 8)))
			myCommand.Parameters.Add("@ContentNumber", SqlDbType.NVarChar, 16).Value = contentNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 2048).Value = content
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal newsReleaseID As String, ByVal contentNumber As String, ByVal content As String, ByVal displayOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NewsReleaseContent set NewsReleaseID=@NewsReleaseID , ContentNumber=@ContentNumber , Content=@Content , DisplayOrder=@DisplayOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@NewsReleaseID", SqlDbType.NVarChar, 32).Value = newsReleaseID
			myCommand.Parameters.Add("@ContentNumber", SqlDbType.NVarChar, 16).Value = contentNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 2048).Value = content
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal newsReleaseID As String, ByVal contentNumber As String, ByVal content As String, ByVal displayOrder As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NewsReleaseContent set NewsReleaseID=@NewsReleaseID , ContentNumber=@ContentNumber , Content=@Content , DisplayOrder=@DisplayOrder , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@NewsReleaseID", SqlDbType.NVarChar, 32).Value = newsReleaseID
			myCommand.Parameters.Add("@ContentNumber", SqlDbType.NVarChar, 16).Value = contentNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 2048).Value = content
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

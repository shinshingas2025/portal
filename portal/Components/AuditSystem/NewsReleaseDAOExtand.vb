Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class NewsReleaseDAOExtand
		Inherits NewsReleaseDAO
		Public Overridable Function GetItemIDByCategorizationID(ByVal categorizationID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID,ItemID from NewsRelease where CategorizationID=@CategorizationID order by ItemID", myConnection)
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByCategorizationID(ByVal categorizationID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from NewsRelease where CategorizationID=@CategorizationID order by ItemID", myConnection)
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByCategorizationID(ByVal categorizationID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NewsRelease where CategorizationID=@CategorizationID order by ItemID", myConnection)
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from NewsRelease order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NewsRelease order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from NewsRelease where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal categorizationID As String, ByVal title As String, ByVal description As String, ByVal opening As String, ByVal ending As String, ByVal relationURL As String, ByVal releaseUnitID As String, ByVal liaisonerID As String, ByVal newsDate As Date, ByVal startDate As Date, ByVal endDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NewsRelease set CategorizationID=@CategorizationID , Title=@Title , Description=@Description , Opening=@Opening , Ending=@Ending , RelationURL=@RelationURL , ReleaseUnitID=@ReleaseUnitID , LiaisonerID=@LiaisonerID , NewsDate=@NewsDate , StartDate=@StartDate , EndDate=@EndDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Opening", SqlDbType.NVarChar, 1024).Value = opening
			myCommand.Parameters.Add("@Ending", SqlDbType.NVarChar, 1024).Value = ending
			myCommand.Parameters.Add("@RelationURL", SqlDbType.NVarChar, 256).Value = relationURL
			myCommand.Parameters.Add("@ReleaseUnitID", SqlDbType.NVarChar, 24).Value = releaseUnitID
			myCommand.Parameters.Add("@LiaisonerID", SqlDbType.NVarChar, 24).Value = liaisonerID
			myCommand.Parameters.Add("@NewsDate", SqlDbType.DateTime, 8).Value = newsDate
			myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = startDate
			myCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = endDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal categorizationID As String, ByVal title As String, ByVal description As String, ByVal opening As String, ByVal ending As String, ByVal relationURL As String, ByVal releaseUnitID As String, ByVal liaisonerID As String, ByVal newsDate As Date, ByVal startDate As Date, ByVal endDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update NewsRelease set CategorizationID=@CategorizationID , Title=@Title , Description=@Description , Opening=@Opening , Ending=@Ending , RelationURL=@RelationURL , ReleaseUnitID=@ReleaseUnitID , LiaisonerID=@LiaisonerID , NewsDate=@NewsDate , StartDate=@StartDate , EndDate=@EndDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Opening", SqlDbType.NVarChar, 1024).Value = opening
			myCommand.Parameters.Add("@Ending", SqlDbType.NVarChar, 1024).Value = ending
			myCommand.Parameters.Add("@RelationURL", SqlDbType.NVarChar, 256).Value = relationURL
			myCommand.Parameters.Add("@ReleaseUnitID", SqlDbType.NVarChar, 24).Value = releaseUnitID
			myCommand.Parameters.Add("@LiaisonerID", SqlDbType.NVarChar, 24).Value = liaisonerID
			myCommand.Parameters.Add("@NewsDate", SqlDbType.DateTime, 8).Value = newsDate
			myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = startDate
			myCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = endDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal categorizationID As String, ByVal title As String, ByVal description As String, ByVal opening As String, ByVal ending As String, ByVal relationURL As String, ByVal releaseUnitID As String, ByVal liaisonerID As String, ByVal newsDate As Date, ByVal startDate As Date, ByVal endDate As Date) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into NewsRelease ( EntityID,CategorizationID,ItemID,Title,Description,Opening,Ending,RelationURL,ReleaseUnitID,LiaisonerID,NewsDate,StartDate,EndDate ) values ( @EntityID,@CategorizationID,@ItemID,@Title,@Description,@Opening,@Ending,@RelationURL,@ReleaseUnitID,@LiaisonerID,@NewsDate,@StartDate,@EndDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("000000000000000000000000" & categorizationID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myCommand.Parameters.Add("@CategorizationID", SqlDbType.NVarChar, 24).Value = categorizationID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(24, 8)))
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Opening", SqlDbType.NVarChar, 1024).Value = opening
			myCommand.Parameters.Add("@Ending", SqlDbType.NVarChar, 1024).Value = ending
			myCommand.Parameters.Add("@RelationURL", SqlDbType.NVarChar, 256).Value = relationURL
			myCommand.Parameters.Add("@ReleaseUnitID", SqlDbType.NVarChar, 24).Value = releaseUnitID
			myCommand.Parameters.Add("@LiaisonerID", SqlDbType.NVarChar, 24).Value = liaisonerID
			myCommand.Parameters.Add("@NewsDate", SqlDbType.DateTime, 8).Value = newsDate
			myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = startDate
			myCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = endDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

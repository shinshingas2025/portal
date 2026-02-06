Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class AffairProcessMapDAOExtand
		Inherits AffairProcessMapDAO
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from AffairProcessMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal processDate As Date, ByVal processState As String, ByVal note As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update AffairProcessMap set ProcessDate=@ProcessDate , ProcessState=@ProcessState , Note=@Note where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ProcessState", SqlDbType.NVarChar, 1024).Value = processState
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal processDate As Date, ByVal processState As String, ByVal note As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update AffairProcessMap set ProcessDate=@ProcessDate , ProcessState=@ProcessState , Note=@Note , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ProcessState", SqlDbType.NVarChar, 1024).Value = processState
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal formID As String, ByVal processDate As Date, ByVal processState As String, ByVal note As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into AffairProcessMap ( EntityID,FormID,ItemID,ProcessDate,ProcessState,Note) values ( @EntityID,@FormID,@ItemID,@ProcessDate,@ProcessState,@Note )", myConnection)
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000000" & formID, 32) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			myCommand.Parameters.Add("@FormID", SqlDbType.NVarChar, 32).Value = formID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(32, 8)))
			myCommand.Parameters.Add("@ProcessDate", SqlDbType.DateTime, 8).Value = processDate
			myCommand.Parameters.Add("@ProcessState", SqlDbType.NVarChar, 1024).Value = processState
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Function GetTotalRowByFormID(ByVal formID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from AffairProcessMap where FormID=@FormID", myConnection)
			myCommand.Parameters.Add("@FormID", SqlDbType.NVarChar, 32).Value = formID
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
		Public Overridable Function GetItemIDByFormID(ByVal formID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID,ItemID from AffairProcessMap where FormID=@FormID order by ItemID", myConnection)
			myCommand.Parameters.Add("@FormID", SqlDbType.NVarChar, 32).Value = formID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByFormID(ByVal formID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from AffairProcessMap where FormID=@FormID order by ItemID", myConnection)
			myCommand.Parameters.Add("@FormID", SqlDbType.NVarChar, 32).Value = formID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByFormID(ByVal formID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from AffairProcessMap where FormID=@FormID order by ItemID", myConnection)
			myCommand.Parameters.Add("@FormID", SqlDbType.NVarChar, 32).Value = formID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

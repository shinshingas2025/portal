Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ModuleStatisticDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_ModuleStatistic", myConnection)
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
		Public Overridable Function GetEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ModuleStatistic where SchoolID=@SchoolID and ModuleID=@ModuleID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ModuleStatistic where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ModuleStatistic where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ModuleStatistic where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer, ByVal bulletinImport As Integer, ByVal bulletinExport As Integer, ByVal subscriptionEdition As Integer, ByVal ePaperAmount As Integer, ByVal baseImport As Integer, ByVal baseExport As Integer, ByVal guestbook As Integer, ByVal voteSubject As Integer, ByVal voteAmount As Integer, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_ModuleStatistic ( EntityID,SchoolID,ModuleID,ItemID,BulletinImport,BulletinExport,SubscriptionEdition,EPaperAmount,BaseImport,BaseExport,Guestbook,VoteSubject,VoteAmount,CreatedDate ) values ( @EntityID,@SchoolID,@ModuleID,@ItemID,@BulletinImport,@BulletinExport,@SubscriptionEdition,@EPaperAmount,@BaseImport,@BaseExport,@Guestbook,@VoteSubject,@VoteAmount,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(moduleID), 8) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(21, 8)))
			myCommand.Parameters.Add("@BulletinImport", SqlDbType.Int, 4).Value = bulletinImport
			myCommand.Parameters.Add("@BulletinExport", SqlDbType.Int, 4).Value = bulletinExport
			myCommand.Parameters.Add("@SubscriptionEdition", SqlDbType.Int, 4).Value = subscriptionEdition
			myCommand.Parameters.Add("@EPaperAmount", SqlDbType.Int, 4).Value = ePaperAmount
			myCommand.Parameters.Add("@BaseImport", SqlDbType.Int, 4).Value = baseImport
			myCommand.Parameters.Add("@BaseExport", SqlDbType.Int, 4).Value = baseExport
			myCommand.Parameters.Add("@Guestbook", SqlDbType.Int, 4).Value = guestbook
			myCommand.Parameters.Add("@VoteSubject", SqlDbType.Int, 4).Value = voteSubject
			myCommand.Parameters.Add("@VoteAmount", SqlDbType.Int, 4).Value = voteAmount
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal schoolID As String, ByVal moduleID As Integer, ByVal bulletinImport As Integer, ByVal bulletinExport As Integer, ByVal subscriptionEdition As Integer, ByVal ePaperAmount As Integer, ByVal baseImport As Integer, ByVal baseExport As Integer, ByVal guestbook As Integer, ByVal voteSubject As Integer, ByVal voteAmount As Integer, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ModuleStatistic set SchoolID=@SchoolID and ModuleID=@ModuleID and BulletinImport=@BulletinImport and BulletinExport=@BulletinExport and SubscriptionEdition=@SubscriptionEdition and EPaperAmount=@EPaperAmount and BaseImport=@BaseImport and BaseExport=@BaseExport and Guestbook=@Guestbook and VoteSubject=@VoteSubject and VoteAmount=@VoteAmount and CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@BulletinImport", SqlDbType.Int, 4).Value = bulletinImport
			myCommand.Parameters.Add("@BulletinExport", SqlDbType.Int, 4).Value = bulletinExport
			myCommand.Parameters.Add("@SubscriptionEdition", SqlDbType.Int, 4).Value = subscriptionEdition
			myCommand.Parameters.Add("@EPaperAmount", SqlDbType.Int, 4).Value = ePaperAmount
			myCommand.Parameters.Add("@BaseImport", SqlDbType.Int, 4).Value = baseImport
			myCommand.Parameters.Add("@BaseExport", SqlDbType.Int, 4).Value = baseExport
			myCommand.Parameters.Add("@Guestbook", SqlDbType.Int, 4).Value = guestbook
			myCommand.Parameters.Add("@VoteSubject", SqlDbType.Int, 4).Value = voteSubject
			myCommand.Parameters.Add("@VoteAmount", SqlDbType.Int, 4).Value = voteAmount
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_ModuleStatistic where substring(EntityID,1,21)='" & entityID.Substring(0, 21) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(21, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 21) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace
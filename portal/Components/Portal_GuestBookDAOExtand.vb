Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_GuestBookDAOExtand
		Inherits ASPNET.StarterKit.Portal.Portal_GuestBookDAO
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select top " & rowCount & " * from Portal_GuestBook where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select * from Portal_GuestBook where EntityID=@EntityID"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim sqlString As String
			sqlString = "select * from Portal_GuestBook where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc"
			Dim myCommand As New SqlCommand(sqlString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal reply As String, ByVal replyByUser As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_GuestBook set Reply=@Reply,ReplyByUser=@ReplyByUser,ReplyDate=getdate() where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Reply", SqlDbType.NVarChar, 1600).Value = reply
			myCommand.Parameters.Add("@ReplyByUser", SqlDbType.NVarChar, 100).Value = replyByUser
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer, ByVal title As String, ByVal description As String, ByVal email As String, ByVal createdByUser As String, ByVal reply As String, ByVal replyByUser As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_GuestBook ( EntityID,SchoolID,ModuleID,ItemID,Title,Description,Email,CreatedByUser,Reply,ReplyByUser ) values ( @EntityID,@SchoolID,@ModuleID,@ItemID,@Title,@Description,@Email,@CreatedByUser,@Reply,@ReplyByUser )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(moduleID), 8) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1600).Value = description
			myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@Reply", SqlDbType.NVarChar, 1600).Value = reply
			myCommand.Parameters.Add("@ReplyByUser", SqlDbType.NVarChar, 100).Value = replyByUser
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace
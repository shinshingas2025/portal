Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class CouncilmanInstructionDAOExtand
		Inherits CouncilmanInstructionDAO
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from CouncilmanInstruction order by ItemID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstruction order by ItemID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetItemID() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID,ItemID from CouncilmanInstruction order by ItemID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstruction where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal title As String, ByVal description As String, ByVal instruction As String, ByVal note As String, ByVal instructionDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstruction set Title=@Title , Description=@Description , Instruction=@Instruction , Note=@Note , InstructionDate=@InstructionDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Instruction", SqlDbType.NVarChar, 1024).Value = instruction
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@InstructionDate", SqlDbType.DateTime, 8).Value = instructionDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal title As String, ByVal description As String, ByVal instruction As String, ByVal note As String, ByVal instructionDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstruction set Title=@Title , Description=@Description , Instruction=@Instruction , Note=@Note , InstructionDate=@InstructionDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Instruction", SqlDbType.NVarChar, 1024).Value = instruction
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@InstructionDate", SqlDbType.DateTime, 8).Value = instructionDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal title As String, ByVal description As String, ByVal instruction As String, ByVal note As String, ByVal instructionDate As Date) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into CouncilmanInstruction ( EntityID,ItemID,Title,Description,Instruction,Note,InstructionDate ) values ( @EntityID,@ItemID,@Title,@Description,@Instruction,@Note,@InstructionDate )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@Instruction", SqlDbType.NVarChar, 1024).Value = instruction
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@InstructionDate", SqlDbType.DateTime, 8).Value = instructionDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
	End Class
End Namespace

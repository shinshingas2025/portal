Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class LawAppendDAOExtand
		Inherits LawAppendDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from LawAppend where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByLawID(ByVal lawID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from LawAppend where LawID=@LawID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
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
		Public Overloads Function GetEntitysByLawID(ByVal lawID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from LawAppend where LawID=@LawID order by ItemID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByLawID(ByVal lawID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from LawAppend where LawID=@LawID order by ItemID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function InsertEntity(ByVal lawID As String, ByVal name As String, ByVal description As String, ByVal fileName As String, ByVal fileSize As Integer, ByVal displayOrder As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into LawAppend ( EntityID,LawID,ItemID,Name,Description,FileName,FileSize,DisplayOrder ) values ( @EntityID,@LawID,@ItemID,@Name,@Description,@FileName,@FileSize,@DisplayOrder )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & lawID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar, 1024).Value = fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int, 4).Value = fileSize
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal lawID As String, ByVal name As String, ByVal description As String, ByVal fileName As String, ByVal fileSize As Integer, ByVal displayOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update LawAppend set LawID=@LawID , Name=@Name , Description=@Description , FileName=@FileName , FileSize=@FileSize , DisplayOrder=@DisplayOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar, 1024).Value = fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int, 4).Value = fileSize
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal lawID As String, ByVal name As String, ByVal description As String, ByVal fileName As String, ByVal fileSize As Integer, ByVal displayOrder As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update LawAppend set LawID=@LawID , Name=@Name , Description=@Description , FileName=@FileName , FileSize=@FileSize , DisplayOrder=@DisplayOrder , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@LawID", SqlDbType.NVarChar, 16).Value = lawID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = name
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@FileName", SqlDbType.NVarChar, 1024).Value = fileName
			myCommand.Parameters.Add("@FileSize", SqlDbType.Int, 4).Value = fileSize
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

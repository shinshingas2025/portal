Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_EPaperDAOExtand
		Inherits Portal_EPaperDAO
		Public Function GetEntitys(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_EPaper where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalRow(ByVal schoolID As String, ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_EPaper where SchoolID=@SchoolID and ModuleID=@ModuleID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
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
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_EPaper where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Portal_EPaper where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overrides Function InsertEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer, ByVal title As String, ByVal description As String, ByVal templateFile As String, ByVal cSSFile As String, ByVal contentFile As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_EPaper ( EntityID,SchoolID,ModuleID,ItemID,Title,Description,TemplateFile,CSSFile,ContentFile,EnableDate,DisableDate,CreatedByUser,CreatedDate ) values ( @EntityID,@SchoolID,@ModuleID,@ItemID,@Title,@Description,@TemplateFile,@CSSFile,@ContentFile,@EnableDate,@DisableDate,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(moduleID), 8) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(21, 8)))
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 400).Value = description
			myCommand.Parameters.Add("@TemplateFile", SqlDbType.NVarChar, 400).Value = templateFile
			myCommand.Parameters.Add("@CSSFile", SqlDbType.NVarChar, 400).Value = cSSFile
			myCommand.Parameters.Add("@ContentFile", SqlDbType.NVarChar, 400).Value = entityID + ".htm"
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal title As String, ByVal description As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_EPaper set Title=@Title,Description=@Description where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 400).Value = description
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace
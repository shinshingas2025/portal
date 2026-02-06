Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_QuestionDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Question", myConnection)
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
		Public Function GetEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal questionID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Question where SchoolID=@SchoolID and ModuleID=@ModuleID and QuestionID=@QuestionID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@QuestionID", SqlDbType.Int, 4).Value = questionID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Question where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_Question where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function InsertEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal questionID As Integer, ByVal parentQuestionID As String, ByVal selectModeID As Integer, ByVal showModeID As Integer, ByVal minSelectRequired As Integer, ByVal maxSelectAllowed As Integer, ByVal displayOrder As Integer, ByVal questionAlias As String, ByVal questionText As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_Question ( EntityID,SchoolID,ModuleID,QuestionID,ParentQuestionID,SelectModeID,ShowModeID,MinSelectRequired,MaxSelectAllowed,DisplayOrder,QuestionAlias,QuestionText,EnableDate,DisableDate,CreatedByUser,CreatedDate ) values ( @EntityID,@SchoolID,@ModuleID,@QuestionID,@ParentQuestionID,@SelectModeID,@ShowModeID,@MinSelectRequired,@MaxSelectAllowed,@DisplayOrder,@QuestionAlias,@QuestionText,@EnableDate,@DisableDate,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(moduleID), 8) & Microsoft.VisualBasic.Right("00000000" & Hex(questionID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@QuestionID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(21, 8)))
			myCommand.Parameters.Add("@ParentQuestionID", SqlDbType.NVarChar, 29).Value = parentQuestionID
			myCommand.Parameters.Add("@SelectModeID", SqlDbType.Int, 4).Value = selectModeID
			myCommand.Parameters.Add("@ShowModeID", SqlDbType.Int, 4).Value = showModeID
			myCommand.Parameters.Add("@MinSelectRequired", SqlDbType.Int, 4).Value = minSelectRequired
			myCommand.Parameters.Add("@MaxSelectAllowed", SqlDbType.Int, 4).Value = maxSelectAllowed
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@QuestionAlias", SqlDbType.NVarChar, 100).Value = questionAlias
			myCommand.Parameters.Add("@QuestionText", SqlDbType.NVarChar, 3600).Value = questionText
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Sub UpdateEntity(ByVal entityID As String, ByVal schoolID As String, ByVal moduleID As Integer, ByVal parentQuestionID As String, ByVal selectModeID As Integer, ByVal showModeID As Integer, ByVal minSelectRequired As Integer, ByVal maxSelectAllowed As Integer, ByVal displayOrder As Integer, ByVal questionAlias As String, ByVal questionText As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Question set SchoolID=@SchoolID,ModuleID=@ModuleID,ParentQuestionID=@ParentQuestionID,SelectModeID=@SelectModeID,ShowModeID=@ShowModeID,MinSelectRequired=@MinSelectRequired,MaxSelectAllowed=@MaxSelectAllowed,DisplayOrder=@DisplayOrder,QuestionAlias=@QuestionAlias,QuestionText=@QuestionText,EnableDate=@EnableDate,DisableDate=@DisableDate,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ParentQuestionID", SqlDbType.NVarChar, 29).Value = parentQuestionID
			myCommand.Parameters.Add("@SelectModeID", SqlDbType.Int, 4).Value = selectModeID
			myCommand.Parameters.Add("@ShowModeID", SqlDbType.Int, 4).Value = showModeID
			myCommand.Parameters.Add("@MinSelectRequired", SqlDbType.Int, 4).Value = minSelectRequired
			myCommand.Parameters.Add("@MaxSelectAllowed", SqlDbType.Int, 4).Value = maxSelectAllowed
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@QuestionAlias", SqlDbType.NVarChar, 100).Value = questionAlias
			myCommand.Parameters.Add("@QuestionText", SqlDbType.NVarChar, 3600).Value = questionText
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_Question where substring(EntityID,1,21)='" & entityID.Substring(0, 21) & "'"
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

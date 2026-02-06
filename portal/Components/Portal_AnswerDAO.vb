Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_AnswerDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Answer", myConnection)
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
		Public Function GetEntity(ByVal questionID As String, ByVal answerID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Answer where QuestionID=@QuestionID and AnswerID=@AnswerID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@QuestionID", SqlDbType.NVarChar, 29).Value = questionID
			myCommand.Parameters.Add("@AnswerID", SqlDbType.Int, 4).Value = answerID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Answer where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_Answer where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function InsertEntity(ByVal questionID As String, ByVal answerID As Integer, ByVal answerTypeID As Integer, ByVal displayOrder As Integer, ByVal answerColor As Integer, ByVal answerAlias As String, ByVal answerText As String, ByVal imageURL As String, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_Answer ( EntityID,QuestionID,AnswerID,AnswerTypeID,DisplayOrder,AnswerColor,AnswerAlias,AnswerText,ImageURL,CreatedByUser,CreatedDate ) values ( @EntityID,@QuestionID,@AnswerID,@AnswerTypeID,@DisplayOrder,@AnswerColor,@AnswerAlias,@AnswerText,@ImageURL,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000" & questionID, 29) & Microsoft.VisualBasic.Right("00000000" & Hex(answerID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myCommand.Parameters.Add("@QuestionID", SqlDbType.NVarChar, 29).Value = questionID
			myCommand.Parameters.Add("@AnswerID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(29, 8)))
			myCommand.Parameters.Add("@AnswerTypeID", SqlDbType.Int, 4).Value = answerTypeID
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@AnswerColor", SqlDbType.Int, 4).Value = answerColor
			myCommand.Parameters.Add("@AnswerAlias", SqlDbType.NVarChar, 100).Value = answerAlias
			myCommand.Parameters.Add("@AnswerText", SqlDbType.NVarChar, 1600).Value = answerText
			myCommand.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 255).Value = imageURL
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Sub UpdateEntity(ByVal entityID As String, ByVal questionID As String, ByVal answerTypeID As Integer, ByVal displayOrder As Integer, ByVal answerColor As Integer, ByVal answerAlias As String, ByVal answerText As String, ByVal imageURL As String, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Answer set QuestionID=@QuestionID,AnswerTypeID=@AnswerTypeID,DisplayOrder=@DisplayOrder,AnswerColor=@AnswerColor,AnswerAlias=@AnswerAlias,AnswerText=@AnswerText,ImageURL=@ImageURL,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@QuestionID", SqlDbType.NVarChar, 29).Value = questionID
			myCommand.Parameters.Add("@AnswerTypeID", SqlDbType.Int, 4).Value = answerTypeID
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@AnswerColor", SqlDbType.Int, 4).Value = answerColor
			myCommand.Parameters.Add("@AnswerAlias", SqlDbType.NVarChar, 100).Value = answerAlias
			myCommand.Parameters.Add("@AnswerText", SqlDbType.NVarChar, 1600).Value = answerText
			myCommand.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 255).Value = imageURL
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_Answer where substring(EntityID,1,29)='" & entityID.Substring(0, 29) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(29, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 29) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace

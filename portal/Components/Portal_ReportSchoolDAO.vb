Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ReportSchoolDAO
		Public Overridable Function GetEntity(ByVal reportGroupID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportSchool where ReportGroupID=@ReportGroupID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ReportGroupID", SqlDbType.NVarChar, 16).Value = reportGroupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal reportGroupID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportSchool where ReportGroupID=@ReportGroupID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ReportGroupID", SqlDbType.NVarChar, 16).Value = reportGroupID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportSchool where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ReportSchool where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal reportGroupID As String, ByVal itemID As Integer, ByVal name As String, ByVal state As Integer, ByVal displayOrder As Integer, ByVal reportName As String, ByVal procedureName As String, ByVal createdbyUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_ReportSchool ( EntityID,ReportGroupID,ItemID,Name,State,DisplayOrder,ReportName,ProcedureName,CreatedbyUser,CreatedDate ) values ( @EntityID,@ReportGroupID,@ItemID,@Name,@State,@DisplayOrder,@ReportName,@ProcedureName,@CreatedbyUser,@CreatedDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & reportGroupID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@ReportGroupID", SqlDbType.NVarChar, 16).Value = reportGroupID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 240).Value = name
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ReportName", SqlDbType.NVarChar, 1024).Value = reportName
			myCommand.Parameters.Add("@ProcedureName", SqlDbType.NVarChar, 100).Value = procedureName
			myCommand.Parameters.Add("@CreatedbyUser", SqlDbType.NVarChar, 100).Value = createdbyUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal reportGroupID As String, ByVal name As String, ByVal state As Integer, ByVal displayOrder As Integer, ByVal reportName As String, ByVal procedureName As String, ByVal createdbyUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ReportSchool set ReportGroupID=@ReportGroupID and Name=@Name and State=@State and DisplayOrder=@DisplayOrder and ReportName=@ReportName and ProcedureName=@ProcedureName and CreatedbyUser=@CreatedbyUser and CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ReportGroupID", SqlDbType.NVarChar, 16).Value = reportGroupID
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 240).Value = name
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@ReportName", SqlDbType.NVarChar, 1024).Value = reportName
			myCommand.Parameters.Add("@ProcedureName", SqlDbType.NVarChar, 100).Value = procedureName
			myCommand.Parameters.Add("@CreatedbyUser", SqlDbType.NVarChar, 100).Value = createdbyUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_ReportSchool where substring(EntityID,1,16)='" & entityID.substring(0, 16) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.substring(16, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.substring(0, 16) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_ReportSchool", myConnection)
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
	End Class
End Namespace
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_AuditDetailDAO
		Public Overridable Function GetEntity(ByVal auditID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_AuditDetail where AuditID=@AuditID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 29).Value = auditID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal auditID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_AuditDetail where AuditID=@AuditID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 29).Value = auditID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_AuditDetail where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_AuditDetail where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal auditID As String, ByVal itemID As Integer, ByVal sequenceID As Integer, ByVal columnName As String, ByVal columnValue As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_AuditDetail ( EntityID,AuditID,ItemID,SequenceID,ColumnName,ColumnValue ) values ( @EntityID,@AuditID,@ItemID,@SequenceID,@ColumnName,@ColumnValue )", myConnection)
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000" & auditID, 29) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 29).Value = auditID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(29, 8)))
			myCommand.Parameters.Add("@SequenceID", SqlDbType.Int, 4).Value = sequenceID
			myCommand.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 100).Value = columnName
			myCommand.Parameters.Add("@ColumnValue", SqlDbType.NVarChar, 2000).Value = columnValue
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal auditID As String, ByVal sequenceID As Integer, ByVal columnName As String, ByVal columnValue As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_AuditDetail set AuditID=@AuditID , SequenceID=@SequenceID , ColumnName=@ColumnName , ColumnValue=@ColumnValue where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 29).Value = auditID
			myCommand.Parameters.Add("@SequenceID", SqlDbType.Int, 4).Value = sequenceID
			myCommand.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 100).Value = columnName
			myCommand.Parameters.Add("@ColumnValue", SqlDbType.NVarChar, 2000).Value = columnValue
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_AuditDetail where substring(EntityID,1,29)='" & entityID.substring(0, 29) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.substring(29, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.substring(0, 29) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_AuditDetail", myConnection)
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
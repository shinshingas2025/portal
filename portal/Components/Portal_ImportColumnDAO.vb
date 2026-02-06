Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ImportColumnDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_ImportColumn", myConnection)
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
		Public Overridable Function GetEntity(ByVal importID As String, ByVal tableColumnID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ImportColumn where ImportID=@ImportID and TableColumnID=@TableColumnID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myCommand.Parameters.Add("@TableColumnID", SqlDbType.NVarChar, 24).Value = tableColumnID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal importID As String, ByVal tableColumnID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ImportColumn where ImportID=@ImportID and TableColumnID=@TableColumnID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myCommand.Parameters.Add("@TableColumnID", SqlDbType.NVarChar, 24).Value = tableColumnID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ImportColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ImportColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal importID As String, ByVal tableColumnID As String, ByVal itemID As Integer, ByVal importOrder As Integer, ByVal importPrimaryKey As Integer, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_ImportColumn ( EntityID,ImportID,TableColumnID,ItemID,ImportOrder,ImportPrimaryKey,CreatedByUser,CreatedDate ) values ( @EntityID,@ImportID,@TableColumnID,@ItemID,@ImportOrder,@ImportPrimaryKey,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000" & importID, 29) & Microsoft.VisualBasic.Right("000000000000000000000000" & tableColumnID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myCommand.Parameters.Add("@TableColumnID", SqlDbType.NVarChar, 24).Value = tableColumnID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(53, 8)))
			myCommand.Parameters.Add("@ImportOrder", SqlDbType.Int, 4).Value = importOrder
			myCommand.Parameters.Add("@ImportPrimaryKey", SqlDbType.Int, 4).Value = importPrimaryKey
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal importID As String, ByVal tableColumnID As String, ByVal importOrder As Integer, ByVal importPrimaryKey As Integer, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ImportColumn set ImportID=@ImportID,TableColumnID=@TableColumnID,ImportOrder=@ImportOrder,ImportPrimaryKey=@ImportPrimaryKey,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myCommand.Parameters.Add("@TableColumnID", SqlDbType.NVarChar, 24).Value = tableColumnID
			myCommand.Parameters.Add("@ImportOrder", SqlDbType.Int, 4).Value = importOrder
			myCommand.Parameters.Add("@ImportPrimaryKey", SqlDbType.Int, 4).Value = importPrimaryKey
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_ImportColumn where substring(EntityID,1,53)='" & entityID.Substring(0, 53) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(53, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 53) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace

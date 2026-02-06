Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Oracle_TableColumnDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Oracle_TableColumn", myConnection)
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
		Public Overridable Function GetEntity(ByVal tableID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Oracle_TableColumn where TableID=@TableID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal tableID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Oracle_TableColumn where TableID=@TableID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Oracle_TableColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Oracle_TableColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal tableID As String, ByVal itemID As Integer, ByVal columnOrder As Integer, ByVal columnName As String, ByVal columnType As Integer, ByVal columnSize As Integer, ByVal columnDefault As String, ByVal columnPrimaryKey As Integer, ByVal columnIdentity As Integer, ByVal columnAllowNull As Integer, ByVal description As String, ByVal remark As String, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Oracle_TableColumn ( EntityID,TableID,ItemID,ColumnOrder,ColumnName,ColumnType,ColumnSize,ColumnDefault,ColumnPrimaryKey,ColumnIdentity,ColumnAllowNull,Description,Remark,CreatedByUser,CreatedDate ) values ( @EntityID,@TableID,@ItemID,@ColumnOrder,@ColumnName,@ColumnType,@ColumnSize,@ColumnDefault,@ColumnPrimaryKey,@ColumnIdentity,@ColumnAllowNull,@Description,@Remark,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & tableID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(16, 8)))
			myCommand.Parameters.Add("@ColumnOrder", SqlDbType.Int, 4).Value = columnOrder
			myCommand.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 100).Value = columnName
			myCommand.Parameters.Add("@ColumnType", SqlDbType.Int, 4).Value = columnType
			myCommand.Parameters.Add("@ColumnSize", SqlDbType.Int, 4).Value = columnSize
			myCommand.Parameters.Add("@ColumnDefault", SqlDbType.NVarChar, 100).Value = columnDefault
			myCommand.Parameters.Add("@ColumnPrimaryKey", SqlDbType.Int, 4).Value = columnPrimaryKey
			myCommand.Parameters.Add("@ColumnIdentity", SqlDbType.Int, 4).Value = columnIdentity
			myCommand.Parameters.Add("@ColumnAllowNull", SqlDbType.Int, 4).Value = columnAllowNull
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 100).Value = description
			myCommand.Parameters.Add("@Remark", SqlDbType.NVarChar, 100).Value = remark
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal tableID As String, ByVal columnOrder As Integer, ByVal columnName As String, ByVal columnType As Integer, ByVal columnSize As Integer, ByVal columnDefault As String, ByVal columnPrimaryKey As Integer, ByVal columnIdentity As Integer, ByVal columnAllowNull As Integer, ByVal description As String, ByVal remark As String, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Oracle_TableColumn set TableID=@TableID,ColumnOrder=@ColumnOrder,ColumnName=@ColumnName,ColumnType=@ColumnType,ColumnSize=@ColumnSize,ColumnDefault=@ColumnDefault,ColumnPrimaryKey=@ColumnPrimaryKey,ColumnIdentity=@ColumnIdentity,ColumnAllowNull=@ColumnAllowNull,Description=@Description,Remark=@Remark,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			myCommand.Parameters.Add("@ColumnOrder", SqlDbType.Int, 4).Value = columnOrder
			myCommand.Parameters.Add("@ColumnName", SqlDbType.NVarChar, 100).Value = columnName
			myCommand.Parameters.Add("@ColumnType", SqlDbType.Int, 4).Value = columnType
			myCommand.Parameters.Add("@ColumnSize", SqlDbType.Int, 4).Value = columnSize
			myCommand.Parameters.Add("@ColumnDefault", SqlDbType.NVarChar, 100).Value = columnDefault
			myCommand.Parameters.Add("@ColumnPrimaryKey", SqlDbType.Int, 4).Value = columnPrimaryKey
			myCommand.Parameters.Add("@ColumnIdentity", SqlDbType.Int, 4).Value = columnIdentity
			myCommand.Parameters.Add("@ColumnAllowNull", SqlDbType.Int, 4).Value = columnAllowNull
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 100).Value = description
			myCommand.Parameters.Add("@Remark", SqlDbType.NVarChar, 100).Value = remark
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
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
			selectSQL = "select max(EntityID) from Oracle_TableColumn where substring(EntityID,1,16)='" & entityID.Substring(0, 16) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(16, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 16) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace

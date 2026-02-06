Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ImportColumnDAOExtand
		Inherits Portal_ImportColumnDAO
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ImportColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByImportIDAndTableID(ByVal importID As String, ByVal tableID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_ImportColumn.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportID as ImportID,"
			mySQLString = mySQLString + "Portal_ImportColumn.TableColumnID as TableColumnID,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportOrder as ImportOrder,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportPrimaryKey as ImportPrimaryKey,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnName as ColumnName,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnType as ColumnType,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnSize as ColumnSize,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnAllowNull as ColumnAllowNull,"
			mySQLString = mySQLString + "Oracle_TableColumn.Description as Description,"
			mySQLString = mySQLString + "Portal_ImportColumn.CreatedByUser as CreatedByUser,"
			mySQLString = mySQLString + "Portal_ImportColumn.CreatedDate as CreatedDate "
			mySQLString = mySQLString + "from Portal_ImportColumn inner join Oracle_TableColumn on Portal_ImportColumn.TableColumnID=Oracle_TableColumn.EntityID where Portal_ImportColumn.ImportID=@ImportID and Oracle_TableColumn.TableID=@TableID order by Portal_ImportColumn.ImportOrder"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByImportID(ByVal importID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_ImportColumn.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportID as ImportID,"
			mySQLString = mySQLString + "Portal_ImportColumn.TableColumnID as TableColumnID,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportOrder as ImportOrder,"
			mySQLString = mySQLString + "Portal_ImportColumn.ImportPrimaryKey as ImportPrimaryKey,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnName as ColumnName,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnType as ColumnType,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnSize as ColumnSize,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnAllowNull as ColumnAllowNull,"
			mySQLString = mySQLString + "Oracle_TableColumn.Description as Description,"
			mySQLString = mySQLString + "Portal_ImportColumn.CreatedByUser as CreatedByUser,"
			mySQLString = mySQLString + "Portal_ImportColumn.CreatedDate as CreatedDate "
			mySQLString = mySQLString + "from Portal_ImportColumn inner join Oracle_TableColumn on Portal_ImportColumn.TableColumnID=Oracle_TableColumn.EntityID where Portal_ImportColumn.ImportID=@ImportID order by Portal_ImportColumn.ImportOrder"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntityByImportID(ByVal importID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ImportColumn where ImportID=@ImportID", myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Sub DeleteEntityByImportID(ByVal importID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ImportColumn where ImportID=@ImportID", myConnection)
			myCommand.Parameters.Add("@ImportID", SqlDbType.NVarChar, 29).Value = importID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal importOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ImportColumn set ImportOrder=@ImportOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ImportOrder", SqlDbType.Int, 4).Value = importOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

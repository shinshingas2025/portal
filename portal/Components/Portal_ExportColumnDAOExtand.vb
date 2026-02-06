Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ExportColumnDAOExtand
		Inherits Portal_ExportColumnDAO
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ExportColumn where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntityByExportID(ByVal exportID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ExportColumn where ExportID=@ExportID", myConnection)
			myCommand.Parameters.Add("@ExportID", SqlDbType.NVarChar, 29).Value = exportID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Sub DeleteEntityByExportID(ByVal exportID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ExportColumn where ExportID=@ExportID", myConnection)
			myCommand.Parameters.Add("@ExportID", SqlDbType.NVarChar, 29).Value = exportID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetEntitysByExportIDAndTableID(ByVal exportID As String, ByVal tableID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_ExportColumn.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_ExportColumn.ExportID as ExportID,"
			mySQLString = mySQLString + "Portal_ExportColumn.TableColumnID as TableColumnID,"
			mySQLString = mySQLString + "Portal_ExportColumn.ExportOrder as ExportOrder,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnName as ColumnName,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnType as ColumnType,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnSize as ColumnSize,"
			mySQLString = mySQLString + "Oracle_TableColumn.Description as Description,"
			mySQLString = mySQLString + "Portal_ExportColumn.CreatedByUser as CreatedByUser,"
			mySQLString = mySQLString + "Portal_ExportColumn.CreatedDate as CreatedDate "
			mySQLString = mySQLString + "from Portal_ExportColumn inner join Oracle_TableColumn on Portal_ExportColumn.TableColumnID=Oracle_TableColumn.EntityID where Portal_ExportColumn.ExportID=@ExportID and Oracle_TableColumn.TableID=@TableID order by Portal_ExportColumn.ExportOrder"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@ExportID", SqlDbType.NVarChar, 29).Value = exportID
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByExportID(ByVal exportID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_ExportColumn.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_ExportColumn.ExportID as ExportID,"
			mySQLString = mySQLString + "Portal_ExportColumn.TableColumnID as TableColumnID,"
			mySQLString = mySQLString + "Portal_ExportColumn.ExportOrder as ExportOrder,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnName as ColumnName,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnType as ColumnType,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnSize as ColumnSize,"
			mySQLString = mySQLString + "Oracle_TableColumn.ColumnAllowNull as ColumnAllowNull,"
			mySQLString = mySQLString + "Oracle_TableColumn.Description as Description,"
			mySQLString = mySQLString + "Portal_ExportColumn.CreatedByUser as CreatedByUser,"
			mySQLString = mySQLString + "Portal_ExportColumn.CreatedDate as CreatedDate "
			mySQLString = mySQLString + "from Portal_ExportColumn inner join Oracle_TableColumn on Portal_ExportColumn.TableColumnID=Oracle_TableColumn.EntityID where Portal_ExportColumn.ExportID=@ExportID order by Portal_ExportColumn.ExportOrder"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@ExportID", SqlDbType.NVarChar, 29).Value = exportID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal exportOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ExportColumn set ExportOrder=@ExportOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ExportOrder", SqlDbType.Int, 4).Value = exportOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 61).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

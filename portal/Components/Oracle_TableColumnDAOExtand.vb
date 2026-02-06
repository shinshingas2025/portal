Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Namespace ASPNET.StarterKit.Portal
	Public Class Oracle_TableColumnDAOExtand
		Inherits Oracle_TableColumnDAO
		Public Overrides Function GetEntitys(ByVal tableID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Oracle_TableColumn where TableID=@TableID order by ColumnOrder", myConnection)
			myCommand.Parameters.Add("@TableID", SqlDbType.NVarChar, 16).Value = tableID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace
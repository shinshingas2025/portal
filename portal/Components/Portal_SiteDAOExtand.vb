Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SiteDAOExtand
		Public Function GetEntitys(ByVal portalId As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Site where PortalId=@PortalId order by ItemID desc", myConnection)
			myCommand.Parameters.Add("@PortalId", SqlDbType.NVarChar, 4).Value = portalId
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Site order by ItemID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

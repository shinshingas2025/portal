Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SubscriptionListDAOExtand
		Inherits Portal_SubscriptionListDAO
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SubscriptionList where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalRow(ByVal subscriptionID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_SubscriptionList where SubscriptionID=@SubscriptionID", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
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
		Public Function GetEntitys(ByVal subscriptionID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SubscriptionList where SubscriptionID=@SubscriptionID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal subscriptionID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Portal_SubscriptionList where SubscriptionID=@SubscriptionID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Sub DeleteEntityBySubscriptionID(ByVal subscriptionID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_SubscriptionList where SubscriptionID=@SubscriptionID", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal deliverMark As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_SubscriptionList set DeliverMark=@DeliverMark where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@DeliverMark", SqlDbType.Int, 4).Value = deliverMark
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace
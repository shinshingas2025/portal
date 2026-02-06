Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ProcessAuditMapDAOExtand
		Inherits ProcessAuditMapDAO
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ProcessAuditMap order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ProcessAuditMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 40).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByProcessID(ByVal processID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ProcessAuditMap where ProcessID=@ProcessID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal processID As String, ByVal auditID As String, ByVal auditValue As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ProcessAuditMap set ProcessID=@ProcessID , AuditID=@AuditID , AuditValue=@AuditValue , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 16).Value = auditID
			myCommand.Parameters.Add("@AuditValue", SqlDbType.NVarChar, 32).Value = auditValue
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 48).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

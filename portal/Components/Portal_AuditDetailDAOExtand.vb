Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_AuditDetailDAOExtand
		Inherits Portal_AuditDetailDAO
		Public Overridable Function GetEntitysBySequenceID(ByVal auditID As String, ByVal sequenceID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_AuditDetail where AuditID=@AuditID and SequenceID=@SequenceID order by EntityID", myConnection)
			myCommand.Parameters.Add("@AuditID", SqlDbType.NVarChar, 29).Value = auditID
			myCommand.Parameters.Add("@SequenceID", SqlDbType.Int, 4).Value = sequenceID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

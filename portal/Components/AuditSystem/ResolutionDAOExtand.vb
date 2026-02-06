Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ResolutionDAOExtand
		Inherits ResolutionDAO
		Public Overridable Shadows Function DeleteEntity(ByVal entityID As String) As Integer
			Dim result As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from Resolution where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			result = myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return result
		End Function
		Public Overridable Function GetMaxResolutionNumber(ByVal resolutionNumber As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(ResolutionNumber) from Resolution where substring(ResolutionNumber,1,14)='" & resolutionNumber.Substring(0, 14) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(14, 2)
				Catch ex As System.InvalidCastException
					maxID = "00"
				End Try
			End While
			myReader.Close()
			valResult = CInt(maxID)
			valResult = valResult + 1
			Return resolutionNumber.Substring(0, 14) & Microsoft.VisualBasic.Right("00" & CStr(valResult), 2)
		End Function
		Public Overridable Function QueryByContent(ByVal content As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Resolution where Content like @Content order by EntityID", myConnection)
			content = "%" + content.Trim + "%"
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, content.Length).Value = content
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function QueryByResolutionNumber(ByVal resolutionNumber As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Resolution where ResolutionNumber=@ResolutionNumber order by EntityID", myConnection)
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Resolution where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Resolution order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal resolutionNumber As String, ByVal content As String, ByVal mainUnit As String, ByVal auditStateID As String, ByVal forecastDate As Date, ByVal finishID As Integer, ByVal note As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Resolution set ResolutionNumber=@ResolutionNumber , Content=@Content , MainUnit=@MainUnit , AuditStateID=@AuditStateID , ForecastDate=@ForecastDate , FinishID=@FinishID , Note=@Note , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ResolutionNumber", SqlDbType.NVarChar, 16).Value = resolutionNumber
			myCommand.Parameters.Add("@Content", SqlDbType.NVarChar, 1024).Value = content
			myCommand.Parameters.Add("@MainUnit", SqlDbType.NVarChar, 256).Value = mainUnit
			myCommand.Parameters.Add("@AuditStateID", SqlDbType.NVarChar, 24).Value = auditStateID
			myCommand.Parameters.Add("@ForecastDate", SqlDbType.DateTime, 8).Value = forecastDate
			myCommand.Parameters.Add("@FinishID", SqlDbType.Int, 4).Value = finishID
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar, 256).Value = note
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

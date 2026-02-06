Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class SecurityDAO
		Public Function GetUIDByLoginID(ByVal loginID As String) As Integer
			Dim valResult As Integer = 0
			Dim UID As String = ""
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select UID from sysSecurity where LoginID=@LoginID", myConnection)
			myCommand.Parameters.Add("@LoginID", SqlDbType.NVarChar, 20).Value = loginID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					UID = CStr(myReader.GetValue(0))
				Catch ex As System.InvalidCastException
					UID = ""
				End Try
			End While
			myReader.Close()
			Try
				valResult = CType(UID.Trim, Integer)
			Catch ex As Exception
				'cast failure
				valResult = 0
			End Try
			Return valResult
		End Function
	End Class
End Namespace
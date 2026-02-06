Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class DMS_MetaKeywordDAOExtand
		Inherits DMS_MetaKeywordDAO
		Public Overridable Function GetTotalRowByKeyword(ByVal myKeyword As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_MetaKeyword where Keyword=@Keyword", myConnection)
			myCommand.Parameters.Add("@Keyword", SqlDbType.NVarChar, 256).Value = myKeyword
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
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_MetaKeyword order by Keyword", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByKeyword(ByVal myKeyword As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_MetaKeyword where Keyword=@Keyword order by Keyword", myConnection)
			myCommand.Parameters.Add("@Keyword", SqlDbType.NVarChar, 256).Value = myKeyword
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

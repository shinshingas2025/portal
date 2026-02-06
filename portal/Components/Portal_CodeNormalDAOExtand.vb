Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_CodeNormalDAOExtand
		Inherits Portal_CodeNormalDAO
		Public Function GetEntitys(ByVal codeGroupID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_CodeNormal where CodeGroupID=@CodeGroupID order by DisplayOrder", myConnection)
			myCommand.Parameters.Add("@CodeGroupID", SqlDbType.NVarChar, 16).Value = codeGroupID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function

	End Class
End Namespace
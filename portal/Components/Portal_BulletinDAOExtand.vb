Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_BulletinDAOExtand
		Inherits Portal_BulletinDAO
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Portal_Bulletin where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Bulletin where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal imageURL As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal announceUnit As String, ByVal affiliatedURL As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Bulletin set TypeID=@TypeID,Title=@Title,Description=@Description,ImageURL=@ImageURL,EnableDate=@EnableDate,DisableDate=@DisableDate,AnnounceUnit=@AnnounceUnit,AffiliatedURL=@AffiliatedURL where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1600).Value = description
			myCommand.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 255).Value = imageURL
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@AnnounceUnit", SqlDbType.NVarChar, 100).Value = announceUnit
			myCommand.Parameters.Add("@AffiliatedURL", SqlDbType.NVarChar, 255).Value = affiliatedURL
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal typeID As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Bulletin set TypeID=@TypeID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

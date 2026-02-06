Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SubscriptionUserDAOExtand
		Inherits Portal_SubscriptionUserDAO
		Public Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Portal_SubscriptionUser where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetEntitys(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SubscriptionUser where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal email As String, ByVal sex As Integer, ByVal education As Integer, ByVal salary As Integer, ByVal birthday As Date, ByVal country As Integer, ByVal job As Integer, ByVal title As Integer, ByVal information As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_SubscriptionUser set Name=@Name,Email=@Email,Sex=@Sex,Education=@Education,Salary=@Salary,Birthday=@Birthday,Country=@Country,Job=@Job,Title=@Title,Information=@Information where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 32).Value = name
			myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email
			myCommand.Parameters.Add("@Sex", SqlDbType.Int, 4).Value = sex
			myCommand.Parameters.Add("@Education", SqlDbType.Int, 4).Value = education
			myCommand.Parameters.Add("@Salary", SqlDbType.Int, 4).Value = salary
			myCommand.Parameters.Add("@Birthday", SqlDbType.DateTime, 8).Value = birthday
			myCommand.Parameters.Add("@Country", SqlDbType.Int, 4).Value = country
			myCommand.Parameters.Add("@Job", SqlDbType.Int, 4).Value = job
			myCommand.Parameters.Add("@Title", SqlDbType.Int, 4).Value = title
			myCommand.Parameters.Add("@Information", SqlDbType.Int, 4).Value = information
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

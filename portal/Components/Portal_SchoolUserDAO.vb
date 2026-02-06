Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SchoolUserDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_SchoolUser", myConnection)
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
		Public Function GetEntity(ByVal schoolID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SchoolUser where SchoolID=@SchoolID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SchoolUser where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 21).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_SchoolUser where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 21).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function InsertEntity(ByVal schoolID As String, ByVal itemID As Integer, ByVal parentID As String, ByVal itemType As Integer, ByVal name As String, ByVal email As String, ByVal sex As Integer, ByVal birthday As Date, ByVal country As Integer, ByVal address As String, ByVal job As Integer, ByVal title As Integer, ByVal salary As Integer, ByVal major As Integer, ByVal academicYear As Integer, ByVal iDNumber As String, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_SchoolUser ( EntityID,SchoolID,ItemID,ParentID,ItemType,Name,Email,Sex,Birthday,Country,Address,Job,Title,Salary,Major,AcademicYear,IDNumber,CreatedByUser,CreatedDate ) values ( @EntityID,@SchoolID,@ItemID,@ParentID,@ItemType,@Name,@Email,@Sex,@Birthday,@Country,@Address,@Job,@Title,@Salary,@Major,@AcademicYear,@IDNumber,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 21).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(13, 8)))
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 21).Value = parentID
			myCommand.Parameters.Add("@ItemType", SqlDbType.Int, 4).Value = itemType
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 32).Value = name
			myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email
			myCommand.Parameters.Add("@Sex", SqlDbType.Int, 4).Value = sex
			myCommand.Parameters.Add("@Birthday", SqlDbType.DateTime, 8).Value = birthday
			myCommand.Parameters.Add("@Country", SqlDbType.Int, 4).Value = country
			myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = address
			myCommand.Parameters.Add("@Job", SqlDbType.Int, 4).Value = job
			myCommand.Parameters.Add("@Title", SqlDbType.Int, 4).Value = title
			myCommand.Parameters.Add("@Salary", SqlDbType.Int, 4).Value = salary
			myCommand.Parameters.Add("@Major", SqlDbType.Int, 4).Value = major
			myCommand.Parameters.Add("@AcademicYear", SqlDbType.Int, 4).Value = academicYear
			myCommand.Parameters.Add("@IDNumber", SqlDbType.NVarChar, 16).Value = iDNumber
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Sub UpdateEntity(ByVal entityID As String, ByVal schoolID As String, ByVal parentID As String, ByVal itemType As Integer, ByVal name As String, ByVal email As String, ByVal sex As Integer, ByVal birthday As Date, ByVal country As Integer, ByVal address As String, ByVal job As Integer, ByVal title As Integer, ByVal salary As Integer, ByVal major As Integer, ByVal academicYear As Integer, ByVal iDNumber As String, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_SchoolUser set SchoolID=@SchoolID,ParentID=@ParentID,ItemType=@ItemType,Name=@Name,Email=@Email,Sex=@Sex,Birthday=@Birthday,Country=@Country,Address=@Address,Job=@Job,Title=@Title,Salary=@Salary,Major=@Major,AcademicYear=@AcademicYear,IDNumber=@IDNumber,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 21).Value = parentID
			myCommand.Parameters.Add("@ItemType", SqlDbType.Int, 4).Value = itemType
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 32).Value = name
			myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email
			myCommand.Parameters.Add("@Sex", SqlDbType.Int, 4).Value = sex
			myCommand.Parameters.Add("@Birthday", SqlDbType.DateTime, 8).Value = birthday
			myCommand.Parameters.Add("@Country", SqlDbType.Int, 4).Value = country
			myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = address
			myCommand.Parameters.Add("@Job", SqlDbType.Int, 4).Value = job
			myCommand.Parameters.Add("@Title", SqlDbType.Int, 4).Value = title
			myCommand.Parameters.Add("@Salary", SqlDbType.Int, 4).Value = salary
			myCommand.Parameters.Add("@Major", SqlDbType.Int, 4).Value = major
			myCommand.Parameters.Add("@AcademicYear", SqlDbType.Int, 4).Value = academicYear
			myCommand.Parameters.Add("@IDNumber", SqlDbType.NVarChar, 16).Value = iDNumber
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 21).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_SchoolUser where substring(EntityID,1,13)='" & entityID.Substring(0, 13) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(13, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 13) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace
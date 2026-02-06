Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_BulletinDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Bulletin", myConnection)
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
		Public Overridable Function GetEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Bulletin where SchoolID=@SchoolID and ModuleID=@ModuleID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Bulletin where SchoolID=@SchoolID and ModuleID=@ModuleID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Bulletin where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_Bulletin where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal imageURL As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal announceUnit As String, ByVal createdByUser As String, ByVal createdDate As Date, ByVal affiliatedURL As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_Bulletin ( EntityID,SchoolID,ModuleID,ItemID,TypeID,Title,Description,ImageURL,EnableDate,DisableDate,AnnounceUnit,CreatedByUser,CreatedDate,AffiliatedURL ) values ( @EntityID,@SchoolID,@ModuleID,@ItemID,@TypeID,@Title,@Description,@ImageURL,@EnableDate,@DisableDate,@AnnounceUnit,@CreatedByUser,@CreatedDate,@AffiliatedURL )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000" & schoolID, 5) & Microsoft.VisualBasic.Right("00000000" & Hex(moduleID), 8) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(21, 8)))
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1600).Value = description
			myCommand.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 255).Value = imageURL
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@AnnounceUnit", SqlDbType.NVarChar, 100).Value = announceUnit
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@AffiliatedURL", SqlDbType.NVarChar, 255).Value = affiliatedURL
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal schoolID As String, ByVal moduleID As Integer, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal imageURL As String, ByVal enableDate As Date, ByVal disableDate As Date, ByVal announceUnit As String, ByVal createdByUser As String, ByVal createdDate As Date, ByVal affiliatedURL As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Bulletin set SchoolID=@SchoolID,ModuleID=@ModuleID,TypeID=@TypeID,Title=@Title,Description=@Description,ImageURL=@ImageURL,EnableDate=@EnableDate,DisableDate=@DisableDate,AnnounceUnit=@AnnounceUnit,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate,AffiliatedURL=@AffiliatedURL where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1600).Value = description
			myCommand.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 255).Value = imageURL
			myCommand.Parameters.Add("@EnableDate", SqlDbType.DateTime, 8).Value = enableDate
			myCommand.Parameters.Add("@DisableDate", SqlDbType.DateTime, 8).Value = disableDate
			myCommand.Parameters.Add("@AnnounceUnit", SqlDbType.NVarChar, 100).Value = announceUnit
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@AffiliatedURL", SqlDbType.NVarChar, 255).Value = affiliatedURL
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_Bulletin where substring(EntityID,1,21)='" & entityID.Substring(0, 21) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(21, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 21) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace
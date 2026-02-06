Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SiteDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_Site", myConnection)
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
		Public Function GetSingleEntity(ByVal itemID As Integer) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_Site where ItemID=@ItemID", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Sub DeleteEntity(ByVal itemID As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_Site where ItemID=@ItemID", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function InsertEntity(ByVal portalName As String, ByVal portalId As String, ByVal alwaysShowEditButton As String, ByVal imagelogo As String, ByVal schoolCode As String) As Integer
			Dim itemID As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_Site ( ItemID,PortalName,PortalId,AlwaysShowEditButton,imagelogo,SchoolCode ) values ( @ItemID,@PortalName,@PortalID,@AlwaysShowEditButton,@imagelogo,@SchoolCode )", myConnection)
			itemID = GetMaxEntityID() + 1
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myCommand.Parameters.Add("@PortalName", SqlDbType.NVarChar, 255).Value = portalName
			myCommand.Parameters.Add("@PortalId", SqlDbType.NVarChar, 4).Value = portalId
			myCommand.Parameters.Add("@AlwaysShowEditButton", SqlDbType.NVarChar, 50).Value = alwaysShowEditButton
			myCommand.Parameters.Add("@imagelogo", SqlDbType.NVarChar, 255).Value = imagelogo
			myCommand.Parameters.Add("@SchoolCode", SqlDbType.NVarChar, 10).Value = schoolCode
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return itemID
		End Function
		Public Sub UpdateEntity(ByVal itemID As Integer, ByVal portalName As String, ByVal portalId As String, ByVal alwaysShowEditButton As String, ByVal imagelogo As String, ByVal schoolCode As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_Site set PortalName=@PortalName,PortalId=@PortalId,AlwaysShowEditButton=@AlwaysShowEditButton,imagelogo=@imagelogo,SchoolCode=@SchoolCode where ItemID=@ItemID", myConnection)
			myCommand.Parameters.Add("@PortalName", SqlDbType.NVarChar, 255).Value = portalName
			myCommand.Parameters.Add("@PortalId", SqlDbType.NVarChar, 4).Value = portalId
			myCommand.Parameters.Add("@AlwaysShowEditButton", SqlDbType.NVarChar, 50).Value = alwaysShowEditButton
			myCommand.Parameters.Add("@imagelogo", SqlDbType.NVarChar, 255).Value = imagelogo
			myCommand.Parameters.Add("@SchoolCode", SqlDbType.NVarChar, 10).Value = schoolCode
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function GetMaxEntityID() As Integer
			Dim maxID As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(ItemID) from Portal_Site"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CInt(myReader.GetValue(0))
				Catch ex As System.InvalidCastException
					maxID = 0
				End Try
			End While
			myReader.Close()
			Return maxID
		End Function
	End Class
End Namespace
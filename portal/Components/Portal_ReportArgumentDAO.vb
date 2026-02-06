Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_ReportArgumentDAO
		Public Overridable Function GetEntity(ByVal reportID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportArgument where ReportID=@ReportID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ReportID", SqlDbType.NVarChar, 24).Value = reportID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal reportID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportArgument where ReportID=@ReportID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ReportID", SqlDbType.NVarChar, 24).Value = reportID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_ReportArgument where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_ReportArgument where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal reportID As String, ByVal itemID As Integer, ByVal argumentName As String, ByVal argumentType As Integer, ByVal argumentSize As Integer, ByVal argumentOrder As Integer, ByVal allowNull As Integer, ByVal title As String, ByVal uIType As Integer, ByVal displayOrder As Integer, ByVal state As Integer, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_ReportArgument ( EntityID,ReportID,ItemID,ArgumentName,ArgumentType,ArgumentSize,ArgumentOrder,AllowNull,Title,UIType,DisplayOrder,State,CreatedByUser,CreatedDate ) values ( @EntityID,@ReportID,@ItemID,@ArgumentName,@ArgumentType,@ArgumentSize,@ArgumentOrder,@AllowNull,@Title,@UIType,@DisplayOrder,@State,@CreatedByUser,@CreatedDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("000000000000000000000000" & reportID, 24) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myCommand.Parameters.Add("@ReportID", SqlDbType.NVarChar, 24).Value = reportID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(24, 8)))
			myCommand.Parameters.Add("@ArgumentName", SqlDbType.NVarChar, 100).Value = argumentName
			myCommand.Parameters.Add("@ArgumentType", SqlDbType.Int, 4).Value = argumentType
			myCommand.Parameters.Add("@ArgumentSize", SqlDbType.Int, 4).Value = argumentSize
			myCommand.Parameters.Add("@ArgumentOrder", SqlDbType.Int, 4).Value = argumentOrder
			myCommand.Parameters.Add("@AllowNull", SqlDbType.Int, 4).Value = allowNull
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@UIType", SqlDbType.Int, 4).Value = uIType
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal reportID As String, ByVal argumentName As String, ByVal argumentType As Integer, ByVal argumentSize As Integer, ByVal argumentOrder As Integer, ByVal allowNull As Integer, ByVal title As String, ByVal uIType As Integer, ByVal displayOrder As Integer, ByVal state As Integer, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_ReportArgument set ReportID=@ReportID and ArgumentName=@ArgumentName and ArgumentType=@ArgumentType and ArgumentSize=@ArgumentSize and ArgumentOrder=@ArgumentOrder and AllowNull=@AllowNull and Title=@Title and UIType=@UIType and DisplayOrder=@DisplayOrder and State=@State and CreatedByUser=@CreatedByUser and CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ReportID", SqlDbType.NVarChar, 24).Value = reportID
			myCommand.Parameters.Add("@ArgumentName", SqlDbType.NVarChar, 100).Value = argumentName
			myCommand.Parameters.Add("@ArgumentType", SqlDbType.Int, 4).Value = argumentType
			myCommand.Parameters.Add("@ArgumentSize", SqlDbType.Int, 4).Value = argumentSize
			myCommand.Parameters.Add("@ArgumentOrder", SqlDbType.Int, 4).Value = argumentOrder
			myCommand.Parameters.Add("@AllowNull", SqlDbType.Int, 4).Value = allowNull
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 100).Value = title
			myCommand.Parameters.Add("@UIType", SqlDbType.Int, 4).Value = uIType
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 32).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_ReportArgument where substring(EntityID,1,24)='" & entityID.substring(0, 24) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.substring(24, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.substring(0, 24) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_ReportArgument", myConnection)
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
	End Class
End Namespace
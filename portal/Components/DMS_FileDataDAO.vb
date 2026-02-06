Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class DMS_FileDataDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_FileData where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_FileData where  order by EntityID desc", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from DMS_FileData where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from DMS_FileData where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer,ByVal data As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into DMS_FileData ( EntityID,ItemID,Data ) values ( @EntityID,@ItemID,@Data )", myConnection)
			Dim today As Date = Now
			entityID=today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(),2) & Microsoft.VisualBasic.Right("00" & today.Day(),2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(8,8)))
			myCommand.Parameters.Add("@Data", SqlDbType.Image,16).Value=data
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal data As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update DMS_FileData set Data=@Data where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Data", SqlDbType.Image,16).Value=data
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL="select max(EntityID) from DMS_FileData where substring(EntityID,1,8)='" & entityID.substring(0,8) & "'"
			Dim myCommand As New SqlCommand(selectSQL,myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID=CStr(myReader.GetValue(0))
					maxID=maxID.substring(8,8)
				Catch ex As System.InvalidCastException
					maxID="00000000"
				End Try
			End While
			myReader.Close()
			valResult=CInt(Val("&H"&maxID))
			valResult=valResult+1
			Return entityID.substring(0,8) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)),8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from DMS_FileData", myConnection)
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

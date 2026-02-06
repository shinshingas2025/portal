Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_SubscriptionListDAO
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_SubscriptionList", myConnection)
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
		Public Function GetEntity(ByVal subscriptionID As String, ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SubscriptionList where SubscriptionID=@SubscriptionID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_SubscriptionList where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_SubscriptionList where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function InsertEntity(ByVal subscriptionID As String, ByVal itemID As Integer, ByVal userType As Integer, ByVal userID As String, ByVal deliverMark As Integer, ByVal createdByUser As String, ByVal createdDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_SubscriptionList ( EntityID,SubscriptionID,ItemID,UserType,UserID,DeliverMark,CreatedByUser,CreatedDate ) values ( @EntityID,@SubscriptionID,@ItemID,@UserType,@UserID,@DeliverMark,@CreatedByUser,@CreatedDate )", myConnection)
			Dim today As Date = Now
			entityID = Microsoft.VisualBasic.Right("00000000000000000000000000000" & subscriptionID, 29) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(29, 8)))
			myCommand.Parameters.Add("@UserType", SqlDbType.Int, 4).Value = userType
			myCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 29).Value = userID
			myCommand.Parameters.Add("@DeliverMark", SqlDbType.Int, 4).Value = deliverMark
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Sub UpdateEntity(ByVal entityID As String, ByVal subscriptionID As String, ByVal userType As Integer, ByVal userID As String, ByVal deliverMark As Integer, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_SubscriptionList set SubscriptionID=@SubscriptionID,UserType=@UserType,UserID=@UserID,DeliverMark=@DeliverMark,CreatedByUser=@CreatedByUser,CreatedDate=@CreatedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@SubscriptionID", SqlDbType.NVarChar, 29).Value = subscriptionID
			myCommand.Parameters.Add("@UserType", SqlDbType.Int, 4).Value = userType
			myCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 29).Value = userID
			myCommand.Parameters.Add("@DeliverMark", SqlDbType.Int, 4).Value = deliverMark
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 37).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from Portal_SubscriptionList where substring(EntityID,1,29)='" & entityID.Substring(0, 29) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(29, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 29) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
	End Class
End Namespace
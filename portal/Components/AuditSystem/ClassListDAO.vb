Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ClassListDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ClassList where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ClassList where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ClassList where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Function DeleteEntity(ByVal entityID As String) As Integer
			Dim result As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from ClassList where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			result=myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return result
		End Function
		Public Overridable Function InsertEntity(ByVal itemID As Integer,ByVal classID As Integer,ByVal studentID As String,ByVal studentName As String,ByVal studentBirth As Date,ByVal classType As String,ByVal classNumber As Integer,ByVal classEmail As String,ByVal remark As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into ClassList ( EntityID,ItemID,ClassID,StudentID,StudentName,StudentBirth,ClassType,ClassNumber,ClassEmail,Remark,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ) values ( @EntityID,@ItemID,@ClassID,@StudentID,@StudentName,@StudentBirth,@ClassType,@ClassNumber,@ClassEmail,@Remark,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate )", myConnection)
			Dim today As Date = Now
			entityID=today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(),2) & Microsoft.VisualBasic.Right("00" & today.Day(),2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(8,8)))
			myCommand.Parameters.Add("@ClassID", SqlDbType.Int,4).Value=classID
			myCommand.Parameters.Add("@StudentID", SqlDbType.NVarChar,20).Value=studentID
			myCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar,50).Value=studentName
			myCommand.Parameters.Add("@StudentBirth", SqlDbType.DateTime,8).Value=studentBirth
			myCommand.Parameters.Add("@ClassType", SqlDbType.NChar,10).Value=classType
			myCommand.Parameters.Add("@ClassNumber", SqlDbType.Int,4).Value=classNumber
			myCommand.Parameters.Add("@ClassEmail", SqlDbType.NVarChar,100).Value=classEmail
			myCommand.Parameters.Add("@Remark", SqlDbType.NVarChar,255).Value=remark
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal classID As Integer,ByVal studentID As String,ByVal studentName As String,ByVal studentBirth As Date,ByVal classType As String,ByVal classNumber As Integer,ByVal classEmail As String,ByVal remark As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ClassList set ClassID=@ClassID , StudentID=@StudentID , StudentName=@StudentName , StudentBirth=@StudentBirth , ClassType=@ClassType , ClassNumber=@ClassNumber , ClassEmail=@ClassEmail , Remark=@Remark , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ClassID", SqlDbType.Int,4).Value=classID
			myCommand.Parameters.Add("@StudentID", SqlDbType.NVarChar,20).Value=studentID
			myCommand.Parameters.Add("@StudentName", SqlDbType.NVarChar,50).Value=studentName
			myCommand.Parameters.Add("@StudentBirth", SqlDbType.DateTime,8).Value=studentBirth
			myCommand.Parameters.Add("@ClassType", SqlDbType.NChar,10).Value=classType
			myCommand.Parameters.Add("@ClassNumber", SqlDbType.Int,4).Value=classNumber
			myCommand.Parameters.Add("@ClassEmail", SqlDbType.NVarChar,100).Value=classEmail
			myCommand.Parameters.Add("@Remark", SqlDbType.NVarChar,255).Value=remark
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL="select max(EntityID) from ClassList where substring(EntityID,1,8)='" & entityID.substring(0,8) & "'"
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
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from ClassList", myConnection)
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

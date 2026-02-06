Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class MajorMemberCaseTracertDAO
		Public Overridable Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MajorMemberCaseTracert where entityID=@entityID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@entityID", SqlDbType.NVarChar, 32).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal txtDateS As Date, ByVal txtDateE As Date) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MajorMemberCaseTracert where ComeFromDate between @txtDateS and @txtDateE  order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@txtDateS", SqlDbType.DateTime, 4).Value = txtDateS
			myCommand.Parameters.Add("@txtDateE", SqlDbType.DateTime, 4).Value = txtDateE
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from MajorMemberCaseTracert where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from MajorMemberCaseTracert where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal comeFrom As String, ByVal comeFromDate As Date, ByVal toDoDate As Date, ByVal unit As String, ByVal deadLine As Date, ByVal cases As String, ByVal workStatus As String, ByVal remark As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into MajorMemberCaseTracert ( EntityID,ItemID,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate,ComeFrom,ComeFromDate,ToDoDate,Unit,DeadLine,Cases,WorkStatus,Remark ) values ( @EntityID,@ItemID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate,@ComeFrom,@ComeFromDate,@ToDoDate,@Unit,@DeadLine,@Cases,@WorkStatus,@Remark )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@ComeFrom", SqlDbType.NVarChar, 50).Value = comeFrom
			myCommand.Parameters.Add("@ComeFromDate", SqlDbType.DateTime, 8).Value = comeFromDate
			myCommand.Parameters.Add("@ToDoDate", SqlDbType.DateTime, 8).Value = toDoDate
			myCommand.Parameters.Add("@Unit", SqlDbType.NVarChar, 50).Value = unit
			myCommand.Parameters.Add("@DeadLine", SqlDbType.DateTime, 8).Value = deadLine
			myCommand.Parameters.Add("@Cases", SqlDbType.NVarChar, 1500).Value = cases
			myCommand.Parameters.Add("@WorkStatus", SqlDbType.NVarChar, 2000).Value = workStatus
			myCommand.Parameters.Add("@Remark", SqlDbType.NChar, 50).Value = remark
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal comeFrom As String, ByVal comeFromDate As Date, ByVal toDoDate As Date, ByVal unit As String, ByVal deadLine As Date, ByVal cases As String, ByVal workStatus As String, ByVal remark As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update MajorMemberCaseTracert set CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate , ComeFrom=@ComeFrom , ComeFromDate=@ComeFromDate , ToDoDate=@ToDoDate , Unit=@Unit , DeadLine=@DeadLine , Cases=@Cases , WorkStatus=@WorkStatus , Remark=@Remark where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@ComeFrom", SqlDbType.NVarChar, 50).Value = comeFrom
			myCommand.Parameters.Add("@ComeFromDate", SqlDbType.DateTime, 8).Value = comeFromDate
			myCommand.Parameters.Add("@ToDoDate", SqlDbType.DateTime, 8).Value = toDoDate
			myCommand.Parameters.Add("@Unit", SqlDbType.NVarChar, 50).Value = unit
			myCommand.Parameters.Add("@DeadLine", SqlDbType.DateTime, 8).Value = deadLine
			myCommand.Parameters.Add("@Cases", SqlDbType.NVarChar, 1500).Value = cases
			myCommand.Parameters.Add("@WorkStatus", SqlDbType.NVarChar, 2000).Value = workStatus
			myCommand.Parameters.Add("@Remark", SqlDbType.NChar, 50).Value = remark
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from MajorMemberCaseTracert where substring(EntityID,1,8)='" & entityID.Substring(0, 8) & "'"
			Dim myCommand As New SqlCommand(selectSQL, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CStr(myReader.GetValue(0))
					maxID = maxID.Substring(8, 8)
				Catch ex As System.InvalidCastException
					maxID = "00000000"
				End Try
			End While
			myReader.Close()
			valResult = CInt(Val("&H" & maxID))
			valResult = valResult + 1
			Return entityID.Substring(0, 8) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from MajorMemberCaseTracert", myConnection)
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

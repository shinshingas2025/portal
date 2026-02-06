Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class CouncilmanInstructionCouncilmanMapDAO
		Public Overridable Function GetEntity(ByVal councilmanInstructionID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstructionCouncilmanMap where CouncilmanInstructionID=@CouncilmanInstructionID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar,16).Value=councilmanInstructionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal councilmanInstructionID As String,ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstructionCouncilmanMap where CouncilmanInstructionID=@CouncilmanInstructionID and ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar,16).Value=councilmanInstructionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstructionCouncilmanMap where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from CouncilmanInstructionCouncilmanMap where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal councilmanInstructionID As String,ByVal itemID As Integer,ByVal typeID As Integer,ByVal councilmanID As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into CouncilmanInstructionCouncilmanMap ( EntityID,CouncilmanInstructionID,ItemID,TypeID,CouncilmanID,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ) values ( @EntityID,@CouncilmanInstructionID,@ItemID,@TypeID,@CouncilmanID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000" & councilmanInstructionID, 16) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar,16).Value=councilmanInstructionID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(24,8)))
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int,4).Value=typeID
			myCommand.Parameters.Add("@CouncilmanID", SqlDbType.NVarChar,24).Value=councilmanID
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
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal councilmanInstructionID As String,ByVal typeID As Integer,ByVal councilmanID As String,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstructionCouncilmanMap set CouncilmanInstructionID=@CouncilmanInstructionID , TypeID=@TypeID , CouncilmanID=@CouncilmanID , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@CouncilmanInstructionID", SqlDbType.NVarChar,16).Value=councilmanInstructionID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int,4).Value=typeID
			myCommand.Parameters.Add("@CouncilmanID", SqlDbType.NVarChar,24).Value=councilmanID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar,50).Value=creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value=createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar,50).Value=modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime,8).Value=modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar,16).Value=permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar,16).Value=permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int,4).Value=state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime,8).Value=deletedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 24).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function GetMaxEntityID(ByVal entityID As String) As String
			Dim maxID As String
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim selectSQL As String
			selectSQL = "select max(EntityID) from CouncilmanInstructionCouncilmanMap where substring(EntityID,1,16)='" & entityID.Substring(0, 16) & "'"
			Dim myCommand As New SqlCommand(selectSQL,myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID=CStr(myReader.GetValue(0))
					maxID = maxID.Substring(16, 8)
				Catch ex As System.InvalidCastException
					maxID="00000000"
				End Try
			End While
			myReader.Close()
			valResult=CInt(Val("&H"&maxID))
			valResult=valResult+1
			Return entityID.Substring(0, 16) & Microsoft.VisualBasic.Right("00000000" & CStr(Hex(valResult)), 8)
		End Function
		Public Overridable Function GetTotalRow() As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from CouncilmanInstructionCouncilmanMap", myConnection)
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

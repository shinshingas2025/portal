Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class LawDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntitys(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from Law where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer, ByVal name As String, ByVal discussionID As String, ByVal constitutionDate As Date, ByVal parentID As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal variationTypeID As String, ByVal constitutionInstitutionID As String, ByVal undertakerInstitutionID As String, ByVal documentNumber As String, ByVal typeID As String) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into Law ( EntityID,ItemID,Name,DiscussionID,ConstitutionDate,ParentID,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate,VariationTypeID,ConstitutionInstitutionID,UndertakerInstitutionID,DocumentNumber,TypeID ) values ( @EntityID,@ItemID,@Name,@DiscussionID,@ConstitutionDate,@ParentID,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate,@VariationTypeID,@ConstitutionInstitutionID,@UndertakerInstitutionID,@DocumentNumber,@TypeID )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@DiscussionID", SqlDbType.NVarChar, 24).Value = discussionID
			myCommand.Parameters.Add("@ConstitutionDate", SqlDbType.DateTime, 8).Value = constitutionDate
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@VariationTypeID", SqlDbType.NVarChar, 24).Value = variationTypeID
			myCommand.Parameters.Add("@ConstitutionInstitutionID", SqlDbType.NVarChar, 24).Value = constitutionInstitutionID
			myCommand.Parameters.Add("@UndertakerInstitutionID", SqlDbType.NVarChar, 24).Value = undertakerInstitutionID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal discussionID As String, ByVal constitutionDate As Date, ByVal parentID As String, ByVal creatorID As String, ByVal createdDate As Date, ByVal modifierID As String, ByVal modifiedDate As Date, ByVal permission As String, ByVal permissionGroup As String, ByVal state As Integer, ByVal deletedDate As Date, ByVal variationTypeID As String, ByVal constitutionInstitutionID As String, ByVal undertakerInstitutionID As String, ByVal documentNumber As String, ByVal typeID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Law set Name=@Name , DiscussionID=@DiscussionID , ConstitutionDate=@ConstitutionDate , ParentID=@ParentID , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate , VariationTypeID=@VariationTypeID , ConstitutionInstitutionID=@ConstitutionInstitutionID , UndertakerInstitutionID=@UndertakerInstitutionID , DocumentNumber=@DocumentNumber , TypeID=@TypeID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@DiscussionID", SqlDbType.NVarChar, 24).Value = discussionID
			myCommand.Parameters.Add("@ConstitutionDate", SqlDbType.DateTime, 8).Value = constitutionDate
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 50).Value = creatorID
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@Permission", SqlDbType.NVarChar, 16).Value = permission
			myCommand.Parameters.Add("@PermissionGroup", SqlDbType.NVarChar, 16).Value = permissionGroup
			myCommand.Parameters.Add("@State", SqlDbType.Int, 4).Value = state
			myCommand.Parameters.Add("@DeletedDate", SqlDbType.DateTime, 8).Value = deletedDate
			myCommand.Parameters.Add("@VariationTypeID", SqlDbType.NVarChar, 24).Value = variationTypeID
			myCommand.Parameters.Add("@ConstitutionInstitutionID", SqlDbType.NVarChar, 24).Value = constitutionInstitutionID
			myCommand.Parameters.Add("@UndertakerInstitutionID", SqlDbType.NVarChar, 24).Value = undertakerInstitutionID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
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
			selectSQL = "select max(EntityID) from Law where substring(EntityID,1,8)='" & entityID.Substring(0, 8) & "'"
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
			Dim myCommand As New SqlCommand("select count(*) from Law", myConnection)
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

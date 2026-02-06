Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class CouncilmanInstructionDAO
		Public Overridable Function GetEntity(ByVal itemID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstruction where ItemID=@ItemID order by EntityID desc", myConnection)
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		'Public Overridable Function GetEntitys(ByVal itemID As Integer) As DataSet
		'	Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
		'	Dim myCommand As New SqlCommand("select * from CouncilmanInstruction where ItemID=@ItemID order by EntityID desc", myConnection)
		'	myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=itemID
		'	Dim myAdapter As New SqlDataAdapter(myCommand)
		'	Dim myDataSet As New DataSet
		'	myAdapter.Fill(myDataSet)
		'	Return myDataSet
		'End Function
		Public Overridable Function GetSingleEntity(ByVal entityID As String) As SqlDataReader
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from CouncilmanInstruction where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			Dim myReader As SqlDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myReader
		End Function
		Public Overridable Sub DeleteEntity(ByVal entityID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("delete from CouncilmanInstruction where EntityID=@EntityID",myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overridable Function InsertEntity(ByVal itemID As Integer,ByVal title As String,ByVal description As String,ByVal instruction As String,ByVal note As String,ByVal instructionDate As Date,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date) As String
			Dim entityID As String
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into CouncilmanInstruction ( EntityID,ItemID,Title,Description,Instruction,Note,InstructionDate,CreatorID,CreatedDate,ModifierID,ModifiedDate,Permission,PermissionGroup,State,DeletedDate ) values ( @EntityID,@ItemID,@Title,@Description,@Instruction,@Note,@InstructionDate,@CreatorID,@CreatedDate,@ModifierID,@ModifiedDate,@Permission,@PermissionGroup,@State,@DeletedDate )", myConnection)
			Dim today As Date = Now
			entityID=today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(),2) & Microsoft.VisualBasic.Right("00" & today.Day(),2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID),8)
			entityID=GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar,16).Value=entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int,4).Value=CInt(Val("&H" & entityID.Substring(8,8)))
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar,128).Value=title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar,256).Value=description
			myCommand.Parameters.Add("@Instruction", SqlDbType.NVarChar,1024).Value=instruction
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar,256).Value=note
			myCommand.Parameters.Add("@InstructionDate", SqlDbType.DateTime,8).Value=instructionDate
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
		Public Overridable Sub UpdateEntity(ByVal entityID As String,ByVal title As String,ByVal description As String,ByVal instruction As String,ByVal note As String,ByVal instructionDate As Date,ByVal creatorID As String,ByVal createdDate As Date,ByVal modifierID As String,ByVal modifiedDate As Date,ByVal permission As String,ByVal permissionGroup As String,ByVal state As Integer,ByVal deletedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update CouncilmanInstruction set Title=@Title , Description=@Description , Instruction=@Instruction , Note=@Note , InstructionDate=@InstructionDate , CreatorID=@CreatorID , CreatedDate=@CreatedDate , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , Permission=@Permission , PermissionGroup=@PermissionGroup , State=@State , DeletedDate=@DeletedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar,128).Value=title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar,256).Value=description
			myCommand.Parameters.Add("@Instruction", SqlDbType.NVarChar,1024).Value=instruction
			myCommand.Parameters.Add("@Note", SqlDbType.NVarChar,256).Value=note
			myCommand.Parameters.Add("@InstructionDate", SqlDbType.DateTime,8).Value=instructionDate
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
			selectSQL="select max(EntityID) from CouncilmanInstruction where substring(EntityID,1,8)='" & entityID.substring(0,8) & "'"
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
			Dim myCommand As New SqlCommand("select count(*) from CouncilmanInstruction", myConnection)
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

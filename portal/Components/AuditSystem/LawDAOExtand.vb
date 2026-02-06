Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class LawDAOExtand
		Inherits LawDAO
		Public Overloads Function GetEntitysByEntityID(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntityIDAndParentID() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID,ParentID from Law order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetEntityIDByParentID(ByVal parentID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select EntityID from Law where ParentID=@ParentID order by EntityID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Law order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law order by EntityID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByParentID(ByVal parentID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Law where ParentID=@ParentID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
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
		Public Overloads Function GetEntitysByParentID(ByVal parentID As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select top " & rowCount & " * from Law where ParentID=@ParentID order by EntityID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByParentID(ByVal parentID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from Law where ParentID=@ParentID order by EntityID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function InsertEntity(ByVal name As String, ByVal discussionID As String, ByVal constitutionDate As Date, ByVal parentID As String, ByVal variationTypeID As String, ByVal constitutionInstitutionID As String, ByVal undertakerInstitutionID As String, ByVal documentNumber As String, ByVal typeID As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into Law ( EntityID,ItemID,Name,DiscussionID,ConstitutionDate,ParentID,VariationTypeID,ConstitutionInstitutionID,UndertakerInstitutionID,DocumentNumber,TypeID ) values ( @EntityID,@ItemID,@Name,@DiscussionID,@ConstitutionDate,@ParentID,@VariationTypeID,@ConstitutionInstitutionID,@UndertakerInstitutionID,@DocumentNumber,@TypeID )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@DiscussionID", SqlDbType.NVarChar, 24).Value = discussionID
			myCommand.Parameters.Add("@ConstitutionDate", SqlDbType.DateTime, 8).Value = constitutionDate
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
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
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal discussionID As String, ByVal constitutionDate As Date, ByVal parentID As String, ByVal variationTypeID As String, ByVal constitutionInstitutionID As String, ByVal undertakerInstitutionID As String, ByVal documentNumber As String, ByVal typeID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Law set Name=@Name , DiscussionID=@DiscussionID , ConstitutionDate=@ConstitutionDate , ParentID=@ParentID , VariationTypeID=@VariationTypeID , ConstitutionInstitutionID=@ConstitutionInstitutionID , UndertakerInstitutionID=@UndertakerInstitutionID , DocumentNumber=@DocumentNumber , TypeID=@TypeID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@DiscussionID", SqlDbType.NVarChar, 24).Value = discussionID
			myCommand.Parameters.Add("@ConstitutionDate", SqlDbType.DateTime, 8).Value = constitutionDate
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
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
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal name As String, ByVal discussionID As String, ByVal constitutionDate As Date, ByVal parentID As String, ByVal variationTypeID As String, ByVal constitutionInstitutionID As String, ByVal undertakerInstitutionID As String, ByVal documentNumber As String, ByVal typeID As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update Law set Name=@Name , DiscussionID=@DiscussionID , ConstitutionDate=@ConstitutionDate , ParentID=@ParentID , VariationTypeID=@VariationTypeID , ConstitutionInstitutionID=@ConstitutionInstitutionID , UndertakerInstitutionID=@UndertakerInstitutionID , DocumentNumber=@DocumentNumber , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate , TypeID=@TypeID where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = name
			myCommand.Parameters.Add("@DiscussionID", SqlDbType.NVarChar, 24).Value = discussionID
			myCommand.Parameters.Add("@ConstitutionDate", SqlDbType.DateTime, 8).Value = constitutionDate
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@VariationTypeID", SqlDbType.NVarChar, 24).Value = variationTypeID
			myCommand.Parameters.Add("@ConstitutionInstitutionID", SqlDbType.NVarChar, 24).Value = constitutionInstitutionID
			myCommand.Parameters.Add("@UndertakerInstitutionID", SqlDbType.NVarChar, 24).Value = undertakerInstitutionID
			myCommand.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar, 32).Value = documentNumber
			myCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar, 24).Value = typeID
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

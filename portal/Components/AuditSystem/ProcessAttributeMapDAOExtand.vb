Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ProcessAttributeMapDAOExtand
		Inherits ProcessAttributeMapDAO
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal attributeValue As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ProcessAttributeMap set AttributeValue=@AttributeValue where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@AttributeValue", SqlDbType.NVarChar, 16).Value = attributeValue
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 48).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal attributeValue As String, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ProcessAttributeMap set AttributeValue=@AttributeValue , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@AttributeValue", SqlDbType.NVarChar, 16).Value = attributeValue
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 48).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal processID As String, ByVal attributeID As String, ByVal attributeValue As String) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into ProcessAttributeMap ( EntityID,ProcessID,ItemID,AttributeID,AttributeValue ) values ( @EntityID,@ProcessID,@ItemID,@AttributeID,@AttributeValue )", myConnection)
			entityID = Microsoft.VisualBasic.Right("0000000000000000000000000000000000000000" & processID, 40) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 48).Value = entityID
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(40, 8)))
			myCommand.Parameters.Add("@AttributeID", SqlDbType.NVarChar, 16).Value = attributeID
			myCommand.Parameters.Add("@AttributeValue", SqlDbType.NVarChar, 32).Value = attributeValue
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overridable Function GetTotalRowByProcessIDAndAttributeID(ByVal processID As String, ByVal attributeID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from ProcessAttributeMap where ProcessID=@ProcessID and AttributeID=@AttributeID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			myCommand.Parameters.Add("@AttributeID", SqlDbType.NVarChar, 40).Value = attributeID
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
		Public Overridable Function GetEntitysByProcessIDAndAttributeID(ByVal processID As String, ByVal attributeID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ProcessAttributeMap where ProcessID=@ProcessID and AttributeID=@AttributeID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			myCommand.Parameters.Add("@AttributeID", SqlDbType.NVarChar, 40).Value = attributeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Function GetTotalRowByProcessID(ByVal processID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from ProcessAttributeMap where ProcessID=@ProcessID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
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
		Public Overridable Function GetEntitysByProcessID(ByVal processID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ProcessAttributeMap where ProcessID=@ProcessID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		'Public Overridable Function GetEntitysByProcessID(ByVal processID As String) As DataSet
		'	Dim mySQLString As String = ""
		'	Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
		'	mySQLString = "select "
		'	mySQLString = "ProcessAttributeMap.EntityID as EntityID,"
		'	mySQLString = "ProcessAttributeMap.ProcessID as ProcessID,"
		'	mySQLString = "ProcessAttributeMap.ItemID as ItemID,"
		'	mySQLString = "ProcessAttributeMap.PermissionGroup as PermissionGroup,"
		'	mySQLString = "ProcessAttributeMap.Permission as Permission,"
		'	mySQLString = "ProcessAttributeMap.AttributeID as AttributeID,"
		'	mySQLString = "ProcessAttributeMap.AttributeValue as AttributeValue,"
		'	mySQLString = "ProcessAttributeMap.CreatorID as CreatorID,"
		'	mySQLString = "ProcessAttributeMap.CreatedDate as CreatedDate,"
		'	mySQLString = "ProcessAttributeMap.ModifierID as ModifierID,"
		'	mySQLString = "ProcessAttributeMap.ModifiedDate as ModifiedDate,"
		'	mySQLString = "ProcessAttributeMap.State as State,"
		'	mySQLString = "ProcessAttributeMap.DeletedDate as DeletedDate,"
		'	Dim myCommand As New SqlCommand("select * from ProcessAttributeMap inner join ProcessAttributeCode on ProcessAttributeMap.AttributeID=ProcessAttributeCode.EntityID where ProcessAttributeMap.ProcessID=@ProcessID order by ProcessAttributeCode.DisplayOrder", myConnection)
		'	myCommand.Parameters.Add("@ProcessID", SqlDbType.NVarChar, 40).Value = processID
		'	Dim myAdapter As New SqlDataAdapter(myCommand)
		'	Dim myDataSet As New DataSet
		'	myAdapter.Fill(myDataSet)
		'	Return myDataSet
		'End Function
	End Class
End Namespace

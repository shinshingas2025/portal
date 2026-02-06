Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal.AuditSystem.DAO

Namespace ASPNET.StarterKit.Portal.AuditSystem.DAO
	Public Class ControlDefinitionDAOExtand
		Inherits ControlDefinitionDAO
		Public Overridable Function GetTotalRowByParentID(ByVal parentID As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select count(*) from ControlDefinition where ParentID=@ParentID", myConnection)
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
		Public Overridable Function GetEntitysByParentID(ByVal parentID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ControlDefinition where ParentID=@ParentID order by ItemID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal parentID As String, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal mobileSourceFile As String, ByVal desktopSourceFile As String, ByVal rowPosition As Integer, ByVal columnPosition As Integer, ByVal rowSpan As Integer, ByVal columnSpan As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ControlDefinition set ParentID=@ParentID , TypeID=@TypeID , Title=@Title , Description=@Description , MobileSourceFile=@MobileSourceFile , DesktopSourceFile=@DesktopSourceFile , RowPosition=@RowPosition , ColumnPosition=@ColumnPosition , RowSpan=@RowSpan , ColumnSpan=@ColumnSpan where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 64).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@MobileSourceFile", SqlDbType.NVarChar, 256).Value = mobileSourceFile
			myCommand.Parameters.Add("@DesktopSourceFile", SqlDbType.NVarChar, 256).Value = desktopSourceFile
			myCommand.Parameters.Add("@RowPosition", SqlDbType.Int, 4).Value = rowPosition
			myCommand.Parameters.Add("@ColumnPosition", SqlDbType.Int, 4).Value = columnPosition
			myCommand.Parameters.Add("@RowSpan", SqlDbType.Int, 4).Value = rowSpan
			myCommand.Parameters.Add("@ColumnSpan", SqlDbType.Int, 4).Value = columnSpan
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal parentID As String, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal mobileSourceFile As String, ByVal desktopSourceFile As String, ByVal rowPosition As Integer, ByVal columnPosition As Integer, ByVal rowSpan As Integer, ByVal columnSpan As Integer, ByVal modifierID As String, ByVal modifiedDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("update ControlDefinition set ParentID=@ParentID , TypeID=@TypeID , Title=@Title , Description=@Description , MobileSourceFile=@MobileSourceFile , DesktopSourceFile=@DesktopSourceFile , RowPosition=@RowPosition , ColumnPosition=@ColumnPosition , RowSpan=@RowSpan , ColumnSpan=@ColumnSpan , ModifierID=@ModifierID , ModifiedDate=@ModifiedDate where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 64).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@MobileSourceFile", SqlDbType.NVarChar, 256).Value = mobileSourceFile
			myCommand.Parameters.Add("@DesktopSourceFile", SqlDbType.NVarChar, 256).Value = desktopSourceFile
			myCommand.Parameters.Add("@RowPosition", SqlDbType.Int, 4).Value = rowPosition
			myCommand.Parameters.Add("@ColumnPosition", SqlDbType.Int, 4).Value = columnPosition
			myCommand.Parameters.Add("@RowSpan", SqlDbType.Int, 4).Value = rowSpan
			myCommand.Parameters.Add("@ColumnSpan", SqlDbType.Int, 4).Value = columnSpan
			myCommand.Parameters.Add("@ModifierID", SqlDbType.NVarChar, 50).Value = modifierID
			myCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = modifiedDate
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function InsertEntity(ByVal parentID As String, ByVal typeID As Integer, ByVal title As String, ByVal description As String, ByVal mobileSourceFile As String, ByVal desktopSourceFile As String, ByVal rowPosition As Integer, ByVal columnPosition As Integer, ByVal rowSpan As Integer, ByVal columnSpan As Integer) As String
			Dim entityID As String
			Dim itemID As Integer = 0
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("insert into ControlDefinition ( EntityID,ItemID,ParentID,TypeID,Title,Description,MobileSourceFile,DesktopSourceFile,RowPosition,ColumnPosition,RowSpan,ColumnSpan ) values ( @EntityID,@ItemID,@ParentID,@TypeID,@Title,@Description,@MobileSourceFile,@DesktopSourceFile,@RowPosition,@ColumnPosition,@RowSpan,@ColumnSpan )", myConnection)
			Dim today As Date = Now
			entityID = today.Year() & Microsoft.VisualBasic.Right("00" & today.Month(), 2) & Microsoft.VisualBasic.Right("00" & today.Day(), 2) & Microsoft.VisualBasic.Right("00000000" & Hex(itemID), 8)
			entityID = GetMaxEntityID(entityID)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 16).Value = entityID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = CInt(Val("&H" & entityID.Substring(8, 8)))
			myCommand.Parameters.Add("@ParentID", SqlDbType.NVarChar, 16).Value = parentID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 64).Value = title
			myCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 256).Value = description
			myCommand.Parameters.Add("@MobileSourceFile", SqlDbType.NVarChar, 256).Value = mobileSourceFile
			myCommand.Parameters.Add("@DesktopSourceFile", SqlDbType.NVarChar, 256).Value = desktopSourceFile
			myCommand.Parameters.Add("@RowPosition", SqlDbType.Int, 4).Value = rowPosition
			myCommand.Parameters.Add("@ColumnPosition", SqlDbType.Int, 4).Value = columnPosition
			myCommand.Parameters.Add("@RowSpan", SqlDbType.Int, 4).Value = rowSpan
			myCommand.Parameters.Add("@ColumnSpan", SqlDbType.Int, 4).Value = columnSpan
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
			Return entityID
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("AuditSystemConnectionString"))
			Dim myCommand As New SqlCommand("select * from ControlDefinition order by ItemID", myConnection)
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
	End Class
End Namespace

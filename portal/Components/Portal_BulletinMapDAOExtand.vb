Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class Portal_BulletinMapDAOExtand
		Inherits Portal_BulletinMapDAO
		Enum BulletinType
			community = 1
			individual = 2
		End Enum
		Public Overloads Function GetTotalRowBySchoolIDAndTypeID(ByVal schoolID As String, ByVal typeID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_Bulletin.TypeID=@TypeID and Portal_Bulletin.EnableDate<=@Today and Portal_Bulletin.DisableDate>=@Today", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Today", SqlDbType.DateTime, 8).Value = Now
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
		Public Overloads Function GetEntitysBySchoolIDAndTypeID(ByVal schoolID As String, ByVal typeID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select top " & rowCount & " "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_Bulletin.TypeID=@TypeID and Portal_Bulletin.EnableDate<=@Today and Portal_Bulletin.DisableDate>=@Today order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			myCommand.Parameters.Add("@Today", SqlDbType.DateTime, 8).Value = Now
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetCommunityEntitys(ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select top " & rowCount & " "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_Bulletin.TypeID=@TypeID and Portal_BulletinMap.ModuleID<>@ModuleID and Portal_Bulletin.ModuleID<>@ModuleID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = BulletinType.community
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalCommunityRow(ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_Bulletin.TypeID=@TypeID and Portal_BulletinMap.ModuleID<>@ModuleID and Portal_Bulletin.ModuleID<>@ModuleID", myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = BulletinType.community
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
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
		Public Overloads Function GetCommunityEntitys(ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_Bulletin.TypeID=@TypeID and Portal_BulletinMap.ModuleID<>@ModuleID and Portal_Bulletin.ModuleID<>@ModuleID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = BulletinType.community
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByTypeID(ByVal schoolID As String, ByVal moduleID As Integer, ByVal typeID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID and Portal_Bulletin.TypeID=@TypeID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByTypeID(ByVal schoolID As String, ByVal moduleID As Integer, ByVal typeID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select top " & rowCount & " "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID and Portal_Bulletin.TypeID=@TypeID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = typeID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByModuleIDAndBulletinID(ByVal moduleID As Integer, ByVal bulletinID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_BulletinMap where ModuleID=@ModuleID and BulletinID=@BulletinID", myConnection)
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@BulletinID", SqlDbType.NVarChar, 29).Value = bulletinID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function

		Public Overloads Function GetTotalRowByGap(ByVal schoolID As String, ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID and Portal_Bulletin.EnableDate<=@Today and Portal_Bulletin.DisableDate>=@Today", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@Today", SqlDbType.DateTime, 8).Value = Now
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
		Public Overloads Function GetTotalRow(ByVal schoolID As String, ByVal moduleID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID", myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
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
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select "
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.TypeID as TypeID,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByGap(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select top " & rowCount
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.TypeID as TypeID,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID and Portal_Bulletin.EnableDate<=@Today and Portal_Bulletin.DisableDate>=@Today order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@Today", SqlDbType.DateTime, 8).Value = Now
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal schoolID As String, ByVal moduleID As Integer, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim mySQLString As String = "select top " & rowCount
			mySQLString = mySQLString + "Portal_BulletinMap.EntityID as EntityID,"
			mySQLString = mySQLString + "Portal_BulletinMap.SchoolID as SchoolID,"
			mySQLString = mySQLString + "Portal_BulletinMap.ModuleID as ModuleID,"
			mySQLString = mySQLString + "Portal_BulletinMap.DisplayOrder as DisplayOrder,"
			mySQLString = mySQLString + "Portal_BulletinMap.BulletinID as BulletinID,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedByUser,"
			mySQLString = mySQLString + "Portal_BulletinMap.CreatedDate,"
			mySQLString = mySQLString + "Portal_Bulletin.TypeID as TypeID,"
			mySQLString = mySQLString + "Portal_Bulletin.Title as Title,"
			mySQLString = mySQLString + "Portal_Bulletin.Description as Description,"
			mySQLString = mySQLString + "Portal_Bulletin.EnableDate as EnableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.DisableDate as DisableDate,"
			mySQLString = mySQLString + "Portal_Bulletin.AnnounceUnit as AnnounceUnit,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedByUser,"
			mySQLString = mySQLString + "Portal_Bulletin.CreatedDate, "
			mySQLString = mySQLString + "Portal_Bulletin.AffiliatedURL "
			mySQLString = mySQLString + "from Portal_BulletinMap inner join Portal_Bulletin on Portal_BulletinMap.BulletinID=Portal_Bulletin.EntityID where Portal_BulletinMap.SchoolID=@SchoolID and Portal_BulletinMap.ModuleID=@ModuleID order by Portal_BulletinMap.EntityID desc"
			Dim myCommand As New SqlCommand(mySQLString, myConnection)
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntity(ByVal entityID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_BulletinMap where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalRowByBulletinID(ByVal bulletinID As Integer) As Integer
			Dim valResult As Integer
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select count(*) from Portal_BulletinMap where BulletinID=@BulletinID", myConnection)
			myCommand.Parameters.Add("@BulletinID", SqlDbType.NVarChar, 29).Value = bulletinID
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
		Public Overloads Function GetEntityByBulletinID(ByVal bulletinID As String) As DataSet
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("select * from Portal_BulletinMap where BulletinID=@BulletinID", myConnection)
			myCommand.Parameters.Add("@BulletinID", SqlDbType.NVarChar, 29).Value = bulletinID
			Dim myAdapter As New SqlDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overridable Sub DeleteEntityByBulletinID(ByVal bulletinID As String)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("delete from Portal_BulletinMap where BulletinID=@BulletinID", myConnection)
			myCommand.Parameters.Add("@BulletinID", SqlDbType.NVarChar, 29).Value = bulletinID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub UpdateEntity(ByVal entityID As String, ByVal displayOrder As Integer)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("update Portal_BulletinMap set DisplayOrder=@DisplayOrder where EntityID=@EntityID", myConnection)
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Sub InsertEntity(ByVal entityID As String, ByVal schoolID As String, ByVal moduleID As Integer, ByVal itemID As Integer, ByVal bulletinID As String, ByVal displayOrder As Integer, ByVal createdByUser As String, ByVal createdDate As Date)
			Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
			Dim myCommand As New SqlCommand("insert into Portal_BulletinMap ( EntityID,SchoolID,ModuleID,ItemID,BulletinID,DisplayOrder,CreatedByUser,CreatedDate ) values ( @EntityID,@SchoolID,@ModuleID,@ItemID,@BulletinID,@DisplayOrder,@CreatedByUser,@CreatedDate )", myConnection)
			myCommand.Parameters.Add("@EntityID", SqlDbType.NVarChar, 29).Value = entityID
			myCommand.Parameters.Add("@SchoolID", SqlDbType.NVarChar, 5).Value = schoolID
			myCommand.Parameters.Add("@ModuleID", SqlDbType.Int, 4).Value = moduleID
			myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID
			myCommand.Parameters.Add("@BulletinID", SqlDbType.NVarChar, 29).Value = bulletinID
			myCommand.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4).Value = displayOrder
			myCommand.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 100).Value = createdByUser
			myCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = createdDate
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
	End Class
End Namespace

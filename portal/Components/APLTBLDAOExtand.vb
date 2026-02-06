Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal

Namespace ASPNET.StarterKit.Portal
	Public Class APLTBLDAOExtand
		Inherits APLTBLDAO
		Private APLTBL_TableID As String = "2005120100000001"
		Public Overloads Function GetTotalRowBySchoolCodeAndNet(ByVal eDGR As String, ByVal gRADU As String, ByVal schoolCode As String, ByVal net As String) As Integer
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetTotalRowBySchoolCodeAndNet(schoolCode, net)
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET", myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			Else
				If gRADU = "4" Then
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			End If
		End Function
		Public Overloads Function GetEntitysBySchoolCodeAndNetAndRowCount(ByVal schoolCode As String, ByVal net As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where SCHOOL_ID=:pSCHOOL_ID and NET=:pNET and rownum<=" & rowCount, myConnection)
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
			myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysBySchoolCodeAndNetAndRowCount(ByVal eDGR As String, ByVal gRADU As String, ByVal schoolCode As String, ByVal net As String, ByVal rowCount As Integer) As DataSet
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetEntitysBySchoolCodeAndNetAndRowCount(schoolCode, net, rowCount)
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			Else
				If gRADU = "4" Then
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and NET=:pNET and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			End If
		End Function
		Public Overloads Function GetTotalRowBySchoolCodeAndNet(ByVal schoolCode As String, ByVal net As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where SCHOOL_ID=:pSCHOOL_ID and NET=:pNET", myConnection)
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
			myCommand.Parameters.Add(":pNET", System.Data.OracleClient.OracleType.VarChar, 1).Value = net
			myConnection.Open()
			Dim myReader As System.Data.OracleClient.OracleDataReader
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
		Public Overloads Function GetTotalRow(ByVal schoolCode As String) As Integer
			Dim valResult As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where SCHOOL_ID=:pSCHOOL_ID", myConnection)
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
			myConnection.Open()
			Dim myReader As System.Data.OracleClient.OracleDataReader
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
		Public Overloads Sub InsertEntity(ByVal lABOR_ID As Integer, ByRef columnDataSet As DataSet)
			Dim myOracleTableColumnDAO As New Oracle_TableColumnDAOExtand
			Dim myOracleTableColumnDataSet As DataSet
			myOracleTableColumnDataSet = myOracleTableColumnDAO.GetEntitys(APLTBL_TableID)
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myLaborID As Integer
			Dim myColumnName As String = ""
			Dim myColumnAlias As String = ""
			Dim myColumnType As Integer = 0
			Dim myColumnData As String = ""
			Dim myColumnSize As Integer = 0
			Dim myOracleTableColumnID As String = ""
			Dim myTableColumnID As String = ""
			Dim myOracleColumnNameArray(myOracleTableColumnDataSet.Tables(0).Rows.Count - 1) As String
			Dim myOracleColumnAliasArray(myOracleTableColumnDataSet.Tables(0).Rows.Count - 1) As String
			'prepare column atring array
			For i = 0 To myOracleTableColumnDataSet.Tables(0).Rows.Count - 1
				myOracleColumnNameArray(i) = (CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("ColumnName"), String))
				myOracleColumnAliasArray(i) = (":p" & CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("ColumnName"), String))
			Next

			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			'prepare sql string
			Dim mySQLString As String = "insert into APLTBL ( "
			mySQLString = mySQLString & String.Join(",", myOracleColumnNameArray)
			mySQLString = mySQLString & " ) values ( "
			mySQLString = mySQLString & String.Join(",", myOracleColumnAliasArray)
			mySQLString = mySQLString & " )"
			Dim myCommand As New System.Data.OracleClient.OracleCommand(mySQLString, myConnection)
			'prepare parameters
			'pk
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 4).Value = lABOR_ID
			'
			For i = 1 To myOracleTableColumnDataSet.Tables(0).Rows.Count - 1
				myColumnName = CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("ColumnName"), String)
				myColumnAlias = ":p" & myColumnName
				myColumnType = CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("ColumnType"), Integer)
				myColumnSize = CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("ColumnSize"), Integer)
				myOracleTableColumnID = CType(myOracleTableColumnDataSet.Tables(0).Rows(i).Item("EntityID"), String)
				myColumnData = ""
				'search column data by column id
				For j = 0 To columnDataSet.Tables(0).Rows.Count - 1
					If myOracleTableColumnID = CType(columnDataSet.Tables(0).Rows(j).Item("TableColumnID"), String) Then
						myColumnData = CType(columnDataSet.Tables(0).Rows(j).Item("ColumnData"), String)
						Exit For
					End If
				Next
				If myColumnType = System.Data.OracleClient.OracleType.DateTime Then
					myCommand.Parameters.Add(myColumnAlias, myColumnType).Value = GetDate(myColumnData)
				Else
					If myColumnType = System.Data.OracleClient.OracleType.Number Then
						myCommand.Parameters.Add(myColumnAlias, myColumnType).Value = GetInteger(myColumnData)
					Else
						'default:varchar
						myCommand.Parameters.Add(myColumnAlias, System.Data.OracleClient.OracleType.VarChar, myColumnSize).Value = myColumnData
					End If
				End If
			Next
			myConnection.Open()
			myCommand.ExecuteNonQuery()
			myConnection.Close()
		End Sub
		Public Overloads Function GetEntitysByRowCount(ByVal schoolCode As String, ByVal rowCount As Integer) As DataSet
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where SCHOOL_ID=:pSCHOOL_ID and rownum<=" & rowCount, myConnection)
			myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByRowCount(ByVal rowCount As Integer) As DataSet
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL where rownum<=" & rowCount, myConnection)
			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitysByRowCount(ByVal eDGR As String, ByVal gRADU As String, ByVal schoolCode As String, ByVal rowCount As Integer) As DataSet
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetEntitysByRowCount(schoolCode, rowCount)
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			Else
				If gRADU = "4" Then
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and SCHOOL_ID=:pSCHOOL_ID and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			End If
		End Function
		Public Overloads Function GetEntitysByRowCount(ByVal eDGR As String, ByVal gRADU As String, ByVal rowCount As Integer) As DataSet
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetEntitysByRowCount(rowCount)
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			Else
				If gRADU = "4" Then
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and rownum<=" & rowCount, myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			End If
		End Function
		Public Overloads Function GetEntitys() As DataSet
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL", myConnection)
			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetTotalRow(ByVal eDGR As String, ByVal gRADU As String) As Integer
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetTotalRow()
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU", myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			Else
				If gRADU = "4" Then
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			End If
		End Function
		Public Overloads Function GetEntitys(ByVal eDGR As String, ByVal gRADU As String) As DataSet
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetEntitys()
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU", myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			Else
				If gRADU = "4" Then
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			End If
		End Function
		Public Overloads Function GetTotalRow(ByVal eDGR As String, ByVal gRADU As String, ByVal schoolCode As String) As Integer
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetTotalRow(schoolCode)
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			Else
				If gRADU = "4" Then
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				Else
					Dim valResult As Integer
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select count(*) from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					myConnection.Open()
					Dim myReader As System.Data.OracleClient.OracleDataReader
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
				End If
			End If
		End Function
		Public Overloads Function GetEntitys(ByVal eDGR As String, ByVal gRADU As String, ByVal schoolCode As String) As DataSet
			If eDGR = "9" Then
				If gRADU = "4" Then
					Return GetEntitys()
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			Else
				If gRADU = "4" Then
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				Else
					Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
					Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL inner join APSTBL on APLTBL.LABOR_ID=APSTBL.LABOR_ID inner join O_APSTBL on APLTBL.LABOR_ID=O_APSTBL.LABOR_ID where EDGR=:pEDGR and GRADU=:pGRADU and SCHOOL_ID=:pSCHOOL_ID", myConnection)
					myCommand.Parameters.Add(":pEDGR", System.Data.OracleClient.OracleType.VarChar, 1).Value = eDGR
					myCommand.Parameters.Add(":pGRADU", System.Data.OracleClient.OracleType.VarChar, 1).Value = gRADU
					myCommand.Parameters.Add(":pSCHOOL_ID", System.Data.OracleClient.OracleType.VarChar, 6).Value = schoolCode
					Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
					Dim myDataSet As New DataSet
					myAdapter.Fill(myDataSet)
					Return myDataSet
				End If
			End If
		End Function
		Public Overloads Function GetEntitys(ByVal lABOR_ID As Integer) As DataSet
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select * from APLTBL where LABOR_ID=:pLABOR_ID", myConnection)
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 4).Value = lABOR_ID
			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Overloads Function GetEntitys(ByVal lABOR_ID As Integer, ByRef columnDataSet As DataSet) As DataSet
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim myLaborID As Integer
			Dim myColumnName As String = ""
			Dim myColumnAlias As String = ""
			Dim myColumnType As Integer = 0
			Dim myColumnData As String = ""
			Dim myColumnSize As Integer = 0
			Dim myOracleTableColumnID As String = ""
			Dim myTableColumnID As String = ""
			Dim isSelect As Boolean = False
			Dim myOracleColumnNameArray(columnDataSet.Tables(0).Rows.Count - 1) As String
			'prepare column atring array
			For i = 0 To columnDataSet.Tables(0).Rows.Count - 1
				myOracleColumnNameArray(i) = (CType(columnDataSet.Tables(0).Rows(i).Item("ColumnName"), String))
			Next

			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			'prepare sql string
			Dim mySQLString As String = "select "
			mySQLString = mySQLString & String.Join(",", myOracleColumnNameArray)
			mySQLString = mySQLString & " from APLTBL where LABOR_ID=:pLABOR_ID"

			Dim myCommand As New System.Data.OracleClient.OracleCommand(mySQLString, myConnection)
			'prepare parameters
			'pk
			myCommand.Parameters.Add(":pLABOR_ID", System.Data.OracleClient.OracleType.Number, 4).Value = lABOR_ID

			Dim myAdapter As New System.Data.OracleClient.OracleDataAdapter(myCommand)
			Dim myDataSet As New DataSet
			myAdapter.Fill(myDataSet)
			Return myDataSet
		End Function
		Public Function GetMaxLaborID() As Integer
			Dim myConnection As New System.Data.OracleClient.OracleConnection(ConfigurationSettings.AppSettings("Oracle.ConnectionString"))
			Dim myCommand As New System.Data.OracleClient.OracleCommand("select max(Labor_ID) from APLTBL", myConnection)
			Dim maxID As Integer = 0
			myConnection.Open()
			Dim myReader As System.Data.OracleClient.OracleDataReader
			myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While myReader.Read()
				Try
					maxID = CInt(myReader.GetValue(0))
				Catch ex As System.InvalidCastException
					maxID = 0
				End Try
			End While
			myReader.Close()
			Return maxID
		End Function
		Private Function GetInteger(ByVal inStr As String) As Integer
			Dim result As Integer = 0
			If inStr.Trim <> "" Then
				result = CType(inStr, Integer)
			End If
			Return result
		End Function
		Private Function GetDate(ByVal inStr As String) As Date
			Dim dateDelimStr As String = "/: -"
			Dim dateDelimiter As Char() = dateDelimStr.ToCharArray()
			Dim dateTempArray As String() = Nothing
			Dim result As Date = New Date(1900, 1, 1)
			If inStr.Trim <> "" Then
				dateTempArray = inStr.Split(dateDelimiter)
				If dateTempArray.Length = 6 Then
					result = New Date(CType(dateTempArray(0), Integer), CType(dateTempArray(1), Integer), CType(dateTempArray(2), Integer), CType(dateTempArray(3), Integer), CType(dateTempArray(4), Integer), CType(dateTempArray(5), Integer))
				Else
					If dateTempArray.Length = 3 Then
						result = New Date(CType(dateTempArray(0), Integer), CType(dateTempArray(1), Integer), CType(dateTempArray(2), Integer))
					Else
						'exception: unknown date format
						Throw New Exception("Exception:Unknown datetime format:'" & inStr & "'")
					End If
				End If
			End If
			Return result
		End Function
	End Class
End Namespace
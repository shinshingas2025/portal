Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OracleClient
'modify 106.09.26

Public Class APPC02DAO

    Public Function GetEntity(ByVal ac02_year As Integer) As DataSet
        'Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        Dim strSQL As String = ""
        'strSQL = "select * from appc02 where ac02_year=" & ac02_year
        strSQL = "select * from HSIN.appc02 where ac02_year=:ac02_year"
        'strSQL = "select * from appc02 where ac02_year=@ac02_year"
        'Dim myCommand As New OdbcCommand(strSQL, myConnection)
        Dim myCommand As New OracleCommand(strSQL, myConnection)
        myCommand.Parameters.Add(":ac02_year", ac02_year)
        'Dim myAdapter As New OdbcDataAdapter(myCommand)
        Dim myAdapter As New OracleDataAdapter(myCommand)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet)

        Return myDataSet
    End Function



    Public Sub UpdateEntity(ByVal ac02_year As Integer, ByVal ac02_last_no As Integer)
        ' Dim myConnection As New OdbcConnection(ConfigurationSettings.AppSettings("InformixConnectionString"))
        Dim myConnection As New OracleConnection(ConfigurationSettings.AppSettings("OracleConnectionString"))
        'Dim myCommand As New OdbcCommand("update appc02 set ac02_last_no=" & ac02_last_no & " where ac02_year=" & ac02_year, myConnection)

        Dim myCommand As New OracleCommand("update HSIN.appc02 set ac02_last_no=" & ac02_last_no & " where ac02_year=" & ac02_year, myConnection)
        'myCommand.Parameters.Add("@ac02_year", SqlDbType.Int, 4).Value = ac02_year
        'myCommand.Parameters.Add("@ac02_last_no", SqlDbType.Int, 4).Value = ac02_last_no
        myConnection.Open()
        myCommand.ExecuteNonQuery()
        myConnection.Close()
    End Sub
End Class

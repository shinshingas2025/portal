Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports ASPNET.StarterKit.Portal


Namespace ASPNET.StarterKit.Portal
    Public Class Portal_iframe

        Public Function Getiframe(ByVal moduleid As Integer) As DataSet

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlDataAdapter("Portal_Getiframe", myConnection)

            ' Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parametermoduleid As New SqlParameter("@moduleid", SqlDbType.Int, 4)
            parametermoduleid.Value = moduleid
            myCommand.SelectCommand.Parameters.Add(parametermoduleid)

            ' Create and Fill the DataSet
            Dim myDataSet As New DataSet
            myCommand.Fill(myDataSet)

            ' Return the DataSet
            Return myDataSet

        End Function


        '*********************************************************************
        '
        ' UpdateEvent Method
        '
        ' The UpdateEvent method updates the specified event within
        ' the Events database table.
        '
        ' Other relevant sources:
        '     + <a href="UpdateEvent.htm" style="color:green">UpdateEvent Stored Procedure</a>
        '
        '*********************************************************************

        Public Sub Updateiframe(ByVal moduleid As Integer, ByVal url As String, ByVal framewidth As Integer, ByVal frameheight As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_Updateiframe", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC
            Dim parametermoduleid As New SqlParameter("@moduleid", SqlDbType.Int, 4)
            parametermoduleid.Value = moduleid
            myCommand.Parameters.Add(parametermoduleid)

            Dim parameterurl As New SqlParameter("@url", SqlDbType.NVarChar, 255)
            parameterurl.Value = url
            myCommand.Parameters.Add(parameterurl)

            Dim parameterframewidth As New SqlParameter("@framewidth", SqlDbType.Int, 4)
            parameterframewidth.Value = framewidth
            myCommand.Parameters.Add(parameterframewidth)

            Dim parameterframeheight As New SqlParameter("@frameheight", SqlDbType.Int, 4)
            parameterframeheight.Value = frameheight
            myCommand.Parameters.Add(parameterframeheight)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Sub


        Public Sub ADDiframe(ByVal sid As String, ByVal moduleID As Integer, ByVal url As String, ByVal framewidth As Integer, ByVal frameheight As Integer)

            ' Create Instance of Connection and Command Object
            Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
            Dim myCommand As New SqlCommand("Portal_ADDiframe", myConnection)

            ' Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure

            ' Add Parameters to SPROC

            Dim parametermoduleID As New SqlParameter("@moduleID", SqlDbType.Int, 4)
            parametermoduleID.Value = moduleID
            myCommand.Parameters.Add(parametermoduleID)

            Dim parametersid As New SqlParameter("@sid", SqlDbType.NVarChar, 5)
            parametersid.Value = sid
            myCommand.Parameters.Add(parametersid)

            Dim parameterurl As New SqlParameter("@url", SqlDbType.NVarChar, 255)
            parameterurl.Value = url
            myCommand.Parameters.Add(parameterurl)

            Dim parameterframewidth As New SqlParameter("@framewidth", SqlDbType.Int, 4)
            parameterframewidth.Value = framewidth
            myCommand.Parameters.Add(parameterframewidth)

            Dim parameterframeheight As New SqlParameter("@frameheight", SqlDbType.Int, 4)
            parameterframeheight.Value = frameheight
            myCommand.Parameters.Add(parameterframeheight)


            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myConnection.Close()


        End Sub
    End Class
End Namespace

Imports System.Data.SqlClient
Public Class NewApplyFormBO

    Public Function Update(ByVal entityID As String, ByVal status As String, ByVal operator As String) As Integer
        Dim strSQL As String

        strSQL = "UPDATE NewApplyForm set ProcessTime=getdate(), status='" & status & "' ,operator='" & operator & "'"

        strSQL &= " Where entityID ='" & entityID & "' "


        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0
    End Function




    Public Function QueryDate(ByVal status As String, ByVal AppSDATE As String, ByVal AppEDATE As String, ByVal ProSDATE As String, ByVal ProEDATE As String) As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select * from NewApplyForm where status='" & status & "'"
        If AppSDATE.Trim <> "" And AppEDATE.Trim <> "" Then
            strSQL &= " and  CreateTime Between '" & AppSDATE & "' and '" & AppEDATE & "'"
        End If
        If ProSDATE.Trim <> "" And ProEDATE.Trim <> "" Then
            strSQL &= " and(  ProcessTime Between '" & ProSDATE & "' and '" & ProEDATE & "')"
        End If

        strSQL &= " Order by EntityID DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function



    Public Function IndexQuery(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select TOP " & NO & " *,convert(char(10),creatdate,111) as cdate from hotnews where new_act = '1' "
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function QueryShow(Optional ByVal NO As String = "") As DataTable
        Dim strSQL As String = ""
        Dim dt As DataTable
        strSQL = "Select *,convert(char(10),creatdate,111) as cdate from hotnews where new_act = '1' "

        If NO <> "" Then
            strSQL &= " and newno='" & NO & "' "

        End If
        strSQL &= " Order by newno DESC "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()

        Return dt

    End Function

    Public Function Delete(ByVal NO As String) As Integer
        Dim strSQL As String = ""

        strSQL = "DELETE hotnews where newno = '" & NO & "'"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function


    Public Function Insert(ByVal Ne As Enhotnews) As Integer
        Dim strSQL As String = ""
        strSQL = "Insert into hotnews (new_subject,new_content,new_link,creater,sdate,edate,provider) values ("
        strSQL &= "'" & Ne.newsubject & "'"
        strSQL &= ",'" & Ne.newcontent & "'"
        strSQL &= ",'" & Ne.newlink & "'"
        strSQL &= ",'" & Ne.creater & "'"
        strSQL &= ",'" & Ne.SDATE & "'"
        strSQL &= ",'" & Ne.EDATE & "'"
        strSQL &= ",'" & Ne.Provider & "'"
        strSQL &= ")"

        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()

        Return 0

    End Function

    Public Function DeleteAll() As Integer
        Dim strSQL As String = ""
        strSQL = "DELETE hotnews where 1 = 1 "
        Dim conn As New DBConn2
        conn.ExecuteNonQuery(strSQL)
        conn.close()
        Return 0
    End Function

End Class

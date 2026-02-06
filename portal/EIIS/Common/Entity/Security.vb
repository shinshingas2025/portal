Public Class Security
    Public Function CheckAccount(ByVal objacc As Account) As Integer '
        Dim se As New SecurityBO
        Dim UID As Integer
        UID = se.CheckSecurity(objacc)



    End Function

    Public Function UpdateaAccount(ByVal at As Account) As Integer

        Dim se As New SecurityBO

        se.Update(at)



    End Function
    Public Function MapCommunity(ByVal at As Account) As Integer

        Dim se As New SecurityBO

        se.MapCommunity(at)



    End Function

    Public Function Query(Optional ByVal LoginID As String = "") As DataTable

        Dim se As New SecurityBO

        Return se.Query(LoginID)



    End Function
    Public Function QueryUID(Optional ByVal UID As String = "") As DataTable

        Dim se As New SecurityBO

        Return se.QueryUID(UID)



    End Function



    Public Function Delete(ByVal LoginID As String) As Integer

        Dim se As New SecurityBO

        se.Delete(LoginID)

        Return 0

    End Function

    Public Function Insert(ByVal at As Account) As Integer

        Dim se As New SecurityBO

        se.Insert(at)

        Return 0

    End Function


    Public Function ProcessingAuthorityData(ByVal LoginID As String) As Integer

        Dim se As New SecurityBO

        Return se.GetAuthorityByLoginID(LoginID)
    End Function

End Class

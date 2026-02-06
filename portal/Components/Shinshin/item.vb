Public Class item
    Dim _no As Integer
    Dim _parentno As Integer
    Dim _type As String
    Dim _name As String
    Dim _note1 As String
    Dim _note2 As String
    Dim _order As Integer
    Dim _act As Integer

    Public Property no() As Integer
        Get
            Return _no
        End Get
        Set(ByVal Value As Integer)
            _no = Value

        End Set
    End Property

    Public Property parentno() As Integer
        Get
            Return _parentno
        End Get
        Set(ByVal Value As Integer)
            _parentno = Value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property
    Public Property order() As Integer
        Get
            Return _order
        End Get
        Set(ByVal Value As Integer)
            _order = Value
        End Set
    End Property
    Public Property act() As Integer
        Get
            Return _act
        End Get
        Set(ByVal Value As Integer)
            _act = Value
        End Set
    End Property


    Public Function GetSelectStr(ByVal name As String, ByVal type As String) As DataTable
        Dim strSQL As String = ""
        Dim strMSG As String = ""
        Dim dt As DataTable
        Dim i As Integer

        strSQL = "Select * from item where it_type = '" & type & "' order by it_order "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        'strMSG = "<select name='" & name & "' > "
        'For i = 0 To dt.Rows.Count - 1
        'node.objID = CType(dt.Rows(i).Item("objID"), Integer)
        ' strMSG = strMSG & "<option value='" & CType(dt.Rows(i).Item("no"), Integer) & "'>" & CType(dt.Rows(i).Item("it_name"), String) & "</option>"
        ' Next

        Return dt
    End Function

    Public Function GetNameStr(ByVal per As String, ByVal type As String) As String
        Dim strSQL As String = ""
        Dim strMSG As String = ""
        Dim dt As DataTable
        Dim name_str As String

        strSQL = "Select * from item where it_act = '1' and it_type = '" & type & "' and no = '" & per & "' "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        name_str = CType(dt.Rows(0).Item("it_name"), String)

        Return name_str
    End Function

    Public Function GetNameStr2(ByVal per As String, ByVal type As String) As String
        Dim strSQL As String = ""
        Dim strMSG As String = ""
        Dim dt As DataTable
        Dim name_str As String

        strSQL = "Select * from item where  it_type = '" & type & "' and no = '" & per & "' "
        Dim conn As New DBConn2
        dt = conn.ReadDataTable(strSQL)
        conn.close()
        name_str = CType(dt.Rows(0).Item("it_name"), String)

        Return name_str
    End Function
End Class

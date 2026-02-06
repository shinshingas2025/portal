Public Class FunctionCollection

    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As Functions

        Get
            Return CType(List(index), Functions)
        End Get
        Set(ByVal Value As Functions)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal item As Functions) As Integer
        Return List.Add(item)
    End Function

    Public Function IndexOf(ByVal item As Functions) As Integer
        Return List.IndexOf(item)

    End Function
    Public Sub insert(ByVal index As Integer, ByVal item As Functions)
        list.Insert(index, item)

    End Sub
    Public Sub remove(ByVal item As Functions)
        list.Remove(item)
    End Sub
End Class



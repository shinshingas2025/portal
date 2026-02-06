Public Class OrgCollection
	Inherits CollectionBase
	Default Public Property Item(ByVal index As Integer) As OrgEntity

		Get
			Return CType(List(index), OrgEntity)
		End Get
		Set(ByVal Value As OrgEntity)
			List(index) = Value
		End Set
	End Property
	Public Function Add(ByVal item As OrgEntity) As Integer
		Return List.Add(item)
	End Function

	Public Function IndexOf(ByVal item As OrgEntity) As Integer
		Return List.IndexOf(item)

	End Function
	Public Sub insert(ByVal index As Integer, ByVal item As OrgEntity)
		list.Insert(index, item)

	End Sub
	Public Sub remove(ByVal item As OrgEntity)
		list.Remove(item)
	End Sub
End Class

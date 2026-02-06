Public Class DeptEntity

	Dim _DeptID As String
	Dim _DeptName As String
	Dim _Depttel As String
	Dim _Manager As String
	Dim _CreateTime As DateTime
	Dim _Creater As String

	Public Property DeptID() As String
		Get
			Return _DeptID
		End Get
		Set(ByVal Value As String)
			_DeptID = Value
		End Set
	End Property
	Public Property DeptName() As String
		Get
			Return _DeptName
		End Get
		Set(ByVal Value As String)
			Value = _DeptName
		End Set
	End Property
	Public Property Depttel() As String
		Get
			Return _Depttel
		End Get
		Set(ByVal Value As String)
			Value = _Depttel
		End Set
	End Property
	Public Property Manager() As String
		Get
			Return _Manager
		End Get
		Set(ByVal Value As String)
			Value = _Manager
		End Set
	End Property
	Public Property CreateTime() As DateTime
		Get
			Return _CreateTime
		End Get
		Set(ByVal Value As DateTime)
			Value = _CreateTime
		End Set
	End Property

	Public Property Creater() As String
		Get
			Return _Creater
		End Get
		Set(ByVal Value As String)
			Value = _Creater
		End Set
	End Property

End Class

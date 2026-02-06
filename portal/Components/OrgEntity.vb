Public Class OrgEntity
	'Inherits CommunityNode
	Private _objID As String = ""
	Private _PID As String = ""
	Private _SEQNO As String = ""
	Private _state As String = ""
	Private _objName As String = ""
	Private _objValue As String = ""
	Private _srcName As String = ""
	Public Property srcName() As String

		Get
			Return _srcName
		End Get
		Set(ByVal Value As String)
			_srcName = Value
		End Set

	End Property

	Public Property objID() As String
		Get
			Return _objID
		End Get
		Set(ByVal Value As String)
			_objID = Value
		End Set

	End Property

	Public Property PID() As String
		Get
			Return _PID
		End Get
		Set(ByVal Value As String)
			_PID = Value
		End Set
	End Property

	Public Property SEQNO() As String
		Get
			Return _SEQNO
		End Get
		Set(ByVal Value As String)
			_SEQNO = Value
		End Set
	End Property


	Public Property state() As String
		Get
			Return _state
		End Get
		Set(ByVal Value As String)
			_state = Value
		End Set
	End Property


	Public Property objName() As String
		Get
			Return _objName
		End Get
		Set(ByVal Value As String)
			_objName = Value
		End Set
	End Property


	Public Property objValue() As String
		Get
			Return _objValue
		End Get
		Set(ByVal Value As String)
			_objValue = Value
		End Set
	End Property

	Public Sub Clear()
		_objID = ""
		_PID = ""
		_SEQNO = ""
		_state = ""
		_objName = ""
		_objValue = ""
		_srcName = ""
	End Sub
End Class

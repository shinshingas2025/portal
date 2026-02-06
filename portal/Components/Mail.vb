Imports System.Configuration
Imports System.Web.Mail



Public Class Mail

	Private SmtpServer As String = ConfigurationSettings.AppSettings("SmtpServer")

	Dim _SendTo, _From, _Subject, _BodyFormat, _Body As String


	Public WriteOnly Property SendTo() As String
		Set(ByVal Value As String)
			_SendTo = Value
		End Set
	End Property

	Public WriteOnly Property Subject() As String
		Set(ByVal Value As String)
			_Subject = Value
		End Set
	End Property

	Public WriteOnly Property BodyFormat() As String
		Set(ByVal Value As String)
			_BodyFormat = Value
		End Set
	End Property

	Public WriteOnly Property Body() As String
		Set(ByVal Value As String)
			_Body = Value
		End Set
	End Property

	Public WriteOnly Property From() As String
		Set(ByVal Value As String)
			_From = Value
		End Set
	End Property

	Public Function SendMail() As Boolean
		Dim ML As New MailMessage
		ML.To = _SendTo
		ML.From = _From
		ML.Subject = _Subject
		ML.BodyFormat = MailFormat.Text
		ML.Body = _Body

		SmtpMail.SmtpServer = SmtpServer
		SmtpMail.Send(ML)

		Return True

	End Function

End Class

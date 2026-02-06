Imports System.Net
Imports System.Xml
Imports System.Data

Namespace ASPNET.StarterKit.Portal
	Public Class RSSList
		Inherits ASPNET.StarterKit.Portal.PortalModuleControl

		Protected Title As String = ""
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
		Protected Description As String = ""
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim rssData As DataSet = RefreshFeed()

			Dim channelItems As Object() = rssData.Tables(1).Rows(0).ItemArray
			Dim titleColumn As Integer = rssData.Tables(1).Columns("title").Ordinal
			Dim descriptionColumn As Integer = rssData.Tables(1).Columns("description").Ordinal

			Title = channelItems.GetValue(titleColumn).ToString()
			Description = channelItems.GetValue(descriptionColumn).ToString()

			Repeater1.DataSource = rssData.Tables(2)
			Repeater1.DataBind()
		End Sub

		Private Function RefreshFeed() As DataSet

			Dim rssFeed As HttpWebRequest = DirectCast(WebRequest.Create("http://msdn.microsoft.com/vbasic/rss.xml"), HttpWebRequest)

			Dim rssData As DataSet = New DataSet
			rssData.ReadXml(rssFeed.GetResponse().GetResponseStream())

			Return rssData
		End Function


		Private Sub InitializeComponent()

		End Sub
	End Class
End Namespace
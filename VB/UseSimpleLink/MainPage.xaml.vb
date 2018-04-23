Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Browser
Imports System.Windows.Controls
Imports System.Globalization
Imports DevExpress.Xpf.Printing
' ...

Namespace UseSimpleLink
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "#SimpleLink"
		Private data() As String

		Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Create an array of strings.
			data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

			' Create a link and specify a template and detail count for it.
			Dim link As New SimpleLink()
			link.Detail = CType(Resources("dayNameTemplate"), DataTemplate)
			link.DetailCount = data.Length

			' Bind the link to the PrintPreview instance.
			preview.Model = New LinkPreviewModel(link)

			' Enable exporting of a document.
			link.ExportServiceUri = "ExportService1.svc"

			' Create a document.
			AddHandler link.CreateDetail, AddressOf link_CreateDetail
			link.CreateDocument(True)

			' Set the MainPage's title.
			HtmlPage.Window.Eval(String.Format("document.title='Simple Link Demo'"))
		End Sub

		Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Data = data(e.DetailIndex)
		End Sub
		#End Region ' #SimpleLink

	End Class
End Namespace

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
        Private Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Create an array of strings.
            Dim data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

            ' Create a link and specify a template and detail count for it.
            Dim link As New SimpleLink()
            link.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate)
            link.DetailCount = data.Length
            ' Enable exporting of a document.
            link.ExportServiceUri = "../ExportService1.svc"

            ' Bind the link to the PrintPreview instance.
            preview.Model = New LinkPreviewModel(link)

            ' Create a document.
            AddHandler link.CreateDetail, Sub(s, eLink)
                                              eLink.Data = data(eLink.DetailIndex)
                                          End Sub
            link.CreateDocument(True)

            ' Set the MainPage's title.
            HtmlPage.Window.Eval("document.title='Simple Link Demo'")
        End Sub
		#End Region ' #SimpleLink
	End Class
End Namespace

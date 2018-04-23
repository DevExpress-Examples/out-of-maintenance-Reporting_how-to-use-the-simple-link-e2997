using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Globalization;
using DevExpress.Xpf.Printing;
// ...

namespace UseSimpleLink {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #SimpleLink
        void Page_Loaded(object sender, RoutedEventArgs e) {
            // Create an array of strings.
            string[] data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            // Create a link and specify a template and detail count for it.
            SimpleLink link = new SimpleLink();
            link.DetailTemplate = (DataTemplate)Resources["dayNameTemplate"];
            link.DetailCount = data.Length;
            
            // Enable exporting of a document.
            link.ExportServiceUri = "../ExportService1.svc";
            
            // Bind the link to the PrintPreview instance.
            preview.Model = new LinkPreviewModel(link);

            // Create a document.
            link.CreateDetail += (s, eLink) => eLink.Data = data[eLink.DetailIndex];
            link.CreateDocument(true);

            // Set the MainPage's title.
            HtmlPage.Window.Eval("document.title='Simple Link Demo'");
        }
        #endregion #SimpleLink
    }
}

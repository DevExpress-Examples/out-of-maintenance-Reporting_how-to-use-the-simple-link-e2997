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
        string[] data;

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            // Create an array of strings.
            data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            // Create a link and specify a template and detail count for it.
            SimpleLink link = new SimpleLink();
            link.DetailTemplate = (DataTemplate)Resources["dayNameTemplate"];
            link.DetailCount = data.Length;

            // Bind the link to the PrintPreview instance.
            preview.Model = new LinkPreviewModel(link);

            // Enable exporting of a document.
            link.ExportServiceUri = "..\\ExportService1.svc";

            // Create a document.
            link.CreateDetail += new EventHandler<CreateAreaEventArgs>(link_CreateDetail);
            link.CreateDocument(true);

            // Set the MainPage's title.
            HtmlPage.Window.Eval(string.Format("document.title='Simple Link Demo'"));
        }

        void link_CreateDetail(object sender, CreateAreaEventArgs e) {
            e.Data = data[e.DetailIndex];
        }
        #endregion #SimpleLink

    }
}

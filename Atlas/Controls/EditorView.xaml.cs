using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Atlas.UI;
using ICSharpCode.AvalonEdit;
using static System.Double;

namespace Atlas.Controls
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView
    {
        public EditorView()
        {
            InitializeComponent();

            TabControl.TabPanelDoubleClick += TabControl_TabPanelDoubleClick;
            TabControl.BeforeTabClosed += TabControl_BeforeTabClosed;
            AddNewTab(null, true);
        }

        private void TabControl_BeforeTabClosed(object sender, UI.Events.TabCloseEventArgs e)
        {

        }

        public void AddNewTab(string fileName, bool switchToNew)
        {
            var textEditorOptions = new TextEditorOptions
            {
                AllowScrollBelowDocument = true,
                ConvertTabsToSpaces = true,
                CutCopyWholeLine = true,
                EnableEmailHyperlinks = true,
                EnableHyperlinks = true
            };

            var textEditor = new TextEditor
            {
                Options = textEditorOptions,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Width = NaN,
                Height = NaN,
                Background = new SolidColorBrush(Color.FromRgb(30, 30, 30)),
                Foreground = new SolidColorBrush(Color.FromRgb(190, 190, 190)),
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                FontFamily = new FontFamily("Lucida Console"),
                FontSize = 12,
                ShowLineNumbers = true,
                Padding = new Thickness(3)
            };

            var atlasTabItem = new AtlasTabItem
            {
                Header = "new",
                Content = textEditor
            };
                
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    textEditor.Text = File.ReadAllText(fileName);
                    atlasTabItem.Header = Path.GetFileName(fileName);
                }
                catch
                {
                    textEditor.Text = string.Empty;
                }
            }


            TabControl.Items.Add(atlasTabItem);

            if (switchToNew)
            {
                atlasTabItem.IsSelected = true;
            }
        }


        private void TabControl_TabPanelDoubleClick(object sender, System.EventArgs e)
        {
            AddNewTab(null, true);
        }
    }
}

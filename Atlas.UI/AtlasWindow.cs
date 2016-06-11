using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Atlas.UI.Extensions;

namespace Atlas.UI
{
    public class AtlasWindow : Window
    {
        private Button CloseButton { get; set; }
        private Button MaximizeButton { get; set; }
        private Button MinimizeButton { get; set; }
        private Border CaptionBorder { get; set; }
        private Border MainBorder { get; set; }

        static AtlasWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtlasWindow), new FrameworkPropertyMetadata(typeof(AtlasWindow)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            CloseButton = GetTemplateChild("PART_Close") as Button;
            MaximizeButton = GetTemplateChild("PART_Maximize") as Button;
            MinimizeButton = GetTemplateChild("PART_Minimize") as Button;
            CaptionBorder = GetTemplateChild("PART_Caption") as Border;
            MainBorder = GetTemplateChild("PART_MainBorder") as Border;

            if (CloseButton != null)
                CloseButton.Click += CloseButton_Click;

            if (MaximizeButton != null)
                MaximizeButton.Click += MaximizeButton_Click;

            if (MinimizeButton != null)
                MinimizeButton.Click += MinimizeButton_Click;

            if (CaptionBorder != null)
            {
                CaptionBorder.MouseDown += Border_MouseDown;
                
            }
        }

        public void SetWindowBorderColor(Color color)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainBorder.BorderBrush = new SolidColorBrush(color);
            });
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Margin = new Thickness(0);
                WindowState = WindowState.Normal;
            }
            else
            {
                MainBorder.Margin = new Thickness(6);
                WindowState = WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

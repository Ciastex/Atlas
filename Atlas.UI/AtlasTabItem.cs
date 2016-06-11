using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Atlas.UI
{
    public class AtlasTabItem : TabItem
    {
        private Button CloseButton { get; set; }

        public event EventHandler BeforeClosed;

        static AtlasTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtlasTabItem), new FrameworkPropertyMetadata(typeof(AtlasTabItem)));
        }

        public AtlasTabItem()
        {
            MouseMove += AtlasTabItem_MouseMove;
            Drop += AtlasTabItem_Drop;
        }

        private void AtlasTabItem_Drop(object sender, DragEventArgs e)
        {
            var tabItemTarget = e.Source as AtlasTabItem;
            var tabItemSource = e.Data.GetData(typeof(AtlasTabItem)) as AtlasTabItem;

            if (tabItemTarget == null)
                return;

            if (!tabItemTarget.Equals(tabItemSource))
            {
                var tabControl = tabItemTarget.Parent as AtlasTabControl;

                if (tabControl == null)
                    return;

                var sourceIndex = tabControl.Items.IndexOf(tabItemSource);
                var targetIndex = tabControl.Items.IndexOf(tabItemTarget);

                tabControl.Items.Remove(tabItemSource);
                tabControl.Items.Insert(targetIndex, tabItemSource);

                tabControl.Items.Remove(tabItemTarget);
                tabControl.Items.Insert(sourceIndex, tabItemTarget);
            }
        }

        private void AtlasTabItem_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var tabItem = e.Source as AtlasTabItem;
            if (tabItem == null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CloseButton = GetTemplateChild("PART_CloseButton") as Button;

            if(CloseButton != null)
                CloseButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Close()
        {
            var tabControl = Parent as TabControl;
            tabControl?.Items.Remove(this);
        }
    }
}

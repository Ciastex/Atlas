using System.Windows;
using System.Windows.Controls;

namespace Atlas.UI
{
    public class AtlasTabControl : TabControl
    {
        static AtlasTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtlasTabControl), new FrameworkPropertyMetadata(typeof(AtlasTabControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


        }
    }
}

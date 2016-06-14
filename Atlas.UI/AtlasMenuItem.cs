using System.Windows;
using System.Windows.Controls;

namespace Atlas.UI
{
    public class AtlasMenuItem : MenuItem
    {
        static AtlasMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtlasMenuItem), new FrameworkPropertyMetadata(typeof(AtlasMenuItem)));
        }
    }
}

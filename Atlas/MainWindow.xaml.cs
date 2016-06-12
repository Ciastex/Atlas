using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Atlas.UI;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AtlasWindow
    {
        private Timer timer;
        private Random rand;

        public MainWindow()
        {
            InitializeComponent();

            timer = new Timer(50);
            timer.Elapsed += Timer_Elapsed;

            rand = new Random();

            // timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var col = new Color();
            col.A = 255;
            col.R = (byte)rand.Next(0, 255);
            col.G = (byte)rand.Next(0, 255);
            col.B = (byte)rand.Next(0, 255);

            SetWindowBorderColor(col);
        }
    }
}

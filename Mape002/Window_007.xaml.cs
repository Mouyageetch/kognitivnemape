using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mape002
{
    /// <summary>
    /// Interaction logic for Window_007.xaml
    /// </summary>
    public partial class Window_007 : Window
    {
        SoundPlayer soundPlayer;
        public Window_007()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.oduzimanje);
            soundPlayer.Play();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_006 window_006 = new Window_006();
            window_006.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_008 window_008 = new Window_008();
            window_008.Show();
            this.Close();

        }
    }
}

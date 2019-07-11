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
    /// Interaction logic for Window_006.xaml
    /// </summary>
    public partial class Window_006 : Window
    {
        SoundPlayer soundPlayer;
        public Window_006()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.sabiranje);
            soundPlayer.Play();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_005 window_005 = new Window_005();
            window_005.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_007 window_007 = new Window_007();
            window_007.Show();
            this.Close();

        }
    }
}

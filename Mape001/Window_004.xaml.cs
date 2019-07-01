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

namespace Mape001
{
    /// <summary>
    /// Interaction logic for Window_004.xaml
    /// </summary>
    public partial class Window_004 : Window
    {
        SoundPlayer soundPlayer;
        public Window_004()
        {
            InitializeComponent();
            
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003a window_003a = new Window_003a();
            window_003a.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_005 window_005 = new Window_005();
            window_005.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.nekaPovrsi);
            soundPlayer.Play();
        }

        private void DoubleAnimationUsingKeyFrames_Completed(object sender, EventArgs e)
        {
        }

        private void DoubleAnimationUsingKeyFrames_Completed_1(object sender, EventArgs e)
        {
        }
    }
}

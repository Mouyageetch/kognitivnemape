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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mape003
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer soundPlayer;
        public MainWindow()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC9EDF5"));
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF7F7F7"));
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            switch (textBlock.Name.ElementAt(2))
            {
                case '1':
                    Window_001 window_001 = new Window_001();
                    this.Close();
                    window_001.Show();
                    break;
                case '2':
                    Window_002 window_002 = new Window_002();
                    this.Close();
                    window_002.Show();
                    break;
                case '3':
                    Window_003 window_003 = new Window_003();
                    this.Close();
                    window_003.Show();
                    break;
                case '4':
                    Window_004 window_004 = new Window_004();
                    this.Close();
                    window_004.Show();
                    break;
                case '5':
                    Window_005 window_005 = new Window_005();
                    this.Close();
                    window_005.Show();
                    break;
                case '6':
                    Window_006 window_006 = new Window_006();
                    this.Close();
                    window_006.Show();
                    break;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bosanskaknjiga.ba");
        }
    }
}

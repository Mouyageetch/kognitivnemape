using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
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

namespace Mape002
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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bosanskaknjiga.ba");
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            switch (textBlock.Name.ElementAt(2))
            {
                case '1':
                    Window_001 window_001 = new Window_001();
                    window_001.Show();
                    this.Close();
                    break;
                case '2':
                    Window_002 window_002 = new Window_002();
                    window_002.Show();
                    this.Close();
                    break;
                case '3':
                    Window_006 window_006 = new Window_006();
                    window_006.Show();
                    this.Close();
                    break;
                case '4':
                    Window_007 window_007 = new Window_007();
                    window_007.Show();
                    this.Close();
                    break;
                case '5':
                    Window_009 window_009 = new Window_009();
                    window_009.Show();
                    this.Close();
                    break;
                case '6':
                    Window_010 window_010 = new Window_010();
                    window_010.Show();
                    this.Close();
                    break;
            }

        }
    }
}

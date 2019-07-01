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
    /// Interaction logic for Window_001.xaml
    /// </summary>
    public partial class Window_001 : Window
    {
        SoundPlayer soundPlayer;
        public Window_001()
        {
            InitializeComponent();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_002 window_002 = new Window_002();
            window_002.Show();
            this.Close();
        }

        private void Valjak_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //System.IO.Stream stream = Properties.Resources.ResourceManager.
            //soundPlayer = new SoundPlayer(@"/Mape001;component/Sounds/click.wav");
            //soundPlayer.Play();
            soundPlayer = new SoundPlayer(Properties.Resources.valjak);
            soundPlayer.Play();
            
        }

        private void Lopta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.lopta);
            soundPlayer.Play();
        }

        private void Kupa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            soundPlayer = new SoundPlayer(Properties.Resources.kupa);
            soundPlayer.Play();
        }

        private void Kocka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            soundPlayer = new SoundPlayer(Properties.Resources.kocka);
            soundPlayer.Play();
        }

        private void Kvadar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            soundPlayer = new SoundPlayer(Properties.Resources.kvadar);
            soundPlayer.Play();
        }

        private void Piramida_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            soundPlayer = new SoundPlayer(Properties.Resources.piramida);
            soundPlayer.Play();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            soundPlayer = new SoundPlayer(Properties.Resources.oveIgracke);
            soundPlayer.Play();
        }
    }
}

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
    /// Interaction logic for Window_008.xaml
    /// </summary>
    public partial class Window_008 : Window
    {
        ImageSourceConverter imageSourceConverter;
        List<string> possibleImages;
        SoundPlayer soundPlayer;
        string imagesFolder = "pack://application:,,,/Kognitivne mape;component/Images/Linija kao/test/";


        public Window_008()
        {
            InitializeComponent();

            possibleImages = new List<string>
            {
                "prave001","izlOtv001","izlOtv002","izlZatv001","izlZatv002","izlZatv003",
                "zakOtv001","zakOtv002","zakZatv001","zakZatv002"
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            KognitivneMapeUtils.SetRandomImage(possibleImages,randomImage,imagesFolder);
            soundPlayer = new SoundPlayer(Properties.Resources.povuciLiniju);
            soundPlayer.Play();
        }

        private void image_Drop(object sender, DragEventArgs e)
        {
            if(KognitivneMapeUtils.ImageDropCheck(sender,e))
            {

                KognitivneMapeUtils.SetRandomImage(possibleImages, randomImage, imagesFolder);

                if (randomImage.Source == null)
                {
                    success.Visibility = Visibility.Visible;
                    soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                    soundPlayer.Play();
                }

                hand.Visibility = Visibility.Hidden;
            }

            
        }


        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_007 window_007 = new Window_007();
            window_007.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RandomImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Image img = sender as Image;
            DragDrop.DoDragDrop(img, img.Source.ToString(), DragDropEffects.Move);
        }
    }
}

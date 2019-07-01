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
    /// Interaction logic for Window_011.xaml
    /// </summary>
    public partial class Window_011 : Window
    {
        // TODO Popraviti snimak (umjesto kvadrat ide kvadar)

        List<string> possibleImages;
        string folderPath = "pack://application:,,,/Kognitivne mape;component/Images/Granice/";
        SoundPlayer soundPlayer;

        public Window_011()
        {
            InitializeComponent();

            possibleImages = new List<string>
            {
                "bocnaStranaPiramide001","bocnaStranaPiramide002","bocnaStranaPiramide003",
                "ravnaPovrsValjka001","ravnaPovrsValjka002","ravnaPovrsValjka003",
                "stranaKocke001","stranaKocke002","stranaKocke003",
                "stranaKvadrata001","stranaKvadrata002","stranaKvadrata003"
            };

            KognitivneMapeUtils.SetRandomImage(possibleImages, randomImage, folderPath);
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_010 window_010 = new Window_010();
            window_010.Show();
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
            Image image = sender as Image;
            DragDrop.DoDragDrop(image, image.Source.ToString(), DragDropEffects.Move);
        }

        private void StranaKvadrata003_Drop(object sender, DragEventArgs e)
        {
            if(KognitivneMapeUtils.ImageDropCheck(sender, e))
            {
                KognitivneMapeUtils.SetRandomImage(possibleImages, randomImage, folderPath);

                if (randomImage.Source == null)
                {
                    success.Visibility = Visibility.Visible;
                    soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                    soundPlayer.Play();
                }

                hand.Visibility = Visibility.Hidden;
            }
        }
    }
}

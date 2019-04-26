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

// TODO Zenski glas
namespace Mape001
{
    class KognitivneMapeUtils
    {
        /// <summary>
        ///  Selects a random image from a list and assignsit as a source.
        /// </summary>
        /// <param name="possibleImages">A list of .png image filenames without the extensions.</param>
        /// <param name="sender">The image that will recieve the randomly chosen source.</param>
        /// <param name="folderPath">Path to the folder in which the images are located.</param>
        public static void SetRandomImage(List<string> possibleImages, Image sender, string folderPath)
        {
            if (possibleImages.Count > 0)
            {
                Random random = new Random();
                int randNum = random.Next(possibleImages.Count);

                string chosenImage = possibleImages.ElementAt(randNum);

                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

                try
                {
                    sender.Source = (ImageSource)imageSourceConverter.ConvertFromString(folderPath + chosenImage + ".png");

                }
                catch (Exception)
                {
                    Console.WriteLine("Random image source not valid.");
                }

                possibleImages.RemoveAt(randNum);
            }
            else
            {
                sender.Source = null;
            }

        }

        public static bool ImageDropCheck(object sender, DragEventArgs e)
        {
            string src;
            Image img;
            try
            {
                img = sender as Image;
            }
            catch (Exception)
            {
                Console.WriteLine("Dropped object is not an image.");
                return false;
            }

            try
            {
                src = (string)e.Data.GetData(typeof(string));
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get data");
                return false;
            }

            string fileName = System.IO.Path.GetFileName(src);

            if (fileName.StartsWith(img.Name.Remove(img.Name.Length - 3)))
            {
                ImageSourceConverter converter = new ImageSourceConverter();

                img.Source = (ImageSource)converter.ConvertFromString(src);
                StackPanel parent = (StackPanel)VisualTreeHelper.GetParent(img);
                parent.ClearValue(StackPanel.BackgroundProperty);

                img.AllowDrop = false;
                return true;

            }
            return false;

        }

    }
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
                    Window_004 window_004 = new Window_004();
                    window_004.Show();
                    this.Close();
                    break;
                case '3':
                    Window_006 window_006 = new Window_006();
                    window_006.Show();
                    this.Close();
                    break;
                case '4':
                    Window_009 window_009 = new Window_009();
                    window_009.Show();
                    this.Close();
                    break;
            }

        }
    }
}


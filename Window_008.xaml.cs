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

        public void setRandomImage()
        {
            if (possibleImages.Count > 0)
            {
                Random random = new Random();
                int randNum = random.Next(possibleImages.Count);

                string chosenImage = possibleImages.ElementAt(randNum);

                imageSourceConverter = new ImageSourceConverter();
                randomImage.Source = (ImageSource)imageSourceConverter.ConvertFromString("pack://application:,,,/Kognitivne mape;component/Images/Linija kao/test/" + chosenImage + ".png");

                possibleImages.RemoveAt(randNum);
            }
            else
            {
                randomImage.Source = null;
            }

        }

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
            setRandomImage();
            soundPlayer = new SoundPlayer(Properties.Resources.povuciLiniju);
            soundPlayer.Play();
        }

        private void image_Drop(object sender, DragEventArgs e)
        {

            /* VAŽNO:
             * Ova funkcija ce se nalaziti na SVAKOJ od ponudjenih mjesta (slika) na koje se dovlace slike 
             * na eventu Drop ! 
             */

            Image img = sender as Image;

            /* Preuzmemo naziv izvora slike koju smo dovukli (isto ime koje smo
             * u prethodnoj funkciji (MouseLeftButtonDown) poslali pomocu DoDragDrop:
             */
            string src = (string)e.Data.GetData(typeof(string));

            /* Iz punog naziva izvora (koji ce biti oblika "nazivPrograma;resources/Images/imeSlike.jpg")
             * izdvojimo samo ime slike (u varijabli fileName ce se nalaziti string oblika "imeSlike.jpg")
             */
            string fileName = System.IO.Path.GetFileName(src);


            /*  OBJASNJENJE UVJETA U IF-u:
             * Ako ime slike koju smo dovukli pocinje sa imenom slike na koju je ona dovucena
             * (tj. ako se imena podudaraju), onda cemo prihvatiti dovucenu sliku i staviti je 
             * na mjesto na koje je ispravno dovucena.
             * 
             * Varijabla img (koju smo preuzeli na pocetku ove funkcije) je slika na koju
             * je nesto dovuceno. 
             * img.Name je ime tog elementa u XAML kodu, ono ime koje se stavi na desnoj strani
             * u Blendu kada dodamo novi element (npr. kada napravimo TextBlock pa mu damo ime tb1)
             * 
             * Kako su imena slika u XAML-u NA KOJE SE DOVLACI oblika 
             * "lopta001", "lopta002", "valjak001", "valjak002",
             * izbrisat cemo zadnja tri elementa (brojeve 001, 002,...) i dobit cemo string
             * oblika "lopta", "valjak", itd.
             * 
             * Imena SLIKA koje BIVAJU DOVUCENE su "lopta1.jpg", "loptaPlava2.jpg", "kockaCrvena.jpg", itd.
             * Ocigledno je da sva ta imena pocinju sa "lopta" ili "kocka".
             * Ako se desi da ime slike pocinje sa img.Name (bez zadnja tri elementa, brojevi 001,002,itd.),
             * ispunit ce se uslov if-a.
             * Primjer, na Image imena "lopta001" dovucena je slika ciji je izvor "loptaCrvena.jpg".
             * "loptaCrvena.jpg" pocinje slovima "lopta".
             */

            if (fileName.StartsWith(img.Name.Remove(img.Name.Length - 3)))
            {
                /* ImageSourceConverter je klasa koja ce iz imena izvora slike
                 * dati ImageSource objekat koji cemo staviti kao novi izvor slike
                 * na koju je ona dovucena
                 */

                ImageSourceConverter converter = new ImageSourceConverter();

                // Stavimo novi izvor slike:
                img.Source = (ImageSource)converter.ConvertFromString(src);

                /* Kako se u mojoj (Mirza) verziji slike NA KOJE se dovlaci nalaze unutar
                 * sivog StackPanela, ovdje se ta siva boja izbrise kada se stavi nova slika:
                 */
                StackPanel parent = (StackPanel)VisualTreeHelper.GetParent(img);
                parent.ClearValue(StackPanel.BackgroundProperty);

                // Kada smo stavili novu sliku, na to mjesto se ne moze opet staviti nova slika:
                img.AllowDrop = false;

                setRandomImage();
                
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

            Window_009 window_009 = new Window_009();
            window_009.Show();
            this.Close();
        }

        private void RandomImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Image img = sender as Image;
            DragDrop.DoDragDrop(img, img.Source.ToString(), DragDropEffects.Move);
        }
    }
}

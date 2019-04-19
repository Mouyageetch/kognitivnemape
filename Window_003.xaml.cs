using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace Mape001
{
    /// <summary>
    /// Interaction logic for Window_003.xaml
    /// </summary>
    public partial class Window_003 : Window
    {
        /* U varijabli dragSource ce se nalaziti slika
         * koja biva povlacena na jedno od mogucih mjesta. 
         * To nam treba da je sakrijemo iz ponudjenih slika za povlacenje
         * ako je korisnik odvuce na ispravno mjesto.
         */

        Image dragSource = null;

        public Window_003()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /* VAŽNO:
             * Ova funkcija ce se nalaziti na SVAKOJ od ponudjenih slika za povlacenje 
             * na eventu MouseLeftButtonDown ! 
             */

            Image img = sender as Image;

            /* Kada se slika povuce, ovdje cemo je spremiti u varijablu dragSource
             * kako bi je zapamtili u slucaju da je budemo morali sakriti (ako se
             * odvuce na ispravno mjesto).
             */
            dragSource = img;

            /* Drugi ulazni parametar funkcije DoDragDrop odredjuje koji ce se podaci poslati
             * u funkciju Drop kada se desi DragDrop event. Ovdje smo poslali
             * naziv izvora slike koja je povucena ( img.Source.ToString() ).
             * To cemo upotrijebiti u funkciji Lopta001_Drop.
             */

            DragDrop.DoDragDrop(img, img.Source.ToString(), DragDropEffects.Move);

        }

        private void Lopta001_Drop(object sender, DragEventArgs e)
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

                // Sakrijemo sliku koju smo dovukli iz ponudjenih za dovlacenje
                dragSource.Visibility = Visibility.Hidden;

                /* U WrapPanelu koji se zove wrapPanel (veoma kreativno) se nalaze 
                 * slike koje su ponudjene sa povlacenje.
                 * Ako u wrapPanel-u nema niti jedna Visible (vidljiva) slika,
                 * to znaci da su sve odvucene na ispravna mjesta i zadatak je ispunjen.
                 */
                 
                bool visible = false;
                foreach (Image image in wrapPanel.Children)
                {
                    //Ako postoji barem jedna vidljiva slika, stavi varijablu "visible" na true:
                    if (image.Visibility == Visibility.Visible)
                        visible = true;
                }

                /* Ako su sve slike nevidljive, prikazi veliki TextBlock imena "success" na kojem pise
                 * "ISPRAVAN ODGOVOR" :
                 */
                if (!visible)
                    success.Visibility = Visibility.Visible;

                hand.Visibility = Visibility.Hidden;
            }
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003a window_003a = new Window_003a();
            window_003a.Show();
            this.Close();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_002 window_002 = new Window_002();
            window_002.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}

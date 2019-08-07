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

namespace Mape003
{
    /// <summary>
    /// Interaction logic for Window_001b.xaml
    /// </summary>
    public partial class Window_001b : Window
    {
        List<TextBlock> zadani, rjesenja;
        List<Tuple<int, int>> sabirnici;
        Random r;
        TextBlock prviOdabrani;
        int brojRijesenih;
        SoundPlayer soundPlayer;
        List<Path> paths;
        public Window_001b()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.successUke);
            prviOdabrani = null;
            namjestiZadatke();
            brojRijesenih = 0;
            paths = new List<Path>();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_001a window_001A = new Window_001a();
            window_001A.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void namjestiZadatke()
        {
            /*    DoubleAnimation fadeIn = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromSeconds(2)) };
                DoubleAnimation fadeOut = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromSeconds(2)) };
                fadeIn.From = 0;
                fadeIn.To = 1;

                fadeOut.From = 1;
                fadeOut.To = 0;
                */
            sabirnici = new List<Tuple<int, int>>();
            zadani = new List<TextBlock> { tb00, tb01, tb02, tb03, tb04 };
            rjesenja = new List<TextBlock> { tb10, tb11, tb12, tb13, tb14 };

            List<TextBlock> sviTb = new List<TextBlock>();
            sviTb.AddRange(zadani);
            sviTb.AddRange(rjesenja);

            foreach (var item in sviTb)
            {
                item.Background = Brushes.LightSkyBlue;

            }


            r = new Random();

            prviOdabrani = null;

            for (int i = 0; i < zadani.Count; i++)
            {
                int dvocifreni;
                int jednocifreni;

                do
                {
                    dvocifreni = r.Next(11, 19);
                    jednocifreni = r.Next(1, 9);
                }
                while (jednocifreni + dvocifreni > 20 || sabirnici.IndexOf(new Tuple<int, int>(dvocifreni, jednocifreni)) != -1);

                sabirnici.Add(new Tuple<int, int>(dvocifreni, jednocifreni));

                zadani.ElementAt(i).Text = dvocifreni + " + " + jednocifreni + " =";

                int randomRjesenje = r.Next(rjesenja.Count - 1);
                rjesenja.ElementAt(randomRjesenje).Text = (dvocifreni + jednocifreni).ToString();
                rjesenja.RemoveAt(randomRjesenje);


            }
            zadani = new List<TextBlock> { tb00, tb01, tb02, tb03, tb04 };
            rjesenja = new List<TextBlock> { tb10, tb11, tb12, tb13, tb14 };


        }

        private void Tb00_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            prviOdabrani = sender as TextBlock;

            // Onemoguci ostale blokove dok se ne rijesi prvi
            foreach (var block in zadani)
            {
                if (block != prviOdabrani)
                {
                    block.IsEnabled = false;
                    block.Background = Brushes.LightGray;
                }
            }
        }

        private void Tb10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (prviOdabrani != null)
            {
                var drugiOdabrani = sender as TextBlock;

                int rezultat = int.Parse(prviOdabrani.Text.Substring(0, 2)) + int.Parse(prviOdabrani.Text.Substring(5, 1));

                if (rezultat == int.Parse(drugiOdabrani.Text))
                {
                    prviOdabrani.Background = Brushes.LightGreen;
                    drugiOdabrani.Background = Brushes.LightGreen;
                    nacrtajLiniju(prviOdabrani, drugiOdabrani);
                    zadani.Remove(prviOdabrani);
                    rjesenja.Remove(drugiOdabrani);

                    prviOdabrani.IsEnabled = false;
                    drugiOdabrani.IsEnabled = false;

                    foreach (var block in zadani)
                    {
                        if (block != prviOdabrani)
                        {
                            block.IsEnabled = true;
                            block.Background = Brushes.LightSkyBlue;
                        }
                    }
                    foreach (var block in rjesenja)
                    {
                        if (block != drugiOdabrani)
                        {
                            block.IsEnabled = true;
                            block.Background = Brushes.LightSkyBlue;
                        }
                    }

                    brojRijesenih++;
                    if (brojRijesenih == 5)
                    {
                        foreach (var item in paths)
                        {
                            item.Opacity = 0;
                        }
                        success.Visibility = Visibility.Visible;
                        soundPlayer.Play();


                    }

                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            namjestiZadatke();
        }

        private void nacrtajLiniju(TextBlock tb1, TextBlock tb2)
        {
            var myPath = new Path();

            //myPath.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFBCE5F1"));
            myPath.Stroke = Brushes.LightGreen;
            myPath.StrokeThickness = 3;

            LineGeometry linija = new LineGeometry();
            /*linija.StartPoint = tb1.TransformToAncestor(mainGrid).Transform(new Point(0, 0));
            linija.EndPoint = tb2.TransformToAncestor(mainGrid).Transform(new Point(50,0));*/

            linija.StartPoint = new Point(tb1.Margin.Left + tb1.Width, tb1.Margin.Top + 15);
            linija.EndPoint = new Point(tb2.Margin.Left, tb2.Margin.Top + 15);


            myPath.Data = linija;

            mainGrid.Children.Add(myPath);

            //MessageBox.Show(linija.StartPoint.ToString() + "   " + linija.EndPoint.ToString());
            paths.Add(myPath);

        }
    }
}

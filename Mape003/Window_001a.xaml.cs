using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mape003
{
    /// <summary>
    /// Interaction logic for Window_001a.xaml
    /// </summary>
    public partial class Window_001a : Window
    {
        List<Tuple<int, int>> sabirnici;
        List<TextBlock> zadani, raspisani, krajnji;
        List<Path> paths;
        Random r;
        SoundPlayer soundPlayer;

        TextBlock prviOdabrani, drugiOdabrani, treciOdabrani;
        int brojRijesenih;
        public Window_001a()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.successUke);
            paths = new List<Path>();
            namjestiZadatke();
            brojRijesenih = 0;

        }

        private void namjestiZadatke()
        {
            DoubleAnimation fadeIn = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromSeconds(2)) };
            DoubleAnimation fadeOut = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromSeconds(2)) };
            fadeIn.From = 0;
            fadeIn.To = 1;

            fadeOut.From = 1;
            fadeOut.To = 0;

            sabirnici = new List<Tuple<int, int>>();
            zadani = new List<TextBlock> { tb00, tb01, tb02, tb03 };
            raspisani = new List<TextBlock> { tb10, tb11, tb12, tb13 };
            krajnji = new List<TextBlock> { tb20, tb21, tb22, tb23 };

            List<TextBlock> sviTb = new List<TextBlock>();
            sviTb.AddRange(zadani);
            sviTb.AddRange(raspisani);
            sviTb.AddRange(krajnji);



            if (brojRijesenih < 4)
            {
                foreach (var item in sviTb)
                {
                    item.Opacity = 0;
                }
            }
            else
            {
                foreach (var item in sviTb)
                {
                    item.BeginAnimation(TextBlock.OpacityProperty, fadeOut);
                }

                foreach (var item in paths)
                {
                    item.BeginAnimation(Path.OpacityProperty, fadeOut);
                }
            }

            r = new Random();

            prviOdabrani = null;
            drugiOdabrani = null;
            treciOdabrani = null;

            for (int i = 0; i < zadani.Count; i++)
            {
                int dvocifreni;
                int jednocifreni;

                do
                {
                    dvocifreni = r.Next(11, 18);
                    jednocifreni = r.Next(1, 9);
                }
                while (jednocifreni + dvocifreni > 19 || sabirnici.IndexOf(new Tuple<int, int>(dvocifreni, jednocifreni)) != -1);

                sabirnici.Add(new Tuple<int, int>(dvocifreni, jednocifreni));

                zadani.ElementAt(i).Text = dvocifreni + " + " + jednocifreni + " =";

                int randomRaspisani = r.Next(raspisani.Count - 1);
                raspisani.ElementAt(randomRaspisani).Text = "10 + " + (dvocifreni % 10) + " + " + jednocifreni + " =";

                int randomKrajnji = r.Next(krajnji.Count - 1);
                krajnji.ElementAt(randomKrajnji).Text = "10 + " + ((dvocifreni % 10) + jednocifreni) + " = " + ((10 + (dvocifreni % 10)) + jednocifreni);

                //nacrtajLiniju(raspisani.ElementAt(randomRaspisani), krajnji.ElementAt(randomKrajnji));

                raspisani.RemoveAt(randomRaspisani);
                krajnji.RemoveAt(randomKrajnji);
            }

            zadani = new List<TextBlock> { tb00, tb01, tb02, tb03 };
            raspisani = new List<TextBlock> { tb10, tb11, tb12, tb13 };
            krajnji = new List<TextBlock> { tb20, tb21, tb22, tb23 };

            foreach (var item in sviTb)
            {
                item.Background = Brushes.LightSkyBlue;
                item.IsEnabled = true;
            }

            foreach (var item in sviTb)
            {
                item.BeginAnimation(TextBlock.OpacityProperty, fadeIn);
            }

        }

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F5)
            {
                namjestiZadatke();
            }
        }

        private void Tb10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (prviOdabrani != null)
            {
                drugiOdabrani = sender as TextBlock;
                int rezultatPrvog = int.Parse(prviOdabrani.Text.Substring(0, 2)) + int.Parse(prviOdabrani.Text.Substring(5, 1));
                int rezultatDrugog = 10 + int.Parse(drugiOdabrani.Text.Substring(5, 1)) + int.Parse(drugiOdabrani.Text.Substring(9, 1));

                int prviDvocifreniMOD = int.Parse(prviOdabrani.Text.Substring(0, 2)) % 10;
                int prviJednocifreni = int.Parse(prviOdabrani.Text.Substring(5, 1));

                int drugiMOD = int.Parse(drugiOdabrani.Text.Substring(5, 1));
                int drugiJednocifreni = int.Parse(drugiOdabrani.Text.Substring(9, 1));

                if (prviDvocifreniMOD == drugiMOD && prviJednocifreni == drugiJednocifreni)
                {
                    //Onemoguci ostale

                    foreach (var blok in raspisani)
                    {
                        if (blok != drugiOdabrani)
                        {
                            blok.IsEnabled = false;
                            blok.Background = Brushes.LightGray;
                        }
                    }
                    nacrtajLiniju(prviOdabrani, drugiOdabrani);
                    prviOdabrani.Background = Brushes.LightGreen;
                    drugiOdabrani.Background = Brushes.LightGreen;
                }
                else
                {
                    drugiOdabrani = null;
                }
            }
        }

        private void Tb20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (prviOdabrani != null && drugiOdabrani != null)
            {
                treciOdabrani = sender as TextBlock;

                int drugiMOD = int.Parse(drugiOdabrani.Text.Substring(5, 1));
                int drugiJednocifreni = int.Parse(drugiOdabrani.Text.Substring(9, 1));

                int zbir = drugiMOD + drugiJednocifreni;

                int treciJednocifreni = int.Parse(treciOdabrani.Text.Substring(5, 1));

                if (zbir == treciJednocifreni)
                {
                    nacrtajLiniju(drugiOdabrani, treciOdabrani);

                    foreach (var blok in zadani)
                    {
                        if (blok != prviOdabrani)
                        {
                            blok.IsEnabled = true;
                            blok.Background = treciOdabrani.Background;
                        }
                    }

                    foreach (var blok in raspisani)
                    {
                        if (blok != drugiOdabrani)
                        {
                            blok.IsEnabled = true;
                            blok.Background = treciOdabrani.Background;
                        }
                    }

                    treciOdabrani.Background = Brushes.LightGreen;


                    prviOdabrani.IsEnabled = false;
                    drugiOdabrani.IsEnabled = false;
                    treciOdabrani.IsEnabled = false;

                    zadani.Remove(prviOdabrani);
                    raspisani.Remove(drugiOdabrani);

                    brojRijesenih++;

                    if (brojRijesenih == 4)
                    {
                        namjestiZadatke();
                    }

                    if (brojRijesenih == 8)
                    {
                        success.Visibility = Visibility.Visible;
                        soundPlayer.Play();

                        foreach (var item in paths)
                        {
                            item.Opacity = 0;
                        }
                    }

                    prviOdabrani = null;
                    drugiOdabrani = null;
                    treciOdabrani = null;


                }


            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                Window_001a window_001A = new Window_001a();
                this.Close();
                window_001A.Show();
            }

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
            paths.Add(myPath);

            //MessageBox.Show(linija.StartPoint.ToString() + "   " + linija.EndPoint.ToString());

        }

        private void Tb00_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            prviOdabrani = sender as TextBlock;
            prviOdabrani.Background = Brushes.Gold;

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

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_001 window_001 = new Window_001();
            window_001.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_001b window_001B = new Window_001b();
            window_001B.Show();
            this.Close();
        }
    }
}

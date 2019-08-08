using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mape002
{
    /// <summary>
    /// Interaction logic for Window_012.xaml
    /// </summary>
    public partial class Window_012 : Window
    {
        List<TextBlock> citamo, pisemo;
        TextBlock prviOdabrani, drugiOdabrani;
        Dictionary<string, int> pisemoCitamoDict;
        List<Path> paths;
        int brojRijesenih;
        SoundPlayer soundPlayer;
        public Window_012()
        {
            InitializeComponent();

            brojRijesenih = 0;
            soundPlayer = new SoundPlayer(Properties.Resources.successUke);
            soundPlayer.Stop();

            citamo = new List<TextBlock> { tb00, tb01, tb02, tb03, tb04, tb05, tb06 };
            pisemo = new List<TextBlock> { tb10, tb11, tb12, tb13, tb14, tb15, tb16 };
            paths = new List<Path>();
            prviOdabrani = drugiOdabrani = null;
            pisemoCitamoDict = napraviBrojeve(7);
            popuniTextBlockove(pisemoCitamoDict, citamo, pisemo);
        }

        private Dictionary<string,int> napraviBrojeve(int kolicina)
        {
            Random r = new Random();
            Dictionary<string, int> parovi = new Dictionary<string, int>();

            for (int i = 0; i < kolicina; i++)
            {
                int broj;
                do
                {
                     broj = r.Next(20, 100);
                }
                while (parovi.ContainsValue(broj));
                string napisano = (broj / 10) + "D i " + (broj % 10) + "J";
                parovi.Add(napisano, broj);
            }

            return parovi;
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_011 window_011 = new Window_011();
            window_011.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_013 window_013 = new Window_013();
            window_013.Show();
            this.Close();

        }

        private void Tb00_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            prviOdabrani = sender as TextBlock;
            if(drugiOdabrani == null)
            {
                foreach (var item in citamo)
                {
                    if(item != prviOdabrani)
                    {
                        item.Background = Brushes.LightGray;
                        item.IsEnabled = false;
                    }
                }
            }
            else
            {
                var _citamo = (from par in pisemoCitamoDict where par.Value == int.Parse(drugiOdabrani.Text) select par).First().Key;

                if(_citamo == prviOdabrani.Text)
                {
                    brojRijesenih++;
                    prviOdabrani.Background = drugiOdabrani.Background = Brushes.LightGreen;
                    nacrtajLiniju(prviOdabrani, drugiOdabrani);
                    prviOdabrani.IsEnabled = drugiOdabrani.IsEnabled = false;
                    pisemo.Remove(drugiOdabrani);
                    citamo.Remove(prviOdabrani);
                    prviOdabrani = drugiOdabrani = null;

                    foreach (var item in pisemo)
                    {
                        item.Background = Brushes.LightSkyBlue;
                        item.IsEnabled = true;
                    }

                    if(brojRijesenih == 7)
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

        private void Tb10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drugiOdabrani = sender as TextBlock;
            if(prviOdabrani == null)
            {
                foreach (var item in pisemo)
                {
                    if(item != drugiOdabrani)
                    {
                        item.Background = Brushes.LightGray;
                        item.IsEnabled = false;
                    }
                }
            }
            else
            {
                var _pisemo = (from par in pisemoCitamoDict where par.Key == prviOdabrani.Text select par).First().Value;

                if(_pisemo == int.Parse(drugiOdabrani.Text))
                {
                    brojRijesenih++;
                    prviOdabrani.Background = drugiOdabrani.Background = Brushes.LightGreen;
                    nacrtajLiniju(prviOdabrani, drugiOdabrani);
                    prviOdabrani.IsEnabled = drugiOdabrani.IsEnabled = false;
                    pisemo.Remove(drugiOdabrani);
                    citamo.Remove(prviOdabrani);
                    prviOdabrani = drugiOdabrani = null;

                    foreach (var item in citamo)
                    {
                        item.Background = Brushes.LightSkyBlue;
                        item.IsEnabled = true;
                    }
                    if(brojRijesenih == 7)
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

        private void popuniTextBlockove(Dictionary<string,int> parovi, List<TextBlock> citamo, List<TextBlock> pisemo)
        {
            Random r = new Random();
            var _pisemo = new List<TextBlock>(pisemo);

            for (int i = 0; i < parovi.Count; i++)
            {
                citamo.ElementAt(i).Text = parovi.ElementAt(i).Key;


                int random = r.Next(_pisemo.Count - 1);
                _pisemo.ElementAt(random).Text = parovi.ElementAt(i).Value.ToString();
                _pisemo.RemoveAt(random);
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
    }
}

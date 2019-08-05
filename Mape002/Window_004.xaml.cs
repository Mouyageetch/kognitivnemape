using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
    /// Interaction logic for Window_004.xaml
    /// </summary>
    public partial class Window_004 : Window
    {
        List<Tuple<string, string, string>> brojevi;
        List<TextBlock> textBlocks;
        Random random;
        List<int> iskoristeniRandom;
        int rijesenih;
        SoundPlayer soundPlayer;

        public Window_004()
        {
            InitializeComponent();


            b1.Background = Brushes.Transparent;
            b2.Background = Brushes.Transparent;
            b3.Background = Brushes.Transparent;
            b4.Background = Brushes.Transparent;
            b5.Background = Brushes.Transparent;
            b6.Background = Brushes.Transparent;
            b7.Background = Brushes.Transparent;
            b8.Background = Brushes.Transparent;
            b9.Background = Brushes.Transparent;
            b10.Background = Brushes.Transparent;


            soundPlayer = new SoundPlayer(Properties.Resources.pridruziZadate);
            soundPlayer.Play();
            rijesenih = 0;
            iskoristeniRandom = new List<int>();
            random = new Random();
            textBlocks = new List<TextBlock> { tb1, tb2, tb3, tb4, tb5, tb6 };
            var atbs = new List<TextBlock> { aTb1, aTb2, aTb3, aTb4, aTb5, aTb6, aTb7, aTb8, aTb9, aTb10 };

            brojevi = new List<Tuple<string, string, string>> {
                new Tuple<string, string, string>("10", "1D", "DESET"),
                new Tuple<string, string, string>("20", "2D", "DVADESET"),
                new Tuple<string, string, string>("30", "3D", "TRIDESET"),
                new Tuple<string, string, string>("40", "4D", "ČETRDESET"),
                new Tuple<string, string, string>("50", "5D", "PEDESET"),
                new Tuple<string, string, string>("60", "6D", "ŠEZDESET"),
                new Tuple<string, string, string>("70", "7D", "SEDAMDESET"),
                new Tuple<string, string, string>("80", "8D", "OSAMDESET"),
                new Tuple<string, string, string>("90", "9D", "DEVEDESET"),
                new Tuple<string, string, string>("100", "10D", "STO") };

            var ostaliBrojevi = new List<Tuple<string, string, string>> {
                new Tuple<string, string, string>("10", "1D", "DESET"),
                new Tuple<string, string, string>("20", "2D", "DVADESET"),
                new Tuple<string, string, string>("30", "3D", "TRIDESET"),
                new Tuple<string, string, string>("40", "4D", "ČETRDESET"),
                new Tuple<string, string, string>("50", "5D", "PEDESET"),
                new Tuple<string, string, string>("60", "6D", "ŠEZDESET"),
                new Tuple<string, string, string>("70", "7D", "SEDAMDESET"),
                new Tuple<string, string, string>("80", "8D", "OSAMDESET"),
                new Tuple<string, string, string>("90", "9D", "DEVEDESET"),
                new Tuple<string, string, string>("100", "10D", "STO") };

            for (int i = 0; i < 6; i++)
            {
                int r = random.Next(0, 9);

                while (iskoristeniRandom.IndexOf(r) != -1)
                {
                    r = random.Next(0, 9);
                }
                iskoristeniRandom.Add(r);

                if (random.Next() % 2 == 0)
                {
                    textBlocks.ElementAt(i).Text = brojevi.ElementAt(r).Item1;
                }
                else
                {
                    textBlocks.ElementAt(i).Text = brojevi.ElementAt(r).Item2;
                }

                ostaliBrojevi.Remove(brojevi.ElementAt(r));
            }


            foreach (var item in ostaliBrojevi)
            {
                switch(item.Item1)
                {
                    case "10":
                        aTb1.Text = "10";
                        break;
                    case "20":
                        aTb2.Text = "20";
                        break;
                    case "30":
                        aTb3.Text = "30";
                        break;
                    case "40":
                        aTb4.Text = "40";
                        break;
                    case "50":
                        aTb5.Text = "50";
                        break;
                    case "60":
                        aTb6.Text = "60";
                        break;
                    case "70":
                        aTb7.Text = "70";
                        break;
                    case "80":
                        aTb8.Text = "80";
                        break;
                    case "90":
                        aTb9.Text = "90";
                        break;
                    case "100":
                        aTb10.Text = "100";
                        break;
                }

            }
        }


        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003 window_003 = new Window_003();
            window_003.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_005 window_005 = new Window_005();
            window_005.Show();
            this.Close();

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            var tb = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(border, 0), 1) as TextBlock;
            DragDrop.DoDragDrop(border, tb, DragDropEffects.Move);

            hand.Opacity = 0.00;
            Grid.SetZIndex(hand, -5);

        }

        private void Border_Drop(object sender, DragEventArgs e)
        {
            Border border = sender as Border;
            TextBlock reciever = VisualTreeHelper.GetChild(border, 0) as TextBlock;
            TextBlock dragged = (TextBlock)e.Data.GetData(typeof(TextBlock));

            int draggedNumber;
            try
            {
                draggedNumber = int.Parse(dragged.Text);
            }
            catch (Exception)
            {
                draggedNumber = int.Parse(Regex.Replace(dragged.Text, "D", "0"));
            }

            int recieverNumber = int.Parse(Regex.Replace(reciever.Name, "[^0-9]", "") + "0");


            if (draggedNumber == recieverNumber)
            {
                reciever.Text = dragged.Text;
                dragged.Opacity = 0.5;
                rijesenih++;
            }

            if(rijesenih==6)
            {
                success.Visibility = Visibility.Visible;
                soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                soundPlayer.Play();

            }

        }
    }
}

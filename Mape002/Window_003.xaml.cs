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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mape002
{
    /// <summary>
    /// Interaction logic for Window_003.xaml
    /// </summary>
    public partial class Window_003 : Window
    {
        List<Tuple<string, string, string>> brojevi;
        List<Tuple<TextBlock, TextBlock>> answerBlocks;
        Random random;
        List<int> iskoristeniRandom;
        List<TextBlock> textBlocks;
        List<Rectangle> glows;

        SoundPlayer soundPlayer;

        int brojRijesenih;
        public Window_003()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.odaberiIspravanOdgovor);
            soundPlayer.Play();
            glows = new List<Rectangle> { r1, r2, r3, r4, r5, r6 };
            r1.Visibility = Visibility.Visible;
            brojRijesenih = 0;
            random = new Random();
            iskoristeniRandom = new List<int>();
            textBlocks = new List<TextBlock> { tb1, tb2, tb3, tb4, tb5, tb6 };
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

            answerBlocks = new List<Tuple<TextBlock, TextBlock>>
            {
                new Tuple<TextBlock, TextBlock>(tb1Pisemo,tb1Brojimo),
                new Tuple<TextBlock, TextBlock>(tb2Pisemo,tb2Brojimo),
                new Tuple<TextBlock, TextBlock>(tb3Pisemo,tb3Brojimo),
                new Tuple<TextBlock, TextBlock>(tb4Pisemo,tb4Brojimo),
                new Tuple<TextBlock, TextBlock>(tb5Pisemo,tb5Brojimo),
                new Tuple<TextBlock, TextBlock>(tb6Pisemo,tb6Brojimo),
            };

            for (int i = 0; i < 6; i++)
            {
                int r = random.Next(0, 9);

                while (iskoristeniRandom.IndexOf(r) != -1)
                {
                    r = random.Next(0, 9);
                }
                iskoristeniRandom.Add(r);
                textBlocks.ElementAt(i).Text = brojevi.ElementAt(r).Item1;
            }

            for (int i = 0; i < 6; i++)
            {
                int r = random.Next(iskoristeniRandom.Count - 1);

                answerBlocks.ElementAt(i).Item1.Text = brojevi.ElementAt(iskoristeniRandom.ElementAt(r)).Item3;
                answerBlocks.ElementAt(i).Item2.Text = brojevi.ElementAt(iskoristeniRandom.ElementAt(r)).Item2;

                iskoristeniRandom.RemoveAt(r);
            }


        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_002a window_002a = new Window_002a();
            window_002a.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_004 window_004 = new Window_004();
            window_004.Show();
            this.Close();

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC9EDF5"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD0D8D7"));


        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hand.Visibility = Visibility.Hidden;
            Border border = sender as Border;
            var odgovorTb = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(border, 0), 1) as TextBlock;
            int odgovor = int.Parse(odgovorTb.Text.Substring(0, 1)) * 10;

            if (odgovor == int.Parse(textBlocks.ElementAt(brojRijesenih).Text))
            {
                glows.ElementAt(brojRijesenih).Visibility = Visibility.Hidden;
                textBlocks.ElementAt(brojRijesenih).Opacity = 0.5;
                try
                {
                    glows.ElementAt(brojRijesenih + 1).Visibility = Visibility.Visible;
                }
                catch (Exception)
                {

                }
                brojRijesenih++;
                border.Opacity = 0.5;

            }

            if (brojRijesenih == 6)
            {
                success.Visibility = Visibility.Visible;
                soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                soundPlayer.Play();
            }

        }
    }
}

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
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
            rijesenih = 0;
            iskoristeniRandom = new List<int>();
            random = new Random();
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

            hand.Opacity = 0.05;
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

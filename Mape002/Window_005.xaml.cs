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
    /// Interaction logic for Window_005.xaml
    /// </summary>
    public partial class Window_005 : Window
    {
        List<Tuple<string, string, string>> brojevi;
        List<TextBlock> textBlocks;
        Random random;
        List<int> iskoristeniRandom;
        int rijesenih;
        SoundPlayer soundPlayer;
        public Window_005()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
            rijesenih = 0;
            iskoristeniRandom = new List<int>();
            random = new Random();
            textBlocks = new List<TextBlock> { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tb15, tb16 };

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

            for (int i = 0; i < 8; i++)
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
            Window_004 window_004 = new Window_004();
            window_004.Show();
            this.Close();

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_006 window_006 = new Window_006();
            window_006.Show();
            this.Close();

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            DragDrop.DoDragDrop(tb, tb.Text, DragDropEffects.Move);

        }

        private void Atb1_Drop(object sender, DragEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            Border border = VisualTreeHelper.GetParent(tb) as Border;
            int row = int.Parse(border.GetValue(Grid.RowProperty).ToString());

            string znak = (string)e.Data.GetData(typeof(string));

            int lijeviBroj, desniBroj;
            try
            {
                lijeviBroj = int.Parse(textBlocks[row].Text);
                desniBroj = int.Parse(textBlocks[row + 8].Text);
            }
            catch (Exception)
            {
                lijeviBroj = int.Parse(Regex.Replace(textBlocks[row].Text, "D", "0"));
                desniBroj = int.Parse(Regex.Replace(textBlocks[row + 8].Text, "D", "0"));
            }

            switch (znak)
            {
                case ">":
                    if (lijeviBroj > desniBroj)
                    {
                        tb.Text = znak;
                        rijesenih++;
                    }
                    break;
                case "<":
                    if (lijeviBroj < desniBroj)
                    {
                        tb.Text = znak;
                        rijesenih++;
                    }
                    break;
                case "=":
                    if (lijeviBroj == desniBroj)
                    {
                        tb.Text = znak;
                        rijesenih++;
                    }
                    break;

            }
            if (rijesenih == 8)
            {
                success.Visibility = Visibility.Visible;
                soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                soundPlayer.Play();
            }

        }
    }
}

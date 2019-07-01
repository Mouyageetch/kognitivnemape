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

namespace Mape002
{
    /// <summary>
    /// Interaction logic for Window_008.xaml
    /// </summary>
    public partial class Window_008 : Window
    {
        List<TextBlock> textBlocksPlus, textBlocksMinus;
        Random random;
        List<Tuple<int, int>> generiraniParoviPlus, generiraniParoviMinus;
        int brojRjesenih;
        SoundPlayer soundPlayer;
        public Window_008()
        {
            InitializeComponent();
            brojRjesenih = 0;
            generiraniParoviPlus = new List<Tuple<int, int>>();
            generiraniParoviMinus = new List<Tuple<int, int>>();
            textBlocksPlus = new List<TextBlock>
            {
                tb0,tb1,tb2,tb3,tb4,tb5,tb6,tb7,tb8,tb9,tb10,tb11,tb12,tb13,tb14,tb15,tb16,tb17,tb18,tb19,tb20,tb21,tb22,tb23
            };

            textBlocksMinus = new List<TextBlock>
            {
                tb24,tb25,tb26,tb27,tb28,tb29,tb30,tb31,tb32,tb33,tb34,tb35,tb36,tb37,tb38,tb39,tb40,tb41,tb42,tb43,tb44,tb45,tb46,tb47
            };
            random = new Random();

            setAddingMatrix();

            setSubtractingMatrix();



        }

        void setSubtractingMatrix()
        {

            for (int i = 0; i < 12; i++)
            {
                int a, b;
                a = random.Next(1, 10);
                b = random.Next(1, 10);

                while (a - b <= 0 || VecPostojiMinus(a, b))
                {
                    a = random.Next(1, 10);
                    b = random.Next(1, 10);
                }

                generiraniParoviMinus.Add(Tuple.Create(a, b));

                if (i < 7)
                {
                    textBlocksMinus[i].Text = generiraniParoviMinus[i].Item1.ToString() + "D";
                    textBlocksMinus[i + 12].Text = generiraniParoviMinus[i].Item2.ToString() + "D";
                }
                else
                {
                    textBlocksMinus[i].Text = generiraniParoviMinus[i].Item1.ToString() + "0";
                    textBlocksMinus[i + 12].Text = generiraniParoviMinus[i].Item2.ToString() + "0";
                }
            }
        }

        void setAddingMatrix()
        {
            for (int i = 0; i < 12; i++)
            {
                int a, b;
                a = random.Next(1, 10);
                b = random.Next(1, 10);

                while (a + b > 10 || VecPostojiPlus(a, b))
                {
                    a = random.Next(1, 10);
                    b = random.Next(1, 10);
                }

                generiraniParoviPlus.Add(Tuple.Create(a, b));

                if (i < 7)
                {
                    textBlocksPlus[i].Text = generiraniParoviPlus[i].Item1.ToString() + "D";
                    textBlocksPlus[i + 12].Text = generiraniParoviPlus[i].Item2.ToString() + "D";
                }
                else
                {
                    textBlocksPlus[i].Text = generiraniParoviPlus[i].Item1.ToString() + "0";
                    textBlocksPlus[i + 12].Text = generiraniParoviPlus[i].Item2.ToString() + "0";
                }
            }
        }

        Boolean VecPostojiPlus(int a, int b)
        {
            if (generiraniParoviPlus.Contains(Tuple.Create(a, b)))
            {
                return true;
            }

            return false;
        }
        Boolean VecPostojiMinus(int a, int b)
        {
            if (generiraniParoviMinus.Contains(Tuple.Create(a, b)))
            {
                return true;
            }

            return false;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hand.Opacity = 0.1;
            Grid.SetZIndex(hand, -5);
            TextBlock tb = sender as TextBlock;
            int broj = int.Parse(tb.Text);
            DragDrop.DoDragDrop(tb, broj, DragDropEffects.Move);

        }

        private void Atb0_Drop(object sender, DragEventArgs e)
        {
            TextBlock tb = sender as TextBlock;

            int tbBroj = int.Parse(tb.Name.Substring(3));

            int odgovor = (int)e.Data.GetData(typeof(int)) / 10;

            Border border = VisualTreeHelper.GetParent(tb) as Border;
            int red = int.Parse(border.GetValue(Grid.RowProperty).ToString());

            if (tbBroj<12)
            {
                if (generiraniParoviPlus[red].Item1 + generiraniParoviPlus[red].Item2 == odgovor)
                {
                    tb.Text = odgovor.ToString() + "0";
                    brojRjesenih++;
                }
            }
            else
            {
                if(generiraniParoviMinus[red].Item1-generiraniParoviMinus[red].Item2 == odgovor)
                {
                    tb.Text = odgovor.ToString() + "0";
                    brojRjesenih++;
                }

            }
            if(brojRjesenih==24)
            {
                success.Visibility = Visibility.Visible;
                soundPlayer = new SoundPlayer(Properties.Resources.successUke);
                soundPlayer.Play();

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
    }
}

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
    /// Interaction logic for Window_002a.xaml
    /// </summary>
    public partial class Window_002a : Window
    {
        List<UIElement> first, up, down;
        SoundPlayer soundPlayer;
        public Window_002a()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
            first = new List<UIElement>
            {
                line001,line002,border001,border002
            };
            up = new List<UIElement>
            {
                line003,line004,line005,line006,line007,line008,line009,line010, sp1,sp2,sp3,sp4,sp5,sp6,sp7,sp8
            };
            down = new List<UIElement>
            {
                line011,bl,tb10,tb30,tb30_Copy,tb30_Copy1,tb30_Copy2,tb30_Copy3,tb30_Copy4,tb30_Copy5
            };

            foreach (var item in first)
            {
                item.Visibility = Visibility.Hidden;

            }
            foreach (var item in up)
            {
                item.Visibility = Visibility.Hidden;

            }
            foreach (var item in down)
            {
                item.Visibility = Visibility.Hidden;

            }



        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_002 window_002 = new Window_002();
            window_002.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003 window_003 = new Window_003();
            window_003.Show();
            this.Close();
        }

        private void Border002_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var el in down)
            {

                el.Visibility = el.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            foreach (UIElement uIElement in first)
            {
                uIElement.Visibility = uIElement.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }

            foreach (UIElement uIElement in up)
            {
                uIElement.Visibility = Visibility.Hidden;
            }

            foreach (UIElement uIElement in down)
            {
                uIElement.Visibility = Visibility.Hidden;
            }



        }

        private void Border001_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var el in up)
            {
                el.Visibility = el.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }

        }
    }
}

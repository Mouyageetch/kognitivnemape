using Microsoft.Expression.Controls;
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

namespace Mape001
{
    /// <summary>
    /// Interaction logic for Window_007.xaml
    /// </summary>
    public partial class Window_007 : Window
    {
        List<TextBlock> tbs;
        List<LineArrow> lines;
        List<Image> images;

        SoundPlayer soundPlayer;
        public Window_007()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

            tbs = new List<TextBlock>
            {
                zakOtv,zakZatv,prave,izlOtv,izlZatv
            };

            lines = new List<LineArrow>
            {
                zakOtvLine001,zakOtvLine002,
                zakZatvLine001,zakZatvLine002,
                praveLine001,
                izlOtvLine001,izlOtvLine002,
                izlZatvLine001,izlZatvLine002,izlZatvLine003,
                linijeLine001,linijeLine002,linijeLine003,linijeLine004,linijeLine005
            };

            images = new List<Image>
            {
                zakOtv001,zakOtv002,
                zakZatv001,zakZatv002,
                prave001,
                izlOtv001,izlOtv002,
                izlZatv001, izlZatv002,izlZatv003
            };
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock tb = sender as TextBlock;
            switch (tb.Name)
            {
                case "prave":
                    soundPlayer = new SoundPlayer(Properties.Resources.praveLinije);
                    soundPlayer.Play();
                    break;
                case "zakZatv":
                    soundPlayer = new SoundPlayer(Properties.Resources.zakrivljeneZatvorene);
                    soundPlayer.Play();
                    break;
                case "zakOtv":
                    soundPlayer = new SoundPlayer(Properties.Resources.zakrivljeneOtvorene);
                    soundPlayer.Play();
                    break;
                case "izlZatv":
                    soundPlayer = new SoundPlayer(Properties.Resources.izlomljeneZatvorene);
                    soundPlayer.Play();
                    break;
                case "izlOtv":
                    soundPlayer = new SoundPlayer(Properties.Resources.izlomljeneOtvorene);
                    soundPlayer.Play();
                    break;


            }

            foreach (var line in lines)
            {
                if (line.Name.StartsWith(tb.Name))
                    line.Visibility = line.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }

            foreach (var image in images)
            {
                if (image.Name.StartsWith(tb.Name))
                    image.Visibility = image.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

            }

        }

        private void Linije_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.linije);
            soundPlayer.Play();
            TextBlock tb = sender as TextBlock;

            foreach (var line in lines)
            {
                if (line.Name.StartsWith("linije"))
                {
                    line.Visibility = line.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                }
                else
                {
                    line.Visibility = Visibility.Hidden;
                }
            }

            foreach (var block in tbs)
            {
                block.Visibility = block.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }

            foreach (var image in images)
            {
                image.Visibility = Visibility.Hidden;
            }


        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_006 window_006 = new Window_006();
            window_006.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_008 window_008 = new Window_008();
            window_008.Show();
            this.Close();
        }
    }
}

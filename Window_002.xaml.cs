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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mape001
{
    /// <summary>
    /// Interaction logic for Window_002.xaml
    /// </summary>
    public partial class Window_002 : Window
    {
        SoundPlayer soundPlayer;
        LineArrow[] lineArrows0, valjakLines, kupaLines, kvadarLines, loptaLines, kockaLines, piramidaLines;
        List<LineArrow[]> allLines;
        Image[] valjakImages, kupaImages, kvadarImages, loptaImages, kockaImages, piramidaImages;

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            Window_001 window_001 = new Window_001();
            window_001.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003 window_003 = new Window_003();
            window_003.Show();
            this.Close();
        }

        List<Image[]> allImages;

        TextBlock[] textBlocks;


        public Window_002()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
            textBlocks = new TextBlock[] { kupe, kvadra, lopte, kocke, piramide, valjka };
            lineArrows0 = new LineArrow[] { line01, line02, line03, line04, line05, line06 };

            valjakLines = new LineArrow[] { valjakLine1, valjakLine2, valjakLine3 };
            kupaLines = new LineArrow[] { kupaLine1, kupaLine2, kupaLine3 };
            kvadarLines = new LineArrow[] { kvadarLine1, kvadarLine2, kvadarLine3 };
            loptaLines = new LineArrow[] { loptaLine1, loptaLine2, loptaLine3, loptaLine4 };
            kockaLines = new LineArrow[] { kockaLine1, kockaLine2, kockaLine3, kockaLine4 };
            piramidaLines = new LineArrow[] { piramidaLine1, piramidaLine2, piramidaLine3 };

            allLines = new List<LineArrow[]>
            { valjakLines, kupaLines, kvadarLines, loptaLines, kockaLines, piramidaLines };

            valjakImages = new Image[] { valjak001, valjak002, valjak003 };
            kupaImages = new Image[] { kupa001, kupa002, kupa003 };
            kvadarImages = new Image[] { kvadar001, kvadar002, kvadar003 };
            loptaImages = new Image[] { lopta001, lopta002, lopta003, lopta004 };
            kockaImages = new Image[] { kocka001, kocka002, kocka003, kocka004 };
            piramidaImages = new Image[] { piramida001, piramida002, piramida003 };

            allImages = new List<Image[]>
            { valjakImages,kupaImages,kvadarImages,loptaImages,kockaImages,piramidaImages };
        }


        private void Piramide_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaPiramide);
            soundPlayer.Play();
            foreach (var line in piramidaLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }


            foreach (var image in piramidaImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }

        }

        private void Kupe_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaKupe);
            soundPlayer.Play();
            foreach (var line in kupaLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            foreach (var image in kupaImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void Valjka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaValjka);
            soundPlayer.Play();
            foreach (var line in valjakLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            foreach (var image in valjakImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void Kocke_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaKocke);
            soundPlayer.Play();
            foreach (var line in kockaLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            foreach (var image in kockaImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void Lopte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaLopte);
            soundPlayer.Play();
            foreach (var line in loptaLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            foreach (var image in loptaImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void Kvadra_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblikaKvadra);
            soundPlayer.Play();
            foreach (var line in kvadarLines)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
            foreach (var image in kvadarImages)
            {
                image.Visibility = (image.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.predmetiOblika);
            soundPlayer.Play();

            foreach (var lineArray in allLines)
            {
                foreach (var line in lineArray)
                {
                    line.Visibility = Visibility.Hidden;

                }
            }

            foreach (var imageArray in allImages)
            {
                foreach (var image in imageArray)
                {
                    image.Visibility = Visibility.Hidden;

                }
            }
            foreach (var textBlock in textBlocks)
            {
                textBlock.Visibility = (textBlock.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }

            foreach (var line in lineArrows0)
            {
                line.Visibility = (line.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            }

            hand.Visibility = Visibility.Hidden;

        }
    }
}

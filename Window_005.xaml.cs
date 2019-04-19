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
    /// Interaction logic for Window_005.xaml
    /// </summary>
    public partial class Window_005 : Window
    {
        List<LineArrow> lines01, lines02, lines03;
        List<Image> glows;
        SoundPlayer soundPlayer;

        public Window_005()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

            lines01 = new List<LineArrow> {
                stranaLine001, stranaLine002, stranaLine003, stranaLine004, stranaLine005,
                bridLine001,bridLine002,bridLine003,bridLine004,bridLine005,
                vrhLine001,vrhLine002,vrhLine003,vrhLine004

            };

            lines03 = new List<LineArrow>
            {

                zakrivljeneLine001,zakrivljeneLine002,zakrivljeneLine003,
                ravneLine001,ravneLine002,ravneLine003,ravneLine004
            };

            lines02 = new List<LineArrow>
            {
                povrsiLine001,povrsiLine002
            };

            glows = new List<Image>
            {
                stranaGlow001,stranaGlow002,stranaGlow003,stranaGlow004,stranaGlow005,
                bridGlow001,bridGlow002,bridGlow003,bridGlow004,bridGlow005
            };
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;

            switch (tb.Name)
            {
                case "strana":
                    soundPlayer = new SoundPlayer(Properties.Resources.strana);
                    soundPlayer.Play();
                    break;
                case "vrh":
                    soundPlayer = new SoundPlayer(Properties.Resources.vrh);
                    soundPlayer.Play();
                    break;
                case "brid":
                    soundPlayer = new SoundPlayer(Properties.Resources.brid);
                    soundPlayer.Play();
                    break;

            }

            // Pokazi linije cije ime pocinje tekstom pritisnutog TextBlocka
            foreach (var line in lines01)
            {
                if (line.Name.StartsWith(tb.Name))
                    line.Visibility = line.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                else
                    line.Visibility = Visibility.Hidden;
            }

            foreach (var glow in glows)
            {
                if (glow.Name.StartsWith(tb.Name))
                    glow.Visibility = glow.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                else
                    glow.Visibility = Visibility.Hidden;

            }

        }

        private void Povrsi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;

            switch (tb.Name)
            {
                case "povrsi":
                    soundPlayer = new SoundPlayer(Properties.Resources.povrsi);
                    soundPlayer.Play();
                    break;
                case "zakrivljene":
                    soundPlayer = new SoundPlayer(Properties.Resources.zakrivljenePovrsi);
                    soundPlayer.Play();
                    break;
                case "ravne":
                    soundPlayer = new SoundPlayer(Properties.Resources.ravnePovrsi);
                    soundPlayer.Play();
                    break;

            }

            if (tb.Name == "povrsi")
            {
                zakrivljene.Visibility = zakrivljene.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                ravne.Visibility = ravne.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

                foreach (var line in lines02)
                {
                    line.Visibility = line.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

                }

                foreach (var line in lines03)
                {
                    line.Visibility = Visibility.Hidden;
                }
            }

            foreach (var line in lines03)
            {
                if (line.Name.StartsWith(tb.Name))
                    line.Visibility = line.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
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


    }
}

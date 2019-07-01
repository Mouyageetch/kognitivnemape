﻿using System;
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
    /// Interaction logic for Window_010.xaml
    /// </summary>
    public partial class Window_010 : Window
    {
        List<Image> stranaKockeObjects, stranaKvadrataObjects, bocnaStranaPiramideObjects, ravnaPovrsValjkaObjects;
        SoundPlayer soundPlayer;

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_009 window_009 = new Window_009();
            window_009.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_011 window_011 = new Window_011();
            window_011.Show();
            this.Close();
        }

        public Window_010()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

            stranaKockeObjects = new List<Image>
            {
                stranaKocke001,stranaKocke002,stranaKocke003,stranaKockeLines
            };

            stranaKvadrataObjects = new List<Image>
            {
                stranaKvadrata001,stranaKvadrata002,stranaKvadrata003,stranaKvadrataLines
            };

            bocnaStranaPiramideObjects = new List<Image>
            {
                bocnaStranaPiramide001,bocnaStranaPiramide002,bocnaStranaPiramide003,bocnaStranaPiramideLines
            };
            ravnaPovrsValjkaObjects = new List<Image>
            {
                ravnaPovrsValjka001,ravnaPovrsValjka002,ravnaPovrsValjka003,ravnaPovrsValjkaLines
            };


        }

        private void Linije_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;

            switch (tb.Name)
            {
                case "stranaKocke":
                    soundPlayer = new SoundPlayer(Properties.Resources.stranaKocke);
                    soundPlayer.Play();
                    foreach (var image in stranaKockeObjects)
                    {
                        image.Visibility = image.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                    }
                    break;
                case "stranaKvadrata":
                    soundPlayer = new SoundPlayer(Properties.Resources.stranaKvadrata);
                    soundPlayer.Play();
                    foreach (var image in stranaKvadrataObjects)
                    {
                        image.Visibility = image.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                    }
                    break;
                case "bocnaStranaPiramide":
                    soundPlayer = new SoundPlayer(Properties.Resources.bocnaStranaPiramide);
                    soundPlayer.Play();
                    foreach (var image in bocnaStranaPiramideObjects)
                    {
                        image.Visibility = image.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                    }
                    break;
                case "ravnaPovrsValjka":
                    soundPlayer = new SoundPlayer(Properties.Resources.ravnaPovrsValjka);
                    soundPlayer.Play();
                    foreach (var image in ravnaPovrsValjkaObjects)
                    {
                        image.Visibility = image.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
                    }
                    break;
            }
        }
    }
}
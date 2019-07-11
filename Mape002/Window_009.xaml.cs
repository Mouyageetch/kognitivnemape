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

namespace Mape002
{
    /// <summary>
    /// Interaction logic for Window_009.xaml
    /// </summary>
    public partial class Window_009 : Window
    {
        SoundPlayer soundPlayer;
        public Window_009()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.formiranjeOstalih);
            soundPlayer.Play();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_008 window_008 = new Window_008();
            window_008.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_010 window_010 = new Window_010();
            window_010.Show();
            this.Close();

        }
    }
}

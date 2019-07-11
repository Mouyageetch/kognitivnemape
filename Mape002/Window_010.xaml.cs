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
    /// Interaction logic for Window_010.xaml
    /// </summary>
    public partial class Window_010 : Window
    {
        SoundPlayer soundPlayer;
        public Window_010()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.uporedjivanje);
            soundPlayer.Play();
        }

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
    }
}
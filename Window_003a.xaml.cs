﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Window_003a.xaml
    /// </summary>
    public partial class Window_003a : Window
    {
        Image dragSource = null;

        public Window_003a()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            dragSource = (Image)e.Source;
            DragDrop.DoDragDrop(img, img.Source.ToString(), DragDropEffects.Move);

        }


        private void Valjak001_Drop(object sender, DragEventArgs e)
        {
            Image img = sender as Image;
            string src = (string)e.Data.GetData(typeof(string));
            string fileName = System.IO.Path.GetFileName(src);

            if (fileName.StartsWith(img.Name.Remove(img.Name.Length - 3)))
            {
                // PREUZMI SOURCE SLIKU
                ImageSourceConverter converter = new ImageSourceConverter();
                img.Source = (ImageSource)converter.ConvertFromString(src);

                // OCISTI STACK PANEL
                StackPanel parent = (StackPanel)VisualTreeHelper.GetParent(img);
                parent.ClearValue(StackPanel.BackgroundProperty);

                // ZAKLJUCAJ NOVU SLIKU I IZBRISI STARU
                img.AllowDrop = false;
                dragSource.Visibility = Visibility.Hidden;

                // PROVJERI DA LI JE ZADATAK ISPUNJEN


                bool visible = false;

                foreach (Image image in wrapPanel.Children)
                {
                    if (image.Visibility == Visibility.Visible)
                        visible = true;
                }
                // AKO SU SVI NEVIDLJIVI
                if (!visible)
                    success.Visibility = Visibility.Visible;
            }

        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_004 window_004 = new Window_004();
            window_004.Show();
            this.Close();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003 window_003 = new Window_003();
            window_003.Show();
            this.Close();
        }
    }
}

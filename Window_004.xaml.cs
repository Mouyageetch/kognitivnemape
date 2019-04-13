using Microsoft.Expression.Controls;
using System;
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
    /// Interaction logic for Window_004.xaml
    /// </summary>
    public partial class Window_004 : Window
    {
        List<LineArrow> lines;
        List<Image> glows;

        public Window_004()
        {
            InitializeComponent();

            lines = new List<LineArrow> {
                stranaLine001, stranaLine002, stranaLine003, stranaLine004, stranaLine005,
                bridLine001,bridLine002,bridLine003,bridLine004,bridLine005,
                vrhLine001,vrhLine002,vrhLine003,vrhLine004
            };

            glows = new List<Image>
            {
                stranaGlow001,stranaGlow002,stranaGlow003,stranaGlow004,stranaGlow005
            };
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;

            // Pokazi linije cije ime pocinje tekstom pritisnutog TextBlocka
            foreach (var line in lines)
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

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window_003 window_003 = new Window_003();
            window_003.Show();
            this.Close();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

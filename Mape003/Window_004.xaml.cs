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

namespace Mape003
{
    /// <summary>
    /// Interaction logic for Window_004.xaml
    /// </summary>
    public partial class Window_004 : Window
    {
        public Window_004()
        {
            InitializeComponent();
        }

        private void PreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void NextWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

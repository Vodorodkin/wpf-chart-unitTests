using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace project
{
    /// <summary>
    /// Логика взаимодействия для Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();
        }




        private void mimain_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void menu_Help_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("DrawIt.chm");
        }
    }
}
    



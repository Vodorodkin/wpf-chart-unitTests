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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Diagnostics;

namespace project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_a_Click(object sender, RoutedEventArgs e)
        {

            
            if (TextBox_m.Text != "")
            {
                Dan.m = Convert.ToInt32(TextBox_m.Text);
                Dan.a1 = Convert.ToInt32(TextBox_a1.Text);
                Dan.a2 = Convert.ToInt32(TextBox_a2.Text);
                if(Dan.a1>Dan.a2)
                {
                    int a = Dan.a2;
                    Dan.a2 = Dan.a1;
                    Dan.a1 = a;
                }
                Dan.S = 0;
                methods.massacreate();
                Button_c.IsEnabled = true;
                Button_x.IsEnabled = false;
                Button_y.IsEnabled = false;
                Button_y_sort.IsEnabled = false;
                Button_create.IsEnabled = false;
                Button_fomr2.IsEnabled = false;
                mip.IsEnabled = false;
                menu_Graph.IsEnabled = false;
                DataGrid_a.ItemsSource = FormirationDataGrid.ToDataTable(Dan.A,"A").DefaultView;
            }

            
        }

        private void Button_c_Click(object sender, RoutedEventArgs e)
        {

            Dan.C = new double[Dan.m];
            Dan.R = Convert.ToDouble(TextBox_R.Text);
            Dan.C1 = Convert.ToDouble(TextBox_C1.Text);
            Dan.C[0] = Dan.C1;
            bool check = true;
            double progr = Dan.C[0];
            methods.progression(ref progr);
            progr = Dan.C[0];
            for (int i=0;i<Dan.m;i++)
            if (Dan.C[i] == 0)
            {

                    check = false;
            }
            
            if (check)
            {
                Button_x.IsEnabled = true;
                DataGrid_c.ItemsSource = FormirationDataGrid.ToDataTable(Dan.C, "C").DefaultView;
            }
            else
            {
                MessageBox.Show("Элемент арифметической прогрессии не может быть равен 0");
            }
        }

        private void Button_x_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            Dan.P = 1;
            Dan.X = new double[Dan.m];
            Dan.B = Convert.ToDouble(TextBox_b.Text);
            for (int i = 0; i < Dan.m; i++)
                if (Math.Pow(i, 2) + Dan.B == 0) check = true;
            
            if (check)
            {
                MessageBox.Show("Вспомогательная переменная выходит из границ допустимых значений");
            }
            else
            {
                methods.massxcreate();
                DataGrid_x.ItemsSource = FormirationDataGrid.ToDataTable(Dan.X, "X").DefaultView;
                Button_y.IsEnabled = true;
            }
        }

        private void Button_y_Click(object sender, RoutedEventArgs e)
        {
            Dan.h = Convert.ToDouble(TextBox_h.Text);
            Dan.my = Convert.ToInt32((Dan.m - 1) / Dan.h + 1);
            if (Dan.my < 0) Dan.my *= -1;
            Dan.Y = new double[Dan.my];
            double[] a = new double[Dan.m];
            a = methods.PN1(Dan.m, Dan.X);
            Button_y_sort.IsEnabled = true;
            DataGrid_y.ItemsSource = FormirationDataGrid.ToDataTable(methods.PN2(a, Dan.m, Dan.Y, Dan.h, Dan.my),"Y").DefaultView;
        }

        private void Button_y_sort_Click(object sender, RoutedEventArgs e)
        {
            Dan.Y_Sort = new double[Dan.my];
            Array.Copy(Dan.Y, Dan.Y_Sort, Dan.Y.Length);
            methods.ShellSort(Dan.Y_Sort);
            DataGrid_y_sort.ItemsSource = FormirationDataGrid.ToDataTable(Dan.Y_Sort, "Y_sort").DefaultView;
            Button_create.IsEnabled = true;
            Button_fomr2.IsEnabled = true;
            menu_Graph.IsEnabled = true;
            mip.IsEnabled = true;
            mio.IsEnabled = true;
        }


        private void Button_fomr2_Click(object sender, RoutedEventArgs e)
        {
            Dan.text = new TextEditor();
            Dan.text.ShowDialog();
        }


        private void Button_createall_Click(object sender, RoutedEventArgs e)
        {

                Button_a_Click(sender, e);
                Button_c_Click(sender, e);
                Button_x_Click(sender, e);
                Button_y_Click(sender, e);
                Button_y_sort_Click(sender, e);
                Button_create.IsEnabled = true;
                Button_fomr2.IsEnabled = true;
                Button_x.IsEnabled = false;
                Button_y.IsEnabled = false;
                Button_y_sort.IsEnabled = false;
                Button_c.IsEnabled = false;
            bool check = false;
            for (int i = 0; i < Dan.m; i++)
                if (Math.Pow(i, 2) + Dan.B == 0) check = true;
            for (int i = 0; i < Dan.m; i++)
                if (Dan.C[i] == 0) check = true;

            if (check)
            {
                menu_clear_Click(sender, e);
            }

        }
        private void Button_create_Click(object sender, RoutedEventArgs e)
        {
            
            Dan.chart = new Chart();
           // Dan.chart.Visibility = Visibility.Visible;
            Dan.chart.ShowDialog();
        }
        private void Double_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox thisTextBox = (sender as TextBox);
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "-") && (!thisTextBox.Text.Contains("-") && thisTextBox.Text.Length == 0)))
            {
                if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") && (!thisTextBox.Text.Contains(",") && thisTextBox.Text.Length != 0)))
            {
                
                    e.Handled = true;
                }
            }

        }
        private void Int_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox thisTextBox = (sender as TextBox);
            e.Handled = (!(Char.IsDigit(e.Text, 0) && !((thisTextBox.Text.IndexOf("-") == 0) && thisTextBox.SelectionStart == 0))) &&
                ((e.Text.Substring(0, 1) != "-") || (thisTextBox.Text.IndexOf("-") == 0) || thisTextBox.SelectionStart != 0);
        }
        private void TextBox_m_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string(textBox.Text.Where(ch => (ch >= '0' && ch <= '9' && textBox.Text[0] != '0')).ToArray());
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (TextBox_a1.Text == "" || TextBox_a2.Text == "" || TextBox_b.Text == "" || TextBox_h.Text == "" || TextBox_m.Text == "" || TextBox_R.Text == "" || TextBox_C1.Text == "" ^ TextBox_a1.Text == "-" || TextBox_a2.Text == "-" || TextBox_b.Text == "-" || TextBox_h.Text == "-" || TextBox_m.Text == "-" || TextBox_R.Text == "-" || TextBox_C1.Text == "-")
            {
                Button_createall.IsEnabled = false;
                Button_a.IsEnabled = false;
                Button_c.IsEnabled = false;
                Button_x.IsEnabled = false;
                Button_y.IsEnabled = false;
                Button_y_sort.IsEnabled = false;

                //MasMenu.IsEnabled = false;
            }
            else
            {
                Button_createall.IsEnabled = true;
                Button_a.IsEnabled = true;
                //MasMenu.IsEnabled = true;
            }
        }

        private void Button_open_Click(object sender, RoutedEventArgs e)
        {
            string fn = "";
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
            if (myFile.ShowDialog() == true)
                fn = (myFile.FileName);
            try
            {              
                methods.fileread(fn);
                if (!(Dan.A == null)&& !(Dan.C == null) && !(Dan.X == null) && !(Dan.Y == null) && !(Dan.Y_Sort == null))
                {
                    DataGrid_a.ItemsSource = FormirationDataGrid.ToDataTable(Dan.A, "A").DefaultView;
                    DataGrid_c.ItemsSource = FormirationDataGrid.ToDataTable(Dan.C, "C").DefaultView;
                    DataGrid_x.ItemsSource = FormirationDataGrid.ToDataTable(Dan.X, "X").DefaultView;
                    DataGrid_y.ItemsSource = FormirationDataGrid.ToDataTable(Dan.Y, "Y").DefaultView;
                    DataGrid_y_sort.ItemsSource = FormirationDataGrid.ToDataTable(Dan.Y_Sort, "Y_sort").DefaultView;
                    Button_create.IsEnabled = true;
                    Button_fomr2.IsEnabled = true;

                        TextBox_m.Text = Convert.ToString(Dan.m);
                        TextBox_a1.Text = Convert.ToString(Dan.a1);
                        TextBox_a2.Text = Convert.ToString(Dan.a2);
                        TextBox_R.Text = Convert.ToString(Dan.R);
                        TextBox_C1.Text = Convert.ToString(Dan.C1);
                        TextBox_b.Text = Convert.ToString(Dan.B);
                        TextBox_h.Text = Convert.ToString(Dan.h);
                    
                }
                mip.IsEnabled = true;
            }
            catch
            { }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menu_Help_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("DrawIt.chm");
        }

        private void menu_clear_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_a.ItemsSource = null;
            DataGrid_c.ItemsSource = null;
            DataGrid_x.ItemsSource = null;
            DataGrid_y.ItemsSource = null;
            DataGrid_y_sort.ItemsSource = null;
            Button_create.IsEnabled = false;
            Button_fomr2.IsEnabled = false;
            mip.IsEnabled = false;
            menu_Graph.IsEnabled = false;
            Button_c.IsEnabled = false;
            Button_x.IsEnabled = false;
            Button_y.IsEnabled = false;
            Button_y_sort.IsEnabled = false;
            TextBox_a1.Clear();
            TextBox_a2.Clear();
            TextBox_b.Clear();
            TextBox_C1.Clear();
            TextBox_h.Clear();
            TextBox_m.Clear();
            TextBox_R.Clear();
            Button_createall.IsEnabled = false;
            Button_a.IsEnabled = false;

        }
    }
}
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для TextEditor.xaml
    /// </summary>
    public partial class TextEditor : Window
    {
        public TextEditor()
        {
            InitializeComponent();
        }
        private void mimain_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            string fn = "";
            SaveFileDialog myFile = new SaveFileDialog();
            myFile.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
            if (myFile.ShowDialog() == true)
                fn = (myFile.FileName);
            try { 
            using (StreamWriter filein = new StreamWriter($"{fn}", false))
            {
                filein.WriteLine($"{Convert.ToString(textBox.Text)}");
            }
            textBox.Clear();
            using (StreamReader filein = new StreamReader($"{fn}", Encoding.GetEncoding(65001)))
            {
                string[] b = filein.ReadToEnd().ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < b.Length; i++)
                    textBox.Text += b[i];
            }
            }
            catch
            {

            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!(Dan.A == null) && !(Dan.C == null) && !(Dan.X == null) && !(Dan.Y == null) && !(Dan.Y_Sort == null))
            {
                misave.IsEnabled = true;
                textBox.Text += ("Массив А:\r\r");
                for (int i = 0; i < Dan.A.GetLength(0); i++)
                {
                    for (int j = 0; j < Dan.A.GetLength(1); j++)
                    {
                        textBox.Text += $"{Dan.A[i, j],5} ";
                    }
                    textBox.Text += "\r";
                }
                textBox.Text += "\rМассив C:\r\r";
                for (int i = 0; i < Dan.C.Length; i++)
                {
                    textBox.Text += $"{Dan.C[i],5} ";
                }
                textBox.Text += "\r";
                textBox.Text += "\rМассив X:\r\r";
                for (int i = 0; i < Dan.X.Length; i++)
                {
                    textBox.Text += $"{Dan.X[i],5} ";
                }
                textBox.Text += "\r";
                textBox.Text += "\rМассив Y:\r\r";
                for (int i = 0; i < Dan.Y.Length; i++)
                {
                    textBox.Text += $"{Dan.Y[i],5} ";
                }
                textBox.Text += "\r";
                textBox.Text += "\rОтсортированный массив Y:\r\r";
                for (int i = 0; i < Dan.Y_Sort.Length; i++)
                {
                    textBox.Text += $"{Dan.Y_Sort[i],5} ";
                }
                textBox.Text += "\r";
                textBox.Text += "\rm: ";
                textBox.Text += $"{Dan.m,5} ";
                textBox.Text += "\ra1: ";
                textBox.Text += $"{Dan.a1,5} ";
                textBox.Text += "\ra2: ";
                textBox.Text += $"{Dan.a2,5} ";
                textBox.Text += "\rR: ";
                textBox.Text += $"{Dan.R,5} ";
                textBox.Text += "\rC1: ";
                textBox.Text += $"{Dan.C1,5} ";
                textBox.Text += "\rb: ";
                textBox.Text += $"{Dan.B,5} ";
                textBox.Text += "\rh: ";
                textBox.Text += $"{Dan.h,5} ";
            }
        }
       
      

        private void menu_Help_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("DrawIt.chm");
        }

        private void menu_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void mio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}

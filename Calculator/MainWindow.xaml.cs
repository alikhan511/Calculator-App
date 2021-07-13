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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void resultScreen_TextBox(object sender, TextChangedEventArgs e)
        {
             
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                if ((result_screen.Text == "0") || (isOperationPerformed))
                    result_screen.Clear();

                isOperationPerformed = false;
                Button btn = (Button)sender;
                if (btn.Content.ToString() == ".")
                {
                    if (!result_screen.Text.Contains("."))
                    {
                        result_screen.Text = result_screen.Text + btn.Content.ToString();
                    }
                }
                else
                {
                    result_screen.Text = result_screen.Text + btn.Content.ToString();
                }
            }
            catch{ }
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                Button btn = (Button)sender;

                if (result != 0)
                {
                    equal_Click(sender, e);
                    operationPerformed = btn.Content.ToString();
                    labelCurrentOperation.Content = result + " " + operationPerformed;
                    isOperationPerformed = true;
                }
                else
                {
                    operationPerformed = btn.Content.ToString();
                    result = Double.Parse(result_screen.Text);
                    labelCurrentOperation.Content = result + " " + operationPerformed;
                    isOperationPerformed = true;
                }
            }
            catch { }
        }

        private void ce_Click(object sender, RoutedEventArgs e)
        {
            result_screen.Text = "0";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            result_screen.Text = "0";
            result = 0;
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                switch (operationPerformed)
                {
                    case "+":
                        result_screen.Text = (result + Double.Parse(result_screen.Text)).ToString();
                        break;
                    case "-":
                        result_screen.Text = (result - Double.Parse(result_screen.Text)).ToString();
                        break;
                    case "*":
                        result_screen.Text = (result * Double.Parse(result_screen.Text)).ToString();
                        break;
                    case "/":
                        result_screen.Text = (result / Double.Parse(result_screen.Text)).ToString();
                        break;
                    default:
                        break;
                }
                result = Double.Parse(result_screen.Text);
                labelCurrentOperation.Content = "";
            }
            catch{ }
        }

        private void closeScreen_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

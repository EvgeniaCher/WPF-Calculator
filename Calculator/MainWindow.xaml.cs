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
using System.Windows.Threading;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startclock();
        }

        private void startclock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text += (sender as Button).Content; //Применяем ко всем цифрам и запятой
        }

        double firstNum = 0;
        double secondNum = 0;
        double valueNum = 0;
        string symbol = "";

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textBlock.Text);
            symbol = "+";
            textBlockSymbol.Text = "+";
            textBlock.Text = "";
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textBlock.Text);
            symbol = "-";
            textBlockSymbol.Text = "-";
            textBlock.Text = "";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textBlock.Text);
            symbol = "*";
            textBlockSymbol.Text = "*";
            textBlock.Text = "";
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textBlock.Text);
            symbol = "/";
            textBlockSymbol.Text = "/";
            textBlock.Text = "";
        }

        private void value_Click(object sender, RoutedEventArgs e)
        {
            textBlockSymbol.Text = "";
            secondNum = Convert.ToDouble(textBlock.Text);

            switch (symbol)
            {
                case "+":   
                    valueNum = firstNum + secondNum;
                    break;
                case "-":   
                    valueNum = firstNum - secondNum;
                    break;
                case "*":
                    valueNum = firstNum * secondNum;
                    break;
                case "/":
                    valueNum = firstNum / secondNum;
                    break;
            }
            textBlock.Text = valueNum.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text != "")
                textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1, 1);

            if (textBlockSymbol.Text != "")
                textBlockSymbol.Text = textBlockSymbol.Text.Remove(textBlockSymbol.Text.Length - 1, 1);
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";
            textBlockSymbol.Text = "";
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

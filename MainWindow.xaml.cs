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

namespace Laba3_Complex_Number
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
        ComplexNumber complexNumber = null;
        ComplexNumber complexNumber1 = null;
        ComplexNumber complexNumber2 = null;
        ComplexNumber complexNumber3 = null;

        private void buttonRandom_Click(object sender, RoutedEventArgs e)
        {
            boxFirstReal.Text = Math.Round(new Random().Next(0, 5) + new Random().NextDouble(), 2).ToString();
            boxFirstImagine.Text = Math.Round(new Random().Next(5, 10) + new Random().NextDouble(), 2).ToString();


            boxSecondReal.Text = Math.Round(new Random().Next(10, 15) + new Random().NextDouble(), 2).ToString();
            boxSecondImagine.Text = Math.Round(new Random().Next(7, 15) + new Random().NextDouble(), 2).ToString();

            boxThirdReal.Text = Math.Round(new Random().Next(1, 6) + new Random().NextDouble(), 2).ToString();
            boxThirdImagine.Text = Math.Round(new Random().Next(9, 30) + new Random().NextDouble(), 2).ToString();

            boxFourthtReal.Text = Math.Round(new Random().Next(10, 15) + new Random().NextDouble(), 2).ToString();
            boxFourthImagine.Text = Math.Round(new Random().Next(25, 30) + new Random().NextDouble(), 2).ToString();
        }

        private void buttonGetInfo_Click(object sender, RoutedEventArgs e)
        {
            string result = null;
            complexNumber = new ComplexNumber(double.Parse(boxFirstReal.Text), double.Parse(boxFirstImagine.Text));
            complexNumber1 = new ComplexNumber(double.Parse(boxSecondReal.Text), double.Parse(boxSecondImagine.Text));
            complexNumber2 = new ComplexNumber(double.Parse(boxThirdReal.Text), double.Parse(boxThirdImagine.Text));
            complexNumber3 = new ComplexNumber(double.Parse(boxFourthtReal.Text), double.Parse(boxFourthImagine.Text));
            result += complexNumber.ToString() + $"\n{new string('=', 50)}" +
                complexNumber1.ToString() + $"\n{new string('=', 50)}" +
                complexNumber2.ToString() + $"\n{new string('=', 50)}" +
                complexNumber3.ToString();
            MessageBox.Show(result);
        }

        private void mainResult_Click(object sender, RoutedEventArgs e)
        {
            if (complexNumber != null ||
                complexNumber1 != null ||
                complexNumber2 != null ||
                complexNumber3 != null)
            {
                ComplexNumber R = ComplexNumber.Pow(complexNumber1, 3) + (complexNumber + complexNumber1) * complexNumber3 / (complexNumber2 - complexNumber);
                MessageBox.Show(R.ToString());
            }
            else
            {
                MessageBox.Show("Ошибка\nНажмите на кнопку рандом => Сохранить");
            }

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            complexNumber = new ComplexNumber(double.Parse(boxFirstReal.Text), double.Parse(boxFirstImagine.Text));
            complexNumber1 = new ComplexNumber(double.Parse(boxSecondReal.Text), double.Parse(boxSecondImagine.Text));
            complexNumber2 = new ComplexNumber(double.Parse(boxThirdReal.Text), double.Parse(boxThirdImagine.Text));
            complexNumber3 = new ComplexNumber(double.Parse(boxFourthtReal.Text), double.Parse(boxFourthImagine.Text));
        }
    }
}

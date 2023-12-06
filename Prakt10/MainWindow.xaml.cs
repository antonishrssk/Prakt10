using System;
using System.Collections.Generic;
using System.Windows;

namespace Prakt10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<int> mas = new List<int>();
        Random rnd = new Random();
        int valueLimit = 1000;

        private void btnGenerateNumbers_Click(object sender, RoutedEventArgs e) // Сгенерировать числа
        {
            if (Int32.TryParse(tbCount.Text, out int n))
            {
                mas.Clear();
                listBoxNumbers.Items.Clear();

                for (int i = 0; i < n; i++)
                {
                    mas.Add(rnd.Next(valueLimit));
                    listBoxNumbers.Items.Add(mas[i]);
                }
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnCalcMaxAmongEven_Click(object sender, RoutedEventArgs e) // Рассчитать максимальное число среди четных
        {
            int max = 0;
            for (int i = 0; i < mas.Count; i++)
                if (mas[i] % 2 == 0 && max < mas[i])
                    max = mas[i];

            if (max == 0) tbMaxAmongEven.Text = "-";
            else tbMaxAmongEven.Text = max.ToString();
        }

        private void btnCalcMinAmongMultiplesOfA_Click(object sender, RoutedEventArgs e) // Рассчитать минимальное число среди кратных A
        {
            if (Int32.TryParse(tbValueA.Text, out int a) && a != 0)
            {
                int min = valueLimit;
                for (int i = 0; i < mas.Count; i++)
                    if (mas[i] % a == 0 && min > mas[i])
                        min = mas[i];

                if (min == 1000) tbMinAmongMultiplesOfA.Text = "-";
                else tbMinAmongMultiplesOfA.Text = min.ToString();
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) // Очистить
        {
            mas.Clear();
            listBoxNumbers.Items.Clear();
            tbMaxAmongEven.Clear();
            tbMinAmongMultiplesOfA.Clear();
        }

        private void miInfo_Click(object sender, RoutedEventArgs e) // О программе
        {
            MessageBox.Show("Практическая работа №10\n" +
                "Разработчик: Антонишин Кирилл Сергеевич\n" +
                "В одномерном массиве целых чисел найти максимальный среди элементов, являющихся четными, и минимальный среди элементов, кратных А.",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void miExit_Click(object sender, RoutedEventArgs e) // Выход
        {
            this.Close();
        }
    }
}

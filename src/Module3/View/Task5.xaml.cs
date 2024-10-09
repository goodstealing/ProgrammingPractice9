using Module3.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Module3.View
{
    public partial class Task5 : Window
    {
        public Task5()
        {
            InitializeComponent();
            InputTextBox.Text = "34, 7, 23, 32, 5, 62, 2, 18";
            DataContext = new ConnectorViewModel();
        }

        // Делегат для сортировки
        private delegate int[] SortDelegate(int[] array);

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсим введенные данные
                int[] numbers = InputTextBox.Text.Split(',')
                                    .Select(n => int.Parse(n.Trim()))
                                    .ToArray();

                // Выбираем метод сортировки
                SortDelegate sortMethod = null;

                if (SortMethodComboBox.SelectedIndex == 0) // Bubble Sort
                {
                    sortMethod = BubbleSort;
                }
                else if (SortMethodComboBox.SelectedIndex == 1) // Quick Sort
                {
                    sortMethod = QuickSort;
                }

                // Проверяем, выбран ли метод
                if (sortMethod != null)
                {
                    // Сортируем данные
                    int[] sortedNumbers = sortMethod(numbers);

                    // Отображаем результат
                    ResultTextBlock.Text = "Sorted: " + string.Join(", ", sortedNumbers);
                }
                else
                {
                    MessageBox.Show("Выберите метод сортировки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void InputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Если в текстовом поле есть текст, скрываем плейсхолдер, иначе показываем его
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(InputTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        // Реализация сортировки пузырьком
        private int[] BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        // Реализация быстрой сортировки
        private int[] QuickSort(int[] array)
        {
            QuickSortRecursive(array, 0, array.Length - 1);
            return array;
        }

        private void QuickSortRecursive(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSortRecursive(array, low, pivotIndex - 1);
                QuickSortRecursive(array, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    // Swap elements
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Swap pivot
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }
        new void MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed) { DragMove(); }
        }
    }
}

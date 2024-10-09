using Module3.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Module3.View
{
    public partial class Task4 : Window
    {
        public Task4()
        {
            InitializeComponent();
            LoadData();
            DataContext = new ConnectorViewModel();
        }

        public class DataItem
        {
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
        }

        // Делегат, который будет использоваться для фильтрации
        public delegate bool DataFilter(DataItem item);

        public class DataService
        {
            // Метод для фильтрации данных по переданному фильтру (делегату)
            public static List<DataItem> FilterData(List<DataItem> items, DataFilter filter)
            {
                return items.Where(item => filter(item)).ToList();
            }

            // Фильтр по ключевому слову
            public static bool FilterByKeyword(DataItem item, string keyword)
            {
                return item.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                       item.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            }

            // Фильтр по дате
            public static bool FilterByDate(DataItem item, DateTime fromDate, DateTime toDate)
            {
                return item.Date >= fromDate && item.Date <= toDate;
            }
        }

        private List<DataItem> _dataItems;

        private void LoadData()
        {
            // Пример данных
            _dataItems = new List<DataItem>
            {
                new DataItem { Title = "10.27.2024", Date = DateTime.Now.AddDays(-1), Description = "Description for event 1" },
                new DataItem { Title = "Текст2", Date = DateTime.Now.AddDays(-10), Description = "Description for event 2" },
                new DataItem { Title = "ЩЫШЗВ ыовыв ЫОВРЫВЫО", Date = DateTime.Now.AddDays(-20), Description = "Description for event 3" },
                new DataItem { Title = "1.22.2010", Date = DateTime.Now.AddDays(-5), Description = "Description for event 4" }
            };

            FilteredDataList.ItemsSource = _dataItems;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string keyword = KeywordTextBox.Text;
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate;

            List<DataItem> filteredData = _dataItems;

            if (!string.IsNullOrEmpty(keyword))
            {
                // Фильтр по ключевому слову
                filteredData = DataService.FilterData(filteredData, item => DataService.FilterByKeyword(item, keyword));
            }

            if (fromDate.HasValue && toDate.HasValue)
            {
                // Фильтр по дате
                filteredData = DataService.FilterData(filteredData, item => DataService.FilterByDate(item, fromDate.Value, toDate.Value));
            }

            // Обновляем список отображаемых данных
            FilteredDataList.ItemsSource = filteredData;
        }

        new void MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed) { DragMove(); }
        }
    }
}

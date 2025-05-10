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

namespace WpfZooApp.View
{
    /// <summary>
    /// Логика взаимодействия для VeterinaryCheksOldWindow.xaml
    /// </summary>
    public partial class VeterinaryCheksOldWindow : Window
    {
        private int selectedCheckId = -1;

        public VeterinaryCheksOldWindow()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxData();
        }

        // Загрузка данных о ветеринарных осмотрах
        private void LoadData()
        {
            using (var context = new ZooDBEntities())
            {
                // Вычисляем дату более месяца назад
                var currentDate = DateTime.Now;

                var oneMonthAgo = currentDate.AddMonths(-1);

                // Фильтруем осмотры, которые были сделаны более месяца назад
                var oldChecks = context.VeterinaryChecks
                    .Where(x => x.check_date != null && x.check_date <= oneMonthAgo)
                    .ToList();

                VeterinaryChecksOldDataGrid.ItemsSource = oldChecks;
            }
        }
        private void LoadComboBoxData()
        {
            using (var context = new ZooDBEntities())
            {
                // Загрузка животных
                var speciesList = context.Animals.ToList();
                AnimalIdComboBox.ItemsSource = speciesList;
                AnimalIdComboBox.DisplayMemberPath = "name";
                AnimalIdComboBox.SelectedValuePath = "id";
            }
        }

        // Выбор ветеринарного осмотра из DataGrid
        private void VeterinaryChecksOldDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VeterinaryChecksOldDataGrid.SelectedItem is VeterinaryChecks check)
            {
                AnimalIdComboBox.SelectedValue = check.animal_id;
                CheckDateDatePicker.SelectedDate = check.check_date;
                ResultTextBox.Text = check.result;
                selectedCheckId = check.id;
            }
        }
    }
}

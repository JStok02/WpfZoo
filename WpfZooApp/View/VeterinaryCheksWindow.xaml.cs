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
    /// Логика взаимодействия для VeterinaryCheksWindow.xaml
    /// </summary>
    public partial class VeterinaryCheksWindow : Window
    {
        private int selectedCheckId = -1;
        public VeterinaryCheksWindow()
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
                var checks = context.VeterinaryChecks.ToList();
                VeterinaryChecksDataGrid.ItemsSource = checks;
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

        // Добавление нового осмотра
        private void AddCheck_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalIdComboBox.SelectedItem == null || !CheckDateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните все поля с животным и временем перед добавлением.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new ZooDBEntities())
            {
                var check = new VeterinaryChecks
                {
                    animal_id = (int)AnimalIdComboBox.SelectedValue,
                    check_date = CheckDateDatePicker.SelectedDate.Value,
                    result = ResultTextBox.Text
                };

                try
                {
                    context.VeterinaryChecks.Add(check);
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearCheckInputFields();
            }
        }

        // Обновление информации о ветеринарном осмотре
        private void UpdateCheck_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCheckId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var check = context.VeterinaryChecks.FirstOrDefault(x => x.id == selectedCheckId);
                    if (check != null)
                    {
                        check.animal_id = (int)AnimalIdComboBox.SelectedValue;
                        check.check_date = CheckDateDatePicker.SelectedDate.Value;
                        check.result = ResultTextBox.Text;

                        try
                        {
                            context.SaveChanges();
                            LoadData();
                            ClearCheckInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Удаление ветеринарного осмотра
        private void DeleteCheck_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCheckId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var check = context.VeterinaryChecks.FirstOrDefault(x => x.id == selectedCheckId);
                    if (check != null)
                    {
                        try
                        {
                            context.VeterinaryChecks.Remove(check);
                            context.SaveChanges();
                            LoadData();
                            ClearCheckInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Выбор ветеринарного осмотра из DataGrid
        private void VeterinaryChecksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VeterinaryChecksDataGrid.SelectedItem is VeterinaryChecks check)
            {
                AnimalIdComboBox.SelectedValue = check.animal_id;
                CheckDateDatePicker.SelectedDate = check.check_date;
                ResultTextBox.Text = check.result;
                selectedCheckId = check.id;
            }
        }

        private void ClearCheckInputFields()
        {
            AnimalIdComboBox.SelectedIndex = -1;
            CheckDateDatePicker.SelectedDate = null;
            ResultTextBox.Clear();
            selectedCheckId = -1;
        }
    }
}

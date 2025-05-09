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
    /// Логика взаимодействия для FeedingsWindow.xaml
    /// </summary>
    public partial class FeedingsWindow : Window
    {
        private int selectedFeedingId = -1;

        public FeedingsWindow()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxData();
        }

        // Загрузка данных о кормлении
        private void LoadData()
        {
            using (var context = new ZooDBEntities())
            {
                var feedings = context.Feedings.ToList();
                FeedingsDataGrid.ItemsSource = feedings;
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

        // Добавление кормления
        private void AddFeeding_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalIdComboBox.SelectedItem == null || !FeedingTimeDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните поля с животным и временем перед добавлением.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new ZooDBEntities())
            {
                var feeding = new Feedings
                {
                    animal_id = (int)AnimalIdComboBox.SelectedValue,
                    feeding_time = FeedingTimeDatePicker.SelectedDate.Value,
                    notes = NotesTextBox.Text
                };

                try
                {
                    context.Feedings.Add(feeding);
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearFeedingInputFields();
            }
        }

        // Обновление информации о кормлении
        private void UpdateFeeding_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFeedingId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var feeding = context.Feedings.FirstOrDefault(x => x.id == selectedFeedingId);
                    if (feeding != null)
                    {
                        feeding.animal_id = (int)AnimalIdComboBox.SelectedValue;
                        feeding.feeding_time = FeedingTimeDatePicker.SelectedDate.Value;
                        feeding.notes = NotesTextBox.Text;

                        try
                        {
                            context.SaveChanges();
                            LoadData();
                            ClearFeedingInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Удаление кормления
        private void DeleteFeeding_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFeedingId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var feeding = context.Feedings.FirstOrDefault(x => x.id == selectedFeedingId);
                    if (feeding != null)
                    {
                        try
                        {
                            context.Feedings.Remove(feeding);
                            context.SaveChanges();
                            LoadData();
                            ClearFeedingInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Выбор кормления из DataGrid
        private void FeedingsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeedingsDataGrid.SelectedItem is Feedings feeding)
            {
                AnimalIdComboBox.SelectedValue = feeding.animal_id;
                FeedingTimeDatePicker.SelectedDate = feeding.feeding_time;
                NotesTextBox.Text = feeding.notes;
                selectedFeedingId = feeding.id;
            }
        }

        private void ClearFeedingInputFields()
        {
            AnimalIdComboBox.SelectedIndex = -1;
            FeedingTimeDatePicker.SelectedDate = null;
            NotesTextBox.Clear();
            selectedFeedingId = -1;
        }
    }
}

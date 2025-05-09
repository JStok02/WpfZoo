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
    /// Логика взаимодействия для EnclosuresWindow.xaml
    /// </summary>
    public partial class EnclosuresWindow : Window
    {
        private int selectedEnclosureId = -1;

        public EnclosuresWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ZooDBEntities())
            {
                var enclosures = context.Enclosures.ToList();
                EnclosuresDataGrid.ItemsSource = enclosures;
            }
        }

        // Добавление вольера
        private void AddEnclosure_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EnclosureNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед добавлением вольера.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new ZooDBEntities())
            {
                var enclosure = new Enclosures
                {
                    name = EnclosureNameTextBox.Text,
                    max_species = 0
                };

                try
                {
                    context.Enclosures.Add(enclosure);
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearEnclosureInputFields();
            }
        }

        // Обновление информации о вольере
        private void UpdateEnclosure_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEnclosureId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var enclosure = context.Enclosures.FirstOrDefault(x => x.id == selectedEnclosureId);
                    if (enclosure != null)
                    {
                        enclosure.name = EnclosureNameTextBox.Text;

                        try
                        {
                            context.SaveChanges();
                            LoadData();
                            ClearEnclosureInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Удаление вольера
        private void DeleteEnclosure_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEnclosureId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var enclosure = context.Enclosures.FirstOrDefault(x => x.id == selectedEnclosureId);
                    if (enclosure != null)
                    {
                        try
                        {
                            context.Enclosures.Remove(enclosure);
                            context.SaveChanges();
                            LoadData();
                            ClearEnclosureInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Выбор вольера из DataGrid
        private void EnclosuresDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnclosuresDataGrid.SelectedItem is Enclosures enclosure)
            {
                EnclosureNameTextBox.Text = enclosure.name;
                selectedEnclosureId = enclosure.id;
            }
        }

        // Очистка полей ввода
        private void ClearEnclosureInputFields()
        {
            EnclosureNameTextBox.Clear();
            selectedEnclosureId = -1;
        }

    }
}

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
    /// Логика взаимодействия для SpeciesWindow.xaml
    /// </summary>
    public partial class SpeciesWindow : Window
    {
        private int selectedSpeciesId = -1;

        public SpeciesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ZooDBEntities())
            {
                var species = context.Species.ToList();
                SpeciesDataGrid.ItemsSource = species;
            }
        }

        // Добавление вида
        private void AddSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SpeciesNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните поле перед добавлением вида.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new ZooDBEntities())
            {
                var species = new Species
                {
                    name = SpeciesNameTextBox.Text
                };

                try
                {
                    context.Species.Add(species);
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearSpeciesInputFields();
            }
        }

        // Обновление информации о виде
        private void UpdateSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSpeciesId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var species = context.Species.FirstOrDefault(x => x.id == selectedSpeciesId);
                    if (species != null)
                    {
                        species.name = SpeciesNameTextBox.Text;

                        try
                        {
                            context.SaveChanges();
                            LoadData();
                            ClearSpeciesInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Удаление вида
        private void DeleteSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSpeciesId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var species = context.Species.FirstOrDefault(x => x.id == selectedSpeciesId);
                    if (species != null)
                    {
                        try
                        {
                            context.Species.Remove(species);
                            context.SaveChanges();
                            LoadData();
                            ClearSpeciesInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Выбор вида из DataGrid
        private void SpeciesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SpeciesDataGrid.SelectedItem is Species species)
            {
                SpeciesNameTextBox.Text = species.name;
                selectedSpeciesId = species.id;
            }
        }

        // Очистка полей ввода
        private void ClearSpeciesInputFields()
        {
            SpeciesNameTextBox.Clear();
            selectedSpeciesId = -1;
        }
    }
}

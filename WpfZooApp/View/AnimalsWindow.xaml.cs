using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AnimalsWindow.xaml
    /// </summary>
    public partial class AnimalsWindow : Window
    {
        private int selectedAnimalId = -1;
        public AnimalsWindow()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ZooDBEntities())
            {
                var animals = context.Animals.ToList();
                AnimalsDataGrid.ItemsSource = animals;
            }
        }
        private void LoadComboBoxData()
        {
            using (var context = new ZooDBEntities())
            {
                // Загрузка видов животных
                var speciesList = context.Species.ToList();
                SpeciesIdComboBox.ItemsSource = speciesList;
                SpeciesIdComboBox.DisplayMemberPath = "name";
                SpeciesIdComboBox.SelectedValuePath = "id";

                // Загрузка вольеров
                var enclosuresList = context.Enclosures.ToList();
                EnclosureIdComboBox.ItemsSource = enclosuresList;
                EnclosureIdComboBox.DisplayMemberPath = "name";
                EnclosureIdComboBox.SelectedValuePath = "id";
            }
        }

        // Добавление животного
        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (SpeciesIdComboBox.SelectedItem == null || string.IsNullOrWhiteSpace(AnimalNameTextBox.Text) || EnclosureIdComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед добавлением животного.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new ZooDBEntities())
            {
                var animal = new Animals
                {
                    species_id = (int)SpeciesIdComboBox.SelectedValue,
                    name = AnimalNameTextBox.Text,
                    enclosure_id = (int)EnclosureIdComboBox.SelectedValue
                };

                try
                {
                    context.Animals.Add(animal);
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ClearAnimalInputFields();
            }
        }

        // Обновление информации о животном
        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimalId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var animal = context.Animals.FirstOrDefault(x => x.id == selectedAnimalId);
                    if (animal != null)
                    {
                        animal.species_id = (int)SpeciesIdComboBox.SelectedValue;
                        animal.name = AnimalNameTextBox.Text;
                        animal.enclosure_id = (int)EnclosureIdComboBox.SelectedValue;

                        try
                        {
                            context.SaveChanges();
                            LoadData();
                            ClearAnimalInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }


        // Удаление животного
        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAnimalId != -1)
            {
                using (var context = new ZooDBEntities())
                {
                    var animal = context.Animals.FirstOrDefault(x => x.id == selectedAnimalId);
                    if (animal != null)
                    {
                        try
                        {
                            context.Animals.Remove(animal);
                            context.SaveChanges();
                            LoadData();
                            ClearAnimalInputFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Выбор животного из DataGrid
        private void AnimalsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalsDataGrid.SelectedItem is Animals animal)
            {
                SpeciesIdComboBox.SelectedValue = animal.species_id;
                AnimalNameTextBox.Text = animal.name;
                EnclosureIdComboBox.SelectedValue = animal.enclosure_id;
                selectedAnimalId = animal.id;
            }
        }

        // Очистка полей ввода
        private void ClearAnimalInputFields()
        {
            AnimalNameTextBox.Clear();
            SpeciesIdComboBox.SelectedIndex = -1;
            EnclosureIdComboBox.SelectedIndex = -1;
            selectedAnimalId = -1;
        }
    }
}

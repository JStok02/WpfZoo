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

namespace WpfZooApp
{
    /// <summary>
    /// Логика взаимодействия для ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        private int selectedAnimalId = -1;

        public ContentWindow()
        {
            InitializeComponent();
            LoadData();
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

        //private void LoadComboBoxData()
        //{
        //    using (var context = new MasterFloorDBEntities())
        //    {
        //        RatesPartnerComboBox.Items.Clear();
        //        RatesPartnerComboBox.ItemsSource = context.Rates.ToList();
        //        RatesPartnerComboBox.DisplayMemberPath = "Name";
        //        RatesPartnerComboBox.SelectedValuePath = "id";
        //    }
        //}
        //private void StudentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (RatesPartnerComboBox.SelectedItem == null) return;

        //    Rates selectedRate = (Rates)RatesPartnerComboBox.SelectedItem;
        //    int selectedRateId = selectedRate.id;
        //}

        // Добавление животного
        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ZooDBEntities())
            {
                var animal = new Animals
                {
                    species_id = int.Parse(SpeciesIdTextBox.Text),
                    name = AnimalNameTextBox.Text,
                    enclosure_id = int.Parse(EnclosureIdTextBox.Text)
                };
                context.Animals.Add(animal);
                context.SaveChanges();
            }

            LoadData();
            ClearAnimalInputFields();
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
                        animal.species_id = int.Parse(SpeciesIdTextBox.Text);
                        animal.name = AnimalNameTextBox.Text;
                        animal.enclosure_id = int.Parse(EnclosureIdTextBox.Text);

                        context.SaveChanges();
                        LoadData();
                        ClearAnimalInputFields();
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
                        context.Animals.Remove(animal);
                        context.SaveChanges();
                        LoadData();
                        ClearAnimalInputFields();
                    }
                }
            }
        }

        // Выбор животного из DataGrid
        private void AnimalsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalsDataGrid.SelectedItem is Animals animal)
            {
                SpeciesIdTextBox.Text = animal.species_id.ToString();
                AnimalNameTextBox.Text = animal.name;
                EnclosureIdTextBox.Text = animal.enclosure_id.ToString();
                selectedAnimalId = animal.id;
            }
        }

        private void ClearAnimalInputFields()
        {
            SpeciesIdTextBox.Clear();
            AnimalNameTextBox.Clear();
            EnclosureIdTextBox.Clear();
            selectedAnimalId = -1;
        }
    }
}

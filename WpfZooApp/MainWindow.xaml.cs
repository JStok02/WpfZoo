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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfZooApp.View;

namespace WpfZooApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _role;

        public MainWindow(string role)
        {
            InitializeComponent();
            _role = role;
            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            // Показываем разные вкладки в зависимости от роли
            if (_role == "Vet")
            {
                VeterinaryMenuItem.Visibility = Visibility.Visible;
                FeedingsMenuItem.Visibility = Visibility.Collapsed;
                EnclosuresMenuItem.Visibility = Visibility.Collapsed;
                SpeciesMenuItem.Visibility = Visibility.Collapsed;
            }
            else if (_role == "Keeper")
            {
                VeterinaryMenuItem.Visibility = Visibility.Collapsed;
                FeedingsMenuItem.Visibility = Visibility.Visible;
                EnclosuresMenuItem.Visibility = Visibility.Collapsed;
                SpeciesMenuItem.Visibility = Visibility.Collapsed;
            }
            else if (_role == "Director")
            {
                VeterinaryMenuItem.Visibility = Visibility.Visible;
                FeedingsMenuItem.Visibility = Visibility.Visible;
                EnclosuresMenuItem.Visibility = Visibility.Visible;
                SpeciesMenuItem.Visibility = Visibility.Visible;
            }
        }

        private void Animals_Click(object sender, RoutedEventArgs e)
        {
            AnimalsWindow wAnimals = new AnimalsWindow();
            wAnimals.Show();
        }
        private void Feedings_Click(object sender, RoutedEventArgs e)
        {
            FeedingsWindow wFeedings = new FeedingsWindow();
            wFeedings.Show();
        }
        private void VeterinaryAll_Click(object sender, RoutedEventArgs e)
        {
            VeterinaryCheksWindow wVeterinary = new VeterinaryCheksWindow();
            wVeterinary.Show();
        }
        private void VeterinaryOld_Click(object sender, RoutedEventArgs e)
        {
            VeterinaryCheksOldWindow wVeterinaryOld = new VeterinaryCheksOldWindow();
            wVeterinaryOld.Show();
        }
        private void Enclosures_Click(object sender, RoutedEventArgs e)
        {
            EnclosuresWindow wEnclosures = new EnclosuresWindow();
            wEnclosures.Show();
        }
        private void Species_Click(object sender, RoutedEventArgs e)
        {
            SpeciesWindow wSpecies = new SpeciesWindow();
            wSpecies.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.AspNetCore.Identity;

namespace WpfZooApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            //пока что
            //MainWindow whileMain = new MainWindow("Director");
            //whileMain.Show();
            //this.Close();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new ZooDBEntities())
            {
                var username = NameLoginTextBox.Text;
                var password = PasswordLoginTextBox.Password;

                // Проверка, существует ли пользователь с таким именем
                var user = context.Users.FirstOrDefault(u => u.username == username);
                if (user == null)
                {
                    MessageBox.Show("Ошибка: такого пользователя не существует");
                    return;
                }

                // Проверка на заполненность полей
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Ошибка: все поля должны быть заполнены!");
                    return;
                }

                // Проверка правильности пароля
                var passwordHasher = new PasswordHasher<string>();
                var result = passwordHasher.VerifyHashedPassword(null, user.password, password);

                if (result == PasswordVerificationResult.Success)
                {
                    MessageBox.Show("Авторизация успешна!");

                    //Если пользователь найден и пароль правильный, открываем новое окно
                    string selectedRole = user.role.ToString();
                    MainWindow wMain = new MainWindow(selectedRole);
                    wMain.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: неверный пароль!");
                }
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ZooDBEntities())
            {
                var username = NameRegisterTextBox.Text;
                var password = PasswordRegisterTextBox.Password;
                string selectedRole = (RoleRegisterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Проверка на заполненность полей
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
                {
                    MessageBox.Show("Ошибка: все поля должны быть заполнены!");
                    return;
                }

                // Проверка на уникальность имени пользователя
                var existingUser = context.Users.FirstOrDefault(u => u.username == username);
                if (existingUser != null)
                {
                    MessageBox.Show("Ошибка: имя пользователя уже существует!");
                    return;
                }

                var passwordHasher = new PasswordHasher<string>();
                var hashedPassword = passwordHasher.HashPassword(null, password);

                // Создаем новый объект пользователя
                var user = new Users
                {
                    username = username,
                    password = hashedPassword,
                    role = selectedRole,
                };

                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\nОшибка добавления данных!\n" + ex.Message);
                }
                finally
                {
                    ClearUsersInputFields();
                }
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ClearUsersInputFields()
        {
            NameLoginTextBox.Clear();
            PasswordLoginTextBox.Clear();

            NameRegisterTextBox.Clear();
            PasswordRegisterTextBox.Clear();
        }
    }
}

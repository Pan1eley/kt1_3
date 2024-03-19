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
using System.Data.SqlClient;

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Registered.xaml
    /// </summary>
    public partial class Registered : Window
    {
        
        public Registered()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AirportEntities context = AirportEntities.GetContext();

                if (!context.UserExists(username, password))
                {
                    if (context.RegisterUser(username, password))
                    {
                        MessageBox.Show("Регистрация успешна!");
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации. Возможно, такой пользователь уже существует.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует. Пожалуйста, выберите другое имя пользователя.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }
    }
       
    
}



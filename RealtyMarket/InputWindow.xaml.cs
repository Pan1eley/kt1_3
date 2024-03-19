using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Packaging;
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
using System.Data;


namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class InputWindow : Window
    {

        public InputWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
            if (sender is TextBox textBox)
            {
                textBox.Foreground = SystemColors.ControlTextBrush;
                if (textBox.Text == textBox.Tag?.ToString())
                {
                    textBox.Text = "";
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = textBox.Tag?.ToString();
            }
        }
        

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AirportEntities context = AirportEntities.GetContext();

                if (context.UserExists(username, password))
                {
                    MessageBox.Show("Вход успешен!");

                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Неверные учетные данные. Пожалуйста, проверьте свой логин и пароль.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }

       public void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Registered registered = new Registered();
            registered.ShowDialog();
            
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.Show();
            this.Close();
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool isAdmin = false; //текущий пользователь не является администратором
            Reys reys = new Reys(isAdmin);
            reys.ShowDialog();
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {     
                MessageBox.Show("Для доступа к профилю необходимо войти в аккаунт.");          
        }

 
    }
}

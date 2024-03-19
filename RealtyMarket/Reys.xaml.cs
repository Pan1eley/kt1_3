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
using System.Data;

namespace RealtyMarket
{
    /// <summary>
    /// Логика взаимодействия для Reys.xaml
    /// </summary>
    public partial class Reys : Window
    {
        private bool isAdmin;
        public Reys(bool isAdmin)
        {

            InitializeComponent();
            this.isAdmin = isAdmin;          
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DGridReys.ItemsSource = AirportEntities.GetContext().Airport.ToList();
            if (isAdmin)
            {
                DGridReys.IsReadOnly = false; // Разрешаем редактирование для администратора
            }
            else
            {
                DGridReys.IsReadOnly = true; // Запрещаем редактирование для обычного пользователя
            }
        }
  


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isAdmin)
            {
                
                Save();
                MessageBox.Show("Данные успешно обновлены!");
            }
            else
            {
                MessageBox.Show("Недостаточно прав для сохранения изменений.");
            }
            
        }
        private void Save()
        {

            // Получение DataView для доступа к измененным данным в DataGrid
            DataView dataView = DGridReys.ItemsSource as DataView;
            if (dataView != null)
            {
                // Получение DataTable из DataView
                DataTable dataTable = dataView.Table;

                try
                {
                    // Обновление базы данных с помощью изменений в DataTable
                    // Ваш код для сохранения изменений в базу данных здесь
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
                }
            }
        }

       
    }
}

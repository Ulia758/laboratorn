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

namespace _11._01_Кол
{
    /// <summary>
    /// Логика взаимодействия для TableOplata.xaml
    /// </summary>
    public partial class TableOplata : Page
    {
        public TableOplata()
        {
            InitializeComponent();
        }

        private void OplataDG_Loaded(object sender, RoutedEventArgs e)
        {
            OplataDG.ItemsSource = Connect.context.Oplata.ToList();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddOplata((sender as Button).DataContext as Oplata));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddOplata(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = OplataDG.SelectedItems.Cast<Oplata>().ToList();
            if (MessageBox.Show($"Удалить{delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.Oplata.RemoveRange(delClients);
            try
            {
                Connect.context.SaveChanges();
                OplataDG.ItemsSource = Connect.context.Oplata.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

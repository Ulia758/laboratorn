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
    /// Логика взаимодействия для TablePoochreniya.xaml
    /// </summary>
    public partial class TablePoochreniya : Page
    {
        public TablePoochreniya()
        {
            InitializeComponent();
        }

        private void PoochreniyaDG_Loaded(object sender, RoutedEventArgs e)
        {
            PoochreniyaDG.ItemsSource = Connect.context.Poochreniya.ToList();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddPoochreniya((sender as Button).DataContext as Poochreniya));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddPoochreniya(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = PoochreniyaDG.SelectedItems.Cast<Poochreniya>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Oplata.Any(x => x.id_poochreniya == delClient.id_poochreniya))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Poochreniya.RemoveRange(delClients);
            }
            try
            {
                Connect.context.SaveChanges();
                PoochreniyaDG.ItemsSource = Connect.context.Poochreniya.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

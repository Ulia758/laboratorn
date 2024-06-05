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
    /// Логика взаимодействия для TableDolgnosti.xaml
    /// </summary>
    public partial class TableDolgnosti : Page
    {
        public TableDolgnosti()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void DolgnostiDG_Loaded(object sender, RoutedEventArgs e)
        {
            DolgnostiDG.ItemsSource = Connect.context.Dolgnosty.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddDolgnosti((sender as Button).DataContext as Dolgnosty));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddDolgnosti(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = DolgnostiDG.SelectedItems.Cast<Dolgnosty>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Uchet_inform_o_sotrudnikah.Any(x => x.id_dolgnost == delClient.id_dolgnost))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Dolgnosty.RemoveRange(delClients);
            }
            try
            {
                Connect.context.SaveChanges();
                DolgnostiDG.ItemsSource = Connect.context.Dolgnosty.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

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
    /// Логика взаимодействия для TableSotrudniki.xaml
    /// </summary>
    public partial class TableSotrudniki : Page
    {
        public TableSotrudniki()
        {
            InitializeComponent();
        }

        private void SotrudnikiDG_Loaded(object sender, RoutedEventArgs e)
        {
            SotrudnikiDG.ItemsSource = Connect.context.Sotrudniki.ToList();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddSotrudniki((sender as Button).DataContext as Sotrudniki));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddSotrudniki(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = SotrudnikiDG.SelectedItems.Cast<Sotrudniki>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Uchet_inform_o_sotrudnikah.Any(x => x.id_sotrudnika == delClient.id_sotrudnika))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Sotrudniki.RemoveRange(delClients);
            }

            try
            {
                Connect.context.SaveChanges();
                SotrudnikiDG.ItemsSource = Connect.context.Sotrudniki.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

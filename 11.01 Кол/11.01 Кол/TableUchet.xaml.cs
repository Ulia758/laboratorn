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
    /// Логика взаимодействия для TableUchet.xaml
    /// </summary>
    public partial class TableUchet : Page
    {
        public TableUchet()
        {
            InitializeComponent();
        }

        private void UchetDG_Loaded(object sender, RoutedEventArgs e)
        {
            UchetDG.ItemsSource = Connect.context.Uchet_inform_o_sotrudnikah.ToList();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddUchet(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = UchetDG.SelectedItems.Cast<Uchet_inform_o_sotrudnikah>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Oplata.Any(x => x.id_naznachenia == delClient.id_naznachenia))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.Uchet_inform_o_sotrudnikah.RemoveRange(delClients);
            try
            {
                Connect.context.SaveChanges();
                UchetDG.ItemsSource = Connect.context.Uchet_inform_o_sotrudnikah.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddUchet((sender as Button).DataContext as Uchet_inform_o_sotrudnikah));
        }
    }
}

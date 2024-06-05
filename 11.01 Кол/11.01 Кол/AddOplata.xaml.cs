using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddOplata.xaml
    /// </summary>
    public partial class AddOplata : Page
    {
        Oplata opl;
        bool checkNew;
        public AddOplata(Oplata c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Oplata();
                checkNew = true;
            }
            else checkNew = false;
            DataContext = opl = c;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Oplata oplata = Connect.context.Oplata.Add(opl);
            }
            try
            {
                Connect.context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}

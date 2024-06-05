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
    /// Логика взаимодействия для AddUchet.xaml
    /// </summary>
    public partial class AddUchet : Page
    {
        Uchet_inform_o_sotrudnikah uchet;
        bool checkNew;
        public AddUchet(Uchet_inform_o_sotrudnikah c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Uchet_inform_o_sotrudnikah();
                checkNew = true;
            }
            else checkNew = false;
            DataContext = uchet = c;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Uchet_inform_o_sotrudnikah uchet_inform_o_sotrudnikah = Connect.context.Uchet_inform_o_sotrudnikah.Add(uchet);
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

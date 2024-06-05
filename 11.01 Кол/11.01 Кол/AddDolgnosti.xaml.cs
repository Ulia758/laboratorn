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
    /// Логика взаимодействия для AddDolgnosti.xaml
    /// </summary>
    public partial class AddDolgnosti : Page       
    {
        Dolgnosty dolg;
        bool checkNew;
        public AddDolgnosti(Dolgnosty c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Dolgnosty();
                checkNew = true;
            }
            else checkNew = false;
            DataContext = dolg = c;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Dolgnosty dolgnosty = Connect.context.Dolgnosty.Add(dolg);
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

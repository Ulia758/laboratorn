using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Proc.xaml
    /// </summary>
    public partial class Proc : Page
    {
        public Proc()
        {
            InitializeComponent();
            //string carPetName = string.Empty;
            //Задание имени хранимой процедуры
            //using (SqlCommand cmd = new SqlCommand("GetPetName", this.connect))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    // Входной параметр.
            //    SqlParameter param = new SqlParameter();
            //    param.ParameterName = "@carID";
            //    param.SqlDbType = SqlDbType.Int;
            //    param.Value = carId;

            //    //По умолчанию параметры считаются входными, но все же для ясности:
            //    param.Direction = ParameterDirection.Input;
            //    cmd.Parameters.Add(param);

            //    // Выходной параметр.
            //    param = new SqlParameter();
            //    param.ParameterName = "@petName";
            //    param.SqlDbType = SqlDbType.Char;
            //    param.Size = 10;
            //    param.Direction = ParameterDirection.Output;
            //    cmd.Parameters.Add(param);

            //    // Выполнение хранимой процедуры.
            //    cmd.ExecuteNonQuery();
            //    // Возврат выходного параметра.
            //    carPetName = ((string)cmd.Parameters["@petName"].Value).Trim();
            //}
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            string Fam = Convert.ToString(sotr.SelectionBoxItem);
            var w = Connect.context.MaxOplata().Select(x =>
            new {
                
                Sotrudniki = x,
                MaxOplata = x.MaxOplata,
            }).Where(x => x.Sotrudniki.Familia == Fam).ToList(); 
            MaxOkl.ItemsSource = w;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
  
}


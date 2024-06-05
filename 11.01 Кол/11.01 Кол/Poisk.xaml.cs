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
    /// Логика взаимодействия для Poisk.xaml
    /// </summary>
    public partial class Poisk : Page
    {
        public Poisk()
        {
            InitializeComponent();
            var pwl = Connect.context.Oplata.Select(x =>
            new
            {
               Oplata = x,
               Uchet_inform_o_sotrudnikah = x.Uchet_inform_o_sotrudnikah,
               Dolgnosty = x.Uchet_inform_o_sotrudnikah.Dolgnosty,
               Sotrudniki = x.Uchet_inform_o_sotrudnikah.Sotrudniki,
               Poochreniya =x.Poochreniya,
            }).GroupBy(x => x.Sotrudniki.Familia).Select(x => new { Familia = x.Key, Max = x.Sum(g => g.Dolgnosty.oklad + g.Poochreniya.procent_ot_oklada * g.Dolgnosty.oklad / 100) }).OrderByDescending(x => x.Max).FirstOrDefault();
            label.Content = pwl;
        }

        private void Back7_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }


        private void Back5_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back4_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back6_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void p1_Loaded(object sender, RoutedEventArgs e)
        {
            var zapr1 = Connect.context.Uchet_inform_o_sotrudnikah.Select(x =>
            new
            {
                Dolgnosty = x.Dolgnosty,
                Sotrudniki = x.Sotrudniki,
            }).ToList();
            p1.ItemsSource = zapr1;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            string a = Convert.ToString(combobox1.SelectionBoxItem);
            var select = Connect.context.Uchet_inform_o_sotrudnikah.Where(x=>x.Dolgnosty.nazvanie == a).ToList();
            p2.ItemsSource = select;
        }

        private void p3_Loaded(object sender, RoutedEventArgs e)
        {
            var w = Connect.context.Dolgnosty.Where(x => x.obyazannosti==null).ToList();
            p3.ItemsSource = w;
        }

        private void p4_Loaded(object sender, RoutedEventArgs e)
        {
            p4.ItemsSource=Connect.context.Sotrudniki.ToList();
        }

        private void p7_Loaded(object sender, RoutedEventArgs e)
        {
            var w = Connect.context.Uchet_inform_o_sotrudnikah.Select(x=>
            new { 
                Uchet_inform_o_sotrudnikah = x,
                Dolgnosty = x.Dolgnosty,
            }).GroupBy(x => x.Dolgnosty.id_dolgnost).Select(g => new { id_dolgnost = g.Key, Count = g.Count() }).ToList();
            p7.ItemsSource = w;
        }

        private void Find2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(p554.SelectionBoxItem);
            var select = Connect.context.Oplata.Select(x =>
            new
            {
                Oplata=x,
                Uchet_inform_o_sotrudnikah=x.Uchet_inform_o_sotrudnikah,
                Sotrudniki = x.Uchet_inform_o_sotrudnikah.Sotrudniki,
                Poochreniya=x.Poochreniya,
                Dolgnosty=x.Uchet_inform_o_sotrudnikah.Dolgnosty,
            }).Where(x => x.Uchet_inform_o_sotrudnikah.id_sotrudnika == a).GroupBy(x => x.Sotrudniki.Familia).Select(x => new { Familia = x.Key, Max = x.Sum(g => g.Dolgnosty.oklad+g.Poochreniya.procent_ot_oklada*g.Dolgnosty.oklad/100) }).OrderByDescending(x => x.Max).ToList();
            p5.ItemsSource = select;
        }
    }
}

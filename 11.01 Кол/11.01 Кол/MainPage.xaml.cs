using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Paragraph = iTextSharp.text.Paragraph;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace _11._01_Кол
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Dolg_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new TableDolgnosti());
        }

        private void Poochr_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new TablePoochreniya());
        }

        private void Sotr_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new TableSotrudniki());
        }

        private void Oplata_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new TableOplata());
        }

        private void Uchet_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new TableUchet());
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Poisk());
        }

        private void Proc_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Proc());
        }

        private void Otch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Oth1_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workbook = app.Workbooks.Add();
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Ведомость начисления зарплаты";
            sheet.Cells[1, 1] = "Табельный номер";
            sheet.Cells[1, 2] = "Фамилия";
            sheet.Cells[1, 3] = "Имя";
            sheet.Cells[1, 4] = "Отчество";
            sheet.Cells[1, 5] = "Оклад";
            sheet.Cells[1, 6] = "Сумма доплаты";
            sheet.Cells[1, 7] = "Всего начислено";
            var currentRow = 2;
            var s = Connect.context.Oplata.Select(x =>
            new
            {
                Oplata = x,
                Uchet_inform_o_sotrudnikah=x.Uchet_inform_o_sotrudnikah,
                Sotrudniki = x.Uchet_inform_o_sotrudnikah.Sotrudniki,
                Dolgnosty = x.Uchet_inform_o_sotrudnikah.Dolgnosty,
                Poochreniya = x.Poochreniya,
                id_sotrudnika = x.Uchet_inform_o_sotrudnikah.Sotrudniki.id_sotrudnika,
                Familia = x.Uchet_inform_o_sotrudnikah.Sotrudniki.Familia,
                Name = x.Uchet_inform_o_sotrudnikah.Sotrudniki.Name,
                Otchestvo = x.Uchet_inform_o_sotrudnikah.Sotrudniki.Otchestvo,
                Oklad = x.Uchet_inform_o_sotrudnikah.Dolgnosty.oklad,
                Sumdop = x.Poochreniya.procent_ot_oklada * x.Uchet_inform_o_sotrudnikah.Dolgnosty.oklad / 100,
                Summ = x.Uchet_inform_o_sotrudnikah.Dolgnosty.oklad + x.Poochreniya.procent_ot_oklada * x.Uchet_inform_o_sotrudnikah.Dolgnosty.oklad / 100,
            }).ToList();
            foreach (var item in s)
            {
                sheet.Cells[currentRow, 1] = item.Sotrudniki.id_sotrudnika;
                sheet.Cells[currentRow, 2] = item.Sotrudniki.Familia;
                sheet.Cells[currentRow, 3] = item.Sotrudniki.Name;
                sheet.Cells[currentRow, 4] = item.Sotrudniki.Otchestvo;
                sheet.Cells[currentRow, 5] = item.Dolgnosty.oklad;
                sheet.Cells[currentRow, 6] = item.Sumdop;
                sheet.Cells[currentRow, 7] = item.Summ;
                currentRow++;
            }
            sheet.Columns[1].ColumnWidth = 10;
            sheet.Columns[2].ColumnWidth = 20;
            sheet.Columns[3].ColumnWidth = 20;
            sheet.Columns[4].ColumnWidth = 20;
            sheet.Columns[5].ColumnWidth = 20;
            sheet.Columns[6].ColumnWidth = 20;
            sheet.Columns[7].ColumnWidth = 20;
            sheet.Cells[currentRow + 1, 5] = "Итого начислено за месяц: ";
            sheet.Cells[currentRow + 1, 7] = "=SUM(G2:G" + (currentRow - 1) + ")";
        }

        private void Oth2_Click(object sender, RoutedEventArgs e)
        {
            //Document doc = new Document();
            //string fileName = "Ведомость начисления заработной платы за 2 месяц.pdf";
            //PdfWriter(doc, new FileStream(fileName, FileMode.Create));
            //doc.Open();
            //BaseFont basefont = BaseFont.CreateFont("C:\\Колосова\\ArialRegular.ttf", "CP1251", BaseFont.EMBEDDED);
            //Encoding encoding = Encoding.GetEncoding("UTF-8");
            //iTextSharp.text.Font font = new iTextSharp.text.Font(basefont, 12, iTextSharp.text.Font.NORMAL);
            //iTextSharp.text.Font fonttitle = new iTextSharp.text.Font(basefont, 18, iTextSharp.text.Font.NORMAL);
            //Paragraph title = new Paragraph("Ведомость начисления заработной платы за второй месяц", fonttitle);
            //doc.Add(title);
            //doc.Add(new Paragraph("\n"));
            //PdfPTable table = new PdfPTable(7);
            //table.WidthPercentage = 100;
            //table.AddCell(new Phrase("Табельный номер", font));
            //table.AddCell(new Phrase("Фамилия", font));
            //table.AddCell(new Phrase("Имя", font));
            //table.AddCell(new Phrase("Отчество", font));
            //table.AddCell(new Phrase("Оклад", font));
            //table.AddCell(new Phrase("Сумма доплаты", font));
            //table.AddCell(new Phrase("Всего начислено", font));
            //var s = Connect.context.Uchetnaya.Select(x =>
            //new
            //{
            //    Uchetnaya = x,
            //    Spravochnaya = x.Spravochnaya,
            //    Tabelnyi_nomer = x.Tabelnyi_nomer,
            //    Familia = x.Spravochnaya.Familia,
            //    Name = x.Spravochnaya.Name,
            //    Otchestvo = x.Spravochnaya.Otchestvo,
            //    Oklad = x.Oklad,
            //    Sumdop = x.Procent_oplaty * x.Oklad / 100,
            //    Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            //}).Where(x => x.Uchetnaya.Month == 2).ToList();
            //foreach (var user in s)
            //{
            //    table.AddCell(new Phrase($"{user.Tabelnyi_nomer}", font));
            //    table.AddCell(new Phrase($"{user.Familia}", font));
            //    table.AddCell(new Phrase($"{user.Name}", font));
            //    table.AddCell(new Phrase($"{user.Otchestvo}", font));
            //    table.AddCell(new Phrase($"{user.Oklad}", font));
            //    table.AddCell(new Phrase($"{user.Sumdop}"));
            //    table.AddCell(new Phrase($"{user.Summ}", font));
            //}
            //doc.Add(table);
            //doc.Add(new Paragraph("\n"));
            //doc.Add(new Paragraph("Итог: " + s.Sum(x => x.Summ), font));
            //doc.Close();
            //MessageBox.Show("Данные записаны в файл. Для просмотра перейдите в папку D:\\Моё\\11.01 и 01.01\\Laboratornie\\Laboratornie\\bin\\Debug", "Успешно");
        }

        private void Oth3_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workbook = app.Workbooks.Add();
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Группировка по дате";
            sheet.Cells[1, 1] = "Дата";
            sheet.Cells[1, 2] = "Количество человек";
            sheet.Cells[1, 3] = "Фамилии";
            var currentRow = 2;
            var s = Connect.context.Uchet_inform_o_sotrudnikah.GroupBy(x => x.data_priema).Select(g => new { Month = g.Key, Count = g.Count() }).ToList();
            foreach (var item in s)
            {
                sheet.Cells[currentRow, 1] = item.Month;
                sheet.Cells[currentRow, 2] = item.Count;
                currentRow++;
            }
            sheet.Columns[1].ColumnWidth = 10;
        }
    }
}

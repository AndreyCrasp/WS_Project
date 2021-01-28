using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WS_Project
{
    /// <summary>
    /// Логика взаимодействия для StatVUPage.xaml
    /// </summary>
    public partial class StatVUPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public StatVUPage()
        {

            InitializeComponent();
            CMBLoad();


        }

        private void CMBLoad()
        {
            int[] arrYears = new int[30];
            arrYears[0] = 2018;
            for (int i = 1; i < 30; i++)
            {
                arrYears[i] = arrYears[i - 1] + 1;
            }
            CalendarYears.ItemsSource = arrYears;
            CalendarYears.SelectedIndex = 0;
            CalendarYears2.ItemsSource = arrYears;
            CalendarYears2.SelectedIndex = 0;
            CalendarMM.ItemsSource = arrYears;
            CalendarMM.SelectedIndex = 0;
            CalendarMM1.ItemsSource = arrYears;
            CalendarMM1.SelectedIndex = 0;
        }

        private void RbtnYear_Checked(object sender, RoutedEventArgs e)
        {
            CalendarDD.Visibility = Visibility.Collapsed;
            CalendarMM.Visibility = Visibility.Collapsed;
            CalendarYears.Visibility = Visibility.Visible;
            CalendarYears2.Visibility = Visibility.Visible;
            CalendarMM1.Visibility = Visibility.Collapsed;

        }

        private void RbtnMM_Checked(object sender, RoutedEventArgs e)
        {
            CalendarMM1.Visibility = Visibility.Collapsed;

            CalendarDD.Visibility = Visibility.Collapsed;
            CalendarMM.Visibility = Visibility.Visible;
            CalendarMM1.Visibility = Visibility.Collapsed;
            CalendarYears.Visibility = Visibility.Collapsed;
            CalendarYears2.Visibility = Visibility.Collapsed;
        }

        private void RbtnDD_Checked(object sender, RoutedEventArgs e)
        {
            CalendarDD.Visibility = Visibility.Visible;
            CalendarMM1.Visibility = Visibility.Visible;
            CalendarMM.Visibility = Visibility.Collapsed;
            CalendarYears.Visibility = Visibility.Collapsed;
            CalendarYears2.Visibility = Visibility.Collapsed;
        }

        private void CalendarYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Дата");
            table.Columns.Add("Изъято");
            try {
                List<Licensies> lic = context.Licensies.Where(x => x.Status_id == 2).ToList();
                List<HistiesLicensies> his = new List<HistiesLicensies>();
                foreach (var p in lic)
                {
                    if (context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Count() != 0)
                        his.Add(context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Last());
                }
                for (int i = (int)CalendarYears.SelectedItem; i < (int)CalendarYears2.SelectedItem; i++)
                {

                    if (lic.Count() != 0 && his.Count() != 0 && context.HistiesLicensies.ToList().Last() != null)
                    {
                        table.Rows.Add(i, context.HistiesLicensies.Where
                            (x => x.Status_id == 2 && x
                            .date.Value.Year == new DateTime(i, 1, 1).Year).Count());
                    }

                }
                datagrid.ItemsSource = table.DefaultView;
            }
            catch (Exception ex) { }

        }

        private void CalendarMM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Дата");
            table.Columns.Add("Изъято");
            try
            {
                List<Licensies> lic = context.Licensies.Where(x => x.Status_id == 2).ToList();
                List<HistiesLicensies> his = new List<HistiesLicensies>();
                foreach (var p in lic)
                {
                    if (context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Count() != 0)
                        his.Add(context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Last());
                }
                for (int i = 1; i <= 12; i++)
                {

                    if (lic.Count() != 0 && his.Count() != 0)
                    {
                        table.Rows.Add(new DateTime((int)CalendarMM.SelectedItem, i, 1).Date.ToString("MM.yyyy"), context.HistiesLicensies.Where
                            (x => x.Status_id == 2 &&
                           x.date.Value.Year == new DateTime((int)CalendarMM.SelectedItem, i, 1).Year
                            &&
                            x.date.Value.Month == new DateTime((int)CalendarMM.SelectedItem, i, 1).Month
                            ).Count());
                    }
                    else table.Rows.Add(i, 0);

                }
                datagrid.ItemsSource = table.DefaultView;
            }
            catch (Exception ex) { }
        }

        private void CalendarDD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Дата");
            table.Columns.Add("Изъято");
            try { 
            List<Licensies> lic = context.Licensies.Where(x => x.Status_id == 2).ToList();
            List<HistiesLicensies> his = new List<HistiesLicensies>();
            foreach (var p in lic)
            {
                if (context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Count() != 0)
                    his.Add(context.HistiesLicensies.Where(x => x.LicensiesId == p.id).ToList().Last());
            }
            for (int i = 1; i <= 30; i++)
            {

                if (lic.Count() != 0 && his.Count() != 0)
                {
                    table.Rows.Add(new DateTime((int)CalendarMM1.SelectedItem, (int)CalendarDD.SelectedIndex + 1, i).Date.ToString("dd.MM.yyyy"), his.Where
                        (x => x.date.Value.Year == new DateTime((int)CalendarMM1.SelectedItem, (int)CalendarDD.SelectedIndex + 1, i).Year
                         && x.date.Value.Month == new DateTime((int)CalendarMM1.SelectedItem, (int)CalendarDD.SelectedIndex + 1, i).Month
                       && x.date.Value.Day == new DateTime((int)CalendarMM1.SelectedItem, (int)CalendarDD.SelectedIndex+1, i).Day 
                        ).ToList().Count());
                }
                else table.Rows.Add(i, 0);

            }
            datagrid.ItemsSource = table.DefaultView;
        }  catch (Exception ex) {  }
}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = "newcsv";
            if (saveFileDialog.ShowDialog() == true)
            {
                datagrid.SelectAllCells();
                datagrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, datagrid);
                string res = Clipboard.GetData(DataFormats.CommaSeparatedValue).ToString();
                datagrid.UnselectAllCells();
                File.WriteAllText(saveFileDialog.FileName, res);
            }
        }
    }
}

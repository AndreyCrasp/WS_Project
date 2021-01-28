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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace WS_Project
{
    /// <summary>
    /// Логика взаимодействия для chartPage.xaml
    /// </summary>
    public partial class chartPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public chartPage()
        {

            int[] arr = new int[30];
            arr[0] = 2018;
            InitializeComponent();
            for (int i = 1; i < 30; i++)
            {
                arr[i] = arr[i-1] + 1;
            }
            cmbYear.ItemsSource = arr;
            cmbYear.SelectedIndex = 0;
           
           
        }

        private void cmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chart.Series[0].Points.Clear();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MM");
            dataTable.Columns.Add("VU");
            
            for (int i = 1; i <= 12; i++)
            {
                dataTable.Rows.Add(i, context.Licensies.ToList()
                .Where(x => x.Licence_date.Value.Date.ToString("MM.yyyy") ==
                new DateTime((int)cmbYear.SelectedValue, i, 1).Date.ToString("MM.yyyy"))
                .Count());

                
                chart.Series[0].Points.AddXY(i, context.Licensies.ToList()
                .Where(x => x.Licence_date.Value.Date.ToString("MM.yyyy") ==
                new DateTime((int)cmbYear.SelectedValue, i, 1).Date.ToString("MM.yyyy"))
                .Count());
            }
            datagrid.ItemsSource = dataTable.DefaultView;

           
        }
    }
}

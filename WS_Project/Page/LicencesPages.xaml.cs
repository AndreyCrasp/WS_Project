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

namespace WS_Project
{
    /// <summary>
    /// Логика взаимодействия для LicencesPages.xaml
    /// </summary>
    public partial class LicencesPages : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public LicencesPages()
        {
            InitializeComponent();
            LicensiesDataGrid.ItemsSource = context.Licensies.ToList();
            cmbStatus.ItemsSource = context.Status.ToList();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try 
            {
                Manager.MainFrame.Navigate(new AddLicensies());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LicensiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Licensies lic = LicensiesDataGrid.SelectedItem as Licensies;
            if(lic !=null)
            HistoryDataGrid.ItemsSource = context.HistiesLicensies.Where(x => x.LicensiesId == lic.id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context = new GIBDDEntities();
            LicensiesDataGrid.ItemsSource = context.Licensies.ToList();
            LicensiesDataGrid.Items.Refresh();
           


        }
        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (GIBDDEntities _context = new GIBDDEntities())
            {
                var lic = _context.Licensies.Find((LicensiesDataGrid.SelectedItem as Licensies).id);
                HistiesLicensies history = new HistiesLicensies();
                lic.Status_id = (cmbStatus.SelectedItem as Status).id;

                history.LicensiesId = lic.id;
                history.Status_id = Convert.ToInt32(lic.Status_id);
                history.date = DateTime.Now.Date;
                history.Comment = tbComment.Text;
                _context.HistiesLicensies.Add(history);
                _context.SaveChanges();
                
                context = new GIBDDEntities();
                    LicensiesDataGrid.ItemsSource = context.Licensies.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (LicensiesDataGrid.SelectedItem != null)
                Manager.MainFrame.Navigate(new CardLicencePage(LicensiesDataGrid.SelectedItem as Licensies));
            else MessageBox.Show("Выберите ВУ!");
        }
    }
}

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

namespace WS_Project
{
    /// <summary>
    /// Логика взаимодействия для AddLicensies.xaml
    /// </summary>
    public partial class AddLicensies : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        
        public AddLicensies()
        {
            InitializeComponent();
            cmbDriver.ItemsSource = context.Drivers.ToList();
            cmbStatus.ItemsSource = context.Status.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var lic = new Licensies();
                lic.id = context.Licensies.ToList().Last().id + 1;
                lic.Licence_date = dateLicensies.SelectedDate.Value.Date;
                lic.Expire_date = dateEx.SelectedDate.Value.Date;
                lic.Categories = tbCat.Text;
                lic.Licenceseries = Convert.ToInt32(tbSeries.Text);
                lic.Licence_number = Convert.ToInt32(tbNumber.Text);
                lic.Driver_ID = (cmbDriver.SelectedItem as Drivers).id;
                lic.Status_id = (cmbStatus.SelectedItem as Status).id;
                context.Licensies.Add(lic);

                HistiesLicensies history = new HistiesLicensies();
               
                history.LicensiesId = lic.id;
                history.Status_id = Convert.ToInt32(lic.Status_id);
                history.Comment = "Выдано";
                history.date = DateTime.Now.Date;
                context.HistiesLicensies.Add(history);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddDriverPage());
        }

        private void cmbDriver_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            
        }

        private void cmbDriver_PreviewTextInput(object sender, KeyEventArgs e)
        {
            cmbDriver.IsDropDownOpen = true;
            cmbDriver.ItemsSource = context.Drivers.Where(x => x.MiddleName.Contains(cmbDriver.Text)).ToList();
        }

        private void cmbDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbDriver.IsEditable = false;
        }

      

        private void cmbDriver_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            cmbDriver.SelectedItem = null;
            cmbDriver.IsEditable = true;
        }
    }
}

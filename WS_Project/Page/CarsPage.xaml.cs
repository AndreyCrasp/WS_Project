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
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public CarsPage()
        {
            InitializeComponent();
            lbCar.ItemsSource = context.Car.ToList();
            cmbColor.ItemsSource = context.CarsColor.ToList();
            cmbDriver.ItemsSource = context.Drivers.ToList();
            cmbTypeEngine.ItemsSource = context.engine_types.ToList();
            cmbTypeOfDrive.ItemsSource = context.TypeOfDrive.ToList();
            
        }

        private void lbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = lbCar.SelectedItem as Car;
            if(car!=null)
            datagridHistories.ItemsSource = context.HistoriesCars.Where(x => x.CarID ==car.id ).ToList();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            context = new GIBDDEntities();
            lbCar.ItemsSource = context.Car.ToList();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCarPage());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbDriver.SelectedItem == null) { MessageBox.Show("Заполнены не все поля"); return; }
                Car car = lbCar.SelectedItem as Car;
                var id = (lbCar.SelectedItem as Car).Driver_ID;
                HistoriesCars histories = new HistoriesCars();
                histories.DriverID = id;
                car.Driver_ID = (cmbDriver.SelectedItem as Drivers).id;
               
               
                histories.date = DateTime.Now.Date;
                
                histories.Comment = tbComment.Text;
                histories.CarID = car.id;
                context.HistoriesCars.Add(histories);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

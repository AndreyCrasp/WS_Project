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
    /// Логика взаимодействия для AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public AddCarPage()
        {
            InitializeComponent();
            cmbColor.ItemsSource = context.CarsColor.ToList();
            cmbDriver.ItemsSource = context.Drivers.ToList();
            cmbTypeEngine.ItemsSource = context.engine_types.ToList();
            cmbTypeOfDrive.ItemsSource = context.TypeOfDrive.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbVIN.Text)
                    || String.IsNullOrWhiteSpace(tbManufactured.Text)
                    || String.IsNullOrWhiteSpace(tbModel.Text)
                    || String.IsNullOrWhiteSpace(tbTypeTS.Text)
                    || String.IsNullOrWhiteSpace(tbCat.Text)
                    || String.IsNullOrWhiteSpace(Year.Text)
                    || String.IsNullOrWhiteSpace(tbWeight.Text)
                    || cmbTypeEngine.SelectedItem == null
                    || cmbTypeOfDrive.SelectedItem == null) { MessageBox.Show("Заполнены не все поля"); return; }
                Car car = new Car();
                car.VIN = tbVIN.Text;
                car.Manufacturer = tbManufactured.Text;
                car.Model = tbModel.Text;
                car.TypeCar = tbTypeTS.Text;
                car.Category = tbCat.Text;
                car.Year = int.Parse(Year.Text);
                car.EngineNumber = int.Parse(tbEngineNumber.Text);
                car.EngineModel = tbEngineModel.Text;
                car.Year_Engine = int.Parse(tbEngineYear.Text);
                car.Color = (cmbColor.SelectedItem as CarsColor).Color_ID;
                car.EnginePower = int.Parse(tbPower.Text);
                car.EnginePowerHorse = int.Parse(tbHourse.Text);
                car.MaxKg = int.Parse(tbMaxKg.Text);
                car.Weight = int.Parse(tbWeight.Text);
                car.Engine_Type = (cmbTypeEngine.SelectedItem as engine_types).id;
                car.type_of_drive = (cmbTypeOfDrive.SelectedItem as TypeOfDrive).id;
                car.Comment = tbComment.Text;
                car.Driver_ID = (cmbDriver.SelectedItem as Drivers).id;
                context.Car.Add(car);
                HistoriesCars histories = new HistoriesCars();
                histories.date = DateTime.Now.Date;
                histories.DriverID = car.Driver_ID;
                histories.Comment = "Первый владелец";
                histories.CarID = car.id;
                context.HistoriesCars.Add(histories);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}

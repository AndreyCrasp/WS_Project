using Microsoft.Win32;
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
    /// Логика взаимодействия для DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        byte[] arrphoto;
        public DriversPage()
        {
            InitializeComponent();
            lbDrivers.ItemsSource = context.Drivers.ToList();

            DataContext = context.Drivers;
            arrphoto = new byte[0];
        }

        private void lbDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbDrivers.SelectedItem != null)
            {
                Drivers driver = lbDrivers.SelectedItem as Drivers;
                tbFirstName.Text = driver.FirstName;
                tbGUID.Text = driver.id.ToString();
                tbMiddleName.Text = driver.MiddleName;
                tbLastNAme.Text = driver.LastNAme;
                tbpassport_serial.Text = driver.passport_serial.ToString();
                tbpassport_number.Text = driver.passport_number.ToString();
                tbaddress.Text = driver.address;
                tbaddress_life.Text = driver.address_life;
                tbcompany.Text = driver.company;
                tbjobname.Text = driver.jobname;
                tbphone.Text = driver.phone.ToString();
                tbemail.Text = driver.email;
                tbdescription.Text = driver.description;
                MemoryStream memoryStream = new MemoryStream(driver.photoimg);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = memoryStream;
                img.EndInit();
                Photo.Source = img;



            }
        }
        /// <summary>
        /// Кнопка сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Drivers driver = lbDrivers.SelectedItem as Drivers;
                driver.FirstName = tbFirstName.Text;

                driver.MiddleName = tbMiddleName.Text;
                driver.LastNAme = tbLastNAme.Text;
                driver.passport_serial = double.Parse(tbpassport_serial.Text);
                driver.passport_number = double.Parse(tbpassport_number.Text);
                driver.address = tbaddress.Text;
                driver.address_life = tbaddress_life.Text;
                driver.company = tbcompany.Text;
                driver.jobname = tbjobname.Text;
                driver.phone = Convert.ToDouble(tbphone.Text);
                driver.email = tbemail.Text;
                driver.description = tbdescription.Text;
                if (arrphoto.Length > 0)
                {
                    driver.photoimg = arrphoto;
                    // File.WriteAllBytes("C:\\Users\\newcr\\Desktop\\WS_Project\\WS_Project\\bin\\Debug\\photo\\" + driver.photo, arrphoto);
                }
                context.SaveChanges();
                lbDrivers.ItemsSource = context.Drivers.ToList();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "IMG|*.jpg;*png";
            if (openFileDialog.ShowDialog() == true)
            {
                string fail = "";
                BitmapImage img = new BitmapImage();
                MemoryStream stream = new MemoryStream((File.ReadAllBytes(openFileDialog.FileName)));
                img.BeginInit();
                img.StreamSource = stream;
                img.EndInit();

                double px = Convert.ToDouble(img.Width) / Convert.ToDouble(img.Height);
                FileInfo imginfo = new FileInfo(openFileDialog.FileName);
                if (imginfo.Length >= 2 * 1024 * 1024) { fail += "Размер изображения больше 2мб\n"; }
                if (px != 3 / 4.0) { fail += "Соотношение стороне не 3/4\n"; }
                if (img.Width >= img.Height) { fail += "Изображение не веритикальное\n"; }
                if (fail.Length > 0) { MessageBox.Show(fail); return; }
                else
                {

                    arrphoto = File.ReadAllBytes(openFileDialog.FileName);
                    Photo.Source = img;
                }
            }
        }

        public void UpdateDrivers()
        {
            lbDrivers.ItemsSource = context.Drivers.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddDriverPage());
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            //lbDrivers.Items.Refresh();
        }
    }
}

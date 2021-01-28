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
    /// Логика взаимодействия для AddDriverPage.xaml
    /// </summary>
    public partial class AddDriverPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        public AddDriverPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Drivers driver = new Drivers();
            try
            {
                
                driver.FirstName = tbFirstName.Text;
                driver.id = context.Drivers.ToList().Last().id+1;
                driver.MiddleName = tbMiddleName.Text;
                driver.LastNAme = tbLastNAme.Text;
                driver.passport_serial = double.Parse(tbpassport_serial.Text);
                driver.passport_number = double.Parse(tbpassport_number.Text);
                driver.address = tbaddress.Text;
                driver.address_life = tbaddress_life.Text;
                driver.company = tbcompany.Text;
                driver.jobname = tbjobname.Text;
                driver.phone = double.Parse(tbphone.Text);
                driver.email = tbemail.Text;
                driver.description = tbdescription.Text;
                driver.photoimg = arrphoto;
                
                context.Drivers.Add(driver);
                context.SaveChanges();
                
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        byte[] arrphoto;
        private void Photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "IMG|*.jpg;*png";
            if (openFileDialog.ShowDialog() == true)
            {
                string fail = "";
                BitmapImage img = new BitmapImage(new Uri(openFileDialog.FileName));
                double px = Convert.ToDouble(img.Width) / Convert.ToDouble(img.Height);
                FileInfo imginfo = new FileInfo(openFileDialog.FileName);
               // if (imginfo.Length != 2 * 1024 * 1024) { fail += "Размер изображения больше 2мб\n"; }
               // if (px != 3 / 4.0) { fail += "Соотношение стороне не 3/4\n"; }
               // if (img.Width >= img.Height) { fail += "Изображение не веритикальное\n"; }
               // if (fail.Length > 0) { MessageBox.Show(fail); return; }
               // else
                {
                    Photo.Source = img;
                    arrphoto = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }
    }
}

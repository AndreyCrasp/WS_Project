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
    /// Логика взаимодействия для CardLicencePage.xaml
    /// </summary>
    public partial class CardLicencePage : Page
    {
        byte[] arr;
        public CardLicencePage(Licensies lic)
        {
            InitializeComponent();
            Firstname.Text = lic.Drivers.FirstName;
            MiddleName.Text = lic.Drivers.MiddleName;
            LastName.Text = lic.Drivers.LastNAme;
            adress.Text = lic.Drivers.address;
            date.Text = lic.Licence_date.Value.ToString("dd.MM.yyyy");
            exdate.Text = lic.Expire_date.Value.ToString("dd.MM.yyyy");
            series.Text = lic.Licenceseries.ToString();
            number.Text = lic.Licence_number.ToString();
            Cat.Text = lic.Categories;
            MemoryStream memoryStream = new MemoryStream(lic.Drivers.photoimg);
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = memoryStream;
            bmp.EndInit();
           
            img.Source = bmp;
            
            
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            RenderTargetBitmap bmp1 = new RenderTargetBitmap((int)Canvas.Width, (int)Canvas.Height, 96, 96, PixelFormats.Pbgra32);
            bmp1.Render(Canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp1));
            //FileStream fs = new FileStream("C:\\Users\\newcr\\Desktop\\neww.png", FileMode.Create);
            MemoryStream memoryStream = new MemoryStream();

            encoder.Save(memoryStream);
            arr = memoryStream.ToArray();
            
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.DefaultExt = "jpeg";
                fileDialog.FileName = "new";
                if (fileDialog.ShowDialog() == true)
                {
                    File.WriteAllBytes(fileDialog.FileName, arr);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

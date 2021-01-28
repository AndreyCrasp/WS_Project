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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Manager.Header = Title;
        }

        private void btnDrivers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DriversPage());
        }

        private void btnLicences_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LicencesPages());
        }

        private void btnLicences_Copy_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new chartPage());
        }

        private void btnStatVU_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StatVUPage());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsPage());
        }
    }
}

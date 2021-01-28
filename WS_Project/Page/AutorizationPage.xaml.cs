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
using System.Windows.Threading;

namespace WS_Project
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        GIBDDEntities context = new GIBDDEntities();
        DispatcherTimer timer;
        public AutorizationPage()
        {
            
            InitializeComponent();
            Title = "Авторизация";
            Manager.Header = Title;
            timer = new DispatcherTimer();

            timer.Tick += Timer_Tick; ;
            
            timer.Interval = new TimeSpan(0, 0, 60);
            if (DateTime.Now - DateTime.Parse(context.users.First().datetime) < new TimeSpan(0, 0, 60)) { 

                timer.Start();
                btlog.IsEnabled = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            count = 0;
            btlog.IsEnabled = true;
            timer.Stop();
        }

        int count = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (context.users.First().login == login.Text && context.users.First().password == pass.Text)
            {
                Manager.MainFrame.Navigate(new MainPage());
                count = 0;
            }
            else { count++; }
            if(count == 3)
            {
                
                btlog.IsEnabled = false;
                timer.Start();
                context.users.First().datetime = DateTime.Now.ToString();
                context.SaveChanges();
            }

        }

       
    }
}

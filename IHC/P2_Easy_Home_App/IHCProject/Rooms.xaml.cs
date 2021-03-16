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
using System.Windows.Shapes;

namespace IHCProject
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        
        public Rooms()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitialPage initial = new InitialPage();

            initial.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statistics = new StatisticsWindow();

            statistics.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /* nothing */
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Rooms_living living = new Rooms_living();

            living.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Rooms_add adding = new Rooms_add(this);
            adding.Show();
            this.Hide();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Notifications noti = new Notifications(new InitialPage());

            noti.Show();
            this.Close(); 
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings();

            set.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Notifications not = new Notifications(new InitialPage());
            not.Show();
            this.Hide();
        }

        public void addSceneFinal(String title, String img)
        {
            if (add2.Visibility.Equals(Visibility.Visible))
            {
                add2.Visibility = Visibility.Hidden;
                label2.Content = title;
                img2.Source = new BitmapImage(new Uri("Resources/" + img + ".png", UriKind.Relative));
                b1.Click -= Button_Click_4;               
                b2.Visibility = Visibility.Visible;
                b2.IsEnabled = true;

            }
            else
            {
                add2.Visibility = Visibility.Hidden;
                label2.Content = title;
                img2.Source = new BitmapImage(new Uri("Resources/" + img + ".png", UriKind.Relative));
                b1.Click -= Button_Click_4;
            }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Rooms_add adding = new Rooms_add(this);
            adding.Show();
            this.Hide();
        }
    }
}

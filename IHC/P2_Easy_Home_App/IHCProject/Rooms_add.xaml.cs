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
    /// Interaction logic for Rooms_add.xaml
    /// </summary>
    public partial class Rooms_add : Window
    {
        Rooms room;
        public Rooms_add(Rooms rm)
        {
            InitializeComponent();
            room = rm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InitialPage ip = new InitialPage();

            ip.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var combotext = combo.Text;
            room.addSceneFinal(tbox.Text, combotext);
            room.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statistics = new StatisticsWindow();

            statistics.Show();
            this.Close();
        }

    }
}

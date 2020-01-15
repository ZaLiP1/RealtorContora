using ContoraRealtor.FormaClienta_1.SentencesClients;
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

namespace ContoraRealtor.FormaClienta_1
{
    /// <summary>
    /// Логика взаимодействия для ClientsForms.xaml
    /// </summary>
    public partial class ClientsForms : Window
    {
        public ClientsForms()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsDemands cli = new ClientsDemands();
            this.Hide();
            cli.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SentenceClients cli = new SentenceClients();
            this.Hide();
            cli.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Deal_1 cli = new Deal_1();
            this.Hide();
            cli.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StartAp cli = new StartAp();
            this.Hide();
            cli.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TypeProperty cli = new TypeProperty();
            this.Hide();
            cli.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

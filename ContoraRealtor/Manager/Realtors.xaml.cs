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

namespace ContoraRealtor
{
    /// <summary>
    /// Логика взаимодействия для Realtors.xaml
    /// </summary>
    public partial class Realtors : Window
    {
        public Realtors()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //список клиентов
        {
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //список риелторов
        {
            RealtorList re = new RealtorList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //переход на главную форму
        {
            StartAp re = new StartAp();
            this.Hide();
            re.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //список менеджеров
        {
            ManagerList re = new ManagerList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DemandListxaml re = new DemandListxaml();
            this.Hide();
            re.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TypeProperty re  = new TypeProperty();
            this.Hide();
            re.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SentenceList re = new SentenceList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Deal_1 re = new Deal_1();
            this.Hide();
            re.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Sentensce_Managers re = new Sentensce_Managers();
            this.Hide();
            re.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

using ContoraRealtor.FormaClienta_1;
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
    /// Логика взаимодействия для TypeProperty.xaml
    /// </summary>
    public partial class TypeProperty : Window
    {
        public TypeProperty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 1) //клиент
            {
                ClientsForms re = new ClientsForms();
                this.Hide();
                re.Show();
            }
            if (SecurityContext.autovxod == 3)
            {
                Realtors re = new Realtors();
                this.Hide();
                re.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApartList re = new ApartList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HouseList re = new HouseList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LandLIst re = new LandLIst();
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

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
    /// Логика взаимодействия для StartAp.xaml
    /// </summary>
    public partial class StartAp : Window
    {
        public StartAp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecurityContext.autovxod = 1;
            MainWindow re = new MainWindow();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecurityContext.autovxod = 2;
            MainWindow re = new MainWindow();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SecurityContext.autovxod = 3;
            MainWindow re = new MainWindow();
            this.Hide();
            re.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

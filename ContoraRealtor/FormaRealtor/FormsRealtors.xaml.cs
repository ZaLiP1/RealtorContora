using ContoraRealtor.FormaRealtor.DemandsRealtors;
using ContoraRealtor.FormaRealtor.SentencesRealtors;
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

namespace ContoraRealtor.FormaRealtor
{
    /// <summary>
    /// Логика взаимодействия для FormsRealtors.xaml
    /// </summary>
    public partial class FormsRealtors : Window
    {
        public FormsRealtors()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            StartAp start = new StartAp();
            this.Hide();
            start.Show();
        }

        private void demand_Click(object sender, RoutedEventArgs e)
        {
            DemandsRealtorsList demands = new DemandsRealtorsList();
            this.Hide();
            demands.Show();
        }

        private void sentence_Click(object sender, RoutedEventArgs e)
        {
            SentenceRealtorsList sentence = new SentenceRealtorsList();
            this.Hide();
            sentence.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sentensce_Managers sentence = new Sentensce_Managers();
            this.Hide();
            sentence.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Deal_1 sentence = new Deal_1();
            this.Hide();
            sentence.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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

namespace ContoraRealtor.FormaRealtor.SentencesRealtors
{
    /// <summary>
    /// Логика взаимодействия для AddSentenceRealtorsList.xaml
    /// </summary>
    public partial class AddSentenceRealtorsList : Window
    {
        public AddSentenceRealtorsList()
        {
            InitializeComponent();
        }

        DataTable dtClient = GetClientList();
        DataTable dtProtert = GetProtertList();
    

       

        public static DataTable GetProtertList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtProtert = new DataTable();

            var Query = from propetr in db.property
                        select new

                        {
                            propetr.idProperty,
                            cit = propetr.City,
                            stret = propetr.Street,
                            Numbers = propetr.Number,
                            Coordinat = propetr.latitude + " " + propetr.Longitude,
                        };
            dtProtert.Columns.Add("id");
            dtProtert.Columns.Add("Город");
            dtProtert.Columns.Add("Улица");
            dtProtert.Columns.Add("Номер дома(квартиры)");
            dtProtert.Columns.Add("Координаты");

            foreach (var rel in Query)
            {

                dtProtert.Rows.Add(rel.idProperty, rel.cit, rel.stret, rel.Numbers, rel.Coordinat);

            }
            return dtProtert;
        }

        private void ClientLi_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }
        public static DataTable GetClientList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Фамилия");
            dtClient.Columns.Add("Имя");
            dtClient.Columns.Add("Отчество");
            dtClient.Columns.Add("Номер телефона");
            var Query = db.Client;

            foreach (var rel in Query)
            {

                dtClient.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Phone);

            }
            return dtClient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SentenceRealtorsList re = new SentenceRealtorsList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Price.Text != "")
                { if (int.Parse(Price.Text) > 0)
                    {
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            RealtorEntities db = new RealtorEntities();
                            Sentence save = new Sentence();
                            save.IdRealtor = SecurityContext.idRealtor;
                            save.IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString());
                            save.IdProperty = int.Parse(dtProtert.Rows[PropertLi.SelectedIndex].ItemArray[0].ToString());
                            save.Price = int.Parse(Price.Text);
                            db.Sentence.Add(save);
                            db.SaveChanges();
                            if (MessageBox.Show("Перейти на форму списка предложений?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                            {

                            }
                            else
                            {
                                SentenceRealtorsList re = new SentenceRealtorsList();
                                this.Hide();
                                re.Show();
                            }
                        }
                    }
                else
                    {
                        MessageBox.Show("Цена не может бы отрицательной");
                    }

                }
                else
                {
                    MessageBox.Show("Проверьте введеные данные в поле Цена");
                }

            }
            catch
            {
                MessageBox.Show("Проверьте выбранные поля в таблицах");
            }

        }

        private void propert_Loaded(object sender, RoutedEventArgs e)
        {
            PropertLi.ItemsSource = dtProtert.DefaultView;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

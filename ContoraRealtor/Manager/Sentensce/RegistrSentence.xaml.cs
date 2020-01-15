using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrSentence.xaml
    /// </summary>
    public partial class RegistrSentence : Window
    {
        public RegistrSentence()
        {
            InitializeComponent();
        }
        DataTable dtRealtor = GetRealtorList();
        DataTable dtClient = GetClientList();
        DataTable dtProtert = GetProtertList();
        private void RealtorLi_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorLi.ItemsSource = dtRealtor.DefaultView;
        }

        public static DataTable GetRealtorList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtRealtor = new DataTable();
            dtRealtor.Columns.Add("id");
            dtRealtor.Columns.Add("Фамилия");
            dtRealtor.Columns.Add("Имя");
            dtRealtor.Columns.Add("Отчество");
            dtRealtor.Columns.Add("Доля комисси");
            var Query = db.Realtor;

            foreach (var rel in Query)
            {

                dtRealtor.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Comission);

            }
            return dtRealtor;
        }

        public static DataTable GetProtertList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtProtert = new DataTable();

            var Query = from propert in db.property
                        select new

                        {
                            propert.idProperty,
                            cit = propert.City,
                            str = propert.Street,
                            Numbers = propert.Number,
                            Coordinat = propert.latitude + " " + propert.Longitude,
                        };
            dtProtert.Columns.Add("id");
            dtProtert.Columns.Add("Город");
            dtProtert.Columns.Add("Улица");
            dtProtert.Columns.Add("Номер дома(квартиры)");
            dtProtert.Columns.Add("Координаты");

            foreach (var rel in Query)
            {

                dtProtert.Rows.Add(rel.idProperty, rel.cit, rel.str, rel.Numbers, rel.Coordinat);

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
            SentenceList re = new SentenceList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])");
                if (regex.IsMatch(Price.Text))
                {
                    MessageBox.Show("Некорректный ввод данных проверьте поле Цена ");
                }
                else
                {
                    if (Price.Text != "")
                    {
                        regex = new Regex(@"(.*[a-z])");
                        var regex_1 = new Regex(@"(.*[A-Z])");
                        var regex_2 = new Regex(@"(.*[А-Я])");
                        var regex_3 = new Regex(@"(.*[а-я])");
                        if (regex.IsMatch(Price.Text) || regex_1.IsMatch(Price.Text) || regex_2.IsMatch(Price.Text) || regex_3.IsMatch(Price.Text))
                        {
                            MessageBox.Show("Некорректный ввод данных проверьте поле Цена ");
                        }
                        else
                        {
                            if (int.Parse(Price.Text) > 0)
                            {


                                RealtorEntities db = new RealtorEntities();
                                Sentence save = new Sentence();
                                save.IdRealtor = int.Parse(dtRealtor.Rows[RealtorLi.SelectedIndex].ItemArray[0].ToString());
                                save.IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString());
                                save.IdProperty = int.Parse(dtProtert.Rows[PropertLi.SelectedIndex].ItemArray[0].ToString());
                                save.Price = int.Parse(Price.Text);
                                if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                {
                                    db.Sentence.Add(save);
                                    db.SaveChanges();
                                    if (MessageBox.Show("Перейти на форму списка предложений?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                    {

                                    }
                                    else
                                    {
                                        SentenceList re = new SentenceList();
                                        this.Hide();
                                        re.Show();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Цена не может быть отрицательной");
                            }
                        }

                    }

                    else
                    {
                        MessageBox.Show("Вы не заполнили цену");
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Вы заполнили не все поля");
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

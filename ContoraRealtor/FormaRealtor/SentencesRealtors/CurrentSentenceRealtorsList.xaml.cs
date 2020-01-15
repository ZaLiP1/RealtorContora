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
    /// Логика взаимодействия для CurrentSentenceRealtorsList.xaml
    /// </summary>
    public partial class CurrentSentenceRealtorsList : Window
    {
        public CurrentSentenceRealtorsList()
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
            dtProtert.Columns.Add("Номер дома");
            dtProtert.Columns.Add("Номер квартиры ");
            dtProtert.Columns.Add("Координаты");

            foreach (var rel in Query)
            {

                dtProtert.Rows.Add(rel.idProperty, rel.cit, rel.stret, rel.Numbers, rel.Coordinat);

            }
            return dtProtert;
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
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }


        private void PropertLi_Loaded(object sender, RoutedEventArgs e)
        {
            PropertLi.ItemsSource = dtProtert.DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            ClientLi.ItemsSource = dtClient.DefaultView;
            PropertLi.ItemsSource = dtProtert.DefaultView;
            Sentence sentence = db.Sentence.Find(SecurityContext.idSentence);
            Price.Text = sentence.Price.ToString();

            for (int i = 0; i < dtClient.Rows.Count; i++)
            {
                if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == sentence.IdClient)
                {
                    ClientLi.SelectedIndex = i;
                }
            }
            for (int i = 0; i < dtProtert.Rows.Count; i++)
            {
                if (int.Parse(dtProtert.Rows[i].ItemArray[0].ToString()) == sentence.IdProperty)
                {
                    PropertLi.SelectedIndex = i;
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SentenceRealtorsList re = new SentenceRealtorsList();
            this.Hide();
            re.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Price.Text != "")
                {
                    if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        RealtorEntities db = new RealtorEntities();
                        Sentence sentence = db.Sentence.Find(SecurityContext.idSentence);
                        sentence.IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString());
                        sentence.IdRealtor = SecurityContext.idRealtor;
                        sentence.IdProperty = int.Parse(dtProtert.Rows[PropertLi.SelectedIndex].ItemArray[0].ToString());
                        sentence.Price = int.Parse(Price.Text);
                        db.Sentence.Create();
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
                    MessageBox.Show("Проверьте введеные данные в поле цена");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте выбранные поля в таблицах");
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данное предложение?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Sentence sentence = db.Sentence.Find(SecurityContext.idSentence);
                    db.Sentence.Remove(db.Sentence.Where(dr => dr.IdSentence == SecurityContext.idSentence).FirstOrDefault());
                    db.SaveChanges();
                    SentenceRealtorsList re = new SentenceRealtorsList();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данное предложение участвует в сделке");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

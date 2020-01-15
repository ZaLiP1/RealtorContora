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

namespace ContoraRealtor
{
    /// <summary>
    /// Логика взаимодействия для CurrentDeal.xaml
    /// </summary>
    public partial class CurrentDeal : Window
    {
        public CurrentDeal()
        {
            InitializeComponent();
        }
        DataTable dtDemand = GetDemandlList();
        DataTable dtSentence = GetSentencList();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Deal deal = db.Deal.Find(SecurityContext.idDeal);
            DemandLi.ItemsSource = dtDemand.DefaultView;
            SentencLi.ItemsSource = dtSentence.DefaultView;


            for (int i = 0; i < dtDemand.Rows.Count; i++)
            {
                if (int.Parse(dtDemand.Rows[i].ItemArray[0].ToString()) == deal.IdDemand)
                {
                    DemandLi.SelectedIndex = i;
                }
            }
            for (int i = 0; i < dtSentence.Rows.Count; i++)
            {
                if (int.Parse(dtSentence.Rows[i].ItemArray[0].ToString()) == deal.IdSentence)
                {
                    SentencLi.SelectedIndex = i;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Deal_1 deal = new Deal_1();
            this.Hide();
            deal.Show();
        }

        private void DemandLi_Loaded(object sender, RoutedEventArgs e)
        {
            DemandLi.ItemsSource = dtDemand.DefaultView;
        }

        private void SentencLi_Loaded(object sender, RoutedEventArgs e)
        {
            SentencLi.ItemsSource = dtSentence.DefaultView;
        }
        public static DataTable GetDemandlList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtDemand = new DataTable();
            var query = from demand in db.demand
                        join realtor in db.Realtor on demand.IdRealtor equals realtor.id
                        join client in db.Client on demand.IdClient equals client.id
                        join NameTyp in db.NameTypPropetry on demand.NameType equals NameTyp.IdNamyType
                        select new
                        {
                            demand.IdDemand,
                            cl = client.id + realtor.id,
                            FioClient = client.LastName + " " + client.Name + " " + client.MiddleName,
                            phone = client.Phone,
                            FioRealtor = realtor.LastName + " " + realtor.Name + " " + realtor.MiddleName,
                            Comiss = realtor.Comission,
                            NameTyp = NameTyp.NameType,
                            demand.MinPrice,
                            demand.MaxPrice
                        };

            dtDemand.Columns.Add("Номер потребности");
            dtDemand.Columns.Add("Уникальный норме");
            dtDemand.Columns.Add("ФИО клиента");
            dtDemand.Columns.Add("Номер телефона клиента");
            dtDemand.Columns.Add("ФИО риелтора");
            dtDemand.Columns.Add("Доля комисси");
            dtDemand.Columns.Add("Тип объекта недвижимости");
            dtDemand.Columns.Add("Минимальная цена");
            dtDemand.Columns.Add("Максимальная цена");


            foreach (var rel in query)
            {

                dtDemand.Rows.Add(rel.IdDemand, rel.cl, rel.FioClient, rel.phone, rel.FioRealtor, rel.Comiss, rel.NameTyp, rel.MinPrice, rel.MaxPrice);

            }

            return dtDemand;
        }

        public static DataTable GetSentencList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtSentence = new DataTable();
            var query = from sentence in db.Sentence
                        join realtor in db.Realtor on sentence.IdRealtor equals realtor.id
                        join client in db.Client on sentence.IdClient equals client.id
                        join propert in db.property on sentence.IdProperty equals propert.idProperty
                        select new
                        {
                            sentence.IdSentence,
                            cl = client.id + realtor.id,

                            FioClient = client.LastName + " " + client.Name + " " + client.MiddleName,
                            phone = client.Phone,
                            FioRealtor = realtor.LastName + " " + realtor.Name + " " + realtor.MiddleName,
                            Comiss = realtor.Comission,
                            cit = propert.City,
                            str = propert.Street,
                            Numbers = propert.Number,
                            Coordinat = propert.latitude + " " + propert.Longitude,
                            sentence.Price

                        };
            dtSentence.Columns.Add("Номер предложения");
            dtSentence.Columns.Add("Уникальный номер");
            dtSentence.Columns.Add("ФИО клиента");
            dtSentence.Columns.Add("Номер телефона клиента");
            dtSentence.Columns.Add("ФИО риелтора");
            dtSentence.Columns.Add("Доля комисси");
            dtSentence.Columns.Add("Город");
            dtSentence.Columns.Add("Улица");
            dtSentence.Columns.Add("Номер дома");
            dtSentence.Columns.Add("Координаты");
            dtSentence.Columns.Add("Цена");
            foreach (var rel in query)
            {

                dtSentence.Rows.Add(rel.IdSentence, rel.cl, rel.FioClient, rel.phone, rel.FioRealtor, rel.Comiss, rel.cit, rel.str, rel.Numbers, rel.Coordinat, rel.Price);

            }
            return dtSentence;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данную сделку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Deal deal = db.Deal.Find(SecurityContext.idDeal);
                    db.Deal.Remove(db.Deal.Where(dr => dr.idDeal == SecurityContext.idDeal).FirstOrDefault());
                    db.SaveChanges();
                    Deal_1 re = new Deal_1();
                    this.Hide();
                    re.Show();
                }
            }
            catch(Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                if (int.Parse(dtDemand.Rows[DemandLi.SelectedIndex].ItemArray[1].ToString()) == int.Parse(dtSentence.Rows[SentencLi.SelectedIndex].ItemArray[1].ToString()))
                {
                    if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        RealtorEntities db = new RealtorEntities();
                        Deal deal = db.Deal.Find(SecurityContext.idDeal);
                        deal.IdDemand = int.Parse(dtDemand.Rows[DemandLi.SelectedIndex].ItemArray[0].ToString());
                        deal.IdSentence = int.Parse(dtSentence.Rows[SentencLi.SelectedIndex].ItemArray[0].ToString());
                        db.Sentence.Create();
                        db.SaveChanges();
                        if (MessageBox.Show("Перейти на форму списка сделок?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {

                        }
                        else
                        {
                            Deal_1 re = new Deal_1();
                            this.Hide();
                            re.Show();
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Вы пытаетесь выбрать риелтора который не предлегала данному клиенту услугу в его потребности");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте выбранные поля");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

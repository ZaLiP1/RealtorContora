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
    /// Логика взаимодействия для CurrentApart.xaml
    /// </summary>
    public partial class CurrentApart : Window
    {
        public CurrentApart()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ApartList re = new ApartList();
            this.Hide();
            re.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ClientLi.ItemsSource = dtClient.DefaultView;
                RealtorEntities db = new RealtorEntities();
                var apart = db.Apartment.Find(SecurityContext.id);
                Floor.Text = apart.Floor.ToString();
                Rooms.Text = apart.NumberOfRooms.ToString();
                Square.Text = apart.square.ToString();
                if (SecurityContext.autovxod == 3)
                {
           
                    for (int i = 0; i < dtClient.Rows.Count; i++)
                    {
                        if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == apart.IdClient)
                        {
                            ClientLi.SelectedIndex = i;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Floor.Text != "" && Rooms.Text != "" && Square.Text != "")
                {


                        RealtorEntities db = new RealtorEntities();
                        Apartment apart = db.Apartment.Find(SecurityContext.id);
                        apart.Floor = int.Parse(Floor.Text);
                        apart.NumberOfRooms = int.Parse(Rooms.Text);
                        apart.square = int.Parse(Square.Text);
                    if (MessageBox.Show("Вы уверены что хотите обновить данные о квартире?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        db.Apartment.Create();
                        db.SaveChanges();
                        if (MessageBox.Show("Перейти на форму списка квартир?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {

                        }
                        else
                        {
                            ApartList re = new ApartList();
                            this.Hide();
                            re.Show();
                        }

                    }

                }
                else

                {
                    MessageBox.Show("Вы  заполнили  не все поля");
                }
            }
            catch 
            {
                MessageBox.Show("Проверьте введеные данные");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                if (MessageBox.Show("Вы уверены что хотите удалить данную квартиру?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Apartment client = db.Apartment.Find(SecurityContext.id);
                    db.Apartment.Remove(db.Apartment.Where(dr => dr.IdApartment == SecurityContext.id).FirstOrDefault());
                    db.SaveChanges();
                    ApartList re = new ApartList();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данная квартира участвует в предложение");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if(SecurityContext.autovxod == 3)
            {

            }
            if (SecurityContext.autovxod == 1)
            {
                Update.Margin = new Thickness(297,144,0,0);
                Delete.Margin = new Thickness(297, 169, 0, 0);
                back.Margin = new Thickness(297, 194, 0, 0);
                Cli.Visibility = Visibility.Hidden;
                ClientLi.Visibility = Visibility.Hidden;
            }
        }
        DataTable dtClient = GetClientList();
        public static DataTable GetClientList()
        {
            if (SecurityContext.autovxod == 3)
            {
                RealtorEntities db = new RealtorEntities();
                DataTable dtClient = new DataTable();
                dtClient.Columns.Add("id");
                dtClient.Columns.Add("Фамилия");
                dtClient.Columns.Add("Имя");
                dtClient.Columns.Add("Отчество");
                dtClient.Columns.Add("Номер телефона");
                dtClient.Columns.Add("Логин");
                dtClient.Columns.Add("Пароль");
                var Query = db.Client;

                foreach (var rel in Query)
                {

                    dtClient.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Phone, rel.Login, rel.Password);

                }
                return dtClient;
            }
            else
            {
                DataTable dtClient = new DataTable();
                return dtClient;
            }
        }
        private void ClientLi_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

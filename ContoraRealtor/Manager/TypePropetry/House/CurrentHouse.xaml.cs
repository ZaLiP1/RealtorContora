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
    /// Логика взаимодействия для CurrentHouse.xaml
    /// </summary>
    public partial class CurrentHouse : Window
    {
        public CurrentHouse()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            ClientLi.ItemsSource = dtClient.DefaultView;
            RealtorEntities db = new RealtorEntities();
            var house = db.House.Find(SecurityContext.id);
            Storeys.Text = house.Storeys.ToString();
            Rooms.Text = house.NumberOfRooms.ToString();
            Square.Text = house.square.ToString();
            if (SecurityContext.autovxod == 3)
            {

                for (int i = 0; i < dtClient.Rows.Count; i++)
                {
                    if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == house.IdClient)
                    {
                        ClientLi.SelectedIndex = i;
                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Storeys.Text != "" && Rooms.Text != "" && Square.Text != "")
                {
                    
                        RealtorEntities db = new RealtorEntities();
                        House house = db.House.Find(SecurityContext.id);
                        house.Storeys =int.Parse(Storeys.Text);
                        house.NumberOfRooms = int.Parse(Rooms.Text);
                        house.square = int.Parse(Square.Text);
                    if (MessageBox.Show("Вы уверены что хотите обновить данные о доме?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        db.House.Create();
                        db.SaveChanges();
                        if (MessageBox.Show("Перейти на форму списка домов?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {

                        }
                        else
                        {
                            HouseList re = new HouseList();
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



                if (MessageBox.Show("Вы уверены что хотите удалить данный дом?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    House house = db.House.Find(SecurityContext.id);
                    db.House.Remove(db.House.Where(dr => dr.IdHouse == SecurityContext.id).FirstOrDefault());
                    db.SaveChanges();
                    HouseList re = new HouseList();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данный дом участвует в предложение");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            HouseList re = new HouseList();
            this.Hide();
            re.Show();
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 1)
            {
                Update.Margin = new Thickness(301, 172, 0, 0);
                Delete.Margin = new Thickness(301, 197, 0, 0);
                back.Margin = new Thickness(301, 222, 0, 0);
                Cli.Visibility = Visibility.Hidden;
                ClientLi.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

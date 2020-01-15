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
    /// Логика взаимодействия для CurrentLand.xaml
    /// </summary>
    public partial class CurrentLand : Window
    {
        public CurrentLand()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            LandLIst re = new LandLIst();
            this.Hide();
            re.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данную землю?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Land land = db.Land.Find(SecurityContext.id);
                    db.Land.Remove(db.Land.Where(dr => dr.IdLand == SecurityContext.id).FirstOrDefault());
                    db.SaveChanges();
                    LandLIst re = new LandLIst();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данная земля участвует в предложение");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Square.Text != "")
                {

                        RealtorEntities db = new RealtorEntities();
                        var land = db.Land.Find(SecurityContext.id);
                        land.square = int.Parse(Square.Text);
                    if (MessageBox.Show("Вы уверены что хотите обновить данные о доме?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        db.Land.Create();
                        db.SaveChanges();
                        if (MessageBox.Show("Перейти на форму списка земли?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {

                        }
                        else
                        {
                            LandLIst re = new LandLIst();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientLi.ItemsSource = dtClient.DefaultView;
                RealtorEntities db = new RealtorEntities();
                var land = db.Land.Find(SecurityContext.id);
                Square.Text = land.square.ToString();
                if (SecurityContext.autovxod == 3)
                {

                    for (int i = 0; i < dtClient.Rows.Count; i++)
                    {
                        if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == land.IdClient)
                        {
                            ClientLi.SelectedIndex = i;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if(SecurityContext.autovxod == 1)
            {
                La.Margin = new Thickness(197, 79, 0, 0);
                Square.Margin = new Thickness(298, 79, 0, 0);
                Update.Margin = new Thickness(314, 119, 0, 0);
                Delete.Margin = new Thickness(314,169,0,0);
                back.Margin = new Thickness(314, 169, 0, 0);
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

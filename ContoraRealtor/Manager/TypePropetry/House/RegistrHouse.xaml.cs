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
    /// Логика взаимодействия для RegistrHouse.xaml
    /// </summary>
    public partial class RegistrHouse : Window
    {
        public RegistrHouse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //добавление
        {
            if (SecurityContext.autovxod == 3) //Риелтор
            {


                try
                {
                    if (Storeys.Text != "" && Rooms.Text != "" && square.Text != "")
                    {
                        
                            RealtorEntities db = new RealtorEntities();
                            House save = new House
                            {
                                Storeys = int.Parse(Storeys.Text),
                                NumberOfRooms = int.Parse(Rooms.Text),
                                square = int.Parse(square.Text),
                                IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString())

                            };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.House.Add(save);
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
                    MessageBox.Show("Проверьте ввденые данные ");
                }
            }
            if (SecurityContext.autovxod == 1) //клиент
            {


                try
                {
                    if (Storeys.Text != "" && Rooms.Text != "" && square.Text != "")
                    {

                            RealtorEntities db = new RealtorEntities();
                            House save = new House
                            {
                                Storeys = int.Parse(Storeys.Text),
                                NumberOfRooms = int.Parse(Rooms.Text),
                                square = int.Parse(square.Text),
                                IdClient = SecurityContext.idClient
                                
                            };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.House.Add(save);
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
                    MessageBox.Show("Проверьте ввденые данные ");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
            if(SecurityContext.autovxod == 1)
            {
                Cli.Visibility = Visibility.Hidden;
                ClientLi.Visibility = Visibility.Hidden;
                add.Margin = new Thickness(323, 159, 0, 0);
                back.Margin = new Thickness(205, 159, 0, 0);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

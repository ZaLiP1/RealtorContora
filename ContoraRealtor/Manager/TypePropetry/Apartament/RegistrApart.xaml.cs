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
    /// Логика взаимодействия для RegistrApart.xaml
    /// </summary>
    public partial class RegistrApart : Window
    {
        public RegistrApart()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 3) //Менеджер
            {
                try
                {
                    if (Floor.Text != "" && Rooms.Text != "" && Squ.Text != "")
                    {
                       
                            RealtorEntities db = new RealtorEntities();
                            Apartment save = new Apartment
                            {
                                Floor = int.Parse(Floor.Text),
                                NumberOfRooms = int.Parse(Rooms.Text),
                                square = int.Parse(Squ.Text),
                                IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString())

                    };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.Apartment.Add(save);
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
                        MessageBox.Show("Вы  заполнили не все поля");
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте введеные данные");
                }
            }
            if (SecurityContext.autovxod == 1) //клиент
            {
                try
                {
                    if (Floor.Text != "" && Rooms.Text != "" && Squ.Text != "")
                    {

                            RealtorEntities db = new RealtorEntities();
                            Apartment save = new Apartment
                            {
                                Floor = int.Parse(Floor.Text),
                                NumberOfRooms = int.Parse(Rooms.Text),
                                square = int.Parse(Squ.Text),
                                IdClient = SecurityContext.idClient,
                            };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.Apartment.Add(save);
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
                        MessageBox.Show("Вы  заполнили не  все поля");
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте введеные данные");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApartList re = new ApartList();
            this.Hide();
            re.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 1)
            {
                add.Margin = new Thickness(296, 134, 0, 0);
                back.Margin = new Thickness(152, 134, 0, 0);
                ClientLi.Visibility = Visibility.Hidden;
                Cli.Visibility = Visibility.Hidden;
                Cli.IsEnabled = false;
            }
            if(SecurityContext.autovxod == 3)
            {
                
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
        private   void ClientLi_Loaded(object sender, RoutedEventArgs e)
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

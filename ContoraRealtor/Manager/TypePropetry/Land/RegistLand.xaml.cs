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
    /// Логика взаимодействия для RegistLand.xaml
    /// </summary>
    public partial class RegistLand : Window
    {
        public RegistLand()
        {
            InitializeComponent();
        }

        private void squ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 3) //Менеджер
            {
                try
                {
                    if (squ.Text != "")
                    {
                       
                            RealtorEntities db = new RealtorEntities();
                            Land save = new Land
                            {

                                square = int.Parse(squ.Text),
                                IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString())

                            };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.Land.Add(save);
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
            if (SecurityContext.autovxod == 1) //Клиент
            {
                try
                {
                    if (squ.Text != "")
                    {

                            RealtorEntities db = new RealtorEntities();
                            Land save = new Land
                            {

                                square = int.Parse(squ.Text),
                                IdClient = SecurityContext.idClient
                            };
                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            db.Land.Add(save);
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
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LandLIst re = new LandLIst();
            this.Hide();
            re.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if(SecurityContext.autovxod == 1)
            {
                squ.Margin = new Thickness(286, 60, 0, 0);
                La.Margin = new Thickness(335, 108, 0, 0);
                add.Margin = new Thickness(225, 108, 0, 0);
                back.Margin = new Thickness(190, 60, 0, 0);
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

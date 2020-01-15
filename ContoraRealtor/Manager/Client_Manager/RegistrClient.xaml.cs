using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegistrClient.xaml
    /// </summary>
    public partial class RegistrClient : Window
    {
        public RegistrClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //форма списка клиентов
        {
            if (SecurityContext.autovxod == 3)
            {
                ClientList re = new ClientList();
                this.Hide();
                re.Show();
            }
            if (SecurityContext.autovxod == 1)
            {
                MainWindow re = new MainWindow();
                this.Hide();
                re.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //создание нового клиента
        {
            try
            {
                if (ClientLastName.Text != "" && phone.Text != "" && ClientName.Text != "" && Log.Text != "" && Pas.Text != "" && phone.Text != "")
                {

                    if (phone.Text.Length == 11)
                    {
                        if (phone.Text[0] == '7' || phone.Text[0] == '8')
                        {
                            var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])");
                            if (regex.IsMatch(ClientLastName.Text) || regex.IsMatch(ClientName.Text) || regex.IsMatch(ClientMiddleName.Text) || regex.IsMatch(phone.Text))
                            {
                                MessageBox.Show("Некорректный ввод данных проверьте  поле ФИО иили Номер телефона");
                            }
                            else
                            {
                                regex = new Regex(@"(.*[0-9])");

                                if (regex.IsMatch(ClientLastName.Text) || regex.IsMatch(ClientName.Text) || regex.IsMatch(ClientMiddleName.Text))
                                {
                                    MessageBox.Show("Некорректный ввод  данных проверьте поле ФИО ");
                                }
                                else
                                {

                                    regex = new Regex(@"(.*[a-z])");
                                    var regex_1 = new Regex(@"(.*[A-Z])");
                                    var regex_2 = new Regex(@"(.*[А-Я])");
                                    var regex_3 = new Regex(@"(.*[а-я])");
                                    if (regex.IsMatch(phone.Text) || regex_1.IsMatch(phone.Text) || regex_2.IsMatch(phone.Text) || regex_3.IsMatch(phone.Text))
                                    {
                                        MessageBox.Show("Некорректный ввод данных проверьте поле Номера телефона ");
                                    }
                                    else
                                    {
                                        RealtorEntities db = new RealtorEntities();
                                        Client save = new Client
                                        {
                                            LastName = LastName_Prov(ClientLastName.Text),
                                            Name = ClientName.Text,
                                            MiddleName = ClientMiddleName.Text,
                                            Phone = phone.Text,
                                            Login = Log.Text,
                                            Password = Pas.Text

                                        };
                                        if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                        {
                                            db.Client.Add(save);
                                            db.SaveChanges();
                                            if (SecurityContext.autovxod == 3)
                                            {
                                                if (MessageBox.Show("Перейти на форму списка клиентов?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                {

                                                }
                                                else
                                                {
                                                    ClientList re = new ClientList();
                                                    this.Hide();
                                                    re.Show();
                                                }
                                            }
                                            if (SecurityContext.autovxod == 1)
                                            {
                                                if (MessageBox.Show("Перейти на форму авторизации?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                {

                                                }
                                                else
                                                {
                                                    MainWindow re = new MainWindow();
                                                    this.Hide();
                                                    re.Show();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else

                        {
                            MessageBox.Show("Номер телефона должен начинатся на 7 или 8 ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод Номера телефона ");
                    }
                }
                else
                {
                    MessageBox.Show("Вы заполнили не все поля");
                }


            }
            catch
            {
                MessageBox.Show("Данный логин существует");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 1)
            {
                Add.Content = "Регистрация";
                Back.Content = "Назад";
            }

       
                if (SecurityContext.autovxod == 3)
                {
                    Add.Content = "Добавить";
                    Back.Content = "Назад";
                }
            }
        private string LastName_Prov(string fam)
        {
            var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,-])");

            if (regex.IsMatch(fam))
            {
                throw new Exception("Некорректные данные в поле Фамилия");
            }
            else
            {
               regex = new Regex(@"(.*[0-9])");

                if (regex.IsMatch(fam))
                {
                    throw new Exception("Некорректные данные в поле Фамилия");
                }
                else
                {
                    return fam;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

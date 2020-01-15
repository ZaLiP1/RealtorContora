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
    /// Логика взаимодействия для CurrentClient.xaml
    /// </summary>
    public partial class CurrentClient : Window
    {
        public CurrentClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //форма списка клиентов
        {
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RealtorEntities db = new RealtorEntities();
                var client = db.Client.Find(SecurityContext.idClient);
                ClientLastName.Text = client.LastName;
                ClientName.Text = client.Name;
                ClientMiddleName.Text = client.MiddleName;
                phone.Text = client.Phone;
                Log.Text = client.Login;
                Pas.Text = client.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //обновление
        {
            try
            {
                if (ClientLastName.Text != "" && phone.Text != "" && ClientName.Text != "" && Log.Text != "" && Pas.Text != "")
                {
                    if (phone.Text.Length == 11)
                    {
                        if (phone.Text[0] == '7' || phone.Text[0] == '8')
                        {
                            var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])");
                            if (regex.IsMatch(ClientLastName.Text) || regex.IsMatch(ClientName.Text) || regex.IsMatch(ClientMiddleName.Text) || regex.IsMatch(phone.Text))
                            {
                                MessageBox.Show("Некорректный ввод данных проверьте поля ФИО или Номер телефона");
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
                                        Client client = db.Client.Find(SecurityContext.idClient);
                                        client.LastName = ClientLastName.Text;
                                        client.MiddleName = ClientMiddleName.Text;
                                        client.Name = ClientName.Text;
                                        client.Phone = phone.Text;
                                        client.Login = Log.Text;
                                        client.Password = Pas.Text;
                                        if (MessageBox.Show("Вы уверены что хотите обновить данного клиента?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                        {

                                        }
                                        else
                                        {
                                            db.Client.Create();
                                            db.SaveChanges();
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
                MessageBox.Show("Данный логин уже существует");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //удаление
        {
            try
            {



                if (MessageBox.Show("Вы уверены что хотите удалить данного клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Client client = db.Client.Find(SecurityContext.idClient);
                    db.Client.Remove(db.Client.Where(dr => dr.id == SecurityContext.idClient).FirstOrDefault());
                    db.SaveChanges();
                    ClientList re = new ClientList();
                    this.Hide();
                    re.Show(); 
                }

            }
            catch 
            {
                MessageBox.Show("Данны клиент участвует в потребности или предложение");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

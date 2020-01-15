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
    /// Логика взаимодействия для RegistrManager.xaml
    /// </summary>
    public partial class RegistrManager : Window
    {
        public RegistrManager()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //создание меденжера
        {
            try
            {
                if (Password.Text != "" && Login.Text != "" && Last.Text != "" && First.Text != "" && Mid.Text != "")
                {
                    var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])");
                    if (regex.IsMatch(Last.Text) || regex.IsMatch(First.Text) || regex.IsMatch(Mid.Text))
                    {
                        MessageBox.Show("Некорректный ввод данных проверьте поле ФИО");
                    }
                    else
                    {
                        regex = new Regex(@"(.*[0-9])");

                        if (regex.IsMatch(Last.Text) || regex.IsMatch(First.Text) || regex.IsMatch(Mid.Text))
                        {
                            MessageBox.Show("Некорректный ввод данных проверьте поле  ФИО ");
                        }
                        else
                        {

                            
                                RealtorEntities db = new RealtorEntities();
                                Manager save = new Manager
                                {
                                    LastName = Last.Text,
                                    Name = First.Text,
                                    MiddleName = Mid.Text,
                                    Login = Login.Text,
                                    Password = Password.Text,
                                    rol = "Manager",
                                };
                            if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            {
                                db.Manager.Add(save);
                                db.SaveChanges();
                                if (MessageBox.Show("Перейти на форму списка менеджеров?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                {

                                }
                                else
                                {
                                    ManagerList re = new ManagerList();
                                    this.Hide();
                                    re.Show();
                                }
                            }
                        }
                    }
                }


                else
                {
                    MessageBox.Show("Вы заполнили не все поля");
                }
            }
            catch
            {
                MessageBox.Show("Данный логин уже занят");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //форма списка менеджеров
        {
            ManagerList re = new ManagerList();
            this.Hide();
            re.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

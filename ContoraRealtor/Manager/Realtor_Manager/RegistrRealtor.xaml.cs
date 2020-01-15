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
    /// Логика взаимодействия для RegistrRealtor.xaml
    /// </summary>
    public partial class RegistrRealtor : Window
    {
        public RegistrRealtor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //создание нового риелтора
        {

            try
            {

                if (RealtorCommis.Text != "" && RealtorName.Text != "" && RealtorLastName.Text != "" && RealtorMiddleName.Text != "" && Log.Text != "" && Pas.Text != "")
                {
                    var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])"); 
                    if (regex.IsMatch(RealtorName.Text) || regex.IsMatch(RealtorLastName.Text) || regex.IsMatch(RealtorMiddleName.Text))
                    {
                        MessageBox.Show("Некорректный ввод данных проверьте поля ФИО или Доля от коммиссии");
                    }
                    else
                    {
                        regex = new Regex(@"(.*[0-9])");

                        if (regex.IsMatch(RealtorName.Text) || regex.IsMatch(RealtorLastName.Text) || regex.IsMatch(RealtorMiddleName.Text))
                        {
                            MessageBox.Show("Некорректный ввод проверьте поле ФИО ");
                        }
                        else
                        {

                                regex = new Regex(@"(.*[a-z])");
                                if (regex.IsMatch(RealtorCommis.Text))
                                {
                                    MessageBox.Show("Проверьте введеные значения в поле комисси");
                                }
                                else
                                {
                                    regex = new Regex(@"(.*[A-Z])");
                                    if (regex.IsMatch(RealtorCommis.Text))
                                    {
                                        MessageBox.Show("Проверьте введеные данные в поле комисси");
                                    }

                                    else
                                    {
                                        regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,-])");
                                        if (regex.IsMatch(RealtorCommis.Text))
                                        {
                                            MessageBox.Show("Проверьте введеные данные в поле комисси");
                                        }

                                        else
                                        {
                                            regex = new Regex(@"(.*[А-Я])");
                                            if (regex.IsMatch(RealtorCommis.Text))
                                            {
                                                MessageBox.Show("Проверьте введеные данные в поле комисси");
                                            }
                                            else
                                            {
                                                regex = new Regex(@"(.*[а-я])");
                                                if (regex.IsMatch(RealtorCommis.Text))
                                                {
                                                    MessageBox.Show("Проверьте введеные данные в поле комисси");
                                                }
                                                else
                                                {


                                                  
                                                        RealtorEntities db = new RealtorEntities();
                                                        Realtor save = new Realtor
                                                        {
                                                            LastName = RealtorLastName.Text,
                                                            Name = RealtorName.Text,
                                                            MiddleName = RealtorMiddleName.Text,
                                                            Comission = int.Parse(RealtorCommis.Text),
                                                            Login = Log.Text,
                                                            Password = Pas.Text
                                                        };
                                                if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                                {
                                                    db.Realtor.Add(save);
                                                        db.SaveChanges();
                                                        if (SecurityContext.autovxod == 3)
                                                        {
                                                            if (MessageBox.Show("Перейти на форму списка риелторов?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                            {

                                                            }
                                                            else
                                                            {
                                                                RealtorList re = new RealtorList();
                                                                this.Hide();
                                                                re.Show();
                                                            }
                                                        }
                                                        if (SecurityContext.autovxod == 2)
                                                        {
                                                            if (MessageBox.Show("Перейти на форму авторизации?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                            {

                                                            }
                                                            else
                                                            {
                                                                MainWindow rel = new MainWindow();
                                                                this.Hide();
                                                                rel.Show();
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
  
                    }
                    else
                    {
                        MessageBox.Show("Вы заполнили не все  поля");
                    }

                }
                catch
                {
                    MessageBox.Show("Данный логин существует");
                }
     
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //форма списка риелтора
        {
            if (SecurityContext.autovxod == 2)
            {
                MainWindow rel = new MainWindow();
                this.Hide();
                rel.Show();
            }
            if (SecurityContext.autovxod == 3)
            {
                RealtorList reg = new RealtorList();
                this.Hide();
                reg.Show();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 2)
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

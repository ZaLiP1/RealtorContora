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
    /// Логика взаимодействия для CurrentManager.xaml
    /// </summary>
    public partial class CurrentManager : Window
    {
        public CurrentManager()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerList re = new ManagerList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //обновление
        {
            try
            {
                if (Password.Text != "" && Login.Text != "" && Last.Text != "" && First.Text != "" && Mid.Text != "")
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
                                Manager manager = db.Manager.Find(SecurityContext.idManager);
                                manager.LastName = Last.Text;
                                manager.Name = First.Text;
                                manager.MiddleName = Mid.Text;
                                manager.Login = Login.Text;
                                manager.Password = Password.Text;
                                if (MessageBox.Show("Вы уверены что хотите обновить данного менеджера?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                {

                                }
                                else
                                {
                                    db.Manager.Create();
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            var manager = db.Manager.Find(SecurityContext.idManager);
            Last.Text = manager.LastName;
            First.Text = manager.Name;
            Mid.Text = manager.MiddleName;
            Login.Text = manager.Login;
            Password.Text = manager.Password;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //удаление
        {
            try
            {
                RealtorEntities db = new RealtorEntities();
                Manager manager = db.Manager.Find(SecurityContext.idManager);
                if (MessageBox.Show("Вы уверены что хотите удалить данного менеджера?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    db.Manager.Remove(db.Manager.Where(dr => dr.IdManager == SecurityContext.idManager).FirstOrDefault());
                    db.SaveChanges();
                    ManagerList re = new ManagerList();
                    this.Hide();
                    re.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

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
    /// Логика взаимодействия для CurrentRealtor.xaml
    /// </summary>
    public partial class CurrentRealtor : Window
    {
        public CurrentRealtor()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            var realtor = db.Realtor.Find(SecurityContext.idRealtor);
            RealtorLastName.Text = realtor.LastName;
            RealtorName.Text = realtor.Name;
            RealtorMiddleName.Text = realtor.MiddleName;
            RealtorCommis.Text = realtor.Comission.ToString();
            Log.Text = realtor.Login;
            Pas.Text = realtor.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //обновление
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
                            MessageBox.Show("Некорректный ввод данных проверьте поле ФИО ");
                        }
                        else
                        {

                            regex = new Regex(@"(.*[a-z])");
                            if (regex.IsMatch(RealtorCommis.Text))
                            {
                                MessageBox.Show("Проверьте введеные данные в поле комисси");
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
                                                    Realtor realtor = db.Realtor.Find(SecurityContext.idRealtor);
                                                    realtor.LastName = RealtorLastName.Text;
                                                    realtor.MiddleName = RealtorMiddleName.Text;
                                                    realtor.Name = RealtorName.Text;
                                                    realtor.Comission = int.Parse(RealtorCommis.Text);
                                                    realtor.Login = Log.Text;
                                                    realtor.Password = Pas.Text;
                                                if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                                {
                                                    db.Realtor.Create();
                                                    db.SaveChanges();
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
                    MessageBox.Show("Вы заполнили не все поля");
                }
            }
            catch
            {
                MessageBox.Show("Данный логин существует");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //удаление
        {try
            {

                if (MessageBox.Show("Вы уверены что хотите удалить данного риелтора?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    Realtor realtor = db.Realtor.Find(SecurityContext.idRealtor);
                    db.Realtor.Remove(db.Realtor.Where(dr => dr.id == SecurityContext.idRealtor).FirstOrDefault());
                    db.SaveChanges();
                    RealtorList re = new RealtorList();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данные риелтор участвует в потребности или предложение");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RealtorList re = new RealtorList();
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

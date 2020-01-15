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
    /// Логика взаимодействия для CurrentSentensce_Managers.xaml
    /// </summary>
    public partial class CurrentSentensce_Managers : Window
    {
        public CurrentSentensce_Managers()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (City.Text != "" && Street.Text != "" && NumberHous.Text != "" && LaT.Text != "" && Long.Text != "")
                {
                    if (City.Text != "" && Street.Text != "" && NumberHous.Text != "" && LaT.Text != "" && Long.Text != "")
                    {
                        var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,.,\,:,-])");
                        if (regex.IsMatch(City.Text) || regex.IsMatch(Street.Text))
                        {
                            MessageBox.Show("Некорректный ввод данных проверьте поля Город или Улици");
                        }
                        else
                        {
                            regex = new Regex(@"(.*[0-9])");

                            if (regex.IsMatch(City.Text) || regex.IsMatch(Street.Text))
                            {
                                MessageBox.Show("Некорректный ввод данных проверьте поля Город или Улици");
                            }
                            else
                            {
                                if (int.Parse(NumberHous.Text) > 0)
                                {
                                    if (int.Parse(LaT.Text) <= 90 && int.Parse(LaT.Text) >= -90)
                                    {
                                        if (int.Parse(Long.Text) <= 180 && int.Parse(LaT.Text) >= -180)
                                        {
                                            RealtorEntities db = new RealtorEntities();
                                            property prop = db.property.Find(SecurityContext.idProperty);
                                            prop.City = City.Text;
                                            prop.Street = Street.Text;
                                            prop.Number = int.Parse(NumberHous.Text);
                                            prop.latitude = int.Parse(LaT.Text);
                                            prop.Longitude = int.Parse(Long.Text);
                                            if (MessageBox.Show("Вы уверены что хотите обновить данный объект недвижимости?", "Обнволение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                            {

                                            }
                                            else
                                            {
                                                db.property.Create();
                                                db.SaveChanges();
                                                if (MessageBox.Show("Перейти на форму списка объектов недвижимости?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                {

                                                }
                                                else
                                                {
                                                    Sentensce_Managers re = new Sentensce_Managers();
                                                    this.Hide();
                                                    re.Show();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Долгота  может принимать значения от -180 до +180");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Широта может принимать значения от -90 до +90");
                                    }
                                }

                                else
                                {
                                    MessageBox.Show("Отрицательного Номера дома(квартиры) не сущесвует");
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
                MessageBox.Show("Некорректный ввод данных проверьте поля Номер дома(квартиры), Долготы или Широты");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                if (MessageBox.Show("Вы уверены что хотите удалить данный объект недвижимости?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    RealtorEntities db = new RealtorEntities();
                    property prop = db.property.Find(SecurityContext.idProperty);
                    db.property.Remove(db.property.Where(dr => dr.idProperty == SecurityContext.idProperty).FirstOrDefault());
                    db.SaveChanges();
                    Sentensce_Managers re = new Sentensce_Managers();
                    this.Hide();
                    re.Show();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Sentensce_Managers re = new Sentensce_Managers();
            this.Hide();
            re.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RealtorEntities db = new RealtorEntities();
                var prop = db.property.Find(SecurityContext.idProperty);
                City.Text = prop.City;
                Street.Text = prop.Street;
                NumberHous.Text = prop.Number.ToString();
                LaT.Text = prop.latitude.ToString();
                Long.Text = prop.Longitude.ToString() ;
            }
            catch (Exception ex)
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

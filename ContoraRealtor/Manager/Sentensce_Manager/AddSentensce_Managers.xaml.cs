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
    /// Логика взаимодействия для AddSentensce_Managers.xaml
    /// </summary>
    public partial class AddSentensce_Managers : Window
    {
        public AddSentensce_Managers()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Sentensce_Managers sentensce = new Sentensce_Managers();
            this.Hide();
            sentensce.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 3) //Менеджер
            {
                try
                {
                    if (City.Text != "" && Street.Text != "" && NumberApart.Text != "" && LaT.Text != "" && Long.Text != "")
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
                                if (int.Parse(NumberApart.Text) > 0)
                                {
                                    if (int.Parse(LaT.Text) <= 90 && int.Parse(LaT.Text) >= -90)
                                    {
                                        if (int.Parse(Long.Text) <= 180 && int.Parse(LaT.Text) >= -180)
                                        {

                                            RealtorEntities db = new RealtorEntities();
                                            property save = new property();
                                            save.City = City.Text;
                                            save.Street = Street.Text;
                                            save.Number = int.Parse(NumberApart.Text);
                                            save.latitude = int.Parse(LaT.Text);
                                            save.Longitude = int.Parse(Long.Text);
                                            if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                            {
                                                db.property.Add(save);
                                                db.SaveChanges();
                                                if (MessageBox.Show("Перейти на форму списка объектов недвижимости?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                                {

                                                }
                                                else
                                                {
                                                    Sentensce_Managers sentensce = new Sentensce_Managers();
                                                    this.Hide();
                                                    sentensce.Show();
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


                    else
                    {
                        MessageBox.Show("Вы заполнили не все  поля");
                    }
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод данных проверьте поля Номер дома(квартиры), Долготы или Широты");
                }
            }
            if (SecurityContext.autovxod == 2) //Риелтор
            {
                try
                {
                    if (City.Text != "" && Street.Text != "" && NumberApart.Text != "" && LaT.Text != "" && Long.Text != "")
                    {
                        if (City.Text != "" && Street.Text != "" && NumberApart.Text != "" && LaT.Text != "" && Long.Text != "")
                        {
                            var regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,=,?,№,;,+,=,<,>,',\,|,/,-])");
                            if (regex.IsMatch(City.Text) || regex.IsMatch(Street.Text))
                            {
                                MessageBox.Show("Некорректный ввод данных проверьте поля Город и Улици");
                            }
                            else
                            {
                                regex = new Regex(@"(.*[0-9])");

                                if (regex.IsMatch(City.Text) || regex.IsMatch(Street.Text))
                                {
                                    MessageBox.Show("Некорректный ввод  данных проверьте поле ФИО ");
                                }
                                else
                                {

                                    RealtorEntities db = new RealtorEntities();
                                    property save = new property();
                                    save.City = City.Text;
                                    save.Street = Street.Text;
                                    save.Number = int.Parse(NumberApart.Text);
                                    save.latitude = int.Parse(LaT.Text);
                                    save.Longitude = int.Parse(Long.Text);
                                    save.idRealtor = SecurityContext.idRealtor;
                                    if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                    {
                                        db.property.Add(save);
                                        db.SaveChanges();
                                        if (MessageBox.Show("Перейти на форму списка объектов недвижимости?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                        {

                                        }
                                        else
                                        {
                                            Sentensce_Managers sentensce = new Sentensce_Managers();
                                            this.Hide();
                                            sentensce.Show();
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
                    MessageBox.Show("Проверьте введеные данные");
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

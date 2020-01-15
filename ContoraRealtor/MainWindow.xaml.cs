using ContoraRealtor.FormaClienta_1;
using ContoraRealtor.FormaRealtor;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContoraRealtor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aut_Click(object sender, RoutedEventArgs e) //авторизация
        {
            try
            {if (SecurityContext.autovxod == 1) //клиент
                {
                    
                    RealtorEntities db = new RealtorEntities();
                    if (password.Password != "")
                    {


                        if (login.Text != "")
                        {

                            var rol = db.Client.Where(us => us.Login == login.Text && us.Password == password.Password).FirstOrDefault().id;

                            ClientsForms cli = new ClientsForms();
                            this.Hide();
                            cli.Show();
                            SecurityContext.idClient = rol;


                        }
                        else

                        {
                            MessageBox.Show("Поле логин не введено");
                        }
                    }
                    else

                    {
                        MessageBox.Show("Поле пароль не введено");
                    }
                }
                if (SecurityContext.autovxod == 2) //realtor
                {
                    
                    RealtorEntities db = new RealtorEntities();
                    if (password.Password != "")
                    {


                        if (login.Text != "")
                        {

                            var rol = db.Realtor.Where(us => us.Login == login.Text && us.Password == password.Password).FirstOrDefault().id;

                            FormsRealtors realtor = new FormsRealtors();
                            this.Hide();
                            realtor.Show();
                            SecurityContext.idRealtor = rol;


                        }
                        else

                        {
                            MessageBox.Show("Поле логин не введено");
                        }
                    }
                    else

                    {
                        MessageBox.Show("Поле пароль не введено");
                    }
                }
                if (SecurityContext.autovxod == 3) //менеджер
                {
                   
                    RealtorEntities db = new RealtorEntities();
                    if (password.Password != "")
                    {


                        if (login.Text != "")
                        {

                            var rol = db.Manager.Where(us => us.Login == login.Text && us.Password == password.Password).FirstOrDefault().rol;
                            if (rol == "Manager")
                            {
                                Realtors realtor = new Realtors();
                                this.Hide();
                                realtor.Show();
                            }

                        }
                        else

                        {
                            MessageBox.Show("Поле логин не введено");
                        }
                    }
                    else

                    {
                        MessageBox.Show("Поле пароль не введено");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Логин или пароль не верны");
            }

        }

      

        private void Back_Click(object sender, RoutedEventArgs e) //кнопка выхода
        {
            StartAp rel = new StartAp();
            this.Hide();
            rel.Show();
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }




     

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 1) 
            {
                RegistrClient rel = new RegistrClient();
                this.Hide();
                rel.Show();
            }
            if (SecurityContext.autovxod == 2)
            {
                RegistrRealtor rel = new RegistrRealtor();
                this.Hide();
                rel.Show();
            }
            if (SecurityContext.autovxod == 3) //realtor
            {
                MessageBox.Show("Вы пытаетесь войти как менеджер. Если вы работник копании, попросите выдать вам пароль у начальства");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

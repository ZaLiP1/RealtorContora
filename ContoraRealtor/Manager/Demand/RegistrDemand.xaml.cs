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
    /// Логика взаимодействия для RegistrDemand.xaml
    /// </summary>
    public partial class RegistrDemand : Window
    {
        public RegistrDemand()
        {
            InitializeComponent();
        }
        DataTable dtRealtor = GetRealtorList();
        DataTable dtClient = GetClientList();
        DataTable dtApart = GetApart();
        DataTable dtHouse = GetHouse();
        DataTable dtLand = GetLand();
        private void Clients_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }

        private void Realtors_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorLi.ItemsSource = dtRealtor.DefaultView;
        }

        public static DataTable GetRealtorList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtRealtor = new DataTable();
            dtRealtor.Columns.Add("id");
            dtRealtor.Columns.Add("Фамилия");
            dtRealtor.Columns.Add("Имя");
            dtRealtor.Columns.Add("Отчество");
            dtRealtor.Columns.Add("Доля комисси");
            var Query = db.Realtor;

            foreach (var rel in Query)
            {

                dtRealtor.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Comission);

            }
            return dtRealtor;
        }
        public static DataTable GetClientList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Фамилия");
            dtClient.Columns.Add("Имя");
            dtClient.Columns.Add("Отчество");
            dtClient.Columns.Add("Номер телефона");
            var Query = db.Client;

            foreach (var rel in Query)
            {

                dtClient.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Phone);

            }
            return dtClient;
        }
        public static DataTable GetApart()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtApart = new DataTable();
            dtApart.Columns.Add("id");
            dtApart.Columns.Add("Этаж");
            dtApart.Columns.Add("Количество комнат");
            dtApart.Columns.Add("Площадь (в м2)");
            var Query = db.Apartment;

            foreach (var rel in Query)
            {

                dtApart.Rows.Add(rel.IdApartment, rel.Floor, rel.NumberOfRooms, rel.square);

            }
            return dtApart;
        }

        public static DataTable GetLand()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtLand = new DataTable();
            dtLand.Columns.Add("id");
            dtLand.Columns.Add("Площадь");

            var Query = db.Land;

            foreach (var rel in Query)
            {

                dtLand.Rows.Add(rel.IdLand, rel.square);

            }
            return dtLand;
        }
        public static DataTable GetHouse()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtHouse = new DataTable();
            dtHouse.Columns.Add("id");
            dtHouse.Columns.Add("Этажность");
            dtHouse.Columns.Add("Количество комнат");
            dtHouse.Columns.Add("Площадь");
            var Query = db.House;

            foreach (var rel in Query)
            {

                dtHouse.Rows.Add(rel.IdHouse, rel.Storeys, rel.NumberOfRooms, rel.square);

            }
            return dtHouse;
        }

        private void Type_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeCombo.SelectedIndex)
            {
                case 0:
                    Type.ItemsSource = dtApart.DefaultView;
                    break;
                case 1:
                    Type.ItemsSource = dtHouse.DefaultView;
                    break;
                case 2:
                    Type.ItemsSource = dtLand.DefaultView;
                    break;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MinPri.Text != "" && MaxPr.Text != "")
                {
                    if (int.Parse(MinPri.Text) > 0 || int.Parse(MaxPr.Text) > 0)
                    {
                        if (int.Parse(MinPri.Text) < int.Parse(MaxPr.Text))
                        {
                            RealtorEntities db = new RealtorEntities();
                            demand save = new demand();
                            save.IdRealtor = int.Parse(dtRealtor.Rows[RealtorLi.SelectedIndex].ItemArray[0].ToString());
                            save.IdClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString());
                            switch (TypeCombo.SelectedIndex)
                            {
                                case 0:
                                    save.TypePropetry = int.Parse(dtApart.Rows[Type.SelectedIndex].ItemArray[0].ToString());
                                    save.NameType = 3;
                                    break;
                                case 1:
                                    save.TypePropetry = int.Parse(dtHouse.Rows[Type.SelectedIndex].ItemArray[0].ToString());
                                    save.NameType = 2;
                                    break;
                                case 2:
                                    save.TypePropetry = int.Parse(dtLand.Rows[Type.SelectedIndex].ItemArray[0].ToString());
                                    save.NameType = 1;
                                    break;
                            }
                            save.MaxPrice = int.Parse(MaxPr.Text);
                            save.MinPrice = int.Parse(MinPri.Text);
                            if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            {
                                db.demand.Add(save);
                                db.SaveChanges();
                                if (MessageBox.Show("Перейти на форму списка потребностей?", "Данные успешно сохранены", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                {

                                }
                                else
                                {
                                    DemandListxaml re = new DemandListxaml();
                                    this.Hide();
                                    re.Show();
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Проверьте минимальную и максимальную сумму");

                        }

                    }
                    else

                    {
                        MessageBox.Show("Цена не может быть отрицательной");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не заполнили поле цена");
                }
        }
            catch
            {
                MessageBox.Show("Проверьте ввденые данные");

            }

}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DemandListxaml re = new DemandListxaml();
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

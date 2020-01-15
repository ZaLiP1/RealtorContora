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
    /// Логика взаимодействия для CurrentDemand.xaml
    /// </summary>
    public partial class CurrentDemand : Window
    {
        public CurrentDemand()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorLi.ItemsSource = dtRealtor.DefaultView;
            ClientLi.ItemsSource = dtClient.DefaultView;
            RealtorEntities db = new RealtorEntities();
            demand save = db.demand.Find(SecurityContext.idDemand);
            MaxPr.Text = save.MaxPrice.ToString();
            MinPri.Text = save.MinPrice.ToString();
            switch (save.NameType)
            {
                case 1:
                    TypeCombo.SelectedIndex = 2;
                    break;
                case 2:
                    TypeCombo.SelectedIndex = 1;
                    break;
                case 3:
                    TypeCombo.SelectedIndex = 0;
                    break;
            }
            for (int i = 0; i < dtClient.Rows.Count; i++)
            {
                if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == save.IdClient)
                {
                    ClientLi.SelectedIndex = i;
                }
            }
            for (int i = 0; i < dtRealtor.Rows.Count; i++)
            {
                if (int.Parse(dtRealtor.Rows[i].ItemArray[0].ToString()) == save.IdRealtor)
                {
                    RealtorLi.SelectedIndex = i;
                }
            }
            switch (TypeCombo.SelectedIndex)
            {

                case 0:
                    for (int i = 0; i < dtApart.Rows.Count; i++)
                    {
                        if (int.Parse(dtApart.Rows[i].ItemArray[0].ToString()) == save.TypePropetry)
                        {
                            Type.SelectedIndex = i;
                        }

                    }
                    break;
                case 1:
                    for (int i = 0; i < dtHouse.Rows.Count; i++)
                    {
                        if (int.Parse(dtHouse.Rows[i].ItemArray[0].ToString()) == save.TypePropetry)
                        {
                            Type.SelectedIndex = i;
                        }

                    }
                    break;
                case 2:
                    for (int i = 0; i < dtLand.Rows.Count; i++)
                    {
                        if (int.Parse(dtLand.Rows[i].ItemArray[0].ToString()) == save.TypePropetry)
                        {
                            Type.SelectedIndex = i;
                        }

                    }
                    break;
            }


        }

        DataTable dtRealtor = GetRealtorList();
        DataTable dtClient = GetClientList();
        DataTable dtApart = GetApart();
        DataTable dtHouse = GetHouse();
        DataTable dtLand = GetLand();
        private void Clients_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void ClientLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MinPri.Text != "" && MaxPr.Text != "")
                {
                    if (int.Parse(MinPri.Text) > 0 && int.Parse(MaxPr.Text) > 0)
                    {
                        if (int.Parse(MinPri.Text) < int.Parse(MaxPr.Text))
                        {

                            RealtorEntities db = new RealtorEntities();
                            demand save = db.demand.Find(SecurityContext.idDemand);
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
                                db.demand.Create();
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
                MessageBox.Show("Проверьте ввденые данные ");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DemandListxaml re = new DemandListxaml();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите сохранить данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    RealtorEntities db = new RealtorEntities();
                    demand demand = db.demand.Find(SecurityContext.idDemand);
                    db.demand.Remove(db.demand.Where(dr => dr.IdDemand == SecurityContext.idDemand).FirstOrDefault());
                    db.SaveChanges();
                    DemandListxaml re = new DemandListxaml();
                    this.Hide();
                    re.Show();
                }
            }
            catch
            {
                MessageBox.Show("Данная потребность участвует в сделке");
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
    }
}

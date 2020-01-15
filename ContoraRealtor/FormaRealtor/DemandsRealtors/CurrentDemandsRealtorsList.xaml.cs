using ContoraRealtor.FormaRealtor.SentencesRealtors;
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

namespace ContoraRealtor.FormaRealtor.DemandsRealtors
{
    /// <summary>
    /// Логика взаимодействия для CurrentDemandsRealtorsList.xaml
    /// </summary>
    public partial class CurrentDemandsRealtorsList : Window
    {
        public CurrentDemandsRealtorsList()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
         
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

        DataTable dtClient = GetClientList();
        DataTable dtApart = GetApart();
        DataTable dtHouse = GetHouse();
        DataTable dtLand = GetLand();
        private void Clients_Loaded(object sender, RoutedEventArgs e)
        {

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

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DemandsRealtorsList re = new DemandsRealtorsList();
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

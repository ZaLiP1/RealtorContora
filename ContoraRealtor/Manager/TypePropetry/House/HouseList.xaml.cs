using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для HouseList.xaml
    /// </summary>
    public partial class HouseList : Window
    {
        public HouseList()
        {
            InitializeComponent();
        }
        DataTable dtHouse = GetHouseList();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TypeProperty re = new TypeProperty();
            this.Hide();
            re.Show();
        }
        public static DataTable GetHouseList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtHouse = new DataTable();
            dtHouse.Columns.Add("id");
            dtHouse.Columns.Add("Этажность");
            dtHouse.Columns.Add("Количество комнат");
            dtHouse.Columns.Add("Площадь (в м2)");
            if (SecurityContext.autovxod == 3)
            {
                dtHouse.Columns.Add("Номер клиента");
                dtHouse.Columns.Add("ФИО клиента");
            }
            var query = from hous in db.House
                        join cllient in db.Client on hous.IdClient equals cllient.id
                        select new
                        {
                            hous.IdHouse,
                            hous.NumberOfRooms,
                            hous.Storeys,
                            hous.square,
                            FIOC = cllient.LastName + " " + cllient.Name + " " + cllient.MiddleName,
                            cl = cllient.id
                        };

            foreach (var rel in query)
            {
                if (SecurityContext.autovxod == 3) //менеджер
                {
                    dtHouse.Rows.Add(rel.IdHouse, rel.Storeys, rel.NumberOfRooms, rel.square,rel.cl,rel.FIOC);
                }
                if (SecurityContext.autovxod == 1) //Риелтор
                {
                    if(SecurityContext.idClient == rel.cl)
                    dtHouse.Rows.Add(rel.IdHouse, rel.Storeys, rel.NumberOfRooms, rel.square);
                }

            }
            return dtHouse;
        }

        private void HouseLi_Loaded(object sender, RoutedEventArgs e)
        {
            HouseLi.ItemsSource = dtHouse.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrHouse re = new RegistrHouse();
            this.Hide();
            re.Show();
        }

        private void HouseLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.id = int.Parse((dtHouse.Rows[HouseLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentHouse cur = new CurrentHouse();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                HouseLi.ItemsSource = dtHouse.DefaultView;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            HouseLi.Items.Refresh();
            HouseLi.UpdateLayout();

            HouseLi.SelectAllCells();
            HouseLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, HouseLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            HouseLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список Домов";
            saveFileDialog.DefaultExt = ".xls";
            saveFileDialog.Filter = "Excel|*.xls|Excel 2010|*.xlsx|CSV files (*.csv)|*.CSV";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, result.Replace(',', ' '), Encoding.Default);
                MessageBox.Show("Фаил создан!");

            }
        }
    }
}

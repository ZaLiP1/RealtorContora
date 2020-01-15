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
    /// Логика взаимодействия для ApartList.xaml
    /// </summary>
    public partial class ApartList : Window
    {
        public ApartList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrApart re = new RegistrApart();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                TypeProperty re = new TypeProperty();
                this.Hide();
                re.Show();

        }
        DataTable dtType = GetApartList();
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public static DataTable GetApartList()
        {
            
                RealtorEntities db = new RealtorEntities();
                DataTable dtType = new DataTable();
                dtType.Columns.Add("Номер");
                dtType.Columns.Add("Этаж");
                dtType.Columns.Add("Количество комнат");
                dtType.Columns.Add("Площадь (в м2)");
            if (SecurityContext.autovxod == 3)
            {
                dtType.Columns.Add("Номер клиента");
                dtType.Columns.Add("ФИО клиента");
            }
                var query = from apart in db.Apartment
                        join cllient in db.Client on apart.IdClient equals cllient.id
                        select new
                        {
                            apart.IdApartment,
                            apart.NumberOfRooms,
                            apart.Floor,
                            apart.square,
                            FIOC = cllient.LastName + " " + cllient.Name + " " + cllient.MiddleName,
                            cl = cllient.id
                        };
               

            foreach (var rel in query)
            {
                if (SecurityContext.autovxod == 3)
                {

                    dtType.Rows.Add(rel.IdApartment, rel.Floor, rel.NumberOfRooms, rel.square,rel.cl,rel.FIOC);
                }
                if (SecurityContext.autovxod == 1)
                {
                    if (SecurityContext.idClient == rel.cl)
                    {
                        dtType.Rows.Add(rel.IdApartment, rel.Floor, rel.NumberOfRooms, rel.square);
                    }
                }
            }
                return dtType;
            }

     

        private void Type_Loaded(object sender, RoutedEventArgs e)
        {
            Type.ItemsSource = dtType.DefaultView;
        }

        private void Type_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.id = int.Parse((dtType.Rows[Type.SelectedIndex].ItemArray[0].ToString()));
                CurrentApart cur = new CurrentApart();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                Type.ItemsSource = dtType.DefaultView;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            Type.Items.Refresh();
            Type.UpdateLayout();

            Type.SelectAllCells();
            Type.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, Type);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            Type.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список квартир";
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

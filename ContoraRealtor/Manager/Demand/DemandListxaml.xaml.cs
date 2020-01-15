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
    /// Логика взаимодействия для DemandListxaml.xaml
    /// </summary>
    public partial class DemandListxaml : Window
    {
        public DemandListxaml()
        {
            InitializeComponent();
        }

        DataTable dtDemand = new DataTable();
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            var query = from demand in db.demand
                        join realtor in db.Realtor on demand.IdRealtor equals realtor.id
                        join client in db.Client on demand.IdClient equals client.id
                        join NameTyp in db.NameTypPropetry on demand.NameType equals NameTyp.IdNamyType
                        select new
                        {
                            demand.IdDemand,
                            FioClient = client.LastName + " " + client.Name + " " + client.MiddleName,
                     
                            phone = client.Phone,
                            FioRealtor = realtor.LastName + " " + realtor.Name + " " + realtor.MiddleName,
                            Comiss = realtor.Comission,
                            NameTyp = NameTyp.NameType,
                            demand.MinPrice,
                            demand.MaxPrice
                            
                        };

            dtDemand.Columns.Add("id");
            dtDemand.Columns.Add("ФИО клиента");
            dtDemand.Columns.Add("Номер телефона");
            dtDemand.Columns.Add("ФИО риелтора");
            dtDemand.Columns.Add("Доля комисси");
            dtDemand.Columns.Add("Тип объекта недвижимости");
            dtDemand.Columns.Add("Минимальная цена (в рублях)");
            dtDemand.Columns.Add("Максимальная цена (в рублях)");


            foreach (var rel in query)
            {

                dtDemand.Rows.Add(rel.IdDemand, rel.FioClient, rel.phone, rel.FioRealtor, rel.Comiss, rel.NameTyp,rel.MinPrice,rel.MaxPrice);

            }

            DemandLi.ItemsSource = dtDemand.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Realtors re = new Realtors();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrDemand re = new RegistrDemand();
            this.Hide();
            re.Show();
        }

        private void DemandLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idDemand = int.Parse((dtDemand.Rows[DemandLi.SelectedIndex].ItemArray[0].ToString()));

                CurrentDemand cur = new CurrentDemand();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                DemandLi.ItemsSource = dtDemand.DefaultView;
            }
        }

        private void DemandLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            DemandLi.Items.Refresh();
            DemandLi.UpdateLayout();

            DemandLi.SelectAllCells();
            DemandLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DemandLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            DemandLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список потребностей";
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

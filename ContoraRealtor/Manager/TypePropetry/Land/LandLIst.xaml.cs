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
    /// Логика взаимодействия для LandLIst.xaml
    /// </summary>
    public partial class LandLIst : Window
    {
        public LandLIst()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TypeProperty re = new TypeProperty();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistLand re = new RegistLand();
            this.Hide();
            re.Show();
        }
        DataTable dtLand = GetLandList();
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LandLi.ItemsSource = dtLand.DefaultView;
        }
        public static DataTable GetLandList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtLand = new DataTable();
            dtLand.Columns.Add("id");
            dtLand.Columns.Add("Площадь (в м2)");
            if (SecurityContext.autovxod == 3)
            {
                dtLand.Columns.Add("Номер клиента");
                dtLand.Columns.Add("ФИО клиента");
            }
            var query = from land in db.Land
                        join cllient in db.Client on land.IdClient equals cllient.id
                        select new
                        {
                            land.IdLand,
                            land.square,
                            FiO = cllient.LastName + " " + cllient.Name + " " + cllient.MiddleName,
                            cl = cllient.id
                        };

            foreach (var rel in query)
            {
                if (SecurityContext.autovxod == 3) //Менеджер
                {
                    dtLand.Rows.Add(rel.IdLand, rel.square,rel.cl,rel.FiO);
                }
                if (SecurityContext.autovxod == 1) //Клиент
                {
                    if (SecurityContext.idClient == rel.cl)
                    {
                        dtLand.Rows.Add(rel.IdLand, rel.square);
                    }
                }

            }
            return dtLand;
        }

        private void LandLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.id = int.Parse((dtLand.Rows[LandLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentLand cur = new CurrentLand();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                LandLi.ItemsSource = dtLand.DefaultView;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            LandLi.Items.Refresh();
            LandLi.UpdateLayout();

            LandLi.SelectAllCells();
            LandLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, LandLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            LandLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список земельных участков";
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

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
    /// Логика взаимодействия для ManagerList.xaml
    /// </summary>
    public partial class ManagerList : Window
    {
        public ManagerList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // форма менеджера
        {
            Realtors re = new Realtors();
            this.Hide();
            re.Show();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e) //форма нового менеджера
        {
            RegistrManager re = new RegistrManager();
            this.Hide();
            re.Show();
        }
        DataTable dtManager = GetRealtorList();
        private void ManagerLi_Loaded(object sender, RoutedEventArgs e)
        {
            ManagerLi.ItemsSource = dtManager.DefaultView;
        }

        public static DataTable GetRealtorList()
        {
            RealtorEntities db = new RealtorEntities();
            DataTable dtManager = new DataTable();
            dtManager.Columns.Add("id");
            dtManager.Columns.Add("Фамилия");
            dtManager.Columns.Add("Имя");
            dtManager.Columns.Add("Отчество");
            dtManager.Columns.Add("Логин");
            dtManager.Columns.Add("Пароль");
            var Query = db.Manager;

            foreach (var rel in Query)
            {

                dtManager.Rows.Add(rel.IdManager,rel.LastName,rel.Name,rel.MiddleName, rel.Login, rel.Password);

            }
            return dtManager;
        }

        private void ManagerLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idManager = int.Parse((dtManager.Rows[ManagerLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentManager re = new CurrentManager();
                this.Hide();
                re.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                ManagerLi.ItemsSource = dtManager.DefaultView;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            ManagerLi.Items.Refresh();
            ManagerLi.UpdateLayout();

            ManagerLi.SelectAllCells();
            ManagerLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, ManagerLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            ManagerLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список менеджеров";
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

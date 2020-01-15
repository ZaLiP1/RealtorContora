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
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Window
    {
        public ClientList()
        {
            InitializeComponent();
        }

        private void ClientLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        DataTable dtClient = GetClientList();
        private void ClientLi_Loaded(object sender, RoutedEventArgs e)
        {   
            ClientLi.ItemsSource = dtClient.DefaultView;
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
            dtClient.Columns.Add("Логин");
            dtClient.Columns.Add("Пароль");
            var Query = db.Client;

            foreach (var rel in Query)
            {

                dtClient.Rows.Add(rel.id, rel.LastName, rel.Name, rel.MiddleName, rel.Phone,rel.Login,rel.Password);

            }
            return dtClient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Realtors cur = new Realtors();
            this.Hide();
            cur.Show();

        }

        private void ClientLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idClient = int.Parse((dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentClient cur = new CurrentClient();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                ClientLi.ItemsSource = dtClient.DefaultView;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrClient cur = new RegistrClient();
            this.Hide();
            cur.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            ClientLi.Items.Refresh();
            ClientLi.UpdateLayout();

            ClientLi.SelectAllCells();
            ClientLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, ClientLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            ClientLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список клиентов";
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

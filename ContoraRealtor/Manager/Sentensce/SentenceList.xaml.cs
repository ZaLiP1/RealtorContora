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
    /// Логика взаимодействия для SentenceList.xaml
    /// </summary>
    public partial class SentenceList : Window
    {
        public SentenceList()
        {
            InitializeComponent();
        }
        DataTable dtSentence = new DataTable();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Realtors re = new Realtors();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrSentence re = new RegistrSentence();
            this.Hide();
            re.Show();
        }

        private void SentenceLi_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();

            var query = from sentence in db.Sentence
                        join realtor in db.Realtor on sentence.IdRealtor equals realtor.id
                        join client in db.Client on sentence.IdClient equals client.id
                        join propert in db.property on sentence.IdProperty equals propert.idProperty
                        select new
                        {
                            sentence.IdSentence,
                            FioClient = client.LastName + " " + client.Name + " " + client.MiddleName,
                            phone = client.Phone,
                            FioRealtor = realtor.LastName + " " + realtor.Name + " " + realtor.MiddleName,
                            Comiss = realtor.Comission,
                            cit = propert.City,
                            str = propert.Street,
                            Numbers = propert.Number,
                            Coordinat = propert.latitude + " " + propert.Longitude,
                            sentence.Price

                        };
            dtSentence.Columns.Add("id");
            dtSentence.Columns.Add("ФИО клиента");
            dtSentence.Columns.Add("Номер телефона");
            dtSentence.Columns.Add("ФИО риелтора");
            dtSentence.Columns.Add("Доля комисси");
            dtSentence.Columns.Add("Город");
            dtSentence.Columns.Add("Улица");
            dtSentence.Columns.Add("Номер дома (квартиры)");
            dtSentence.Columns.Add("Координаты");
            dtSentence.Columns.Add("Цена (в рублях)");
            foreach (var rel in query)
            {

                dtSentence.Rows.Add(rel.IdSentence, rel.FioClient, rel.phone, rel.FioRealtor, rel.Comiss, rel.cit,rel.str,rel.Numbers, rel.Coordinat, rel.Price);

            }

            SentenceLi.ItemsSource = dtSentence.DefaultView;
        }

        private void SentenceLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SentenceLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idSentence = int.Parse((dtSentence.Rows[SentenceLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentSentence cur = new CurrentSentence();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                SentenceLi.ItemsSource = dtSentence.DefaultView;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
            SentenceLi.Items.Refresh();
            SentenceLi.UpdateLayout();

            SentenceLi.SelectAllCells();
            SentenceLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, SentenceLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            SentenceLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список предложений";
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


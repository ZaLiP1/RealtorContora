using ContoraRealtor.FormaClienta_1;
using ContoraRealtor.FormaRealtor;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;


namespace ContoraRealtor
{
    /// <summary>
    /// Логика взаимодействия для Deal_1.xaml
    /// </summary>
    public partial class Deal_1 : Window
    {
        public Deal_1()
        {
            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 3)
            {
                Realtors re = new Realtors();
                this.Hide();
                re.Show();
            }
            if (SecurityContext.autovxod == 1)
            {
                ClientsForms re = new ClientsForms();
                this.Hide();
                re.Show();
            }
            if (SecurityContext.autovxod == 2)
            {
                FormsRealtors re = new FormsRealtors();
                this.Hide();
                re.Show();
            }
        }
        DataTable dtDeal = new DataTable();
        private void DealLi_Loaded(object sender, RoutedEventArgs e)
        {
            

                RealtorEntities db = new RealtorEntities();
            var query = from deal in db.Deal
                        join sentence in db.Sentence on deal.IdSentence equals sentence.IdSentence
                        join demand in db.demand on deal.IdDemand equals demand.IdDemand
                        join nametype in db.NameTypPropetry on demand.NameType equals nametype.IdNamyType
                        join cllient in db.Client on sentence.IdClient equals cllient.id
                        join realtor in db.Realtor on sentence.IdRealtor equals realtor.id
                        join propert in db.property on sentence.IdProperty equals propert.idProperty
                        select new
                        {
                            deal.idDeal,
                            idDeman = demand.IdDemand,
                            FIOC = cllient.LastName + " " + cllient.Name + " " + cllient.MiddleName,
                            FIOR = realtor.LastName + " " + realtor.Name + " " + realtor.MiddleName,
                            comis = realtor.Comission,
                            cit = propert.City + " , " + propert.Street + " , " + propert.Number,
                            Coordinat = propert.latitude + " " + propert.Longitude,
                            nametyp = nametype.NameType,
                            price = sentence.Price,
                            idsenten = sentence.IdSentence,
                             cl = cllient.id,
                             re = realtor.id,
                            //deal.ComPrice,
                            Coma = sentence.Price*(realtor.Comission/100.0),
                            deal.ComPrice

                        };
            dtDeal.Columns.Add("Номер сделки");
            dtDeal.Columns.Add("Номер потребности");
            dtDeal.Columns.Add("Номер предложений");
            dtDeal.Columns.Add("ФИО клиента");
            dtDeal.Columns.Add("ФИО риелтора");
            dtDeal.Columns.Add("Доля от комиссии %");
            dtDeal.Columns.Add("Объект недвижимости");
            dtDeal.Columns.Add("Адрес");
            dtDeal.Columns.Add("Координаты");
            dtDeal.Columns.Add("Цена без коммиссии");
            //dtDeal.Columns.Add("Доля от проба чегото");
            dtDeal.Columns.Add("Доля от общей суммы");
            dtDeal.Columns.Add("Общая сумма");

            foreach (var rel in query)
            { if (SecurityContext.autovxod == 3)
                {
                    dtDeal.Rows.Add(rel.idDeal, rel.idDeman, rel.idsenten, rel.FIOC, rel.FIOR, rel.comis, rel.nametyp, rel.cit, rel.Coordinat, rel.price, /*rel.ComPrice,*/ rel.Coma,rel.ComPrice);
                }
                if (SecurityContext.autovxod == 1)
                {
                    if (SecurityContext.idClient == rel.cl)
                    {
                        dtDeal.Rows.Add(rel.idDeal, rel.idDeman, rel.idsenten, rel.FIOC, rel.FIOR, rel.comis, rel.nametyp, rel.cit, rel.Coordinat, rel.price, /*rel.ComPrice,*/ rel.Coma, rel.ComPrice);

                    }
                }
                if (SecurityContext.autovxod == 2)
                {
                    if (SecurityContext.idRealtor == rel.re)
                    {
                        dtDeal.Rows.Add(rel.idDeal, rel.idDeman, rel.idsenten, rel.FIOC, rel.FIOR, rel.comis, rel.nametyp, rel.cit, rel.Coordinat, rel.price, /*rel.ComPrice,*/ rel.Coma, rel.ComPrice);

                    }
                }
            }

            DealLi.ItemsSource = dtDeal.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrDeal re = new RegistrDeal();
            this.Hide();
            re.Show();
        }

        private void DealLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idDeal = int.Parse((dtDeal.Rows[DealLi.SelectedIndex].ItemArray[0].ToString()));

                CurrentDeal cur = new CurrentDeal();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                DealLi.ItemsSource = dtDeal.DefaultView;
            }
        }

        private void Add_Loaded(object sender, RoutedEventArgs e)
        {
            if(SecurityContext.autovxod == 2)
            {
                Add.Visibility = Visibility.Collapsed;
            }
        }

        private void ExcelFails_Click(object sender, RoutedEventArgs e)
        {
          
            DealLi.Items.Refresh();
            DealLi.UpdateLayout();

            DealLi.SelectAllCells();
            DealLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DealLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            DealLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список сделок";
            saveFileDialog.DefaultExt = ".xls";
            saveFileDialog.Filter = "Excel|*.xls|Excel 2010|*.xlsx|CSV files (*.csv)|*.CSV";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, result.Replace(',', ' '), Encoding.Default);
                MessageBox.Show("Фаил создан!");

            }
            //DealLi.SelectAllCells();
            //DealLi.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
            //ApplicationCommands.Copy.Execute(null, DealLi);
            //DealLi.UnselectAllCells();
            //string result1 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            //Clipboard.Clear();

            //var convertTobyte = Encoding.ASCII.GetBytes(result1);
            //var stream = new StreamWriter(_filename);
            //stream.WriteLine(convertTobyte);
            //stream.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();

        }
    }
}

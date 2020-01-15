
using ContoraRealtor.FormaRealtor;
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
    /// Логика взаимодействия для Sentensce_Managers.xaml
    /// </summary>
    public partial class Sentensce_Managers : Window
    {
        public Sentensce_Managers()
        {
            InitializeComponent();
        }
        DataTable dtSentence = new DataTable();
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.autovxod == 3) //realtor
            {
                Realtors re = new Realtors();
                this.Hide();
                re.Show();
            }
            if (SecurityContext.autovxod == 2) //realtor
            {
                FormsRealtors re = new FormsRealtors();
                this.Hide();
                re.Show();
            }
            }

        private void SentensceLi_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();

            var query = from Property in db.property
                        
                        select new
                        {
                            Property.idProperty,
                            cit = Property.City,
                            str = Property.Street,
                            Numbers = Property.Number,
                            Lat = Property.latitude,
                            Long = Property.Longitude,
                            id = Property.idRealtor,

                        };
            dtSentence.Columns.Add("id");
            dtSentence.Columns.Add("Город");
            dtSentence.Columns.Add("Улица");
            dtSentence.Columns.Add("Номер дома(квартиры)");
            dtSentence.Columns.Add("Широта");
            dtSentence.Columns.Add("Долгота");
            foreach (var rel in query)
            {
                if (SecurityContext.autovxod == 3)
                {
                    dtSentence.Rows.Add(rel.idProperty, rel.cit, rel.str, rel.Numbers, rel.Lat, rel.Long);
                }
                if (SecurityContext.autovxod == 2)
                {   if(SecurityContext.idRealtor == rel.id)
                    dtSentence.Rows.Add(rel.idProperty, rel.cit, rel.str, rel.Numbers, rel.Lat, rel.Long);
                }

            }

            SentensceLi.ItemsSource = dtSentence.DefaultView;
        }

        private void SentensceLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idProperty = int.Parse((dtSentence.Rows[SentensceLi.SelectedIndex].ItemArray[0].ToString()));
                CurrentSentensce_Managers cur = new CurrentSentensce_Managers();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Вы пытаетесь выбрать пустое поле");
                SentensceLi.ItemsSource = dtSentence.DefaultView;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddSentensce_Managers cur = new AddSentensce_Managers();
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
            SentensceLi.Items.Refresh();
            SentensceLi.UpdateLayout();

            SentensceLi.SelectAllCells();
            SentensceLi.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, SentensceLi);
            var result = (string)Clipboard.GetData(DataFormats.Text);
            SentensceLi.UnselectAllCells();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Список объектов недвижимости у предложения";
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

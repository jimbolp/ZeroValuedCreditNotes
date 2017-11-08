using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZeroValuedCreditNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _requestToDbSent = false;
        LibraSofiaEntities dbSofia = null;
        LibraBurgasEntities dbBurgas = null;
        LibraPlovdivEntities dbPlovdiv = null;
        LibraVarnaEntities dbVarna = null;
        LibraVelikoTyrnovoEntities dbVelikoTyrnovo = null;
        
        public MainWindow()
        {
            InitializeComponent();
            dateFrom.SelectedDate = DateTime.Now;
            dateTo.SelectedDate = DateTime.Now;
            try
            {
                dbSofia = new LibraSofiaEntities();
                dbBurgas = new LibraBurgasEntities();
                dbPlovdiv = new LibraPlovdivEntities();
                dbVarna = new LibraVarnaEntities();
                dbVelikoTyrnovo = new LibraVelikoTyrnovoEntities();
            }
            catch (Exception)
            {
                MessageBox.Show("No connection with the database!", "Database Error");
            }
        }

        private void CorrectSelectedDates()
        {
            if(dateFrom.SelectedDate > dateTo.SelectedDate)
            {
                DateTime? temp = dateFrom.SelectedDate;
                dateFrom.SelectedDate = dateTo.SelectedDate;
                dateTo.SelectedDate = temp;
            }
        }

        private void getInvoices_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            CorrectSelectedDates();
            try
            {
                Thread t = new Thread(GetDataFromDB);
                t.Start();
            }
            catch(Exception ex)
            {
                MessageBoxResult result;
                result = MessageBox.Show(ex.Message + Environment.NewLine + "Моля изберете \"Yes\" за да изпратите съобщението за грешка на вашата съпорт група!", "Проблем!", MessageBoxButton.YesNo);
                if(MessageBoxResult.Yes == result)
                {
                    SendErrorByMail(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }

        private void SendErrorByMail(string stackTrace)
        {
            switch(SendEmail.Send("Automatic mail, send by application \"ZeroValuedCreditNotes\"!", stackTrace))
            {
                case 0:
                    MessageBox.Show("Съобщението за грешка беше изпратено успешно!");
                    break;
                case 1:
                    MessageBox.Show("Има проблем с изпращането на съобщението за грешка! Моля свържете се с вашата съпорт група!", "Грешка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                default:
                    break;
            }
        }

        private void GetDataFromDB()
        {
            if (_requestToDbSent)
            {
                MessageBox.Show("Заявката се изпълнява. Моля изчакайте!", "Двойна заявка!");
                return;
            }
            _requestToDbSent = true;
            try
            {
                List<ZeroInvoice> invoices = new List<ZeroInvoice>();
                invoices = GetInvoices();

                PopulateDataGrid(invoices);
                _requestToDbSent = false;
            }
            catch(Exception e)
            {
                _requestToDbSent = false;
                //MessageBox.Show(e.ToString());
                throw e;
            }
            finally
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { Mouse.OverrideCursor = null; }));                
            }
        }

        private List<ZeroInvoice> GetInvoices()
        {
            List<ZeroInvoice> invoices = new List<ZeroInvoice>();
            DateTime from = dateFrom.Dispatcher.Invoke<DateTime>(new Func<DateTime>(delegate { return dateFrom.SelectedDate ?? DateTime.Now; }));
            DateTime to = dateTo.Dispatcher.Invoke<DateTime>(new Func<DateTime>(delegate { return dateTo.SelectedDate ?? DateTime.Now; }));
            
            if (chckBox_Sofia.Dispatcher.Invoke(new Func<bool>(delegate { return (chckBox_Sofia.IsChecked ?? false); })))
            {
                lock (dbSofia)
                {
                    invoices.AddRange(dbSofia.Sales.Where(s => s.DocDate >= from && s.DocDate <= to && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                    {
                        Branch = "София",
                        CustomerID = s.CustomerID,
                        DocDate = s.DocDate,
                        DocNo = s.DocNo
                    }).ToList());
                }
            }
            if (chckBox_Burgas.Dispatcher.Invoke(new Func<bool>(delegate { return chckBox_Burgas.IsChecked ?? false; })))
            {
                lock (dbBurgas)
                {
                    invoices.AddRange(dbBurgas.Sales.Where(s => s.DocDate >= from && s.DocDate <= to && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                    {
                        Branch = "Бургас",
                        CustomerID = s.CustomerID,
                        DocDate = s.DocDate,
                        DocNo = s.DocNo
                    }).ToList());
                }
            }
            if (chckBox_Plovdiv.Dispatcher.Invoke(new Func<bool>(delegate { return chckBox_Plovdiv.IsChecked ?? false; })))
            {
                lock (dbPlovdiv)
                {
                    invoices.AddRange(dbPlovdiv.Sales.Where(s => s.DocDate >= from && s.DocDate <= to && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                    {
                        Branch = "Пловдив",
                        CustomerID = s.CustomerID,
                        DocDate = s.DocDate,
                        DocNo = s.DocNo
                    }).ToList());
                }
            }
            if (chckBox_Varna.Dispatcher.Invoke(new Func<bool>(delegate { return chckBox_Varna.IsChecked ?? false; })))
            {
                lock (dbVarna)
                {
                    invoices.AddRange(dbVarna.Sales.Where(s => s.DocDate >= from && s.DocDate <= to && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                    {
                        Branch = "Варна",
                        CustomerID = s.CustomerID,
                        DocDate = s.DocDate,
                        DocNo = s.DocNo
                    }).ToList());
                }
            }
            if (chckBox_VelikoTyrnovo.Dispatcher.Invoke(new Func<bool>(delegate { return chckBox_VelikoTyrnovo.IsChecked ?? false; })))
            {
                lock (dbVelikoTyrnovo)
                {
                    invoices.AddRange(dbVelikoTyrnovo.Sales.Where(s => s.DocDate >= from && s.DocDate <= to && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                    {
                        Branch = "Велико Търново",
                        CustomerID = s.CustomerID,
                        DocDate = s.DocDate,
                        DocNo = s.DocNo
                    }).ToList());
                }
            }
            return invoices;
        }

        private void PopulateDataGrid(List<ZeroInvoice> invoices)
        {
            ObservableCollection<ZeroInvoice> collection = new ObservableCollection<ZeroInvoice>();
            foreach(var invoice in invoices)
            {
                collection.Add(invoice);
            }
            lock (dataGrid)
            {
                Dispatcher.Invoke(() => dataGrid.ItemsSource = collection);
            }
        }

        private void MenuItemSelectAll_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectAll();
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime?) || e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
        }
    }
}

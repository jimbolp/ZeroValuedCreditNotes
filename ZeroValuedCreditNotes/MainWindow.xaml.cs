using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeroValuedCreditNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LibraSofiaEntities dbSofia = null;
        private LibraBurgasEntities dbBurgas = null;
        private LibraPlovdivEntities dbPlovdiv = null;
        private LibraVarnaEntities dbVarna = null;
        private LibraVelikoTyrnovoEntities dbVelikoTyrnovo = null;
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

        private void getInvoices_Click(object sender, RoutedEventArgs e)
        {
            GetDataFromDB();
        }

        private void GetDataFromDB()
        {
            try
            {
                List<ZeroInvoice> invoices = new List<ZeroInvoice>();
                invoices.AddRange(SofiaInvoices());

                PopulateDataGrid(invoices);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private List<ZeroInvoice> SofiaInvoices()
        {
            List<ZeroInvoice> invoices = new List<ZeroInvoice>();
            if (chckBox_Sofia.IsChecked ?? false)
            {
                invoices.AddRange(dbSofia.Sales.Where(s => s.DocDate >= dateFrom.SelectedDate && s.DocDate <= dateTo.SelectedDate && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                {
                    Branch = "София",
                    CustomerID = s.CustomerID,
                    DocDate = s.DocDate,
                    DocNo = s.DocNo
                }).ToList());
            }
            if (chckBox_Burgas.IsChecked ?? false)
            {
                invoices.AddRange(dbBurgas.Sales.Where(s => s.DocDate >= dateFrom.SelectedDate && s.DocDate <= dateTo.SelectedDate && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                {
                    Branch = "Бургас",
                    CustomerID = s.CustomerID,
                    DocDate = s.DocDate,
                    DocNo = s.DocNo
                }).ToList());
            }
            if (chckBox_Plovdiv.IsChecked ?? false)
            {
                invoices.AddRange(dbPlovdiv.Sales.Where(s => s.DocDate >= dateFrom.SelectedDate && s.DocDate <= dateTo.SelectedDate && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                {
                    Branch = "Пловдив",
                    CustomerID = s.CustomerID,
                    DocDate = s.DocDate,
                    DocNo = s.DocNo
                }).ToList());
            }
            if (chckBox_Varna.IsChecked ?? false)
            {
                invoices.AddRange(dbVarna.Sales.Where(s => s.DocDate >= dateFrom.SelectedDate && s.DocDate <= dateTo.SelectedDate && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                {
                    Branch = "Варна",
                    CustomerID = s.CustomerID,
                    DocDate = s.DocDate,
                    DocNo = s.DocNo
                }).ToList());
            }
            if (chckBox_VelikoTyrnovo.IsChecked ?? false)
            {
                invoices.AddRange(dbVelikoTyrnovo.Sales.Where(s => s.DocDate >= dateFrom.SelectedDate && s.DocDate <= dateTo.SelectedDate && s.PaymentSum == 0 && s.CorrectedSaleID != 0 && s.CorrectedSaleID != null).Select(s => new ZeroInvoice
                {
                    Branch = "Велико Търново",
                    CustomerID = s.CustomerID,
                    DocDate = s.DocDate,
                    DocNo = s.DocNo
                }).ToList());
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
            dataGrid.ItemsSource = collection;
        }

        private void MenuItemSelectAll_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectAll();
        }
    }
}

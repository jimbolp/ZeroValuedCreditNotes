using System;
using System.ComponentModel;

namespace ZeroValuedCreditNotes
{
    internal class ZeroInvoice
    {
        [DisplayName("Склад")]
        public string Branch { get; set; }
        [DisplayName("Клиент Номер")]
        public int? CustomerID { get; set; }
        [DisplayName("Дата")]
        public DateTime? DocDate { get; set; }
        [DisplayName("Ф-ра")]
        public long? DocNo { get; set; }

    }
}
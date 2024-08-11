using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyectos.ProsperDaily.MVVM.Models
{
    public class TransactionSummary
    {
        public DateTime TransactionsDate { get; set; }
        public string ShownDate {  get; set; }
        public decimal TransactionTotal { get; set; }
    }
}

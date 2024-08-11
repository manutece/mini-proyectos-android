using MiniProyectos.ProsperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyectos.ProsperDaily.MVVM.ModelViews
{
    public class TransactionSummary
    {
        public Transaction Transaction { get; set; } = new Transaction();

        public string SaveTransaction()
        {
            App.TransactionsRepo.SaveItem(Transaction);
            return App.TransactionsRepo.StatusMessage;
        }
    }
}

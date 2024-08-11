using MiniProyectos.ProsperDaily.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace MiniProyectos.ProsperDaily.MVVM.ModelViews
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<Models.TransactionSummary> Summary { get; set; }
        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionsRepo.GetItems();
            var result = new List<Models.TransactionSummary>();
            var groupedTransactions = data.GroupBy(t => t.OperationDate);
            foreach(var group in groupedTransactions)
            {
                var transactionSummary = new Models.TransactionSummary
                {
                    TransactionsDate = group.Key,
                    TransactionTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
                    ShownDate = group.Key.ToString("MM/dd")
                };
                result.Add(transactionSummary);
            }

            result = result.OrderBy(x => x.TransactionsDate).ToList();

            Summary = new ObservableCollection<Models.TransactionSummary>(result);
            var spendingList = data.Where(x => x.IsIncome == false);
            SpendingList = new ObservableCollection<Transaction>(spendingList);
        }
    }
}

using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dangl.Calculator;

namespace MiniProyectos.Calculator.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        public string Formula { get; set; }
        public string Result { get; set; } = "";

        public ICommand OperationCommand => new Command((number) => {
            if (Result == "")
            {
                Formula += number;
            } else
            {
                Formula = Result += number;
                Result = "";
            }
            
        });
        public ICommand CleanCommand => new Command(() =>
        {
            Result = "";
            Formula = "";
        });
        public ICommand BackspaceCommand => new Command(() =>
        {
            if (Formula.Length > 0)
            {
                Formula = Formula.Substring(0, Formula.Length - 1);
            }
        });
        public ICommand CalculateCommand => new Command(() =>
        {
            if (Formula.Length == 0)
                return;
            var calculation = Dangl.Calculator.Calculator.Calculate(Formula);
            Result = calculation.Result.ToString();
        });
    }
}

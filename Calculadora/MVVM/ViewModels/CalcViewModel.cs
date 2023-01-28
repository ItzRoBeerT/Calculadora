using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalcViewModel
    {
        public string Formula { get; set; }
        public double Resultado { get; set; }
        public ICommand ClickCommand { get; set; }

        public CalcViewModel()
        {
            Formula = "";
            Resultado = 0;

            ClickCommand = new Command((s) =>
            {
                string btnText = s.ToString();
                switch (btnText)
                {
                    case "AC":
                        Formula = "";
                        break;
                    case "⌫":
                        BorrarUltimo();
                        break;
                    case "%":
                        CalcularPorcentaje();
                        break;
                    case "=":
                        Calcular();
                        break;
                    default:
                        Formula += btnText;
                        break;
                }
            });
        }

        private void BorrarUltimo()
        {
            string str="";
            for (int i = 0; i < Formula.Length-1; i++)
            {
                str += Formula[i];
            }
            Formula = str;
        }

        private void CalcularPorcentaje()
        {
            double operacion = Calculator.Calculate(Formula).Result;
            Resultado = operacion / 100;
            Formula = "";
        }

        private void Calcular()
        {
            Resultado =  Calculator.Calculate(Formula).Result;
            Formula = "";
        }
    }
}

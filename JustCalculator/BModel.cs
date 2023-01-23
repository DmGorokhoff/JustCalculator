using System;
using System.Data;

namespace JustCalculator
{
    public interface ICalculations
    {
        double Calc_Root(double tmpCalcRoot);
        double Calc_Degree(string tmpCalcDeg);
        string Calc_Persent(string tmpCalcPers);

    }
    class Calculations : ICalculations
    {
        public string Calc_Persent(string tmpCalcPers) //исчисление процентов
        {
            tmpCalcPers = tmpCalcPers.Replace(",", ".");
            tmpCalcPers = tmpCalcPers.Replace("%", "/100");
            DataTable dt = new DataTable();
            var v = dt.Compute(tmpCalcPers, "");
            string res = v.ToString();
            return res;
        }
        public double Calc_Root(double tmpCalcRoot) //вычисление корня
        {
            tmpCalcRoot = Math.Sqrt(tmpCalcRoot);
            return tmpCalcRoot;            
        }
        public double Calc_Degree(string tmpCalcDeg) //вычисление степени
        {
            string[] arr = tmpCalcDeg.Split('^');
            double x = double.Parse(arr[0].ToString());
            double y = double.Parse(arr[1].ToString());
            double tmp1 = Math.Pow(x, y);            
            return tmp1;
        }

    }
}

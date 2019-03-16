using System;
namespace Lab5
{
    public enum CalculatorOperation { Add = '+', Sub = '-', Mul = '*', Div = '/' };

    public interface ICalculator
    {
        double? Left { get; set; }

        double? Right { get; set; }

        CalculatorOperation? Operation { get; set; }

        double? Result { get; }

        void Compute();
    }

    public class CalcService : ICalculator
    {
        public double? Left { get; set; }

        public double? Right { get; set; }

        public CalculatorOperation? Operation { get; set; }

        public double? Result { get; private set; }

        public CalcService()
        {
        }

        public void Compute()
        {
            if (!Operation.HasValue)
                return;

            switch (Operation.Value)
            {
                case CalculatorOperation.Add:
                    Result = Left + Right;
                    break;
                case CalculatorOperation.Sub:
                    Result = Left - Right;
                    break;
                case CalculatorOperation.Mul:
                    Result = Left * Right;
                    break;
                case CalculatorOperation.Div:
                    Result = Left / Right;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Left} {(char)Operation} {Right} = {Result}";
        }
    }
}

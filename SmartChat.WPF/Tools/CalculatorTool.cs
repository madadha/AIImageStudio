using System;
using System.Data;

namespace SmartChat.WPF.Tools
{
    public static class CalculatorTool
    {
        public static string Calculate(string expression)
        {
            try
            {
                var table = new DataTable();
                var result = table.Compute(expression, null);
                return result.ToString() ?? "0";
            }
            catch (Exception)
            {
                return "Invalid mathematical expression.";
            }
        }
    }
}
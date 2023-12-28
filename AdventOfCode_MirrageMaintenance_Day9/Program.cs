using System.Reflection;

namespace AdventOfCode_MirrageMaintenance_Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FILE_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "InputDay9.txt");
            var data = FileReader.ReadDataFromFile(FILE_PATH);

            Calculator.AddCalculations(data);
            Calculator.UpdateCalculations(data);
            Calculator.SetSum(data);

            var result = data.Sum(x => x.SumOfLastRecords);
            Console.WriteLine($"Sum is {result}");
        }
    }
}
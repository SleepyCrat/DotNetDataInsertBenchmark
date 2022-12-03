using ABunchOfData.ConsoleApp.Models;
using BenchmarkDotNet.Running;
using System.Text;

namespace ABunchOfData.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BigInsertBenchMark>();
        }
    }
}
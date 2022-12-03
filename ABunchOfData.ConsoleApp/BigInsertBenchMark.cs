using ABunchOfData.ConsoleApp.DataMovers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp
{
    [MemoryDiagnoser(displayGenColumns: false)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [SimpleJob(runStrategy: RunStrategy.ColdStart, warmupCount: 0, launchCount: 1, invocationCount: 1, targetCount: 1)]
    [HtmlExporter]
    [Outliers(Perfolizer.Mathematics.OutlierDetection.OutlierMode.DontRemove)]
    public class BigInsertBenchMark
    {
        [GlobalSetup]
        public void Setup()
        {
            DataSetupClass.Setup();
        }

        [Benchmark(Baseline = true, Description = "Using Entity Framework namespace to insert data row by row")]
        public void EFRowByRow()
        {
            var efRowByRow = new EF_Row_by_Row();
            efRowByRow.Run();
        }

        [Benchmark(Description = "Using Entity Framework namespace to insert in batches")]
        public void EFLazyBatch()
        {
            var efLazyBatch = new EF_Lazy_Batch();
            efLazyBatch.Run();
        }

        [Benchmark(Description = "Using System.Data.SqlClient namespace to insert data row by row")]
        public void SqlClientClassicRowByRow()
        {
            var rowByRow = new Sql_Client_Classic_Row_By_Row();
            rowByRow.Run();
        }

        [Benchmark(Description = "Using System.Data.SqlClient namespace to insert data row by row using stored procedure")]
        public void SqlClientClassicSprocRowByRow()
        {
            var rowByRowSproc = new Sql_Client_Classic_Sproc_Row_By_Row();
            rowByRowSproc.Run();
        }

        [Benchmark(Description = "Using System.Data.SqlClient namespace to insert data row by row using table defined types")]
        public void SqlClientClassicUserDefinedTableType()
        {
            var userDefined = new Sql_Client_Classic_User_Defined_Table_Type();
            userDefined.Run();
        }

        [Benchmark(Description = "Using System.Data.SqlClient namespace to insert data by using SqlBulkCopyInsert")]
        public void SqlClientClassicBulkCopyInsert()
        {
            var copy = new Sql_Client_Classic_SqlBulkCopy();
            copy.Run();
        }
    }
}

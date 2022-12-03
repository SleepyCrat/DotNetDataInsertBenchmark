using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace ABunchOfData.ConsoleApp.DataMovers
{
    public class Sql_Client_Classic_SqlBulkCopy
    {
        public void Run()
        {
            DataTable dt = new DataTable("SqlBulkCopyMethod");
            dt.Columns.Add("pk", typeof(int));
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("DateCreatedUTC", typeof(DateTime));

            for (int i = 0; i < DataSetupClass.ModelCollection.Length; i++)
            {
                var newRow = dt.NewRow();
                newRow[1] = DataSetupClass.ModelCollection[i].Id;
                newRow[2] = DataSetupClass.ModelCollection[i].Title;
                newRow[3] = DataSetupClass.ModelCollection[i].DateCreatedUTC;

                dt.Rows.Add(newRow);
            }

            using (var copyClient = new SqlBulkCopy(DataSetupClass.DBConnString, SqlBulkCopyOptions.Default))
            {
                copyClient.BatchSize = DataSetupClass.batchSize;
                copyClient.DestinationTableName = "SqlBulkCopyMethod";
                copyClient.WriteToServer(dt);
            }
        }
    }
}

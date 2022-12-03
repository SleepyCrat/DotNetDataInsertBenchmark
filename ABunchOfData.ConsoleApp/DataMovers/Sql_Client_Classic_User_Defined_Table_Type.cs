using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.DataMovers
{
    public class Sql_Client_Classic_User_Defined_Table_Type
    {
        public void Run()
        {
            var sprocName = "usp_UserDefinedTableTypeSproc";

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("DateCreatedUTC", typeof(DateTime));

            for (int i = 0; i < DataSetupClass.ModelCollection.Length; i++)
            {
                var newRow = dt.NewRow();
                newRow[0] = DataSetupClass.ModelCollection[i].Id;
                newRow[1] = DataSetupClass.ModelCollection[i].Title;
                newRow[2] = DataSetupClass.ModelCollection[i].DateCreatedUTC;

                dt.Rows.Add(newRow);
            }

            using (var theConnection = new SqlConnection(DataSetupClass.DBConnString))
            {
                using (var theCommand = new SqlCommand(sprocName, theConnection))
                {
                    theCommand.CommandType = CommandType.StoredProcedure;
                    theCommand.Connection.Open();
                    theCommand.Parameters.Add(new SqlParameter() { ParameterName = "@bigDataTable", Value = dt, TypeName = "BigInsertTableType", SqlDbType = SqlDbType.Structured });
                    theCommand.ExecuteNonQuery();

                    theCommand.Connection.Close();
                }
            }
        }
    }
}

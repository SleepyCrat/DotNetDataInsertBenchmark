using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.DataMovers
{
    public  class Sql_Client_Classic_Sproc_Row_By_Row
    {
        public void Run()
        {
            var sprocName = "usp_RowByRowSprocProcedure";

            using (var theConnection = new SqlConnection(DataSetupClass.DBConnString))
            {
                using (var theCommand = new SqlCommand(sprocName, theConnection))
                {
                    theCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    theCommand.Connection.Open();
                    for (int i = 0; i < DataSetupClass.ModelCollection.Length; i++)
                    {
                        theCommand.Parameters.Clear();
                        theCommand.Parameters.AddWithValue("@Id", DataSetupClass.ModelCollection[i].Id);
                        theCommand.Parameters.AddWithValue("@title", DataSetupClass.ModelCollection[i].Title);
                        theCommand.Parameters.AddWithValue("@dateCreatedUTC", DataSetupClass.ModelCollection[i].DateCreatedUTC);

                        theCommand.ExecuteNonQuery();

                    }
                    theCommand.Connection.Close();
                }
            }

        }
    }
}

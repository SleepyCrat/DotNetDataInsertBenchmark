using ABunchOfData.ConsoleApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.DataMovers
{
    public class EF_Row_by_Row
    {
        public void Run()
        {
            using (var dataContext = new BigDataContext())
            {
                for (int i = 0; i < DataSetupClass.ModelCollection.Length; i++)
                {
                    EFOneByOneMethodTable dataRow = new EFOneByOneMethodTable()
                    {
                        Id = DataSetupClass.ModelCollection[i].Id,
                        Title= DataSetupClass.ModelCollection[i].Title,
                        DateCreatedUTC = DataSetupClass.ModelCollection[i].DateCreatedUTC
                    };

                    dataContext.Add(dataRow);
                    dataContext.SaveChanges();
                }
            }
        }
    }
}

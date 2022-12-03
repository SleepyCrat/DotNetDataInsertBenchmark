using ABunchOfData.ConsoleApp.EF;

namespace ABunchOfData.ConsoleApp.DataMovers
{
    public class EF_Lazy_Batch
    {
        public void Run()
        {
            using (var dataContext = new BigDataContext())
            {
                for (int i = 0; i < DataSetupClass.ModelCollection.Length; i++)
                {
                    EFLayBatchMethodTable dataRow = new EFLayBatchMethodTable()
                    {
                        Id = DataSetupClass.ModelCollection[i].Id,
                        Title= DataSetupClass.ModelCollection[i].Title,
                        DateCreatedUTC = DataSetupClass.ModelCollection[i].DateCreatedUTC
                    };

                    dataContext.Add(dataRow);
                }

                dataContext.SaveChanges();
            }
        }
    }
}

using ABunchOfData.ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp
{
    public static class DataSetupClass
    {
        private static int maxItems = 100_000;
        public static PlainOldPocoModel[] ModelCollection = new PlainOldPocoModel[maxItems];
        public static int batchSize = 10_000;//size for batch based operations
        public static string DBConnString = "";
        
        public static void Setup()
        {
            IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appSettings.local.json", optional:true , reloadOnChange: true)//my local file that contains my conn string I have git ignored this file to prevent checkin of connection details
            .Build();

            DBConnString = Configuration.GetConnectionString("theDBConnString");

            for (int i = 0; i < maxItems; i++)
            {
                Guid theNewId = Guid.NewGuid();
                var title = $"I am the record {theNewId}";
                DateTime currentDateAndTimeUTC = DateTime.UtcNow;
                ModelCollection[i] = new PlainOldPocoModel { Id = theNewId, Title = title, DateCreatedUTC = currentDateAndTimeUTC };
            }
        }
    }
}

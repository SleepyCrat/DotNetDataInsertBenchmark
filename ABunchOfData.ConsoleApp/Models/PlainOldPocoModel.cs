using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.Models
{
    public class PlainOldPocoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreatedUTC { get; set; }
    }
}

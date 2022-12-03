using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABunchOfData.ConsoleApp.EF
{
    public class EFMethodsBase
    {
        [Key]
        public int Pk { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreatedUTC { get; set; }

    }

    [Table("EF_One_By_One_Method")]
    public class EFOneByOneMethodTable:EFMethodsBase
    {

    }

    [Table("EF_Lazy_Batch_Method")]
    public class EFLayBatchMethodTable : EFMethodsBase
    {

    }
}

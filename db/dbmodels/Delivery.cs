using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace db.dbmodels
{
    public class Delivery : BaseDbModel
    {
        [Required]
        public Provider Provider { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int NumberOfInvoices { get; set; }
    }
}

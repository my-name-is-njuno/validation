using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace db.dbmodels
{
    public class User : BaseDbModel
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Password { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }
        public Provider Provider { get; set; }
        public List<Delivery> Deliverys { get; set; }
    }
}

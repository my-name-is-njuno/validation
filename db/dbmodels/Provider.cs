using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace db.dbmodels
{
    public class Provider : BaseDbModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        [Required, MaxLength(500)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required, MaxLength(50)]
        public string ContactPerson { get; set; }

        public List<Delivery> Deliveries { get; set; }
        public List<User> Users { get; set; }
    }
}

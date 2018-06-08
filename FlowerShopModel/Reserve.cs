﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopModel
{
    public class Reserve
    {
        public int ID { get; set; }

        [Required]
        public string ReserveName { get; set; }

        [ForeignKey("ReserveID")]
        public virtual List<ReserveElement> ReserveElements { get; set; }
    }
}

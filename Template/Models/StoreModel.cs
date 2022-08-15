using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street_address { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        public int Zip_code { get; set; }
        [Required]

        public string phone_number { get; set; }
        public bool Enable_future_order { get; set; }
        [Required]
        public string Day { get; set; }

        public DateTime From_time { get; set; }


        public DateTime To_time { get; set; }


        public bool Open_time { get; set; }

    }
}
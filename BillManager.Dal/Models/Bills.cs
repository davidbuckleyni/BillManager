using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillManager.Dal.Models
{
    public class Bills 
    {


        [PrimaryKey, AutoIncrement]      

        public int Id { get; set; }

        public string UserId { get; set; }
        public DateTime Startdate { get; set; }

        public DateTime EndDate { get; set; }
     
        public string Description { get; set; }


        public string Occurance { get; set; }
        public decimal Price { get; set; }

        public bool isDeleted { get; set; }
        public bool isActive { get; set; }

    }
}

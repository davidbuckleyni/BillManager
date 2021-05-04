using System;
using System.Collections.Generic;
using System.Text;

namespace BillManager.Dal.ViewModels
{
  public  class BillOccuranceTypeViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int   Type { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted{ get; set; }

    }
}

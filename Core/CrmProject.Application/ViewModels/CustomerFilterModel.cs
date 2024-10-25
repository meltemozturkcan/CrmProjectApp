using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.ViewModels
{
    public class CustomerFilterModel
    {
        public string NameFilter { get; set; }
        public string RegionFilter { get; set; }
        public DateTime? FromDate { get; set; }
        public string EmailFilter { get; set; }
    }
}

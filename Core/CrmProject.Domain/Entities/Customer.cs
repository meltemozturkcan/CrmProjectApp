using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public DateTime RegistrationDate { get; set; }
    

    public string FullName => $"{FirstName} {LastName}";//fullname property tanımlayarak firstname ve lastname i maule olarak birliştirmeye gerek kalmaz.
    }
}

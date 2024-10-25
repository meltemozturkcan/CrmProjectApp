using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.Features.Customers.Commands
{
    public record UpdateCustomerCommand(
         int Id,
         string FirstName,
         string LastName,
         string Email,
         string Region
     );
   

}
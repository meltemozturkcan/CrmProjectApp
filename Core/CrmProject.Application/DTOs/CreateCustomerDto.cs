using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.DTOs
{
    public record CreateCustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string Region);
}

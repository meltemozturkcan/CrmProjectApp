using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.Features.Customers.Queries
{
    public record GetCustomersQuery(
        string? NameFilter,
        string? EmailFilter,
        string? RegionFilter,
        DateTime? FromDate,
        DateTime? ToDate,
        int Page = 1,
        int PageSize = 10
    );
}

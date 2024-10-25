using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.DTOs.Auth
{
    public record LoginRequest(
    [Required] string Username,
    [Required] string Password);
}
